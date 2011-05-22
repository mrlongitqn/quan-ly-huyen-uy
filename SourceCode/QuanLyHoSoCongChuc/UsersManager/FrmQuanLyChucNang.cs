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
    /// Implement by le tuan: to manage chuc nang corresponding with menus in app
    /// </summary>
    public partial class FrmQuanLyChucNang : DevComponents.DotNetBar.Office2007Form
    {
        public FrmQuanLyChucNang()
        {
            InitializeComponent();
        }

        private void FrmQuanLyChucNang_Load(object sender, EventArgs e)
        {
            InitGridView();
            LoadData();
            // No choose any item
            dtgvChucNang.ClearSelection();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
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
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaChucNang.Text = "";
            txtTenChucNang.Text = "";
        }

        private void dtgvChucNang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvChucNang.SelectedRows == null || dtgvChucNang.SelectedRows.Count == 0)
                return;
            var selectedItem = dtgvChucNang.SelectedRows[0];
            txtMaChucNang.Text = ((ChucNang)selectedItem.DataBoundItem).MaChucNang.ToString();
            txtTenChucNang.Text = ((ChucNang)selectedItem.DataBoundItem).TenChucNang.ToString();
        }

        /// <summary>
        /// Init structure of gridview
        /// </summary>
        private void InitGridView()
        {
            dtgvChucNang.AutoGenerateColumns = false;
            dtgvChucNang.Columns.Clear();

            DataGridViewTextBoxColumn objColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã chức năng",
                DataPropertyName = "MaChucNang",
                Width = (int)((dtgvChucNang.Width - dtgvChucNang.RowHeadersWidth)*0.3)
            };
            dtgvChucNang.Columns.Add(objColumn);

            objColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên chức năng",
                DataPropertyName = "TenChucNang",
                Width = (int)((dtgvChucNang.Width - dtgvChucNang.RowHeadersWidth)*0.7 - 1)
            };
            dtgvChucNang.Columns.Add(objColumn);
        }

        /// <summary>
        /// Load data from DB
        /// </summary>
        private void LoadData()
        {
            var lstItem = ChucNangRepository.SelectAll();
            if (lstItem.Count > 0)
            {
                dtgvChucNang.DataSource = lstItem;
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
                if (txtMaChucNang.Text == "")
                {
                    errorText = "Vui lòng chọn chức năng";
                    return false;
                }
            }
            if (mode != EnumUpdateMode.DELETE)
            {
                if (txtTenChucNang.Text == "")
                {
                    errorText = "Vui lòng nhập tên chức năng";
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
                var item = new ChucNang
                {
                    TenChucNang = txtTenChucNang.Text
                };
                if (!ChucNangRepository.Insert(item))
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
                var item = ChucNangRepository.SelectByID(int.Parse(txtMaChucNang.Text));
                item.TenChucNang = txtTenChucNang.Text;
                return ChucNangRepository.Save();
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
                return ChucNangRepository.Delete(int.Parse(txtMaChucNang.Text));
            }
            catch
            {
                return false;
            }
        }
    }
}