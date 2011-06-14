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
using QuanLyHoSoCongChuc.OtherForms;

namespace QuanLyHoSoCongChuc.DataManager
{
    public partial class FrmPhieuBaoBoDonVi : DevComponents.DotNetBar.Office2007Form
    {
        private EnumUpdateMode UpdateMode = EnumUpdateMode.INSERT;
        // Hidden files are used to store ids 
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaCanBo;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaHinhThuc;

        public FrmPhieuBaoBoDonVi()
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
            LoadNhanVienBoDonVi();
        }

        private void btnChonDonViChuyenDen_Click(object sender, EventArgs e)
        {
            FrmQuanLyHinhThucBoDonVi frm = new FrmQuanLyHinhThucBoDonVi();
            frm.Handler += GetHinhThucBoDonVi;
            frm.ShowDialog();
        }

        public void GetHinhThucBoDonVi(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaHinhThuc.Text = comp[0];
            txtHinhThuc.Text = comp[1];
        }

        private void btnChonNhanVien_Click(object sender, EventArgs e)
        {
            FrmTimNhanVien frm = new FrmTimNhanVien(txtMaDonVi.Text.Trim(), GlobalPhieuBaos.GetListOfNhanVienKhongConSinhHoat(txtMaDonVi.Text));
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
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaDonVi.Text == "")
            {
                MessageBox.Show("Vui lòng chọn đơn vị", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UpdateMode = EnumUpdateMode.INSERT;
            EraseTextboxes();
            SetDefaultMode(false);
            DisableCmdButtons();
            btnChonHinhThuc.Focus();
            lstvData.SelectedItems.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaCanBo.Text != "")
            {
                UpdateMode = EnumUpdateMode.UPDATE;
                SetDefaultMode(false);
                DisableCmdButtons();
                btnChonHinhThuc.Focus();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaCanBo.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa dữ liệu này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (CanBoQuaCacThoiKiRepository.Delete(int.Parse(txtMaCanBo.Text)))
                    {
                        txtMaCanBo.Text = "";
                        EraseTextboxes();
                        LoadNhanVienBoDonVi();
                        MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                LoadNhanVienBoDonVi();
                SetDefaultMode(true);
                MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (txtMaCanBo.Text != "")
            {
                LoadCurrentQuaTrinhInfo(int.Parse(txtMaCanBo.Text), dtNgay.Value);
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

        private void lstvData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvData.SelectedItems.Count > 0)
            {
                LoadCurrentQuaTrinhInfo(((CanBoQuaCacThoiKi)lstvData.SelectedItems[0].Tag).MaCanBo, dtNgay.Value);
            }
        }

        /// <summary>
        /// Init hidden fields
        /// </summary>
        public void InitHiddenFields()
        {
            // Add a new textbox
            txtMaCanBo = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaCanBo",
                Text = ""
            };
            txtMaCanBo.Visible = false;

            // Add a new textbox
            txtMaHinhThuc = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaHinhThuc",
                Text = ""
            };
            txtMaHinhThuc.Visible = false;
        }

