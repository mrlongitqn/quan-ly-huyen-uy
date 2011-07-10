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
using QuanLyHoSoCongChuc.OtherForms;

namespace QuanLyHoSoCongChuc.DataManager
{
    public partial class FrmPhieuBaoChuyenChinhThuc : DevComponents.DotNetBar.Office2007Form
    {
        public FrmPhieuBaoChuyenChinhThuc()
        {
            InitializeComponent();
        }

        private void btnChonDonVi_Click(object sender, EventArgs e)
        {
            FrmDanhMuc frm = new FrmDanhMuc(true);
            frm.Handler += GetDonVi;
            frm.ShowDialog();
        }

        public void GetDonVi(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaDonVi.Text = comp[0];
            txtTenDonViDayDu.Text = comp[1];
            // Load list of nhan vien updated ngach luong, bac luong, he so
            LoadListOfNhanVienUpdatedOnTime();
        }

        private void btnChonNhanVien_Click(object sender, EventArgs e)
        {
            FrmTimNhanVien frm = new FrmTimNhanVien(txtMaDonVi.Text.Trim(), GlobalPhieuBaos.GetListNhanVienLoaded(lstvData));
            frm.Handler += GetNhanVien;
            frm.ShowDialog();
        }

        public void GetNhanVien(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaNhanVien.Text = comp[0];

            // Load nhanvien info
            var nhanvien = NhanVienRepository.SelectByID(txtMaNhanVien.Text.Trim());
            txtHoTen.Text = nhanvien.HoTenKhaiSinh;
            txtGioiTinh.Text = nhanvien.MaGioiTinh == null ? "" : nhanvien.GioiTinh.TenGioiTinh;
            txtNamSinh.Text = String.Format("{0:dd/MM/yyyy}", nhanvien.NgaySinh.Value);
            txtVaoDonVi.Text = String.Format("{0:dd/MM/yyyy}", nhanvien.NgayTuyenDung.Value);
            txtTaiCoQuan.Text = nhanvien.CoQuanTuyenDung;

            //// Load ngach cong chuc
            dtNgayTuyenDungChinhThuc.Value = nhanvien.NgayTuyenDungChinhThuc.Value;
            txtTuyenDungChinhThucTaiChiBo.Text = nhanvien.TuyenDungChinhThucTaiChiBo;
            txtSoQuyetDinh.Text = nhanvien.SoQuyetDinhChuyenChinhThuc;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaDonVi.Text == "")
            {
                MessageBox.Show("Vui lòng chọn đơn vị", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            EraseTextboxes();
            SetDefaultMode(false);
            DisableCmdButtons();
            lstvData.SelectedItems.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaDonVi.Text != "" && txtMaNhanVien.Text != "")
            {
                SetDefaultMode(false);
                DisableCmdButtons();
                dtNgayTuyenDungChinhThuc.Focus();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var success = false;
            if (txtMaNhanVien.Text != "" && txtMaDonVi.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa dữ liệu này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var nhanvien = NhanVienRepository.SelectByID(txtMaNhanVien.Text);
                    nhanvien.NgayTuyenDungChinhThuc = DateTime.MinValue;
                    nhanvien.TuyenDungChinhThucTaiChiBo = "";
                    nhanvien.SoQuyetDinhChuyenChinhThuc= "";
                    success = NhanVienRepository.Save();

                    if (NhanVienRepository.Save())
                    {
                        MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EraseTextboxes();
                        LoadListOfNhanVienUpdatedOnTime();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật dữ liệu thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            string errorText = "";
            if (!ValidateUserInput(ref errorText))
            {
                MessageBox.Show(errorText, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Neu nhan vien chua co ngach cong chuc, thuc hien update ngach cong chuc
            var nhanvien = NhanVienRepository.SelectByID(txtMaNhanVien.Text);
            nhanvien.NgayTuyenDungChinhThuc = dtNgayTuyenDungChinhThuc.Value;
            nhanvien.TuyenDungChinhThucTaiChiBo = txtTuyenDungChinhThucTaiChiBo.Text;
            nhanvien.SoQuyetDinhChuyenChinhThuc = txtSoQuyetDinh.Text;

            if (NhanVienRepository.Save())
            {
                MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadListOfNhanVienUpdatedOnTime();
                SetDefaultMode(true);
            }
            else
            {
                MessageBox.Show("Cập nhật dữ liệu thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (txtMaNhanVien.Text != "")
            {
                LoadCurrentQuaTrinhInfo(txtMaNhanVien.Text, dtNgay.Value);
            }
            else
            {
                EraseTextboxes();
            }
            SetDefaultMode(true);
            btnThem.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lstvNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvData.SelectedItems.Count > 0)
            {
                LoadCurrentQuaTrinhInfo(((NhanVien)lstvData.SelectedItems[0].Tag).MaNhanVien, dtNgay.Value);
            }
        }

        private void FrmPhieuBaoChuyenChinhThuc_Load(object sender, EventArgs e)
        {
        }


        /// <summary>
        /// Load list of phieu chuyen progresses of specified nhanvien
        /// </summary>
        public void LoadListOfNhanVienUpdatedOnTime()
        {
            var lstItem = NhanVienRepository.SelectNhanVienChinhThuc(txtMaDonVi.Text);
            lstvData.Items.Clear();
            for (int i = 0; i < lstItem.Count; i++)
            {
                var objListViewItem = new ListViewItem();
                objListViewItem.Tag = lstItem[i];
                objListViewItem.Text = (i + 1).ToString();
                objListViewItem.SubItems.Add(lstItem[i].MaNhanVien);
                objListViewItem.SubItems.Add(lstItem[i].HoTenKhaiSinh);
                objListViewItem.SubItems.Add(lstItem[i].MaGioiTinh == null ? "" : lstItem[i].GioiTinh.TenGioiTinh);
                objListViewItem.SubItems.Add(String.Format("{0:dd/MM/yyyy}", lstItem[i].NgaySinh));
                objListViewItem.SubItems.Add(lstItem[i].NoiOHienNay);
                lstvData.Items.Add(objListViewItem);
            }
        }

        /// <summary>
        /// Validate user inputs
        /// </summary>
        /// <returns></returns>
        public bool ValidateUserInput(ref string errorText)
        {
            if (txtMaNhanVien.Text == "")
            {
                errorText = "Vui lòng chọn nhân viên";
                return false;
            }
            return true;
        }

        /// <summary>
        /// Load info of current quatrinh
        /// If mode is insert: update txtMaLuongPhuCap
        /// Else: not change
        /// </summary>
        public void LoadCurrentQuaTrinhInfo(string manv, DateTime time)
        {
            // Load nhanvien info
            var nhanvien = NhanVienRepository.SelectByID(manv);
            txtMaNhanVien.Text = manv;
            txtHoTen.Text = nhanvien.HoTenKhaiSinh;
            txtGioiTinh.Text = nhanvien.MaGioiTinh == null ? "" : nhanvien.GioiTinh.TenGioiTinh;
            txtNamSinh.Text = String.Format("{0:dd/MM/yyyy}", nhanvien.NgaySinh.Value);
            txtVaoDonVi.Text = String.Format("{0:dd/MM/yyyy}", nhanvien.NgayTuyenDung.Value);
            txtTaiCoQuan.Text = nhanvien.CoQuanTuyenDung;

            dtNgayTuyenDungChinhThuc.Value = nhanvien.NgayTuyenDungChinhThuc.Value;
            txtTuyenDungChinhThucTaiChiBo.Text = nhanvien.TuyenDungChinhThucTaiChiBo;
            txtSoQuyetDinh.Text = nhanvien.SoQuyetDinhChuyenChinhThuc;
        }

        /// <summary>
        /// Disable them, xoa, sua
        /// </summary>
        public void DisableCmdButtons()
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        /// <summary>
        /// Erase data in textboxes when mode is insert
        /// </summary>
        public void EraseTextboxes()
        {
            txtMaNhanVien.Text = "";
            txtHoTen.Text = "";
            txtGioiTinh.Text = "";
            txtNamSinh.Text = "";
            txtVaoDonVi.Text = "";
            txtTaiCoQuan.Text = "";
            dtNgayTuyenDungChinhThuc.Value = DateTime.MinValue;
            txtTuyenDungChinhThucTaiChiBo.Text = "";
            txtSoQuyetDinh.Text = "";
        }

        /// <summary>
        /// Set default status
        /// </summary>
        /// <param name="val">default is true</param>
        public void SetDefaultMode(bool val = true)
        {
            dtNgayTuyenDungChinhThuc.Enabled = !val;
            txtTuyenDungChinhThucTaiChiBo.ReadOnly = val;
            txtSoQuyetDinh.ReadOnly = val;

            btnChonNhanVien.Enabled = !val;

            btnThem.Enabled = val;
            btnSua.Enabled = val;
            btnXoa.Enabled = val;
            btnGhi.Enabled = !val;
            btnHuy.Enabled = !val;
        }

        private void txtSoQuyetDinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow type number
            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}