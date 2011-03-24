using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyHoSoCongChuc.BusinessObject;
using QuanLyHoSoCongChuc.Controller;
using QuanLyHoSoCongChuc.DataLayer;
namespace QuanLyHoSoCongChuc.DataLayer
{
    public class NhanVienData
    {
        DataService m_NhanVienData = new DataService();
        //DataService ds = new DataService();
        public DataTable LayDanhSachNhanVien()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM NhanVien");
            m_NhanVienData.Load(cmd);
            return m_NhanVienData;
        }

        public DataTable LayThongTinLuong()
        {
            SqlCommand cmd = new SqlCommand("SELECT HoTenNhanVien, MaGioiTinh, MaChucVu, MaDonVi, MaLuongNhanVien, MaNgach, BacLuong, HeSoLuong, LuongCongChucDuBi, ChenhLechBaoLuuHeSoLuong, HuongLuongTuNgay, MocTinhNangLuongLanSau, HeSoPhuCapChucVu, HeSoPhuCapThamNienVuotKhung, HeSoPhuCapKiemNhiem, HeSoPhuCapKhac FROM NhanVien");
            m_NhanVienData.Load(cmd);
            return m_NhanVienData;
        }
        public DataTable LayThongTinLuong2()
        {
            SqlCommand cmd = new SqlCommand("SELECT MaNhanVien, HoTenNhanVien, MaGioiTinh, MaChucVu, MaDonVi, MaLuongNhanVien FROM NhanVien");
            m_NhanVienData.Load(cmd);
            return m_NhanVienData;
        }
        public DataTable LayDSNhanVienTheoPhong(String phong, String chucvu)
        { 
            SqlCommand cmd = new SqlCommand("Select * From NhanVien NV, ChucVu CV, DonVi DV, GioiTinh GT Where NV.MaChucVu = CV.MaChucVu And NV.MaDonVi = DV.MaDonVi And NV.MaGioiTinh = GT.MaGioiTinh And DV.MaDonVi = @phong and CV.MaChucVu = @chucvu");
            cmd.Parameters.Add("phong", SqlDbType.NVarChar).Value = phong;
            cmd.Parameters.Add("chucvu", SqlDbType.NVarChar).Value = chucvu;
            m_NhanVienData.Load(cmd);
            return m_NhanVienData;
        }
        public DataTable LayDanhSachNhanVienphong(String phong)
        {
            SqlCommand cmd = new SqlCommand("Select * From NhanVien NV, ChucVu CV, DonVi DV, GioiTinh GT Where NV.MaChucVu = CV.MaChucVu And NV.MaDonVi = DV.MaDonVi And NV.MaGioiTinh = GT.MaGioiTinh And DV.MaDonVi = @phong ");
            cmd.Parameters.Add("phong", SqlDbType.NVarChar).Value = phong;
            m_NhanVienData.Load(cmd);
            return m_NhanVienData;
        }

        public DataTable LayNhanVienTheoMa(String MaNV)
        {
            SqlCommand cmd = new SqlCommand("Select * From NhanVien  Where MaNhanVIen = @MaNV ");
            cmd.Parameters.Add("MaNV", SqlDbType.NVarChar).Value = MaNV;
            m_NhanVienData.Load(cmd);
            return m_NhanVienData;
        }


