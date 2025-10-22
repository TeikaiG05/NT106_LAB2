namespace LAB2
{
    partial class Bai6
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
            this.grpNhap = new System.Windows.Forms.GroupBox();
            this.btXoa = new System.Windows.Forms.Button();
            this.lbQuyenmoi = new System.Windows.Forms.Label();
            this.tbQuyen = new System.Windows.Forms.TextBox();
            this.tbNguoimoi = new System.Windows.Forms.TextBox();
            this.checkNguoimoi = new System.Windows.Forms.CheckBox();
            this.cbNguoidonggop = new System.Windows.Forms.ComboBox();
            this.btRandom = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btThem = new System.Windows.Forms.Button();
            this.btBrowse = new System.Windows.Forms.Button();
            this.tbAnh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTenmon = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.lvMon = new System.Windows.Forms.ListView();
            this.lbNguoidonggop = new System.Windows.Forms.Label();
            this.pbPic = new System.Windows.Forms.PictureBox();
            this.grpNhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPic)).BeginInit();
            this.SuspendLayout();
            // 
            // grpNhap
            // 
            this.grpNhap.Controls.Add(this.btXoa);
            this.grpNhap.Controls.Add(this.lbQuyenmoi);
            this.grpNhap.Controls.Add(this.tbQuyen);
            this.grpNhap.Controls.Add(this.tbNguoimoi);
            this.grpNhap.Controls.Add(this.checkNguoimoi);
            this.grpNhap.Controls.Add(this.cbNguoidonggop);
            this.grpNhap.Controls.Add(this.btRandom);
            this.grpNhap.Controls.Add(this.label3);
            this.grpNhap.Controls.Add(this.btThem);
            this.grpNhap.Controls.Add(this.btBrowse);
            this.grpNhap.Controls.Add(this.tbAnh);
            this.grpNhap.Controls.Add(this.label2);
            this.grpNhap.Controls.Add(this.tbTenmon);
            this.grpNhap.Controls.Add(this.label1);
            this.grpNhap.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpNhap.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpNhap.Location = new System.Drawing.Point(0, 0);
            this.grpNhap.Name = "grpNhap";
            this.grpNhap.Size = new System.Drawing.Size(730, 149);
            this.grpNhap.TabIndex = 0;
            this.grpNhap.TabStop = false;
            this.grpNhap.Text = "Nhập món ăn";
            // 
            // btXoa
            // 
            this.btXoa.Location = new System.Drawing.Point(493, 100);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(108, 34);
            this.btXoa.TabIndex = 12;
            this.btXoa.Text = "Xóa món";
            this.btXoa.UseVisualStyleBackColor = true;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // lbQuyenmoi
            // 
            this.lbQuyenmoi.AutoSize = true;
            this.lbQuyenmoi.Location = new System.Drawing.Point(42, 119);
            this.lbQuyenmoi.Name = "lbQuyenmoi";
            this.lbQuyenmoi.Size = new System.Drawing.Size(82, 16);
            this.lbQuyenmoi.TabIndex = 11;
            this.lbQuyenmoi.Text = "Quyền hạn:";
            // 
            // tbQuyen
            // 
            this.tbQuyen.Location = new System.Drawing.Point(130, 116);
            this.tbQuyen.Name = "tbQuyen";
            this.tbQuyen.Size = new System.Drawing.Size(88, 24);
            this.tbQuyen.TabIndex = 10;
            // 
            // tbNguoimoi
            // 
            this.tbNguoimoi.Location = new System.Drawing.Point(130, 86);
            this.tbNguoimoi.Name = "tbNguoimoi";
            this.tbNguoimoi.Size = new System.Drawing.Size(169, 24);
            this.tbNguoimoi.TabIndex = 9;
            // 
            // checkNguoimoi
            // 
            this.checkNguoimoi.AutoSize = true;
            this.checkNguoimoi.Location = new System.Drawing.Point(130, 63);
            this.checkNguoimoi.Name = "checkNguoimoi";
            this.checkNguoimoi.Size = new System.Drawing.Size(165, 20);
            this.checkNguoimoi.TabIndex = 1;
            this.checkNguoimoi.Text = "Người đóng góp mới?";
            this.checkNguoimoi.UseVisualStyleBackColor = true;
            // 
            // cbNguoidonggop
            // 
            this.cbNguoidonggop.FormattingEnabled = true;
            this.cbNguoidonggop.Location = new System.Drawing.Point(130, 86);
            this.cbNguoidonggop.Name = "cbNguoidonggop";
            this.cbNguoidonggop.Size = new System.Drawing.Size(169, 24);
            this.cbNguoidonggop.TabIndex = 8;
            // 
            // btRandom
            // 
            this.btRandom.Location = new System.Drawing.Point(607, 100);
            this.btRandom.Name = "btRandom";
            this.btRandom.Size = new System.Drawing.Size(108, 34);
            this.btRandom.TabIndex = 7;
            this.btRandom.Text = "Random";
            this.btRandom.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Người đóng góp:";
            // 
            // btThem
            // 
            this.btThem.Location = new System.Drawing.Point(379, 100);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(108, 34);
            this.btThem.TabIndex = 4;
            this.btThem.Text = "Thêm";
            this.btThem.UseVisualStyleBackColor = true;
            // 
            // btBrowse
            // 
            this.btBrowse.Location = new System.Drawing.Point(666, 44);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.Size = new System.Drawing.Size(31, 27);
            this.btBrowse.TabIndex = 1;
            this.btBrowse.Text = "...";
            this.btBrowse.UseVisualStyleBackColor = true;
            // 
            // tbAnh
            // 
            this.tbAnh.Location = new System.Drawing.Point(473, 46);
            this.tbAnh.Name = "tbAnh";
            this.tbAnh.Size = new System.Drawing.Size(169, 24);
            this.tbAnh.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(430, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ảnh:";
            // 
            // tbTenmon
            // 
            this.tbTenmon.Location = new System.Drawing.Point(130, 31);
            this.tbTenmon.Name = "tbTenmon";
            this.tbTenmon.Size = new System.Drawing.Size(169, 24);
            this.tbTenmon.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nhập tên món:";
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 149);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.lvMon);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.lbNguoidonggop);
            this.splitMain.Panel2.Controls.Add(this.pbPic);
            this.splitMain.Size = new System.Drawing.Size(730, 301);
            this.splitMain.SplitterDistance = 243;
            this.splitMain.TabIndex = 8;
            // 
            // lvMon
            // 
            this.lvMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvMon.FullRowSelect = true;
            this.lvMon.HideSelection = false;
            this.lvMon.Location = new System.Drawing.Point(0, 0);
            this.lvMon.MultiSelect = false;
            this.lvMon.Name = "lvMon";
            this.lvMon.Size = new System.Drawing.Size(243, 301);
            this.lvMon.TabIndex = 0;
            this.lvMon.UseCompatibleStateImageBehavior = false;
            this.lvMon.View = System.Windows.Forms.View.Details;
            // 
            // lbNguoidonggop
            // 
            this.lbNguoidonggop.AutoSize = true;
            this.lbNguoidonggop.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNguoidonggop.Location = new System.Drawing.Point(3, 279);
            this.lbNguoidonggop.Name = "lbNguoidonggop";
            this.lbNguoidonggop.Size = new System.Drawing.Size(115, 16);
            this.lbNguoidonggop.TabIndex = 2;
            this.lbNguoidonggop.Text = "Người đóng góp:";
            // 
            // pbPic
            // 
            this.pbPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPic.Location = new System.Drawing.Point(0, 0);
            this.pbPic.Name = "pbPic";
            this.pbPic.Size = new System.Drawing.Size(483, 301);
            this.pbPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPic.TabIndex = 1;
            this.pbPic.TabStop = false;
            // 
            // Bai6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 450);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.grpNhap);
            this.Name = "Bai6";
            this.Text = "Bài 06 - Hôm nay ăn gì? (phiên bản số 2)";
            this.Load += new System.EventHandler(this.Bai6_Load);
            this.grpNhap.ResumeLayout(false);
            this.grpNhap.PerformLayout();
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            this.splitMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpNhap;
        private System.Windows.Forms.Button btBrowse;
        private System.Windows.Forms.TextBox tbAnh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTenmon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.Button btRandom;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.ListView lvMon;
        private System.Windows.Forms.PictureBox pbPic;
        private System.Windows.Forms.Label lbNguoidonggop;
        private System.Windows.Forms.ComboBox cbNguoidonggop;
        private System.Windows.Forms.CheckBox checkNguoimoi;
        private System.Windows.Forms.TextBox tbNguoimoi;
        private System.Windows.Forms.Label lbQuyenmoi;
        private System.Windows.Forms.TextBox tbQuyen;
        private System.Windows.Forms.Button btXoa;
    }
}