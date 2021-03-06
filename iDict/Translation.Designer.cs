namespace iDict
{
    partial class Translation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Translation));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnLookup = new System.Windows.Forms.Button();
            this.lstDict = new System.Windows.Forms.ListBox();
            this.btnTranslation = new System.Windows.Forms.Button();
            this.txbParagraph = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.AccessibleDescription = null;
            this.splitContainer1.AccessibleName = null;
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.BackgroundImage = null;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Font = null;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AccessibleDescription = null;
            this.splitContainer1.Panel1.AccessibleName = null;
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            this.splitContainer1.Panel1.BackgroundImage = null;
            this.splitContainer1.Panel1.Controls.Add(this.btnLookup);
            this.splitContainer1.Panel1.Controls.Add(this.lstDict);
            this.splitContainer1.Panel1.Controls.Add(this.btnTranslation);
            this.splitContainer1.Panel1.Controls.Add(this.txbParagraph);
            this.splitContainer1.Panel1.Font = null;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AccessibleDescription = null;
            this.splitContainer1.Panel2.AccessibleName = null;
            resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
            this.splitContainer1.Panel2.BackgroundImage = null;
            this.splitContainer1.Panel2.Controls.Add(this.listBox1);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Font = null;
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
            // lstDict
            // 
            this.lstDict.AccessibleDescription = null;
            this.lstDict.AccessibleName = null;
            resources.ApplyResources(this.lstDict, "lstDict");
            this.lstDict.BackgroundImage = null;
            this.lstDict.Font = null;
            this.lstDict.FormattingEnabled = true;
            this.lstDict.Name = "lstDict";
            // 
            // btnTranslation
            // 
            this.btnTranslation.AccessibleDescription = null;
            this.btnTranslation.AccessibleName = null;
            resources.ApplyResources(this.btnTranslation, "btnTranslation");
            this.btnTranslation.BackgroundImage = null;
            this.btnTranslation.Font = null;
            this.btnTranslation.Name = "btnTranslation";
            this.btnTranslation.UseVisualStyleBackColor = true;
            this.btnTranslation.Click += new System.EventHandler(this.btnTranslation_Click);
            // 
            // txbParagraph
            // 
            this.txbParagraph.AccessibleDescription = null;
            this.txbParagraph.AccessibleName = null;
            resources.ApplyResources(this.txbParagraph, "txbParagraph");
            this.txbParagraph.BackgroundImage = null;
            this.txbParagraph.Name = "txbParagraph";
            // 
            // listBox1
            // 
            this.listBox1.AccessibleDescription = null;
            this.listBox1.AccessibleName = null;
            resources.ApplyResources(this.listBox1, "listBox1");
            this.listBox1.BackgroundImage = null;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Name = "listBox1";
            this.listBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseClick);
            this.listBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyDown);
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
            // Translation
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundImage = null;
            this.Controls.Add(this.splitContainer1);
            this.Font = null;
            this.Name = "Translation";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txbParagraph;
        private System.Windows.Forms.Button btnTranslation;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox lstDict;
        private System.Windows.Forms.Button btnLookup;

    }
}