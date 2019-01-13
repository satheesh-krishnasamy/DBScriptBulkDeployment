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
using System.Windows.Forms;

namespace DBScriptRunner
{
    public partial class DBScriptRunner : Form
    {
        private Project prj = null;

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
                if (files != null && ((multipleFiles && files.Count() > 0) || files.Count() == 1))
                {
                    foreach (var foundFile in files)
                    {
                        lstFileMatches.Items.Add(foundFile);
                    }
                }
                else
                {
                    lstFailures.Items.Add(sqlObjName);
                }
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

        private void ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(lblConnectionString.Text))
                throw new Exception("Missing DB name");
            else
            {
                DbConnectionStringBuilder csb = new DbConnectionStringBuilder();
                csb.ConnectionString = lblConnectionString.Text; // throws
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
                DBConnStr = lblConnectionString.Text,
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

                lblConnectionString.Text = objFormData.DBConnStr;
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
                lblConnectionString.Text = $"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog={cboDatabases.Text};Data Source={cboDBServers.Text}";
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

                lblConnectionString.Text = $"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog={cboDatabases.Text};Data Source={cboDBServers.Text}";
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
            string[] allFilesArray = new string[lstFileMatches.Items.Count];
            int i = 0;
            foreach (string file in lstFileMatches.Items)
            {
                allFilesArray[i++] = file;
                if (!lstStagedFiles.Items.Contains(file))
                {
                    lstStagedFiles.Items.Add(file);
                }
            }

            btnRemoveStagedFile.Enabled = lstStagedFiles.Items.Count > 0;

            //PopulateTreeView(stagedFilesTreeView, new string[] { cboScriptFolderPath.Text + "\\" }, "", null);

            //PopulateTreeView(stagedFilesTreeView, allFilesArray, cboScriptFolderPath.Text + "\\", stagedFilesTreeView.Nodes[0]);
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
                foreach (string item in lstStagedFiles.Items)
                {
                    files.Add(item);
                }

                var scriptsToRun = new StagedScripts(
                    lblConnectionString.Text,
                    files);

                mainTabControl.SelectTab(1);
                scriptExecutorBGWorker.RunWorkerAsync(scriptsToRun);
            }
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

        private void lstStagedFiles_DragDrop(object sender, DragEventArgs e)
        {
            Point point = lstStagedFiles.PointToClient(new Point(e.X, e.Y));
            int index = this.lstStagedFiles.IndexFromPoint(point);
            if (index < 0)
            {
                index = this.lstStagedFiles.Items.Count - 1;
            }
            object data = e.Data.GetData(typeof(string));
            this.lstStagedFiles.Items.Remove(data);
            this.lstStagedFiles.Items.Insert(index, data);
        }

        private void lstStagedFiles_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void lstStagedFiles_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.lstStagedFiles.SelectedItem == null)
                    return;
                this.lstStagedFiles.DoDragDrop(this.lstStagedFiles.SelectedItem, DragDropEffects.Move);
            }
            else
            {
                Point clickedPoint = new Point(e.X, e.Y);
                Point point = lstStagedFiles.PointToClient(clickedPoint);
                int index = this.lstStagedFiles.IndexFromPoint(clickedPoint);
                if (index > -1 && index < this.lstStagedFiles.Items.Count)
                {
                    //index = this.lstFileMatches.Items.Count - 1;
                    fileToOpen = this.lstStagedFiles.Items[index].ToString();
                }
                else
                    fileToOpen = string.Empty;

                contextMenuStrip1.Show(lstStagedFiles, e.X, e.Y);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //if (lstStagedFiles.SelectedIndices != null)
            //{
            //    foreach (int index in lstStagedFiles.SelectedIndices)
            //    {
            //        var targetIndex = index - 1;

            //        if (targetIndex < 0)
            //            targetIndex = 0;

            //        if (index > -1)
            //        {
            //            var itemToMoveUp = this.lstStagedFiles.Items[index].ToString();
            //            var itemInTarget = this.lstStagedFiles.Items[targetIndex].ToString();
            //            this.lstStagedFiles.Items.Remove(targetIndex);
            //            this.lstStagedFiles.Items.Remove(index);

            //            this.lstStagedFiles.Items.Insert(targetIndex, itemToMoveUp);
            //            this.lstStagedFiles.Items.Insert(index + 1, itemInTarget);
            //        }
            //    }
            //}
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
            foreach (string item in lstStagedFiles.Items)
            {
                prj.FileNames.Add(item);
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

                    lstStagedFiles.Items.Clear();

                    foreach (var stagedFile in deserializedObj.FileNames)
                    {
                        lstStagedFiles.Items.Add(stagedFile);
                    }

                    this.prj = deserializedObj;
                    mainTabControl.SelectTab(1);
                }
            }

        }

        private void closeExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRemoveStagedFile_Click(object sender, EventArgs e)
        {
            HandleDeleteSelectedStagedFile();
        }

        private void lstStagedFiles_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                HandleDeleteSelectedStagedFile();
            }
        }

        private void HandleDeleteSelectedStagedFile()
        {
            if (lstStagedFiles.SelectedItem != null
                && lstStagedFiles.SelectedIndex > -1
                && lstStagedFiles.SelectedIndex < lstStagedFiles.Items.Count)
            {
                lstStagedFiles.Items.Remove(lstStagedFiles.SelectedItem);
            }
            btnRemoveStagedFile.Enabled = lstStagedFiles.Items.Count > 0;
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
    }
}
