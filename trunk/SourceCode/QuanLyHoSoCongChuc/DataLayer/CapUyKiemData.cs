using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyHoSoCongChuc.DataLayer
{
    public class CapUyKiemData
    {
        public DataTable LayDSCapUyKiem()
        {
            if (DataService.m_ConnectString == "")
                DataService.ConnectionString();
            string ConnectionString = DataService.m_ConnectString;
            DataTable dtDSCapUyKiem = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM CapUyKiem";
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtDSCapUyKiem);
                con.Close();
            }

            return dtDSCapUyKiem;
        }

    }
}
