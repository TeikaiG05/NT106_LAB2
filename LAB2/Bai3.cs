using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB2
{
    public partial class Bai3 : Form
    {
        private readonly string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input3.txt");
        private readonly string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output3.txt");
        public Bai3()
        {
            InitializeComponent();
        }

        private void btdocFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(inputPath))
                {
                    MessageBox.Show($"Không tìm thấy {inputPath}.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                var ev = new StackEvaluator();

                // lấy từng dòng từ richTextBox1 (đã đọc input3.txt trước đó)
                var lines = (richTextBox1.Text ?? string.Empty).Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

                var outLines = new List<string>();

                foreach (var raw in lines)
                {
                    var line = raw.Trim();
                    if (line.Length == 0) continue;

                    try
                    {
                        //Doi phay thanh cham
                        var normalized = line.Replace(',', '.');

                        double val = ev.StackEvaluate(normalized);
                        string sVal = val.ToString("0.##########", CultureInfo.InvariantCulture);
                        outLines.Add(line + " = " + sVal);
                    }
                    catch (Exception ex)
                    {
                        outLines.Add(line + " = ERROR (" + ex.Message + ")");
                    }
                }

                // ghi file
                File.WriteAllLines(outputPath, outLines, Encoding.UTF8);
                MessageBox.Show("Đã tính toán và ghi ra: " + outputPath, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi file: " + ex.Message);
            }
        }
        public class StackEvaluator
        {
            private static int Prec(char op)
            {
                if (op == '+' || op == '-') return 1;
                if (op == '*' || op == '/') return 2;
                return 0;
            }

            public double StackEvaluate(string expr)
            {
                var values = new Stack<double>();
                var ops = new Stack<char>();
                int i = 0;
                string s = expr ?? "";

                while (i < s.Length)
                {
                    char c = s[i];

                    if (char.IsWhiteSpace(c)) { i++; continue; }

                    if (char.IsDigit(c) || c == '.' ||((c == '+' || c == '-') && (i == 0 || s[i - 1] == '(' || IsOp(s[i - 1])) && (i + 1 < s.Length) && (char.IsDigit(s[i + 1]) || s[i + 1] == '.')))
                    {
                        int start = i;
                        if (c == '+' || c == '-') i++;
                        bool dot = (c == '.');

                        while (i < s.Length)
                        {
                            char d = s[i];
                            if (char.IsDigit(d)) { i++; }
                            else if (d == '.' && !dot) { dot = true; i++; }
                            else break;
                        }

                        string token = s.Substring(start, i - start);
                        double val = double.Parse(token, NumberStyles.Float, CultureInfo.InvariantCulture);
                        values.Push(val);
                        continue;
                    }

                    if (c == '(') { ops.Push('('); i++; continue; }

                    if (c == ')')
                    {
                        while (ops.Count > 0 && ops.Peek() != '(')
                            ApplyTop(values, ops.Pop());
                        if (ops.Count == 0 || ops.Pop() != '(')
                            throw new Exception("Ngoặc không khớp");
                        i++; continue;
                    }

                    if (IsOp(c))
                    {
                        while (ops.Count > 0 && IsOp(ops.Peek()) && Prec(ops.Peek()) >= Prec(c))
                            ApplyTop(values, ops.Pop());
                        ops.Push(c);
                        i++; continue;
                    }
                    throw new Exception("Ký tự không hợp lệ: '" + c + "'");
                }

                while (ops.Count > 0)
                {
                    char op = ops.Pop();
                    if (op == '(') throw new Exception("Ngoặc không khớp");
                    ApplyTop(values, op);
                }

                if (values.Count != 1) throw new Exception("Biểu thức không hợp lệ");
                return values.Pop();
            }

            private static bool IsOp(char c)
            {
                return c == '+' || c == '-' || c == '*' || c == '/';
            }

            private static void ApplyTop(Stack<double> values, char op)
            {
                if (values.Count < 2) throw new Exception("Thiếu toán hạng");
                double b = values.Pop();
                double a = values.Pop();
                double r;

                switch (op)
                {
                    case '+': r = a + b; break;
                    case '-': r = a - b; break;
                    case '*': r = a * b; break;
                    case '/':
                        if (b == 0) throw new DivideByZeroException();
                        r = a / b; break;
                    default:
                        throw new Exception("Toán tử không hỗ trợ: " + op);
                }

                values.Push(r);
            }
        }
    }
}
