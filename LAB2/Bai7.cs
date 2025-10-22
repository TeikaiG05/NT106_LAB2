using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB2
{
    public partial class Bai7 : Form
    {
        private const long MaxTextPreviewBytes = 2 * 1024 * 1024; // 2MB

        public Bai7()
        {
            InitializeComponent();

            treeFile.BeforeExpand += TreeFile_BeforeExpand;
            treeFile.AfterSelect += TreeFile_AfterSelect;
            treeFile.NodeMouseDoubleClick += TreeFile_NodeMouseDoubleClick;

            rtbPreview.Visible = true;
            imgPreview.Visible = false;

            this.Load += (s, e) => LoadDrives();
        }

        public void LoadDrives()
        {
            treeFile.BeginUpdate();
            treeFile.Nodes.Clear();

            foreach (var drive in DriveInfo.GetDrives())
            {
                if (!drive.IsReady) continue; 
                var driveNode = new TreeNode(drive.Name)
                {
                    Tag = drive.RootDirectory.FullName
                };
                NodeFake(driveNode);
                treeFile.Nodes.Add(driveNode);
            }

            treeFile.EndUpdate();
        }
        private static void NodeFake(TreeNode node)
        {
            node.Nodes.Add(new TreeNode { Name = "Fake", Text = "..." });
        }
        private static bool HasNodeFake(TreeNode node)
        {
            return node.Nodes.Count == 1 && node.Nodes[0].Name == "Fake";
        }
        private static void RmNodeFake(TreeNode node)
        {
            if (HasNodeFake(node)) node.Nodes.Clear();
        }

        private void TreeFile_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (!HasNodeFake(e.Node)) return;

            RmNodeFake(e.Node);
            string path = e.Node.Tag as string;
            if (string.IsNullOrEmpty(path)) return;

            try
            {
                treeFile.BeginUpdate();
                string[] dirs = Array.Empty<string>();
                try { dirs = Directory.GetDirectories(path); } catch { }

                foreach (var dir in dirs.OrderBy(d => d))
                {
                    var dirNode = new TreeNode(Path.GetFileName(dir)) { Tag = dir };
                    try
                    {
                        if (Directory.EnumerateFileSystemEntries(dir).Any())
                            NodeFake(dirNode);
                    }
                    catch {}

                    e.Node.Nodes.Add(dirNode);
                }

                // File
                string[] files = Array.Empty<string>();
                try { files = Directory.GetFiles(path); } catch { }

                foreach (var file in files.OrderBy(f => f))
                {
                    var fileNode = new TreeNode(Path.GetFileName(file)) { Tag = file };
                    e.Node.Nodes.Add(fileNode);
                }
            }
            finally
            {
                treeFile.EndUpdate();
            }
        }

        private async void TreeFile_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string path = e.Node.Tag as string;
            if (string.IsNullOrEmpty(path)) return;

            if (File.Exists(path))
            {
                string ext = Path.GetExtension(path).ToLowerInvariant();

                // Pic
                if (new[] { ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".tif", ".tiff", ".webp" }.Contains(ext))
                {
                    ShowImage(path);
                    return;
                }

                // Text
                if (new[] { ".txt", ".cs", ".config", ".xml", ".html", ".htm", ".json", ".csv", ".log", ".md", ".ini" }.Contains(ext))
                {
                    await ShowTextAsync(path);
                    return;
                }

                // Hien thong tin co ban
                try
                {
                    var fi = new FileInfo(path);
                    ShowTextRaw(
                        $"Tên: {fi.Name}\r\nĐường dẫn: {fi.FullName}\r\n" +
                        $"Kích thước: {fi.Length:n0} bytes\r\nSửa lần cuối: {fi.LastWriteTime}\r\n" +
                        $"Thuộc tính: {fi.Attributes}"
                    );
                }
                catch (Exception ex)
                {
                    ShowTextRaw("Không thể đọc thông tin file: " + ex.Message);
                }
            }
            else if (Directory.Exists(path))
            {
                ShowTextRaw("(Thư mục) " + path + "\r\n— Nhấp mở rộng để xem nội dung.");
            }
            else
            {
                ShowTextRaw("No preview available.");
            }
        }

        private void TreeFile_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string path = e.Node.Tag as string;
            if (string.IsNullOrEmpty(path)) return;

            if (Directory.Exists(path))
            {
                if (!e.Node.IsExpanded) e.Node.Expand();
            }
            else if (File.Exists(path))
            {
            }
        }
        private async Task ShowTextAsync(string path)
        {
            rtbPreview.Visible = true;
            imgPreview.Visible = false;

            try
            {
                var fi = new FileInfo(path);
                if (fi.Length > MaxTextPreviewBytes)
                    rtbPreview.Text = $"(File lớn: {fi.Length:n0} bytes) — chỉ đọc phần đầu...\r\n";

                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var reader = new StreamReader(fs, Encoding.UTF8, true))
                {
                    if (fi.Length > MaxTextPreviewBytes)
                    {
                        char[] buf = new char[64 * 1024];
                        int n = await reader.ReadAsync(buf, 0, buf.Length);
                        rtbPreview.AppendText(new string(buf, 0, n));
                    }
                    else
                    {
                        rtbPreview.Text = await reader.ReadToEndAsync();
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                rtbPreview.Text = "Bạn không có quyền đọc file này.";
            }
            catch (Exception ex)
            {
                rtbPreview.Text = "Không thể đọc file: " + ex.Message;
            }
        }

        private void ShowTextRaw(string text)
        {
            rtbPreview.Visible = true;
            imgPreview.Visible = false;
            rtbPreview.Text = text;
        }

        private void ShowImage(string path)
        {
            rtbPreview.Visible = false;
            imgPreview.Visible = true;
            if (imgPreview.Image != null)
            {
                var old = imgPreview.Image;
                imgPreview.Image = null;
                old.Dispose();
            }

            try
            {
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    imgPreview.Image = Image.FromStream(fs);
                }
            }
            catch (Exception ex)
            {
                imgPreview.Visible = false;
                ShowTextRaw("Không thể hiển thị ảnh: " + ex.Message);
            }
        }
    }
}
