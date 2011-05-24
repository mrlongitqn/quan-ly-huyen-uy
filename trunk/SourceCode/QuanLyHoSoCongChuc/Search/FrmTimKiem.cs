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
            LoadDanToc();
            LoadTonGiao();
            LoadTrinhDoChinhTri();
            LoadHocHam();
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
                cbxGioiTinh.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Load list of dan toc
        /// </summary>
        public void LoadDanToc()
        {
            var lstItem = DanTocRepository.SelectAll();
            if (lstItem.Count > 0)
            {
                cbxDanToc.DataSource = lstItem;
                cbxDanToc.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Load list of ton giao
        /// </summary>
        public void LoadTonGiao()
        {
            var lstItem = TonGiaoRepository.SelectAll();
            if (lstItem.Count > 0)
            {
                cbxTonGiao.DataSource = lstItem;
                cbxTonGiao.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Load list of TrinhDoChinhTri
        /// </summary>
        public void LoadTrinhDoChinhTri()
        {
            var lstItem = TrinhDoChinhTriRepository.SelectAll();
            if (lstItem.Count > 0)
            {
                cbxLyLuanChinhTri.DataSource = lstItem;
                cbxLyLuanChinhTri.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Load list of TrinhDoChinhTri
        /// </summary>
        public void LoadHocHam()
        {
            var lstItem = TrinhDoHocVanRepository.SelectAll();
            if (lstItem.Count > 0)
            {
                cbxHocHam.DataSource = lstItem;
                cbxHocHam.SelectedIndex = -1;
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
            frm.Handler += GetNguyenQuan;
            frm.EnableButtonChon = true;
            frm.ShowDialog();
        }

        /// <summary>
        /// Get thong tin don vi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GetNguyenQuan(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtQueQuan.Text = comp[0];
            txtTenQueQuanDayDu.Text = comp[1];
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
