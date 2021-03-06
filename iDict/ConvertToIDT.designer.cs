namespace iDict
{
    partial class ConvertToIDT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConvertToIDT));
            this.label1 = new System.Windows.Forms.Label();
            this.txbAuthor = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label6 = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.cbbVoice = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txbDictName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbbCultureInfo = new System.Windows.Forms.ComboBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblProcess = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "Author:";
            // 
            // txbAuthor
            // 
            this.txbAuthor.Location = new System.Drawing.Point(96, 159);
            this.txbAuthor.Multiline = true;
            this.txbAuthor.Name = "txbAuthor";
            this.txbAuthor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbAuthor.Size = new System.Drawing.Size(327, 185);
            this.txbAuthor.TabIndex = 53;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(96, 350);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(327, 18);
            this.progressBar1.TabIndex = 52;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(93, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(333, 13);
            this.label6.TabIndex = 51;
            this.label6.Text = "The converted database is placed on the same path with dict.tab file.";
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(12, 242);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(71, 23);
            this.btnConvert.TabIndex = 50;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnCheckWord_Click);
            // 
            // cbbVoice
            // 
            this.cbbVoice.FormattingEnabled = true;
            this.cbbVoice.Items.AddRange(new object[] {
            "",
            "4-Adult Female #1 Brazilian Portuguese (L&H)",
            "4-Adult Female #1 Dutch (L&H)",
            "4-Adult Female #1 French (L&H)",
            "4-Adult Female #1 German (L&H)",
            "4-Adult Female #1 Italian (L&H)",
            "4-Adult Female #1 Japanese (L&H)",
            "4-Adult Female #1 Korean (L&H)",
            "4-Adult Female #1 Russian (L&H)",
            "4-Adult Female #1 Spanish (L&H)",
            "4-Adult Male #1 Brazilian Portuguese (L&H)",
            "4-Adult Male #1 Dutch (L&H)",
            "4-Adult Male #1 French (L&H)",
            "4-Adult Male #1 German (L&H)",
            "4-Adult Male #1 Italian (L&H)",
            "4-Adult Male #1 Japanese (L&H)",
            "4-Adult Male #1 Korean (L&H)",
            "4-Adult Male #1 Russian (L&H)",
            "4-Adult Male #1 Spanish (L&H)",
            "4-Female Whisper",
            "4-Male Whisper",
            "4-Mary",
            "4-Mary (for Telephone)",
            "4-Mary in Hall",
            "4-Mary in Space",
            "4-Mary in Stadium",
            "4-Mike",
            "4-Mike (for Telephone)",
            "4-Mike in Hall",
            "4-Mike in Space",
            "4-Mike in Stadium",
            "4-PETRa",
            "4-RoboSoft Five",
            "4-RoboSoft Four",
            "4-RoboSoft One",
            "4-RoboSoft Six",
            "4-RoboSoft Three",
            "4-RoboSoft Two",
            "4-Sam",
            "5-Microsoft Mary",
            "5-Microsoft Mike",
            "5-Microsoft Sam",
            "5-Microsoft Simplified Chinese",
            "5-Minh Du"});
            this.cbbVoice.Location = new System.Drawing.Point(96, 119);
            this.cbbVoice.MaxDropDownItems = 15;
            this.cbbVoice.Name = "cbbVoice";
            this.cbbVoice.Size = new System.Drawing.Size(227, 21);
            this.cbbVoice.TabIndex = 49;
            this.cbbVoice.SelectedIndexChanged += new System.EventHandler(this.cbbVoice_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 48;
            this.label7.Text = "Voice :";
            // 
            // txbDictName
            // 
            this.txbDictName.Location = new System.Drawing.Point(96, 45);
            this.txbDictName.Name = "txbDictName";
            this.txbDictName.Size = new System.Drawing.Size(327, 20);
            this.txbDictName.TabIndex = 47;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 46;
            this.label8.Text = "Dictionary Name";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label9.Location = new System.Drawing.Point(14, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 32);
            this.label9.TabIndex = 45;
            this.label9.Text = "CultureInfo:";
            // 
            // cbbCultureInfo
            // 
            this.cbbCultureInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCultureInfo.FormattingEnabled = true;
            this.cbbCultureInfo.Items.AddRange(new object[] {
            "af-ZA",
            "ar-AE",
            "ar-BH",
            "ar-DZ",
            "ar-EG",
            "ar-IQ",
            "ar-JO",
            "ar-KW",
            "ar-LB",
            "ar-LY",
            "ar-MA",
            "ar-OM",
            "ar-QA",
            "ar-SA",
            "ar-SY",
            "ar-TN",
            "ar-YE",
            "az-AZ-Cyrl",
            "az-AZ-Latn",
            "be-BY",
            "bg-BG",
            "ca-ES",
            "cs-CZ",
            "da-DK",
            "de-AT",
            "de-CH",
            "de-DE",
            "de-LI",
            "de-LU",
            "div-MV",
            "el-GR",
            "en-AU",
            "en-BZ",
            "en-CA",
            "en-CB",
            "en-GB",
            "en-IE",
            "en-JM",
            "en-NZ",
            "en-PH",
            "en-TT",
            "en-US",
            "en-ZA",
            "en-ZW",
            "es-AR",
            "es-BO",
            "es-CL",
            "es-CO",
            "es-CR",
            "es-DO",
            "es-EC",
            "es-ES",
            "es-GT",
            "es-HN",
            "es-MX",
            "es-NI",
            "es-PA",
            "es-PE",
            "es-PR",
            "es-PY",
            "es-SV",
            "es-UY",
            "es-VE",
            "et-EE",
            "eu-ES",
            "fa-IR",
            "fi-FI",
            "fo-FO",
            "fr-BE",
            "fr-CA",
            "fr-CH",
            "fr-FR",
            "fr-LU",
            "fr-MC",
            "gl-ES",
            "gu-IN",
            "he-IL",
            "hi-IN",
            "hr-HR",
            "hu-HU",
            "hy-AM",
            "id-ID",
            "is-IS",
            "it-CH",
            "it-IT",
            "ja-JP",
            "ka-GE",
            "kk-KZ",
            "kn-IN",
            "ko-KR",
            "kok-IN",
            "ky-KG",
            "lt-LT",
            "lv-LV",
            "mk-MK",
            "mn-MN",
            "mr-IN",
            "ms-BN",
            "ms-MY",
            "nb-NO",
            "nl-BE",
            "nl-NL",
            "nn-NO",
            "pa-IN",
            "pl-PL",
            "pt-BR",
            "pt-PT",
            "ro-RO",
            "ru-RU",
            "sa-IN",
            "sk-SK",
            "sl-SI",
            "sq-AL",
            "sr-SP-Cyrl",
            "sr-SP-Latn",
            "sv-FI",
            "sv-SE",
            "sw-KE",
            "syr-SY",
            "ta-IN",
            "te-IN",
            "th-TH",
            "tr-TR",
            "tt-RU",
            "uk-UA",
            "ur-PK",
            "uz-Cyrl-UZ",
            "uz-Latn-UZ",
            "vi-VN",
            "zh-CHS",
            "zh-CHT",
            "zh-CN",
            "zh-HK",
            "zh-MO",
            "zh-SG",
            "zh-TW"});
            this.cbbCultureInfo.Location = new System.Drawing.Point(96, 80);
            this.cbbCultureInfo.MaxDropDownItems = 15;
            this.cbbCultureInfo.Name = "cbbCultureInfo";
            this.cbbCultureInfo.Size = new System.Drawing.Size(155, 21);
            this.cbbCultureInfo.TabIndex = 44;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(9, 17);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(74, 23);
            this.btnOpen.TabIndex = 43;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Plaintext *.txt|*.txt";
            // 
            // lblProcess
            // 
            this.lblProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblProcess.Location = new System.Drawing.Point(6, 345);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(74, 23);
            this.lblProcess.TabIndex = 55;
            this.lblProcess.Text = "Process";
            this.lblProcess.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(15, 306);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(68, 23);
            this.btnCancel.TabIndex = 56;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ConvertToIDT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(437, 382);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblProcess);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbAuthor);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.cbbVoice);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txbDictName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbbCultureInfo);
            this.Controls.Add(this.btnOpen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConvertToIDT";
            this.ShowInTaskbar = false;
            this.Text = "Convert to iDict Data";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbAuthor;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.ComboBox cbbVoice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbDictName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbbCultureInfo;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblProcess;
        private System.Windows.Forms.Button btnCancel;
    }
}