namespace iDict
{
    partial class AdvancedSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdvancedSearch));
            this.txtPattern = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbSimilarWord = new System.Windows.Forms.RadioButton();
            this.rdbRegex = new System.Windows.Forms.RadioButton();
            this.rdbWildcard = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbSearchAll = new System.Windows.Forms.RadioButton();
            this.rdbMeaning = new System.Windows.Forms.RadioButton();
            this.rdbWord = new System.Windows.Forms.RadioButton();
            this.txbResult = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnLookup = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPattern
            // 
            this.txtPattern.AccessibleDescription = null;
            this.txtPattern.AccessibleName = null;
            resources.ApplyResources(this.txtPattern, "txtPattern");
            this.txtPattern.BackgroundImage = null;
            this.txtPattern.Name = "txtPattern";
            this.txtPattern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPattern_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleDescription = null;
            this.groupBox1.AccessibleName = null;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.BackgroundImage = null;
            this.groupBox1.Controls.Add(this.rdbSimilarWord);
            this.groupBox1.Controls.Add(this.rdbRegex);
            this.groupBox1.Controls.Add(this.rdbWildcard);
            this.groupBox1.Font = null;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // rdbSimilarWord
            // 
            this.rdbSimilarWord.AccessibleDescription = null;
            this.rdbSimilarWord.AccessibleName = null;
            resources.ApplyResources(this.rdbSimilarWord, "rdbSimilarWord");
            this.rdbSimilarWord.BackgroundImage = null;
            this.rdbSimilarWord.Checked = true;
            this.rdbSimilarWord.Font = null;
            this.rdbSimilarWord.Name = "rdbSimilarWord";
            this.rdbSimilarWord.TabStop = true;
            this.rdbSimilarWord.UseVisualStyleBackColor = true;
            this.rdbSimilarWord.Click += new System.EventHandler(this.rdbGanDung_Click);
            // 
            // rdbRegex
            // 
            this.rdbRegex.AccessibleDescription = null;
            this.rdbRegex.AccessibleName = null;
            resources.ApplyResources(this.rdbRegex, "rdbRegex");
            this.rdbRegex.BackgroundImage = null;
            this.rdbRegex.Font = null;
            this.rdbRegex.Name = "rdbRegex";
            this.rdbRegex.UseVisualStyleBackColor = true;
            this.rdbRegex.Click += new System.EventHandler(this.rdbRegex_Click);
            // 
            // rdbWildcard
            // 
            this.rdbWildcard.AccessibleDescription = null;
            this.rdbWildcard.AccessibleName = null;
            resources.ApplyResources(this.rdbWildcard, "rdbWildcard");
            this.rdbWildcard.BackgroundImage = null;
            this.rdbWildcard.Font = null;
            this.rdbWildcard.Name = "rdbWildcard";
            this.rdbWildcard.UseVisualStyleBackColor = true;
            this.rdbWildcard.Click += new System.EventHandler(this.rdbWildcard_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.AccessibleDescription = null;
            this.groupBox2.AccessibleName = null;
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.BackgroundImage = null;
            this.groupBox2.Controls.Add(this.rdbSearchAll);
            this.groupBox2.Controls.Add(this.rdbMeaning);
            this.groupBox2.Controls.Add(this.rdbWord);
            this.groupBox2.Font = null;
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // rdbSearchAll
            // 
            this.rdbSearchAll.AccessibleDescription = null;
            this.rdbSearchAll.AccessibleName = null;
            resources.ApplyResources(this.rdbSearchAll, "rdbSearchAll");
            this.rdbSearchAll.BackgroundImage = null;
            this.rdbSearchAll.Font = null;
            this.rdbSearchAll.Name = "rdbSearchAll";
            this.rdbSearchAll.TabStop = true;
            this.rdbSearchAll.UseVisualStyleBackColor = true;
            // 
            // rdbMeaning
            // 
            this.rdbMeaning.AccessibleDescription = null;
            this.rdbMeaning.AccessibleName = null;
            resources.ApplyResources(this.rdbMeaning, "rdbMeaning");
            this.rdbMeaning.BackgroundImage = null;
            this.rdbMeaning.Font = null;
            this.rdbMeaning.Name = "rdbMeaning";
            this.rdbMeaning.TabStop = true;
            this.rdbMeaning.UseVisualStyleBackColor = true;
            // 
            // rdbWord
            // 
            this.rdbWord.AccessibleDescription = null;
            this.rdbWord.AccessibleName = null;
            resources.ApplyResources(this.rdbWord, "rdbWord");
            this.rdbWord.BackgroundImage = null;
            this.rdbWord.Checked = true;
            this.rdbWord.Font = null;
            this.rdbWord.Name = "rdbWord";
            this.rdbWord.TabStop = true;
            this.rdbWord.UseVisualStyleBackColor = true;
            // 
            // txbResult
            // 
            this.txbResult.AccessibleDescription = null;
            this.txbResult.AccessibleName = null;
            resources.ApplyResources(this.txbResult, "txbResult");
            this.txbResult.BackgroundImage = null;
            this.txbResult.Name = "txbResult";
            // 
            // progressBar1
            // 
            this.progressBar1.AccessibleDescription = null;
            this.progressBar1.AccessibleName = null;
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.BackgroundImage = null;
            this.progressBar1.Font = null;
            this.progressBar1.Name = "progressBar1";
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleDescription = null;
            this.btnSearch.AccessibleName = null;
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.BackgroundImage = null;
            this.btnSearch.Font = null;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Tag = "";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnStop
            // 
            this.btnStop.AccessibleDescription = null;
            this.btnStop.AccessibleName = null;
            resources.ApplyResources(this.btnStop, "btnStop");
            this.btnStop.BackgroundImage = null;
            this.btnStop.Font = null;
            this.btnStop.Name = "btnStop";
            this.btnStop.Tag = "";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tabControl1
            // 
            this.tabControl1.AccessibleDescription = null;
            this.tabControl1.AccessibleName = null;
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.BackgroundImage = null;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = null;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.AccessibleDescription = null;
            this.tabPage1.AccessibleName = null;
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.BackgroundImage = null;
            this.tabPage1.Controls.Add(this.btnLookup);
            this.tabPage1.Controls.Add(this.txbResult);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtPattern);
            this.tabPage1.Controls.Add(this.progressBar1);
            this.tabPage1.Controls.Add(this.btnStop);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.btnSearch);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Font = null;
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnLookup
            // 
            this.btnLookup.AccessibleDescription = null;
            this.btnLookup.AccessibleName = null;
            resources.ApplyResources(this.btnLookup, "btnLookup");
            this.btnLookup.BackgroundImage = null;
            this.btnLookup.Font = null;
            this.btnLookup.Name = "btnLookup";
            this.btnLookup.UseVisualStyleBackColor = true;
            this.btnLookup.Click += new System.EventHandler(this.btnLookup_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.AccessibleDescription = null;
            this.tabPage2.AccessibleName = null;
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.BackgroundImage = null;
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Font = null;
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.AccessibleDescription = null;
            this.textBox1.AccessibleName = null;
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.BackgroundImage = null;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.AccessibleDescription = null;
            this.panel1.AccessibleName = null;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackgroundImage = null;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.webBrowser1);
            this.panel1.Font = null;
            this.panel1.Name = "panel1";
            // 
            // webBrowser1
            // 
            this.webBrowser1.AccessibleDescription = null;
            this.webBrowser1.AccessibleName = null;
            resources.ApplyResources(this.webBrowser1, "webBrowser1");
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Url = new System.Uri("about:blank", System.UriKind.Absolute);
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // AdvancedSearch
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundImage = null;
            this.Controls.Add(this.tabControl1);
            this.Font = null;
            this.Name = "AdvancedSearch";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.AdvancedSearch_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtPattern;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbRegex;
        private System.Windows.Forms.RadioButton rdbWildcard;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbSearchAll;
        private System.Windows.Forms.RadioButton rdbMeaning;
        private System.Windows.Forms.RadioButton rdbWord;
        private System.Windows.Forms.TextBox txbResult;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnLookup;
        private System.Windows.Forms.RadioButton rdbSimilarWord;
    }
}