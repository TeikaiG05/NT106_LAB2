using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB2
{
    public partial class Bai5 : Form
    {
        public Bai5()
        {
            InitializeComponent();
        }
        private List<(int Room, string Seat)> veDaChon = new List<(int, string)>();
        private HashSet<(int Room, string Seat)> gheDaBan = new HashSet<(int Room, string Seat)>();
        Dictionary<string, (int GiaChuan, List<int> PhongChieu)> phimDict = new Dictionary<string, (int, List<int>)>(StringComparer.OrdinalIgnoreCase);
        Dictionary<string, string> gheDict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<string, Dictionary<int, HashSet<string>>> daBanTheoPhim = new Dictionary<string, Dictionary<int, HashSet<string>>>(StringComparer.OrdinalIgnoreCase);
        private static readonly string[] ALL_SEATS = new[] {"A1","A2","A3","A4","A5","B1","B2","B3","B4","B5","C1","C2","C3","C4","C5"};
        private void LoadMoviesFromFile(string path)
        {
            phimDict.Clear();
            gheDict.Clear();

            if (!File.Exists(path)) throw new FileNotFoundException("Không tìm thấy file cấu hình phim.", path);

            var lines = File.ReadAllLines(path, Encoding.UTF8).Select(l => l.Trim()).ToList();

            int i = 0;
            while (i < lines.Count)
            {
                while (i < lines.Count && string.IsNullOrWhiteSpace(lines[i])) i++;
                if (i >= lines.Count || string.Equals(lines[i], "[SEATS]", StringComparison.OrdinalIgnoreCase))
                    break;

                string ten = lines[i++];                        
                if (i >= lines.Count) throw new FormatException("Thiếu giá vé chuẩn.");
                if (!int.TryParse(lines[i++], out int gia))   
                    throw new FormatException($"Giá không hợp lệ cho phim '{ten}'.");

                if (i >= lines.Count) throw new FormatException("Thiếu danh sách phòng chiếu.");
                string phongLine = lines[i++];                
                var phong = phongLine.Split(',').Select(s => s.Trim()).Where(s => s.Length > 0).Select(int.Parse).ToList();
                if (phong.Count == 0)
                    throw new FormatException($"Phim '{ten}' chưa có phòng chiếu.");
                phimDict[ten] = (gia, phong);
            }
            if (i < lines.Count && string.Equals(lines[i], "[SEATS]", StringComparison.OrdinalIgnoreCase))
            {
                i++;
                var allowed = new HashSet<string>(new[] { "vot", "thuong", "vip" }, StringComparer.OrdinalIgnoreCase);

                while (i < lines.Count)
                {
                    string line = lines[i++];
                    if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#")) continue;

                    var kv = line.Split(new[] { '=' }, 2);
                    if (kv.Length != 2) continue;

                    string seat = kv[0].Trim();
                    string type = kv[1].Trim().ToLowerInvariant();

                    if (seat.Length == 0 || !allowed.Contains(type)) continue;
                    gheDict[seat] = type;
                }
            }
            if (gheDict.Count == 0)
            {
                gheDict["A1"] = "vot"; gheDict["A5"] = "vot"; gheDict["C1"] = "vot"; gheDict["C5"] = "vot";
                gheDict["A2"] = "thuong"; gheDict["A3"] = "thuong"; gheDict["A4"] = "thuong";
                gheDict["C2"] = "thuong"; gheDict["C3"] = "thuong"; gheDict["C4"] = "thuong";
                gheDict["B2"] = "vip"; gheDict["B3"] = "vip"; gheDict["B4"] = "vip";
            }
        }
        private int TinhGiaVe(int giaChuan, string ghe)
        {
            string loai = gheDict.ContainsKey(ghe) ? gheDict[ghe] : "thuong";
            switch (loai)
            {
                case "vot": return giaChuan / 4;
                case "vip": return giaChuan * 2;
                default: return giaChuan;
            }
        }
        private void ExportThongKe(string outPath)
        {
            // Tính doanh thu cho từng phim
            var listKq = new List<(string Ten, long SoBan, long SoTon, double TyLe, long DoanhThu)>();

            foreach (var kv in phimDict) // kv.Key=ten phim, kv.Value=(GiaChuan, PhongChieu)
            {
                string tenPhim = kv.Key;
                int giaChuan = kv.Value.GiaChuan;
                var rooms = kv.Value.PhongChieu;

                long soBan = 0;
                long soTon = 0;
                long doanhThu = 0;

                foreach (var room in rooms)
                {
                    // Tập ghế bán của phim này ở phòng này (nếu có)
                    HashSet<string> sold = null;
                    if (daBanTheoPhim.TryGetValue(tenPhim, out var byRoom) &&
                        byRoom.TryGetValue(room, out var set))
                        sold = set;

                    foreach (var seat in ALL_SEATS)
                    {
                        bool isSold = sold != null && sold.Contains(seat);
                        if (isSold)
                        {
                            soBan++;
                            doanhThu += TinhGiaVe(giaChuan, seat);
                        }
                        else
                        {
                            soTon++;
                        }
                    }
                }

                double tyle = (soBan + soTon) == 0 ? 0.0 : (double)soBan / (soBan + soTon);
                listKq.Add((tenPhim, soBan, soTon, tyle, doanhThu));
            }
            var ranked = listKq .OrderByDescending(x => x.DoanhThu).Select((x, idx) => new { Rank = idx + 1, x.Ten, x.SoBan, x.SoTon, x.TyLe, x.DoanhThu }).ToList();
            using (var sw = new StreamWriter(outPath, false, Encoding.UTF8))
            {
                foreach (var r in ranked)
                {
                    sw.WriteLine($"Hạng: {r.Rank}");
                    sw.WriteLine($"Phim: {r.Ten}");
                    sw.WriteLine($"Số vé bán ra: {r.SoBan}");
                    sw.WriteLine($"Số vé tồn: {r.SoTon}");
                    sw.WriteLine($"Tỉ lệ bán ra: {r.TyLe:P2}");
                    sw.WriteLine($"Doanh thu: {r.DoanhThu:N0} VND");
                    sw.WriteLine(new string('-', 40));
                }
            }
        }

        private void cListphim_SelectedIndexChanged(object sender, EventArgs e)
        {
            cPhongchieu.Items.Clear();
            if (cListPhim.SelectedItem == null) return;
            string phim = cListPhim.SelectedItem.ToString();
            foreach (int p in phimDict[phim].PhongChieu) cPhongchieu.Items.Add(p);
            if (cPhongchieu.Items.Count > 0) cPhongchieu.SelectedIndex = 0;
            veDaChon.Clear();
            for (int i = 0; i < cCheckList.Items.Count; i++)
                cCheckList.SetItemChecked(i, false);
            // Gọi làm mới theo phim/phòng *mới*
            RefreshSeats();
        }
        private void Bai4_Load(object sender, EventArgs e)
        {
            cListPhim.DropDownStyle = ComboBoxStyle.DropDownList;

            try
            {
                string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input5.txt");
                LoadMoviesFromFile(inputPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể nạp 'input5.txt': " + ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            cListPhim.Items.Clear();
            foreach (var tenPhim in phimDict.Keys)
                cListPhim.Items.Add(tenPhim);
            if (cListPhim.Items.Count > 0)
                cListPhim.SelectedIndex = 0;
        }
        private void button_checklist(object sender, EventArgs e)
        {
            if (cListPhim.SelectedItem == null)
            {
                MessageBox.Show("Chưa chọn phim!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cPhongchieu.SelectedItem == null)
            {
                MessageBox.Show("Chưa chọn phòng chiếu!", "Cảnh báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Button btn = sender as Button;
            string ghe = btn.Text;
            int phongChieu = Convert.ToInt32(cPhongchieu.SelectedItem);

            if (btn.BackColor == Color.LightGreen)
            {
                MessageBox.Show("Ghế đã được chọn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var distinctRooms = veDaChon.Select(v => v.Room).Distinct().ToList();
            if (!distinctRooms.Contains(phongChieu)) distinctRooms.Add(phongChieu);

            if (distinctRooms.Count > 1 && veDaChon.Count + 1 > 2)
            {
                MessageBox.Show("Không thể chọn hơn 2 vé ở 2 phòng chiếu khác nhau!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            btn.BackColor = Color.LightGreen;
            veDaChon.Add((phongChieu, ghe));

            for (int i = 0; i < cCheckList.Items.Count; i++)
                if (cCheckList.Items[i].ToString() == ghe)
                {
                    cCheckList.SetItemChecked(i, true);
                    break;
                }

        }
        private void RefreshSeats()
        {
            if (cPhongchieu.SelectedItem == null || cListPhim.SelectedItem == null) return;

            int phong = Convert.ToInt32(cPhongchieu.SelectedItem);
            string phimCur = cListPhim.SelectedItem.ToString();

            var soldThisMovie =daBanTheoPhim.TryGetValue(phimCur, out var byRoom) &&byRoom.TryGetValue(phong, out var set)? set: new HashSet<String>(StringComparer.OrdinalIgnoreCase);

            foreach (var btn in this.Controls.OfType<Button>().Where(b => ALL_SEATS.Contains(b.Text)))
            {
                string ghe = btn.Text;
                bool isSold = soldThisMovie.Contains(ghe);

                if (isSold)
                {
                    btn.BackColor = Color.Gray;
                    btn.Enabled = false;
                }
                else
                {
                    btn.BackColor = SystemColors.Control;
                    btn.Enabled = true;
                }
            }
        }

        private void cThanhtoan_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(cHoten.Text))
            {
                MessageBox.Show("Bạn chưa nhập họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cListPhim.SelectedItem == null)
            {
                MessageBox.Show("Bạn chưa chọn phim!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string phim = cListPhim.SelectedItem.ToString();
            int giaChuan = phimDict[phim].GiaChuan;

            var gheHopLe = veDaChon.Where(v => !gheDaBan.Contains(v)).ToList();

            if (gheHopLe.Count == 0)
            {
                MessageBox.Show("Tất cả ghế bạn chọn đã bán hoặc chưa chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int tongTien = 0;
            StringBuilder bill = new StringBuilder();
            bill.AppendLine("HÓA ĐƠN THANH TOÁN");
            bill.AppendLine($"KHÁCH HÀNG : {cHoten.Text}");
            bill.AppendLine($"PHIM: {phim}");
            bill.AppendLine("----------------------------");

            foreach (var ghe in gheHopLe)
            {
                string loai = gheDict.ContainsKey(ghe.Seat) ? gheDict[ghe.Seat] : "thuong";
                int gia;
                switch (loai)
                {
                    case "vot":
                        gia = giaChuan / 4;
                        break;
                    case "vip":
                        gia = giaChuan * 2;
                        break;
                    default:
                        gia = giaChuan;
                        break;
                }

                tongTien += gia;
                bill.AppendLine($"Phòng {ghe.Room} - Ghế {ghe.Seat} ({loai}) : {gia:N0} VND");
            }

            bill.AppendLine("----------------------------");
            bill.AppendLine($"TỔNG CỘNG : {tongTien:N0} VND");

            MessageBox.Show(bill.ToString(), "Thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Information);
            foreach (var ghe in gheHopLe)
            {
                if (!daBanTheoPhim.TryGetValue(phim, out var byRoom))
                {
                    byRoom = new Dictionary<int, HashSet<string>>();
                    daBanTheoPhim[phim] = byRoom;
                }
                if (!byRoom.TryGetValue(ghe.Room, out var seatSet))
                {
                    seatSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                    byRoom[ghe.Room] = seatSet;
                }
                seatSet.Add(ghe.Seat);
                RefreshSeats();
                veDaChon.Clear();
                for (int i = 0; i < cCheckList.Items.Count; i++)
                    cCheckList.SetItemChecked(i, false);
            }
        }
        private void cReset_Click(object sender, EventArgs e)
        {
            veDaChon.Clear();
            foreach (var item in this.Controls)
                if (item is Button btn && ALL_SEATS.Contains(btn.Text))
                    btn.BackColor = SystemColors.Control;

            for (int i = 0; i < cCheckList.Items.Count; i++)
                cCheckList.SetItemChecked(i, false);

            RefreshSeats();
        }

        private void cHoten_TextChanged(object sender, EventArgs e)
        {

        }

        private void cThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cCheckList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cA1_Click(object sender, EventArgs e)
        {
            button_checklist(sender, e);
        }

        private void cA2_Click(object sender, EventArgs e)
        {
            button_checklist(sender, e);
        }

        private void cA3_Click(object sender, EventArgs e)
        {
            button_checklist(sender, e);
        }

        private void cA4_Click(object sender, EventArgs e)
        {
            button_checklist(sender, e);
        }

        private void cA5_Click(object sender, EventArgs e)
        {
            button_checklist(sender, e);
        }
        private void cB1_Click(object sender, EventArgs e)
        {
            button_checklist(sender, e);
        }

        private void cC1_Click(object sender, EventArgs e)
        {
            button_checklist(sender, e);
        }

        private void cB2_Click(object sender, EventArgs e)
        {
            button_checklist(sender, e);
        }

        private void cB3_Click(object sender, EventArgs e)
        {
            button_checklist(sender, e);
        }

        private void cB4_Click(object sender, EventArgs e)
        {
            button_checklist(sender, e);
        }

        private void cB5_Click(object sender, EventArgs e)
        {
            button_checklist(sender, e);
        }

        private void cC2_Click(object sender, EventArgs e)
        {
            button_checklist(sender, e);
        }

        private void cC3_Click(object sender, EventArgs e)
        {
            button_checklist(sender, e);
        }

        private void cC4_Click(object sender, EventArgs e)
        {
            button_checklist(sender, e);
        }

        private void cC5_Click(object sender, EventArgs e)
        {
            button_checklist(sender, e);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cPhongchieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshSeats();
        }

        private void btThongke_Click(object sender, EventArgs e)
        {

            var outPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output5.txt");
            try
            {
                ExportThongKe(outPath);
                MessageBox.Show("Đã xuất thống kê: " + outPath, "OK",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất thống kê: " + ex.Message);
            }
    }
    }
}
