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
    public class KhoiXomData
    {
        DataService m_KhoiXomData = new DataService();
        public DataTable LayDSKhoiXom()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM KhoiXom");
            if (m_KhoiXomData.ExecuteNoneQuery(cmd) == 0)
            {
                return null;
            }
            m_KhoiXomData.Load(cmd);
            return m_KhoiXomData;
        }

        public DataTable LayDSKhoiXomTheoMaPhuongXa(string MaPhuongXa)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM KhoiXom WHERE MaPhuongXa = '" + MaPhuongXa + "'");
            if (m_KhoiXomData.ExecuteNoneQuery(cmd) == 0)
            {
                return null;
            }
            m_KhoiXomData.Load(cmd);
            return m_KhoiXomData;
        }

        public DataTable LayDSKhoiXomTheoTenPhuongXa(string TenPhuongXa)
        {
            SqlCommand cmd = new SqlCommand("SELECT k.MaKhoiXom, k.TenKhoiXom FROM KhoiXom k, PhuongXa p WHERE k.MaPhuongXa = p.MaPhuongXa and p.TenPhuongXa = '" + TenPhuongXa + "'");
            if (m_KhoiXomData.ExecuteNoneQuery(cmd) == 0)
            {
                return null;
            }
            m_KhoiXomData.Load(cmd);           
            return m_KhoiXomData;
        }

        public bool KiemTraTonTaiKhoiXomTheoMa(string MaKhoiXom)
        {
            bool bResult = false;
            SqlCommand cmd = new SqlCommand("SELECT * FROM KhoiXom WHERE MaKhoiXom = '" + MaKhoiXom + "'");
            if (m_KhoiXomData.ExecuteNoneQuery(cmd) == 0)
            {
                return false;
            }
            m_KhoiXomData.Load(cmd);
            if (m_KhoiXomData.Rows.Count > 0)
            {
                bResult = true;
            }
            return bResult;
        }


        public int ThemKhoiXomMoi(KhoiXomInfo KhoiXomObj)
        {
            int iResult = 0;
            SqlCommand cmd = new SqlCommand("Insert Into KhoiXom (MaKhoiXom, TenKhoiXom, MaPhuongXa) VALUES (@MaKhoiXom, @TenKhoiXom, @MaPhuongXa)");
            cmd.Parameters.Add("@MaKhoiXom", SqlDbType.NVarChar, 10).Value = KhoiXomObj.MaKhoiXom;
            cmd.Parameters.Add("@TenKhoiXom", SqlDbType.NVarChar, 50).Value = KhoiXomObj.TenKhoiXom;
            cmd.Parameters.Add("@MaPhuongXa", SqlDbType.NVarChar, 10).Value = KhoiXomObj.MaPhuongXa;
            iResult = m_KhoiXomData.ExecuteNoneQuery(cmd);
            return iResult;
        }


        public DataTable CapNhatKhoiXom(KhoiXomInfo KhoiXomObj)
        {
            SqlCommand cmd = new SqlCommand("UPDATE KhoiXom SET TenKhoiXom = @TenKhoiXom WHERE MaKhoiXom = @MaKhoiXom");
            cmd.Parameters.Add("@TenKhoiXom", SqlDbType.NVarChar, 50).Value = KhoiXomObj.TenKhoiXom;
            cmd.Parameters.Add("@MaKhoiXom", SqlDbType.NVarChar, 10).Value = KhoiXomObj.MaKhoiXom;
            m_KhoiXomData.Load(cmd);
            return m_KhoiXomData;
        }

        public DataTable XoaKhoiXom(string MaKhoiXom)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM KhoiXom WHERE MaKhoiXom = @MaKhoiXom");            
            cmd.Parameters.Add("@MaKhoiXom", SqlDbType.NVarChar, 10).Value = MaKhoiXom;
            m_KhoiXomData.Load(cmd);
            return m_KhoiXomData;
        }

        public DataTable XoaKhoiXomTheoMaPhuongXa(string MaPhuongXa)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM KhoiXom WHERE MaPhuongXa = @MaPhuongXa");
            cmd.Parameters.Add("@MaPhuongXa", SqlDbType.NVarChar, 10).Value = MaPhuongXa;
            m_KhoiXomData.Load(cmd);
            return m_KhoiXomData;
        }
    }
}
