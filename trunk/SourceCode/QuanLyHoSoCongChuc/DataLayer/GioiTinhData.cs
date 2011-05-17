using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace QuanLyHoSoCongChuc.DataLayer
{
    public class GioiTinhData
    {
        DataService m_GioiTinhData = new DataService();
        public DataTable LayDsGioiTinh()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM GioiTinh");
            m_GioiTinhData.Load(cmd);
            return m_GioiTinhData;
        }

        public DataTable LayDanhSachGioiTinh()
        {
            if (DataService.m_ConnectString == "")
                DataService.ConnectionString();
            string ConnectionString = DataService.m_ConnectString;
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM GioiTinh";
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }

            return dt;
        }
    }
}
