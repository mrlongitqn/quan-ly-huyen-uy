using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using WeifenLuo.WinFormsUI;
using QuanLyHoSoCongChuc.Controller;
using QuanLyHoSoCongChuc.BusinessObject;
using QuanLyHoSoCongChuc.Utils;
using QuanLyHoSoCongChuc.Report;

namespace QuanLyHoSoCongChuc.Search
{
    #region Using
    using QuanLyHoSoCongChuc.Models;
    using QuanLyHoSoCongChuc.Repositories;
    using QuanLyHoSoCongChuc.Utils;
    using WeifenLuo.WinFormsUI.Docking;
    #endregion

    /// <summary>
    /// tuansl added: tim kiem nhan vien
    /// </summary>
    public partial class FrmTimKiem : DockContent
    {
        public FrmTimKiem()
        {
            InitializeComponent();
        }

        private void FrmTimKiem_Load(object sender, EventArgs e)
        {
            LoadTieuChiChung();
        }

        /// <summary>
        /// Load tieu chi chung
        /// </summary>
        public void LoadTieuChiChung()
        {
            LoadGioiTinh();
        }

        /// <summary>
        /// Load list of gioi tinh
        /// </summary>
        public void LoadGioiTinh()
        {
            var lstItem = GioiTinhRepository.SelectAll();
            if (lstItem.Count > 0)
            {
                cbxGioiTinh.DataSource = lstItem;
            }
        }

        private void btnChonDonVi_Click(object sender, EventArgs e)
        {
            FrmDanhMuc frm = new FrmDanhMuc();
            frm.Handler += GetDonVi;
            frm.ShowDialog();
        }

        private void btnChonQueQuan_Click(object sender, EventArgs e)
        {
            FrmDanhMucHanhChinh frm = new FrmDanhMucHanhChinh();
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
            string[] comp = eventType.Data.Split(new char[]{ '#' });
            txtMaDonVi.Text = comp[0];
            txtTenDonViDayDu.Text = comp[1];
        }

        private void btnTim_Click(object sender, EventArgs e)
        {

        }
    }
}
