using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using QuanLyHoSoCongChuc.BusinessObject;

namespace QuanLyHoSoCongChuc.DataLayer
{
    public class ThanNhanMoiData
    {
        public DataTable LayDanhSachThanNhan(string MaNhanVien)
        {
            if (DataService.m_ConnectString == "")
                DataService.ConnectionString();
            string ConnectionString = DataService.m_ConnectString;
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT  (SELECT COUNT(1) + 1 FROM ThanNhanMoi tn1 WHERE tn1.MaNhanVien = @MaNhanVien and tn1.MaThanNhan < tn2.MaThanNhan) as STT, tn2.*, qh.TenQuanHe FROM ThanNhanMoi tn2, QuanHe qh WHERE tn2.MaNhanVien = @MaNhanVien and tn2.MaQuanHe = qh.MaQuanHe";
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.NChar, 10).Value = MaNhanVien;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }

            return dt;
        }

        public ThanNhanMoiInfo LayThongTinThanNhan(int MaThanNhan)
        {
            ThanNhanMoiInfo tn = new ThanNhanMoiInfo();
            if (DataService.m_ConnectString == "")
                DataService.ConnectionString();
            string ConnectionString = DataService.m_ConnectString;

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM ThanNhanMoi WHERE MaThanNhan = @MaThanNhan";
                cmd.Parameters.Add("@MaThanNhan", SqlDbType.Int, 10).Value = MaThanNhan;
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tn.MaThanNhan = (int)dr["MaThanNhan"];
                    tn.TenThanNhan = (string)dr["TenThanNhan"];
                    tn.MaQuanHe = (string)dr["MaQuanHe"];
                    tn.NamSinh = (int)dr["NamSinh"];
                    tn.ThongTinCaNhan = (string)dr["ThongTinCaNhan"];
                    tn.MaNhanVien = (string)dr["MaNhanVien"];
                    break;
                }

                con.Close();
            }
            return tn;
        }


        public void ThemThanNhan(ThanNhanMoiInfo tn)
        {
            if (DataService.m_ConnectString == "")
                DataService.ConnectionString();
            string ConnectionString = DataService.m_ConnectString;
            
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO ThanNhanMoi (TenThanNhan, MaQuanHe, NamSinh, ThongTinCaNhan, MaNhanVien) VALUES (@TenThanNhan, @MaQuanHe, @NamSinh, @ThongTinCaNhan, @MaNhanVien)";
                cmd.Parameters.Add("@TenThanNhan", SqlDbType.NVarChar, 50).Value = tn.TenThanNhan;
                cmd.Parameters.Add("@MaQuanHe", SqlDbType.NChar, 10).Value = tn.MaQuanHe;
                cmd.Parameters.Add("@NamSinh", SqlDbType.Int, 10).Value = tn.NamSinh;
                cmd.Parameters.Add("@ThongTinCaNhan", SqlDbType.NVarChar, 200).Value = tn.ThongTinCaNhan;
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.NChar, 10).Value = tn.MaNhanVien;
                con.Open();

                cmd.ExecuteNonQuery();
                con.Close();
            }            
        }


        public void CapNhatThanNhan(ThanNhanMoiInfo tn)
        {
            if (DataService.m_ConnectString == "")
                DataService.ConnectionString();
            string ConnectionString = DataService.m_ConnectString;

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE ThanNhanMoi SET TenThanNhan=@TenThanNhan, MaQuanHe=@MaQuanHe, NamSinh=@NamSinh, ThongTinCaNhan=@ThongTinCaNhan, MaNhanVien=@MaNhanVien WHERE MaThanNhan=@MaThanNhan";
                cmd.Parameters.Add("@TenThanNhan", SqlDbType.NVarChar, 50).Value = tn.TenThanNhan;
                cmd.Parameters.Add("@MaQuanHe", SqlDbType.NChar, 10).Value = tn.MaQuanHe;
                cmd.Parameters.Add("@NamSinh", SqlDbType.Int, 10).Value = tn.NamSinh;
                cmd.Parameters.Add("@ThongTinCaNhan", SqlDbType.NVarChar, 200).Value = tn.ThongTinCaNhan;
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.NChar, 10).Value = tn.MaNhanVien;
                cmd.Parameters.Add("@MaThanNhan", SqlDbType.Int, 10).Value = tn.MaThanNhan;
                con.Open();

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }


        public void XoaThanNhan(int MaThanNhan)
        {
            if (DataService.m_ConnectString == "")
                DataService.ConnectionString();
            string ConnectionString = DataService.m_ConnectString;

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM ThanNhanMoi WHERE MaThanNhan = @MaThanNhan";
                cmd.Parameters.Add("@MaThanNhan", SqlDbType.Int, 10).Value = MaThanNhan;                
                con.Open();

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        
    }
}
