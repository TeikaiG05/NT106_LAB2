using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB2
{
    public static class SqliteDb
    {
        public static readonly string DbPath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "monan.db");
        public static readonly string ConnStr = $"Data Source={DbPath};Version=3;";

        //public static int DeleteMonAnByName(string ten)
        //{
        //    var cn = new SQLiteConnection(ConnStr);
        //    cn.Open();
        //    var cmd = cn.CreateCommand();
        //    cmd.CommandText = "DELETE FROM MonAn WHERE TenMonAn COLLATE NOCASE = @ten;";
        //    cmd.Parameters.AddWithValue("@ten", ten);
        //    return cmd.ExecuteNonQuery();
        //}
        public static void EnsureCreatedAndSeed()
        {
            if (!File.Exists(DbPath))
                SQLiteConnection.CreateFile(DbPath);

            using (var cn = new SQLiteConnection(ConnStr))
            {
                cn.Open();

                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"CREATE TABLE IF NOT EXISTS NguoiDung(IDNCC   INTEGER PRIMARY KEY, HoVaTen TEXT NOT NULL, QuyenHan TEXT); 
                                        CREATE TABLE IF NOT EXISTS MonAn(IDMA     INTEGER PRIMARY KEY, TenMonAn TEXT NOT NULL, HinhAnh  TEXT, IDNCC    INTEGER NOT NULL, FOREIGN KEY(IDNCC) REFERENCES NguoiDung(IDNCC));";
                    cmd.ExecuteNonQuery();
                }

                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "SELECT COUNT(*) FROM NguoiDung;";
                    long ncc = (long)cmd.ExecuteScalar();
                    if (ncc == 0)
                    {
                        cmd.CommandText = @"INSERT INTO NguoiDung(IDNCC,HoVaTen,QuyenHan) VALUES (1,'Phùng Kiệt','User');";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public static DataTable GetNguoiDung()
        {
            using (var cn = new SQLiteConnection(ConnStr))
            using (var da = new SQLiteDataAdapter("SELECT IDNCC, HoVaTen FROM NguoiDung ORDER BY HoVaTen;", cn))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static void InsertMonAn(string ten, string hinh, int idncc)
        {
            using (var cn = new SQLiteConnection(ConnStr))
            {
                cn.Open();
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO MonAn(TenMonAn,HinhAnh,IDNCC) VALUES(@t,@h,@n)";
                    cmd.Parameters.AddWithValue("@t", ten);
                    cmd.Parameters.AddWithValue("@h",
                        string.IsNullOrWhiteSpace(hinh) ? (object)DBNull.Value : hinh);
                    cmd.Parameters.AddWithValue("@n", idncc);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataTable GetMonAnWithNguoi()
        {
            using (var cn = new SQLiteConnection(ConnStr))
            using (var da = new SQLiteDataAdapter(
                @"SELECT m.IDMA, m.TenMonAn, m.HinhAnh, n.HoVaTen
                  FROM MonAn m JOIN NguoiDung n ON m.IDNCC = n.IDNCC
                  ORDER BY m.TenMonAn;", cn))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataRow GetRandomDish()
        {
            using (var cn = new SQLiteConnection(ConnStr))
            using (var da = new SQLiteDataAdapter(
                @"SELECT m.TenMonAn, m.HinhAnh, n.HoVaTen
                  FROM MonAn m JOIN NguoiDung n ON m.IDNCC = n.IDNCC
                  ORDER BY RANDOM() LIMIT 1;", cn))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }
        public static int GetOrCreateNguoiDungByName(string hoTen, string quyenHan = null)
        {
            using (var cn = new SQLiteConnection(ConnStr))
            {
                cn.Open();

                // 1) Thử tìm trước
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "SELECT IDNCC FROM NguoiDung WHERE HoVaTen = @h LIMIT 1;";
                    cmd.Parameters.AddWithValue("@h", hoTen);
                    var o = cmd.ExecuteScalar();
                    if (o != null && o != DBNull.Value)
                        return Convert.ToInt32((long)o);
                }

                // 2) Không có thì chèn mới
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText =
                        "INSERT INTO NguoiDung(HoVaTen, QuyenHan) VALUES(@h, @q); SELECT last_insert_rowid();";
                    cmd.Parameters.AddWithValue("@h", hoTen);
                    cmd.Parameters.AddWithValue("@q", (object)quyenHan ?? DBNull.Value);
                    return Convert.ToInt32((long)cmd.ExecuteScalar());
                }
            }
        }
        public static int DeleteMonAnById(int idma)
        {
            using (var cn = new SQLiteConnection(ConnStr))
            {
                cn.Open();
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM MonAn WHERE IDMA = @id;";
                    cmd.Parameters.AddWithValue("@id", idma);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