        public DataRow ThemDongMoi()
        {
            return m_NhanVienData.NewRow();

        }
        public void ThemNhanVien(DataRow m_Row)
        {
            m_NhanVienData.Rows.Add(m_Row);
        }
        public bool LuuNhanVien()
        {
            return m_NhanVienData.ExecuteNoneQuery() > 0;
        }
        public DataTable TimNhanVien(string cmbTen_tt, string txtTen,string cmbTDCM_tt, ComboBox cmbTDCM, string cmbChucVu_tt, ComboBox cmbChucVu, string cmbPhong_tt, ComboBox cmbPhong)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                string sql = "SELECT  NhanVien.HoTenNhanVien, TrinhDoChuyenMon.TenTrinhDoChuyenMon,ChucVu.TenChucVu, DonVi.TenDonVi FROM DonVi INNER JOIN (ChucVu INNER JOIN (TrinhDoChuyenMon INNER JOIN NhanVien ON TrinhDoChuyenMon.MaTrinhDoChuyenMon = NhanVien.MaTrinhDoChuyenMon) ON ChucVu.MaChucVu = NhanVien.MaChucVu) ON DonVi.MaDonVi = NhanVien.MaDonVi where ";
                //string sql = "SELECT  NhanVien.HoTenNhanVien, NhanVien.MaTrinhDoChuyenMon, TrinhDoChuyenMon.TenTrinhDoChuyenMon, NhanVien.MaChucVu, ChucVu.TenChucVu, NhanVien.MaDonVi, DonVi.TenDonVi FROM DonVi INNER JOIN (ChucVu INNER JOIN (TrinhDoChuyenMon INNER JOIN NhanVien ON TrinhDoChuyenMon.MaTrinhDoChuyenMon = NhanVien.MaTrinhDoChuyenMon) ON ChucVu.MaChucVu = NhanVien.MaChucVu) ON DonVi.MaDonVi = NhanVien.MaDonVi where ";
                int i = 0;

                if (cmbTen_tt != "Bỏ Qua")
                {
                    i = 1;
                    sql += "NhanVien.HoTenNhanVien = @ten ";
                    cmd.Parameters.Add("ten", SqlDbType.NVarChar).Value = txtTen;
                }

               

                if (cmbChucVu_tt != "Bỏ Qua")
                {
                    if (i == 1)
                    {
                        sql += cmbChucVu_tt + " NhanVien.MaChucVu = @machucvu ";
                        cmd.Parameters.Add("machucvu", SqlDbType.Char).Value = cmbChucVu.SelectedValue.ToString();
                    }
                    else
                    {
                        sql += "NhanVien.MaChucVu = @machucvu ";
                        cmd.Parameters.Add("machucvu", SqlDbType.Char).Value = cmbChucVu.SelectedValue.ToString();
                        i = 1;
                    }
                }

                if (cmbPhong_tt != "Bỏ Qua")
                {
                    if (i == 1)
                    {
                        sql += cmbPhong_tt + " NhanVien.MaDonVi like '%' + @maphong + '%' ";
                        cmd.Parameters.Add("maphong", SqlDbType.Char).Value = cmbPhong.SelectedValue.ToString();
                    }
                    else
                    {
                        sql += "NhanVien.MaDonVi like '%' + @maphong + '%' ";
                        cmd.Parameters.Add("maphong", SqlDbType.Char).Value = cmbPhong.SelectedValue.ToString();
                        i = 1;
                    }
                }
                if (cmbTDCM_tt != "Bỏ Qua")
                {
                    if (i == 1)
                    {
                        sql += cmbTDCM_tt + "NhanVien.MaTrinhDoChuyenMon like '%' + @matrinhdochuyenmon + '%'";
                        cmd.Parameters.Add("matrinhdochuyenmon", SqlDbType.Char).Value = cmbTDCM.SelectedValue.ToString();
                    }
                    else
                    {
                        sql += "NhanVien.MaTrinhDoChuyenMon like '%' + @matrinhdochuyenmon + '%'";
                        cmd.Parameters.Add("matrinhdochuyenmon", SqlDbType.Char).Value = cmbTDCM.SelectedValue.ToString();
                        i = 1;
                    }
                }

              

