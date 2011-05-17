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
    public class GiaDinhControl
    {
        NhanVienData m_NhanVienData = new NhanVienData();
        GioiTinhCotrol m_GioiTinhControl = new GioiTinhCotrol();

        public DataTable LayDanhSachNhanVien()
        {
            DataTable dt = m_NhanVienData.LayDSNhanVien();
            return dt;
        }

        public void HienThiDSNhanVien(ComboBox cmb)
        {
            DataTable dt = LayDanhSachNhanVien();
            cmb.DataSource = dt;
            cmb.DisplayMember = "HoTenNhanVien";
            cmb.ValueMember = "MaNhanVien";
        }

        public void HienThiDSGioiTinh(ComboBox cmb)
        {
            m_GioiTinhControl.HienThiDanhSachGioiTinh(cmb);
        }

        public DateTime LayNgaySinhNhanVien(string MaNhanVien)
        {
            return m_NhanVienData.LayNgaySinhNhanVien(MaNhanVien);
        }

        public string LayMaGioiTinhNhanVien(string MaNhanVien)
        {
            return m_NhanVienData.LayGioiTinhNhanVien(MaNhanVien);
        }
    }
}
