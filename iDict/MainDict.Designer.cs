namespace iDict
{
    partial class MainDict
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDict));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.lstWordsList = new System.Windows.Forms.ListBox();
            this.tabDictList = new System.Windows.Forms.TabControl();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.cbbWord = new System.Windows.Forms.ComboBox();
            this.lblTotalWord = new System.Windows.Forms.Label();
            this.cbbKeypad = new System.Windows.Forms.ComboBox();
            this.txbPosition = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPronounce = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCheckWord = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsConvert = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsIDictCV = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDictTabCV = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsBabylonCV = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsStardictCV = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsTranslation = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsMiniDict = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsMainDict = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsStartWithWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsExit = new System.Windows.Forms.ToolStripMenuItem();
            this.iDictNotify = new System.Windows.Forms.NotifyIcon(this.components);
            this.cbbVoice = new System.Windows.Forms.ComboBox();
            this.btnTranslate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAddWord = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnPronounce = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnEditWord = new System.Windows.Forms.Button();
            this.btnDeleteWord = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.btnDictInfo = new System.Windows.Forms.Button();
            this.btnManageDict = new System.Windows.Forms.Button();
            this.btnAdvancedSearch = new System.Windows.Forms.Button();
            this.btnConfiguration = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.vScrollBar1);
            this.splitContainer1.Panel1.Controls.Add(this.lstWordsList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabDictList);
            this.splitContainer1.Panel2.Controls.Add(this.webBrowser1);
            // 
            // vScrollBar1
            // 
            resources.ApplyResources(this.vScrollBar1, "vScrollBar1");
            this.vScrollBar1.Name = "vScrollBar1";
            // 
            // lstWordsList
            // 
            this.lstWordsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.lstWordsList, "lstWordsList");
            this.lstWordsList.Name = "lstWordsList";
            this.lstWordsList.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.lstWordsList_MouseWheel);
            this.lstWordsList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstWordsList_MouseClick);
            this.lstWordsList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstWordsList_KeyDown);
            // 
            // tabDictList
            // 
            resources.ApplyResources(this.tabDictList, "tabDictList");
            this.tabDictList.Name = "tabDictList";
            this.tabDictList.SelectedIndex = 0;
            this.tabDictList.SelectedIndexChanged += new System.EventHandler(this.tabDictList_SelectedIndexChanged);
            // 
            // webBrowser1
            // 
            resources.ApplyResources(this.webBrowser1, "webBrowser1");
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Url = new System.Uri("about:blank", System.UriKind.Absolute);
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // cbbWord
            // 
            this.cbbWord.AllowDrop = true;
            resources.ApplyResources(this.cbbWord, "cbbWord");
            this.cbbWord.BackColor = System.Drawing.SystemColors.Window;
            this.cbbWord.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbbWord.FormattingEnabled = true;
            this.cbbWord.Items.AddRange(new object[] {
            resources.GetString("cbbWord.Items"),
            resources.GetString("cbbWord.Items1"),
            resources.GetString("cbbWord.Items2"),
            resources.GetString("cbbWord.Items3"),
            resources.GetString("cbbWord.Items4"),
            resources.GetString("cbbWord.Items5"),
            resources.GetString("cbbWord.Items6"),
            resources.GetString("cbbWord.Items7"),
            resources.GetString("cbbWord.Items8"),
            resources.GetString("cbbWord.Items9"),
            resources.GetString("cbbWord.Items10"),
            resources.GetString("cbbWord.Items11"),
            resources.GetString("cbbWord.Items12"),
            resources.GetString("cbbWord.Items13"),
            resources.GetString("cbbWord.Items14"),
            resources.GetString("cbbWord.Items15"),
            resources.GetString("cbbWord.Items16"),
            resources.GetString("cbbWord.Items17"),
            resources.GetString("cbbWord.Items18"),
            resources.GetString("cbbWord.Items19"),
            resources.GetString("cbbWord.Items20"),
            resources.GetString("cbbWord.Items21"),
            resources.GetString("cbbWord.Items22"),
            resources.GetString("cbbWord.Items23"),
            resources.GetString("cbbWord.Items24"),
            resources.GetString("cbbWord.Items25"),
            resources.GetString("cbbWord.Items26"),
            resources.GetString("cbbWord.Items27"),
            resources.GetString("cbbWord.Items28"),
            resources.GetString("cbbWord.Items29"),
            resources.GetString("cbbWord.Items30"),
            resources.GetString("cbbWord.Items31"),
            resources.GetString("cbbWord.Items32"),
            resources.GetString("cbbWord.Items33"),
            resources.GetString("cbbWord.Items34"),
            resources.GetString("cbbWord.Items35"),
            resources.GetString("cbbWord.Items36"),
            resources.GetString("cbbWord.Items37"),
            resources.GetString("cbbWord.Items38"),
            resources.GetString("cbbWord.Items39"),
            resources.GetString("cbbWord.Items40"),
            resources.GetString("cbbWord.Items41"),
            resources.GetString("cbbWord.Items42"),
            resources.GetString("cbbWord.Items43"),
            resources.GetString("cbbWord.Items44"),
            resources.GetString("cbbWord.Items45"),
            resources.GetString("cbbWord.Items46"),
            resources.GetString("cbbWord.Items47"),
            resources.GetString("cbbWord.Items48"),
            resources.GetString("cbbWord.Items49"),
            resources.GetString("cbbWord.Items50"),
            resources.GetString("cbbWord.Items51"),
            resources.GetString("cbbWord.Items52"),
            resources.GetString("cbbWord.Items53"),
            resources.GetString("cbbWord.Items54"),
            resources.GetString("cbbWord.Items55"),
            resources.GetString("cbbWord.Items56"),
            resources.GetString("cbbWord.Items57"),
            resources.GetString("cbbWord.Items58"),
            resources.GetString("cbbWord.Items59"),
            resources.GetString("cbbWord.Items60"),
            resources.GetString("cbbWord.Items61"),
            resources.GetString("cbbWord.Items62"),
            resources.GetString("cbbWord.Items63"),
            resources.GetString("cbbWord.Items64"),
            resources.GetString("cbbWord.Items65"),
            resources.GetString("cbbWord.Items66"),
            resources.GetString("cbbWord.Items67"),
            resources.GetString("cbbWord.Items68"),
            resources.GetString("cbbWord.Items69"),
            resources.GetString("cbbWord.Items70"),
            resources.GetString("cbbWord.Items71"),
            resources.GetString("cbbWord.Items72"),
            resources.GetString("cbbWord.Items73"),
            resources.GetString("cbbWord.Items74"),
            resources.GetString("cbbWord.Items75"),
            resources.GetString("cbbWord.Items76"),
            resources.GetString("cbbWord.Items77"),
            resources.GetString("cbbWord.Items78"),
            resources.GetString("cbbWord.Items79"),
            resources.GetString("cbbWord.Items80"),
            resources.GetString("cbbWord.Items81"),
            resources.GetString("cbbWord.Items82"),
            resources.GetString("cbbWord.Items83"),
            resources.GetString("cbbWord.Items84"),
            resources.GetString("cbbWord.Items85"),
            resources.GetString("cbbWord.Items86"),
            resources.GetString("cbbWord.Items87"),
            resources.GetString("cbbWord.Items88"),
            resources.GetString("cbbWord.Items89"),
            resources.GetString("cbbWord.Items90"),
            resources.GetString("cbbWord.Items91"),
            resources.GetString("cbbWord.Items92"),
            resources.GetString("cbbWord.Items93"),
            resources.GetString("cbbWord.Items94"),
            resources.GetString("cbbWord.Items95"),
            resources.GetString("cbbWord.Items96"),
            resources.GetString("cbbWord.Items97"),
            resources.GetString("cbbWord.Items98"),
            resources.GetString("cbbWord.Items99")});
            this.cbbWord.Name = "cbbWord";
            this.cbbWord.SelectionChangeCommitted += new System.EventHandler(this.cbbWord_SelectionChangeCommitted);
            this.cbbWord.DragDrop += new System.Windows.Forms.DragEventHandler(this.cbbWord_DragDrop);
            this.cbbWord.DragEnter += new System.Windows.Forms.DragEventHandler(this.cbbWord_DragEnter);
            this.cbbWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbWord_KeyDown);
            this.cbbWord.TextUpdate += new System.EventHandler(this.cbbWord_TextUpdate);
            // 
            // lblTotalWord
            // 
            resources.ApplyResources(this.lblTotalWord, "lblTotalWord");
            this.lblTotalWord.Name = "lblTotalWord";
            // 
            // cbbKeypad
            // 
            resources.ApplyResources(this.cbbKeypad, "cbbKeypad");
            this.cbbKeypad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbKeypad.FormattingEnabled = true;
            this.cbbKeypad.Items.AddRange(new object[] {
            resources.GetString("cbbKeypad.Items"),
            resources.GetString("cbbKeypad.Items1"),
            resources.GetString("cbbKeypad.Items2"),
            resources.GetString("cbbKeypad.Items3")});
            this.cbbKeypad.Name = "cbbKeypad";
            this.cbbKeypad.SelectedIndexChanged += new System.EventHandler(this.cbbKeypad_SelectedIndexChanged);
            // 
            // txbPosition
            // 
            resources.ApplyResources(this.txbPosition, "txbPosition");
            this.txbPosition.Name = "txbPosition";
            this.txbPosition.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbPosition_KeyPress);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.cmsConvert,
            this.toolStripSeparator3,
            this.cmsTranslation,
            this.cmsMiniDict,
            this.cmsMainDict,
            this.toolStripSeparator2,
            this.cmsClipboard,
            this.cmsStartWithWindows,
            this.toolStripSeparator1,
            this.cmsHelp,
            this.cmsAbout,
            this.cmsExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsPronounce,
            this.cmsCheckWord});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // cmsPronounce
            // 
            resources.ApplyResources(this.cmsPronounce, "cmsPronounce");
            this.cmsPronounce.Name = "cmsPronounce";
            this.cmsPronounce.Click += new System.EventHandler(this.cmsPronounce_Click);
            // 
            // cmsCheckWord
            // 
            this.cmsCheckWord.Name = "cmsCheckWord";
            resources.ApplyResources(this.cmsCheckWord, "cmsCheckWord");
            this.cmsCheckWord.Click += new System.EventHandler(this.cmsCheckWord_Click);
            // 
            // cmsConvert
            // 
            this.cmsConvert.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsIDictCV,
            this.cmsDictTabCV,
            this.cmsBabylonCV,
            this.cmsStardictCV});
            this.cmsConvert.Name = "cmsConvert";
            resources.ApplyResources(this.cmsConvert, "cmsConvert");
            // 
            // cmsIDictCV
            // 
            this.cmsIDictCV.Name = "cmsIDictCV";
            resources.ApplyResources(this.cmsIDictCV, "cmsIDictCV");
            this.cmsIDictCV.Click += new System.EventHandler(this.cmsIDictCV_Click);
            // 
            // cmsDictTabCV
            // 
            this.cmsDictTabCV.Name = "cmsDictTabCV";
            resources.ApplyResources(this.cmsDictTabCV, "cmsDictTabCV");
            this.cmsDictTabCV.Click += new System.EventHandler(this.cmsDictTabCV_Click);
            // 
            // cmsBabylonCV
            // 
            this.cmsBabylonCV.Name = "cmsBabylonCV";
            resources.ApplyResources(this.cmsBabylonCV, "cmsBabylonCV");
            this.cmsBabylonCV.Click += new System.EventHandler(this.cmsBabylonCV_Click);
            // 
            // cmsStardictCV
            // 
            this.cmsStardictCV.Name = "cmsStardictCV";
            resources.ApplyResources(this.cmsStardictCV, "cmsStardictCV");
            this.cmsStardictCV.Click += new System.EventHandler(this.cmsStardictCV_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // cmsTranslation
            // 
            this.cmsTranslation.Name = "cmsTranslation";
            resources.ApplyResources(this.cmsTranslation, "cmsTranslation");
            this.cmsTranslation.Click += new System.EventHandler(this.cmsTranslation_Click);
            // 
            // cmsMiniDict
            // 
            this.cmsMiniDict.Name = "cmsMiniDict";
            resources.ApplyResources(this.cmsMiniDict, "cmsMiniDict");
            this.cmsMiniDict.Click += new System.EventHandler(this.cmsMiniDict_Click);
            // 
            // cmsMainDict
            // 
            this.cmsMainDict.Name = "cmsMainDict";
            resources.ApplyResources(this.cmsMainDict, "cmsMainDict");
            this.cmsMainDict.Click += new System.EventHandler(this.cmsMainDict_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // cmsClipboard
            // 
            this.cmsClipboard.Name = "cmsClipboard";
            resources.ApplyResources(this.cmsClipboard, "cmsClipboard");
            this.cmsClipboard.Click += new System.EventHandler(this.cmsClipboard_Click);
            // 
            // cmsStartWithWindows
            // 
            this.cmsStartWithWindows.Name = "cmsStartWithWindows";
            resources.ApplyResources(this.cmsStartWithWindows, "cmsStartWithWindows");
            this.cmsStartWithWindows.Click += new System.EventHandler(this.cmsStartWithWindows_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // cmsHelp
            // 
            this.cmsHelp.Name = "cmsHelp";
            resources.ApplyResources(this.cmsHelp, "cmsHelp");
            this.cmsHelp.Click += new System.EventHandler(this.cmsHelp_Click);
            // 
            // cmsAbout
            // 
            this.cmsAbout.Name = "cmsAbout";
            resources.ApplyResources(this.cmsAbout, "cmsAbout");
            this.cmsAbout.Click += new System.EventHandler(this.cmsAbout_Click);
            // 
            // cmsExit
            // 
            this.cmsExit.Name = "cmsExit";
            resources.ApplyResources(this.cmsExit, "cmsExit");
            this.cmsExit.Click += new System.EventHandler(this.cmsExit_Click);
            // 
            // iDictNotify
            // 
            this.iDictNotify.ContextMenuStrip = this.contextMenuStrip1;
            resources.ApplyResources(this.iDictNotify, "iDictNotify");
            this.iDictNotify.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.iDictNotify_MouseDoubleClick);
            // 
            // cbbVoice
            // 
            resources.ApplyResources(this.cbbVoice, "cbbVoice");
            this.cbbVoice.DropDownHeight = 110;
            this.cbbVoice.DropDownWidth = 160;
            this.cbbVoice.Name = "cbbVoice";
            this.cbbVoice.SelectedIndexChanged += new System.EventHandler(this.cbbVoice_SelectedIndexChanged);
            // 
            // btnTranslate
            // 
            this.btnTranslate.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnTranslate, "btnTranslate");
            this.btnTranslate.Name = "btnTranslate";
            this.btnTranslate.UseVisualStyleBackColor = true;
            this.btnTranslate.Click += new System.EventHandler(this.btnTranslate_Click);
            // 
            // btnClear
            // 
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.Name = "btnClear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAddWord
            // 
            resources.ApplyResources(this.btnAddWord, "btnAddWord");
            this.btnAddWord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddWord.Name = "btnAddWord";
            this.btnAddWord.UseVisualStyleBackColor = true;
            this.btnAddWord.Click += new System.EventHandler(this.btnAddWord_Click);
            // 
            // btnHelp
            // 
            resources.ApplyResources(this.btnHelp, "btnHelp");
            this.btnHelp.Cursor = System.Windows.Forms.Cursors.Help;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnPronounce
            // 
            resources.ApplyResources(this.btnPronounce, "btnPronounce");
            this.btnPronounce.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPronounce.Name = "btnPronounce";
            this.btnPronounce.UseVisualStyleBackColor = true;
            this.btnPronounce.Click += new System.EventHandler(this.btnPronounce_Click);
            // 
            // btnAbout
            // 
            resources.ApplyResources(this.btnAbout, "btnAbout");
            this.btnAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnEditWord
            // 
            resources.ApplyResources(this.btnEditWord, "btnEditWord");
            this.btnEditWord.Name = "btnEditWord";
            this.btnEditWord.UseVisualStyleBackColor = true;
            this.btnEditWord.Click += new System.EventHandler(this.btnEditWord_Click);
            // 
            // btnDeleteWord
            // 
            resources.ApplyResources(this.btnDeleteWord, "btnDeleteWord");
            this.btnDeleteWord.Cursor = System.Windows.Forms.Cursors.No;
            this.btnDeleteWord.Name = "btnDeleteWord";
            this.btnDeleteWord.UseVisualStyleBackColor = true;
            this.btnDeleteWord.Click += new System.EventHandler(this.btnDeleteWord_Click);
            // 
            // btnExit
            // 
            resources.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnExit.Name = "btnExit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnRename
            // 
            resources.ApplyResources(this.btnRename, "btnRename");
            this.btnRename.Name = "btnRename";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // btnDictInfo
            // 
            resources.ApplyResources(this.btnDictInfo, "btnDictInfo");
            this.btnDictInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDictInfo.Name = "btnDictInfo";
            this.btnDictInfo.Tag = "";
            this.btnDictInfo.UseVisualStyleBackColor = true;
            this.btnDictInfo.Click += new System.EventHandler(this.btnDictInfo_Click);
            // 
            // btnManageDict
            // 
            resources.ApplyResources(this.btnManageDict, "btnManageDict");
            this.btnManageDict.Name = "btnManageDict";
            this.btnManageDict.UseVisualStyleBackColor = true;
            this.btnManageDict.Click += new System.EventHandler(this.btnManageDict_Click);
            // 
            // btnAdvancedSearch
            // 
            resources.ApplyResources(this.btnAdvancedSearch, "btnAdvancedSearch");
            this.btnAdvancedSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdvancedSearch.Name = "btnAdvancedSearch";
            this.btnAdvancedSearch.UseVisualStyleBackColor = true;
            this.btnAdvancedSearch.Click += new System.EventHandler(this.btnAdvancedSearch_Click);
            // 
            // btnConfiguration
            // 
            resources.ApplyResources(this.btnConfiguration, "btnConfiguration");
            this.btnConfiguration.Name = "btnConfiguration";
            this.btnConfiguration.UseVisualStyleBackColor = true;
            this.btnConfiguration.Click += new System.EventHandler(this.btnConfiguration_Click);
            // 
            // trackBar1
            // 
            resources.ApplyResources(this.trackBar1, "trackBar1");
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Value = 10;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // MainDict
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.lblTotalWord);
            this.Controls.Add(this.cbbWord);
            this.Controls.Add(this.btnTranslate);
            this.Controls.Add(this.txbPosition);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnConfiguration);
            this.Controls.Add(this.btnAddWord);
            this.Controls.Add(this.btnPronounce);
            this.Controls.Add(this.cbbKeypad);
            this.Controls.Add(this.cbbVoice);
            this.Controls.Add(this.btnEditWord);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.btnManageDict);
            this.Controls.Add(this.btnDeleteWord);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnAdvancedSearch);
            this.Controls.Add(this.btnDictInfo);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.HelpButton = true;
            this.Name = "MainDict";
            this.Load += new System.EventHandler(this.MainDict_Load);
            this.Shown += new System.EventHandler(this.MainDict_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainDict_FormClosing);
            this.Resize += new System.EventHandler(this.MainDict_Resize);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainDict_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.ComboBox cbbWord;
        private System.Windows.Forms.ListBox lstWordsList;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Button btnAddWord;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.Button btnEditWord;
        private System.Windows.Forms.Button btnDeleteWord;
        private System.Windows.Forms.Button btnManageDict;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Label lblTotalWord;
        private System.Windows.Forms.TextBox txbPosition;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cmsMainDict;
        private System.Windows.Forms.ToolStripMenuItem cmsHelp;
        private System.Windows.Forms.ToolStripMenuItem cmsStartWithWindows;
        private System.Windows.Forms.ToolStripMenuItem cmsMiniDict;
        private System.Windows.Forms.ToolStripMenuItem cmsAbout;
        private System.Windows.Forms.ToolStripMenuItem cmsExit;
        private System.Windows.Forms.NotifyIcon iDictNotify;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cmsConvert;
        private System.Windows.Forms.ToolStripMenuItem cmsIDictCV;
        private System.Windows.Forms.ToolStripMenuItem cmsDictTabCV;
        private System.Windows.Forms.ToolStripMenuItem cmsBabylonCV;
        private System.Windows.Forms.ToolStripMenuItem cmsStardictCV;
        private System.Windows.Forms.ToolStripMenuItem cmsClipboard;
        private System.Windows.Forms.Button btnAdvancedSearch;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnDictInfo;
        private System.Windows.Forms.ComboBox cbbKeypad;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cmsPronounce;
        private System.Windows.Forms.ToolStripMenuItem cmsCheckWord;
        public  System.Windows.Forms.TabControl tabDictList;
        private System.Windows.Forms.ToolStripMenuItem cmsTranslation;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ComboBox cbbVoice;
        private System.Windows.Forms.Button btnPronounce;
        private System.Windows.Forms.Button btnTranslate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnConfiguration;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}

