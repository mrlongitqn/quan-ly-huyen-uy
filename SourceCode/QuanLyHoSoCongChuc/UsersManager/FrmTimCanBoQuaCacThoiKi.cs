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
    using QuanLyHoSoCongChuc.Utils;
    using QuanLyHoSoCongChuc.Models;
    using QuanLyHoSoCongChuc.Repositories;
    using QuanLyHoSoCongChuc.Danh_muc;
    using QuanLyHoSoCongChuc.DataManager;
    using QuanLyHoSoCongChuc.NhanVienManager;
    #endregion

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
            // Show waiting form
            GlobalVars.PreLoading();
            //------- E ---------

            var lstItem = CanBoQuaCacThoiKiRepository.SearchCanBoQuaCacThoiKi(txtMaDonVi.Text, txtHoTen.Text);
            lstvCanBo.Items.Clear();
            if (lstItem.Count > 0)
            {
                for (int i = 0; i < lstItem.Count; i++)
                {
                    var objListViewItem = new ListViewItem();
                    objListViewItem.Tag = lstItem[i];
                    objListViewItem.Text = (i + 1).ToString();
                    if (lstItem[i].LoaiCanBoQuaCacThoiKi.TenLoaiCanBoQuaCacThoiKi.ToUpper() == GlobalPhieuBaos.CHUYEN_DONVI ||
                        lstItem[i].LoaiCanBoQuaCacThoiKi.TenLoaiCanBoQuaCacThoiKi.ToUpper() == GlobalPhieuBaos.BO_DONVI ||
                        lstItem[i].LoaiCanBoQuaCacThoiKi.TenLoaiCanBoQuaCacThoiKi.ToUpper() == GlobalPhieuBaos.TUTRAN)
                    {
                        objListViewItem.SubItems.Add(lstItem[i].NhanVien.HoTenKhaiSinh);
                        objListViewItem.SubItems.Add(lstItem[i].NhanVien.NgaySinh == DateTime.MinValue ? "" : String.Format("{0:dd/MM/yyyy}", lstItem[i].NhanVien.NgaySinh.Value));
                    }
                    else if (lstItem[i].LoaiCanBoQuaCacThoiKi.TenLoaiCanBoQuaCacThoiKi.ToUpper() == GlobalPhieuBaos.NOIKHAC_CHUYENDEN)
                    {
                        objListViewItem.SubItems.Add(lstItem[i].CanBoVeHuuChuyenDen.HoTen);
                        objListViewItem.SubItems.Add(lstItem[i].CanBoVeHuuChuyenDen.NgaySinh == DateTime.MinValue ? "" : String.Format("{0:dd/MM/yyyy}", lstItem[i].CanBoVeHuuChuyenDen.NgaySinh.Value));
                    }
                    lstvCanBo.Items.Add(objListViewItem);
                }
            }

            // Hide waiting form
            GlobalVars.PosLoading();
            //------- E ---------
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnChonDonVi_Click(object sender, EventArgs e)
        {
            FrmDanhMuc frm = new FrmDanhMuc(true);
            frm.Handler += GetDonVi;
            frm.ShowDialog();
        }

        public void GetDonVi(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaDonVi.Text = comp[0];
        }

        private void lstvCanBo_DoubleClick(object sender, EventArgs e)
        {
            if (lstvCanBo.SelectedItems.Count > 0)
            {
                var canbo = (CanBoQuaCacThoiKi)lstvCanBo.SelectedItems[0].Tag;
                if (canbo.LoaiCanBoQuaCacThoiKi.TenLoaiCanBoQuaCacThoiKi.ToUpper() == GlobalPhieuBaos.CHUYEN_DONVI ||
                        canbo.LoaiCanBoQuaCacThoiKi.TenLoaiCanBoQuaCacThoiKi.ToUpper() == GlobalPhieuBaos.BO_DONVI ||
                        canbo.LoaiCanBoQuaCacThoiKi.TenLoaiCanBoQuaCacThoiKi.ToUpper() == GlobalPhieuBaos.TUTRAN)
                {
                    FrmThongTinNhanVien frm = new FrmThongTinNhanVien(canbo.NhanVien, canbo.LoaiCanBoQuaCacThoiKi.TenLoaiCanBoQuaCacThoiKi);
                    frm.Handler += NothingToProcess;
                    frm.ShowDialog();
                }
                else if (canbo.LoaiCanBoQuaCacThoiKi.TenLoaiCanBoQuaCacThoiKi.ToUpper() == GlobalPhieuBaos.NOIKHAC_CHUYENDEN)
                {
                    FrmChiTietCanBoQuaCacThoiKi frm = new FrmChiTietCanBoQuaCacThoiKi(canbo);
                    frm.Handler += NothingToProcess;
                    frm.ShowDialog();
                }
            }
        }

        private void NothingToProcess(object sender, EventArgs e)
        {
        }
    }
}