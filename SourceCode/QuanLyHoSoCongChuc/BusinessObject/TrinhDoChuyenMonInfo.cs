using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyHoSoCongChuc.BusinessObject
{
    public class BangChuyenMonNghiepVuInfo
    {
        public BangChuyenMonNghiepVuInfo()
        {
        }
        private String m_MaBangChuyenMonNghiepVu;
        public String MaBangChuyenMonNghiepVu
        {
            get { return m_MaBangChuyenMonNghiepVu; }
            set { m_MaBangChuyenMonNghiepVu = value; }
        }

        private String m_TenBangChuyenMonNghiepVu;
        public String TenBangChuyenMonNghiepVu
        {
            get { return m_TenBangChuyenMonNghiepVu; }
            set { m_TenBangChuyenMonNghiepVu = value; }
        }
    }
}
