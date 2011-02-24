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
    public class HoanCanhKinhTeControl
    {
        HoanCanhKinhTeData m_HoanCanhKinhTeData = new HoanCanhKinhTeData();
        public HoanCanhKinhTeInfo LayThongTinHoanCanhKinhTe(string MaNhanVien)
        {
            return m_HoanCanhKinhTeData.LayThongTinHoanCanhKinhTe(MaNhanVien);
        }

        public void ThemHoanCanhKinhTe(HoanCanhKinhTeInfo hc)
        {
            m_HoanCanhKinhTeData.ThemHoanCanhKinhTe(hc);
        }

        public void CapNhatCanhKinhTe(HoanCanhKinhTeInfo hc)
        {
            m_HoanCanhKinhTeData.CapNhatCanhKinhTe(hc);
        }

        public void HienThiHoanCanhGiaDinh(TextBox txtTongThuNhap, TextBox txtNhaODuocCap, TextBox txtNhaOTuMua,
            TextBox txtDatDuocCap, ComboBox cmbHoatDongKinhTe, TextBox txtDienTichDatTrangTrai, TextBox txtTaiSanGiaTri,
            TextBox txtBinhQuanDauNguoi, TextBox txtDienTichSuDungNhaO, TextBox txtDienTichSuDungDat,
            TextBox txtDatTuMua, TextBox txtSoLaoDong, TextBox txtGiaTriTaiSan,
            string MaNhanVien)
        {
            HoanCanhKinhTeInfo hc = LayThongTinHoanCanhKinhTe(MaNhanVien);

            txtTongThuNhap.Text = hc.TongThuNhapGiaDinh;
            txtNhaODuocCap.Text = hc.NhaODuocCap;
            txtNhaOTuMua.Text = hc.NhaOTuMua;
            txtDatDuocCap.Text = hc.DatDuocCap;

            foreach (DataRowView itemTemp in cmbHoatDongKinhTe.Items)
            {
                if (itemTemp["MaHoatDongKinhTe"].ToString() == hc.MaHoatDongKinhTe)
                {
                    cmbHoatDongKinhTe.SelectedItem = itemTemp;
                }
            }

            txtDienTichDatTrangTrai.Text = hc.DienTichDatKinhDoanhTrangTrai;
            txtTaiSanGiaTri.Text = hc.TaiSanCoGiaTri;
            txtBinhQuanDauNguoi.Text = hc.BinhQuanDauNguoi;
            txtDienTichSuDungNhaO.Text = hc.DienTichSuDungNhaO;
            txtDienTichSuDungDat.Text = hc.DienTichSuDungDatO;
            txtDatTuMua.Text = hc.DatTuMua;
            txtSoLaoDong.Text = hc.SoLaoDongThue;
            txtGiaTriTaiSan.Text = hc.GiaTriTaiSan;
        }

        public bool KiemTraTonTaiHoanCanhNhanVien(string MaNhanVien)
        {
            return m_HoanCanhKinhTeData.KiemTraTonTaiHoanCanhNhanVien(MaNhanVien);
        }
    }
}
