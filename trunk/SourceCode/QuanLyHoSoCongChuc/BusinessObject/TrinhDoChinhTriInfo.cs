using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyHoSoCongChuc.BusinessObject
{
    public class BangLyLuanChinhTriInfo
    {
        public BangLyLuanChinhTriInfo()
        {
        }
        private String m_MaBangLyLuanChinhTri;
        public String MaBangLyLuanChinhTri
        {
            get { return m_MaBangLyLuanChinhTri; }
            set { m_MaBangLyLuanChinhTri = value; }
        }

        private String m_TenBangLyLuanChinhTri;
        public String TenBangLyLuanChinhTri
        {
            get { return m_TenBangLyLuanChinhTri; }
            set { m_TenBangLyLuanChinhTri = value; }
        }
    }
}

