using DBScriptRunner.Models;
using DBScriptRunner.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBScriptRunner
{
    public partial class DBScriptRunner : Form
    {
        private Project prj = null;
        private string DBConnectionString = "";

        public DBScriptRunner()
        {
            InitializeComponent();
        }

        private void btnFindFiles_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateInput();
                lstFileMatches.Items.Clear();
                lstFailures.Items.Clear();

                FindMatchingFiles();
                btnRunScripts.Enabled = true;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                btnRunScripts.Enabled = false;
            }
        }

        private readonly List<GridViewDataModel> foundFileList = new List<GridViewDataModel>();
        private void FindMatchingFiles()
        {
            //var finalListOfMacthingFiles = new List<string>();
            var sqlObjectNames = txtDBObjects.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            if (sqlObjectNames.Count() < 1)
                throw new Exception("No objects detected.");
            foreach (var sqlObjName in sqlObjectNames)
            {
                var sqlFileNameToSearch = sqlObjName;
                var multipleFiles = sqlFileNameToSearch.Contains("*");

                if (sqlFileNameToSearch.EndsWith(".sql"))
                {
                    sqlFileNameToSearch = sqlObjName.Replace(".sql", string.Empty);
                }
                else if (sqlFileNameToSearch.EndsWith(".*"))
                {
                    sqlFileNameToSearch = sqlObjName.Replace(".*", string.Empty);
                }

                var files = Directory.GetFiles(cboScriptFolderPath.Text, $"{sqlFileNameToSearch}.sql");
                //IList<GridViewDataModel> f = new List<GridViewDataModel>();
                //foundFileList.Clear();
                //dataGridView1.DataSource = null;
                if (files != null && ((multipleFiles && files.Count() > 0) || files.Count() == 1))
                {
                    var fileNo = 1;
                    foreach (var foundFile in files)
                    {
                        lstFileMatches.Items.Add(foundFile);
                        foundFileList.Add(
                            new GridViewDataModel() { FileNo = fileNo++, FilePath = foundFile }
                            );
                    }
                }
                else
                {
                    lstFailures.Items.Add(sqlObjName);
                }
                //dataGridView1.DataSource = foundFileList;
            }



            if (lstFailures.Items.Count > 0)
            {
                splitContainer3.Panel2Collapsed = false;
            }
            else
            {
                splitContainer3.Panel2Collapsed = true;
            }
        }

        private void SwapFoundFile(int sourceIndex, int targetIndex)
        {
            var tempSource = foundFileList[sourceIndex];
            foundFileList[sourceIndex] = foundFileList[targetIndex];
            foundFileList[targetIndex] = tempSource;

            ReBindDataGridView(targetIndex);
        }

        private void MoveUpFoundFiles()
        {
            if (stagedScriptFilesGridView.RowCount > 0
                && stagedScriptFilesGridView.SelectedRows != null)
            {
                var index = stagedScriptFilesGridView.SelectedRows[0].Index;
                if (index > 0 && index < stagedScriptFilesGridView.RowCount)
                {
                    SwapFoundFile(index, index - 1);
                }
            }
        }

        private void MoveDownFoundFiles()
        {
            if (stagedScriptFilesGridView.RowCount > 0
                && stagedScriptFilesGridView.SelectedRows != null)
            {
                var index = stagedScriptFilesGridView.SelectedRows[0].Index;
                if (index > -1 && index < stagedScriptFilesGridView.RowCount - 1)
                {
                    SwapFoundFile(index, index + 1);
                }
            }
        }

        private void ReBindDataGridView(int selectRowIndex = -1)
        {
            for (int i = 0; i < foundFileList.Count; i++)
            {
                foundFileList[i].FileNo = i + 1;
            }

            stagedScriptFilesGridView.DataSource = null;
            stagedScriptFilesGridView.DataSource = foundFileList;

            stagedScriptFilesGridView.Columns["FileFound"].Visible = false;
            stagedScriptFilesGridView.Columns["FileNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            stagedScriptFilesGridView.Columns["FilePath"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            if (selectRowIndex > -1 && selectRowIndex < stagedScriptFilesGridView.RowCount)
            {
                stagedScriptFilesGridView.Rows[selectRowIndex].Selected = true;
            }
        }

        private void RemoveFoundFiles()
        {
            if (stagedScriptFilesGridView.RowCount > 0
                && stagedScriptFilesGridView.SelectedRows != null)
            {
                var index = stagedScriptFilesGridView.SelectedRows[0].Index;
                if (index > -1 && index < stagedScriptFilesGridView.RowCount)
                {
                    //var userHasConfirmedDelete = !this.ShowDeleteConfirmation;
                    //if (this.ShowDeleteConfirmation)
                    //{
                    //    var deleteConfirmForm = new CustomDialogBox();
                    //    deleteConfirmForm.lblMessage.Text = $"Are you sure to unstage this file?";
                    //    deleteConfirmForm.Text = "Confirmation";
                    //    deleteConfirmForm.btnNoCancel.Click += BtnNoCancel_Click;
                    //    deleteConfirmForm.btnOKYes.Click += BtnOKYes_Click;
                    //    deleteConfirmForm.chkOption1.Click += ChkOption1_Click;
                    //    deleteConfirmForm.ShowDialog(this);
                    //    userHasConfirmedDelete = this.deleteDialogResult;
                    //}                    

                    //if (userHasConfirmedDelete)
                    if(!chkPromptOnDelete.Checked || DialogResult.Yes == MessageBox.Show($"Are you sure you want to unstage this file {foundFileList[index]}?", "Confirm unstage", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        foundFileList.RemoveAt(index);
                        ReBindDataGridView(index);
                    }
                }
            }
        }

        private void ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(this.DBConnectionString))
                throw new Exception("Missing DB name");
            else
            {
                DbConnectionStringBuilder csb = new DbConnectionStringBuilder();
                csb.ConnectionString = this.DBConnectionString; // throws
            }
            if (string.IsNullOrWhiteSpace(txtDBObjects.Text))
                throw new Exception("Missing DB objects");
            if (string.IsNullOrWhiteSpace(cboScriptFolderPath.Text))
                throw new Exception("Missing folder path");
            if (!Directory.Exists(cboScriptFolderPath.Text))
                throw new Exception("Folder does not exist");

        }

        private FormData GetInputFieldValuesAsObject()
        {
            var data = new FormData()
            {
                DBConnStr = this.DBConnectionString,
                DirectoryName = cboScriptFolderPath.Text,
                SQLObjects = txtDBObjects.Text,
                DBSelected = cboDatabases.Text,
                DBServerSelected = cboDBServers.Text
            };

            try
            {
                data.Databases.Clear();
                foreach (string item in cboDatabases.Items)
                {
                    data.Databases.Add(item);
                }
            }
            catch { }

            try
            {
                data.DBServers.Clear();
                foreach (string item in cboDBServers.Items)
                {
                    data.DBServers.Add(item);
                }
            }
            catch { }

            try
            {
                data.DirectoriesRecent.Clear();
                foreach (string item in cboScriptFolderPath.Items)
                {
                    data.DirectoriesRecent.Add(item);
                }
            }
            catch { }

            return data;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                var data = GetInputFieldValuesAsObject();

                File.WriteAllText("formData.json", JsonConvert.SerializeObject(data, Formatting.Indented));
            }
            catch { }
        }

        private FormData GetFormDataFromFile()
        {
            try
            {
                var data = File.ReadAllText("formData.json");
                return JsonConvert.DeserializeObject<FormData>(data);
            }
            catch
            {
                return null;
            }
        }

        private void TryLoadingForm(FormData objFormData)
        {
            try
            {
                if (objFormData == null)
                    return;

                this.DBConnectionString = objFormData.DBConnStr;
                cboScriptFolderPath.Text = objFormData.DirectoryName;
                txtDBObjects.Text = objFormData.SQLObjects;
                stageSectionSplitContainer.Panel2Collapsed = true;


                if (objFormData.Databases != null)
                {
                    cboDatabases.Items.Clear();
                    foreach (var db in objFormData.Databases)
                    {
                        if (!string.IsNullOrWhiteSpace(db))
                        {
                            if (!cboDatabases.Items.Contains(db))
                                cboDatabases.Items.Add(db);

                            if (db == objFormData.DBSelected)
                            {
                                cboDatabases.SelectedItem = db;
                            }
                        }
                    }
                }

                if (objFormData.DBServers != null)
                {
                    cboDBServers.Items.Clear();
                    foreach (var dbServer in objFormData.DBServers)
                    {
                        if (!string.IsNullOrWhiteSpace(dbServer))
                        {
                            if (!cboDBServers.Items.Contains(dbServer))
                                cboDBServers.Items.Add(dbServer);

                            if (dbServer == objFormData.DBServerSelected)
                            {
                                cboDBServers.SelectedItem = dbServer;
                            }
                        }
                    }
                }

                if (objFormData.DirectoriesRecent != null)
                {
                    cboScriptFolderPath.Items.Clear();
                    var folderPathCount = 0;
                    foreach (var directoryPath in objFormData.DirectoriesRecent)
                    {
                        if (!string.IsNullOrWhiteSpace(directoryPath))
                        {
                            if (folderPathCount++ > 10)
                                break;

                            if (!cboScriptFolderPath.Items.Contains(directoryPath))
                                cboScriptFolderPath.Items.Add(directoryPath);

                            if (directoryPath == objFormData.DirectoryName)
                            {
                                cboDBServers.SelectedItem = directoryPath;
                            }
                        }

                    }
                }


            }
            catch { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TryLoadingForm(GetFormDataFromFile());
        }

        private void lstExecutionFailures_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lstExecutionFailures.SelectedIndex > -1
                && lstExecutionFailures.SelectedIndex < lstExecutionFailures.Items.Count)
            {
                try
                {
                    Process.Start(lstExecutionFailures.SelectedItem.ToString());
                }
                catch { }
            }
        }

        private void txtScriptFolderPath_MouseHover(object sender, EventArgs e)
        {
            var pathInClipBoard = Clipboard.GetText();
            if (!string.IsNullOrWhiteSpace(pathInClipBoard))
            {
                if (!pathInClipBoard.Equals(cboScriptFolderPath.Text)
                    && Directory.Exists(pathInClipBoard))
                {
                    cboScriptFolderPath.Text = pathInClipBoard;
                }
            }
        }

        private void cboDatabases_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cboDatabases.Text))
            {
                if (!cboDatabases.Items.Contains(cboDatabases.Text))
                {
                    cboDatabases.Items.Add(cboDatabases.Text);
                }
                this.DBConnectionString = $"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog={cboDatabases.Text};Data Source={cboDBServers.Text}";
            }
        }

        private void cboDBServers_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cboDBServers.Text))
            {
                if (!cboDBServers.Items.Contains(cboDBServers.Text))
                {
                    cboDBServers.Items.Add(cboDBServers.Text);
                }

                this.DBConnectionString = $"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog={cboDatabases.Text};Data Source={cboDBServers.Text}";
            }
        }

        private void lstFileMatches_DoubleClick(object sender, EventArgs e)
        {
            OpenSelectedMatchedFileInExplorer();
        }

        private void lstFailures_Click(object sender, EventArgs e)
        {
            if (lstFailures.SelectedIndex > -1
                && lstFailures.SelectedIndex < lstFailures.Items.Count)
            {
                try
                {
                    txtDBObjects.SelectionStart = txtDBObjects.Text.IndexOf(lstFailures.Text);
                    txtDBObjects.SelectionLength = lstFailures.Text.Length;
                }
                catch { }
            }
        }

        private void btnOpenFolderDialog_Click(object sender, EventArgs e)
        {
            var folderSelection = new FolderBrowserDialog();

            if (!string.IsNullOrWhiteSpace(cboScriptFolderPath.Text)
                && Directory.Exists(cboScriptFolderPath.Text))
            {
                folderSelection.SelectedPath = cboScriptFolderPath.Text;
            }
            var result = folderSelection.ShowDialog();
            if (result == DialogResult.OK)
            {
                cboScriptFolderPath.Text = folderSelection.SelectedPath;
            }
        }

        private void cboScriptFolderPath_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cboScriptFolderPath.Text)
                && Directory.Exists(cboScriptFolderPath.Text.Trim()))
            {
                if (cboScriptFolderPath.FindStringExact(cboScriptFolderPath.Text.Trim()) < 0)
                {
                    cboScriptFolderPath.Items.Add(cboScriptFolderPath.Text.Trim());
                }
            }
        }

        #region DragAndDrop_Reorder_Files
        private string fileToOpen = string.Empty;
        private void lstFileMatches_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                if (this.lstFileMatches.SelectedItem == null)
                    return;
                this.lstFileMatches.DoDragDrop(this.lstFileMatches.SelectedItem, DragDropEffects.Move);
            }
            else
            {
                Point clickedPoint = new Point(e.X, e.Y);
                Point point = lstFileMatches.PointToClient(clickedPoint);
                int index = this.lstFileMatches.IndexFromPoint(clickedPoint);
                if (index > -1 && index < this.lstFileMatches.Items.Count)
                {
                    //index = this.lstFileMatches.Items.Count - 1;
                    fileToOpen = this.lstFileMatches.Items[index].ToString();
                }
                else
                    fileToOpen = string.Empty;

                contextMenuStrip1.Show(lstFileMatches, e.X, e.Y);
            }
        }



        private void lstFileMatches_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void lstFileMatches_DragDrop(object sender, DragEventArgs e)
        {
            Point point = lstFileMatches.PointToClient(new Point(e.X, e.Y));
            int index = this.lstFileMatches.IndexFromPoint(point);
            if (index < 0)
            {
                index = this.lstFileMatches.Items.Count - 1;
            }
            object data = e.Data.GetData(typeof(string));
            this.lstFileMatches.Items.Remove(data);
            this.lstFileMatches.Items.Insert(index, data);
        }

        #endregion DragAndDrop_Reorder_Files

        private void btnStageFiles_Click(object sender, EventArgs e)
        {
            if (lstFileMatches.Items.Count < 1)
                return;

            mainTabControl.SelectTab(1);
            int i = 0;

            foreach (string file in lstFileMatches.Items)
            {
                if (!foundFileList.Exists(p => p.FilePath.Equals(file, StringComparison.InvariantCultureIgnoreCase)))
                {
                    foundFileList.Add(
                        new GridViewDataModel()
                        {
                            FileNo = foundFileList.Count + 1,
                            FilePath = file
                        });
                }
            }

            stagedScriptFilesGridView.DataSource = null;
            stagedScriptFilesGridView.DataSource = foundFileList;
            stagedScriptFilesGridView.Columns["FileFound"].Visible = false;
            stagedScriptFilesGridView.Columns["FileNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            stagedScriptFilesGridView.Columns["FilePath"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //DataGridViewButtonColumn dtc = new DataGridViewButtonColumn();
            //dtc.Name = "Actions";
            //dtc.HeaderText = "Actions";



        }

        private static void PopulateTreeView(TreeView treeView, string[] paths, string pathSeparator, TreeNode initialParentNode)
        {
            TreeNode lastNode = initialParentNode;
            string subPathAgg;
            foreach (string path in paths)
            {
                subPathAgg = string.Empty;
                foreach (string subPath in path.Split(new string[] { pathSeparator }, StringSplitOptions.RemoveEmptyEntries))
                {
                    subPathAgg += pathSeparator + subPath;
                    TreeNode[] nodes = treeView.Nodes.Find(subPathAgg, true);
                    if (nodes.Length == 0)
                        if (lastNode == null)
                            //lastNode = 
                            treeView.Nodes.Add(subPathAgg, subPath);
                        else
                            //lastNode = 
                            lastNode.Nodes.Add(subPathAgg, subPath);
                    //else
                    //    lastNode = nodes[0];
                }
                // lastNode = null; // This is the place code was changed
            }
        }

        private void stagedFilesTreeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void stagedFilesTreeView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        //private void stagedFilesTreeView_DragDrop(object sender, DragEventArgs e)
        //{
        //    TreeNode NewNode;


        //    if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
        //    {
        //        Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
        //        TreeNode DestinationNode = ((TreeView)sender).GetNodeAt(pt);
        //        NewNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");

        //        var indexOfSourceNode = NewNode.Index;
        //        var indexOfTargetNode = DestinationNode.Index;

        //        if (indexOfSourceNode > -1 && indexOfSourceNode < stagedFilesTreeView.Nodes.Count)
        //        {
        //            stagedFilesTreeView.Nodes.RemoveAt(indexOfTargetNode);
        //            stagedFilesTreeView.Nodes.Insert(indexOfTargetNode, NewNode);
        //            stagedFilesTreeView.Nodes.Insert(indexOfTargetNode + 1, DestinationNode);
        //        }


        //        ////if (DestinationNode.TreeView != NewNode.TreeView)
        //        ////{
        //        //if (DestinationNode.Parent != null)
        //        //{
        //        //    DestinationNode.Parent.Nodes.Add((TreeNode)NewNode.Clone());
        //        //}
        //        //else
        //        //{
        //        //    DestinationNode.Nodes.Add((TreeNode)NewNode.Clone());
        //        //}
        //        //DestinationNode.Expand();
        //        ////    //Remove Original Node
        //        ////NewNode.Remove();
        //        ////}


        //    }
        //}


        private bool isRunning = false;

        private void HandleRunCommand()
        {
            if (isRunning)
            {
                if (scriptExecutorBGWorker.WorkerSupportsCancellation)
                {
                    btnRunScripts.Text = "Run";
                    btnRunScripts.Tag = "NotRunning";
                    scriptExecutorBGWorker.CancelAsync();
                    statusBarText.Text = "Cancellation requested";
                }
                else
                {
                    MessageBox.Show("Cannot be stopped..");
                }
            }
            else
            {
                if (stagedScriptFilesGridView.RowCount < 1)
                    return;
                try
                {
                    DbConnectionStringBuilder csb = new DbConnectionStringBuilder();
                    csb.ConnectionString = this.DBConnectionString;
                }
                catch
                {
                    MessageBox.Show("Please provide valid database server and database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                if (MessageBox.Show($"Are you sure to execute the {stagedScriptFilesGridView.RowCount} script(s)? {Environment.NewLine + Environment.NewLine} DB connection string : {this.DBConnectionString}.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                isRunning = true;
                OnlyErrors = string.Empty;
                AllMessages = string.Empty;
                lstExecutionResult.Items.Clear();
                lstExecutionFailures.Items.Clear();
                rtbExecutionSummaryMessage.Text = string.Empty;
                splitContainer1.TabIndex = 2;
                btnRunScripts.Tag = "Running";
                btnRunScripts.Text = "Stop";
                stageSectionSplitContainer.Panel2Collapsed = false;

                var files = new List<string>();
                foreach (var item in foundFileList)
                {
                    files.Add(item.FilePath);
                }

                var scriptsToRun = new StagedScripts(
                    this.DBConnectionString,
                    files);

                mainTabControl.SelectTab(1);
                scriptExecutorBGWorker.RunWorkerAsync(scriptsToRun);
            }
        }

        private void ChkOption1_Click(object sender, EventArgs e)
        {
            this.ShowDeleteConfirmation = !((CheckBox)sender).Checked;
        }

        private void BtnOKYes_Click(object sender, EventArgs e)
        {
            this.deleteDialogResult = true;
            ((Form)((Button)sender).Parent).Close();
        }

        private bool deleteDialogResult = false;
        private bool ShowDeleteConfirmation = true;
        private void BtnNoCancel_Click(object sender, EventArgs e)
        {
            deleteDialogResult = false;
            ((Form)((Button)sender).Parent).Close();
        }

        private void btnRunScripts_Click_1(object sender, EventArgs e)
        {
            HandleRunCommand();
        }

        private void scriptExecutorBGWorker_DoWork(
            object sender,
            System.ComponentModel.DoWorkEventArgs e)
        {
            var scriptsFilesInfo = e.Argument as StagedScripts;
            var scripeExcuter = new ScripeExcuter(
                this.scriptExecutorBGWorker,
                scriptsFilesInfo.ScriptsFilesToRun,
                scriptsFilesInfo.ConnectionString)
            {
                ThrowIfOneFileFails = !chkRunIfError.Checked
            };

            scripeExcuter.ExecuteScripts(sender, e);
        }

        private string OnlyErrors = string.Empty;
        private string AllMessages = string.Empty;

        private void scriptExecutorBGWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            var progress = e.UserState as ScriptExecutionProgress;
            if (progress != null)
            {
                if (!string.IsNullOrWhiteSpace(progress.FileName)
                    && progress.CurrentFileProgress == 100)
                {
                    if (progress.Success)
                    {
                        lstExecutionResult.Items.Add(progress.FileName);
                    }
                    else
                    {
                        OnlyErrors += progress.Message;
                        lstExecutionFailures.Items.Add(progress.FileName);
                    }
                }

                if (progress.Success)
                {
                    rtbExecutionSummaryMessage.ForeColor = Color.Green;
                }
                else
                {
                    rtbExecutionSummaryMessage.ForeColor = Color.Red;
                }
                rtbExecutionSummaryMessage.AppendText(progress.Message);

                this.Text = string.Format("Result {0}: Percent {1}", "", e.ProgressPercentage);
            }
            else
            {
                rtbExecutionSummaryMessage.ForeColor = Color.Black;
                this.Text = string.Format("Result {0}: Percent {1}", "", e.ProgressPercentage);
            }
            statusBarProgressBar.Value = e.ProgressPercentage;
            statusBarText.Text = "Overall progress " + e.ProgressPercentage.ToString() + "%.." + progress.FileName;
        }

        private void scriptExecutorBGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                this.Text = "DB script runner - Cancelled";
            }
            else if (e.Error != null)
            {
                this.Text = "DB script runner - Compelted with error";
            }
            else
            {
                this.Text = "DB script runner - Compelted successfully";
            }

            isRunning = false;
            btnRunScripts.Tag = "";
            btnRunScripts.Text = "Run";
            statusBarProgressBar.Value = 100;
            statusBarText.Text = "Completed Running.";

            chkShowOnlyErrorMessages.Visible = !string.IsNullOrWhiteSpace(OnlyErrors);
        }


        private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAllAsProject(false);
        }

        private bool SaveAllAsProject(bool promptIfFileExists)
        {
            var data = GetInputFieldValuesAsObject();
            if (this.prj == null)
                this.prj = new Project();

            prj.FormData = data;
            var files = new List<string>();
            foreach (var item in foundFileList)
            {
                prj.FileNames.Add(item.FilePath);
            }

            if (string.IsNullOrWhiteSpace(this.prj.ProjectFileName) || promptIfFileExists)
            {
                if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    prj.ProjectFileName = saveFileDialog1.FileName;
                    prj.Name = saveFileDialog1.FileName;
                }

            }

            if (!string.IsNullOrWhiteSpace(this.prj.ProjectFileName))
            {
                var overwrite = true;
                if (File.Exists(this.prj.ProjectFileName) && promptIfFileExists)
                {
                    if (MessageBox.Show("Are your sure to overwrite the file?", "File already exists", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                        == DialogResult.Yes)
                    {
                        overwrite = true;
                    }
                    else
                    {
                        overwrite = false;
                    }
                }

                if (overwrite)
                {
                    File.WriteAllText(prj.ProjectFileName, JsonConvert.SerializeObject(prj));
                    MessageBox.Show($"File {prj.ProjectFileName} saved.");
                    return true;
                }
                else
                {
                    MessageBox.Show("File not saved. Try saving with another file name.");
                }
            }
            else
            {
                MessageBox.Show("File not saved. You cancelled saving.");
            }

            return false;

        }

        private bool LoadProject()
        {
            return true;
        }

        private void btnSaveProject_Click(object sender, EventArgs e)
        {
            SaveAllAsProject(false);
        }

        private void saveAsProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAllAsProject(true);
        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenProject();
            }
            catch (Exception exp)
            {
                MessageBox.Show("Unable to open the file. " + exp.Message);
            }
        }

        private void OpenProject()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrWhiteSpace(openFileDialog1.FileName))
                {
                    var fileContent = File.ReadAllText(openFileDialog1.FileName);
                    var deserializedObj = JsonConvert.DeserializeObject<Project>(fileContent);
                    TryLoadingForm(deserializedObj.FormData);

                    foundFileList.Clear();

                    foreach (var stagedFile in deserializedObj.FileNames)
                    {
                        if (!string.IsNullOrWhiteSpace(stagedFile))
                        {
                            var fileExists = File.Exists(stagedFile);
                            foundFileList.Add(
                                    new GridViewDataModel()
                                    {
                                        FileNo = foundFileList.Count + 1,
                                        FilePath = stagedFile,
                                        FileFound = fileExists
                                    });
                        }
                    }

                    this.prj = deserializedObj;
                    stagedScriptFilesGridView.DataSource = null;
                    stagedScriptFilesGridView.DataSource = foundFileList;

                    stagedScriptFilesGridView.Columns["FileFound"].Visible = false;
                    stagedScriptFilesGridView.Columns["FileNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    stagedScriptFilesGridView.Columns["FilePath"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    mainTabControl.SelectTab(1);

                    var missingFiles = new List<string>();
                    if (missingFiles.Count > 0)
                    {
                        var response = MessageBox.Show($"There are {missingFiles.Count} files missing in your workspace. Do you like to provide the folders/files to this application?", "Provide files/folders", MessageBoxButtons.YesNo);
                        if (response != DialogResult.Yes)
                        {
                            return;
                        }


                        IList<MissingFileTree> treeRoot = new List<MissingFileTree>();
                        foreach (var missingFile in missingFiles)
                        {
                            var dirPathAlone = Path.GetDirectoryName(missingFile);
                            var root = Directory.GetDirectoryRoot(dirPathAlone);
                            var drive = treeRoot.FirstOrDefault(
                                f => f.PathPartName.Equals(root,
                                    StringComparison.InvariantCultureIgnoreCase));

                            if (drive == null)
                            {
                                drive = new MissingFileTree() { PathPartName = root };
                                treeRoot.Add(drive);
                            }

                            var subFolders = dirPathAlone
                                .Replace(root, string.Empty)
                                .Split(new char[] { Path.DirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries);

                            var startNode = drive;
                            foreach (var subFolder in subFolders)
                            {
                                var existingChild = startNode
                                    .ChildPath
                                    .FirstOrDefault(
                                        f => f.PathPartName.Equals(subFolder, StringComparison.InvariantCultureIgnoreCase));

                                if (existingChild == null)
                                {
                                    var tempNode = new MissingFileTree() { PathPartName = subFolder };
                                    startNode.ChildPath.Add(tempNode);
                                    startNode = tempNode;
                                }
                                else
                                {
                                    startNode = existingChild;
                                }
                            }
                        }

                        var candidatePathsToGetInput = new List<string>();

                        foreach (var root in treeRoot)
                        {
                            string tempPath = "";
                            if (root.ChildPath.Count > 1)
                            {
                                if (!candidatePathsToGetInput
                                    .Exists(p => p.Equals(root.PathPartName, StringComparison.InvariantCultureIgnoreCase)))
                                {
                                    candidatePathsToGetInput.Add(root.PathPartName);
                                }
                            }

                            var tempPathNode = root;
                            tempPath = root.PathPartName;

                            foreach (var child in tempPathNode.ChildPath)
                            {
                                if (child.ChildPath.Count > 1)
                                {

                                }
                            }
                        }

                    }


                }
            }

        }

        private void closeExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void runToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HandleRunCommand();
        }

        private void resultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainTabControl.SelectTab(2);
        }


        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(fileToOpen))
            {
                if (e.ClickedItem.Tag == "OpenSelectedFileMatchInEditor")
                {
                    OpenFileInEditor(fileToOpen);
                }
                else if (e.ClickedItem.Tag == "OpenInFileExplorer")
                {
                    openFolderInFileExplorer(fileToOpen);
                }
            }
        }

        private void OpenSelectedMatchedFileInExplorer()
        {
            if (lstFileMatches.SelectedIndex > -1
                && lstFileMatches.SelectedIndex < lstFileMatches.Items.Count)
            {
                OpenFileInEditor(lstFileMatches.SelectedItem.ToString());
            }
        }

        private void OpenFileInEditor(string filePath)
        {
            try
            {
                Process.Start(filePath);
                statusBarText.Text = string.Empty;
            }
            catch (Exception excep)
            {
                statusBarText.Text = "Unable to open the file in editor. " + excep.Message;
            }
        }

        private void openFolderInFileExplorer(string filePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(filePath))
                    return;

                System.Diagnostics.Process.Start("Explorer.exe ", "/select, \"" + filePath + "\"");
                statusBarText.Text = string.Empty;
            }
            catch (Exception excep)
            {
                statusBarText.Text = "Unable to open the file in file explorer. " + excep.Message;
            }
        }

        private void toolStripMenuItemOpenInEditor_Click(object sender, EventArgs e)
        {

        }

        private void lstExecutionResult_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point clickedPoint = new Point(e.X, e.Y);
                Point point = lstExecutionResult.PointToClient(clickedPoint);
                int index = this.lstExecutionResult.IndexFromPoint(clickedPoint);
                if (index > -1 && index < this.lstExecutionResult.Items.Count)
                {
                    //index = this.lstFileMatches.Items.Count - 1;
                    fileToOpen = this.lstExecutionResult.Items[index].ToString();
                }
                else
                    fileToOpen = string.Empty;
            }
            else if (e.Button == MouseButtons.Right)
            {
                Point clickedPoint = new Point(e.X, e.Y);
                Point point = lstExecutionResult.PointToClient(clickedPoint);
                int index = this.lstExecutionResult.IndexFromPoint(clickedPoint);
                if (index > -1 && index < this.lstExecutionResult.Items.Count)
                {
                    //index = this.lstFileMatches.Items.Count - 1;
                    fileToOpen = this.lstExecutionResult.Items[index].ToString();
                }
                else
                    fileToOpen = string.Empty;

                contextMenuStrip1.Show(lstExecutionResult, e.X, e.Y);
            }
        }

        private void lstExecutionFailures_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point clickedPoint = new Point(e.X, e.Y);
                Point point = lstExecutionFailures.PointToClient(clickedPoint);
                int index = this.lstExecutionFailures.IndexFromPoint(clickedPoint);
                if (index > -1 && index < this.lstExecutionFailures.Items.Count)
                {
                    //index = this.lstFileMatches.Items.Count - 1;
                    fileToOpen = this.lstExecutionFailures.Items[index].ToString();
                }
                else
                    fileToOpen = string.Empty;
            }
            else if (e.Button == MouseButtons.Right)
            {
                Point clickedPoint = new Point(e.X, e.Y);
                Point point = lstExecutionFailures.PointToClient(clickedPoint);
                int index = this.lstExecutionFailures.IndexFromPoint(clickedPoint);
                if (index > -1 && index < this.lstExecutionFailures.Items.Count)
                {
                    //index = this.lstFileMatches.Items.Count - 1;
                    fileToOpen = this.lstExecutionFailures.Items[index].ToString();
                }
                else
                    fileToOpen = string.Empty;

                contextMenuStrip1.Show(lstExecutionFailures, e.X, e.Y);
            }
        }

        private void executionResultSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainTabControl.SelectTab(1);
            splitContainer2.Panel2Collapsed = !splitContainer2.Panel2Collapsed;
        }

        private void chkShowOnlyErrorMessages_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowOnlyErrorMessages.Checked)
            {
                AllMessages = rtbExecutionSummaryMessage.Text;
                rtbExecutionSummaryMessage.Text = OnlyErrors;
            }
            else
            {
                rtbExecutionSummaryMessage.Text = AllMessages;
            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.stagedScriptFilesGridView.SelectedRows == null
                        || this.stagedScriptFilesGridView.SelectedRows.Count < 1)
                    return;

                Point point = stagedScriptFilesGridView.PointToClient(new Point(e.X, e.Y));
                // target row
                DataGridView.HitTestInfo info = stagedScriptFilesGridView.HitTest(point.X, point.Y);
                var alreadyHandled = false;

                var currrow = stagedScriptFilesGridView.CurrentRow;

                if (info != null
                && info.RowIndex > -1
                && info.RowIndex < stagedScriptFilesGridView.RowCount
                && info.ColumnIndex > -1)
                {
                    if (info.ColumnIndex == 3)
                    {
                        alreadyHandled = true;
                        MessageBox.Show("hello");
                    }
                }

                if (!alreadyHandled)
                {
                    this.stagedScriptFilesGridView.DoDragDrop(this.stagedScriptFilesGridView.SelectedRows[0], DragDropEffects.Move);
                }
            }
            else
            {
                //Point point = dataGridView1.PointToClient(new Point(e.X, e.Y));
                //// target row
                //DataGridView.HitTestInfo info = dataGridView1.HitTest(point.X, point.Y);
                ////var fileSet = false;

                //if (info != null
                //&& info.RowIndex > -1
                //&& info.RowIndex < dataGridView1.RowCount
                //&& info.ColumnIndex > -1)
                //{
                //    var targetFilePath = dataGridView1.Rows[info.RowIndex].Cells[info.ColumnIndex];
                //    if (targetFilePath != null)
                //    {
                //        fileSet = true;
                //        fileToOpen = (targetFilePath.Value ?? "").ToString();
                //    }
                //}

                //if (!fileSet)
                //{

                if (this.stagedScriptFilesGridView.SelectedRows == null
                || this.stagedScriptFilesGridView.SelectedRows.Count < 1)
                {
                    fileToOpen = string.Empty;
                }
                else
                {
                    fileToOpen = foundFileList[stagedScriptFilesGridView.SelectedRows[0].Index].FilePath;
                }
                //}
            }
        }

        private void dataGridView1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            Point point = stagedScriptFilesGridView.PointToClient(new Point(e.X, e.Y));

            // target row
            DataGridView.HitTestInfo info = stagedScriptFilesGridView.HitTest(point.X, point.Y);

            if (e.Data.GetDataPresent(typeof(DataGridViewRow))
                && info != null
                && info.RowIndex > -1
                && info.ColumnIndex > -1)
            {
                var sourceRow = (DataGridViewRow)(e.Data.GetData(typeof(DataGridViewRow)));
                var targetFilePath = stagedScriptFilesGridView.Rows[info.RowIndex].Cells[info.ColumnIndex].Value;

                var sourceFile = foundFileList[sourceRow.Index];
                var targetFile = foundFileList[info.RowIndex];
                foundFileList.Insert(info.RowIndex, sourceFile);

                if (sourceRow.Index < info.RowIndex)
                    foundFileList.RemoveAt(sourceRow.Index);
                else
                    foundFileList.RemoveAt(sourceRow.Index + 1);

                for (int i = 0; i < foundFileList.Count; i++)
                {
                    foundFileList[i].FileNo = i + 1;
                }

                //dataGridView1.Rows.Clear();
                //dataGridView1.DataSource = foundFileList;
                var prevRowCellColor = stagedScriptFilesGridView.Rows[info.RowIndex].Cells[info.ColumnIndex].Style.BackColor;
                stagedScriptFilesGridView.Rows[info.RowIndex].Cells[info.ColumnIndex].Style.BackColor = Color.Green;
                Task.Delay(500).ConfigureAwait(false).GetAwaiter().GetResult();
                stagedScriptFilesGridView.Rows[info.RowIndex].Cells[info.ColumnIndex].Style.BackColor = prevRowCellColor;

                //var targetRowPrevColor = dataGridView1.Rows[info.RowIndex].Cells[info.ColumnIndex].Style.BackColor;
                //var sourcePrevColor = sourceRow.Cells[info.ColumnIndex].Style.BackColor;
                //dataGridView1.Rows[info.RowIndex].Cells[info.ColumnIndex].Style.BackColor = Color.Green;
                //sourceRow.Cells[info.ColumnIndex].Style.BackColor = Color.OrangeRed;

                //Task.Delay(500).ConfigureAwait(false).GetAwaiter().GetResult();

                //dataGridView1.Rows[info.RowIndex].Cells[info.ColumnIndex].Value = sourceRow.Cells[info.ColumnIndex].Value;
                //sourceRow.Cells[info.ColumnIndex].Value = targetFilePath;

                //dataGridView1.Rows[info.RowIndex].Cells[info.ColumnIndex].Style.BackColor = Color.OrangeRed;
                //sourceRow.Cells[info.ColumnIndex].Style.BackColor = Color.Green;
                //Task.Delay(1000).ConfigureAwait(false).GetAwaiter().GetResult();
                //dataGridView1.Rows[info.RowIndex].Cells[info.ColumnIndex].Style.BackColor = targetRowPrevColor;
                //sourceRow.Cells[info.ColumnIndex].Style.BackColor = sourcePrevColor;

            }
        }

        private void mainTabControl_TabIndexChanged(object sender, EventArgs e)
        {
            stageToolStripMenuItem.Visible = mainTabControl.SelectedTab.Text == "Stage";
        }

        private void mainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            stageToolStripMenuItem.Visible = mainTabControl.SelectedTab.Text == "Stage";
        }

        private void moveDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoveDownFoundFiles();
        }

        private void moveUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoveUpFoundFiles();
        }

        private void deleteFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveFoundFiles();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}
