using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LAB2
{
    public partial class Bai4 : Form
    {
        private readonly List<Student> list = new List<Student>();
        private List<Student> loaded = new List<Student>();
        private int idx = -1;
        private readonly string input = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input4.txt");
        private readonly string output = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output4.txt");
        public Bai4()
        {
            InitializeComponent();
        }
        private float F(string t)
        {
            float v;
            if (!float.TryParse((t ?? "").Replace(',', '.'),System.Globalization.NumberStyles.Float,System.Globalization.CultureInfo.InvariantCulture, out v)) v = 0f;
            return v;
        }
        private bool Valid(Student s, out string msg)
        {
            if (string.IsNullOrWhiteSpace(s.Name)) { msg = "Name trống"; return false; }
            if (!System.Text.RegularExpressions.Regex.IsMatch(s.ID ?? "", @"^\d{8}$")) { msg = "MSSV phải 8 chữ số"; return false; }
            if (!System.Text.RegularExpressions.Regex.IsMatch(s.Phone ?? "", @"^0\d{9}$")) { msg = "Phone 10 chữ số, bắt đầu 0"; return false; }
            if (s.Course1 < 0 || s.Course1 > 10 || s.Course2 < 0 || s.Course2 > 10 || s.Course3 < 0 || s.Course3 > 10) { msg = "Điểm 0..10"; return false; }
            msg = null; return true;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            var s = new Student
            {
                Name = tbinName.Text.Trim(),
                ID = tbinID.Text.Trim(),
                Phone = tbinPhone.Text.Trim(),
                Course1 = F(tbinC1.Text),
                Course2 = F(tbinC2.Text),
                Course3 = F(tbinC3.Text)
            };
            string err; if (!Valid(s, out err)) { MessageBox.Show(err); return; }
            list.Add(s);
            rtbView.AppendText($"{s.Name}\r\n{s.ID}\r\n{s.Phone}\r\n{s.Course1}\r\n{s.Course2}\r\n{s.Course3}\r\n\r\n");

            // clear
            tbinName.Clear(); 
            tbinID.Clear(); 
            tbinPhone.Clear();
            tbinC1.Clear(); 
            tbinC2.Clear(); 
            tbinC3.Clear(); 
            tbinName.Focus();
        }

        private void btWrite_Click(object sender, EventArgs e)
        {
            try
            {
                using (var fs = new System.IO.FileStream(input, FileMode.Create, FileAccess.Write))
                {
                    var bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    bf.Serialize(fs, list);
                }
                MessageBox.Show("Đã ghi: " + input);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi ghi: " + ex.Message); }
        }

        private void btRead_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(input)) { MessageBox.Show("Chưa có input4.txt."); return; }

                using (var fs = new FileStream(input, FileMode.Open, FileAccess.Read))
                {
                    var bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    loaded = (List<Student>)bf.Deserialize(fs);
                }
                foreach (var st in loaded) st.RecalcAverage();
                idx = loaded.Count > 0 ? 0 : -1;
                ShowCurrent();
                var sb = new StringBuilder();
                foreach (var st in loaded)
                {
                    st.RecalcAverage();
                    sb.AppendLine(st.Name);
                    sb.AppendLine(st.ID);
                    sb.AppendLine(st.Phone);
                    sb.AppendLine(st.Course1.ToString());
                    sb.AppendLine(st.Course2.ToString());
                    sb.AppendLine(st.Course3.ToString());
                    sb.AppendLine(st.Average.ToString());
                    sb.AppendLine();
                }
                File.WriteAllText(output, sb.ToString(), Encoding.UTF8);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi đọc/tính: " + ex.Message); }
        }

        private void ShowCurrent()
        {
            if (idx < 0 || idx >= loaded.Count)
            {
                tbRName.Clear();
                tbRID.Clear();
                tbRPhone.Clear();
                tbRC1.Clear();
                tbRC2.Clear();
                tbRC3.Clear();
                tbRAvg.Clear();
                lbStt.Text = "0/0";
                btBack.Enabled = btNext.Enabled = false;
                return;
            }

            var s = loaded[idx];
            tbRName.Text = s.Name;
            tbRID.Text = s.ID;
            tbRPhone.Text = s.Phone;
            tbRC1.Text = s.Course1.ToString(CultureInfo.InvariantCulture);
            tbRC2.Text = s.Course2.ToString(CultureInfo.InvariantCulture);
            tbRC3.Text = s.Course3.ToString(CultureInfo.InvariantCulture);
            tbRAvg.Text = s.Average.ToString("0.##", CultureInfo.InvariantCulture);

            lbStt.Text = (idx + 1) + "/" + loaded.Count;
            btBack.Enabled = idx > 0;
            btNext.Enabled = idx < loaded.Count - 1;
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            if (idx > 0) { idx--; ShowCurrent(); }
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            if (idx < loaded.Count - 1) { idx++; ShowCurrent(); }
        }
    }
    [Serializable]               
    public class Student
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string Phone { get; set; } 
        public float Course1 { get; set; }
        public float Course2 { get; set; }
        public float Course3 { get; set; }
        public float Average { get; set; }

        public void RecalcAverage()
        {
            Average = (Course1 + Course2 + Course3) / 3f;
        }

        public override string ToString()
        {
            return Name + "\n" + ID + "\n" + Phone + "\n" + Course1 + "\n" + Course2 + "\n" + Course3 + "\n" + Average;
        }
    }
}
