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

namespace QuanLyHoSoCongChuc.UsersManager
{
    /// <summary>
    /// tuansl added: Search can bo qua cac thoi ki
    /// </summary>
    public partial class FrmTimCanBoQuaCacThoiKi : DevComponents.DotNetBar.Office2007Form
    {
        public EventHandler Handler { get; set; }
        public FrmTimCanBoQuaCacThoiKi()
        {
            InitializeComponent();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            var canbo = new CanBoQuaCacThoiKiModel
            {
                MaDonVi = txtMaDonVi.Text.Trim(),
                HoTen = txtHoTen.Text.Trim()
            };
            var lstItem = CanBoQuaCacThoiKiRepository.SearchCanBoQuaCacThoiKi(canbo);
            lstvCanBo.Items.Clear();
            if (lstItem.Count > 0)
            {
                for (int i = 0; i < lstItem.Count; i++)
                {
                    var objListViewItem = new ListViewItem();
                    objListViewItem.Tag = lstItem[i];
                    objListViewItem.Text = (i + 1).ToString();
                    objListViewItem.SubItems.Add(lstItem[i].HoTen);
                    objListViewItem.SubItems.Add(String.Format("{0:dd/MM/yyyy}", lstItem[i].NgaySinh.Value));
                    lstvCanBo.Items.Add(objListViewItem);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnChonDonVi_Click(object sender, EventArgs e)
        {
            FrmDanhMuc frm = new FrmDanhMuc();
            frm.Handler += GetDonVi;
            frm.EnableButtonChon = true;
            frm.ShowDialog();
        }

        /// <summary>
        /// Get thong tin don vi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GetDonVi(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaDonVi.Text = comp[0];
        }
    }
}