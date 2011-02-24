using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using QuanLyHoSoCongChuc.DataLayer;
using QuanLyHoSoCongChuc.BusinessObject;

namespace QuanLyHoSoCongChuc.Controller
{
    public class HoatDongKinhTeControl
    {
        HoatDongKinhTeData m_HoatDongKinhTeData = new HoatDongKinhTeData();
        public DataTable LayDanhSachHoatDongKinhTe()
        {
            return m_HoatDongKinhTeData.LayDanhSachHoatDongKinhTe();
        }

        public void HienThiDanhSachHoatDongKinhTe(ComboBox cmb)
        {
            DataTable dt = LayDanhSachHoatDongKinhTe();
            cmb.DataSource = dt;
            cmb.DisplayMember = "TenHoatDongKinhTe";
            cmb.ValueMember = "MaHoatDongKinhTe";
        }
    }
}
