using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using QuanLyHoSoCongChuc.Utils;
using QuanLyHoSoCongChuc.Repositories;
using QuanLyHoSoCongChuc.Models;
using QuanLyHoSoCongChuc.Danh_muc;

namespace QuanLyHoSoCongChuc.DataManager
{
    public partial class FrmPhieuBaoChuyenNgach : DevComponents.DotNetBar.Office2007Form
    {
        public FrmPhieuBaoChuyenNgach()
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

        private void btnChonNhanVien_Click(object sender, EventArgs e)
        {
            FrmTimNhanVien frm = new FrmTimNhanVien(txtMaDonVi.Text.Trim(), GlobalPhieuBaos.GetListNhanVienLoaded(lstvNhanVien));
            frm.Handler += GetNhanVien;
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
            if (txtMaDonVi.Text == "")
                return;
            if (txtMaNhanVien.Text == "")
                return;
            var nhanvien = NhanVienRepository.SelectByID(txtMaNhanVien.Text.Trim());
            //nhanvien.MaNgach = "";
            //nhanvien.BacLuong = "";
            //nhanvien.HeSoLuong = "";
            //if (NhanVienRepository.Save())
            //{
            //    MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    LoadNhanVienNgachLuong();
            //}
            //else
            //{
            //    MessageBox.Show("Cập nhật thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            var errorText = "";
            if (!ValidateInput(ref errorText))
            {
                MessageBox.Show(errorText, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var nhanvien = NhanVienRepository.SelectByID(txtMaNhanVien.Text.Trim());
            //nhanvien.MaNgach = ((NgachCongChuc)cbxNgachLuong.SelectedItem).MaNgachCongChuc;
            //nhanvien.BacLuong = txtBacLuong.Text.Trim();
            //nhanvien.HeSoLuong = txtHeSo.Text.Trim();
            //if (NhanVienRepository.Save())
            //{
            //    MessageBox.Show("Lập phiếu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    LoadNhanVienNgachLuong();
            //}
            //else
            //{
            //    MessageBox.Show("Lập phiếu thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lstvNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvNhanVien.SelectedItems.Count > 0)
            {
                //var nhanvien = (NhanVien)lstvNhanVien.SelectedItems[0].Tag;
                //txtMaNhanVien.Text = nhanvien.MaNhanVien;
                //txtHoTen.Text = nhanvien.HoTenKhaiSinh;
                //txtGioiTinh.Text = nhanvien.GioiTinh.TenGioiTinh;
                //txtTaiCoQuan.Text = nhanvien.DonVi.TenDonVi;
                //txtNamSinh.Text = String.Format("{0:dd/MM/yyyy}", nhanvien.NgaySinh.Value);
                //txtVaoDonVi.Text = String.Format("{0:dd/MM/yyyy}", nhanvien.NgayVeCoQuanHienTai.Value);
                
                //// Select ngachluong
                //cbxNgachLuong.SelectedIndex = -1;
                //for (int i=0; i<cbxNgachLuong.Items.Count; i++)
                //{
                //    if (((NgachCongChuc)cbxNgachLuong.Items[i]).MaNgachCongChuc == nhanvien.MaNgach)
                //    {
                //        cbxNgachLuong.SelectedIndex = i;
                //        break;
                //    }
                //}

                //txtHeSo.Text = nhanvien.HeSoLuong;
                //txtBacLuong.Text = nhanvien.BacLuong;
                //cbxNgachLuong.Enabled = false;
                //txtBacLuong.ReadOnly = true;
                //txtHeSo.ReadOnly = true;
            }
        }

        private void FrmPhieuBaoChuyenNgach_Load(object sender, EventArgs e)
        {
            LoadNgachLuong();
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
            cbxNgachLuong.Enabled = true;
            txtBacLuong.ReadOnly = false;
            txtHeSo.ReadOnly = false;
        }

        /// <summary>
        /// Load nhan vien have ngach luong, he so, bac luong
        /// </summary>
        public void LoadNhanVienNgachLuong()
        {
            var lstTmp = NhanVienRepository.SelectByMaDonVi(txtMaDonVi.Text);
            var lstItem = new List<NhanVien>();
            //foreach (var item in lstTmp)
            //{
            //    if (item.MaNgach != "" || item.BacLuong != "" || item.HeSoLuong != "")
            //    {
            //        lstItem.Add(item);
            //    }
            //}
            //if (lstItem.Count > 0)
            //{
            //    lstvNhanVien.Items.Clear();
            //    for (int i = 0; i < lstItem.Count; i++)
            //    {
            //        //var objListViewItem = new ListViewItem();
            //        //objListViewItem.Tag = lstItem[i];
            //        //objListViewItem.Text = (i + 1).ToString();
            //        //objListViewItem.SubItems.Add(lstItem[i].MaNhanVien);
            //        //objListViewItem.SubItems.Add(lstItem[i].HoTenKhaiSinh);
            //        //objListViewItem.SubItems.Add(lstItem[i].GioiTinh.TenGioiTinh);
            //        //objListViewItem.SubItems.Add(String.Format("{0:dd/MM/yyyy}", lstItem[i].NgaySinh));
            //        //objListViewItem.SubItems.Add(lstItem[i].NoiOHienTai);
            //        //lstvNhanVien.Items.Add(objListViewItem);
            //    }
            //}
        }

        /// <summary>
        /// Validate user input
        /// </summary>
        /// <returns></returns>
        public bool ValidateInput(ref string errorText)
        {
            if (cbxNgachLuong.SelectedIndex == -1)
            {
                errorText = "Vui lòng nhập ngạch lương";
                return false;
            }
            if (txtHeSo.Text == "")
            {
                errorText = "Vui lòng nhập hệ số";
                return false;
            }
            if (txtBacLuong.Text == "")
            {
                errorText = "Vui lòng nhập bậc lương";
                return false;
            }
            return true;
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
            LoadNhanVienNgachLuong();
        }

        /// <summary>
        /// Get thong tin nhan vien
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GetNhanVien(object sender, EventArgs e)
        {
            //var eventType = (MyEvent)e;
            //string[] comp = eventType.Data.Split(new char[] { '#' });
            //txtMaNhanVien.Text = comp[0];

            //// Load nhanvien info
            //var nhanvien = NhanVienRepository.SelectByID(txtMaNhanVien.Text.Trim());
            //txtHoTen.Text = nhanvien.HoTenKhaiSinh;
            //txtGioiTinh.Text = nhanvien.GioiTinh.TenGioiTinh;
            //txtTaiCoQuan.Text = nhanvien.DonVi.TenDonVi;
            //txtNamSinh.Text = String.Format("{0:dd/MM/yyyy}", nhanvien.NgaySinh.Value);
            //txtVaoDonVi.Text = String.Format("{0:dd/MM/yyyy}", nhanvien.NgayVeCoQuanHienTai.Value);
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
            cbxNgachLuong.Text = "";
            txtHeSo.Text = "";
            txtBacLuong.Text = "";
        }

        /// <summary>
        /// Load list of all ngach cong chuc
        /// </summary>
        public void LoadNgachLuong()
        {
            var lstItem = NgachCongChucRepository.SelectAll();
            if (lstItem.Count > 0)
            {
                cbxNgachLuong.DataSource = lstItem;
            }
        }
    }
}