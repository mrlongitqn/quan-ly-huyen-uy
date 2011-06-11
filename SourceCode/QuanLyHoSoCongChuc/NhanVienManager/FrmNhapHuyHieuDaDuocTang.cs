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
    /// tuansl added: insert new huyhieudang
    /// </summary>
    public partial class FrmNhapHuyHieuDaDuocTang : DevComponents.DotNetBar.Office2007Form
    {
        public EventHandler Handler { get; set; }
        private bool Updated = false;
        private NhanVien _nhanvien;
        private EnumUpdateMode UpdateMode = EnumUpdateMode.INSERT;
        // Hidden files are used to store ids 
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaHuyHieu;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaLoaiHuyHieu;

        public FrmNhapHuyHieuDaDuocTang(NhanVien nhanvien)
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
            txtNam.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaHuyHieu.Text != "")
            {
                UpdateMode = EnumUpdateMode.UPDATE;
                SetDefaultMode(false);
                DisableCmdButtons();
                txtNam.Focus();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaHuyHieu.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa dữ liệu này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (QuaTrinhCongTacRepository.Delete(int.Parse(txtMaHuyHieu.Text)))
                    {
                        MessageBox.Show("Xóa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EraseTextboxes();
                        txtMaHuyHieu.Text = "";
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
            if (txtMaHuyHieu.Text != "")
                LoadCurrentQuaTrinhInfo(int.Parse(txtMaHuyHieu.Text));
            else
                EraseTextboxes();

            SetDefaultMode(true);
            btnThem.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChonHuyHieu_Click(object sender, EventArgs e)
        {
            FrmQuanLyLoaiHuyHieu frm = new FrmQuanLyLoaiHuyHieu();
            frm.Handler += GetHinhThucHuyHieu;
            frm.ShowDialog();
        }

        public void GetHinhThucHuyHieu(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaLoaiHuyHieu.Text = comp[0];
            txtLoaiHuyHieu.Text = comp[1];
        }

        private void lstvData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvData.SelectedItems.Count > 0)
            {
                var item = (HuyHieu)lstvData.SelectedItems[0].Tag;

                txtMaHuyHieu.Text = item.MaHuyHieu.ToString();
                txtNam.Text = item.NamNhan.ToString();
                txtSoHuyHieu.Text = item.SoHuyHieu;
                txtGhiChu.Text = item.GhiChu;

                txtLoaiHuyHieu.Text = item.MaLoaiHuyHieu == null ? "" : item.LoaiHuyHieu.TenLoaiHuyHieu;
                txtMaLoaiHuyHieu.Text = item.MaLoaiHuyHieu == null ? "" : item.MaLoaiHuyHieu.ToString();
            }
        }

        private void FrmNhapHuyHieuDaDuocTang_Load(object sender, EventArgs e)
        {
            EraseTextboxes();
            SetDefaultMode(true);
        }

        private void FrmNhapHuyHieuDaDuocTang_FormClosed(object sender, FormClosedEventArgs e)
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
                var lstItem = HuyHieuRepository.SelectByMaNhanVien(_nhanvien.MaNhanVien);
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
            txtMaHuyHieu = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaHuyHieu",
                Text = ""
            };
            txtMaHuyHieu.Visible = false;

            // Add a new textbox
            txtMaLoaiHuyHieu = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaLoaiHuyHieu",
                Text = ""
            };
            txtMaLoaiHuyHieu.Visible = false;
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
                errorText = "Vui lòng nhập năm huy hiệu";
                return false;
            }
            else
            {
                if (!Validations.IsNumeric(txtNam.Text))
                {
                    errorText = "Năm huy hiệu phải là số";
                    return false;
                }
            }
            if (txtLoaiHuyHieu.Text == "")
            {
                errorText = "Vui lòng nhập loại huy hiệu";
                return false;
            }
            if (txtSoHuyHieu.Text == "")
            {
                errorText = "Vui lòng nhập số huy hiệu";
                return false;
            }
            return true;
        }

        /// <summary>
        /// Update foreign keys need to insert
        /// </summary>
        /// <param name="quatrinhcongtac"></param>
        public void UpdateForeignKeys(ref HuyHieu quatrinh)
        {
            if (txtMaLoaiHuyHieu.Text != "")
            {
                quatrinh.MaLoaiHuyHieu = int.Parse(txtMaLoaiHuyHieu.Text);
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
                var newItem = new HuyHieu
                {
                    MaNhanVien = _nhanvien.MaNhanVien,
                    NamNhan = int.Parse(txtNam.Text),
                    SoHuyHieu = txtSoHuyHieu.Text,
                    GhiChu = txtGhiChu.Text
                };

                UpdateForeignKeys(ref newItem);

                if (!HuyHieuRepository.Insert(newItem))
                {
                    return false;
                }
                RefreshQuaTrinh(newItem.MaHuyHieu.ToString());
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
                var quatrinh = HuyHieuRepository.SelectByID(int.Parse(txtMaHuyHieu.Text));
                quatrinh.MaNhanVien = _nhanvien.MaNhanVien;
                quatrinh.NamNhan = int.Parse(txtNam.Text);
                quatrinh.SoHuyHieu = txtSoHuyHieu.Text;
                quatrinh.GhiChu = txtGhiChu.Text;

                UpdateForeignKeys(ref quatrinh);

                return QuaTrinhCongTacRepository.Save();
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Load info of current quatrinh
        /// If mode is insert: update txtMaHuyHieuCongTac
        /// Else: not change
        /// </summary>
        public void LoadCurrentQuaTrinhInfo(int id)
        {
            var item = HuyHieuRepository.SelectByID(id);

            txtMaHuyHieu.Text = id.ToString();
            txtNam.Text = item.NamNhan.ToString();
            txtSoHuyHieu.Text = item.SoHuyHieu;
            txtGhiChu.Text = item.GhiChu;

            txtLoaiHuyHieu.Text = item.MaLoaiHuyHieu == null ? "" : item.LoaiHuyHieu.TenLoaiHuyHieu;
            txtMaLoaiHuyHieu.Text = item.MaLoaiHuyHieu == null ? "" : item.MaLoaiHuyHieu.ToString();
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
            txtMaHuyHieu.Text = val;
        }

        /// <summary>
        /// Erase data in textboxes when mode is insert
        /// </summary>
        public void EraseTextboxes()
        {
            txtNam.Text = "";
            txtLoaiHuyHieu.Text = "";
            txtMaLoaiHuyHieu.Text = "";
            txtGhiChu.Text = "";
        }

        /// <summary>
        /// Set default status
        /// </summary>
        /// <param name="val">default is true</param>
        public void SetDefaultMode(bool val = true)
        {
            txtNam.ReadOnly = val;
            txtSoHuyHieu.ReadOnly = val;
            txtGhiChu.ReadOnly = val;

            btnChonHuyHieu.Enabled = !val;

            btnThem.Enabled = val;
            btnSua.Enabled = val;
            btnXoa.Enabled = val;
            btnGhi.Enabled = !val;
            btnHuy.Enabled = !val;
        }

    }
}