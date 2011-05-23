using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyHoSoCongChuc
{
    #region Using
    using QuanLyHoSoCongChuc.Models;
    using QuanLyHoSoCongChuc.Repositories;
    #endregion
    public partial class FrmThemPhanLoaiDonVi : Form
    {
        public EventHandler HandleExitForm { get; set; }
        public FrmThemPhanLoaiDonVi()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmThemPhanLoaiDonVi_Load(object sender, EventArgs e)
        {
            loadPhanLoaiDonVi();
        }
        void loadPhanLoaiDonVi()
        {
            cbPhanLoaiDonVi.Items.Clear();
            var lstPhanLoaiDonVi = PhanLoaiDonViRepository.SelectAll();
            for (int i = 0; i < lstPhanLoaiDonVi.Count; i++)
            {
                cbPhanLoaiDonVi.Items.Add(new ListItem(lstPhanLoaiDonVi[i].MaPhanLoai, lstPhanLoaiDonVi[i].TenPhanLoai));
            }
            if (lstPhanLoaiDonVi.Count > 0)
                cbPhanLoaiDonVi.SelectedIndex = 1;
        }

        private void cbPhanLoaiDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPhanLoaiDonVi.SelectedItem != null)
            {
                ListItem PhanLoaiDV = (ListItem)cbPhanLoaiDonVi.SelectedItem;
                txtMaPLDV.Text = PhanLoaiDV.ID;
            }
        }

        private void btnThemPLDV_Click(object sender, EventArgs e)
        {
            string MaDV = txtMaPLDV.Text;
            if (string.IsNullOrWhiteSpace(MaDV) == true)
            {
                MessageBox.Show("Mã Phân loại đơn vị không được bỏ trống.");
            }
            else
            {
                string TenDonVi = cbPhanLoaiDonVi.Text;

                if (PhanLoaiDonViRepository.SelectByID(MaDV) != null)
                {
                    MessageBox.Show("Phân loại đơn vị có mã " + MaDV + " đã tồn tại!");
                }
                else
                {
                    PhanLoaiDonVi pldv = new PhanLoaiDonVi();
                    pldv.MaPhanLoai = MaDV;
                    pldv.TenPhanLoai = TenDonVi;
                    bool result = PhanLoaiDonViRepository.Insert(pldv);
                    if (result)
                    {
                        MessageBox.Show("Thêm 1 phân loại đơn vị mới thành công.");
                    }
                }
            }
            loadPhanLoaiDonVi();
        }

        private void btnLuuPLDV_Click(object sender, EventArgs e)
        {
            var item = PhanLoaiDonViRepository.SelectByID(txtMaPLDV.Text);
            item.TenPhanLoai = cbPhanLoaiDonVi.Text;
            bool result = PhanLoaiDonViRepository.Save();
            if (result)
            {
                MessageBox.Show("Cập nhật phân loại đơn vị thành công.");
                loadPhanLoaiDonVi();
            }
        }

        private void btnXoaPLDV_Click(object sender, EventArgs e)
        {
            bool result = PhanLoaiDonViRepository.Delete(txtMaPLDV.Text);
            if (result)
            {
                MessageBox.Show("Xóa phân loại đơn vị thành công.");
                loadPhanLoaiDonVi();
            }
        }
    }
}
