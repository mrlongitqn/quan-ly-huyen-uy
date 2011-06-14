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
    public partial class FrmPhieuBaoPhuCap : DevComponents.DotNetBar.Office2007Form
    {
        public FrmPhieuBaoPhuCap()
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

            txtChucVu.Text = nhanvien.MaChucVu == null ? "" : ChucVuRepository.SelectByID(nhanvien.MaChucVu.Value).TenChucVu;
            txtChucVuKiemNhiem.Text = nhanvien.MaChucVuKiemNhiem == null ? "" : ChucVuRepository.SelectByID(nhanvien.MaChucVuKiemNhiem.Value).TenChucVu;
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
            txtPhuCapChucVu.Focus();
            lstvData.SelectedItems.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaDonVi.Text != "" && txtMaNhanVien.Text != "")
            {
                SetDefaultMode(false);
                DisableCmdButtons();
                txtPhuCapChucVu.Focus();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNhanVien.Text != "" && txtMaDonVi.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa dữ liệu này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Remove luong, phu cap
                    var luongOfNV = LuongPhuCapRepository.SelectByMaNhanVienBaseOnThoiDiem(txtMaNhanVien.Text, dtNgay.Value)[0];
                    luongOfNV.HeSoPhuCapChucVu = null;
                    luongOfNV.HeSoPhuCapKiemNhiem = null;
                    luongOfNV.HeSoPhuCapThamNienVuotKhung = null;
                    luongOfNV.HeSoPhuCapKhac = null;
                    luongOfNV.HeSoPhuCapThamNienNghe = null;
                    luongOfNV.HeSoPhuCapKhuVuc = null;
                    luongOfNV.HeSoPhuCapPhanLoaiXa = null;
                    luongOfNV.HeSoPhuCapTrachNhiem = null;
                    luongOfNV.HeSoPhuCapDocHai = null;
                    luongOfNV.HeSoPhuCapUuDaiNghe = null;

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

            var luongOfNV = LuongPhuCapRepository.SelectByMaNhanVienBaseOnThoiDiem(txtMaNhanVien.Text, dtNgay.Value);
            // Da ton tai luong phu cap cua nhan vien tai thoi diem chi dinh -> Update luong, phuc cap
            if (luongOfNV.Count > 0)
            {
                if (txtPhuCapChucVu.Text != "")
                {
                    luongOfNV[0].HeSoPhuCapChucVu = float.Parse(txtPhuCapChucVu.Text);
                }
                if (txtPhuCapKiemNhiem.Text != "")
                {
                    luongOfNV[0].HeSoPhuCapKiemNhiem = float.Parse(txtPhuCapKiemNhiem.Text);
                }
                if (txtPhuCapThamNienVuotKhung.Text != "")
                {
                    luongOfNV[0].HeSoPhuCapThamNienVuotKhung = float.Parse(txtPhuCapThamNienVuotKhung.Text);
                }
                if (txtPhuCapKhac.Text != "")
                {
                    luongOfNV[0].HeSoPhuCapKhac = float.Parse(txtPhuCapKhac.Text);
                }
                if (txtPhuCapThamNienNghe.Text != "")
                {
                    luongOfNV[0].HeSoPhuCapThamNienNghe = float.Parse(txtPhuCapThamNienNghe.Text);
                }
                if (txtPhuCapKhuVuc.Text != "")
                {
                    luongOfNV[0].HeSoPhuCapKhuVuc = float.Parse(txtPhuCapKhuVuc.Text);
                }
                if (txtPhuCapPhanLoaiXa.Text != "")
                {
                    luongOfNV[0].HeSoPhuCapPhanLoaiXa = float.Parse(txtPhuCapPhanLoaiXa.Text);
                }
                if (txtPhuCapTrachNhiem.Text != "")
                {
                    luongOfNV[0].HeSoPhuCapTrachNhiem = float.Parse(txtPhuCapTrachNhiem.Text);
                }
                if (txtPhuCapDocHai.Text != "")
                {
                    luongOfNV[0].HeSoPhuCapDocHai = float.Parse(txtPhuCapDocHai.Text);
                }
                if (txtPhuCapUuDaiNghe.Text != "")
                {
                    luongOfNV[0].HeSoPhuCapUuDaiNghe = float.Parse(txtPhuCapUuDaiNghe.Text);
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

                if (txtPhuCapChucVu.Text != "")
                {
                    newItem.HeSoPhuCapChucVu = float.Parse(txtPhuCapChucVu.Text);
                }
                if (txtPhuCapKiemNhiem.Text != "")
                {
                    newItem.HeSoPhuCapKiemNhiem = float.Parse(txtPhuCapKiemNhiem.Text);
                }
                if (txtPhuCapThamNienVuotKhung.Text != "")
                {
                    newItem.HeSoPhuCapThamNienVuotKhung = float.Parse(txtPhuCapThamNienVuotKhung.Text);
                }
                if (txtPhuCapKhac.Text != "")
                {
                    newItem.HeSoPhuCapKhac = float.Parse(txtPhuCapKhac.Text);
                }
                if (txtPhuCapThamNienNghe.Text != "")
                {
                    newItem.HeSoPhuCapThamNienNghe = float.Parse(txtPhuCapThamNienNghe.Text);
                }
                if (txtPhuCapKhuVuc.Text != "")
                {
                    newItem.HeSoPhuCapKhuVuc = float.Parse(txtPhuCapKhuVuc.Text);
                }
                if (txtPhuCapPhanLoaiXa.Text != "")
                {
                    newItem.HeSoPhuCapPhanLoaiXa = float.Parse(txtPhuCapPhanLoaiXa.Text);
                }
                if (txtPhuCapTrachNhiem.Text != "")
                {
                    newItem.HeSoPhuCapTrachNhiem = float.Parse(txtPhuCapTrachNhiem.Text);
                }
                if (txtPhuCapDocHai.Text != "")
                {
                    newItem.HeSoPhuCapDocHai = float.Parse(txtPhuCapDocHai.Text);
                }
                if (txtPhuCapUuDaiNghe.Text != "")
                {
                    newItem.HeSoPhuCapUuDaiNghe = float.Parse(txtPhuCapUuDaiNghe.Text);
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
                objListViewItem.SubItems.Add(lstItem[i].NhanVien.NoiOHienNay);
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

            txtChucVu.Text = nhanvien.MaChucVu == null ? "" : ChucVuRepository.SelectByID(nhanvien.MaChucVu.Value).TenChucVu;
            txtChucVuKiemNhiem.Text = nhanvien.MaChucVuKiemNhiem == null ? "" : ChucVuRepository.SelectByID(nhanvien.MaChucVuKiemNhiem.Value).TenChucVu;

            // If there's info luong and phu cap of nhanvien
            var lstItem = LuongPhuCapRepository.SelectByMaNhanVienBaseOnThoiDiem(txtMaNhanVien.Text, dtNgay.Value);
            if (lstItem.Count > 0)
            {
                txtPhuCapChucVu.Text = lstItem[0].HeSoPhuCapChucVu.ToString();
                txtPhuCapKiemNhiem.Text = lstItem[0].HeSoPhuCapKiemNhiem.ToString();
                txtPhuCapThamNienVuotKhung.Text = lstItem[0].HeSoPhuCapThamNienVuotKhung.ToString();
                txtPhuCapKhac.Text = lstItem[0].HeSoPhuCapKhac.ToString();
                txtPhuCapThamNienNghe.Text = lstItem[0].HeSoPhuCapThamNienNghe.ToString();
                txtPhuCapKhuVuc.Text = lstItem[0].HeSoPhuCapKhuVuc.ToString();
                txtPhuCapPhanLoaiXa.Text = lstItem[0].HeSoPhuCapPhanLoaiXa.ToString();
                txtPhuCapTrachNhiem.Text = lstItem[0].HeSoPhuCapTrachNhiem.ToString();
                txtPhuCapDocHai.Text = lstItem[0].HeSoPhuCapDocHai.ToString();
                txtPhuCapUuDaiNghe.Text = lstItem[0].HeSoPhuCapUuDaiNghe.ToString();
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

            txtPhuCapChucVu.Text = "";
            txtPhuCapKiemNhiem.Text = "";
            txtPhuCapThamNienVuotKhung.Text = "";
            txtPhuCapKhac.Text = "";
            txtPhuCapThamNienNghe.Text = "";
            txtPhuCapKhuVuc.Text = "";
            txtPhuCapPhanLoaiXa.Text = "";
            txtPhuCapTrachNhiem.Text = "";
            txtPhuCapDocHai.Text = "";
            txtPhuCapUuDaiNghe.Text = "";
        }

        /// <summary>
        /// Set default status
        /// </summary>
        /// <param name="val">default is true</param>
        public void SetDefaultMode(bool val = true)
        {
            txtPhuCapChucVu.ReadOnly = val;
            txtPhuCapKiemNhiem.ReadOnly = val;
            txtPhuCapThamNienVuotKhung.ReadOnly = val;
            txtPhuCapKhac.ReadOnly = val;
            txtPhuCapThamNienNghe.ReadOnly = val;
            txtPhuCapKhuVuc.ReadOnly = val;
            txtPhuCapPhanLoaiXa.ReadOnly = val;
            txtPhuCapTrachNhiem.ReadOnly = val;
            txtPhuCapDocHai.ReadOnly = val;
            txtPhuCapUuDaiNghe.ReadOnly = val;

            btnChonNhanVien.Enabled = !val;

            btnThem.Enabled = val;
            btnSua.Enabled = val;
            btnXoa.Enabled = val;
            btnGhi.Enabled = !val;
            btnHuy.Enabled = !val;
        }

        public void InitKeysPressEvent()
        {
            txtPhuCapChucVu.KeyPress += NavigationChildControl_KeyPress;
            txtPhuCapKiemNhiem.KeyPress += NavigationChildControl_KeyPress;
            txtPhuCapThamNienVuotKhung.KeyPress += NavigationChildControl_KeyPress;
            txtPhuCapKhac.KeyPress += NavigationChildControl_KeyPress;
            txtPhuCapKhuVuc.KeyPress += NavigationChildControl_KeyPress;
            txtPhuCapThamNienNghe.KeyPress += NavigationChildControl_KeyPress;
            txtPhuCapPhanLoaiXa.KeyPress += NavigationChildControl_KeyPress;
            txtPhuCapTrachNhiem.KeyPress += NavigationChildControl_KeyPress;
            txtPhuCapDocHai.KeyPress += NavigationChildControl_KeyPress;
            txtPhuCapUuDaiNghe.KeyPress += NavigationChildControl_KeyPress;
        }

        private void NavigationChildControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow type number
            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void FrmPhieuBaoPhuCap_Load(object sender, EventArgs e)
        {
            InitKeysPressEvent();
        }
    }
}