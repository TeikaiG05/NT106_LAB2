namespace LAB2
{
    partial class Bai3
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
            this.btghiFile = new System.Windows.Forms.Button();
            this.btdocFile = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btghiFile
            // 
            this.btghiFile.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btghiFile.Location = new System.Drawing.Point(32, 109);
            this.btghiFile.Name = "btghiFile";
            this.btghiFile.Size = new System.Drawing.Size(109, 46);
            this.btghiFile.TabIndex = 5;
            this.btghiFile.Text = "TÍNH TOÁN VÀ GHI FILE";
            this.btghiFile.UseVisualStyleBackColor = true;
            this.btghiFile.Click += new System.EventHandler(this.btghiFile_Click);
            // 
            // btdocFile
            // 
            this.btdocFile.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btdocFile.Location = new System.Drawing.Point(32, 45);
            this.btdocFile.Name = "btdocFile";
            this.btdocFile.Size = new System.Drawing.Size(109, 46);
            this.btdocFile.TabIndex = 4;
            this.btdocFile.Text = "ĐỌC FILE";
            this.btdocFile.UseVisualStyleBackColor = true;
            this.btdocFile.Click += new System.EventHandler(this.btdocFile_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(186, 45);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(293, 339);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // Bai3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 416);
            this.Controls.Add(this.btghiFile);
            this.Controls.Add(this.btdocFile);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Bai3";
            this.Text = "Bài 03 - Đọc và Ghi file và tính toán ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btghiFile;
        private System.Windows.Forms.Button btdocFile;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}