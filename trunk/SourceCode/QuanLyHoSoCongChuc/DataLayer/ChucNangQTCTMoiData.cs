using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyHoSoCongChuc.BusinessObject;

namespace QuanLyHoSoCongChuc.DataLayer
{    
    public class ChucNangQTCTMoiData
    {
        DataService m_ChucNangQTCTMoiData = new DataService();

        public DataTable LayDanhsachQuaTrinhCongTacTheoMaNhanVien(string MaNhanVien)
        {

            if (DataService.m_ConnectString == "")
                DataService.ConnectionString();
            string ConnectionString = DataService.m_ConnectString;
            DataTable dtDanhSachQTCT = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT (SELECT COUNT(1) + 1 FROM QuaTrinhCongTacMoi AS q1 WHERE (MaNhanVien = @MaNhanVien) AND (MaQuaTrinhCongTac < q2.MaQuaTrinhCongTac)) AS STT, q2.* FROM QuaTrinhCongTacMoi AS q2 WHERE (MaNhanVien = @MaNhanVien)";
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.NChar, 10).Value = MaNhanVien;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtDanhSachQTCT);
                con.Close();
            }

            return dtDanhSachQTCT;            
        }


        public QuaTrinhCongTacMoiInfo LayThongTinQuaTrinhCongTac(int MaQuaTrinhCongTac)
        {
            QuaTrinhCongTacMoiInfo qtct = new QuaTrinhCongTacMoiInfo();

            if (DataService.m_ConnectString == "")
                DataService.ConnectionString();
            string ConnectionString = DataService.m_ConnectString;
            
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM QuaTrinhCongTacMoi WHERE MaQuaTrinhCongTac = @MaQuaTrinhCongTac";
                cmd.Parameters.Add("@MaQuaTrinhCongTac", SqlDbType.Int, 10).Value = MaQuaTrinhCongTac;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    qtct.MaQuaTrinhCongTac = (int)dr["MaQuaTrinhCongTac"];
                    qtct.MaNhanVien = (string)dr["MaNhanVien"];
                    qtct.MoTaCongTac = (string)dr["MoTaCongTac"];
                    qtct.MaCapUy = (int)dr["MaCapUy"];
                    qtct.MaCapUyKiem = (int)dr["MaCapUyKiem"];
                    qtct.ChucDanh = (string)dr["ChucDanh"];
                    qtct.MaChucVuChinhQuyen = (int)dr["MaChucVuChinhQuyen"];
                    qtct.ThoiGianBatDau = (DateTime)dr["ThoiGianBatDau"];
                    qtct.ThoiGianKetThuc = (DateTime)dr["ThoiGianKetThuc"];
                }

                con.Close();
            }


            return qtct;            
        }


        public void ThemQuaTrinhCongTac(QuaTrinhCongTacMoiInfo qtct)
        {
            if (DataService.m_ConnectString == "")
                DataService.ConnectionString();
            string ConnectionString = DataService.m_ConnectString;

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO QuaTrinhCongTacMoi (MaNhanVien, MoTaCongTac, MaNuocCongTac, MaCapUy, MaCapUyKiem, ChucDanh, MaChucVuChinhQuyen, ThoiGianBatDau, ThoiGianKetThuc)VALUES (@MaNhanVien, @MoTaCongTac, @MaNuocCongTac, @MaCapUy, @MaCapUyKiem, @ChucDanh, @MaChucVuChinhQuyen, @ThoiGianBatDau, @ThoiGianKetThuc)";
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.NChar, 10).Value = qtct.MaNhanVien;
                cmd.Parameters.Add("@MoTaCongTac", SqlDbType.NVarChar, 150).Value = qtct.MoTaCongTac;
                cmd.Parameters.Add("@MaNuocCongTac", SqlDbType.Int, 10).Value = qtct.MaNuocCongTac;
                cmd.Parameters.Add("@MaCapUy", SqlDbType.Int, 10).Value = qtct.MaCapUy;
                cmd.Parameters.Add("@MaCapUyKiem", SqlDbType.Int, 10).Value = qtct.MaCapUyKiem;
                cmd.Parameters.Add("@ChucDanh", SqlDbType.NVarChar, 100).Value = qtct.ChucDanh;
                cmd.Parameters.Add("@MaChucVuChinhQuyen", SqlDbType.Int, 10).Value = qtct.MaChucVuChinhQuyen;
                cmd.Parameters.Add("@ThoiGianBatDau", SqlDbType.DateTime, 10).Value = qtct.ThoiGianBatDau;
                cmd.Parameters.Add("@ThoiGianKetThuc", SqlDbType.DateTime, 10).Value = qtct.ThoiGianKetThuc;
                con.Open();

                cmd.ExecuteNonQuery();
                con.Close();
            }            
        }

        public void CapNhatQuaTrinhCongTac(QuaTrinhCongTacMoiInfo qtct)
        {
            if (DataService.m_ConnectString == "")
                DataService.ConnectionString();
            string ConnectionString = DataService.m_ConnectString;

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE QuaTrinhCongTacMoi SET MaNhanVien=@MaNhanVien, MoTaCongTac=@MoTaCongTac, MaNuocCongTac=@MaNuocCongTac, MaCapUy=@MaCapUy, MaCapUyKiem=@MaCapUyKiem, ChucDanh=@ChucDanh, MaChucVuChinhQuyen=@MaChucVuChinhQuyen, ThoiGianBatDau=@ThoiGianBatDau, ThoiGianKetThuc=@ThoiGianKetThuc WHERE MaQuaTrinhCongTac=@MaQuaTrinhCongTac";
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.NChar, 10).Value = qtct.MaNhanVien;
                cmd.Parameters.Add("@MoTaCongTac", SqlDbType.NVarChar, 150).Value = qtct.MoTaCongTac;
                cmd.Parameters.Add("@MaNuocCongTac", SqlDbType.Int, 10).Value = qtct.MaNuocCongTac;
                cmd.Parameters.Add("@MaCapUy", SqlDbType.Int, 10).Value = qtct.MaCapUy;
                cmd.Parameters.Add("@MaCapUyKiem", SqlDbType.Int, 10).Value = qtct.MaCapUyKiem;
                cmd.Parameters.Add("@ChucDanh", SqlDbType.NVarChar, 100).Value = qtct.ChucDanh;
                cmd.Parameters.Add("@MaChucVuChinhQuyen", SqlDbType.Int, 10).Value = qtct.MaChucVuChinhQuyen;
                cmd.Parameters.Add("@ThoiGianBatDau", SqlDbType.DateTime, 10).Value = qtct.ThoiGianBatDau;
                cmd.Parameters.Add("@ThoiGianKetThuc", SqlDbType.DateTime, 10).Value = qtct.ThoiGianKetThuc;
                cmd.Parameters.Add("@MaQuaTrinhCongTac", SqlDbType.Int, 10).Value = qtct.MaQuaTrinhCongTac;
                con.Open();

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }


        public void XoaQuaTrinhCongTac(int MaQTCT)
        {
            if (DataService.m_ConnectString == "")
                DataService.ConnectionString();
            string ConnectionString = DataService.m_ConnectString;

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM QuaTrinhCongTacMoi WHERE MaQuaTrinhCongTac=@MaQuaTrinhCongTac";
                cmd.Parameters.Add("@MaQuaTrinhCongTac", SqlDbType.Int, 10).Value = MaQTCT;
                con.Open();

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }


}
