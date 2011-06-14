using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using DevComponents.DotNetBar;

namespace QuanLyHoSoCongChuc.UsersManager
{
    #region Using
    using QuanLyHoSoCongChuc.Repositories;
    using QuanLyHoSoCongChuc.Utils;
    using QuanLyHoSoCongChuc.Models;
    using QuanLyHoSoCongChuc.DataManager;
    using QuanLyHoSoCongChuc.NhanVienManager;
    #endregion

    /// <summary>
    /// tuansl added: view list of danh sach can bo qua cac thoi ki
    /// </summary>
    public partial class FrmDanhSachCanBoQuaCacThoiKy : DockContent
    {
        private string _maDonVi;
        private EnumLoaiCanBoQuaCacThoiKi _loaiCanBo;

        public FrmDanhSachCanBoQuaCacThoiKy(EnumLoaiCanBoQuaCacThoiKi loaicanbo)
        {
            InitializeComponent();
            _loaiCanBo = loaicanbo;
        }

        public FrmDanhSachCanBoQuaCacThoiKy(string madonvi)
        {
            InitializeComponent();
            _maDonVi = madonvi;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {   
            Close();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            FrmChiTietCanBoQuaCacThoiKi frm = new FrmChiTietCanBoQuaCacThoiKi(_maDonVi);
            frm.Handler += GetUpdatedState;
            frm.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lstvCanBo.SelectedItems.Count > 0)
            {
                var canbo = (CanBoQuaCacThoiKi)lstvCanBo.SelectedItems[0].Tag;
                if (CanBoQuaCacThoiKiRepository.Delete(canbo.MaCanBo))
                {
                    LoadData();
                    MessageBox.Show("Xóa cán bộ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa cán bộ thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            // Show waiting form
            GlobalVars.PreLoading();
            //------- E ---------
            LoadData();
        }

        /// <summary>
        /// Load data from DB
        /// </summary>
        private void LoadData()
        {
            if (_maDonVi != null)
            {
                var lstItem = CanBoQuaCacThoiKiRepository.SelectByMaDonVi(_maDonVi);
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
                            objListViewItem.SubItems.Add(lstItem[i].LoaiCanBoQuaCacThoiKi.TenLoaiCanBoQuaCacThoiKi);
                            objListViewItem.SubItems.Add(lstItem[i].NhanVien.NgaySinh == DateTime.MinValue ? "" : String.Format("{0:dd/MM/yyyy}", lstItem[i].NhanVien.NgaySinh.Value));
                            objListViewItem.SubItems.Add(lstItem[i].NhanVien.NoiOHienNay);
                        }
                        else if (lstItem[i].LoaiCanBoQuaCacThoiKi.TenLoaiCanBoQuaCacThoiKi.ToUpper() == GlobalPhieuBaos.NOIKHAC_CHUYENDEN)
                        {
                            objListViewItem.SubItems.Add(lstItem[i].CanBoVeHuuChuyenDen.HoTen);
                            objListViewItem.SubItems.Add(lstItem[i].LoaiCanBoQuaCacThoiKi.TenLoaiCanBoQuaCacThoiKi);
                            objListViewItem.SubItems.Add(lstItem[i].CanBoVeHuuChuyenDen.NgaySinh == DateTime.MinValue ? "" : String.Format("{0:dd/MM/yyyy}", lstItem[i].CanBoVeHuuChuyenDen.NgaySinh.Value));
                            objListViewItem.SubItems.Add(lstItem[i].CanBoVeHuuChuyenDen.NoiOHienNay);
                        }
                        lstvCanBo.Items.Add(objListViewItem);
                    }
                }
            }
            else
            {
                // Load all can bo
                LoadAllCanBo();
            }
        }

        public void LoadAllCanBo()
        {
            var lstItem = new List<CanBoQuaCacThoiKi>();
            switch (_loaiCanBo)
            {
                case EnumLoaiCanBoQuaCacThoiKi.CHUYEN_DONVI:
                    lstItem = CanBoQuaCacThoiKiRepository.SelectCanBoQuaCacThoiKi(EnumLoaiCanBoQuaCacThoiKi.CHUYEN_DONVI);
                    break;
                case EnumLoaiCanBoQuaCacThoiKi.BO_DONVI:
                    lstItem = CanBoQuaCacThoiKiRepository.SelectCanBoQuaCacThoiKi(EnumLoaiCanBoQuaCacThoiKi.BO_DONVI);
                    break;
                case EnumLoaiCanBoQuaCacThoiKi.TUTRAN:
                    lstItem = CanBoQuaCacThoiKiRepository.SelectCanBoQuaCacThoiKi(EnumLoaiCanBoQuaCacThoiKi.TUTRAN);
                    break;
            }

            lstvCanBo.Items.Clear();
            if (lstItem.Count > 0)
            {
                for (int i = 0; i < lstItem.Count; i++)
                {
                    var objListViewItem = new ListViewItem();
                    objListViewItem.Tag = lstItem[i];
                    objListViewItem.Text = (i + 1).ToString();
                    objListViewItem.SubItems.Add(lstItem[i].NhanVien.HoTenKhaiSinh);
                    objListViewItem.SubItems.Add(lstItem[i].LoaiCanBoQuaCacThoiKi.TenLoaiCanBoQuaCacThoiKi);
                    objListViewItem.SubItems.Add(lstItem[i].NhanVien.NgaySinh == DateTime.MinValue ? "" : String.Format("{0:dd/MM/yyyy}", lstItem[i].NhanVien.NgaySinh.Value));
                    objListViewItem.SubItems.Add(lstItem[i].NhanVien.NoiOHienNay);
                    lstvCanBo.Items.Add(objListViewItem);
                }
            }
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
                    FrmThongTinNhanVien frm = new FrmThongTinNhanVien(canbo.NhanVien, canbo.LoaiCanBoQuaCacThoiKi.TenLoaiCanBoQuaCacThoiKi.ToUpper());
                    frm.Handler += GetUpdatedState;
                    frm.ShowDialog();
                }
                else if (canbo.LoaiCanBoQuaCacThoiKi.TenLoaiCanBoQuaCacThoiKi.ToUpper() == GlobalPhieuBaos.NOIKHAC_CHUYENDEN)
                {
                    FrmChiTietCanBoQuaCacThoiKi frm = new FrmChiTietCanBoQuaCacThoiKi(canbo);
                    frm.Handler += GetUpdatedState;
                    frm.ShowDialog();
                }
            }
        }

        public void GetUpdatedState(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            if (eventType.Data == "true")
            {
                LoadData();
            }
        }

        private void FrmDanhSachCanBoQuaCacThoiKy_Shown(object sender, EventArgs e)
        {
            // Hide waiting form
            GlobalVars.PosLoading();
            //------- E ---------
        }
    }
}