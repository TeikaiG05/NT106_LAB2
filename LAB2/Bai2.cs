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
    public partial class Bai2 : Form
    {
        public Bai2()
        {
            InitializeComponent();
        }

        private void btRead_Click(object sender, EventArgs e)
        {
            rtbOutput.Clear();
            using (var ofd = new OpenFileDialog()
            {
                Title = "Chọn file .txt",
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*", 
                CheckFileExists = true
            })
            {
                if (ofd.ShowDialog() != DialogResult.OK) return;
  
                var filePath = ofd.FileName;
                var fi=new FileInfo(filePath);

                string content;
                using (var sr = new StreamReader(filePath))
                {
                    content = sr.ReadToEnd();
                }

                int lineCount = CountLines(content);
                int wordsCount = CountWords(content);
                int charCount = content.Length;

                tbfileName.Text = fi.Name;
                tbURL.Text = fi.FullName;
                tbSize.Text = fi.Length.ToString() + " bytes";
                tblineCount.Text = lineCount.ToString();
                tbwordCount.Text = wordsCount.ToString();
                tbcharacterCount.Text = charCount.ToString();
                rtbOutput.Text = content;
            }

        }
        private int CountLines(string content)
        {
            if (string.IsNullOrEmpty(content)) return 0;
            var lines = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            return lines.Length;
        }
        private int CountWords(string content)
        {
            if (string.IsNullOrWhiteSpace(content)) return 0;
            var words = content.Split(new[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }
    }
}
