namespace iDict
{
    partial class MiniDict
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MiniDict));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbbVoice = new System.Windows.Forms.ComboBox();
            this.btnPronounce = new System.Windows.Forms.Button();
            this.btnShowHide = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnLocation = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.AccessibleDescription = null;
            this.panel1.AccessibleName = null;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackgroundImage = null;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.cbbVoice);
            this.panel1.Controls.Add(this.btnPronounce);
            this.panel1.Controls.Add(this.btnShowHide);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.webBrowser1);
            this.panel1.Font = null;
            this.panel1.Name = "panel1";
            // 
            // cbbVoice
            // 
            this.cbbVoice.AccessibleDescription = null;
            this.cbbVoice.AccessibleName = null;
            resources.ApplyResources(this.cbbVoice, "cbbVoice");
            this.cbbVoice.BackgroundImage = null;
            this.cbbVoice.Font = null;
            this.cbbVoice.FormattingEnabled = true;
            this.cbbVoice.Name = "cbbVoice";
            this.cbbVoice.SelectedIndexChanged += new System.EventHandler(this.cbbVoice_SelectedIndexChanged);
            // 
            // btnPronounce
            // 
            this.btnPronounce.AccessibleDescription = null;
            this.btnPronounce.AccessibleName = null;
            resources.ApplyResources(this.btnPronounce, "btnPronounce");
            this.btnPronounce.BackgroundImage = global::iDict.Properties.Resources.speech;
            this.btnPronounce.Font = null;
            this.btnPronounce.Name = "btnPronounce";
            this.btnPronounce.UseVisualStyleBackColor = true;
            this.btnPronounce.Click += new System.EventHandler(this.btnPronounce_Click);
            // 
            // btnShowHide
            // 
            this.btnShowHide.AccessibleDescription = null;
            this.btnShowHide.AccessibleName = null;
            resources.ApplyResources(this.btnShowHide, "btnShowHide");
            this.btnShowHide.BackgroundImage = null;
            this.btnShowHide.Font = null;
            this.btnShowHide.Name = "btnShowHide";
            this.btnShowHide.UseVisualStyleBackColor = true;
            this.btnShowHide.Click += new System.EventHandler(this.btnShowHide_Click);
            // 
            // listBox1
            // 
            this.listBox1.AccessibleDescription = null;
            this.listBox1.AccessibleName = null;
            resources.ApplyResources(this.listBox1, "listBox1");
            this.listBox1.BackgroundImage = null;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            resources.GetString("listBox1.Items"),
            resources.GetString("listBox1.Items1"),
            resources.GetString("listBox1.Items2"),
            resources.GetString("listBox1.Items3"),
            resources.GetString("listBox1.Items4"),
            resources.GetString("listBox1.Items5"),
            resources.GetString("listBox1.Items6"),
            resources.GetString("listBox1.Items7"),
            resources.GetString("listBox1.Items8"),
            resources.GetString("listBox1.Items9"),
            resources.GetString("listBox1.Items10"),
            resources.GetString("listBox1.Items11"),
            resources.GetString("listBox1.Items12"),
            resources.GetString("listBox1.Items13"),
            resources.GetString("listBox1.Items14")});
            this.listBox1.Name = "listBox1";
            this.listBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseClick);
            this.listBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyDown);
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
            // textBox1
            // 
            this.textBox1.AccessibleDescription = null;
            this.textBox1.AccessibleName = null;
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.BackgroundImage = null;
            this.textBox1.Name = "textBox1";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox1_DragDrop);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // btnLocation
            // 
            this.btnLocation.AccessibleDescription = null;
            this.btnLocation.AccessibleName = null;
            resources.ApplyResources(this.btnLocation, "btnLocation");
            this.btnLocation.BackgroundImage = null;
            this.btnLocation.Font = null;
            this.btnLocation.Name = "btnLocation";
            this.btnLocation.UseVisualStyleBackColor = true;
            this.btnLocation.Click += new System.EventHandler(this.btnLocation_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AccessibleDescription = null;
            this.checkBox1.AccessibleName = null;
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.BackgroundImage = null;
            this.checkBox1.Font = null;
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.AccessibleDescription = null;
            this.trackBar1.AccessibleName = null;
            resources.ApplyResources(this.trackBar1, "trackBar1");
            this.trackBar1.BackgroundImage = null;
            this.trackBar1.Font = null;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Value = 10;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // button1
            // 
            this.button1.AccessibleDescription = null;
            this.button1.AccessibleName = null;
            resources.ApplyResources(this.button1, "button1");
            this.button1.BackgroundImage = null;
            this.button1.Font = null;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AccessibleDescription = null;
            this.checkBox2.AccessibleName = null;
            resources.ApplyResources(this.checkBox2, "checkBox2");
            this.checkBox2.BackgroundImage = null;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Font = null;
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // MiniDict
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = null;
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnLocation);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MiniDict";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Load += new System.EventHandler(this.MiniDict_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MiniDict_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MiniDict_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnShowHide;
        private System.Windows.Forms.Button btnLocation;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox cbbVoice;
        private System.Windows.Forms.Button btnPronounce;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox2;

    }
}