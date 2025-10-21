namespace LAB2
{
    partial class Bai1
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btdocFile = new System.Windows.Forms.Button();
            this.btghiFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(183, 35);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(293, 339);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // btdocFile
            // 
            this.btdocFile.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btdocFile.Location = new System.Drawing.Point(29, 35);
            this.btdocFile.Name = "btdocFile";
            this.btdocFile.Size = new System.Drawing.Size(109, 46);
            this.btdocFile.TabIndex = 1;
            this.btdocFile.Text = "ĐỌC FILE";
            this.btdocFile.UseVisualStyleBackColor = true;
            this.btdocFile.Click += new System.EventHandler(this.btdocFile_Click);
            // 
            // btghiFile
            // 
            this.btghiFile.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btghiFile.Location = new System.Drawing.Point(29, 99);
            this.btghiFile.Name = "btghiFile";
            this.btghiFile.Size = new System.Drawing.Size(109, 46);
            this.btghiFile.TabIndex = 2;
            this.btghiFile.Text = "GHI FILE";
            this.btghiFile.UseVisualStyleBackColor = true;
            this.btghiFile.Click += new System.EventHandler(this.btghiFile_Click);
            // 
            // Bai1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 396);
            this.Controls.Add(this.btghiFile);
            this.Controls.Add(this.btdocFile);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Bai1";
            this.Text = "Bài 01 – Ghi và Đọc file";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btdocFile;
        private System.Windows.Forms.Button btghiFile;
    }
}