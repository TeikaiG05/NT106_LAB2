using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LAB2
{
    public partial class Bai6 : Form
    {
        public Bai6()
        {
            InitializeComponent();

            lvMon.View = View.Details;
            lvMon.FullRowSelect = true;
            lvMon.HideSelection = false;
            if (lvMon.Columns.Count == 0)
            {
                lvMon.Columns.Add("Tên món", 100);
                lvMon.Columns.Add("Người đóng góp", 100);
            }          
            lvMon.SelectedIndexChanged += LvMon_SelectedIndexChanged;
            btXoa.Enabled = false;
            this.Load += Bai6_Load;
            this.Load += (s, e) =>
            {
                SqliteDb.EnsureCreatedAndSeed();
                LoadContributors();
                checkNguoimoi.Checked = false;
                UpdateContributorMode(false);
                if (cbNguoidonggop.Items.Count > 0)
                    cbNguoidonggop.SelectedIndex = 0;
                LoadListView();
            };

            btBrowse.Click += (s, e) => BrowseImage();
            btThem.Click += (s, e) => AddDish();
            btRandom.Click += (s, e) => PickRandom();
            lvMon.SelectedIndexChanged += (s, e) => ShowSelectedPreview();

            checkNguoimoi.CheckedChanged += (s, e) =>
            {
                bool addNew = checkNguoimoi.Checked;
                UpdateContributorMode(addNew);
                if (!addNew) { tbNguoimoi.Clear(); tbQuyen.Clear(); }
            };
        }
        private void UpdateContributorMode(bool addNew)
        {
            lbQuyenmoi.Visible = addNew;
            tbQuyen.Visible = addNew;
            tbNguoimoi.Visible = addNew;

            cbNguoidonggop.Visible = !addNew;
            cbNguoidonggop.Enabled = !addNew;

            if (addNew) tbNguoimoi.Focus();
        }
        private void LoadContributors()
        {
            var dt = SqliteDb.GetNguoiDung();
            cbNguoidonggop.DataSource = dt;
            cbNguoidonggop.DisplayMember = "HoVaTen";
            cbNguoidonggop.ValueMember = "IDNCC";
        }

        private void LoadListView()
        {
            lvMon.BeginUpdate();
            lvMon.Items.Clear();

            var dt = SqliteDb.GetMonAnWithNguoi();
            foreach (DataRow r in dt.Rows)
            {
                var it = new ListViewItem(r["TenMonAn"].ToString());
                it.SubItems.Add(r["HoVaTen"].ToString());
                it.Tag = r;
                lvMon.Items.Add(it);
            }

            lvMon.EndUpdate();
        }
        private void BrowseImage()
        {
            using (var ofd = new OpenFileDialog
            {
                Title = "Chọn ảnh món ăn",
                Filter = "Ảnh|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.webp|Tất cả|*.*"
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                    tbAnh.Text = ofd.FileName;
            }
        }

        private void AddDish()
        {
            var ten = tbTenmon.Text.Trim();
            if (string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Vui lòng nhập tên món.", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbTenmon.Focus();
                return;
            }

            int idncc = 0;

            if (checkNguoimoi.Checked)
            {
                var tenMoi = tbNguoimoi.Text.Trim();
                var quyen = string.IsNullOrWhiteSpace(tbQuyen.Text) ? null : tbQuyen.Text.Trim();

                if (string.IsNullOrEmpty(tenMoi))
                {
                    MessageBox.Show("Vui lòng nhập tên người đóng góp mới.", "Thiếu dữ liệu",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbNguoimoi.Focus();
                    return;
                }

                idncc = SqliteDb.GetOrCreateNguoiDungByName(tenMoi, quyen);

                LoadContributors();
                cbNguoidonggop.SelectedValue = idncc;
                checkNguoimoi.Checked = false;
                UpdateContributorMode(false);
                tbNguoimoi.Clear();
                tbQuyen.Clear();
            }
            else
            {
                if (cbNguoidonggop.SelectedValue == null || cbNguoidonggop.SelectedIndex < 0)
                {
                    MessageBox.Show("Vui lòng chọn người đóng góp.", "Thiếu dữ liệu",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbNguoidonggop.DroppedDown = true;
                    return;
                }
                idncc = Convert.ToInt32(cbNguoidonggop.SelectedValue);
            }

            var imgPath = string.IsNullOrWhiteSpace(tbAnh.Text) ? null : tbAnh.Text.Trim();

            SqliteDb.InsertMonAn(ten, imgPath, idncc);

            tbTenmon.Clear();
            tbAnh.Clear();
            LoadListView();
        }

        private void ShowSelectedPreview()
        {
            if (lvMon.SelectedItems.Count == 0)
            {
                lbNguoidonggop.Text = "Người đóng góp:";
                pbPic.Image?.Dispose();
                pbPic.Image = null;
                return;
            }

            var row = lvMon.SelectedItems[0].Tag as DataRow;
            if (row == null) return;

            lbNguoidonggop.Text = "Người đóng góp: " + row["HoVaTen"].ToString();

            var path = row["HinhAnh"]?.ToString();
            pbPic.Image?.Dispose();
            pbPic.Image = null;

            if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
            {
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var img = Image.FromStream(fs))
                {
                    pbPic.Image = (Image)img.Clone();
                }
            }
        }
        private void PickRandom()
        {
            var row = SqliteDb.GetRandomDish();
            if (row == null)
            {
                MessageBox.Show("Chưa có món ăn trong CSDL.");
                return;
            }

            lbNguoidonggop.Text = "Người đóng góp: " + row["HoVaTen"].ToString();

            var path = row["HinhAnh"]?.ToString();
            pbPic.Image?.Dispose();
            pbPic.Image = null;
            if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
            {
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var img = Image.FromStream(fs))
                {
                    pbPic.Image = (Image)img.Clone();
                }
            }
            foreach (ListViewItem it in lvMon.Items)
            {
                var r = it.Tag as DataRow;
                bool match = r != null &&
                             r["TenMonAn"].ToString() == row["TenMonAn"].ToString() &&
                             r["HoVaTen"].ToString() == row["HoVaTen"].ToString();
                it.Selected = match;
                if (match) it.EnsureVisible();
            }
        }
        private void DeleteSelectedDish()
        {
            if (lvMon.SelectedItems.Count == 0)
            {
                MessageBox.Show("Hãy chọn một món để xoá."); return;
            }

            var item = lvMon.SelectedItems[0];
            var row = item.Tag as DataRow;
            if (row == null) { MessageBox.Show("Không lấy được thông tin món."); return; }

            int idma = Convert.ToInt32(row["IDMA"]);
            string ten = Convert.ToString(row["TenMonAn"]);

            if (MessageBox.Show($"Xoá món \"{ten}\"?", "Xác nhận xoá",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            int affected = SqliteDb.DeleteMonAnById(idma);
            if (affected > 0)
            {
                pbPic.Image?.Dispose(); pbPic.Image = null;
                lbNguoidonggop.Text = "Người đóng góp:";
                LoadListView();
            }
            else MessageBox.Show("Không xoá được món.");
        }
        private void ReloadAll()
        {
            var dtNguoi = SqliteDb.GetNguoiDung();
            cbNguoidonggop.DataSource = null;
            cbNguoidonggop.DisplayMember = "HoVaTen";
            cbNguoidonggop.ValueMember = "IDNCC";
            cbNguoidonggop.DataSource = dtNguoi;
            if (cbNguoidonggop.Items.Count > 0) cbNguoidonggop.SelectedIndex = 0;
            lvMon.BeginUpdate();
            lvMon.Items.Clear();
            var dtMon = SqliteDb.GetMonAnWithNguoi();
            foreach (DataRow r in dtMon.Rows)
            {
                var it = new ListViewItem(r["TenMonAn"].ToString());
                it.SubItems.Add(r["HoVaTen"].ToString());
                it.Tag = r;                        
                lvMon.Items.Add(it);
            }
            lvMon.EndUpdate();
            pbPic.Image?.Dispose(); pbPic.Image = null;
            lbNguoidonggop.Text = "Người đóng góp:";
            btXoa.Enabled = false;
        }
        private void Bai6_Load(object sender, EventArgs e)
        {
            cbNguoidonggop.DropDownStyle = ComboBoxStyle.DropDownList;
            //var removed = SqliteDb.DeleteMonAnByName("bunbo");
            //if (removed > 0) LoadListView();
                SqliteDb.EnsureCreatedAndSeed(); 
                ReloadAll();
        }   
        private void LvMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            btXoa.Enabled = lvMon.SelectedItems.Count > 0;
        }
        private void btXoa_Click(object sender, EventArgs e)
        {
            DeleteSelectedDish();
        }
    }
}
