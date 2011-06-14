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
    /// tuansl added: insert new khenthuong progress
    /// </summary>
    public partial class FrmNhapQuaTrinhKhenThuong : DevComponents.DotNetBar.Office2007Form
    {
        public EventHandler Handler { get; set; }
        private bool Updated = false;
        private NhanVien _nhanvien;
        private EnumUpdateMode UpdateMode = EnumUpdateMode.INSERT;
        // Hidden files are used to store ids 
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaQuaTrinh;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaHinhThucKhenThuong;

        public FrmNhapQuaTrinhKhenThuong(NhanVien nhanvien)
        {
            InitializeComponent();
            InitHiddenFields();
            _nhanvien = nhanvien;
            txtHoTen.Text = _nhanvien.HoTenKhaiSinh;
            txtMaNhanVien.Text = _nhanvien.MaNhanVien;
            LoadData();
        }

        private void btnChonHinhThucKhenThuong_Click(object sender, EventArgs e)
        {
            FrmQuanLyHinhThucKhenThuong frm = new FrmQuanLyHinhThucKhenThuong();
            frm.Handler += GetHinhThucKhenThuong;
            frm.ShowDialog();
        }

        public void GetHinhThucKhenThuong(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaHinhThucKhenThuong.Text = comp[0];
            txtHinhThuc.Text = comp[1];
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            UpdateMode = EnumUpdateMode.INSERT;
            EraseTextboxes();
            SetDefaultMode(false);
            DisableCmdButtons();
            txtNam.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaQuaTrinh.Text != "")
            {
                UpdateMode = EnumUpdateMode.UPDATE;
                SetDefaultMode(false);
                DisableCmdButtons();
                txtNam.Focus();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaQuaTrinh.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa dữ liệu này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (KhenThuongRepository.Delete(int.Parse(txtMaQuaTrinh.Text)))
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

        private void FrmNhapQuaTrinhKhenThuong_Load(object sender, EventArgs e)
        {
            EraseTextboxes();
            SetDefaultMode(true);
        }

        private void lstvData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvData.SelectedItems.Count > 0)
            {
                var item = (KhenThuong)lstvData.SelectedItems[0].Tag;

                txtMaQuaTrinh.Text = item.MaKhenThuong.ToString();
                txtNam.Text = item.NamNhan.ToString();
                txtLyDo.Text = item.GhiChu;

                txtHinhThuc.Text = item.MaHinhThucKhenThuong == null ? "" : item.HinhThucKhenThuong.TenHinhThucKhenThuong;
                txtMaHinhThucKhenThuong.Text = item.MaHinhThucKhenThuong == null ? "" : item.MaHinhThucKhenThuong.ToString();
            }
        }

        private void FrmNhapQuaTrinhKhenThuong_FormClosed(object sender, FormClosedEventArgs e)
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
                var lstItem = KhenThuongRepository.SelectByMaNhanVien(_nhanvien.MaNhanVien);
                lstvData.Items.Clear();
                for (int i = 0; i < lstItem.Count; i++)
                {
                    var objListViewItem = new ListViewItem();
                    objListViewItem.Tag = lstItem[i];
                    objListViewItem.Text = (i + 1).ToString();
                    objListViewItem.SubItems.Add(lstItem[i].NamNhan.ToString());
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
            txtMaHinhThucKhenThuong = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaHinhThucKhenThuong",
                Text = ""
            };
            txtMaHinhThucKhenThuong.Visible = false;
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
            if (txtNam.Text == "")
            {
                errorText = "Vui lòng nhập năm khen thưởng";
                return false;
            }
            else
            {
                if (!Validations.IsNumeric(txtNam.Text))
                {
                    errorText = "Năm khen thưởng phải là số";
                    return false;
                }
            }
            if (txtHinhThuc.Text == "")
            {
                errorText = "Vui lòng nhập hình thức khen thưởng";
                return false;
            }
            return true;
        }

        /// <summary>
        /// Update foreign keys need to insert
        /// </summary>
        /// <param name="KhenThuong"></param>
        public void UpdateForeignKeys(ref KhenThuong quatrinh)
        {
            if (txtMaHinhThucKhenThuong.Text != "")
            {
                quatrinh.MaHinhThucKhenThuong = int.Parse(txtMaHinhThucKhenThuong.Text);
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
                var newItem = new KhenThuong
                {
                    MaNhanVien = _nhanvien.MaNhanVien,
                    NamNhan = int.Parse(txtNam.Text),
                    GhiChu = txtLyDo.Text
                };

                UpdateForeignKeys(ref newItem);

                if (!KhenThuongRepository.Insert(newItem))
                {
                    return false;
                }
                RefreshQuaTrinh(newItem.MaKhenThuong.ToString());
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
                var quatrinh = KhenThuongRepository.SelectByID(int.Parse(txtMaQuaTrinh.Text));
                quatrinh.MaNhanVien = _nhanvien.MaNhanVien;
                quatrinh.NamNhan = int.Parse(txtNam.Text);
                quatrinh.GhiChu = txtLyDo.Text;
                
                UpdateForeignKeys(ref quatrinh);

                return KhenThuongRepository.Save();
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Load info of current quatrinh
        /// If mode is insert: update txtMaKhenThuong
        /// Else: not change
        /// </summary>
        public void LoadCurrentQuaTrinhInfo(int id)
        {
            var item = KhenThuongRepository.SelectByID(id);

            txtMaQuaTrinh.Text = id.ToString();
            txtNam.Text = item.NamNhan.ToString();
            txtLyDo.Text = item.GhiChu;

            txtHinhThuc.Text = item.MaHinhThucKhenThuong == null ? "" : item.HinhThucKhenThuong.TenHinhThucKhenThuong;
            txtMaHinhThucKhenThuong.Text = item.MaHinhThucKhenThuong == null ? "" : item.MaHinhThucKhenThuong.ToString();
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
            txtNam.Text = "";
            txtHinhThuc.Text = "";
            txtMaHinhThucKhenThuong.Text = "";
            txtLyDo.Text = "";
        }

        /// <summary>
        /// Set default status
        /// </summary>
        /// <param name="val">default is true</param>
        public void SetDefaultMode(bool val = true)
        {
            txtNam.ReadOnly = val;
            txtLyDo.ReadOnly = val;

            btnChonHinhThuc.Enabled = !val;

            btnThem.Enabled = val;
            btnSua.Enabled = val;
            btnXoa.Enabled = val;
            btnGhi.Enabled = !val;
            btnHuy.Enabled = !val;
        }

        private void txtNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow type number
            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}