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
    public partial class FrmPhieuBaoChuyenNgach : DevComponents.DotNetBar.Office2007Form
    {
        // Hidden files are used to store ids 
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaNgachCongChuc;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaLuongPhuCap;

        public FrmPhieuBaoChuyenNgach()
        {
            InitializeComponent();
            InitHiddenFields();
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

            // Load ngach cong chuc
            txtNgachCongChuc.Text = nhanvien.MaNgachCongChuc == null ? "" : nhanvien.NgachCongChuc.TenNgachCongChuc;
            txtMaNgachCongChuc.Text = nhanvien.MaNgachCongChuc == null ? "" : nhanvien.MaNgachCongChuc.ToString();
        }

        private void btnChonNgach_Click(object sender, EventArgs e)
        {
            FrmQuanLyNgachCongChuc frm = new FrmQuanLyNgachCongChuc();
            frm.Handler += GetNgachCongChuc;
            frm.ShowDialog();
        }

        public void GetNgachCongChuc(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaNgachCongChuc.Text = comp[0];
            txtNgachCongChuc.Text = comp[1];
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
            btnChonNgach.Focus();
            lstvData.SelectedItems.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaDonVi.Text != "" && txtMaNhanVien.Text != "")
            {
                SetDefaultMode(false);
                DisableCmdButtons();
                btnChonNgach.Focus();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var success = false;
            if (txtMaNhanVien.Text != "" && txtMaDonVi.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa dữ liệu này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Remove ngach cong chuc
                    if (txtMaNgachCongChuc.Text != "")
                    {
                        var nhanvien = NhanVienRepository.SelectByID(txtMaNhanVien.Text);
                        nhanvien.MaNgachCongChuc = null;
                        success = NhanVienRepository.Save();
                    }
                    // Remove luong, phu cap
                    var luongOfNV = LuongPhuCapRepository.SelectByMaNhanVienBaseOnThoiDiem(txtMaNhanVien.Text, dtNgay.Value)[0];
                    luongOfNV.BacLuong = null;
                    luongOfNV.HeSoLuong = null;

                    if (LuongPhuCapRepository.Save())
                    {
                        MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EraseTextboxes();
                        //LoadListOfNhanVienUpdatedOnTime();
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
            var success = false;
            if (!ValidateUserInput(ref errorText))
            {
                MessageBox.Show(errorText, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Neu nhan vien chua co ngach cong chuc, thuc hien update ngach cong chuc
            var nhanvien = NhanVienRepository.SelectByID(txtMaNhanVien.Text);
            if (nhanvien.MaNgachCongChuc == null)
            {
                if (txtMaNgachCongChuc.Text != "")
                {
                    nhanvien.MaNgachCongChuc = txtMaNgachCongChuc.Text;
                    success = NhanVienRepository.Save();
                }
            }

            var luongOfNV = LuongPhuCapRepository.SelectByMaNhanVienBaseOnThoiDiem(txtMaNhanVien.Text, dtNgay.Value);
            // Da ton tai luong phu cap cua nhan vien tai thoi diem chi dinh -> Update luong, phuc cap
            if (luongOfNV.Count > 0)
            {
                if (txtHeSo.Text != "")
                {
                    luongOfNV[0].HeSoLuong = float.Parse(txtHeSo.Text);
                }
                if (txtBacLuong.Text != "")
                {
                    luongOfNV[0].BacLuong = float.Parse(txtBacLuong.Text);
                }
                if (txtMaNgachCongChuc.Text != "")
                {
                    luongOfNV[0].MaNgachCongChuc = txtMaNgachCongChuc.Text;
                }
                success = LuongPhuCapRepository.Save();
            }
            else// chua ton tai, thuc hien the moi
            {
                var newItem = new LuongPhuCap
                {
                    MaNhanVien = txtMaNhanVien.Text,
                    NgayThangNam = dtNgay.Value
                };
                if (txtHeSo.Text != "")
                {
                    newItem.HeSoLuong = float.Parse(txtHeSo.Text);
                }
                if (txtBacLuong.Text != "")
                {
                    newItem.BacLuong = float.Parse(txtBacLuong.Text);
                }
                if (txtMaNgachCongChuc.Text != "")
                {
                    newItem.MaNgachCongChuc = txtMaNgachCongChuc.Text;
                }

                success = LuongPhuCapRepository.Insert(newItem);
            }

            if (success)
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

        private void FrmPhieuBaoChuyenNgach_Load(object sender, EventArgs e)
        {
        }


        /// <summary>
        /// Load list of phieu chuyen progresses of specified nhanvien
        /// </summary>
        public void LoadListOfNhanVienUpdatedOnTime()
        {
            var lstItem = LuongPhuCapRepository.SelectListOfNhanVienUpdatedOnTime(dtNgay.Value);
            lstvData.Items.Clear();
            for (int i = 0; i < lstItem.Count; i++)
            {
                var objListViewItem = new ListViewItem();
                objListViewItem.Tag = lstItem[i].NhanVien;
                objListViewItem.Text = (i + 1).ToString();
                objListViewItem.SubItems.Add(lstItem[i].MaNhanVien);
                objListViewItem.SubItems.Add(lstItem[i].NhanVien.HoTenKhaiSinh);
                objListViewItem.SubItems.Add(lstItem[i].NhanVien.MaGioiTinh == null ? "" : lstItem[i].NhanVien.GioiTinh.TenGioiTinh);
                objListViewItem.SubItems.Add(String.Format("{0:dd/MM/yyyy}", lstItem[i].NhanVien.NgaySinh));
                objListViewItem.SubItems.Add(lstItem[i].NhanVien.HoKhau);
                lstvData.Items.Add(objListViewItem);
            }
        }

        /// <summary>
        /// Init hidden fields
        /// </summary>
        public void InitHiddenFields()
        {
            // Add a new textbox
            txtMaNgachCongChuc = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaNgachCongChuc",
                Text = ""
            };
            txtMaNgachCongChuc.Visible = false;

            // Add a new textbox
            txtMaLuongPhuCap = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaLuongPhuCap",
                Text = ""
            };
            txtMaLuongPhuCap.Visible = false;
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

            txtNgachCongChuc.Text = nhanvien.MaNgachCongChuc == null ? "" : nhanvien.NgachCongChuc.TenNgachCongChuc;
            txtMaNgachCongChuc.Text = nhanvien.MaNgachCongChuc == null ? "" : nhanvien.MaNgachCongChuc.ToString();

            // If there's info luong and phu cap of nhanvien
            var lstItem = LuongPhuCapRepository.SelectByMaNhanVienBaseOnThoiDiem(txtMaNhanVien.Text, dtNgay.Value);
            if (lstItem.Count > 0)
            {
                txtHeSo.Text = lstItem[0].HeSoLuong.ToString();
                txtBacLuong.Text = lstItem[0].BacLuong.ToString();
            }
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
            txtMaNgachCongChuc.Text = "";
            txtNgachCongChuc.Text = "";
            txtHeSo.Text = "";
            txtBacLuong.Text = "";
        }

        /// <summary>
        /// Set default status
        /// </summary>
        /// <param name="val">default is true</param>
        public void SetDefaultMode(bool val = true)
        {
            txtHeSo.ReadOnly = val;
            txtBacLuong.ReadOnly = val;

            btnChonNhanVien.Enabled = !val;
            btnChonNgach.Enabled = !val;

            btnThem.Enabled = val;
            btnSua.Enabled = val;
            btnXoa.Enabled = val;
            btnGhi.Enabled = !val;
            btnHuy.Enabled = !val;
        }

        private void txtHeSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow type number
            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtBacLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow type number
            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
    }
}