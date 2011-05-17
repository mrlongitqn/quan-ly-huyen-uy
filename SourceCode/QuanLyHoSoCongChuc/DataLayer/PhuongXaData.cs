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
    public class PhuongXaData
    {
        DataService m_PhuongXaData = new DataService();
        public DataTable LayDSPhuongXa()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PhuongXa");
            if (m_PhuongXaData.ExecuteNoneQuery(cmd) == 0)
            {
                return null;
            }
            m_PhuongXaData.Load(cmd);
            return m_PhuongXaData;
        }

        public DataTable LayDSPhuongXaTheoMaQuanHuyen(string MaQuanHuyen)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PhuongXa WHERE MaQuanHuyen = '" + MaQuanHuyen + "'");
            if (m_PhuongXaData.ExecuteNoneQuery(cmd) == 0)
            {
                return null;
            }
            m_PhuongXaData.Load(cmd);
            return m_PhuongXaData;
        }

        public DataTable LayDSPhuongXaTheoTenQuanHuyen(string TenQuanHuyen)
        {
            SqlCommand cmd = new SqlCommand("SELECT p.MaPhuongXa, p.TenPhuongXa FROM PhuongXa p, QuanHuyen q WHERE p.MaQuanHuyen = q.MaQuanHuyen and q.TenQuanHuyen = '" + TenQuanHuyen + "'");
            if (m_PhuongXaData.ExecuteNoneQuery(cmd) == 0)
            {
                return null;
            }
            m_PhuongXaData.Load(cmd);            
            return m_PhuongXaData;
        }

        public bool KiemTraTonTaiPhuongXaTheoMa(string MaPhuongXa)
        {
            bool bResult = false;
            SqlCommand cmd = new SqlCommand("SELECT * FROM PhuongXa WHERE MaPhuongXa = '" + MaPhuongXa + "'");
            if (m_PhuongXaData.ExecuteNoneQuery(cmd) == 0)
            {
                return false;
            }
            m_PhuongXaData.Load(cmd);
            if (m_PhuongXaData.Rows.Count > 0)
            {
                bResult = true;
            }

            return bResult;
        }

        public int ThemPhuongXaMoi(PhuongXaInfo PhuongXaObj)
        {
            int iResult = 0;
            SqlCommand cmd = new SqlCommand("Insert Into PhuongXa (MaPhuongXa, TenPhuongXa, MaQuanHuyen) VALUES (@MaPhuongXa, @TenPhuongXa, @MaQuanHuyen)");
            cmd.Parameters.Add("@MaPhuongXa", SqlDbType.NVarChar, 10).Value = PhuongXaObj.MaPhuongXa;
            cmd.Parameters.Add("@TenPhuongXa", SqlDbType.NVarChar, 50).Value = PhuongXaObj.TenPhuongXa;
            cmd.Parameters.Add("@MaQuanHuyen", SqlDbType.NVarChar, 10).Value = PhuongXaObj.MaQuanHuyen;
            iResult = m_PhuongXaData.ExecuteNoneQuery(cmd);
            return iResult;
        }

        public DataTable CapNhatPhuongXa(PhuongXaInfo PhuongXaObj)
        {
            SqlCommand cmd = new SqlCommand("UPDATE PhuongXa SET TenPhuongXa = @TenPhuongXa WHERE MaPhuongXa = @MaPhuongXa");
            cmd.Parameters.Add("@TenPhuongXa", SqlDbType.NVarChar, 50).Value = PhuongXaObj.TenPhuongXa;
            cmd.Parameters.Add("@MaPhuongXa", SqlDbType.NVarChar, 10).Value = PhuongXaObj.MaPhuongXa;
            m_PhuongXaData.Load(cmd);
            return m_PhuongXaData;
        }

        public DataTable XoaPhuongXa(string MaPhuongXa)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM PhuongXa WHERE MaPhuongXa = @MaPhuongXa");
            cmd.Parameters.Add("@MaPhuongXa", SqlDbType.NVarChar, 10).Value = MaPhuongXa;
            m_PhuongXaData.Load(cmd);
            return m_PhuongXaData;
        }

        public DataTable XoaPhuongXaTheoMaQuanHuyen(string MaQuanHuyen)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM KhoiXom WHERE MaQuanHuyen = @MaQuanHuyen");
            cmd.Parameters.Add("@MaQuanHuyen", SqlDbType.NVarChar, 10).Value = MaQuanHuyen;
            m_PhuongXaData.Load(cmd);
            return m_PhuongXaData;
        }

    }
}
