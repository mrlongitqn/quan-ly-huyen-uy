using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace QuanLyHoSoCongChuc.OtherForms
{
    #region Using
    using QuanLyHoSoCongChuc.Models;
    using QuanLyHoSoCongChuc.Repositories;
    using QuanLyHoSoCongChuc.Utils;
    #endregion

    /// <summary>
    /// tuansl added: manage loai don vi corresponding with menus in app
    /// </summary>
    public partial class FrmQuanLyLoaiDonVi: DevComponents.DotNetBar.Office2007Form
    {
        // tuansl added: event handler to transfer data to other forms
        public EventHandler Handler { get; set; }
        // ---------------- E -----------------

        public FrmQuanLyLoaiDonVi()
        {
            InitializeComponent();
            InitGridView();
        }

        private void FrmQuanLyLoaiDonVi_Load(object sender, EventArgs e)
        {
            LoadData();
            // No choose any item
            dtgvDataList.ClearSelection();
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
            txtMaLoaiDonVi.Text = "";
            txtTenLoaiDonVi.Text = "";
        }

        private void dtgvLoaiDonVi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvDataList.SelectedRows == null || dtgvDataList.SelectedRows.Count == 0)
                return;
            btnChon.Enabled = true;
            var selectedItem = dtgvDataList.SelectedRows[0];
            txtMaLoaiDonVi.Text = ((LoaiDonVi)selectedItem.DataBoundItem).MaLoaiDonVi.ToString();
            txtTenLoaiDonVi.Text = ((LoaiDonVi)selectedItem.DataBoundItem).TenLoaiDonVi.ToString();
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            var id = int.Parse(txtMaLoaiDonVi.Text);
            var name = LoaiDonViRepository.SelectByID(id).TenLoaiDonVi;
            TransferDataInfo(this, new MyEvent(id + "#" + name));
        }

        /// <summary>
        /// Init structure of gridview
        /// </summary>
        private void InitGridView()
        {
            dtgvDataList.AutoGenerateColumns = false;
            dtgvDataList.Columns.Clear();

            DataGridViewTextBoxColumn objColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã loại đơn vị",
                DataPropertyName = "MaLoaiDonVi",
                Width = (int)((dtgvDataList.Width - dtgvDataList.RowHeadersWidth) * 0.3)
            };
            dtgvDataList.Columns.Add(objColumn);

            objColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên loại đơn vị",
                DataPropertyName = "TenLoaiDonVi",
                Width = (int)((dtgvDataList.Width - dtgvDataList.RowHeadersWidth) * 0.7 - 1)
            };
            dtgvDataList.Columns.Add(objColumn);
        }

        /// <summary>
        /// Load data from DB
        /// </summary>
        private void LoadData()
        {
            var lstItem = LoaiDonViRepository.SelectAll();
            if (lstItem.Count > 0)
            {
                dtgvDataList.DataSource = lstItem;
            }
            dtgvDataList.ClearSelection();
        }

        /// <summary>
        /// Validate user input
        /// </summary>
        /// <param name="isUpdate"></param>
        /// <returns></returns>
        private bool ValidateInput(EnumUpdateMode mode, ref string errorText)
        {
            // Mode update -> checking MaLoaiDonVi is exists on textbox
            if (mode == EnumUpdateMode.UPDATE || mode == EnumUpdateMode.DELETE)
            {
                if (txtMaLoaiDonVi.Text == "")
                {
                    errorText = "Vui lòng chọn loại đơn vị";
                    return false;
                }
            }
            if (mode != EnumUpdateMode.DELETE)
            {
                if (txtTenLoaiDonVi.Text == "")
                {
                    errorText = "Vui lòng nhập tên loại đơn vị";
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
                var item = new LoaiDonVi
                {
                    TenLoaiDonVi = txtTenLoaiDonVi.Text
                };
                if (!LoaiDonViRepository.Insert(item))
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
                var item = LoaiDonViRepository.SelectByID(int.Parse(txtMaLoaiDonVi.Text));
                item.TenLoaiDonVi = txtTenLoaiDonVi.Text;
                return LoaiDonViRepository.Save();
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
                return LoaiDonViRepository.Delete(int.Parse(txtMaLoaiDonVi.Text));
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// tuansl added: function is used to transfer data when event would be raised
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TransferDataInfo(object sender, MyEvent e)
        {
            this.Close();
            this.Handler(this, e);
        }
        
    }
}