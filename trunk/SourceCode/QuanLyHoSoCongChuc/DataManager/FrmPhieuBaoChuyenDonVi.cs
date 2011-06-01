using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using QuanLyHoSoCongChuc.Utils;
using QuanLyHoSoCongChuc.Models;
using QuanLyHoSoCongChuc.Repositories;

namespace QuanLyHoSoCongChuc.DataManager
{
    public partial class FrmPhieuBaoChuyenDonVi : DevComponents.DotNetBar.Office2007Form
    {
        public FrmPhieuBaoChuyenDonVi()
        {
            InitializeComponent();
        }

        private void btnChonDonVi_Click(object sender, EventArgs e)
        {
            FrmDanhMuc frm = new FrmDanhMuc();
            frm.Handler += GetDonVi;
            frm.EnableButtonChon = true;
            frm.ShowDialog();
        }

        private void lstvNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnChonNhanVien_Click(object sender, EventArgs e)
        {
            FrmTimNhanVien frm = new FrmTimNhanVien(txtMaDonVi.Text.Trim(), GlobalPhieuBaos.GetListNhanVienLoaded(lstvNhanVien));
            frm.Handler += GetNhanVien;
            frm.ShowDialog();
        }

        private void btnChonDonViChuyenDen_Click(object sender, EventArgs e)
        {
            FrmDanhMuc frm = new FrmDanhMuc();
            frm.Handler += GetDonViChuyenDen;
            frm.EnableButtonChon = true;
            frm.ShowDialog();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaDonVi.Text == "")
            {
                MessageBox.Show("Vui lòng chọn đơn vị", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            EnableUpdateMode(EnumUpdateMode.INSERT);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaDonVi.Text == "")
                return;
            if (txtMaNhanVien.Text == "")
                return;
            EnableUpdateMode(EnumUpdateMode.UPDATE);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnGhi_Click(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void ResetForm()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnGhi.Enabled = false;
            btnHuy.Enabled = false;
            btnChonNhanVien.Enabled = false;
            txtMaNhanVien.Text = "";
            txtHoTen.Text = "";
            txtGioiTinh.Text = "";
            txtTaiCoQuan.Text = "";
            btnChonDonViChuyenDen.Enabled = false;
        }

        public void EnableUpdateMode(EnumUpdateMode mode)
        {
            if (mode == EnumUpdateMode.INSERT)
                btnChonNhanVien.Enabled = true;
            else if (mode == EnumUpdateMode.UPDATE)
                btnChonNhanVien.Enabled = false;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnGhi.Enabled = true;
            btnHuy.Enabled = true;
            btnChonDonViChuyenDen.Enabled = true;
        }

        /// <summary>
        /// Get thong tin nhan vien
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GetNhanVien(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaNhanVien.Text = comp[0];

            // Load nhanvien info
            var nhanvien = NhanVienRepository.SelectByID(txtMaNhanVien.Text.Trim());
            txtHoTen.Text = nhanvien.HoTenNhanVien;
            txtGioiTinh.Text = nhanvien.GioiTinh.TenGioiTinh;
            txtTaiCoQuan.Text = nhanvien.DonVi.TenDonVi;
            txtNamSinh.Text = String.Format("{0:dd/MM/yyyy}", nhanvien.NgaySinh.Value);
            txtVaoDonVi.Text = String.Format("{0:dd/MM/yyyy}", nhanvien.NgayVeCoQuanHienTai.Value);
        }

        /// <summary>
        /// Get thong tin don vi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GetDonVi(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaDonVi.Text = comp[0];
            txtTenDonViDayDu.Text = comp[1];
            // Load list of nhan vien updated ngach luong, bac luong, he so
            //LoadNhanVienPhuCap();
        }

        /// <summary>
        /// Get thong tin don vi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GetDonViChuyenDen(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtDonViChuyenDen.Text = comp[0];
            txtTenDonViChuyenDenDayDu.Text = comp[1];
        }
    }
}