                if (i == 0)
                   // sql = "SELECT NhanVien.HoTenNhanVien, NhanVien.MaTrinhDoChuyenMon, TrinhDoChuyenMon.TenTrinhDoChuyenMon, NhanVien.MaChucVu, ChucVu.TenChucVu, NhanVien.MaDonVi, DonVi.TenDonVi FROM DonVi INNER JOIN (ChucVu INNER JOIN (TrinhDoChuyenMon INNER JOIN NhanVien ON TrinhDoChuyenMon.MaTrinhDoChuyenMon = NhanVien.MaTrinhDoChuyenMon) ON ChucVu.MaChucVu = NhanVien.MaChucVu) ON DonVi.MaDonVi = NhanVien.MaDonVi";
                    sql = "SELECT NhanVien.HoTenNhanVien, TrinhDoChuyenMon.TenTrinhDoChuyenMon, ChucVu.TenChucVu, DonVi.TenDonVi FROM DonVi INNER JOIN (ChucVu INNER JOIN (TrinhDoChuyenMon INNER JOIN NhanVien ON TrinhDoChuyenMon.MaTrinhDoChuyenMon = NhanVien.MaTrinhDoChuyenMon) ON ChucVu.MaChucVu = NhanVien.MaChucVu) ON DonVi.MaDonVi = NhanVien.MaDonVi";

