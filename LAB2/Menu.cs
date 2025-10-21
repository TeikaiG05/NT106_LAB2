using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB2
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Bai1_Click(object sender, EventArgs e)
        {
            Bai1 bai1 = new Bai1();
            this.Hide();
            bai1.ShowDialog();
            this.Show();
        }

        private void Bai2_Click(object sender, EventArgs e)
        {
            Bai2 bai2 = new Bai2();
            this.Hide();
            bai2.ShowDialog();
            this.Show();
        }

        private void Bai3_Click(object sender, EventArgs e)
        {
            Bai3 bai3 = new Bai3();
            this.Hide();
            bai3.ShowDialog();
            this.Show();
        }

        private void Bai4_Click(object sender, EventArgs e)
        {
            Bai4 bai4 = new Bai4();
            this.Hide();
            bai4.ShowDialog();
            this.Show();
        }

        private void Bai5_Click(object sender, EventArgs e)
        {
            Bai5 bai5 = new Bai5();
            this.Hide(); 
            bai5.ShowDialog();
            this.Show();
        }

        private void Bai6_Click(object sender, EventArgs e)
        {
            Bai6 bai6 = new Bai6();
            this.Hide();
            bai6.ShowDialog();
            this.Show();
        }

        private void Bai7_Click(object sender, EventArgs e)
        {
            Bai7 bai7 = new Bai7();
            this.Hide();
            bai7.ShowDialog();
            this.Show();
        }
    }
}
