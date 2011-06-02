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
using QuanLyHoSoCongChuc.Danh_muc;

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
            if (lstvNhanVien.SelectedItems.Count > 0)
            {
                var nhanvienchuyendi = (ChuyenDonVi)lstvNhanVien.SelectedItems[0].Tag;
                txtMaNhanVien.Text = nhanvienchuyendi.MaNhanVien;
                txtHoTen.Text = nhanvienchuyendi.NhanVien.HoTenNhanVien;
                txtGioiTinh.Text = nhanvienchuyendi.NhanVien.GioiTinh.TenGioiTinh;
                txtTaiCoQuan.Text = nhanvienchuyendi.NhanVien.DonVi.TenDonVi;
                txtNamSinh.Text = String.Format("{0:dd/MM/yyyy}", nhanvienchuyendi.NhanVien.NgaySinh.Value);
                txtVaoDonVi.Text = String.Format("{0:dd/MM/yyyy}", nhanvienchuyendi.NhanVien.NgayVeCoQuanHienTai.Value);
                txtDonViChuyenDen.Text = nhanvienchuyendi.MaDonViDen;
                txtTenDonViChuyenDenDayDu.Text = DonViRepository.SelectByID(nhanvienchuyendi.MaDonViDen).TenDonVi;
            }
        }

        private void btnChonNhanVien_Click(object sender, EventArgs e)
        {
            FrmTimNhanVien frm = new FrmTimNhanVien(txtMaDonVi.Text.Trim(), GlobalPhieuBaos.GetListNhanVienChuyenDiLoaded(lstvNhanVien));
            frm.Handler += GetNhanVien;
            frm.ShowDialog();
        }

        private void btnChonDonViChuyenDen_Click(object sender, EventArgs e)
        {
            FrmChonDanhMucAll frm = new FrmChonDanhMucAll();
            frm.Handler += GetDonViChuyenDen;
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

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            var errorText = "";
            if (!ValidateInput(ref errorText))
            {
                MessageBox.Show(errorText, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Execute the operation through 2 step:
            // Step1: update madonvi for nhanvien
            string madonviOld;
            var nhanvien = NhanVienRepository.SelectByID(txtMaNhanVien.Text.Trim());
            madonviOld = nhanvien.MaDonVi;
            nhanvien.MaDonVi = txtDonViChuyenDen.Text.Trim();
            if (NhanVienRepository.Save())
            {
                // Step2: insert new record to ChuyenDonVi table
                var nhanvienchuyendi = new ChuyenDonVi
                {
                    MaNhanVien = nhanvien.MaNhanVien,
                    MaDonViDi = madonviOld,
                    MaDonViDen = txtDonViChuyenDen.Text.Trim()
                };
                if (ChuyenDonViRepository.Insert(nhanvienchuyendi))
                {
                    MessageBox.Show("Lập phiếu chuyển đơn vị thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadNhanVienChuyenDi();
                }
            }
            else
            {
                MessageBox.Show("Lập phiếu chuyển đơn vị thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Validate user input
        /// </summary>
        /// <returns></returns>
        public bool ValidateInput(ref string errorText)
        {
            if (txtMaNhanVien.Text == "")
            {
                errorText = "Vui lòng chọn nhân viên";
                return false;
            }
            if (txtDonViChuyenDen.Text == "")
            {
                errorText = "Vui lòng chọn đơn vị chuyển đến";
                return false;
            }
            return true;
        }

        public void ResetForm()
        {
            btnThem.Enabled = true;
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
            LoadNhanVienChuyenDi();
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

        /// <summary>
        /// Load list of nhan vien moved out of donvi
        /// </summary>
        public void LoadNhanVienChuyenDi()
        {
            var lstItem = ChuyenDonViRepository.SelectByMaDonViDi(txtMaDonVi.Text);
            if (lstItem.Count > 0)
            {
                lstvNhanVien.Items.Clear();
                for (int i = 0; i < lstItem.Count; i++)
                {
                    var objListViewItem = new ListViewItem();
                    objListViewItem.Tag = lstItem[i];
                    objListViewItem.Text = (i + 1).ToString();
                    objListViewItem.SubItems.Add(lstItem[i].MaNhanVien);
                    objListViewItem.SubItems.Add(lstItem[i].NhanVien.HoTenNhanVien);
                    objListViewItem.SubItems.Add(lstItem[i].NhanVien.GioiTinh.TenGioiTinh);
                    objListViewItem.SubItems.Add(String.Format("{0:dd/MM/yyyy}", lstItem[i].NhanVien.NgaySinh));
                    objListViewItem.SubItems.Add(lstItem[i].NhanVien.NoiOHienTai);
                    lstvNhanVien.Items.Add(objListViewItem);
                }
            }
        }
    }
}