using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using QuanLyHoSoCongChuc.BusinessObject;

namespace QuanLyHoSoCongChuc.DataLayer
{
    public class TinhThanhData
    {
        DataService m_TinhThanhData = new DataService();

        public TinhThanhData()
        {
            DataService.OpenConnection();
        }

        public DataTable LayDSTinhThanh()
        {
            SqlCommand cmd = new SqlCommand("SELECT MaTinh, TenTinh FROM TinhThanh");
            m_TinhThanhData.Load(cmd);
            return m_TinhThanhData;
        }

        public bool KiemTraTonTaiTinhThanhTheoMa(string MaTinh)
        {
            bool bResult = false;

            SqlCommand cmd = new SqlCommand("SELECT * FROM TinhThanh WHERE MaTinh = '" + MaTinh +"'");
            if (m_TinhThanhData.ExecuteNoneQuery(cmd) == 0)
            {
                return false;
            }
            m_TinhThanhData.Load(cmd);
            if (m_TinhThanhData.Rows.Count > 0)
            {
                bResult = true;
            }
            return bResult;
        }


        public int ThemTinhThanhMoi(TinhThanhInfo TinhThanhObj)
        {
            int iResult = 0;
            SqlCommand cmd = new SqlCommand("Insert Into TinhThanh (MaTinh, TenTinh) VALUES (@MaTinh, @TenTinh)");
            cmd.Parameters.Add("@MaTinh", SqlDbType.NVarChar, 10).Value = TinhThanhObj.MaTinh;
            cmd.Parameters.Add("@TenTinh", SqlDbType.NVarChar, 50).Value = TinhThanhObj.TenTinh;

            iResult = m_TinhThanhData.ExecuteNoneQuery(cmd);
            return iResult;
        }

        public DataTable CapNhatTinhThanh(TinhThanhInfo TinhThanhObj)
        {            
            SqlCommand cmd = new SqlCommand("UPDATE TinhThanh SET TenTinh = @TenTinh WHERE MaTinh = @MaTinh");
            cmd.Parameters.Add("@TenTinh", SqlDbType.NVarChar, 50).Value = TinhThanhObj.TenTinh;
            cmd.Parameters.Add("@MaTinh", SqlDbType.NVarChar, 10).Value = TinhThanhObj.MaTinh;
            m_TinhThanhData.Load(cmd);
            return m_TinhThanhData;
        }

        public DataTable XoaTinhThanh(string MaTinh)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM TinhThanh WHERE MaTinh = @MaTinh");
            cmd.Parameters.Add("@MaTinh", SqlDbType.NVarChar, 10).Value = MaTinh;
            m_TinhThanhData.Load(cmd);
            return m_TinhThanhData;
        }        
    }
}
