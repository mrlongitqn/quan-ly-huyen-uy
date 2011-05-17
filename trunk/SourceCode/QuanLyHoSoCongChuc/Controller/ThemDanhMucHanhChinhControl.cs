using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLyHoSoCongChuc.DataLayer;
using QuanLyHoSoCongChuc.BusinessObject;
using System.Data;
using System.Windows.Forms;

namespace QuanLyHoSoCongChuc.Controller
{
    public class ThemDanhMucHanhChinhControl
    {
        TinhThanhData m_TinhThanhData = new TinhThanhData();
        QuanHuyenData m_QuanHuyenData = new QuanHuyenData();
        PhuongXaData m_PhuongXaData = new PhuongXaData();
        KhoiXomData m_KhoiXomData = new KhoiXomData();

        public PhuongXaData PhuongXaData
        {
            get { return m_PhuongXaData; }
            set { m_PhuongXaData = value; }
        }
        
        public KhoiXomData KhoiXomData
        {
            get { return m_KhoiXomData; }
            set { m_KhoiXomData = value; }
        }

        public TinhThanhData TinhThanhData
        {
            get { return m_TinhThanhData; }
            set { m_TinhThanhData = value; }
        }

        public QuanHuyenData QuanHuyenData
        {
            get { return m_QuanHuyenData; }
            set { m_QuanHuyenData = value; }
        }

        public enum KieuHanhChinh
        {
            TinhThanh = 1,
            QuanHuyen = 2,
            PhuongXa = 3,
            KhoiXom = 4
        }

        public void HienThiComboBox(ComboBox cmb, DataTable dt, KieuHanhChinh d)
        {
            cmb.DataSource = dt;
            switch (d)
            {
                case KieuHanhChinh.TinhThanh:
                    cmb.ValueMember = "MaTinh";
                    cmb.DisplayMember = "TenTinh";
                    break;
                case KieuHanhChinh.QuanHuyen:
                    cmb.ValueMember = "MaQuanHuyen";
                    cmb.DisplayMember = "TenQuanHuyen";
                    break;
                case KieuHanhChinh.PhuongXa:
                    cmb.ValueMember = "MaPhuongXa";
                    cmb.DisplayMember = "TenPhuongXa";
                    break;
                case KieuHanhChinh.KhoiXom:
                    cmb.ValueMember = "MaKhoiXom";
                    cmb.DisplayMember = "TenKhoiXom";
                    break;
            }
        }

        public bool KiemTraTonTaiTinhThanhTheoMa(string MaTinh)
        {
            bool bResult = false;
            bResult = m_TinhThanhData.KiemTraTonTaiTinhThanhTheoMa(MaTinh);
            return bResult;
        }

        public bool KiemTraTonTaiQuanHuyenTheoMa(string MaQuanHuyen)
        {
            bool bResult = false;
            bResult = m_QuanHuyenData.KiemTraTonTaiQuanHuyenTheoMa(MaQuanHuyen);
            return bResult;
        }

        public bool KiemTraTonTaiPhuongXaTheoMa(string MaPhuongXa)
        {
            bool bResult = false;
            bResult = m_PhuongXaData.KiemTraTonTaiPhuongXaTheoMa(MaPhuongXa);
            return bResult;
        }

        public bool KiemTraTonTaiKhoiXomTheoMa(string MaKhoiXom)
        {
            bool bResult = false;
            bResult = m_KhoiXomData.KiemTraTonTaiKhoiXomTheoMa(MaKhoiXom);
            return bResult;
        }


        public int ThemTinhThanhMoi(TinhThanhInfo TinhThanhObj)
        {
            int iResult = 0;
            iResult = m_TinhThanhData.ThemTinhThanhMoi(TinhThanhObj);
            return iResult;
        }

        public int ThemQuanHuyenMoi(QuanHuyenInfo QuanHuyenObj)
        {
            int iResult = 0;
            iResult = m_QuanHuyenData.ThemQuanHuyenMoi(QuanHuyenObj);
            return iResult;
        }


        public int ThemPhuongXaMoi(PhuongXaInfo PhuongXaObj)
        {
            int iResult = 0;
            iResult = m_PhuongXaData.ThemPhuongXaMoi(PhuongXaObj);
            return iResult;
        }

        public int ThemKhoiXomMoi(KhoiXomInfo KhoiXomObj)
        {
            int iResult = 0;
            iResult = m_KhoiXomData.ThemKhoiXomMoi(KhoiXomObj);
            return iResult;
        }


        public DataTable CapNhatTinhThanh(TinhThanhInfo TinhThanhObj)
        {
            DataTable dt = m_TinhThanhData.CapNhatTinhThanh(TinhThanhObj);
            return dt;
        }

        public DataTable CapNhatQuanHuyen(QuanHuyenInfo QuanHuyenObj)
        {
            DataTable dt = m_QuanHuyenData.CapNhatQuanHuyen(QuanHuyenObj);
            return dt;
        }

        public DataTable CapNhatPhuongXa(PhuongXaInfo PhuongXaObj)
        {
            DataTable dt = m_PhuongXaData.CapNhatPhuongXa(PhuongXaObj);
            return dt;
        }

        public DataTable CapNhatKhoiXom(KhoiXomInfo KhoiXomObj)
        {
            DataTable dt = m_KhoiXomData.CapNhatKhoiXom(KhoiXomObj);
            return dt;
        }


        public DataTable XoaKhoiXom(string MaKhoiXom)
        {
            DataTable dt = m_KhoiXomData.XoaKhoiXom(MaKhoiXom);
            return dt;
        }

        public DataTable XoaPhuongXa(string MaPhuongXa)
        {
            DataTable dt;
            dt = m_KhoiXomData.XoaKhoiXomTheoMaPhuongXa(MaPhuongXa);
            dt = m_PhuongXaData.XoaPhuongXa(MaPhuongXa);
            return dt;
        }

        public DataTable XoaQuanHuyen(string MaQuanHuyen)
        {
            DataTable dt = m_PhuongXaData.LayDSPhuongXaTheoMaQuanHuyen(MaQuanHuyen);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {                    
                    XoaPhuongXa(row["MaPhuongXa"].ToString());
                    if (dt.Rows.Count == 0)
                    {
                        break;
                    }
                }
            }

            m_QuanHuyenData.XoaQuanHuyen(MaQuanHuyen);

            return dt;
        }


        public DataTable XoaTinhThanh(string MaTinhThanh)
        {
            DataTable dt = m_QuanHuyenData.LayDanhSachQuanHuyenThemMaTinh(MaTinhThanh);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    XoaQuanHuyen(row["MaTinh"].ToString());
                    if (dt.Rows.Count == 0)
                    {
                        break;
                    }
                }
            }

            m_TinhThanhData.XoaTinhThanh(MaTinhThanh);

            return dt;
        }
    }
}
