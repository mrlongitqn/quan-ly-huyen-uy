using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace QuanLyHoSoCongChuc.UsersManager
{
    #region Using
    using QuanLyHoSoCongChuc.Models;
    using QuanLyHoSoCongChuc.Repositories;
    using QuanLyHoSoCongChuc.Utils;
    #endregion

    /// <summary>
    /// tuansl added: manage LoaiNguoiDung in app
    /// </summary>
    public partial class FrmQuanLyLoaiNguoiDung : DevComponents.DotNetBar.Office2007Form
    {
        public FrmQuanLyLoaiNguoiDung()
        {
            InitializeComponent();
        }

        private void FrmQuanLyLoaiNguoiDung_Load(object sender, EventArgs e)
        {
            InitGridView();
            LoadData();
            // No choose any item
            dtgvLoaiNguoiDung.ClearSelection();
        }

        private void dtgvChucNang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvLoaiNguoiDung.SelectedRows == null || dtgvLoaiNguoiDung.SelectedRows.Count == 0)
                return;
            var selectedItem = dtgvLoaiNguoiDung.SelectedRows[0];
            txtMaLoaiNguoiDung.Text = ((LoaiNguoiDung)selectedItem.DataBoundItem).MaQuyen.ToString();
            txtTenLoaiNguoiDung.Text = ((LoaiNguoiDung)selectedItem.DataBoundItem).TenQuyen.ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaLoaiNguoiDung.Text = "";
            txtTenLoaiNguoiDung.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var errorText = "";
            if (!ValidateInput(EnumUpdateMode.INSERT, ref errorText))
            {
                MessageBox.Show(errorText, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ActionAdd())
            {
                MessageBox.Show("Lưu dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Lưu dữ liệu thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var errorText = "";
            if (!ValidateInput(EnumUpdateMode.DELETE, ref errorText))
            {
                MessageBox.Show(errorText, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (ActionDelete())
                {
                    MessageBox.Show("Xóa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa dữ liệu thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            var errorText = "";
            if (!ValidateInput(EnumUpdateMode.UPDATE, ref errorText))
            {
                MessageBox.Show(errorText, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ActionUpdate())
            {
                MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Cập nhật dữ liệu thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Init structure of gridview
        /// </summary>
        private void InitGridView()
        {
            dtgvLoaiNguoiDung.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn objColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã loại người dùng",
                DataPropertyName = "MaQuyen",
                Width = (int)((dtgvLoaiNguoiDung.Width - dtgvLoaiNguoiDung.RowHeadersWidth) * 0.3)
            };
            dtgvLoaiNguoiDung.Columns.Add(objColumn);

            objColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên loại người dùng",
                DataPropertyName = "TenQuyen",
                Width = (int)((dtgvLoaiNguoiDung.Width - dtgvLoaiNguoiDung.RowHeadersWidth) * 0.7 - 1)
            };
            dtgvLoaiNguoiDung.Columns.Add(objColumn);
        }

        /// <summary>
        /// Load data from DB
        /// </summary>
        private void LoadData()
        {
            var lstItem = LoaiNguoiDungRepository.SelectAll();
            if (lstItem.Count > 0)
            {
                dtgvLoaiNguoiDung.DataSource = lstItem;
            }
        }

        /// <summary>
        /// Validate user input
        /// </summary>
        /// <param name="isUpdate"></param>
        /// <returns></returns>
        private bool ValidateInput(EnumUpdateMode mode, ref string errorText)
        {
            // Mode update -> checking MaChucNang is exists on textbox
            if (mode == EnumUpdateMode.UPDATE || mode == EnumUpdateMode.DELETE)
            {
                if (txtMaLoaiNguoiDung.Text == "")
                {
                    errorText = "Vui lòng chọn loại người dùng";
                    return false;
                }
            }
            if (mode != EnumUpdateMode.DELETE)
            {
                if (txtTenLoaiNguoiDung.Text == "")
                {
                    errorText = "Vui lòng nhập tên loại người dùng";
                    return false;
                }
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
                var item = new LoaiNguoiDung
                {
                    TenQuyen = txtTenLoaiNguoiDung.Text
                };
                if (!LoaiNguoiDungRepository.Insert(item))
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Update item with specificed ID
        /// </summary>
        /// <returns></returns>
        private bool ActionUpdate()
        {
            try
            {
                var item = LoaiNguoiDungRepository.SelectByID(int.Parse(txtMaLoaiNguoiDung.Text));
                item.TenQuyen = txtTenLoaiNguoiDung.Text;
                return LoaiNguoiDungRepository.Save();
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Delete item with specified ID
        /// </summary>
        /// <returns></returns>
        private bool ActionDelete()
        {
            try
            {
                return LoaiNguoiDungRepository.Delete(int.Parse(txtMaLoaiNguoiDung.Text));
            }
            catch
            {
                return false;
            }
        }
    }
}