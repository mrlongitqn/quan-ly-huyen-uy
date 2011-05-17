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
    public class QuanHuyenData
    {
        DataService m_QuanHuyenData = new DataService();

        public DataTable LayDSQuanHuyen()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM QuanHuyen");
            if (m_QuanHuyenData.ExecuteNoneQuery(cmd) == 0)
            {
                return null;
            }
            m_QuanHuyenData.Load(cmd);
            return m_QuanHuyenData;
        }

        public DataTable LayDanhSachQuanHuyenThemMaTinh(string MaTinhThanh)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM QuanHuyen WHERE MaTinh = '" + MaTinhThanh + "'");
            if (m_QuanHuyenData.ExecuteNoneQuery(cmd) == 0)
            {
                return null;
            }
            m_QuanHuyenData.Load(cmd);
            return m_QuanHuyenData;
        }

        public DataTable LayDanhSachQuanHuyenThemTenTinh(string TenTinhThanh)
        {
            SqlCommand cmd = new SqlCommand("SELECT q.MaQuanHuyen, q.TenQuanHuyen FROM QuanHuyen q, TinhThanh t WHERE q.MaTinh = t.MaTinh and t.TenTinh = '" + TenTinhThanh + "'");
            if (m_QuanHuyenData.ExecuteNoneQuery(cmd) == 0)
            {
                return null;
            }
            m_QuanHuyenData.Load(cmd);            
            return m_QuanHuyenData;
        }

        public bool KiemTraTonTaiQuanHuyenTheoMa(string MaQuanhuyen)
        {
            bool bResult = false;
            SqlCommand cmd = new SqlCommand("SELECT * FROM QuanHuyen WHERE MaQuanHuyen = '" + MaQuanhuyen + "'");
            if (m_QuanHuyenData.ExecuteNoneQuery(cmd) == 0)
            {
                return false;
            }
            m_QuanHuyenData.Load(cmd);
            if (m_QuanHuyenData.Rows.Count > 0)
            {
                bResult = true;
            }
            return bResult;
        }

        public int ThemQuanHuyenMoi(QuanHuyenInfo QuanHuyenObj)
        {
            int iResult = 0;
            SqlCommand cmd = new SqlCommand("Insert Into QuanHuyen (MaQuanHuyen, TenQuanHuyen, MaTinh) VALUES (@MaQuanHuyen, @TenQuanHuyen, @MaTinh)");
            cmd.Parameters.Add("@MaQuanHuyen", SqlDbType.NVarChar, 10).Value = QuanHuyenObj.MaQuanHuyen;
            cmd.Parameters.Add("@TenQuanHuyen", SqlDbType.NVarChar, 50).Value = QuanHuyenObj.TenQuanHuyen;
            cmd.Parameters.Add("@MaTinh", SqlDbType.NVarChar, 10).Value = QuanHuyenObj.MaTinh;
            iResult = m_QuanHuyenData.ExecuteNoneQuery(cmd);
            return iResult;
        }

        public DataTable CapNhatQuanHuyen(QuanHuyenInfo QuanHuyenObj)
        {
            SqlCommand cmd = new SqlCommand("UPDATE QuanHuyen SET TenQuanHuyen = @TenQuanHuyen WHERE MaQuanHuyen = @MaQuanHuyen");
            cmd.Parameters.Add("@TenQuanHuyen", SqlDbType.NVarChar, 50).Value = QuanHuyenObj.TenQuanHuyen;
            cmd.Parameters.Add("@MaQuanHuyen", SqlDbType.NVarChar, 10).Value = QuanHuyenObj.MaQuanHuyen;
            m_QuanHuyenData.Load(cmd);
            return m_QuanHuyenData;
        }


        public DataTable XoaQuanHuyen(string MaQuanHuyen)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM QuanHuyen WHERE MaQuanHuyen = @MaQuanHuyen");
            cmd.Parameters.Add("@MaQuanHuyen", SqlDbType.NVarChar, 10).Value = MaQuanHuyen;
            m_QuanHuyenData.Load(cmd);
            return m_QuanHuyenData;
        }

        public DataTable XoaQuanHuyenTheoMaTinh(string MaTinh)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM QuanHuyen WHERE MaTinh = @MaTinh");
            cmd.Parameters.Add("@MaTinh", SqlDbType.NVarChar, 10).Value = MaTinh;
            m_QuanHuyenData.Load(cmd);
            return m_QuanHuyenData;
        }
    }
}
