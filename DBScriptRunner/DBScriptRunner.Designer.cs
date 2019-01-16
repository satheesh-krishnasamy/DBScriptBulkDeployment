namespace DBScriptRunner
{
    partial class DBScriptRunner
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnFindFiles = new System.Windows.Forms.Button();
            this.txtDBObjects = new System.Windows.Forms.TextBox();
            this.lblFolderName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOpenFolderDialog = new System.Windows.Forms.Button();
            this.tabResults = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstExecutionResult = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemOpenInEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOpenInFileExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.lstExecutionFailures = new System.Windows.Forms.ListBox();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.tabSearch = new System.Windows.Forms.TabPage();
            this.scAllContentHolder = new System.Windows.Forms.SplitContainer();
            this.cboScriptFolderPath = new System.Windows.Forms.ComboBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sqlFilePatternGroupBox = new System.Windows.Forms.GroupBox();
            this.btnStageFiles = new System.Windows.Forms.Button();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.foundFilesGroupBox = new System.Windows.Forms.GroupBox();
            this.lstFileMatches = new System.Windows.Forms.ListBox();
            this.notFoundFilesGroupBox = new System.Windows.Forms.GroupBox();
            this.lstFailures = new System.Windows.Forms.ListBox();
            this.tabStage = new System.Windows.Forms.TabPage();
            this.stageSectionSplitContainer = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.chkShowOnlyErrorMessages = new System.Windows.Forms.CheckBox();
            this.btnRunScripts = new System.Windows.Forms.Button();
            this.chkRunIfError = new System.Windows.Forms.CheckBox();
            this.stagedScriptFilesGridView = new System.Windows.Forms.DataGridView();
            this.rtbExecutionSummaryMessage = new System.Windows.Forms.RichTextBox();
            this.scriptExecutorBGWorker = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.resultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executionResultSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusBarText = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusBarProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.cboDBServers = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboDatabases = new System.Windows.Forms.ComboBox();
            this.chkPromptOnDelete = new System.Windows.Forms.CheckBox();
            this.tabResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.tabSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scAllContentHolder)).BeginInit();
            this.scAllContentHolder.Panel1.SuspendLayout();
            this.scAllContentHolder.Panel2.SuspendLayout();
            this.scAllContentHolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.sqlFilePatternGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.foundFilesGroupBox.SuspendLayout();
            this.notFoundFilesGroupBox.SuspendLayout();
            this.tabStage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stageSectionSplitContainer)).BeginInit();
            this.stageSectionSplitContainer.Panel1.SuspendLayout();
            this.stageSectionSplitContainer.Panel2.SuspendLayout();
            this.stageSectionSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stagedScriptFilesGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFindFiles
            // 
            this.btnFindFiles.Location = new System.Drawing.Point(4, 11);
            this.btnFindFiles.Margin = new System.Windows.Forms.Padding(2);
            this.btnFindFiles.Name = "btnFindFiles";
            this.btnFindFiles.Size = new System.Drawing.Size(56, 19);
            this.btnFindFiles.TabIndex = 0;
            this.btnFindFiles.Text = "Find files";
            this.btnFindFiles.UseVisualStyleBackColor = true;
            this.btnFindFiles.Click += new System.EventHandler(this.btnFindFiles_Click);
            // 
            // txtDBObjects
            // 
            this.txtDBObjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDBObjects.Location = new System.Drawing.Point(5, 18);
            this.txtDBObjects.Margin = new System.Windows.Forms.Padding(2);
            this.txtDBObjects.Multiline = true;
            this.txtDBObjects.Name = "txtDBObjects";
            this.txtDBObjects.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDBObjects.Size = new System.Drawing.Size(247, 265);
            this.txtDBObjects.TabIndex = 3;
            // 
            // lblFolderName
            // 
            this.lblFolderName.AutoSize = true;
            this.lblFolderName.Location = new System.Drawing.Point(2, 9);
            this.lblFolderName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFolderName.Name = "lblFolderName";
            this.lblFolderName.Size = new System.Drawing.Size(69, 13);
            this.lblFolderName.TabIndex = 4;
            this.lblFolderName.Text = "Script Folder:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 833);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Ran successfully";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 739);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Execution failure";
            // 
            // btnOpenFolderDialog
            // 
            this.btnOpenFolderDialog.Location = new System.Drawing.Point(560, 10);
            this.btnOpenFolderDialog.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpenFolderDialog.Name = "btnOpenFolderDialog";
            this.btnOpenFolderDialog.Size = new System.Drawing.Size(20, 19);
            this.btnOpenFolderDialog.TabIndex = 16;
            this.btnOpenFolderDialog.Text = "...";
            this.btnOpenFolderDialog.UseVisualStyleBackColor = true;
            this.btnOpenFolderDialog.Click += new System.EventHandler(this.btnOpenFolderDialog_Click);
            // 
            // tabResults
            // 
            this.tabResults.Controls.Add(this.splitContainer1);
            this.tabResults.Location = new System.Drawing.Point(4, 22);
            this.tabResults.Margin = new System.Windows.Forms.Padding(2);
            this.tabResults.Name = "tabResults";
            this.tabResults.Padding = new System.Windows.Forms.Padding(2);
            this.tabResults.Size = new System.Drawing.Size(1018, 383);
            this.tabResults.TabIndex = 0;
            this.tabResults.Text = "Execution result";
            this.tabResults.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(2, 2);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstExecutionResult);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lstExecutionFailures);
            this.splitContainer1.Size = new System.Drawing.Size(1014, 379);
            this.splitContainer1.SplitterDistance = 179;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // lstExecutionResult
            // 
            this.lstExecutionResult.BackColor = System.Drawing.Color.PaleGreen;
            this.lstExecutionResult.ContextMenuStrip = this.contextMenuStrip1;
            this.lstExecutionResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstExecutionResult.FormattingEnabled = true;
            this.lstExecutionResult.Location = new System.Drawing.Point(0, 0);
            this.lstExecutionResult.Margin = new System.Windows.Forms.Padding(2);
            this.lstExecutionResult.Name = "lstExecutionResult";
            this.lstExecutionResult.Size = new System.Drawing.Size(1014, 179);
            this.lstExecutionResult.TabIndex = 14;
            this.lstExecutionResult.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstExecutionResult_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpenInEditor,
            this.toolStripMenuItemOpenInFileExplorer});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(183, 48);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // toolStripMenuItemOpenInEditor
            // 
            this.toolStripMenuItemOpenInEditor.Name = "toolStripMenuItemOpenInEditor";
            this.toolStripMenuItemOpenInEditor.Size = new System.Drawing.Size(182, 22);
            this.toolStripMenuItemOpenInEditor.Tag = "OpenSelectedFileMatchInEditor";
            this.toolStripMenuItemOpenInEditor.Text = "Open in editor";
            // 
            // toolStripMenuItemOpenInFileExplorer
            // 
            this.toolStripMenuItemOpenInFileExplorer.Name = "toolStripMenuItemOpenInFileExplorer";
            this.toolStripMenuItemOpenInFileExplorer.Size = new System.Drawing.Size(182, 22);
            this.toolStripMenuItemOpenInFileExplorer.Tag = "OpenInFileExplorer";
            this.toolStripMenuItemOpenInFileExplorer.Text = "Open In File Explorer";
            // 
            // lstExecutionFailures
            // 
            this.lstExecutionFailures.BackColor = System.Drawing.Color.LightSalmon;
            this.lstExecutionFailures.ContextMenuStrip = this.contextMenuStrip1;
            this.lstExecutionFailures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstExecutionFailures.FormattingEnabled = true;
            this.lstExecutionFailures.Location = new System.Drawing.Point(0, 0);
            this.lstExecutionFailures.Margin = new System.Windows.Forms.Padding(2);
            this.lstExecutionFailures.Name = "lstExecutionFailures";
            this.lstExecutionFailures.Size = new System.Drawing.Size(1014, 197);
            this.lstExecutionFailures.TabIndex = 14;
            this.lstExecutionFailures.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstExecutionFailures_MouseDown);
            // 
            // mainTabControl
            // 
            this.mainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTabControl.Controls.Add(this.tabSearch);
            this.mainTabControl.Controls.Add(this.tabStage);
            this.mainTabControl.Controls.Add(this.tabResults);
            this.mainTabControl.Location = new System.Drawing.Point(9, 29);
            this.mainTabControl.Margin = new System.Windows.Forms.Padding(2);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.ShowToolTips = true;
            this.mainTabControl.Size = new System.Drawing.Size(1026, 409);
            this.mainTabControl.TabIndex = 18;
            this.mainTabControl.SelectedIndexChanged += new System.EventHandler(this.mainTabControl_SelectedIndexChanged);
            this.mainTabControl.TabIndexChanged += new System.EventHandler(this.mainTabControl_TabIndexChanged);
            // 
            // tabSearch
            // 
            this.tabSearch.AutoScroll = true;
            this.tabSearch.Controls.Add(this.scAllContentHolder);
            this.tabSearch.Controls.Add(this.label3);
            this.tabSearch.Controls.Add(this.label2);
            this.tabSearch.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabSearch.Location = new System.Drawing.Point(4, 22);
            this.tabSearch.Margin = new System.Windows.Forms.Padding(2);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Padding = new System.Windows.Forms.Padding(2);
            this.tabSearch.Size = new System.Drawing.Size(1018, 383);
            this.tabSearch.TabIndex = 1;
            this.tabSearch.Text = "Search";
            this.tabSearch.UseVisualStyleBackColor = true;
            // 
            // scAllContentHolder
            // 
            this.scAllContentHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scAllContentHolder.Location = new System.Drawing.Point(2, 2);
            this.scAllContentHolder.Margin = new System.Windows.Forms.Padding(2);
            this.scAllContentHolder.Name = "scAllContentHolder";
            this.scAllContentHolder.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scAllContentHolder.Panel1
            // 
            this.scAllContentHolder.Panel1.Controls.Add(this.cboScriptFolderPath);
            this.scAllContentHolder.Panel1.Controls.Add(this.lblFolderName);
            this.scAllContentHolder.Panel1.Controls.Add(this.btnOpenFolderDialog);
            // 
            // scAllContentHolder.Panel2
            // 
            this.scAllContentHolder.Panel2.Controls.Add(this.splitContainer2);
            this.scAllContentHolder.Size = new System.Drawing.Size(1014, 379);
            this.scAllContentHolder.SplitterDistance = 37;
            this.scAllContentHolder.SplitterWidth = 8;
            this.scAllContentHolder.TabIndex = 24;
            // 
            // cboScriptFolderPath
            // 
            this.cboScriptFolderPath.FormattingEnabled = true;
            this.cboScriptFolderPath.Location = new System.Drawing.Point(75, 9);
            this.cboScriptFolderPath.Margin = new System.Windows.Forms.Padding(2);
            this.cboScriptFolderPath.Name = "cboScriptFolderPath";
            this.cboScriptFolderPath.Size = new System.Drawing.Size(481, 21);
            this.cboScriptFolderPath.TabIndex = 23;
            this.cboScriptFolderPath.Leave += new System.EventHandler(this.cboScriptFolderPath_Leave);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1014, 334);
            this.splitContainer2.SplitterDistance = 265;
            this.splitContainer2.SplitterWidth = 8;
            this.splitContainer2.TabIndex = 23;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.sqlFilePatternGroupBox);
            this.panel1.Controls.Add(this.btnStageFiles);
            this.panel1.Controls.Add(this.btnFindFiles);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 334);
            this.panel1.TabIndex = 0;
            // 
            // sqlFilePatternGroupBox
            // 
            this.sqlFilePatternGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sqlFilePatternGroupBox.Controls.Add(this.txtDBObjects);
            this.sqlFilePatternGroupBox.Location = new System.Drawing.Point(5, 36);
            this.sqlFilePatternGroupBox.Name = "sqlFilePatternGroupBox";
            this.sqlFilePatternGroupBox.Size = new System.Drawing.Size(257, 288);
            this.sqlFilePatternGroupBox.TabIndex = 9;
            this.sqlFilePatternGroupBox.TabStop = false;
            this.sqlFilePatternGroupBox.Text = "SQL file pattern to search";
            // 
            // btnStageFiles
            // 
            this.btnStageFiles.Location = new System.Drawing.Point(65, 11);
            this.btnStageFiles.Name = "btnStageFiles";
            this.btnStageFiles.Size = new System.Drawing.Size(56, 19);
            this.btnStageFiles.TabIndex = 8;
            this.btnStageFiles.Text = "Stage..";
            this.btnStageFiles.UseVisualStyleBackColor = true;
            this.btnStageFiles.Click += new System.EventHandler(this.btnStageFiles_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.foundFilesGroupBox);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.notFoundFilesGroupBox);
            this.splitContainer3.Size = new System.Drawing.Size(741, 334);
            this.splitContainer3.SplitterDistance = 208;
            this.splitContainer3.SplitterWidth = 5;
            this.splitContainer3.TabIndex = 0;
            // 
            // foundFilesGroupBox
            // 
            this.foundFilesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.foundFilesGroupBox.Controls.Add(this.lstFileMatches);
            this.foundFilesGroupBox.Location = new System.Drawing.Point(3, 3);
            this.foundFilesGroupBox.Name = "foundFilesGroupBox";
            this.foundFilesGroupBox.Size = new System.Drawing.Size(725, 202);
            this.foundFilesGroupBox.TabIndex = 8;
            this.foundFilesGroupBox.TabStop = false;
            this.foundFilesGroupBox.Text = "Files found";
            // 
            // lstFileMatches
            // 
            this.lstFileMatches.AllowDrop = true;
            this.lstFileMatches.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFileMatches.ContextMenuStrip = this.contextMenuStrip1;
            this.lstFileMatches.FormattingEnabled = true;
            this.lstFileMatches.HorizontalScrollbar = true;
            this.lstFileMatches.Location = new System.Drawing.Point(5, 14);
            this.lstFileMatches.Margin = new System.Windows.Forms.Padding(2);
            this.lstFileMatches.Name = "lstFileMatches";
            this.lstFileMatches.Size = new System.Drawing.Size(715, 160);
            this.lstFileMatches.TabIndex = 7;
            this.lstFileMatches.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstFileMatches_DragDrop);
            this.lstFileMatches.DragOver += new System.Windows.Forms.DragEventHandler(this.lstFileMatches_DragOver);
            this.lstFileMatches.DoubleClick += new System.EventHandler(this.lstFileMatches_DoubleClick);
            this.lstFileMatches.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstFileMatches_MouseDown);
            // 
            // notFoundFilesGroupBox
            // 
            this.notFoundFilesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.notFoundFilesGroupBox.Controls.Add(this.lstFailures);
            this.notFoundFilesGroupBox.Location = new System.Drawing.Point(8, 14);
            this.notFoundFilesGroupBox.Name = "notFoundFilesGroupBox";
            this.notFoundFilesGroupBox.Size = new System.Drawing.Size(720, 96);
            this.notFoundFilesGroupBox.TabIndex = 9;
            this.notFoundFilesGroupBox.TabStop = false;
            this.notFoundFilesGroupBox.Text = "Files not found";
            // 
            // lstFailures
            // 
            this.lstFailures.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFailures.FormattingEnabled = true;
            this.lstFailures.HorizontalScrollbar = true;
            this.lstFailures.Location = new System.Drawing.Point(5, 18);
            this.lstFailures.Margin = new System.Windows.Forms.Padding(2);
            this.lstFailures.Name = "lstFailures";
            this.lstFailures.Size = new System.Drawing.Size(710, 82);
            this.lstFailures.TabIndex = 8;
            this.lstFailures.Click += new System.EventHandler(this.lstFailures_Click);
            // 
            // tabStage
            // 
            this.tabStage.Controls.Add(this.stageSectionSplitContainer);
            this.tabStage.Location = new System.Drawing.Point(4, 22);
            this.tabStage.Name = "tabStage";
            this.tabStage.Padding = new System.Windows.Forms.Padding(3);
            this.tabStage.Size = new System.Drawing.Size(1018, 383);
            this.tabStage.TabIndex = 2;
            this.tabStage.Text = "Stage";
            this.tabStage.UseVisualStyleBackColor = true;
            // 
            // stageSectionSplitContainer
            // 
            this.stageSectionSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stageSectionSplitContainer.Location = new System.Drawing.Point(3, 3);
            this.stageSectionSplitContainer.Name = "stageSectionSplitContainer";
            this.stageSectionSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // stageSectionSplitContainer.Panel1
            // 
            this.stageSectionSplitContainer.Panel1.Controls.Add(this.splitContainer4);
            // 
            // stageSectionSplitContainer.Panel2
            // 
            this.stageSectionSplitContainer.Panel2.Controls.Add(this.rtbExecutionSummaryMessage);
            this.stageSectionSplitContainer.Size = new System.Drawing.Size(1012, 377);
            this.stageSectionSplitContainer.SplitterDistance = 223;
            this.stageSectionSplitContainer.TabIndex = 17;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.chkPromptOnDelete);
            this.splitContainer4.Panel1.Controls.Add(this.cboDatabases);
            this.splitContainer4.Panel1.Controls.Add(this.label6);
            this.splitContainer4.Panel1.Controls.Add(this.cboDBServers);
            this.splitContainer4.Panel1.Controls.Add(this.label5);
            this.splitContainer4.Panel1.Controls.Add(this.chkShowOnlyErrorMessages);
            this.splitContainer4.Panel1.Controls.Add(this.btnRunScripts);
            this.splitContainer4.Panel1.Controls.Add(this.chkRunIfError);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.stagedScriptFilesGridView);
            this.splitContainer4.Size = new System.Drawing.Size(1012, 223);
            this.splitContainer4.SplitterDistance = 163;
            this.splitContainer4.TabIndex = 16;
            // 
            // chkShowOnlyErrorMessages
            // 
            this.chkShowOnlyErrorMessages.AutoSize = true;
            this.chkShowOnlyErrorMessages.Location = new System.Drawing.Point(13, 167);
            this.chkShowOnlyErrorMessages.Name = "chkShowOnlyErrorMessages";
            this.chkShowOnlyErrorMessages.Size = new System.Drawing.Size(104, 17);
            this.chkShowOnlyErrorMessages.TabIndex = 17;
            this.chkShowOnlyErrorMessages.Text = "Show only errors";
            this.chkShowOnlyErrorMessages.UseVisualStyleBackColor = true;
            this.chkShowOnlyErrorMessages.Visible = false;
            this.chkShowOnlyErrorMessages.CheckedChanged += new System.EventHandler(this.chkShowOnlyErrorMessages_CheckedChanged);
            // 
            // btnRunScripts
            // 
            this.btnRunScripts.Enabled = false;
            this.btnRunScripts.Location = new System.Drawing.Point(13, 99);
            this.btnRunScripts.Margin = new System.Windows.Forms.Padding(2);
            this.btnRunScripts.Name = "btnRunScripts";
            this.btnRunScripts.Size = new System.Drawing.Size(75, 19);
            this.btnRunScripts.TabIndex = 14;
            this.btnRunScripts.Text = "Run..";
            this.btnRunScripts.UseVisualStyleBackColor = true;
            this.btnRunScripts.Click += new System.EventHandler(this.btnRunScripts_Click_1);
            // 
            // chkRunIfError
            // 
            this.chkRunIfError.AutoSize = true;
            this.chkRunIfError.Location = new System.Drawing.Point(13, 122);
            this.chkRunIfError.Margin = new System.Windows.Forms.Padding(2);
            this.chkRunIfError.Name = "chkRunIfError";
            this.chkRunIfError.Size = new System.Drawing.Size(151, 17);
            this.chkRunIfError.TabIndex = 15;
            this.chkRunIfError.Text = "Run even if one script fails";
            this.chkRunIfError.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkRunIfError.UseVisualStyleBackColor = true;
            // 
            // stagedScriptFilesGridView
            // 
            this.stagedScriptFilesGridView.AllowDrop = true;
            this.stagedScriptFilesGridView.AllowUserToAddRows = false;
            this.stagedScriptFilesGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stagedScriptFilesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stagedScriptFilesGridView.ContextMenuStrip = this.contextMenuStrip1;
            this.stagedScriptFilesGridView.Location = new System.Drawing.Point(0, 0);
            this.stagedScriptFilesGridView.MultiSelect = false;
            this.stagedScriptFilesGridView.Name = "stagedScriptFilesGridView";
            this.stagedScriptFilesGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.stagedScriptFilesGridView.Size = new System.Drawing.Size(845, 223);
            this.stagedScriptFilesGridView.TabIndex = 2;
            this.stagedScriptFilesGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.stagedScriptFilesGridView.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragDrop);
            this.stagedScriptFilesGridView.DragOver += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragOver);
            this.stagedScriptFilesGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDown);
            this.stagedScriptFilesGridView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseUp);
            // 
            // rtbExecutionSummaryMessage
            // 
            this.rtbExecutionSummaryMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbExecutionSummaryMessage.Location = new System.Drawing.Point(0, 0);
            this.rtbExecutionSummaryMessage.Name = "rtbExecutionSummaryMessage";
            this.rtbExecutionSummaryMessage.Size = new System.Drawing.Size(1012, 150);
            this.rtbExecutionSummaryMessage.TabIndex = 18;
            this.rtbExecutionSummaryMessage.Text = "";
            // 
            // scriptExecutorBGWorker
            // 
            this.scriptExecutorBGWorker.WorkerReportsProgress = true;
            this.scriptExecutorBGWorker.WorkerSupportsCancellation = true;
            this.scriptExecutorBGWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.scriptExecutorBGWorker_DoWork);
            this.scriptExecutorBGWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.scriptExecutorBGWorker_ProgressChanged);
            this.scriptExecutorBGWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.scriptExecutorBGWorker_RunWorkerCompleted);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.runToolStripMenuItem,
            this.stageToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1028, 24);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openProjectToolStripMenuItem,
            this.saveProjectToolStripMenuItem,
            this.saveAsProjectToolStripMenuItem,
            this.closeExitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openProjectToolStripMenuItem
            // 
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            this.openProjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.openProjectToolStripMenuItem.Text = "&Open project..";
            this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.openProjectToolStripMenuItem_Click);
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            this.saveProjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.saveProjectToolStripMenuItem.Text = "&Save project..";
            this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.saveProjectToolStripMenuItem_Click);
            // 
            // saveAsProjectToolStripMenuItem
            // 
            this.saveAsProjectToolStripMenuItem.Name = "saveAsProjectToolStripMenuItem";
            this.saveAsProjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsProjectToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.saveAsProjectToolStripMenuItem.Text = "Save project &as..";
            this.saveAsProjectToolStripMenuItem.Click += new System.EventHandler(this.saveAsProjectToolStripMenuItem_Click);
            // 
            // closeExitToolStripMenuItem
            // 
            this.closeExitToolStripMenuItem.Name = "closeExitToolStripMenuItem";
            this.closeExitToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.closeExitToolStripMenuItem.Text = "Close/E&xit";
            this.closeExitToolStripMenuItem.Click += new System.EventHandler(this.closeExitToolStripMenuItem_Click);
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem1,
            this.resultToolStripMenuItem,
            this.executionResultSummaryToolStripMenuItem});
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.runToolStripMenuItem.Text = "SQL &deployment";
            // 
            // runToolStripMenuItem1
            // 
            this.runToolStripMenuItem1.Name = "runToolStripMenuItem1";
            this.runToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.runToolStripMenuItem1.Size = new System.Drawing.Size(236, 22);
            this.runToolStripMenuItem1.Text = "&Run";
            this.runToolStripMenuItem1.Click += new System.EventHandler(this.runToolStripMenuItem1_Click);
            // 
            // resultToolStripMenuItem
            // 
            this.resultToolStripMenuItem.Name = "resultToolStripMenuItem";
            this.resultToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.R)));
            this.resultToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.resultToolStripMenuItem.Text = "Execution r&esult";
            this.resultToolStripMenuItem.Click += new System.EventHandler(this.resultToolStripMenuItem_Click);
            // 
            // executionResultSummaryToolStripMenuItem
            // 
            this.executionResultSummaryToolStripMenuItem.Name = "executionResultSummaryToolStripMenuItem";
            this.executionResultSummaryToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.executionResultSummaryToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.executionResultSummaryToolStripMenuItem.Text = "To&ggle result summary";
            this.executionResultSummaryToolStripMenuItem.Click += new System.EventHandler(this.executionResultSummaryToolStripMenuItem_Click);
            // 
            // stageToolStripMenuItem
            // 
            this.stageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveDownToolStripMenuItem,
            this.moveUpToolStripMenuItem,
            this.deleteFileToolStripMenuItem});
            this.stageToolStripMenuItem.Name = "stageToolStripMenuItem";
            this.stageToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.stageToolStripMenuItem.Text = "Stage";
            this.stageToolStripMenuItem.Visible = false;
            // 
            // moveDownToolStripMenuItem
            // 
            this.moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
            this.moveDownToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Down)));
            this.moveDownToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.moveDownToolStripMenuItem.Text = "Move file &down";
            this.moveDownToolStripMenuItem.Click += new System.EventHandler(this.moveDownToolStripMenuItem_Click);
            // 
            // moveUpToolStripMenuItem
            // 
            this.moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
            this.moveUpToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Up)));
            this.moveUpToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.moveUpToolStripMenuItem.Text = "Move file &Up";
            this.moveUpToolStripMenuItem.Click += new System.EventHandler(this.moveUpToolStripMenuItem_Click);
            // 
            // deleteFileToolStripMenuItem
            // 
            this.deleteFileToolStripMenuItem.Name = "deleteFileToolStripMenuItem";
            this.deleteFileToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteFileToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.deleteFileToolStripMenuItem.Text = "Unstage file";
            this.deleteFileToolStripMenuItem.Click += new System.EventHandler(this.deleteFileToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarText,
            this.statusBarProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 425);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1028, 22);
            this.statusStrip1.TabIndex = 20;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusBarText
            // 
            this.statusBarText.Name = "statusBarText";
            this.statusBarText.Size = new System.Drawing.Size(52, 17);
            this.statusBarText.Text = "Progress";
            // 
            // statusBarProgressBar
            // 
            this.statusBarProgressBar.Name = "statusBarProgressBar";
            this.statusBarProgressBar.Size = new System.Drawing.Size(250, 16);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "sdbproj";
            this.saveFileDialog1.Title = "Save project";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "sdbproj";
            this.openFileDialog1.Filter = "Only SQL db projects(*.sdbproj)|*.sdbproj";
            this.openFileDialog1.Title = "Open SQL DB deployment project";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 12);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "DB server:";
            // 
            // cboDBServers
            // 
            this.cboDBServers.FormattingEnabled = true;
            this.cboDBServers.Location = new System.Drawing.Point(13, 27);
            this.cboDBServers.Margin = new System.Windows.Forms.Padding(2);
            this.cboDBServers.Name = "cboDBServers";
            this.cboDBServers.Size = new System.Drawing.Size(119, 21);
            this.cboDBServers.TabIndex = 23;
            this.cboDBServers.Leave += new System.EventHandler(this.cboDBServers_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 50);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "DB:";
            // 
            // cboDatabases
            // 
            this.cboDatabases.FormattingEnabled = true;
            this.cboDatabases.Location = new System.Drawing.Point(13, 74);
            this.cboDatabases.Margin = new System.Windows.Forms.Padding(2);
            this.cboDatabases.Name = "cboDatabases";
            this.cboDatabases.Size = new System.Drawing.Size(119, 21);
            this.cboDatabases.TabIndex = 25;
            this.cboDatabases.Leave += new System.EventHandler(this.cboDatabases_Leave);
            // 
            // chkPromptOnDelete
            // 
            this.chkPromptOnDelete.AutoSize = true;
            this.chkPromptOnDelete.Checked = true;
            this.chkPromptOnDelete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPromptOnDelete.Location = new System.Drawing.Point(13, 144);
            this.chkPromptOnDelete.Name = "chkPromptOnDelete";
            this.chkPromptOnDelete.Size = new System.Drawing.Size(106, 17);
            this.chkPromptOnDelete.TabIndex = 26;
            this.chkPromptOnDelete.Text = "Prompt on delete";
            this.chkPromptOnDelete.UseVisualStyleBackColor = true;
            // 
            // DBScriptRunner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 447);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DBScriptRunner";
            this.Text = "DB Script bulk deployment";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabResults.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.mainTabControl.ResumeLayout(false);
            this.tabSearch.ResumeLayout(false);
            this.tabSearch.PerformLayout();
            this.scAllContentHolder.Panel1.ResumeLayout(false);
            this.scAllContentHolder.Panel1.PerformLayout();
            this.scAllContentHolder.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scAllContentHolder)).EndInit();
            this.scAllContentHolder.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.sqlFilePatternGroupBox.ResumeLayout(false);
            this.sqlFilePatternGroupBox.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.foundFilesGroupBox.ResumeLayout(false);
            this.notFoundFilesGroupBox.ResumeLayout(false);
            this.tabStage.ResumeLayout(false);
            this.stageSectionSplitContainer.Panel1.ResumeLayout(false);
            this.stageSectionSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stageSectionSplitContainer)).EndInit();
            this.stageSectionSplitContainer.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stagedScriptFilesGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFindFiles;
        private System.Windows.Forms.TextBox txtDBObjects;
        private System.Windows.Forms.Label lblFolderName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOpenFolderDialog;
        private System.Windows.Forms.TabPage tabResults;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage tabSearch;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lstExecutionFailures;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer scAllContentHolder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboScriptFolderPath;
        private System.Windows.Forms.TabPage tabStage;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ListBox lstFileMatches;
        private System.Windows.Forms.ListBox lstFailures;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Button btnRunScripts;
        private System.Windows.Forms.CheckBox chkRunIfError;
        private System.Windows.Forms.Button btnStageFiles;
        private System.ComponentModel.BackgroundWorker scriptExecutorBGWorker;
        private System.Windows.Forms.ListBox lstExecutionResult;
        private System.Windows.Forms.SplitContainer stageSectionSplitContainer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusBarText;
        private System.Windows.Forms.ToolStripProgressBar statusBarProgressBar;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsProjectToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem closeExitToolStripMenuItem;
        private System.Windows.Forms.GroupBox foundFilesGroupBox;
        private System.Windows.Forms.GroupBox notFoundFilesGroupBox;
        private System.Windows.Forms.GroupBox sqlFilePatternGroupBox;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem resultToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenInEditor;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenInFileExplorer;
        private System.Windows.Forms.ToolStripMenuItem executionResultSummaryToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkShowOnlyErrorMessages;
        private System.Windows.Forms.RichTextBox rtbExecutionSummaryMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn filePathDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripMenuItem stageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteFileToolStripMenuItem;
        private System.Windows.Forms.DataGridView stagedScriptFilesGridView;
        private System.Windows.Forms.ComboBox cboDatabases;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboDBServers;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkPromptOnDelete;
    }
}

