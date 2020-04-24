namespace NoCropSquareBuck
{
    partial class Form1
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
            this.btnDst = new System.Windows.Forms.Button();
            this.btnSrc = new System.Windows.Forms.Button();
            this.lblSrc = new System.Windows.Forms.Label();
            this.lblDst = new System.Windows.Forms.Label();
            this.btnNoCrop = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnBackColor = new System.Windows.Forms.Button();
            this.lblBackColor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDst
            // 
            this.btnDst.Location = new System.Drawing.Point(12, 12);
            this.btnDst.Name = "btnDst";
            this.btnDst.Size = new System.Drawing.Size(75, 23);
            this.btnDst.TabIndex = 0;
            this.btnDst.Text = "Source";
            this.btnDst.UseVisualStyleBackColor = true;
            this.btnDst.Click += new System.EventHandler(this.btnSrc_Click);
            // 
            // btnSrc
            // 
            this.btnSrc.Location = new System.Drawing.Point(12, 41);
            this.btnSrc.Name = "btnSrc";
            this.btnSrc.Size = new System.Drawing.Size(75, 23);
            this.btnSrc.TabIndex = 1;
            this.btnSrc.Text = "Destination";
            this.btnSrc.UseVisualStyleBackColor = true;
            this.btnSrc.Click += new System.EventHandler(this.btnDst_Click);
            // 
            // lblSrc
            // 
            this.lblSrc.AutoSize = true;
            this.lblSrc.Location = new System.Drawing.Point(93, 17);
            this.lblSrc.Name = "lblSrc";
            this.lblSrc.Size = new System.Drawing.Size(35, 13);
            this.lblSrc.TabIndex = 2;
            this.lblSrc.Text = "lblSrc";
            // 
            // lblDst
            // 
            this.lblDst.AutoSize = true;
            this.lblDst.Location = new System.Drawing.Point(93, 46);
            this.lblDst.Name = "lblDst";
            this.lblDst.Size = new System.Drawing.Size(35, 13);
            this.lblDst.TabIndex = 3;
            this.lblDst.Text = "lblDst";
            // 
            // btnNoCrop
            // 
            this.btnNoCrop.Location = new System.Drawing.Point(12, 70);
            this.btnNoCrop.Name = "btnNoCrop";
            this.btnNoCrop.Size = new System.Drawing.Size(390, 23);
            this.btnNoCrop.TabIndex = 4;
            this.btnNoCrop.Text = "Perform No Croping";
            this.btnNoCrop.UseVisualStyleBackColor = true;
            this.btnNoCrop.Click += new System.EventHandler(this.btnNoCrop_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 98);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(390, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // btnBackColor
            // 
            this.btnBackColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackColor.Location = new System.Drawing.Point(327, 12);
            this.btnBackColor.Name = "btnBackColor";
            this.btnBackColor.Size = new System.Drawing.Size(75, 23);
            this.btnBackColor.TabIndex = 6;
            this.btnBackColor.Text = "BackColor";
            this.btnBackColor.UseVisualStyleBackColor = true;
            this.btnBackColor.Click += new System.EventHandler(this.btnBackColor_Click);
            // 
            // lblBackColor
            // 
            this.lblBackColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBackColor.AutoSize = true;
            this.lblBackColor.Location = new System.Drawing.Point(273, 17);
            this.lblBackColor.Name = "lblBackColor";
            this.lblBackColor.Size = new System.Drawing.Size(35, 13);
            this.lblBackColor.TabIndex = 7;
            this.lblBackColor.Text = "White";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 127);
            this.Controls.Add(this.lblBackColor);
            this.Controls.Add(this.btnBackColor);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnNoCrop);
            this.Controls.Add(this.lblDst);
            this.Controls.Add(this.lblSrc);
            this.Controls.Add(this.btnSrc);
            this.Controls.Add(this.btnDst);
            this.Name = "Form1";
            this.Text = "Buck Squarify";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDst;
        private System.Windows.Forms.Button btnSrc;
        private System.Windows.Forms.Label lblSrc;
        private System.Windows.Forms.Label lblDst;
        private System.Windows.Forms.Button btnNoCrop;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnBackColor;
        private System.Windows.Forms.Label lblBackColor;
    }
}