        /// <summary>
        /// Load list of nhanvien has gone away
        /// </summary>
        public void LoadNhanVienBoDonVi()
        {
            var lstItem = CanBoQuaCacThoiKiRepository.SelectCanBoQuaCacThoiKi(txtMaDonVi.Text, EnumLoaiCanBoQuaCacThoiKi.BO_DONVI);
            lstvData.Items.Clear();
            if (lstItem.Count > 0)
            {
                for (int i = 0; i < lstItem.Count; i++)
                {
                    var objListViewItem = new ListViewItem();
                    objListViewItem.Tag = lstItem[i];
                    objListViewItem.Text = (i + 1).ToString();
                    objListViewItem.SubItems.Add(lstItem[i].MaNhanVien);
                    objListViewItem.SubItems.Add(lstItem[i].NhanVien.HoTenKhaiSinh);
                    objListViewItem.SubItems.Add(lstItem[i].NhanVien.MaGioiTinh == null ? "" : lstItem[i].NhanVien.GioiTinh.TenGioiTinh);
                    objListViewItem.SubItems.Add(lstItem[i].NhanVien.NgaySinh.Value == DateTime.MinValue ? "" : String.Format("{0:dd/MM/yyyy}", lstItem[i].NhanVien.NgaySinh));
                    objListViewItem.SubItems.Add(lstItem[i].NhanVien.HoKhau);
                    lstvData.Items.Add(objListViewItem);
                }
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
        /// Add a new item to DB
        /// </summary>
        /// <returns></returns>
        private bool ActionAdd()
        {
            try
            {
                // Inser new record to table CanBoQuaCacThoiKi
                var newItem = new CanBoQuaCacThoiKi
                {
                    MaLoaiCanBo = LoaiCanBoQuaCacThoiKiRepository.SelectByName(GlobalPhieuBaos.BO_DONVI).MaLoaiCanBoQuaCacThoiKiMa,
                    MaDonVi = txtMaDonVi.Text,
                    MaNhanVien = txtMaNhanVien.Text
                };

                if (!CanBoQuaCacThoiKiRepository.Insert(newItem))
                {
                    return false;
                }
                
                // Update donvichuyenden for canbo
                var bodonvi = new BoDonVi
                {
                    MaCanBo = newItem.MaCanBo,
                    NgayRaKhoiDonVi = dtNgayRaKhoiDang.Value,
                    LyDo = txtLyDo.Text,
                    SoQuyetDinh = txtSoQuyetDinh.Text
                };

                if (txtMaHinhThuc.Text != "")
                {
                    bodonvi.MaHinhThucBoDonVi = int.Parse(txtMaHinhThuc.Text);
                }

                BoDonViRepository.Insert(bodonvi);

                // Update status of nhanvien -> khong con sinh hoat
                var nhanvien = NhanVienRepository.SelectByID(txtMaNhanVien.Text);
                nhanvien.ConSinhHoat = false;
                NhanVienRepository.Save();

                RefreshQuaTrinh(newItem.MaCanBo.ToString());

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Store ma qua trinh cong tac
        /// </summary>
        /// <param name="val"></param>
        public void RefreshQuaTrinh(string val)
        {
            txtMaCanBo.Text = val;
        }

        /// <summary>
        /// Update an item in DB
        /// </summary>
        /// <returns></returns>
        private bool ActionUpdate()
        {
            try
            {
                var canbo = CanBoQuaCacThoiKiRepository.SelectByID(int.Parse(txtMaCanBo.Text));
                canbo.BoDonVi.NgayRaKhoiDonVi = dtNgayRaKhoiDang.Value;
                canbo.BoDonVi.LyDo = txtLyDo.Text;
                canbo.BoDonVi.SoQuyetDinh = txtSoQuyetDinh.Text;

                if (txtMaHinhThuc.Text != "")
                {
                    canbo.BoDonVi.MaHinhThucBoDonVi = int.Parse(txtMaHinhThuc.Text);
                }

                return CanBoQuaCacThoiKiRepository.Save();
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Load info of current quatrinh
        /// If mode is insert: update txtMaCanBoQuaCacThoiKi
        /// Else: not change
        /// </summary>
        public void LoadCurrentQuaTrinhInfo(int macanbo, DateTime time)
        {
            // Load nhanvien info
            var canbo = CanBoQuaCacThoiKiRepository.SelectByID(macanbo);
            txtMaCanBo.Text = macanbo.ToString();

            txtMaNhanVien.Text = canbo.MaNhanVien;
            txtHoTen.Text = canbo.NhanVien.HoTenKhaiSinh;
            txtGioiTinh.Text = canbo.NhanVien.MaGioiTinh == null ? "" : canbo.NhanVien.GioiTinh.TenGioiTinh;
            txtNamSinh.Text = String.Format("{0:dd/MM/yyyy}", canbo.NhanVien.NgaySinh.Value);
            txtVaoDonVi.Text = String.Format("{0:dd/MM/yyyy}", canbo.NhanVien.NgayTuyenDung.Value);
            txtTaiCoQuan.Text = canbo.NhanVien.CoQuanTuyenDung;
            
            // If there's info luong and phu cap of nhanvien
            var lstItem = BoDonViRepository.SelectByMaCanBo(canbo.MaCanBo);
            if (lstItem.Count > 0)
            {
                dtNgayRaKhoiDang.Value = lstItem[0].NgayRaKhoiDonVi.Value;
                txtMaHinhThuc.Text = lstItem[0].MaHinhThucBoDonVi == null ? "" : lstItem[0].MaHinhThucBoDonVi.ToString();
                txtHinhThuc.Text = lstItem[0].MaHinhThucBoDonVi == null ? "" : lstItem[0].HinhThucBoDonVi.TenHinhThucBoDonVi;
                txtLyDo.Text = lstItem[0].LyDo;
                txtSoQuyetDinh.Text = lstItem[0].SoQuyetDinh;
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

            txtMaHinhThuc.Text = "";
            txtHinhThuc.Text = "";
            txtLyDo.Text = "";
            txtSoQuyetDinh.Text = "";
        }

        /// <summary>
        /// Set default status
        /// </summary>
        /// <param name="val">default is true</param>
        public void SetDefaultMode(bool val = true)
        {
            txtLyDo.ReadOnly = val;
            txtSoQuyetDinh.ReadOnly = val;

            btnChonNhanVien.Enabled = !val;
            btnChonHinhThuc.Enabled = !val;

            btnThem.Enabled = val;
            btnSua.Enabled = val;
            btnXoa.Enabled = val;
            btnGhi.Enabled = !val;
            btnHuy.Enabled = !val;
        }
    }
}