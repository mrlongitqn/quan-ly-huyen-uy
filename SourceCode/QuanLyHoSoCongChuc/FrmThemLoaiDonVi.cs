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
    public partial class FrmThemLoaiDonVi : Form
    {
        public FrmThemLoaiDonVi()
        {
            InitializeComponent();
        }

        private void FrmThemLoaiDonVi_Load(object sender, EventArgs e)
        {
            loadLoaiDonVi();
        }
        void loadLoaiDonVi()
        {
            cbLoaiDonVi.Items.Clear();
            var lstLoaiDonVi = LoaiDonViRepository.SelectAll();
            for (int i = 0; i < lstLoaiDonVi.Count; i++)
            {
                cbLoaiDonVi.Items.Add(new ListItem(lstLoaiDonVi[i].MaLoaiDonVi, lstLoaiDonVi[i].TenLoaiDonVi));
            }
            if (lstLoaiDonVi.Count > 0)
                cbLoaiDonVi.SelectedIndex = 1;
        }

        private void cbLoaiDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLoaiDonVi.SelectedItem != null)
            {
                ListItem LoaiDV = (ListItem)cbLoaiDonVi.SelectedItem;
                txtMaDoVi.Text = LoaiDV.ID;
            }
        }

        private void btnThemDonVi_Click(object sender, EventArgs e)
        {
            string MaDV = txtMaDoVi.Text;
            if (string.IsNullOrWhiteSpace(MaDV) == true)
            {
                MessageBox.Show("Mã đơn vị không được bỏ trống.");
            }
            else
            {
                string TenDonVi = cbLoaiDonVi.Text;

                if (LoaiDonViRepository.SelectByID(MaDV)!=null)
                {
                    MessageBox.Show("Loại đơn vị có mã " + MaDV + " đã tồn tại!");
                }
                else
                {
                    LoaiDonVi dv = new LoaiDonVi();
                    dv.MaLoaiDonVi =MaDV;
                    dv.TenLoaiDonVi = TenDonVi;
                    bool result = LoaiDonViRepository.Insert(dv);
                    if (result)
                    {
                        MessageBox.Show("Thêm 1 loại đơn vị mới thành công.");
                    }
                }
            }
            loadLoaiDonVi();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuuDonVi_Click(object sender, EventArgs e)
        {
            var item = LoaiDonViRepository.SelectByID(txtMaDoVi.Text);
            item.TenLoaiDonVi = cbLoaiDonVi.Text;
            bool result = LoaiDonViRepository.Save();
            if (result)
            {
                MessageBox.Show("Cập nhật loại đơn vị thành công.");
                loadLoaiDonVi();
            }
        }

        private void btnXoaDonVi_Click(object sender, EventArgs e)
        {
            bool result = LoaiDonViRepository.Delete(txtMaDoVi.Text);
            if (result)
            {
                MessageBox.Show("Xóa loại đơn vị thành công.");
                loadLoaiDonVi();
            }
        }
    }
}
