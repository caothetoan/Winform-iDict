namespace iDict
{
    partial class ConvertToPlainText
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConvertToPlainText));
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.btnConvert = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblProcess = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(88, 286);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(330, 17);
            this.progressBar2.TabIndex = 7;
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(12, 160);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(70, 28);
            this.btnConvert.TabIndex = 6;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnCheckWord2_Click);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Window;
            this.textBox2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBox2.Location = new System.Drawing.Point(88, 12);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(330, 258);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = resources.GetString("textBox2.Text");
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(12, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(70, 26);
            this.btnOpen.TabIndex = 4;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "File iDict *.idt|*.idt";
            // 
            // lblProcess
            // 
            this.lblProcess.Location = new System.Drawing.Point(12, 286);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(52, 25);
            this.lblProcess.TabIndex = 8;
            this.lblProcess.Text = "Process";
            this.lblProcess.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 242);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 28);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ConvertToPlainText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(435, 324);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblProcess);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btnOpen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConvertToPlainText";
            this.ShowInTaskbar = false;
            this.Text = "Convert To Plain Text Data";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblProcess;
        private System.Windows.Forms.Button btnCancel;
    }
}