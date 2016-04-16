namespace YAXBPC
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabpgCreatePatch = new System.Windows.Forms.TabPage();
            this.btnResetForms = new System.Windows.Forms.Button();
            this.btnAddEditJob = new System.Windows.Forms.Button();
            this.btnSwapSnT = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnBrowseOutputDir = new System.Windows.Forms.Button();
            this.txtOutputDir = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBrowseTargetFile = new System.Windows.Forms.Button();
            this.txtTargetFile = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBrowseSourceFile = new System.Windows.Forms.Button();
            this.txtSourceFile = new System.Windows.Forms.TextBox();
            this.tabpgBatchProcessing = new System.Windows.Forms.TabPage();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuBatchJobList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnEdit = new System.Windows.Forms.Button();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.btnBatchLoadDirs = new System.Windows.Forms.Button();
            this.btnBrowseBatchSourceDir = new System.Windows.Forms.Button();
            this.txtBatchSourceDir = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowseBatchTargetDir = new System.Windows.Forms.Button();
            this.txtBatchTargetDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabpgApplyPatch = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.rtbApplyLog = new System.Windows.Forms.RichTextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.btnBrowseApplyOutput = new System.Windows.Forms.Button();
            this.txtApplyOutput = new System.Windows.Forms.TextBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.btnBrowseApplyVcdiffFile = new System.Windows.Forms.Button();
            this.txtApplyVcdiffFile = new System.Windows.Forms.TextBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.btnBrowseApplySource = new System.Windows.Forms.Button();
            this.txtApplySource = new System.Windows.Forms.TextBox();
            this.tabpgSettings = new System.Windows.Forms.TabPage();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.chbAddNewPatchToApplyAllScripts = new System.Windows.Forms.CheckBox();
            this.chbFunnyMode = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnBrowseDefaultOutDir = new System.Windows.Forms.Button();
            this.txtDefaultOutDir = new System.Windows.Forms.TextBox();
            this.rdbThisFol = new System.Windows.Forms.RadioButton();
            this.rdbTargetDir = new System.Windows.Forms.RadioButton();
            this.rdbSourceDir = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.chbOnlyStoreFileNameInVCDIFF = new System.Windows.Forms.CheckBox();
            this.chbDist64bitxdelta3 = new System.Windows.Forms.CheckBox();
            this.chbRun64bitxdelta3 = new System.Windows.Forms.CheckBox();
            this.btnSetxdeltaHighMem = new System.Windows.Forms.Button();
            this.btnApplySetxdeltaDefault = new System.Windows.Forms.Button();
            this.btnSetxdeltaDefault = new System.Windows.Forms.Button();
            this.btnSetxdeltaHighCompression = new System.Windows.Forms.Button();
            this.btnCusXdelHelp = new System.Windows.Forms.Button();
            this.txtCustomXdeltaParamsForApplying = new System.Windows.Forms.TextBox();
            this.chbUseCustomXdeltaParamsForApplying = new System.Windows.Forms.CheckBox();
            this.txtCustomXdeltaParams = new System.Windows.Forms.TextBox();
            this.chbUseCustomXdeltaParams = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chbNewAutoName = new System.Windows.Forms.CheckBox();
            this.txtAddTextWhenSwap = new System.Windows.Forms.TextBox();
            this.chbAddTextWhenSwap = new System.Windows.Forms.CheckBox();
            this.chbDetEpNum = new System.Windows.Forms.CheckBox();
            this.ofdFileBrowser = new System.Windows.Forms.OpenFileDialog();
            this.fbdDirBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.bgwCreatePatch = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.bgwApplyPatch = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabpgCreatePatch.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabpgBatchProcessing.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.contextMenuBatchJobList.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.tabpgApplyPatch.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.tabpgSettings.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabpgCreatePatch);
            this.tabControl1.Controls.Add(this.tabpgBatchProcessing);
            this.tabControl1.Controls.Add(this.tabpgApplyPatch);
            this.tabControl1.Controls.Add(this.tabpgSettings);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(452, 421);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabpgCreatePatch
            // 
            this.tabpgCreatePatch.Controls.Add(this.btnResetForms);
            this.tabpgCreatePatch.Controls.Add(this.btnAddEditJob);
            this.tabpgCreatePatch.Controls.Add(this.btnSwapSnT);
            this.tabpgCreatePatch.Controls.Add(this.groupBox4);
            this.tabpgCreatePatch.Controls.Add(this.groupBox3);
            this.tabpgCreatePatch.Controls.Add(this.groupBox2);
            this.tabpgCreatePatch.Controls.Add(this.groupBox1);
            this.tabpgCreatePatch.Location = new System.Drawing.Point(4, 22);
            this.tabpgCreatePatch.Name = "tabpgCreatePatch";
            this.tabpgCreatePatch.Padding = new System.Windows.Forms.Padding(3);
            this.tabpgCreatePatch.Size = new System.Drawing.Size(444, 395);
            this.tabpgCreatePatch.TabIndex = 0;
            this.tabpgCreatePatch.Text = "Create Patch";
            this.tabpgCreatePatch.UseVisualStyleBackColor = true;
            // 
            // btnResetForms
            // 
            this.btnResetForms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnResetForms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetForms.Location = new System.Drawing.Point(6, 365);
            this.btnResetForms.Name = "btnResetForms";
            this.btnResetForms.Size = new System.Drawing.Size(88, 23);
            this.btnResetForms.TabIndex = 8;
            this.btnResetForms.Text = "&Reset Forms";
            this.btnResetForms.UseVisualStyleBackColor = true;
            this.btnResetForms.Click += new System.EventHandler(this.btnResetForms_Click);
            // 
            // btnAddEditJob
            // 
            this.btnAddEditJob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddEditJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddEditJob.Location = new System.Drawing.Point(350, 365);
            this.btnAddEditJob.Name = "btnAddEditJob";
            this.btnAddEditJob.Size = new System.Drawing.Size(88, 23);
            this.btnAddEditJob.TabIndex = 10;
            this.btnAddEditJob.Text = "&Add to batch";
            this.btnAddEditJob.UseVisualStyleBackColor = true;
            this.btnAddEditJob.Click += new System.EventHandler(this.btnAddEditJob_Click);
            // 
            // btnSwapSnT
            // 
            this.btnSwapSnT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSwapSnT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwapSnT.Location = new System.Drawing.Point(100, 365);
            this.btnSwapSnT.Name = "btnSwapSnT";
            this.btnSwapSnT.Size = new System.Drawing.Size(244, 23);
            this.btnSwapSnT.TabIndex = 9;
            this.btnSwapSnT.Text = "&Source File <<-->> Target File";
            this.btnSwapSnT.UseVisualStyleBackColor = true;
            this.btnSwapSnT.Click += new System.EventHandler(this.btnSwapSnT_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.rtbLog);
            this.groupBox4.Location = new System.Drawing.Point(6, 171);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(432, 188);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Log";
            // 
            // rtbLog
            // 
            this.rtbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbLog.DetectUrls = false;
            this.rtbLog.Location = new System.Drawing.Point(6, 19);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtbLog.Size = new System.Drawing.Size(419, 163);
            this.rtbLog.TabIndex = 7;
            this.rtbLog.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnBrowseOutputDir);
            this.groupBox3.Controls.Add(this.txtOutputDir);
            this.groupBox3.Location = new System.Drawing.Point(6, 116);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(432, 49);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output Directory";
            // 
            // btnBrowseOutputDir
            // 
            this.btnBrowseOutputDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseOutputDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseOutputDir.Location = new System.Drawing.Point(396, 16);
            this.btnBrowseOutputDir.Name = "btnBrowseOutputDir";
            this.btnBrowseOutputDir.Size = new System.Drawing.Size(30, 23);
            this.btnBrowseOutputDir.TabIndex = 6;
            this.btnBrowseOutputDir.Text = "...";
            this.btnBrowseOutputDir.UseVisualStyleBackColor = true;
            this.btnBrowseOutputDir.Click += new System.EventHandler(this.btnBrowseOutputDir_Click);
            // 
            // txtOutputDir
            // 
            this.txtOutputDir.AllowDrop = true;
            this.txtOutputDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutputDir.Location = new System.Drawing.Point(6, 19);
            this.txtOutputDir.Name = "txtOutputDir";
            this.txtOutputDir.Size = new System.Drawing.Size(384, 20);
            this.txtOutputDir.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtOutputDir, "Drop a directory here~");
            this.txtOutputDir.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtOutputDir_DragDrop);
            this.txtOutputDir.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtOutputDir_DragEnter);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnBrowseTargetFile);
            this.groupBox2.Controls.Add(this.txtTargetFile);
            this.groupBox2.Location = new System.Drawing.Point(6, 61);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(432, 49);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Target File";
            // 
            // btnBrowseTargetFile
            // 
            this.btnBrowseTargetFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseTargetFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseTargetFile.Location = new System.Drawing.Point(396, 16);
            this.btnBrowseTargetFile.Name = "btnBrowseTargetFile";
            this.btnBrowseTargetFile.Size = new System.Drawing.Size(30, 23);
            this.btnBrowseTargetFile.TabIndex = 4;
            this.btnBrowseTargetFile.Text = "...";
            this.btnBrowseTargetFile.UseVisualStyleBackColor = true;
            this.btnBrowseTargetFile.Click += new System.EventHandler(this.btnBrowseTargetFile_Click);
            // 
            // txtTargetFile
            // 
            this.txtTargetFile.AllowDrop = true;
            this.txtTargetFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTargetFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTargetFile.Location = new System.Drawing.Point(6, 19);
            this.txtTargetFile.Name = "txtTargetFile";
            this.txtTargetFile.Size = new System.Drawing.Size(384, 20);
            this.txtTargetFile.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtTargetFile, "Drop a file here~");
            this.txtTargetFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtTargetFile_DragDrop);
            this.txtTargetFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtTargetFile_DragEnter);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnBrowseSourceFile);
            this.groupBox1.Controls.Add(this.txtSourceFile);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 49);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source File";
            // 
            // btnBrowseSourceFile
            // 
            this.btnBrowseSourceFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseSourceFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseSourceFile.Location = new System.Drawing.Point(396, 16);
            this.btnBrowseSourceFile.Name = "btnBrowseSourceFile";
            this.btnBrowseSourceFile.Size = new System.Drawing.Size(30, 23);
            this.btnBrowseSourceFile.TabIndex = 2;
            this.btnBrowseSourceFile.Text = "...";
            this.btnBrowseSourceFile.UseVisualStyleBackColor = true;
            this.btnBrowseSourceFile.Click += new System.EventHandler(this.btnBrowseSourceFile_Click);
            // 
            // txtSourceFile
            // 
            this.txtSourceFile.AllowDrop = true;
            this.txtSourceFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSourceFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSourceFile.Location = new System.Drawing.Point(6, 19);
            this.txtSourceFile.Name = "txtSourceFile";
            this.txtSourceFile.Size = new System.Drawing.Size(384, 20);
            this.txtSourceFile.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtSourceFile, "Drop a file here~");
            this.txtSourceFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtSourceFile_DragDrop);
            this.txtSourceFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtSourceFile_DragEnter);
            // 
            // tabpgBatchProcessing
            // 
            this.tabpgBatchProcessing.Controls.Add(this.groupBox14);
            this.tabpgBatchProcessing.Controls.Add(this.groupBox13);
            this.tabpgBatchProcessing.Location = new System.Drawing.Point(4, 22);
            this.tabpgBatchProcessing.Name = "tabpgBatchProcessing";
            this.tabpgBatchProcessing.Padding = new System.Windows.Forms.Padding(3);
            this.tabpgBatchProcessing.Size = new System.Drawing.Size(444, 395);
            this.tabpgBatchProcessing.TabIndex = 1;
            this.tabpgBatchProcessing.Text = "Batch Processing";
            this.tabpgBatchProcessing.UseVisualStyleBackColor = true;
            // 
            // groupBox14
            // 
            this.groupBox14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox14.Controls.Add(this.btnClear);
            this.groupBox14.Controls.Add(this.btnRemove);
            this.groupBox14.Controls.Add(this.listView1);
            this.groupBox14.Controls.Add(this.btnEdit);
            this.groupBox14.Location = new System.Drawing.Point(6, 6);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(432, 298);
            this.groupBox14.TabIndex = 14;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Job list";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Location = new System.Drawing.Point(351, 16);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "&Clear List";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Location = new System.Drawing.Point(270, 16);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "&Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.ContextMenuStrip = this.contextMenuBatchJobList;
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(6, 45);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(420, 246);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Source File";
            this.columnHeader1.Width = 135;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Target File";
            this.columnHeader2.Width = 142;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Output Directory";
            this.columnHeader3.Width = 134;
            // 
            // contextMenuBatchJobList
            // 
            this.contextMenuBatchJobList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.resetToolStripMenuItem});
            this.contextMenuBatchJobList.Name = "contextMenuStrip1";
            this.contextMenuBatchJobList.Size = new System.Drawing.Size(124, 70);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "images_1ske4zt113.ico");
            this.imageList1.Images.SetKeyName(1, "ico_alpha_SysInfo_Unit1_ImageList1_0_16x16.ico");
            this.imageList1.Images.SetKeyName(2, "BLANK.ICO");
            // 
            // btnEdit
            // 
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Location = new System.Drawing.Point(6, 16);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "&Edit...";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // groupBox13
            // 
            this.groupBox13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox13.Controls.Add(this.btnBatchLoadDirs);
            this.groupBox13.Controls.Add(this.btnBrowseBatchSourceDir);
            this.groupBox13.Controls.Add(this.txtBatchSourceDir);
            this.groupBox13.Controls.Add(this.label2);
            this.groupBox13.Controls.Add(this.btnBrowseBatchTargetDir);
            this.groupBox13.Controls.Add(this.txtBatchTargetDir);
            this.groupBox13.Controls.Add(this.label1);
            this.groupBox13.Location = new System.Drawing.Point(6, 310);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(432, 79);
            this.groupBox13.TabIndex = 13;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Patches for batch";
            // 
            // btnBatchLoadDirs
            // 
            this.btnBatchLoadDirs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchLoadDirs.Enabled = false;
            this.btnBatchLoadDirs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatchLoadDirs.Location = new System.Drawing.Point(380, 16);
            this.btnBatchLoadDirs.Name = "btnBatchLoadDirs";
            this.btnBatchLoadDirs.Size = new System.Drawing.Size(46, 54);
            this.btnBatchLoadDirs.TabIndex = 13;
            this.btnBatchLoadDirs.Text = "LOAD";
            this.toolTip1.SetToolTip(this.btnBatchLoadDirs, "Not yet implemented; don\'t bother to ask when");
            this.btnBatchLoadDirs.UseVisualStyleBackColor = true;
            this.btnBatchLoadDirs.Click += new System.EventHandler(this.btnBatchLoadDirs_Click);
            // 
            // btnBrowseBatchSourceDir
            // 
            this.btnBrowseBatchSourceDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseBatchSourceDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseBatchSourceDir.Location = new System.Drawing.Point(344, 16);
            this.btnBrowseBatchSourceDir.Name = "btnBrowseBatchSourceDir";
            this.btnBrowseBatchSourceDir.Size = new System.Drawing.Size(30, 23);
            this.btnBrowseBatchSourceDir.TabIndex = 18;
            this.btnBrowseBatchSourceDir.Text = "...";
            this.btnBrowseBatchSourceDir.UseVisualStyleBackColor = true;
            this.btnBrowseBatchSourceDir.Click += new System.EventHandler(this.btnBrowseBatchSourceDir_Click);
            // 
            // txtBatchSourceDir
            // 
            this.txtBatchSourceDir.AllowDrop = true;
            this.txtBatchSourceDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBatchSourceDir.Location = new System.Drawing.Point(99, 19);
            this.txtBatchSourceDir.Name = "txtBatchSourceDir";
            this.txtBatchSourceDir.Size = new System.Drawing.Size(239, 20);
            this.txtBatchSourceDir.TabIndex = 17;
            this.toolTip1.SetToolTip(this.txtBatchSourceDir, "Drop a directory here~");
            this.txtBatchSourceDir.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtBatchSourceDir_DragDrop);
            this.txtBatchSourceDir.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtBatchSourceDir_DragEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Source directory:";
            // 
            // btnBrowseBatchTargetDir
            // 
            this.btnBrowseBatchTargetDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseBatchTargetDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseBatchTargetDir.Location = new System.Drawing.Point(344, 48);
            this.btnBrowseBatchTargetDir.Name = "btnBrowseBatchTargetDir";
            this.btnBrowseBatchTargetDir.Size = new System.Drawing.Size(30, 23);
            this.btnBrowseBatchTargetDir.TabIndex = 15;
            this.btnBrowseBatchTargetDir.Text = "...";
            this.btnBrowseBatchTargetDir.UseVisualStyleBackColor = true;
            this.btnBrowseBatchTargetDir.Click += new System.EventHandler(this.btnBrowseBatchTargetDir_Click);
            // 
            // txtBatchTargetDir
            // 
            this.txtBatchTargetDir.AllowDrop = true;
            this.txtBatchTargetDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBatchTargetDir.Location = new System.Drawing.Point(99, 50);
            this.txtBatchTargetDir.Name = "txtBatchTargetDir";
            this.txtBatchTargetDir.Size = new System.Drawing.Size(239, 20);
            this.txtBatchTargetDir.TabIndex = 14;
            this.toolTip1.SetToolTip(this.txtBatchTargetDir, "Drop a directory here~");
            this.txtBatchTargetDir.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtBatchTargetDir_DragDrop);
            this.txtBatchTargetDir.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtBatchTargetDir_DragEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Target directory:";
            // 
            // tabpgApplyPatch
            // 
            this.tabpgApplyPatch.Controls.Add(this.groupBox8);
            this.tabpgApplyPatch.Controls.Add(this.groupBox9);
            this.tabpgApplyPatch.Controls.Add(this.groupBox10);
            this.tabpgApplyPatch.Controls.Add(this.groupBox11);
            this.tabpgApplyPatch.Location = new System.Drawing.Point(4, 22);
            this.tabpgApplyPatch.Name = "tabpgApplyPatch";
            this.tabpgApplyPatch.Size = new System.Drawing.Size(444, 395);
            this.tabpgApplyPatch.TabIndex = 3;
            this.tabpgApplyPatch.Text = "Apply Patch";
            this.tabpgApplyPatch.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Controls.Add(this.rtbApplyLog);
            this.groupBox8.Location = new System.Drawing.Point(6, 171);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(429, 188);
            this.groupBox8.TabIndex = 4;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Log";
            // 
            // rtbApplyLog
            // 
            this.rtbApplyLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbApplyLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbApplyLog.DetectUrls = false;
            this.rtbApplyLog.Location = new System.Drawing.Point(6, 19);
            this.rtbApplyLog.Name = "rtbApplyLog";
            this.rtbApplyLog.ReadOnly = true;
            this.rtbApplyLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtbApplyLog.Size = new System.Drawing.Size(416, 163);
            this.rtbApplyLog.TabIndex = 7;
            this.rtbApplyLog.Text = "";
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox9.Controls.Add(this.btnBrowseApplyOutput);
            this.groupBox9.Controls.Add(this.txtApplyOutput);
            this.groupBox9.Location = new System.Drawing.Point(6, 116);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(432, 49);
            this.groupBox9.TabIndex = 5;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Output File";
            // 
            // btnBrowseApplyOutput
            // 
            this.btnBrowseApplyOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseApplyOutput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseApplyOutput.Location = new System.Drawing.Point(396, 16);
            this.btnBrowseApplyOutput.Name = "btnBrowseApplyOutput";
            this.btnBrowseApplyOutput.Size = new System.Drawing.Size(30, 23);
            this.btnBrowseApplyOutput.TabIndex = 6;
            this.btnBrowseApplyOutput.Text = "...";
            this.btnBrowseApplyOutput.UseVisualStyleBackColor = true;
            this.btnBrowseApplyOutput.Click += new System.EventHandler(this.btnBrowseApplyOutput_Click);
            // 
            // txtApplyOutput
            // 
            this.txtApplyOutput.AllowDrop = true;
            this.txtApplyOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApplyOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApplyOutput.Location = new System.Drawing.Point(6, 19);
            this.txtApplyOutput.Name = "txtApplyOutput";
            this.txtApplyOutput.Size = new System.Drawing.Size(384, 20);
            this.txtApplyOutput.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtApplyOutput, "Drop a directory here~");
            this.txtApplyOutput.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtApplyOutput_DragDrop);
            this.txtApplyOutput.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtApplyOutput_DragEnter);
            // 
            // groupBox10
            // 
            this.groupBox10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox10.Controls.Add(this.btnBrowseApplyVcdiffFile);
            this.groupBox10.Controls.Add(this.txtApplyVcdiffFile);
            this.groupBox10.Location = new System.Drawing.Point(6, 61);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(432, 49);
            this.groupBox10.TabIndex = 2;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "VCDIFF File";
            // 
            // btnBrowseApplyVcdiffFile
            // 
            this.btnBrowseApplyVcdiffFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseApplyVcdiffFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseApplyVcdiffFile.Location = new System.Drawing.Point(396, 16);
            this.btnBrowseApplyVcdiffFile.Name = "btnBrowseApplyVcdiffFile";
            this.btnBrowseApplyVcdiffFile.Size = new System.Drawing.Size(30, 23);
            this.btnBrowseApplyVcdiffFile.TabIndex = 4;
            this.btnBrowseApplyVcdiffFile.Text = "...";
            this.btnBrowseApplyVcdiffFile.UseVisualStyleBackColor = true;
            this.btnBrowseApplyVcdiffFile.Click += new System.EventHandler(this.btnBrowseApplyVcdiffFile_Click);
            // 
            // txtApplyVcdiffFile
            // 
            this.txtApplyVcdiffFile.AllowDrop = true;
            this.txtApplyVcdiffFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApplyVcdiffFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApplyVcdiffFile.Location = new System.Drawing.Point(6, 19);
            this.txtApplyVcdiffFile.Name = "txtApplyVcdiffFile";
            this.txtApplyVcdiffFile.Size = new System.Drawing.Size(384, 20);
            this.txtApplyVcdiffFile.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtApplyVcdiffFile, "Drop a file here~");
            this.txtApplyVcdiffFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtApplyVcdiffFile_DragDrop);
            this.txtApplyVcdiffFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtApplyVcdiffFile_DragEnter);
            // 
            // groupBox11
            // 
            this.groupBox11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox11.Controls.Add(this.btnBrowseApplySource);
            this.groupBox11.Controls.Add(this.txtApplySource);
            this.groupBox11.Location = new System.Drawing.Point(6, 6);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(432, 49);
            this.groupBox11.TabIndex = 3;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Source File";
            // 
            // btnBrowseApplySource
            // 
            this.btnBrowseApplySource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseApplySource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseApplySource.Location = new System.Drawing.Point(396, 16);
            this.btnBrowseApplySource.Name = "btnBrowseApplySource";
            this.btnBrowseApplySource.Size = new System.Drawing.Size(30, 23);
            this.btnBrowseApplySource.TabIndex = 2;
            this.btnBrowseApplySource.Text = "...";
            this.btnBrowseApplySource.UseVisualStyleBackColor = true;
            this.btnBrowseApplySource.Click += new System.EventHandler(this.btnBrowseApplySource_Click);
            // 
            // txtApplySource
            // 
            this.txtApplySource.AllowDrop = true;
            this.txtApplySource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApplySource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApplySource.Location = new System.Drawing.Point(6, 19);
            this.txtApplySource.Name = "txtApplySource";
            this.txtApplySource.Size = new System.Drawing.Size(384, 20);
            this.txtApplySource.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtApplySource, "Drop a file here~");
            this.txtApplySource.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtApplySource_DragDrop);
            this.txtApplySource.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtApplySource_DragEnter);
            // 
            // tabpgSettings
            // 
            this.tabpgSettings.Controls.Add(this.groupBox12);
            this.tabpgSettings.Controls.Add(this.groupBox7);
            this.tabpgSettings.Controls.Add(this.groupBox6);
            this.tabpgSettings.Controls.Add(this.groupBox5);
            this.tabpgSettings.Location = new System.Drawing.Point(4, 22);
            this.tabpgSettings.Name = "tabpgSettings";
            this.tabpgSettings.Size = new System.Drawing.Size(444, 395);
            this.tabpgSettings.TabIndex = 2;
            this.tabpgSettings.Text = "Settings";
            this.tabpgSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox12
            // 
            this.groupBox12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox12.Controls.Add(this.chbAddNewPatchToApplyAllScripts);
            this.groupBox12.Controls.Add(this.chbFunnyMode);
            this.groupBox12.Location = new System.Drawing.Point(3, 321);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(430, 71);
            this.groupBox12.TabIndex = 3;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Misc";
            // 
            // chbAddNewPatchToApplyAllScripts
            // 
            this.chbAddNewPatchToApplyAllScripts.AutoSize = true;
            this.chbAddNewPatchToApplyAllScripts.Location = new System.Drawing.Point(6, 19);
            this.chbAddNewPatchToApplyAllScripts.Name = "chbAddNewPatchToApplyAllScripts";
            this.chbAddNewPatchToApplyAllScripts.Size = new System.Drawing.Size(270, 17);
            this.chbAddNewPatchToApplyAllScripts.TabIndex = 13;
            this.chbAddNewPatchToApplyAllScripts.Text = "Add new patches to \"Apply all\" scripts automatically";
            this.chbAddNewPatchToApplyAllScripts.UseVisualStyleBackColor = true;
            this.chbAddNewPatchToApplyAllScripts.CheckedChanged += new System.EventHandler(this.chbAddNewPatchToApplyAllScripts_CheckedChanged);
            // 
            // chbFunnyMode
            // 
            this.chbFunnyMode.AutoSize = true;
            this.chbFunnyMode.Location = new System.Drawing.Point(340, 19);
            this.chbFunnyMode.Name = "chbFunnyMode";
            this.chbFunnyMode.Size = new System.Drawing.Size(84, 17);
            this.chbFunnyMode.TabIndex = 13;
            this.chbFunnyMode.Text = "Funny mode";
            this.toolTip1.SetToolTip(this.chbFunnyMode, "Check this if you want to troll d1st");
            this.chbFunnyMode.UseVisualStyleBackColor = true;
            this.chbFunnyMode.CheckedChanged += new System.EventHandler(this.chbFunnyMode_CheckedChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.btnBrowseDefaultOutDir);
            this.groupBox7.Controls.Add(this.txtDefaultOutDir);
            this.groupBox7.Controls.Add(this.rdbThisFol);
            this.groupBox7.Controls.Add(this.rdbTargetDir);
            this.groupBox7.Controls.Add(this.rdbSourceDir);
            this.groupBox7.Location = new System.Drawing.Point(3, 99);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(430, 45);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Default output folder";
            // 
            // btnBrowseDefaultOutDir
            // 
            this.btnBrowseDefaultOutDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseDefaultOutDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseDefaultOutDir.Location = new System.Drawing.Point(396, 13);
            this.btnBrowseDefaultOutDir.Name = "btnBrowseDefaultOutDir";
            this.btnBrowseDefaultOutDir.Size = new System.Drawing.Size(28, 23);
            this.btnBrowseDefaultOutDir.TabIndex = 9;
            this.btnBrowseDefaultOutDir.Text = "...";
            this.btnBrowseDefaultOutDir.UseVisualStyleBackColor = true;
            this.btnBrowseDefaultOutDir.Click += new System.EventHandler(this.btnBrowseDefaultOutDir_Click);
            // 
            // txtDefaultOutDir
            // 
            this.txtDefaultOutDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDefaultOutDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDefaultOutDir.Location = new System.Drawing.Point(304, 15);
            this.txtDefaultOutDir.Name = "txtDefaultOutDir";
            this.txtDefaultOutDir.Size = new System.Drawing.Size(86, 20);
            this.txtDefaultOutDir.TabIndex = 8;
            this.txtDefaultOutDir.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rdbThisFol
            // 
            this.rdbThisFol.AutoSize = true;
            this.rdbThisFol.Location = new System.Drawing.Point(247, 17);
            this.rdbThisFol.Name = "rdbThisFol";
            this.rdbThisFol.Size = new System.Drawing.Size(51, 17);
            this.rdbThisFol.TabIndex = 7;
            this.rdbThisFol.Text = "Here:";
            this.rdbThisFol.UseVisualStyleBackColor = true;
            this.rdbThisFol.CheckedChanged += new System.EventHandler(this.rdbThisFol_CheckedChanged);
            // 
            // rdbTargetDir
            // 
            this.rdbTargetDir.AutoSize = true;
            this.rdbTargetDir.Location = new System.Drawing.Point(129, 17);
            this.rdbTargetDir.Name = "rdbTargetDir";
            this.rdbTargetDir.Size = new System.Drawing.Size(112, 17);
            this.rdbTargetDir.TabIndex = 6;
            this.rdbTargetDir.Text = "Same as target file";
            this.rdbTargetDir.UseVisualStyleBackColor = true;
            this.rdbTargetDir.CheckedChanged += new System.EventHandler(this.rdbTargetDir_CheckedChanged);
            // 
            // rdbSourceDir
            // 
            this.rdbSourceDir.AutoSize = true;
            this.rdbSourceDir.Checked = true;
            this.rdbSourceDir.Location = new System.Drawing.Point(6, 17);
            this.rdbSourceDir.Name = "rdbSourceDir";
            this.rdbSourceDir.Size = new System.Drawing.Size(117, 17);
            this.rdbSourceDir.TabIndex = 5;
            this.rdbSourceDir.TabStop = true;
            this.rdbSourceDir.Text = "Same as source file";
            this.rdbSourceDir.UseVisualStyleBackColor = true;
            this.rdbSourceDir.CheckedChanged += new System.EventHandler(this.rdbSourceDir_CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.chbOnlyStoreFileNameInVCDIFF);
            this.groupBox6.Controls.Add(this.chbDist64bitxdelta3);
            this.groupBox6.Controls.Add(this.chbRun64bitxdelta3);
            this.groupBox6.Controls.Add(this.btnSetxdeltaHighMem);
            this.groupBox6.Controls.Add(this.btnApplySetxdeltaDefault);
            this.groupBox6.Controls.Add(this.btnSetxdeltaDefault);
            this.groupBox6.Controls.Add(this.btnSetxdeltaHighCompression);
            this.groupBox6.Controls.Add(this.btnCusXdelHelp);
            this.groupBox6.Controls.Add(this.txtCustomXdeltaParamsForApplying);
            this.groupBox6.Controls.Add(this.chbUseCustomXdeltaParamsForApplying);
            this.groupBox6.Controls.Add(this.txtCustomXdeltaParams);
            this.groupBox6.Controls.Add(this.chbUseCustomXdeltaParams);
            this.groupBox6.Location = new System.Drawing.Point(3, 150);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(430, 165);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "xdelta3 settings";
            // 
            // chbOnlyStoreFileNameInVCDIFF
            // 
            this.chbOnlyStoreFileNameInVCDIFF.AutoSize = true;
            this.chbOnlyStoreFileNameInVCDIFF.Checked = true;
            this.chbOnlyStoreFileNameInVCDIFF.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbOnlyStoreFileNameInVCDIFF.Location = new System.Drawing.Point(6, 141);
            this.chbOnlyStoreFileNameInVCDIFF.Name = "chbOnlyStoreFileNameInVCDIFF";
            this.chbOnlyStoreFileNameInVCDIFF.Size = new System.Drawing.Size(286, 17);
            this.chbOnlyStoreFileNameInVCDIFF.TabIndex = 17;
            this.chbOnlyStoreFileNameInVCDIFF.Text = "Store only filenames in VCDIFF files instead of full paths";
            this.toolTip1.SetToolTip(this.chbOnlyStoreFileNameInVCDIFF, "Still works even when the input files are in two different folders.");
            this.chbOnlyStoreFileNameInVCDIFF.UseVisualStyleBackColor = true;
            // 
            // chbDist64bitxdelta3
            // 
            this.chbDist64bitxdelta3.AutoSize = true;
            this.chbDist64bitxdelta3.Location = new System.Drawing.Point(192, 69);
            this.chbDist64bitxdelta3.Name = "chbDist64bitxdelta3";
            this.chbDist64bitxdelta3.Size = new System.Drawing.Size(187, 17);
            this.chbDist64bitxdelta3.TabIndex = 16;
            this.chbDist64bitxdelta3.Text = "Distribute 64-bit binaries of xdelta3";
            this.toolTip1.SetToolTip(this.chbDist64bitxdelta3, "Copy 64-bit binaries of xdelta3 to output folder instead of 32-bit ones (default)" +
                    ".");
            this.chbDist64bitxdelta3.UseVisualStyleBackColor = true;
            this.chbDist64bitxdelta3.CheckedChanged += new System.EventHandler(this.chbDist64bitxdelta3_CheckedChanged);
            // 
            // chbRun64bitxdelta3
            // 
            this.chbRun64bitxdelta3.AutoSize = true;
            this.chbRun64bitxdelta3.Location = new System.Drawing.Point(6, 69);
            this.chbRun64bitxdelta3.Name = "chbRun64bitxdelta3";
            this.chbRun64bitxdelta3.Size = new System.Drawing.Size(179, 17);
            this.chbRun64bitxdelta3.TabIndex = 16;
            this.chbRun64bitxdelta3.Text = "Run the 64-bit version of xdelta3";
            this.toolTip1.SetToolTip(this.chbRun64bitxdelta3, "...instead of the default 32-bit version. \r\nThis setting only has effect in Windo" +
                    "ws system, \r\nas in others, the installed version of xdelta3 is used.");
            this.chbRun64bitxdelta3.UseVisualStyleBackColor = true;
            this.chbRun64bitxdelta3.CheckedChanged += new System.EventHandler(this.chbRun64bitxdelta3_CheckedChanged);
            // 
            // btnSetxdeltaHighMem
            // 
            this.btnSetxdeltaHighMem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetxdeltaHighMem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetxdeltaHighMem.Location = new System.Drawing.Point(133, 13);
            this.btnSetxdeltaHighMem.Name = "btnSetxdeltaHighMem";
            this.btnSetxdeltaHighMem.Size = new System.Drawing.Size(82, 23);
            this.btnSetxdeltaHighMem.TabIndex = 12;
            this.btnSetxdeltaHighMem.Text = "High memory";
            this.toolTip1.SetToolTip(this.btnSetxdeltaHighMem, resources.GetString("btnSetxdeltaHighMem.ToolTip"));
            this.btnSetxdeltaHighMem.UseVisualStyleBackColor = true;
            this.btnSetxdeltaHighMem.Click += new System.EventHandler(this.btnSetxdeltaHighMem_Click);
            // 
            // btnApplySetxdeltaDefault
            // 
            this.btnApplySetxdeltaDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplySetxdeltaDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplySetxdeltaDefault.Location = new System.Drawing.Point(363, 86);
            this.btnApplySetxdeltaDefault.Name = "btnApplySetxdeltaDefault";
            this.btnApplySetxdeltaDefault.Size = new System.Drawing.Size(61, 23);
            this.btnApplySetxdeltaDefault.TabIndex = 14;
            this.btnApplySetxdeltaDefault.Text = "Default";
            this.btnApplySetxdeltaDefault.UseVisualStyleBackColor = true;
            this.btnApplySetxdeltaDefault.Click += new System.EventHandler(this.btnApplySetxdeltaDefault_Click);
            // 
            // btnSetxdeltaDefault
            // 
            this.btnSetxdeltaDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetxdeltaDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetxdeltaDefault.Location = new System.Drawing.Point(329, 13);
            this.btnSetxdeltaDefault.Name = "btnSetxdeltaDefault";
            this.btnSetxdeltaDefault.Size = new System.Drawing.Size(61, 23);
            this.btnSetxdeltaDefault.TabIndex = 14;
            this.btnSetxdeltaDefault.Text = "Default";
            this.toolTip1.SetToolTip(this.btnSetxdeltaDefault, "Sets to default settings");
            this.btnSetxdeltaDefault.UseVisualStyleBackColor = true;
            this.btnSetxdeltaDefault.Click += new System.EventHandler(this.btnSetxdeltaDefault_Click);
            // 
            // btnSetxdeltaHighCompression
            // 
            this.btnSetxdeltaHighCompression.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetxdeltaHighCompression.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetxdeltaHighCompression.Location = new System.Drawing.Point(221, 13);
            this.btnSetxdeltaHighCompression.Name = "btnSetxdeltaHighCompression";
            this.btnSetxdeltaHighCompression.Size = new System.Drawing.Size(102, 23);
            this.btnSetxdeltaHighCompression.TabIndex = 13;
            this.btnSetxdeltaHighCompression.Text = "High compression";
            this.toolTip1.SetToolTip(this.btnSetxdeltaHighCompression, "Increases compression with more input buffer \r\n(should be at least 2x amount of d" +
                    "ata added/removed), \r\nsecondary compression, and higher compression level (9 is " +
                    "highest).");
            this.btnSetxdeltaHighCompression.UseVisualStyleBackColor = true;
            this.btnSetxdeltaHighCompression.Click += new System.EventHandler(this.btnSetxdeltaHighCompression_Click);
            // 
            // btnCusXdelHelp
            // 
            this.btnCusXdelHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCusXdelHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCusXdelHelp.Location = new System.Drawing.Point(396, 13);
            this.btnCusXdelHelp.Name = "btnCusXdelHelp";
            this.btnCusXdelHelp.Size = new System.Drawing.Size(28, 23);
            this.btnCusXdelHelp.TabIndex = 15;
            this.btnCusXdelHelp.Text = "?";
            this.toolTip1.SetToolTip(this.btnCusXdelHelp, "Visit xdelta wiki page");
            this.btnCusXdelHelp.UseVisualStyleBackColor = true;
            this.btnCusXdelHelp.Click += new System.EventHandler(this.btnCusXdelHelp_Click);
            // 
            // txtCustomXdeltaParamsForApplying
            // 
            this.txtCustomXdeltaParamsForApplying.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomXdeltaParamsForApplying.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomXdeltaParamsForApplying.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtCustomXdeltaParamsForApplying.Location = new System.Drawing.Point(6, 115);
            this.txtCustomXdeltaParamsForApplying.Name = "txtCustomXdeltaParamsForApplying";
            this.txtCustomXdeltaParamsForApplying.Size = new System.Drawing.Size(418, 20);
            this.txtCustomXdeltaParamsForApplying.TabIndex = 11;
            this.txtCustomXdeltaParamsForApplying.Text = "-d -f -s %source% %vcdiff% %output%";
            this.txtCustomXdeltaParamsForApplying.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCustomXdeltaParamsForApplying.TextChanged += new System.EventHandler(this.txtCusXdelta_TextChanged);
            // 
            // chbUseCustomXdeltaParamsForApplying
            // 
            this.chbUseCustomXdeltaParamsForApplying.AutoSize = true;
            this.chbUseCustomXdeltaParamsForApplying.Location = new System.Drawing.Point(6, 92);
            this.chbUseCustomXdeltaParamsForApplying.Name = "chbUseCustomXdeltaParamsForApplying";
            this.chbUseCustomXdeltaParamsForApplying.Size = new System.Drawing.Size(230, 17);
            this.chbUseCustomXdeltaParamsForApplying.TabIndex = 10;
            this.chbUseCustomXdeltaParamsForApplying.Text = "Use custom paramenters for applying patch";
            this.chbUseCustomXdeltaParamsForApplying.UseVisualStyleBackColor = true;
            this.chbUseCustomXdeltaParamsForApplying.CheckedChanged += new System.EventHandler(this.chbUseCusXdelPara_CheckedChanged);
            // 
            // txtCustomXdeltaParams
            // 
            this.txtCustomXdeltaParams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomXdeltaParams.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomXdeltaParams.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtCustomXdeltaParams.Location = new System.Drawing.Point(6, 42);
            this.txtCustomXdeltaParams.Name = "txtCustomXdeltaParams";
            this.txtCustomXdeltaParams.Size = new System.Drawing.Size(418, 20);
            this.txtCustomXdeltaParams.TabIndex = 11;
            this.txtCustomXdeltaParams.Text = "-e -f -s %source% %patched% %vcdiff%";
            this.txtCustomXdeltaParams.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCustomXdeltaParams.TextChanged += new System.EventHandler(this.txtCusXdelta_TextChanged);
            // 
            // chbUseCustomXdeltaParams
            // 
            this.chbUseCustomXdeltaParams.AutoSize = true;
            this.chbUseCustomXdeltaParams.Location = new System.Drawing.Point(6, 19);
            this.chbUseCustomXdeltaParams.Name = "chbUseCustomXdeltaParams";
            this.chbUseCustomXdeltaParams.Size = new System.Drawing.Size(119, 17);
            this.chbUseCustomXdeltaParams.TabIndex = 10;
            this.chbUseCustomXdeltaParams.Text = "Use custom params";
            this.chbUseCustomXdeltaParams.UseVisualStyleBackColor = true;
            this.chbUseCustomXdeltaParams.CheckedChanged += new System.EventHandler(this.chbUseCusXdelPara_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.chbNewAutoName);
            this.groupBox5.Controls.Add(this.txtAddTextWhenSwap);
            this.groupBox5.Controls.Add(this.chbAddTextWhenSwap);
            this.groupBox5.Controls.Add(this.chbDetEpNum);
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(430, 90);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Naming";
            // 
            // chbNewAutoName
            // 
            this.chbNewAutoName.AutoSize = true;
            this.chbNewAutoName.Enabled = false;
            this.chbNewAutoName.Location = new System.Drawing.Point(6, 65);
            this.chbNewAutoName.Name = "chbNewAutoName";
            this.chbNewAutoName.Size = new System.Drawing.Size(383, 17);
            this.chbNewAutoName.TabIndex = 4;
            this.chbNewAutoName.Text = "Use patch_[1CD79B4A]_to_v2_[35B3DE7A] or so as output directory name";
            this.toolTip1.SetToolTip(this.chbNewAutoName, "Not yet implemented; don\'t bother to ask when");
            this.chbNewAutoName.UseVisualStyleBackColor = true;
            // 
            // txtAddTextWhenSwap
            // 
            this.txtAddTextWhenSwap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddTextWhenSwap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddTextWhenSwap.Location = new System.Drawing.Point(273, 39);
            this.txtAddTextWhenSwap.Name = "txtAddTextWhenSwap";
            this.txtAddTextWhenSwap.Size = new System.Drawing.Size(151, 20);
            this.txtAddTextWhenSwap.TabIndex = 3;
            this.txtAddTextWhenSwap.Text = "_revert";
            this.txtAddTextWhenSwap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chbAddTextWhenSwap
            // 
            this.chbAddTextWhenSwap.AutoSize = true;
            this.chbAddTextWhenSwap.Location = new System.Drawing.Point(6, 42);
            this.chbAddTextWhenSwap.Name = "chbAddTextWhenSwap";
            this.chbAddTextWhenSwap.Size = new System.Drawing.Size(263, 17);
            this.chbAddTextWhenSwap.TabIndex = 2;
            this.chbAddTextWhenSwap.Text = "Add this to output directory when swapping inputs:";
            this.chbAddTextWhenSwap.UseVisualStyleBackColor = true;
            // 
            // chbDetEpNum
            // 
            this.chbDetEpNum.AutoSize = true;
            this.chbDetEpNum.Checked = true;
            this.chbDetEpNum.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbDetEpNum.Location = new System.Drawing.Point(6, 19);
            this.chbDetEpNum.Name = "chbDetEpNum";
            this.chbDetEpNum.Size = new System.Drawing.Size(185, 17);
            this.chbDetEpNum.TabIndex = 1;
            this.chbDetEpNum.Text = "Attempt to detect episode number";
            this.chbDetEpNum.UseVisualStyleBackColor = true;
            this.chbDetEpNum.CheckedChanged += new System.EventHandler(this.chbDetEpNum_CheckedChanged);
            // 
            // ofdFileBrowser
            // 
            this.ofdFileBrowser.Filter = "All files|*.*|MKV Files|*.mkv|MP4 Files|*.mp4";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(12, 441);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(98, 23);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Location = new System.Drawing.Point(366, 441);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(98, 23);
            this.btnStart.TabIndex = 12;
            this.btnStart.Text = "&Create Patch";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // bgwCreatePatch
            // 
            this.bgwCreatePatch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.createPatchBackground);
            // 
            // bgwApplyPatch
            // 
            this.bgwApplyPatch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.applyPatchBackground);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.Filter = "All files|*.*|MKV Files|*.mkv|MP4 Files|*.mp4";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 480);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(488, 507);
            this.Name = "frmMain";
            this.Text = "Yet Another xdelta3-based Patch Creator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabpgCreatePatch.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabpgBatchProcessing.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.contextMenuBatchJobList.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.tabpgApplyPatch.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.tabpgSettings.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabpgCreatePatch;
        private System.Windows.Forms.TabPage tabpgBatchProcessing;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnBrowseOutputDir;
        private System.Windows.Forms.TextBox txtOutputDir;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBrowseTargetFile;
        private System.Windows.Forms.TextBox txtTargetFile;
        private System.Windows.Forms.Button btnBrowseSourceFile;
        private System.Windows.Forms.TextBox txtSourceFile;
        private System.Windows.Forms.OpenFileDialog ofdFileBrowser;
        private System.Windows.Forms.FolderBrowserDialog fbdDirBrowser;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TabPage tabpgSettings;
        private System.Windows.Forms.Button btnSwapSnT;
        private System.ComponentModel.BackgroundWorker bgwCreatePatch;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.CheckBox chbDetEpNum;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox chbUseCustomXdeltaParams;
        private System.Windows.Forms.TextBox txtCustomXdeltaParams;
        private System.Windows.Forms.Button btnSetxdeltaHighCompression;
        private System.Windows.Forms.Button btnCusXdelHelp;
        private System.Windows.Forms.TextBox txtAddTextWhenSwap;
        private System.Windows.Forms.CheckBox chbAddTextWhenSwap;
        private System.Windows.Forms.CheckBox chbNewAutoName;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnResetForms;
        private System.Windows.Forms.Button btnAddEditJob;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuBatchJobList;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RadioButton rdbThisFol;
        private System.Windows.Forms.RadioButton rdbTargetDir;
        private System.Windows.Forms.RadioButton rdbSourceDir;
        private System.Windows.Forms.Button btnBrowseDefaultOutDir;
        private System.Windows.Forms.TextBox txtDefaultOutDir;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnSetxdeltaHighMem;
        private System.Windows.Forms.Button btnSetxdeltaDefault;
        private System.Windows.Forms.CheckBox chbRun64bitxdelta3;
        private System.Windows.Forms.CheckBox chbDist64bitxdelta3;
        private System.Windows.Forms.TabPage tabpgApplyPatch;
        private System.ComponentModel.BackgroundWorker bgwApplyPatch;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.RichTextBox rtbApplyLog;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button btnBrowseApplyOutput;
        private System.Windows.Forms.TextBox txtApplyOutput;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button btnBrowseApplyVcdiffFile;
        private System.Windows.Forms.TextBox txtApplyVcdiffFile;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Button btnBrowseApplySource;
        private System.Windows.Forms.TextBox txtApplySource;
        private System.Windows.Forms.TextBox txtCustomXdeltaParamsForApplying;
        private System.Windows.Forms.CheckBox chbUseCustomXdeltaParamsForApplying;
        private System.Windows.Forms.Button btnApplySetxdeltaDefault;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.CheckBox chbOnlyStoreFileNameInVCDIFF;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.CheckBox chbFunnyMode;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.Button btnBrowseBatchSourceDir;
        private System.Windows.Forms.TextBox txtBatchSourceDir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowseBatchTargetDir;
        private System.Windows.Forms.TextBox txtBatchTargetDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBatchLoadDirs;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.CheckBox chbAddNewPatchToApplyAllScripts;
    }
}