                cmd.CommandText = sql;
                m_NhanVienData.Load(cmd);
               
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi khi tìm nhân viên.\n" + e.Message, "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            return m_NhanVienData;
        }
        //public DataTable LayDsNhanVienForReport()
        //{
        //    SqlCommand cmd = new SqlCommand("SELECT * FROM NhanVien NV, ChucVu CV, GioiTinh GT, DonVi DV WHERE NV.MaChucVu = CV.MaChucVu AND NV.MaGioiTinh = GT.MaGioiTinh AND NV.MaDonVi = DV.MaDonVi ");
        //    m_NhanVienData.Load(cmd);
        //    return m_NhanVienData;
        //}


        //////////////////Danh sách nâng lương///////////////////
        public DataTable LayDSNV( String dt)
        {
           // SqlCommand cmd = new SqlCommand("SELECT * FROM NhanVien NV, ChucVu CV, GioiTinh GT, DonVi DV  where NV.MaChucVu = CV.MaChucVu AND NV.MaGioiTinh = GT.MaGioiTinh AND NV.MaDonVi = DV.MaDonVi and DateDiff(dd,NgayNangLuong,Getdate())>0");
            SqlCommand cmd = new SqlCommand("SELECT * FROM NhanVien NV, ChucVu CV, GioiTinh GT, DonVi DV  where NV.MaChucVu = CV.MaChucVu AND NV.MaGioiTinh = GT.MaGioiTinh AND NV.MaDonVi = DV.MaDonVi and DateDiff(dd,NgayNangLuong,'"+ dt +"')>0");
            cmd.Parameters.Add("dt", SqlDbType.NVarChar).Value = dt;
            m_NhanVienData.Load(cmd);
            return m_NhanVienData;
        }
        public DataTable CapNhatCanSu(String dt)
        {
            SqlCommand cmd = new SqlCommand("Update NhanVien set  MocTinhNangLuongLanSau = NgayNangLuong, NgayNangLuong = DateAdd(year,2,NgayNangLuong) Where NhanVien.MaNgach = 'MN001' and DateDiff(dd, NgayNangLuong, '" + dt + "')>0");
            cmd.Parameters.Add("dt", SqlDbType.NVarChar).Value = dt;
            //SqlCommand cmd = new SqlCommand("Update HoTenNhanVien, MaNgach, MocTinhNangLuongLanSau = NgayNangLuong, NgayNangLuong = DateAdd(year,2,NgayNangLuong) from NhanVien Where NhanVien.MaNgach = 'MN001' And DateDiff(dd,NgayNangLuong,'" + dt + "')>0");
            m_NhanVienData.Load(cmd);
            return m_NhanVienData;

        }
        public DataTable CapNhatChuyenVien(String dt)
        {
            SqlCommand cmd = new SqlCommand("Update NhanVien set  MocTinhNangLuongLanSau = NgayNangLuong, NgayNangLuong = DateAdd(year,3,NgayNangLuong) Where NhanVien.MaNgach = 'MN002' And DateDiff(dd,NgayNangLuong,'" + dt + "')>0");
            cmd.Parameters.Add("dt", SqlDbType.NVarChar).Value = dt;
            m_NhanVienData.Load(cmd);
            return m_NhanVienData;
        }

        public DataTable TimNhanVien(string MaHoacTenNhanVien)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM NhanVien WHERE MaNhanVien = @MaNhanVien OR HoTenNhanVien LIKE @HoTenNhanVien");
            cmd.Parameters.Add("@MaNhanVien", SqlDbType.NChar, 10).Value = MaHoacTenNhanVien;
            cmd.Parameters.Add("@HoTenNhanVien", SqlDbType.NVarChar, 50).Value = "%" + MaHoacTenNhanVien + "%";
            m_NhanVienData.Load(cmd);
            return m_NhanVienData;
        }

        public string LayIDDangVienTheoMaNhanVien(string MaNhanVien)
        {
            string IDDangVien = "";
            if (DataService.m_ConnectString == "")
                DataService.ConnectionString();
            string ConnectionString = DataService.m_ConnectString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT MaDangVien FROM NhanVien WHERE MaNhanVien = @MaNhanVien";
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.NChar, 10).Value = MaNhanVien;
                try
                {
                    con.Open();
                    Object obj = cmd.ExecuteScalar();
                    if (obj != null)
                    {
                        IDDangVien = obj.ToString();
                    }
                    con.Close();
                }
                catch (Exception)
                {
                }
            }
            
            return IDDangVien;
        }

        public DataTable LayDSNhanVien()
        {            
            if (DataService.m_ConnectString == "")
                DataService.ConnectionString();
            string ConnectionString = DataService.m_ConnectString;
            DataTable dtDanhSachNhanVien = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM NhanVien";
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtDanhSachNhanVien);
                con.Close();
            }

            return dtDanhSachNhanVien;
        }

        public NhanVienInfo LayThongTinNhanVien(string MaNhanVien)
        {
            NhanVienInfo nv = new NhanVienInfo();


            if (DataService.m_ConnectString == "")
                DataService.ConnectionString();
            string ConnectionString = DataService.m_ConnectString;
            
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM NhanVien WHERE MaNhanVien = @MaNhanVien";
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.NChar, 10).Value = MaNhanVien;
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    nv.MaNhanVien = (string)dr["MaNhanVien"];

                    nv.HoTen = (string)dr["HoTenNhanVien"];
                    nv.TenGoiKhac = (string)dr["TenGoiKhac"];
                    nv.GioiTinh = (string)dr["MaGioiTinh"].ToString();
                    nv.NgaySinh = (DateTime)dr["NgaySinh"];
                    nv.NoiSinh = (string)dr["NoiSinh"];
                    nv.SoCMND = (string)dr["SoChungMinhNhanDan"];
                    nv.NoiCap = (string)dr["NoiCap"];
                    nv.NgayCap = (DateTime)dr["NgayCap"];
                    nv.DanToc = (string)dr["MaDanToc"];
                    nv.TonGiao = (string)dr["MaTonGiao"];
                    nv.QueQuan = (string)dr["QueQuan"];
                    nv.HoKhau = (string)dr["HoKhauThuongTru"];
                    nv.NoiOHienTai = (string)dr["NoiOHienTai"];
                    nv.DienThoaiNhaRieng = (string)dr["DienThoaiNhaRieng"];
                    nv.DienThoaiDiDong = (string)dr["DienThoaiDiDong"];
                    nv.TinhTrangHonNhan = (string)dr["MaTinhTrangHonNhan"];
                    nv.ThanhPhanXuatThan = (string)dr["MaThanhPhanXuatThan"];
                    nv.DienUuTienGiaDinh = (string)dr["MaDienUuTienCuaGiaDinh"];
                    nv.DienUuTienCuaBanThan = (string)dr["MaDienUuTienCuaBanThan"];
                    nv.NangKhieu = (string)dr["NangKhieu"];
                    nv.NgayHopDong = (DateTime)dr["NgayHopDong"];
                    nv.NgayTuyenDung = (DateTime)dr["NgayTuyenDung"];
                    nv.HinhThucTuyenDung = (string)dr["MaHinhThucTuyenDung"];
                    
                    /////////add some property
                }

                con.Close();
            }
            return nv;
        }

        public string LayGioiTinhNhanVien(string MaNhanVien)
        {
            string GioiTinh = "";


            if (DataService.m_ConnectString == "")
                DataService.ConnectionString();
            string ConnectionString = DataService.m_ConnectString;
            
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT MaGioiTinh FROM NhanVien WHERE MaNhanVien = @MaNhanVien";
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.NChar, 10).Value = MaNhanVien;
                con.Open();

                Object obj = cmd.ExecuteScalar();
                if (obj != null)
                    GioiTinh = (string)obj;
                con.Close();
            }
            return GioiTinh;
        }

        public DateTime LayNgaySinhNhanVien(string MaNhanVien)
        {
            DateTime NgaySinh = DateTime.Now;


            if (DataService.m_ConnectString == "")
                DataService.ConnectionString();
            string ConnectionString = DataService.m_ConnectString;

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT NgaySinh FROM NhanVien WHERE MaNhanVien = @MaNhanVien";
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.NChar, 10).Value = MaNhanVien;
                con.Open();

                Object obj = cmd.ExecuteScalar();
                if (obj != null)
                    NgaySinh = (DateTime)obj;
                con.Close();
            }
            return NgaySinh;
        }

        public string LayTenNhanVien(string MaNhanVien)
        {
            string TenNhanVien = "";

            if (DataService.m_ConnectString == "")
                DataService.ConnectionString();
            string ConnectionString = DataService.m_ConnectString;

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT HoTenNhanVien FROM NhanVien WHERE MaNhanVien = @MaNhanVien";
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.NChar, 10).Value = MaNhanVien;
                con.Open();

                Object obj = cmd.ExecuteScalar();
                if (obj != null)
                    TenNhanVien = (string)obj;
                con.Close();
            }
            return TenNhanVien;
        }

        public string LayIDDangVien(string MaNhanVien)
        {
            string IDDangVien = "";

            if (DataService.m_ConnectString == "")
                DataService.ConnectionString();
            string ConnectionString = DataService.m_ConnectString;

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT MaDangVien FROM NhanVien WHERE MaNhanVien = @MaNhanVien";
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.NChar, 10).Value = MaNhanVien;
                con.Open();

                Object obj = cmd.ExecuteScalar();
                if (obj != null)
                    IDDangVien = (string)obj;
                con.Close();
            }
            return IDDangVien;
        }

        public DataTable TimKiem(int type, string Frm, string To)
        {
            String sql="";
            sql += " SELECT MaNhanVien, HoTenNhanVien, MaGioiTinh, MaChucVu, MaDonVi, MaLuongNhanVien FROM NhanVien ";
            if (type == 0)
            {

            }
            else if (type == 1)
            {
                sql += " where YEAR(GETDATE()) - YEAR(NgayHopDong) >= '" + Frm .ToString()+ "' ";
                sql += " and YEAR(GETDATE()) - YEAR(NgayHopDong) <= '" + To.ToString() + "' ";
            }
            else if(type == 2)
            {
                sql += " where YEAR(GETDATE()) - YEAR(NgaySinh) >= '" + Frm.ToString() + "' ";
                sql += " and YEAR(GETDATE()) - YEAR(NgaySinh) <= '" + To.ToString() + "' ";
            }
            SqlCommand cmd = new SqlCommand(sql);
            m_NhanVienData.Load(cmd);
            return m_NhanVienData;
        }
    }
}

