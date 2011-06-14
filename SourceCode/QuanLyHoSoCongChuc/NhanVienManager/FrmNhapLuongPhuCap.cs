using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace QuanLyHoSoCongChuc.NhanVienManager
{
    #region Using
    using QuanLyHoSoCongChuc.Models;
    using QuanLyHoSoCongChuc.Utils;
    using QuanLyHoSoCongChuc.Repositories;
    using QuanLyHoSoCongChuc.OtherForms;
    #endregion

    /// <summary>
    /// tuansl added: insert new LuongPhuCap progress
    /// </summary>
    public partial class FrmNhapLuongPhuCap : DevComponents.DotNetBar.Office2007Form
    {
        public EventHandler Handler { get; set; }
        private bool Updated = false;
        private NhanVien _nhanvien;
        private EnumUpdateMode UpdateMode = EnumUpdateMode.INSERT;
        // Hidden files are used to store ids 
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaQuaTrinh;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaHuong85;

        public FrmNhapLuongPhuCap(NhanVien nhanvien)
        {
            InitializeComponent();
            InitHiddenFields();
            _nhanvien = nhanvien;
            txtHoTen.Text = _nhanvien.HoTenKhaiSinh;
            txtMaNhanVien.Text = _nhanvien.MaNhanVien;
        }

        private void btnChonNgach_Click(object sender, EventArgs e)
        {
            FrmQuanLyNgachCongChuc frm = new FrmQuanLyNgachCongChuc();
            frm.Handler += GetNgach;
            frm.ShowDialog();
        }

        public void GetNgach(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaNgach.Text = comp[0];
            txtTenNgach.Text = comp[1];
        }

        private void btnChonHuong85_Click(object sender, EventArgs e)
        {
            FrmQuanLyHuong85 frm = new FrmQuanLyHuong85();
            frm.Handler += GetHuong85;
            frm.ShowDialog();
        }

        public void GetHuong85(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaHuong85.Text = comp[0];
            txtHuong85.Text = comp[1];
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            UpdateMode = EnumUpdateMode.INSERT;
            EraseTextboxes();
            SetDefaultMode(false);
            DisableCmdButtons();
            dtNgayThangNam.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaQuaTrinh.Text != "")
            {
                UpdateMode = EnumUpdateMode.UPDATE;
                SetDefaultMode(false);
                DisableCmdButtons();
                dtNgayThangNam.Focus();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaQuaTrinh.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa dữ liệu này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (LuongPhuCapRepository.Delete(int.Parse(txtMaQuaTrinh.Text)))
                    {
                        Updated = true;
                        EraseTextboxes();
                        txtMaQuaTrinh.Text = "";
                        LoadData();
                        MessageBox.Show("Xóa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xóa dữ liệu thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (UpdateMode == EnumUpdateMode.INSERT)
            {
                if (ActionAdd())
                {
                    success = true;
                }
            }
            else if (UpdateMode == EnumUpdateMode.UPDATE)
            {
                if (ActionUpdate())
                {
                    success = true;
                }
            }

            // Inform result for nguoidung
            if (success)
            {
                LoadData();
                SetDefaultMode(true);
                Updated = true;
                MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Case 1
            if (txtMaQuaTrinh.Text != "")
                LoadCurrentQuaTrinhInfo(int.Parse(txtMaQuaTrinh.Text));
            else
                EraseTextboxes();

            SetDefaultMode(true);
            btnThem.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmNhapLuongPhuCap_Load(object sender, EventArgs e)
        {
            // Show waiting form
            GlobalVars.PreLoading();
            //------- E ---------
            LoadData();
            EraseTextboxes();
            SetDefaultMode(true);
            InitKeysPressEvent();
        }

        private void lstvData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvData.SelectedItems.Count > 0)
            {
                var item = (LuongPhuCap)lstvData.SelectedItems[0].Tag;

                txtMaQuaTrinh.Text = item.MaLuongPhuCap.ToString();
                dtNgayThangNam.Value = item.NgayThangNam.Value;

                txtTenNgach.Text = item.MaNgachCongChuc == null ? "" : item.NgachCongChuc.TenNgachCongChuc;
                txtMaNgach.Text = item.MaNgachCongChuc == null ? "" : item.MaNgachCongChuc.ToString();

                txtHuong85.Text = item.MaHuong85 == null ? "" : item.Huong85.GiaTriHuong;
                txtMaHuong85.Text = item.MaHuong85 == null ? "" : item.MaHuong85.ToString();

                txtBacLuong.Text = item.BacLuong.ToString();
                txtHeSoLuong.Text = item.HeSoLuong.ToString();
                txtChenhLech.Text = item.ChenhLechBaoLuuHeSoLuong.ToString();
                dtHuongTuNgay.Value = item.HuongTuNgay.Value;
                dtMocTinhLuongLanSau.Value = item.MocTinhNangLuongLanSau.Value;
                dtNgayNangLuong.Value = item.NgayNangLuong.Value;
                txtATM.Text = item.SoTheATM;
                txtNganHang.Text = item.NganHang;

                txtPhuCapChucVu.Text = item.HeSoPhuCapChucVu.ToString();
                txtPhuCapKiemNhiem.Text = item.HeSoPhuCapKiemNhiem.ToString();
                txtPhuCapThamNienVuotKhung.Text = item.HeSoPhuCapThamNienVuotKhung.ToString();
                txtPhuCapThamNienNghe.Text = item.HeSoPhuCapThamNienNghe.ToString();
                txtPhuCapKhuVuc.Text = item.HeSoPhuCapKhuVuc.ToString();
                txtPhuCapPhanLoaiXa.Text = item.HeSoPhuCapPhanLoaiXa.ToString();
                txtPhuCapKhac.Text = item.HeSoPhuCapKhac.ToString();
                txtPhuCapTrachNhiem.Text = item.HeSoPhuCapTrachNhiem.ToString();
                txtPhuCapDocHai.Text = item.HeSoPhuCapDocHai.ToString();
                txtPhuCapUuDaiNghe.Text = item.HeSoPhuCapUuDaiNghe.ToString();
                txtSoBHXH.Text = item.SoSoBHXH.ToString();
                dtNgayDongBHXH.Value = item.NgayBatDauDongBHXH.Value;
            }
        }

        private void FrmNhapLuongPhuCap_FormClosed(object sender, FormClosedEventArgs e)
        {
            TransferDataInfo(this, new MyEvent(Updated ? "true" : "false"));
        }

        /// <summary>
        /// Load list of congtac progresses of specified nhanvien
        /// </summary>
        public void LoadData()
        {
            if (_nhanvien != null)
            {
                var lstItem = LuongPhuCapRepository.SelectByMaNhanVien(_nhanvien.MaNhanVien);
                lstvData.Items.Clear();
                for (int i = 0; i < lstItem.Count; i++)
                {
                    var objListViewItem = new ListViewItem();
                    objListViewItem.Tag = lstItem[i];
                    objListViewItem.Text = (i + 1).ToString();
                    objListViewItem.SubItems.Add(lstItem[i].NgayThangNam.ToString());
                    objListViewItem.SubItems.Add(lstItem[i].NgachCongChuc.TenNgachCongChuc);
                    lstvData.Items.Add(objListViewItem);
                }
            }
        }

        /// <summary>
        /// Init hidden fields
        /// </summary>
        public void InitHiddenFields()
        {
            // Add a new textbox
            txtMaQuaTrinh = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaQuaTrinh",
                Text = ""
            };
            txtMaQuaTrinh.Visible = false;

            // Add a new textbox
            txtMaHuong85 = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaHuong85",
                Text = ""
            };
            txtMaHuong85.Visible = false;
        }

        /// <summary>
        /// tuansl added: function is used to transfer data when event would be raised
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TransferDataInfo(object sender, MyEvent e)
        {
            this.Handler(this, e);
        }

        /// <summary>
        /// Validate user inputs
        /// </summary>
        /// <returns></returns>
        public bool ValidateUserInput(ref string errorText)
        {
            if (dtNgayThangNam.Value == DateTime.MinValue)
            {
                errorText = "Vui lòng nhập ngày tháng năm";
                return false;
            }
            if (txtMaNgach.Text == "")
            {
                errorText = "Vui lòng chọn ngạch công chức";
                return false;
            }
            return true;
        }

        /// <summary>
        /// Update foreign keys need to insert
        /// </summary>
        /// <param name="LuongPhuCap"></param>
        public void UpdateForeignKeys(ref LuongPhuCap item)
        {
            if (txtMaNgach.Text != "")
            {
                item.MaNgachCongChuc = txtMaNgach.Text;
            }
            if (txtMaHuong85.Text != "")
            {
                item.MaHuong85 = txtMaHuong85.Text;
            }
            if (txtPhuCapChucVu.Text != "")
            {
                item.HeSoPhuCapChucVu = float.Parse(txtPhuCapChucVu.Text);
            }
            if (txtPhuCapKiemNhiem.Text != "")
            {
                item.HeSoPhuCapKiemNhiem = float.Parse(txtPhuCapKiemNhiem.Text);
            }
            if (txtPhuCapThamNienVuotKhung.Text != "")
            {
                item.HeSoPhuCapThamNienVuotKhung = float.Parse(txtPhuCapThamNienVuotKhung.Text);
            }
            if (txtPhuCapThamNienNghe.Text != "")
            {
                item.HeSoPhuCapThamNienNghe = float.Parse(txtPhuCapThamNienNghe.Text);
            }
            if (txtPhuCapKhuVuc.Text != "")
            {
                item.HeSoPhuCapKhuVuc = float.Parse(txtPhuCapKhuVuc.Text);
            }
            if (txtPhuCapPhanLoaiXa.Text != "")
            {
                item.HeSoPhuCapPhanLoaiXa = float.Parse(txtPhuCapPhanLoaiXa.Text);
            }
            if (txtPhuCapKhac.Text != "")
            {
                item.HeSoPhuCapKhac = float.Parse(txtPhuCapKhac.Text);
            }
            if (txtPhuCapTrachNhiem.Text != "")
            {
                item.HeSoPhuCapTrachNhiem = float.Parse(txtPhuCapTrachNhiem.Text);
            }
            if (txtPhuCapDocHai.Text != "")
            {
                item.HeSoPhuCapDocHai = float.Parse(txtPhuCapDocHai.Text);
            }
            if (txtPhuCapUuDaiNghe.Text != "")
            {
                item.HeSoPhuCapUuDaiNghe = float.Parse(txtPhuCapUuDaiNghe.Text);
            }
            if (txtSoBHXH.Text != "")
            {
                item.SoSoBHXH = float.Parse(txtSoBHXH.Text);
            }
            if (txtBacLuong.Text != "")
            {
                item.BacLuong = float.Parse(txtBacLuong.Text);
            }
            if (txtHeSoLuong.Text != "")
            {
                item.HeSoLuong = float.Parse(txtHeSoLuong.Text);
            }
            if (txtChenhLech.Text != "")
            {
                item.ChenhLechBaoLuuHeSoLuong = float.Parse(txtChenhLech.Text);
            }

        }

        /// <summary>
        /// Add a new item to DB
        /// </summary>
        /// <returns></returns>
        private bool ActionAdd()
        {
            try
            {
                var newItem = new LuongPhuCap
                {
                    MaNhanVien = _nhanvien.MaNhanVien,
                    NgayThangNam = dtNgayThangNam.Value,
                    HuongTuNgay = dtHuongTuNgay.Value,
                    MocTinhNangLuongLanSau = dtMocTinhLuongLanSau.Value,
                    NgayNangLuong = dtNgayNangLuong.Value,
                    SoTheATM = txtATM.Text,
                    NganHang = txtNganHang.Text,
                    NgayBatDauDongBHXH = dtNgayDongBHXH.Value
                };

                UpdateForeignKeys(ref newItem);

                if (!LuongPhuCapRepository.Insert(newItem))
                {
                    return false;
                }
                RefreshQuaTrinh(newItem.MaLuongPhuCap.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Update an item in DB
        /// </summary>
        /// <returns></returns>
        private bool ActionUpdate()
        {
            try
            {
                var item = LuongPhuCapRepository.SelectByID(int.Parse(txtMaQuaTrinh.Text));
                item.MaNhanVien = _nhanvien.MaNhanVien;
                item.NgayThangNam = dtNgayThangNam.Value;
                item.HuongTuNgay = dtHuongTuNgay.Value;
                item.MocTinhNangLuongLanSau = dtMocTinhLuongLanSau.Value;
                item.NgayNangLuong = dtNgayNangLuong.Value;
                item.SoTheATM = txtATM.Text;
                item.NganHang = txtNganHang.Text;
                item.NgayBatDauDongBHXH = dtNgayDongBHXH.Value;

                UpdateForeignKeys(ref item);

                return LuongPhuCapRepository.Save();
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Load info of current quatrinh
        /// If mode is insert: update luong phu cap
        /// Else: not change
        /// </summary>
        public void LoadCurrentQuaTrinhInfo(int id)
        {
            var item = LuongPhuCapRepository.SelectByID(id);

            txtMaQuaTrinh.Text = item.MaLuongPhuCap.ToString();

            txtTenNgach.Text = item.MaNgachCongChuc == null ? "" : item.NgachCongChuc.TenNgachCongChuc;
            txtMaNgach.Text = item.MaNgachCongChuc == null ? "" : item.MaNgachCongChuc.ToString();

            txtHuong85.Text = item.MaHuong85 == null ? "" : item.Huong85.GiaTriHuong;
            txtMaHuong85.Text = item.MaHuong85 == null ? "" : item.MaHuong85.ToString();

            txtBacLuong.Text = item.BacLuong.ToString();
            txtHeSoLuong.Text = item.HeSoLuong.ToString();
            txtChenhLech.Text = item.ChenhLechBaoLuuHeSoLuong.ToString();
            dtHuongTuNgay.Value = item.HuongTuNgay.Value;
            dtMocTinhLuongLanSau.Value = item.MocTinhNangLuongLanSau.Value;
            dtNgayNangLuong.Value = item.NgayNangLuong.Value;
            txtATM.Text = item.SoTheATM;
            txtNganHang.Text = item.NganHang;

            txtPhuCapChucVu.Text = item.HeSoPhuCapChucVu.ToString();
            txtPhuCapKiemNhiem.Text = item.HeSoPhuCapKiemNhiem.ToString();
            txtPhuCapThamNienVuotKhung.Text = item.HeSoPhuCapThamNienVuotKhung.ToString();
            txtPhuCapThamNienNghe.Text = item.HeSoPhuCapThamNienNghe.ToString();
            txtPhuCapKhuVuc.Text = item.HeSoPhuCapKhuVuc.ToString();
            txtPhuCapPhanLoaiXa.Text = item.HeSoPhuCapPhanLoaiXa.ToString();
            txtPhuCapKhac.Text = item.HeSoPhuCapKhac.ToString();
            txtPhuCapTrachNhiem.Text = item.HeSoPhuCapTrachNhiem.ToString();
            txtPhuCapDocHai.Text = item.HeSoPhuCapDocHai.ToString();
            txtPhuCapUuDaiNghe.Text = item.HeSoPhuCapUuDaiNghe.ToString();
            txtSoBHXH.Text = item.SoSoBHXH.ToString();
            dtNgayDongBHXH.Value = item.NgayBatDauDongBHXH.Value;
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
        /// Store ma qua trinh cong tac
        /// </summary>
        /// <param name="val"></param>
        public void RefreshQuaTrinh(string val)
        {
            txtMaQuaTrinh.Text = val;
        }

        /// <summary>
        /// Erase data in textboxes when mode is insert
        /// </summary>
        public void EraseTextboxes()
        {
            txtTenNgach.Text = "";
            txtMaNgach.Text = "";

            txtHuong85.Text = "";
            txtMaHuong85.Text = "";

            txtBacLuong.Text = "";
            txtHeSoLuong.Text = "";
            txtChenhLech.Text = "";
            txtATM.Text = "";
            txtNganHang.Text = "";

            dtHuongTuNgay.Value = dtHuongTuNgay.Value.Date;
            dtMocTinhLuongLanSau.Value = dtMocTinhLuongLanSau.Value.Date;
            dtNgayNangLuong.Value = dtNgayNangLuong.Value.Date;
            dtNgayDongBHXH.Value = dtNgayDongBHXH.Value.Date;

            txtPhuCapChucVu.Text = "";
            txtPhuCapKiemNhiem.Text = "";
            txtPhuCapThamNienVuotKhung.Text = "";
            txtPhuCapThamNienNghe.Text = "";
            txtPhuCapKhuVuc.Text = "";
            txtPhuCapPhanLoaiXa.Text = "";
            txtPhuCapKhac.Text = "";
            txtPhuCapTrachNhiem.Text = "";
            txtPhuCapDocHai.Text = "";
            txtPhuCapUuDaiNghe.Text = "";
            txtSoBHXH.Text = "";
        }

        /// <summary>
        /// Set default status
        /// </summary>
        /// <param name="val">default is true</param>
        public void SetDefaultMode(bool val = true)
        {
            txtBacLuong.ReadOnly = val;
            txtHeSoLuong.ReadOnly = val;
            txtChenhLech.ReadOnly = val;
            txtATM.ReadOnly = val;
            txtNganHang.ReadOnly = val;

            dtHuongTuNgay.Value = dtHuongTuNgay.Value.Date;
            dtMocTinhLuongLanSau.Value = dtMocTinhLuongLanSau.Value.Date;
            dtNgayNangLuong.Value = dtNgayNangLuong.Value.Date;
            dtNgayDongBHXH.Value = dtNgayDongBHXH.Value.Date;

            txtPhuCapChucVu.ReadOnly = val;
            txtPhuCapKiemNhiem.ReadOnly = val;
            txtPhuCapThamNienVuotKhung.ReadOnly = val;
            txtPhuCapThamNienNghe.ReadOnly = val;
            txtPhuCapKhuVuc.ReadOnly = val;
            txtPhuCapPhanLoaiXa.ReadOnly = val;
            txtPhuCapKhac.ReadOnly = val;
            txtPhuCapTrachNhiem.ReadOnly = val;
            txtPhuCapDocHai.ReadOnly = val;
            txtPhuCapUuDaiNghe.ReadOnly = val;
            txtSoBHXH.ReadOnly = val;

            btnChonHuong85.Enabled = !val;
            btnChonNgach.Enabled = !val;

            btnThem.Enabled = val;
            btnSua.Enabled = val;
            btnXoa.Enabled = val;
            btnGhi.Enabled = !val;
            btnHuy.Enabled = !val;
        }

        public void InitKeysPressEvent()
        {
            txtBacLuong.KeyPress += NavigationChildControl_KeyPress;
            txtHeSoLuong.KeyPress += NavigationChildControl_KeyPress;
            txtChenhLech.KeyPress += NavigationChildControl_KeyPress;
            txtPhuCapChucVu.KeyPress += NavigationChildControl_KeyPress;
            txtPhuCapKiemNhiem.KeyPress += NavigationChildControl_KeyPress;
            txtPhuCapThamNienVuotKhung.KeyPress += NavigationChildControl_KeyPress;
            txtPhuCapKhuVuc.KeyPress += NavigationChildControl_KeyPress;
            txtPhuCapPhanLoaiXa.KeyPress += NavigationChildControl_KeyPress;
            txtPhuCapKhac.KeyPress += NavigationChildControl_KeyPress;
            txtPhuCapTrachNhiem.KeyPress += NavigationChildControl_KeyPress;
            txtPhuCapDocHai.KeyPress += NavigationChildControl_KeyPress;
            txtPhuCapUuDaiNghe.KeyPress += NavigationChildControl_KeyPress;
            txtPhuCapThamNienNghe.KeyPress += NavigationChildControl_KeyPress;
        }

        private void NavigationChildControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow type number
            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void FrmNhapLuongPhuCap_Shown(object sender, EventArgs e)
        {
            // Hide waiting form
            GlobalVars.PosLoading();
            //------- E ---------
        }
    }
}