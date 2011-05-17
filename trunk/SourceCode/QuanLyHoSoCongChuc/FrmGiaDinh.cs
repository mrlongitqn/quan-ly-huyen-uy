using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using WeifenLuo.WinFormsUI.Docking;
using QuanLyHoSoCongChuc.Controller;
using QuanLyHoSoCongChuc.BusinessObject;

namespace QuanLyHoSoCongChuc
{
    public partial class FrmGiaDinh : DockContent
    {
        GiaDinhControl m_GiaDinhControl = new GiaDinhControl();
        ThanNhanMoiControl m_ThanNhanMoiControl = new ThanNhanMoiControl();
        HoanCanhKinhTeControl m_HoanCanhKinhTeControl = new HoanCanhKinhTeControl();
        HoatDongKinhTeControl m_HoatDongKinhTeControl = new HoatDongKinhTeControl();
        public FrmGiaDinh()
        {
            InitializeComponent();
        }

        private void FrmGiaDinh_Load(object sender, EventArgs e)
        {
            m_GiaDinhControl.HienThiDSNhanVien(cmbHoTen);
            m_GiaDinhControl.HienThiDSGioiTinh(cmbGioiTinh);
            m_ThanNhanMoiControl.HienThiDanhSachThanNhanDayDu(dgvThanNhan, cmbHoTen.SelectedValue.ToString());

            m_HoatDongKinhTeControl.HienThiDanhSachHoatDongKinhTe(cmbHoatDongKinhTe);

            m_HoanCanhKinhTeControl.HienThiHoanCanhGiaDinh(txtTongThuNhap, txtNhaODuocCap, txtNhaOTuMua, txtDatDuocCap, cmbHoatDongKinhTe, txtDienTichDatKinhDoanhTrangTrai, txtTaiSanGiaTri, txtBinhQuanDauNguoi, txtDienTichSuDungNhaO, txtDienTichSuDungDat, txtDatTuMua, txtSoLaoDongThue, txtGiaTriTaiSan, cmbHoTen.SelectedValue.ToString());
            
        }

        private void cmbHoTen_SelectedIndexChanged(object sender, EventArgs e)
        {
            string MaNhanVien = ((ComboBox)sender).SelectedValue.ToString();
            string TenNhanVien = ((ComboBox)sender).Text.ToString();

            if (string.IsNullOrEmpty(MaNhanVien) == false)
            {
                string MaGioiTinh = m_GiaDinhControl.LayMaGioiTinhNhanVien(MaNhanVien);
                DateTime NgaySinh = m_GiaDinhControl.LayNgaySinhNhanVien(MaNhanVien);
                foreach (DataRowView rvTemp in cmbGioiTinh.Items)
                {
                    if (rvTemp["MaGioiTinh"].ToString() == MaGioiTinh)
                    {
                        cmbGioiTinh.SelectedItem = rvTemp;
                    }
                }

                dtpSinhNgay.Value = NgaySinh;

                m_ThanNhanMoiControl.HienThiDanhSachThanNhanDayDu(dgvThanNhan, MaNhanVien);

                m_HoanCanhKinhTeControl.HienThiHoanCanhGiaDinh(txtTongThuNhap, txtNhaODuocCap, txtNhaOTuMua, txtDatDuocCap, cmbHoatDongKinhTe, txtDienTichDatKinhDoanhTrangTrai, txtTaiSanGiaTri, txtBinhQuanDauNguoi, txtDienTichSuDungNhaO, txtDienTichSuDungDat, txtDatTuMua, txtSoLaoDongThue, txtGiaTriTaiSan, cmbHoTen.SelectedValue.ToString());
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            FrmNhapQuanHeGiaDinh frm = new FrmNhapQuanHeGiaDinh();
            frm.MaNhanVien = cmbHoTen.SelectedValue.ToString();
            frm.Show();
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            HoanCanhKinhTeInfo hc = new HoanCanhKinhTeInfo();

            hc.MaNhanVien = cmbHoTen.SelectedValue.ToString();
            hc.TongThuNhapGiaDinh = txtTongThuNhap.Text;
            hc.NhaODuocCap = txtNhaODuocCap.Text;
            hc.NhaOTuMua = txtNhaOTuMua.Text;
            hc.DatDuocCap = txtDatDuocCap.Text;            
            if (cmbHoatDongKinhTe.SelectedValue != null)
            {
                hc.MaHoatDongKinhTe = cmbHoatDongKinhTe.SelectedValue.ToString();
            }
            hc.DienTichDatKinhDoanhTrangTrai = txtDienTichDatKinhDoanhTrangTrai.Text;
            hc.TaiSanCoGiaTri = txtTaiSanGiaTri.Text;
            hc.BinhQuanDauNguoi = txtBinhQuanDauNguoi.Text;
            hc.DienTichSuDungNhaO = txtDienTichSuDungNhaO.Text;
            hc.DienTichSuDungDatO = txtDienTichSuDungDat.Text;
            hc.DatTuMua = txtDatTuMua.Text;
            hc.SoLaoDongThue = txtSoLaoDongThue.Text;
            hc.GiaTriTaiSan = txtGiaTriTaiSan.Text;

            if (m_HoanCanhKinhTeControl.KiemTraTonTaiHoanCanhNhanVien(hc.MaNhanVien) == true)
            {
                m_HoanCanhKinhTeControl.CapNhatCanhKinhTe(hc);
            }
            else
            {
                m_HoanCanhKinhTeControl.ThemHoanCanhKinhTe(hc);
            }

            m_HoanCanhKinhTeControl.HienThiHoanCanhGiaDinh(txtTongThuNhap, txtNhaODuocCap, txtNhaOTuMua, txtDatDuocCap, cmbHoatDongKinhTe, txtDienTichDatKinhDoanhTrangTrai, txtTaiSanGiaTri, txtBinhQuanDauNguoi, txtDienTichSuDungNhaO, txtDienTichSuDungDat, txtDatTuMua, txtSoLaoDongThue, txtGiaTriTaiSan, cmbHoTen.SelectedValue.ToString());
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
