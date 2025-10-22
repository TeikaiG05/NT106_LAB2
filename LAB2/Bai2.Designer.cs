namespace LAB2
{
    partial class Bai2
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
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.btRead = new System.Windows.Forms.Button();
            this.tbfileName = new System.Windows.Forms.TextBox();
            this.tbSize = new System.Windows.Forms.TextBox();
            this.tbURL = new System.Windows.Forms.TextBox();
            this.tblineCount = new System.Windows.Forms.TextBox();
            this.tbwordCount = new System.Windows.Forms.TextBox();
            this.tbcharacterCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtbOutput
            // 
            this.rtbOutput.Location = new System.Drawing.Point(330, 59);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.Size = new System.Drawing.Size(274, 404);
            this.rtbOutput.TabIndex = 0;
            this.rtbOutput.Text = "";
            // 
            // btRead
            // 
            this.btRead.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRead.Location = new System.Drawing.Point(84, 59);
            this.btRead.Name = "btRead";
            this.btRead.Size = new System.Drawing.Size(143, 34);
            this.btRead.TabIndex = 1;
            this.btRead.Text = "Read from File";
            this.btRead.UseVisualStyleBackColor = true;
            this.btRead.Click += new System.EventHandler(this.btRead_Click);
            // 
            // tbfileName
            // 
            this.tbfileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbfileName.Location = new System.Drawing.Point(124, 169);
            this.tbfileName.Name = "tbfileName";
            this.tbfileName.Size = new System.Drawing.Size(171, 20);
            this.tbfileName.TabIndex = 2;
            // 
            // tbSize
            // 
            this.tbSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSize.Location = new System.Drawing.Point(124, 223);
            this.tbSize.Name = "tbSize";
            this.tbSize.Size = new System.Drawing.Size(171, 20);
            this.tbSize.TabIndex = 3;
            // 
            // tbURL
            // 
            this.tbURL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbURL.Location = new System.Drawing.Point(124, 277);
            this.tbURL.Name = "tbURL";
            this.tbURL.Size = new System.Drawing.Size(171, 20);
            this.tbURL.TabIndex = 4;
            // 
            // tblineCount
            // 
            this.tblineCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tblineCount.Location = new System.Drawing.Point(124, 331);
            this.tblineCount.Name = "tblineCount";
            this.tblineCount.Size = new System.Drawing.Size(171, 20);
            this.tblineCount.TabIndex = 5;
            // 
            // tbwordCount
            // 
            this.tbwordCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbwordCount.Location = new System.Drawing.Point(124, 385);
            this.tbwordCount.Name = "tbwordCount";
            this.tbwordCount.Size = new System.Drawing.Size(171, 20);
            this.tbwordCount.TabIndex = 6;
            // 
            // tbcharacterCount
            // 
            this.tbcharacterCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbcharacterCount.Location = new System.Drawing.Point(124, 439);
            this.tbcharacterCount.Name = "tbcharacterCount";
            this.tbcharacterCount.Size = new System.Drawing.Size(171, 20);
            this.tbcharacterCount.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "File name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Size:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 279);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "URL:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 333);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Line count:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 387);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Word count:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 441);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Character count:";
            // 
            // Bai2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 510);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbcharacterCount);
            this.Controls.Add(this.tbwordCount);
            this.Controls.Add(this.tblineCount);
            this.Controls.Add(this.tbURL);
            this.Controls.Add(this.tbSize);
            this.Controls.Add(this.tbfileName);
            this.Controls.Add(this.btRead);
            this.Controls.Add(this.rtbOutput);
            this.Name = "Bai2";
            this.Text = "Bài 02 – Đọc thông tin một file .txt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.Button btRead;
        private System.Windows.Forms.TextBox tbfileName;
        private System.Windows.Forms.TextBox tbSize;
        private System.Windows.Forms.TextBox tbURL;
        private System.Windows.Forms.TextBox tblineCount;
        private System.Windows.Forms.TextBox tbwordCount;
        private System.Windows.Forms.TextBox tbcharacterCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}