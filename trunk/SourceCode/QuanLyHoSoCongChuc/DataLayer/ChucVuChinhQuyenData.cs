using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyHoSoCongChuc.DataLayer
{
    public class ChucVuChinhQuyenData
    {
        public DataTable LayDSChucVuChinhQuyen()
        {
            if (DataService.m_ConnectString == "")
                DataService.ConnectionString();
            string ConnectionString = DataService.m_ConnectString;
            DataTable dtDSChucVuChinhQuyen = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM ChucVuChinhQuyen";
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtDSChucVuChinhQuyen);
                con.Close();
            }

            return dtDSChucVuChinhQuyen;
        }
    }
}
