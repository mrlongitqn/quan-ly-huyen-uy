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
            LoadHocVan();
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
        /// Load list of LoadHocVan
        /// </summary>
        public void LoadHocVan()
        {
            var lstItem = TrinhDoHocVanRepository.SelectAll();
            if (lstItem.Count > 0)
            {
                cbxHocVan.DataSource = lstItem;
                cbxHocVan.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Load list of TrinhDoChinhTri
        /// </summary>
        public void LoadHocHam()
        {
            var lstItem = TrinhDoChuyenMonRepository.SelectAll();
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
            var item = PhuongXaRepository.SelectByID(comp[0]);
            txtQueQuan.Text = item.MaPhuongXa + "." + item.QuanHuyen.MaQuanHuyen + "." + item.QuanHuyen.TinhThanh.MaTinh;
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
            var nhanvien = new NhanVienModel
            {
                MaDonVi = txtMaDonVi.Text,
                HoTenNhanVien = txtHoTen.Text.Trim(),
                MaGioiTinh = cbxGioiTinh.SelectedIndex > -1 ? ((GioiTinh)cbxGioiTinh.SelectedItem).MaGioiTinh : null,
                QueQuan = txtQueQuan.Text.Trim(),
                MaDanToc = cbxDanToc.SelectedIndex > -1 ? ((DanToc)cbxDanToc.SelectedItem).MaDanToc : null,
                MaTonGiao = cbxTonGiao.SelectedIndex > -1 ? ((TonGiao)cbxTonGiao.SelectedItem).MaTonGiao : null,
                MaTrinhDoChinhTri = cbxLyLuanChinhTri.SelectedIndex > -1 ? ((TrinhDoChinhTri)cbxLyLuanChinhTri.SelectedItem).MaTrinhDoChinhTri : null,
                MaTrinhDoHocVan = cbxHocVan.SelectedIndex > -1 ? ((TrinhDoHocVan)cbxHocVan.SelectedItem).MaTrinhDoHocVan : null,
                MaTrinhDoChuyenMon = cbxHocHam.SelectedIndex > -1 ? ((TrinhDoChuyenMon)cbxHocHam.SelectedItem).MaTrinhDoChuyenMon : null,
                CongViecHienNay = txtCongVienChinh.Text.Trim()
            };
            if (ckbxEnableNgaySinh.Checked)
                nhanvien.NgaySinh = dtpSinhNgay.Value;
            if (ckbxEnableNgayVaoDang.Checked)
                nhanvien.NgayVaoDang = dtpNgayVaoDang.Value;
            if (ckbxEnableNgayChinhThuc.Checked)
                nhanvien.NgayChinhThuc = dtpNgayChinhThuc.Value;
            if (dmTuoiDoi.Text != "")
                nhanvien.TuoiDoi = int.Parse(dmTuoiDoi.Text);
            if (dmTuoiDang.Text != "")
                nhanvien.TuoiDang = int.Parse(dmTuoiDang.Text);

            var lstItem = NhanVienRepository.SearchByTieuChiChung(nhanvien);
            lstvNhanVien.Items.Clear();
            if (lstItem.Count > 0)
            {
                ListViewItem objListViewItem;
                for (int i = 0; i < lstItem.Count; i++)
                {
                    objListViewItem = new ListViewItem();
                    objListViewItem.Tag = lstItem[i];
                    objListViewItem.Text = lstItem[i].MaNhanVien;
                    objListViewItem.SubItems.Add(lstItem[i].HoTenNhanVien);
                    objListViewItem.SubItems.Add(lstItem[i].GioiTinh.TenGioiTinh);
                    objListViewItem.SubItems.Add(String.Format("{0:dd/MM/yyyy}", lstItem[i].NgaySinh));
                    objListViewItem.SubItems.Add(lstItem[i].NoiOHienTai);
                    lstvNhanVien.Items.Add(objListViewItem);
                }
                txtTongSo.Text = "Tìm thấy " + lstItem.Count + " nhân viên";
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        ///////////////////////////////////////////////////////////////////////////////
        // Process search by different criticals

        private void btnChonDonVi_TieuChiKhac_Click(object sender, EventArgs e)
        {
            FrmDanhMuc frm = new FrmDanhMuc();
            frm.Handler += GetDonVi4TieuChiKhac;
            frm.ShowDialog();
        }

        /// <summary>
        /// Get thong tin don vi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GetDonVi4TieuChiKhac(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaDonVi_TieuChiKhac.Text = comp[0];
        }

        private void rdbtnThongTinChung_Click(object sender, EventArgs e)
        {
            var criteria = new Criteria()
            {
                DBName = "NhanVien",
                DBProvider = new DBProvider()
            };
            LoadCriterias(criteria);
        }

        private void rdbtnQuaTrinhCongTac_Click(object sender, EventArgs e)
        {
            var criteria = new Criteria()
            {
                DBName = "QuaTrinhCongTac",
                DBProvider = new DBProvider()
            };
            LoadCriterias(criteria);
        }

        private void rdbtnQuaTrinhDaoTao_Click(object sender, EventArgs e)
        {
            var criteria = new Criteria()
            {
                DBName = "QuaTrinhDaoTao",
                DBProvider = new DBProvider()
            };
            LoadCriterias(criteria);
        }

        private void rdbtnNgoaiNgu_Click(object sender, EventArgs e)
        {
            var criteria = new Criteria()
            {
                DBName = "TrinhDoNgoaiNgu",
                DBProvider = new DBProvider()
            };
            LoadCriterias(criteria);
        }

        private void rdbtnQuaTrinhKhenThuong_Click(object sender, EventArgs e)
        {
            var criteria = new Criteria()
            {
                DBName = "KhenThuong",
                DBProvider = new DBProvider()
            };
            LoadCriterias(criteria);
        }

        private void rdbtnQuaTrinhKyLuat_Click(object sender, EventArgs e)
        {
            var criteria = new Criteria()
            {
                DBName = "KyLuat",
                DBProvider = new DBProvider()
            };
            LoadCriterias(criteria);
        }

        /// <summary>
        /// Load criterial corresponding with specified table
        /// </summary>
        public void LoadCriterias(Criteria criteria)
        {
            try
            {
                // Init criteria
                Table tbl = criteria.InitCriterias();
                lstvTenTruongDuLieu.Items.Clear();
                for (int i = 0; i < tbl.Attributes.Count; i++)
                {
                    if (tbl.Attributes[i].IsPrimaryKey)
                        continue;
                    var objListViewItem = new ListViewItem();
                    objListViewItem.Tag = tbl.Attributes[i];

                    if (tbl.Attributes[i].IsForeignKey)
                    {
                        if (tbl.Attributes[i].Name.Substring(0, 2).ToUpper() == "MA")
                            objListViewItem.Text = tbl.Attributes[i].Name.Substring(2);
                        else
                            objListViewItem.Text = tbl.Attributes[i].Name;
                    }
                    else
                        objListViewItem.Text = tbl.Attributes[i].Name;

                    lstvTenTruongDuLieu.Items.Add(objListViewItem);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        //--------------------- E --------------------------
    }
}
