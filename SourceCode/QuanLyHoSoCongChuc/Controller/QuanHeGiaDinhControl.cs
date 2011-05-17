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
    public class QuanHeGiaDinhControl
    {
        NhanVienData m_NhanVienData = new NhanVienData();

        public string LayIDDangVien(string MaNhanVien)
        {
            return m_NhanVienData.LayIDDangVien(MaNhanVien);
        }
        public string LayTenNhanVien(string MaNhanVien)
        {
            return m_NhanVienData.LayTenNhanVien(MaNhanVien);
        }

    }
}
