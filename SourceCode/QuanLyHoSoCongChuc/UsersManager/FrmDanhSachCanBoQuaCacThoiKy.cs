using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using QuanLyHoSoCongChuc.Repositories;
using QuanLyHoSoCongChuc.Utils;
using QuanLyHoSoCongChuc.Models;
using WeifenLuo.WinFormsUI.Docking;

namespace QuanLyHoSoCongChuc.UsersManager
{
    /// <summary>
    /// tuansl added: view list of danh sach can bo qua cac thoi ki
    /// </summary>
    public partial class FrmDanhSachCanBoQuaCacThoiKy : DockContent
    {
        public FrmDanhSachCanBoQuaCacThoiKy()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {   
            Close();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            FrmChiTietCanBoQuaCacThoiKi frm = new FrmChiTietCanBoQuaCacThoiKi();
            frm.Handler += GetStateUpdate;
            frm.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lstvCanBo.SelectedItems.Count > 0)
            {
                //var canbo = (CanBoQuaCacThoiKi)lstvCanBo.SelectedItems[0].Tag;
                //if (CanBoQuaCacThoiKiRepository.Delete(canbo.MaCanBo))
                //{
                //    MessageBox.Show("Xóa cán bộ thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    LoadData();
                //}
                //else
                //{
                //    MessageBox.Show("Xóa cán bộ thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
            else
            {
                MessageBox.Show("Vui lòng chọn cán bộ cần xóa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            FrmTimCanBoQuaCacThoiKi frm = new FrmTimCanBoQuaCacThoiKi();
            frm.ShowDialog();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {

        }

        private void FrmDanhSachCanBoQuaCacThoiKy_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// Get thong tin don vi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GetStateUpdate(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            if (eventType.Data == "true")
            {
                LoadData();
            }
        }

        /// <summary>
        /// Load data from DB
        /// </summary>
        private void LoadData()
        {
            var lstItem = CanBoQuaCacThoiKiRepository.SelectAll();
            lstvCanBo.Items.Clear();
            if (lstItem.Count > 0)
            {
                for (int i = 0; i < lstItem.Count; i++)
                {
                    var objListViewItem = new ListViewItem();
                    //objListViewItem.Tag = lstItem[i];
                    //objListViewItem.Text = (i + 1).ToString();
                    //objListViewItem.SubItems.Add(lstItem[i].HoTen);
                    //objListViewItem.SubItems.Add(lstItem[i].TinhTrang.Value ? "Còn sống" : "Đã mất");
                    //objListViewItem.SubItems.Add(String.Format("{0:dd/MM/yyyy}", lstItem[i].NgaySinh.Value));
                    //objListViewItem.SubItems.Add(lstItem[i].NoiOHienNay);
                    lstvCanBo.Items.Add(objListViewItem);
                }
            }
        }

        private void lstvCanBo_DoubleClick(object sender, EventArgs e)
        {
            if (lstvCanBo.SelectedItems.Count > 0)
            {
                var canbo = (CanBoQuaCacThoiKi)lstvCanBo.SelectedItems[0].Tag;
                FrmChiTietCanBoQuaCacThoiKi frm = new FrmChiTietCanBoQuaCacThoiKi(canbo.MaCanBo);
                frm.Handler += GetStateUpdate;
                frm.ShowDialog();
            }
        }
    }
}