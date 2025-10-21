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
    public partial class Bai1 : Form
    {
        private readonly string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input1.txt");
        private readonly string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output1.txt");
        public Bai1()
        {
            InitializeComponent();
        }

        private void btdocFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(inputPath))
                {
                    MessageBox.Show($"Không tìm thấy {inputPath}.","Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                using (var sr = new StreamReader(inputPath))
                {
                    string all = sr.ReadToEnd();
                    richTextBox1.Text = all;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc file: " + ex.Message);
            }
        }

        private void btghiFile_Click(object sender, EventArgs e)
        {
            try
            {
                string upper = (richTextBox1.Text ?? string.Empty).ToUpper();
                using (var sw = new StreamWriter(outputPath, false))
                {
                    sw.Write(upper);
                }

                MessageBox.Show($"Đã ghi ra: {outputPath}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi file: " + ex.Message);
            }
        }
    }
}
