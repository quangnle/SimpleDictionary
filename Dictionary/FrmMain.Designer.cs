namespace Dictionary
{
    partial class FrmMain
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
            this.lblSource = new System.Windows.Forms.Label();
            this.lblPhonetic = new System.Windows.Forms.Label();
            this.txtMean = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSource.Location = new System.Drawing.Point(12, 9);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(48, 17);
            this.lblSource.TabIndex = 0;
            this.lblSource.Text = "source";
            // 
            // lblPhonetic
            // 
            this.lblPhonetic.AutoSize = true;
            this.lblPhonetic.Font = new System.Drawing.Font("Calibri", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhonetic.Location = new System.Drawing.Point(12, 26);
            this.lblPhonetic.Name = "lblPhonetic";
            this.lblPhonetic.Size = new System.Drawing.Size(46, 17);
            this.lblPhonetic.TabIndex = 1;
            this.lblPhonetic.Text = "source";
            // 
            // txtMean
            // 
            this.txtMean.Location = new System.Drawing.Point(13, 47);
            this.txtMean.Multiline = true;
            this.txtMean.Name = "txtMean";
            this.txtMean.ReadOnly = true;
            this.txtMean.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMean.Size = new System.Drawing.Size(502, 100);
            this.txtMean.TabIndex = 2;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 159);
            this.Controls.Add(this.txtMean);
            this.Controls.Add(this.lblPhonetic);
            this.Controls.Add(this.lblSource);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(543, 198);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(543, 198);
            this.Name = "FrmMain";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Translating";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblPhonetic;
        private System.Windows.Forms.TextBox txtMean;
    }
}

