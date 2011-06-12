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
    /// tuansl added: insert new family relationships
    /// </summary>
    public partial class FrmNhapQuanHeGiaDinh : DevComponents.DotNetBar.Office2007Form
    {
        public EventHandler Handler { get; set; }
        private bool Updated = false;
        private NhanVien _nhanvien;
        private EnumUpdateMode UpdateMode = EnumUpdateMode.INSERT;
        // Hidden files are used to store ids 
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaThanNhan;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaQuanHe;

        public FrmNhapQuanHeGiaDinh(NhanVien nhanvien)
        {
            InitializeComponent();
            InitHiddenFields();
            _nhanvien = nhanvien;
            txtHoTen.Text = _nhanvien.HoTenKhaiSinh;
            txtMaNhanVien.Text = _nhanvien.MaNhanVien;
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            UpdateMode = EnumUpdateMode.INSERT;
            EraseTextboxes();
            SetDefaultMode(false);
            DisableCmdButtons();
            btnChonQuanHe.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaThanNhan.Text != "")
            {
                UpdateMode = EnumUpdateMode.UPDATE;
                SetDefaultMode(false);
                DisableCmdButtons();
                btnChonQuanHe.Focus();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaThanNhan.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa dữ liệu này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (ThanNhanRepository.Delete(int.Parse(txtMaThanNhan.Text)))
                    {
                        MessageBox.Show("Xóa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Updated = true;
                        EraseTextboxes();
                        txtMaThanNhan.Text = "";
                        LoadData();
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
            if (!ValidateUserInput(ref errorText))
            {
                MessageBox.Show(errorText, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (UpdateMode == EnumUpdateMode.INSERT)
            {
                if (ActionAdd())
                {
                    MessageBox.Show("Lưu dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    SetDefaultMode(true);
                    Updated = true;
                }
                else
                {
                    MessageBox.Show("Lưu dữ liệu thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (UpdateMode == EnumUpdateMode.UPDATE)
            {
                if (ActionUpdate())
                {
                    MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    SetDefaultMode(true);
                    Updated = true;
                }
                else
                {
                    MessageBox.Show("Cập nhật dữ liệu thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Case 1
            if (txtMaThanNhan.Text != "")
                LoadCurrentThanNhanInfo(int.Parse(txtMaThanNhan.Text));
            else
                EraseTextboxes();

            SetDefaultMode(true);
            btnThem.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChonQuanHe_Click(object sender, EventArgs e)
        {
            FrmQuanLyQuanHe frm = new FrmQuanLyQuanHe();
            frm.Handler += GetQuanHe;
            frm.ShowDialog();
        }

        public void GetQuanHe(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaQuanHe.Text = comp[0];
            txtQuanHe.Text = comp[1];
        }

        private void FrmNhapQuanHeGiaDinh_Load(object sender, EventArgs e)
        {
            EraseTextboxes();
            SetDefaultMode(true);
        }

        private void lstvData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvData.SelectedItems.Count > 0)
            {
                var item = (ThanNhan)lstvData.SelectedItems[0].Tag;

                txtMaThanNhan.Text = item.MaThanNhan.ToString();

                txtNamSinh.Text = item.NamSinh.ToString();
                txtHoTenThanNhan.Text = item.TenThanNhan.ToString();
                txtThongTinCaNhan.Text = item.ThongTinCaNhan.ToString();

                txtQuanHe.Text = item.MaQuanHe == null ? "" : item.QuanHe.TenQuanHe;
                txtMaQuanHe.Text = item.MaQuanHe == null ? "" : item.MaQuanHe.ToString();
            }
        }

        private void FrmNhapQuanHeGiaDinh_FormClosed(object sender, FormClosedEventArgs e)
        {
            TransferDataInfo(this, new MyEvent(Updated ? "true" : "false"));
        }

        /// <summary>
        /// Init hidden fields
        /// </summary>
        public void InitHiddenFields()
        {
            // Add a new textbox
            txtMaThanNhan = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaThanNhan",
                Text = ""
            };
            txtMaThanNhan.Visible = false;

            // Add a new textbox
            txtMaQuanHe = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaQuanHe",
                Text = ""
            };
            txtMaQuanHe.Visible = false;
        }

        /// <summary>
        /// Load list of congtac progresses of specified nhanvien
        /// </summary>
        public void LoadData()
        {
            if (_nhanvien != null)
            {
                var lstItem = ThanNhanRepository.SelectByMaNhanVien(_nhanvien.MaNhanVien);
                lstvData.Items.Clear();
                for (int i = 0; i < lstItem.Count; i++)
                {
                    var objListViewItem = new ListViewItem();
                    objListViewItem.Tag = lstItem[i];
                    objListViewItem.Text = (i + 1).ToString();
                    objListViewItem.SubItems.Add(lstItem[i].TenThanNhan.ToString());
                    lstvData.Items.Add(objListViewItem);
                }
            }
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
            if (txtMaQuanHe.Text == "")
            {
                errorText = "Vui lòng chọn quan hệ";
                return false;
            }
            if (txtHoTenThanNhan.Text == "")
            {
                errorText = "Vui lòng nhập họ tên thân nhân";
                return false;
            }
            return true;
        }

        /// <summary>
        /// Update foreign keys need to insert
        /// </summary>
        /// <param name="thannhancongtac"></param>
        public void UpdateForeignKeys(ref ThanNhan thannhan)
        {
            if (txtNamSinh.Text != "")
            {
                if (Validations.IsNumeric(txtNamSinh.Text))
                {
                    thannhan.NamSinh = int.Parse(txtNamSinh.Text);
                }
            }
            if (txtMaQuanHe.Text != "")
            {
                thannhan.MaQuanHe = int.Parse(txtMaQuanHe.Text);
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
                var newItem = new ThanNhan
                {
                    MaNhanVien = _nhanvien.MaNhanVien,
                    TenThanNhan = txtHoTenThanNhan.Text,
                    ThongTinCaNhan = txtThongTinCaNhan.Text
                };

                UpdateForeignKeys(ref newItem);

                if (!ThanNhanRepository.Insert(newItem))
                {
                    return false;
                }
                Refreshthannhan(newItem.MaThanNhan.ToString());
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
                var thannhan = ThanNhanRepository.SelectByID(int.Parse(txtMaThanNhan.Text));
                thannhan.MaNhanVien = _nhanvien.MaNhanVien;
                thannhan.TenThanNhan = txtHoTenThanNhan.Text;
                thannhan.ThongTinCaNhan = txtThongTinCaNhan.Text;

                UpdateForeignKeys(ref thannhan);

                return ThanNhanRepository.Save();
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Load info of current thannhan
        /// If mode is insert: update txtMathannhanCongTac
        /// Else: not change
        /// </summary>
        public void LoadCurrentThanNhanInfo(int id)
        {
            var item = ThanNhanRepository.SelectByID(id);

            txtMaThanNhan.Text = id.ToString();
            txtNamSinh.Text = item.NamSinh.ToString();
            txtHoTenThanNhan.Text = item.TenThanNhan;
            txtThongTinCaNhan.Text = item.ThongTinCaNhan;

            txtQuanHe.Text = item.MaQuanHe == null ? "" : item.QuanHe.TenQuanHe;
            txtMaQuanHe.Text = item.MaQuanHe == null ? "" : item.MaQuanHe.ToString();
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
        public void Refreshthannhan(string val)
        {
            txtMaThanNhan.Text = val;
        }

        /// <summary>
        /// Erase data in textboxes when mode is insert
        /// </summary>
        public void EraseTextboxes()
        {
            txtNamSinh.Text = "";
            txtQuanHe.Text = "";
            txtMaQuanHe.Text = "";
            txtHoTenThanNhan.Text = "";
            txtThongTinCaNhan.Text = "";
        }

        /// <summary>
        /// Set default status
        /// </summary>
        /// <param name="val">default is true</param>
        public void SetDefaultMode(bool val = true)
        {
            txtNamSinh.ReadOnly = val;
            txtHoTenThanNhan.ReadOnly = val;
            txtThongTinCaNhan.ReadOnly = val;

            btnChonQuanHe.Enabled = !val;

            btnThem.Enabled = val;
            btnSua.Enabled = val;
            btnXoa.Enabled = val;
            btnGhi.Enabled = !val;
            btnHuy.Enabled = !val;
        }

        private void txtNamSinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow type number
            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}