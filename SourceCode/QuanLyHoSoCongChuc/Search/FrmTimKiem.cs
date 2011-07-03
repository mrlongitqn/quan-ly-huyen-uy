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
    using QuanLyHoSoCongChuc.Danh_muc;
    using QuanLyHoSoCongChuc.NhanVienManager;
    using QuanLyHoSoCongChuc.OtherForms;
    #endregion

    /// <summary>
    /// tuansl added: tim kiem nhan vien
    /// </summary>
    public partial class FrmTimKiem : DevComponents.DotNetBar.Office2007Form
    {
        #region Variables
        public bool bnLoading;
        // Hidden files are used to store ids 
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaDanToc;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaTonGiao;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaLLCT;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaHocHam;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaHocViCaoNhat;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaGioiTinh;
        #endregion

        #region Constructors
        public FrmTimKiem()
        {
            bnLoading = true;
            InitializeComponent();
            InitHiddenFields();
            InitControlGiaTriTimKiem();
            InitDomain();
            bnLoading = false;
        }

        public FrmTimKiem(string _madonvi, string _tendaydu)
        {
            bnLoading = true;
            InitializeComponent();
            InitHiddenFields();
            InitControlGiaTriTimKiem();
            InitDomain();

            txtMaDonVi.Text = _madonvi;
            txtTenDonViDayDu.Text = _tendaydu;
            txtMaDonVi_TieuChiKhac.Text = _madonvi;
            bnLoading = false;
        }

        public FrmTimKiem(CauHoiNguoiDung cauhoi)
        {
            bnLoading = true;
            InitializeComponent();
            InitHiddenFields();
            InitControlGiaTriTimKiem();
            FillQueryDataToListView(cauhoi);
            InitDomain();

            tabControl1.SelectedTabIndex = 1;
            bnLoading = false;
        }
        #endregion

        #region Methods
        public void InitDomain()
        {
            for (int i = 100; i >= 18; i--)
            {
                dmTuoiDoi.Items.Add(i);
            }
            for (int i = 100; i >=1; i--)
            {
                dmTuoiDang.Items.Add(i);
            }
        }

        /// <summary>
        /// Init hidden fields
        /// </summary>
        public void InitHiddenFields()
        {
            // Add a new textbox
            txtMaDanToc = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaDanToc",
                Text = ""
            };
            txtMaDanToc.Visible = false;

            // Add a new textbox
            txtMaTonGiao = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaTonGiao",
                Text = ""
            };
            txtMaTonGiao.Visible = false;

            // Add a new textbox
            txtMaLLCT = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaLLCT",
                Text = ""
            };
            txtMaLLCT.Visible = false;

            // Add a new textbox
            txtMaHocHam = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaHocHam",
                Text = ""
            };
            txtMaHocHam.Visible = false;

            // Add a new textbox
            txtMaHocViCaoNhat = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaHocViCaoNhat",
                Text = ""
            };
            txtMaHocViCaoNhat.Visible = false;

            // Add a new textbox
            txtMaGioiTinh = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaGioiTinh",
                Text = ""
            };
            txtMaGioiTinh.Visible = false;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // tuansl added: SEARCH BY TIEU CHI CHUNG
        ///////////////////////////////////////////////////////////////////////////////////////////////

        private void FrmTimKiem_Load(object sender, EventArgs e)
        {
            InitLstTruongHienThi();
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
            txtTenDonViDayDu.Text = comp[1];
        }

        private void btnChonQueQuan_Click(object sender, EventArgs e)
        {
            FrmDanhMucHanhChinh frm = new FrmDanhMucHanhChinh();
            frm.Handler += GetNguyenQuan;
            frm.EnableButtonChon = true;
            frm.ShowDialog();
        }

        public void GetNguyenQuan(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            var item = PhuongXaRepository.SelectByID(comp[0]);
            txtQueQuan.Text = item.MaPhuongXa + "." + item.QuanHuyen.MaQuanHuyen + "." + item.QuanHuyen.TinhThanh.MaTinh;
            txtTenQueQuanDayDu.Text = comp[1];
        }

        private void btnChonDanToc_Click(object sender, EventArgs e)
        {
            FrmQuanLyDanToc frm = new FrmQuanLyDanToc();
            frm.Handler += GetDanToc;
            frm.ShowDialog();
        }

        public void GetDanToc(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaDanToc.Text = comp[0];
            txtDanToc.Text = comp[1];
        }

        private void btnChonTonGiao_Click(object sender, EventArgs e)
        {
            FrmQuanLyTonGiao frm = new FrmQuanLyTonGiao();
            frm.Handler += GetTonGiao;
            frm.ShowDialog();
        }

        public void GetTonGiao(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaTonGiao.Text = comp[0];
            txtTonGiao.Text = comp[1];
        }

        private void btnChonLLCT_Click(object sender, EventArgs e)
        {
            FrmQuanLyBangLyLuanChinhTri frm = new FrmQuanLyBangLyLuanChinhTri();
            frm.Handler += GetLLCT;
            frm.ShowDialog();
        }

        public void GetLLCT(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaLLCT.Text = comp[0];
            txtLLCT.Text = comp[1];
        }

        private void btnChonHocHam_Click(object sender, EventArgs e)
        {
            FrmQuanLyHocHam frm = new FrmQuanLyHocHam();
            frm.Handler += GetHocHam;
            frm.ShowDialog();
        }

        public void GetHocHam(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaHocHam.Text = comp[0];
            txtHocHam.Text = comp[1];
        }

        private void btnChonHocVi_Click(object sender, EventArgs e)
        {
            FrmQuanLyHocVi frm = new FrmQuanLyHocVi();
            frm.Handler += GetHocVi;
            frm.ShowDialog();
        }

        public void GetHocVi(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaHocViCaoNhat.Text = comp[0];
            txtHocViCaoNhat.Text = comp[1];
        }

        private void btnChonGioiTinh_Click(object sender, EventArgs e)
        {
            FrmQuanLyGioiTinh frm = new FrmQuanLyGioiTinh();
            frm.Handler += GetGioiTinh;
            frm.ShowDialog();
        }

        public void GetGioiTinh(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaGioiTinh.Text = comp[0];
            txtGioiTinh.Text = comp[1];
        }

        public void UpdateGeneralCriterias(NhanVienModel nv)
        {
            nv.MaDonVi = txtMaDonVi.Text;
            nv.HoTenKhaiSinh = txtHoTen.Text.Trim();
            nv.QueQuan = txtTenQueQuanDayDu.Text.Trim();
            nv.CongViecChinh = txtCongVienChinh.Text.Trim();
            nv.NgaySinh = dtNgaySinh.Value;

            nv.MaGioiTinh = txtMaGioiTinh.Text == "" ? -1 : int.Parse(txtMaGioiTinh.Text);
            nv.MaDanToc = txtMaDanToc.Text == "" ? -1 : int.Parse(txtMaDanToc.Text);
            nv.MaTonGiao = txtMaTonGiao.Text == "" ? -1 : int.Parse(txtMaTonGiao.Text);
            nv.MaBangLyLuanChinhTri = txtMaLLCT.Text == "" ? -1 : int.Parse(txtMaLLCT.Text);
            nv.MaHocHam = txtMaHocHam.Text == "" ? -1 : int.Parse(txtMaHocHam.Text);
            nv.MaHocVi = txtMaHocViCaoNhat.Text == "" ? -1 : int.Parse(txtMaHocViCaoNhat.Text);

            nv.NgayVaoDang = dtNgayVaoDang.Value;
            nv.NgayChinhThuc = dtNgayChinhThuc.Value;

            nv.TuoiDoi = dmTuoiDoi.Text == "" ? -1 : int.Parse(dmTuoiDoi.Text);
            nv.TuoiDang = dmTuoiDang.Text == "" ? -1 : int.Parse(dmTuoiDang.Text);
        }

        public int GetSoNhanVienNu(List<NhanVien> lstItem)
        {
            int count = 0;
            for (int i = 0; i < lstItem.Count; i++)
            {
                if (lstItem[i].MaGioiTinh != null)
                {
                    if (lstItem[i].GioiTinh.TenGioiTinh.ToUpper().Contains("NỮ"))
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public int GetSoNhanVienDTItNguoi(List<NhanVien> lstItem)
        {
            int count = 0;
            for (int i = 0; i < lstItem.Count; i++)
            {
                if (lstItem[i].MaDanToc != null)
                {
                    if (lstItem[i].DanToc.TenDanToc.ToUpper().Contains("KINH"))
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public int GetSoNhanVienCoBangDH(List<NhanVien> lstItem)
        {
            int count = 0;
            for (int i = 0; i < lstItem.Count; i++)
            {
                if (lstItem[i].MaHocVi != null)
                {
                    if (lstItem[i].HocVi.TenHocVi.ToUpper().Contains("ĐẠI HỌC"))
                    {
                        count++;
                    }

                }
            }
            return count;
        }

        public float CalTuoiBinhQuan(List<NhanVien> lstItem)
        {
            int tuoitong = 0;
            for (int i = 0; i < lstItem.Count; i++)
            {
                tuoitong += (DateTime.Now.Year - lstItem[i].NgaySinh.Value.Year);
            }
            return tuoitong/lstItem.Count;
        }

        public void UpdateTongHopKQ(List<NhanVien> lstItem)
        {
            lstvTongHopKQ.Items.Clear();
            ListViewItem objListViewItem;
            for (int i = 0; i < 6; i++)
            {
                objListViewItem = new ListViewItem();
                if (i == 0)
                {
                    objListViewItem.Text = "Số nhân viên tìm thấy";
                    objListViewItem.SubItems.Add(lstItem.Count.ToString());
                }
                else if (i == 1)
                {
                    objListViewItem.Text = "Trong đó";
                }
                else if (i == 2)
                {
                    objListViewItem.Text = "Nhân viên nữ";
                    var numNV = GetSoNhanVienNu(lstItem);
                    objListViewItem.SubItems.Add(numNV.ToString());
                    objListViewItem.SubItems.Add(String.Format("{0:0.##}", (numNV * 100) / lstItem.Count));
                }
                else if (i == 3)
                {
                    objListViewItem.Text = "Nhân viên dân tộc ít người";
                    var numNV = GetSoNhanVienDTItNguoi(lstItem);
                    objListViewItem.SubItems.Add(numNV.ToString());
                    objListViewItem.SubItems.Add(String.Format("{0:0.##}", (numNV * 100) / lstItem.Count));
                }
                else if (i == 4)
                {
                    objListViewItem.Text = "Tuổi bình quân";
                    objListViewItem.SubItems.Add(CalTuoiBinhQuan(lstItem).ToString());
                }
                else if (i == 5)
                {
                    objListViewItem.Text = "Trình độ đại học trở lên";
                    var numNV = GetSoNhanVienCoBangDH(lstItem);
                    objListViewItem.SubItems.Add(numNV.ToString());
                    objListViewItem.SubItems.Add(String.Format("{0:0.##}", (numNV * 100) / lstItem.Count));
                }
                lstvTongHopKQ.Items.Add(objListViewItem);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            // Show waiting form
            GlobalVars.PreLoading();
            //------- E ---------

            var nhanvien = new NhanVienModel();
            UpdateGeneralCriterias(nhanvien);

            var lstItem = NhanVienRepository.SearchByTieuChiChung(nhanvien);
            lstvNhanVien.Items.Clear();
            //Searching
            UpdateTruongHienThi();

            if (lstItem.Count > 0)
            {
                ListViewItem objListViewItem;
                for (int i = 0; i < lstItem.Count; i++)
                {
                    objListViewItem = new ListViewItem();
                    objListViewItem.Tag = lstItem[i];

                    for (int j = 0; j < GlobalSearch.LstTruongHienThi.Count; j++)
                    {
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "MaNhanVien") != null)
                        {
                            objListViewItem.Text = lstItem[i].MaNhanVien;
                        }
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "SoLyLich") != null)
                        {
                            objListViewItem.SubItems.Add(lstItem[i].SoLyLich);
                        }
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "SoTheDangVien") != null)
                        {
                            objListViewItem.SubItems.Add(lstItem[i].SoTheDangVien);
                        }
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "HoTenKhaiSinh") != null)
                        {
                            objListViewItem.SubItems.Add(lstItem[i].HoTenKhaiSinh);
                        }
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "HoTenDangDung") != null)
                        {
                            objListViewItem.SubItems.Add(lstItem[i].HoTenDangDung);
                        }
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "SoCMND") != null)
                        {
                            objListViewItem.SubItems.Add(lstItem[i].SoCMND);
                        }
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "MaGioiTinh") != null)
                        {
                            objListViewItem.SubItems.Add(lstItem[i].MaGioiTinh != null ? lstItem[i].GioiTinh.TenGioiTinh : "");
                        }
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "NgaySinh") != null)
                        {
                            objListViewItem.SubItems.Add(String.Format("{0:dd/MM/yyyy}", lstItem[i].NgaySinh.ToString()));
                        }
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "NoiSinh") != null)
                        {
                            objListViewItem.SubItems.Add(lstItem[i].NoiSinh);
                        }
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "QueQuan") != null)
                        {
                            objListViewItem.SubItems.Add(lstItem[i].QueQuan);
                        }
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "HoKhau") != null)
                        {
                            objListViewItem.SubItems.Add(lstItem[i].HoKhau);
                        }
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "NoiOHienNay") != null)
                        {
                            objListViewItem.SubItems.Add(lstItem[i].NoiOHienNay);
                        }
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "MaDonVi") != null)
                        {
                            objListViewItem.SubItems.Add(lstItem[i].MaDonVi != null ? lstItem[i].DonVi.TenDonVi : "");
                        }
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "CongViecChinh") != null)
                        {
                            objListViewItem.SubItems.Add(lstItem[i].CongViecChinh);
                        }
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "NgayVaoDang") != null)
                        {
                            objListViewItem.SubItems.Add(String.Format("{0:dd/MM/yyyy}", lstItem[i].NgayVaoDang.ToString()));
                        }
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "VaoDangTaiChiBo") != null)
                        {
                            objListViewItem.SubItems.Add(lstItem[i].VaoDangTaiChiBo);
                        }
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "NguoiGioiThieu1") != null)
                        {
                            objListViewItem.SubItems.Add(lstItem[i].NguoiGioiThieu1);
                        }
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "ChucVuNguoi1") != null)
                        {
                            objListViewItem.SubItems.Add(lstItem[i].ChucVuNguoi1);
                        }
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "NguoiGioiThieu2") != null)
                        {
                            objListViewItem.SubItems.Add(lstItem[i].NguoiGioiThieu2);
                        }
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "ChucVuNguoi2") != null)
                        {
                            objListViewItem.SubItems.Add(lstItem[i].ChucVuNguoi2);
                        }
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "NgayChinhThuc") != null)
                        {
                            objListViewItem.SubItems.Add(String.Format("{0:dd/MM/yyyy}", lstItem[i].NgayChinhThuc.Value));
                        }
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "ChinhThucTaiChiBo") != null)
                        {
                            objListViewItem.SubItems.Add(lstItem[i].ChinhThucTaiChiBo);
                        }
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "NgayTuyenDung") != null)
                        {
                            objListViewItem.SubItems.Add(String.Format("{0:dd/MM/yyyy}", lstItem[i].NgayTuyenDung.Value));
                        }
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "CoQuanTuyenDung") != null)
                        {
                            objListViewItem.SubItems.Add(lstItem[i].CoQuanTuyenDung);
                        }








                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "MaDanToc") != null)
                        {
                            objListViewItem.SubItems.Add(lstItem[i].MaDanToc != null ? lstItem[i].DanToc.TenDanToc : "");
                        }
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "MaTonGiao") != null)
                        {
                            objListViewItem.SubItems.Add(lstItem[i].MaTonGiao != null ? lstItem[i].TonGiao.TenTonGiao : "");
                        }
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "MaThanhPhanGiaDinh") != null)
                        {
                            objListViewItem.SubItems.Add(lstItem[i].MaThanhPhanGiaDinh != null ? lstItem[i].ThanhPhanGiaDinh.TenThanhPhanGiaDinh : "");
                        }
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "MaNgheNghiepTruocKhiDuocTuyenDung") != null)
                        {
                            objListViewItem.SubItems.Add(lstItem[i].MaNgheNghiepTruocKhiDuocTuyenDung != null ? lstItem[i].NgheNghiep.TenNgheNghiep : "");
                        }
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "MaBangGiaoDucPhoThong") != null)
                        {
                            objListViewItem.SubItems.Add(lstItem[i].MaBangGiaoDucPhoThong != null ? lstItem[i].BangGiaoDucPhoThong.TenBangGiaoDucPhoThong : "");
                        }
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "MaBangChuyenMonNghiepVu") != null)
                        {
                            objListViewItem.SubItems.Add(lstItem[i].MaBangChuyenMonNghiepVu != null ? lstItem[i].BangChuyenMonNghiepVu.TenBangChuyenMonNghiepVu : "");
                        }
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "MaBangLyLuanChinhTri") != null)
                        {
                            objListViewItem.SubItems.Add(lstItem[i].MaBangLyLuanChinhTri != null ? lstItem[i].BangLyLuanChinhTri.TenBangLyLuanChinhTri : "");
                        }
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "MaBangNgoaiNgu") != null)
                        {
                            objListViewItem.SubItems.Add(lstItem[i].MaBangNgoaiNgu != null ? lstItem[i].BangNgoaiNgu.TenBangNgoaiNgu : "");
                        }
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "MaHocVi") != null)
                        {
                            objListViewItem.SubItems.Add(lstItem[i].MaHocVi != null ? lstItem[i].HocVi.TenHocVi : "");
                        }
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "MaHocHam") != null)
                        {
                            objListViewItem.SubItems.Add(lstItem[i].MaHocHam != null ? lstItem[i].HocHam.TenHocHam : "");
                        }
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "MaTinhTrangSucKhoe") != null)
                        {
                            objListViewItem.SubItems.Add(lstItem[i].MaTinhTrangSucKhoe != null ? lstItem[i].TinhTrangSucKhoe.TenTinhTrangSucKhoe : "");
                        }
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "MaLoaiThuongBinh") != null)
                        {
                            objListViewItem.SubItems.Add(lstItem[i].MaLoaiThuongBinh != null ? lstItem[i].LoaiThuongBinh.TenLoaiThuongBinh : "");
                        }
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "MaChucVu") != null)
                        {
                            objListViewItem.SubItems.Add(lstItem[i].MaChucVu != null ? ChucVuRepository.SelectByID(lstItem[i].MaChucVu.Value).TenChucVu : "");
                        }
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "MaChucVuKiemNhiem") != null)
                        {
                            objListViewItem.SubItems.Add(lstItem[i].MaChucVuKiemNhiem != null ? ChucVuRepository.SelectByID(lstItem[i].MaChucVuKiemNhiem.Value).TenChucVu : "");
                        }
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "MaNgachCongChuc") != null)
                        {
                            objListViewItem.SubItems.Add(lstItem[i].MaNgachCongChuc != null ? lstItem[i].NgachCongChuc.TenNgachCongChuc : "");
                        }
                        if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "MaHuong85") != null)
                        {
                            objListViewItem.SubItems.Add(lstItem[i].MaHuong85 != null ? lstItem[i].Huong85.GiaTriHuong : "");
                        }
                    }

                    
                    objListViewItem.SubItems.Add(lstItem[i].HoTenKhaiSinh);
                    objListViewItem.SubItems.Add(lstItem[i].MaGioiTinh == null ? "" : lstItem[i].GioiTinh.TenGioiTinh);
                    objListViewItem.SubItems.Add(lstItem[i].NgaySinh.Value == DateTime.MinValue ? "" : String.Format("{0:dd/MM/yyyy}", lstItem[i].NgaySinh));
                    objListViewItem.SubItems.Add(lstItem[i].NoiOHienNay);
                    lstvNhanVien.Items.Add(objListViewItem);
                }

                UpdateTongHopKQ(lstItem);
            }
            txtTongSo.Text = "Tìm thấy " + lstItem.Count + " nhân viên";

            // Hide waiting form
            GlobalVars.PosLoading();
            //------- E ---------
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // tuansl added: SEARCH BY TIEU CHI KHAC
        ///////////////////////////////////////////////////////////////////////////////////////////////
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbxGiaTriTimKiem;
        private DevComponents.DotNetBar.Controls.TextBoxX txtGiaTriTimKiem;

        private void btnChonDonVi_TieuChiKhac_Click(object sender, EventArgs e)
        {
            FrmDanhMuc frm = new FrmDanhMuc(true);
            frm.Handler += GetDonVi4TieuChiKhac;
            frm.ShowDialog();
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
                DBName = "BangNgoaiNgu",
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

        private void rdbtnDanhHuyHieu_Click(object sender, EventArgs e)
        {
            var criteria = new Criteria()
            {
                DBName = "HuyHieu",
                DBProvider = new DBProvider()
            };
            LoadCriterias(criteria);
        }

        private void rdbtnQuanHeGiaDinh_Click(object sender, EventArgs e)
        {
            var criteria = new Criteria()
            {
                DBName = "ThanNhan",
                DBProvider = new DBProvider()
            };
            LoadCriterias(criteria);
        }

        private void lstvTenTruongDuLieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvTenTruongDuLieu.SelectedItems.Count > 0)
            {
                try
                {
                    var item = (Attribute)lstvTenTruongDuLieu.SelectedItems[0].Tag;
                    LoadControlGiaTriTimKiem(item);
                    cbxDieuKien.SelectedIndex = -1;
                    cbxDieuKien.Text = "";
                    cbxGiaTriTimKiem.SelectedIndex = -1;
                    txtGiaTriTimKiem.Text = "";
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }
        }

        private void btnThemDieuKien_Click(object sender, EventArgs e)
        {
            if (lstvTenTruongDuLieu.SelectedItems.Count > 0)
            {
                var errorText = "";
                if (!ValidateThemDieuKien(ref errorText))
                {
                    MessageBox.Show(errorText, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var dieukientimkiem = new DieuKienTimKiem
                {
                    Attr = (Attribute)lstvTenTruongDuLieu.SelectedItems[0].Tag,
                    Condition = cbxDieuKien.Text,
                    Value = cbxGiaTriTimKiem.Visible ? GetGiaTriTimKiem(cbxGiaTriTimKiem.SelectedItem).Trim() : txtGiaTriTimKiem.Text.Trim(),
                    AndOr = lstvDieuKienTimKiem.Items.Count > 0 ? (rdbtnVa.Checked ? "And" : "Or") : ""
                };
                // Add item to lstview
                var objListViewItem = new ListViewItem
                {
                    Tag = dieukientimkiem,
                    Text = dieukientimkiem.AndOr + " " + dieukientimkiem.Attr.Name + dieukientimkiem.Condition + dieukientimkiem.Value
                };
                lstvDieuKienTimKiem.Items.Add(objListViewItem);
                cbxDieuKien.SelectedIndex = -1;
                cbxGiaTriTimKiem.SelectedIndex = -1;
                txtGiaTriTimKiem.Text = "";
            }
        }

        private void btnXoaDieuKien_Click(object sender, EventArgs e)
        {
            if (lstvDieuKienTimKiem.Items.Count > 0)
            {
                lstvDieuKienTimKiem.Items.RemoveAt(lstvDieuKienTimKiem.Items.Count - 1);
            }
        }

        private void btnMo_Click(object sender, EventArgs e)
        {
            FrmMoCauHoi frm = new FrmMoCauHoi();
            frm.Handler += GetCauHoi;
            frm.ShowDialog();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Init list of searching condition to transfer data 
            List<DieuKienTimKiem> lstDieuKienTimKiem = new List<DieuKienTimKiem>();
            for (int i = 0; i < lstvDieuKienTimKiem.Items.Count; i++)
            {
                lstDieuKienTimKiem.Add((DieuKienTimKiem)lstvDieuKienTimKiem.Items[i].Tag);
            }
            // Show form luucauhoi
            if (lstDieuKienTimKiem.Count > 0)
            {
                FrmLuuCauHoi frm = new FrmLuuCauHoi
                {
                    Bang = GetBang(),
                    LstDieuKienTimKiem = lstDieuKienTimKiem,
                    MaDonVi = txtMaDonVi.Text.Trim()
                };
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Không có giá trị tìm kiếm để lưu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnDKMoi_Click(object sender, EventArgs e)
        {
            lstvDieuKienTimKiem.Items.Clear();
        }

        private void btnTim_TieuChiKhac_Click(object sender, EventArgs e)
        {
            int num = lstvDieuKienTimKiem.Items.Count;

            if (num <= 0)
            {
                MessageBox.Show("Không có giá trị tìm kiếm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Show waiting form
            GlobalVars.PreLoading();
            //------- E ---------

            // Init list of searching condition to transfer data 
            List<DieuKienTimKiem> lstDieuKienTimKiem = new List<DieuKienTimKiem>();
            for (int i = 0; i < num; i++)
            {
                lstDieuKienTimKiem.Add((DieuKienTimKiem)lstvDieuKienTimKiem.Items[i].Tag);
            }
            // Show form luucauhoi
            if (lstDieuKienTimKiem.Count > 0)
            {
                var bang = GetBang();
                var sqlQuery = "";
                switch (bang)
                {
                    case "NhanVien":
                        sqlQuery = BuildSearchByTieuChiChungQuery(lstDieuKienTimKiem, txtMaDonVi_TieuChiKhac.Text.Trim());
                        break;
                    case "QuaTrinhCongTac":
                        sqlQuery = BuildSearchByQuaTrinhCongTacQuery(lstDieuKienTimKiem, txtMaDonVi_TieuChiKhac.Text.Trim());
                        break;
                    case "QuaTrinhDaoTao":
                        sqlQuery = BuildSearchByQuaTrinhDaoTaoQuery(lstDieuKienTimKiem, txtMaDonVi_TieuChiKhac.Text.Trim());
                        break;
                    case "TrinhDoNgoaiNgu":
                        sqlQuery = BuildSearchByNgoaiNguQuery(lstDieuKienTimKiem, txtMaDonVi_TieuChiKhac.Text.Trim());
                        break;
                    case "KhenThuong":
                        sqlQuery = BuildSearchByQuaTrinhKhenThuongQuery(lstDieuKienTimKiem, txtMaDonVi_TieuChiKhac.Text.Trim());
                        break;
                    case "KyLuat":
                        sqlQuery = BuildSearchByQuaTrinhKyLuatQuery(lstDieuKienTimKiem, txtMaDonVi_TieuChiKhac.Text.Trim());
                        break;
                    case "HuyHieu":
                        sqlQuery = BuildSearchByHuyHieuQuery(lstDieuKienTimKiem, txtMaDonVi_TieuChiKhac.Text.Trim());
                        break;
                    case "ThanNhan":
                        sqlQuery = BuildSearchByThanNhanQuery(lstDieuKienTimKiem, txtMaDonVi_TieuChiKhac.Text.Trim());
                        break;
                }
                var ds = GlobalVars.g_CauHoiNguoiDung.SearchByCriterias(sqlQuery);
                List<NhanVien> lstItem = new List<NhanVien>();
                lstvNhanVien.Items.Clear();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        var objListViewItem = new ListViewItem();
                        objListViewItem.Tag = NhanVienRepository.SelectByID(ds.Tables[0].Rows[i]["MaNhanVien"].ToString().Trim());
                        
                        lstItem.Add((NhanVien)objListViewItem.Tag);

                        objListViewItem.Text = ds.Tables[0].Rows[i]["MaNhanVien"].ToString();
                        objListViewItem.SubItems.Add(ds.Tables[0].Rows[i]["HoTenKhaiSinh"].ToString());
                        var gioitinh = GioiTinhRepository.SelectByID(int.Parse(ds.Tables[0].Rows[i]["MaGioiTinh"].ToString()));
                        objListViewItem.SubItems.Add(gioitinh == null ? "" : gioitinh.TenGioiTinh);
                        objListViewItem.SubItems.Add(ds.Tables[0].Rows[i]["NgaySinh"] == null ? "" : String.Format("{0:dd/MM/yyyy}", DateTime.Parse(ds.Tables[0].Rows[i]["NgaySinh"].ToString())));
                        objListViewItem.SubItems.Add(ds.Tables[0].Rows[i]["HoKhau"].ToString());
                        lstvNhanVien.Items.Add(objListViewItem);
                    }

                    UpdateTongHopKQ(lstItem);
                }
                txtTongSo.Text = "Tìm thấy " + ds.Tables[0].Rows.Count + " nhân viên";
            }

            // Pos waiting form
            GlobalVars.PosLoading();
            //------- E ---------
        }

        /// <summary>
        /// Fill queries to listview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GetCauHoi(object sender, EventArgs e)
        {
            var dataType = (MyQueryEvent)e;
            var cauhoi = (CauHoiNguoiDung)dataType.Data;
            if (cauhoi != null)
            {
                FillQueryDataToListView(cauhoi);
            }
        }

        /// <summary>
        /// Get bang need to search
        /// </summary>
        /// <returns></returns>
        private string GetBang()
        {
            var result = "";
            if (rdbtnThongTinChung.Checked)
                result = "NhanVien";
            else if (rdbtnQuaTrinhCongTac.Checked)
                result = "QuaTrinhCongTac";
            else if (rdbtnQuaTrinhDaoTao.Checked)
                result = "QuaTrinhDaoTao";
            else if (rdbtnNgoaiNgu.Checked)
                result = "TrinhDoNgoaiNgu";
            else if (rdbtnQuaTrinhKhenThuong.Checked)
                result = "KhenThuong";
            else if (rdbtnQuaTrinhKyLuat.Checked)
                result = "KyLuat";
            else if (rdbtnDanhHuyHieu.Checked)
                result = "HuyHieu";
            else if (rdbtnQuanHeGiaDinh.Checked)
                result = "ThanNhan";
            return result;
        }

        /// <summary>
        /// From table name, set criteria
        /// </summary>
        /// <param name="tenbang"></param>
        private void SelectBang(string tenbang)
        {
            switch (tenbang)
            {
                case "NhanVien":
                    rdbtnThongTinChung.Checked = true;
                    rdbtnThongTinChung_Click(null, null);
                    break;
                case "QuaTrinhCongTac":
                    rdbtnQuaTrinhCongTac.Checked = true;
                    rdbtnQuaTrinhCongTac_Click(null, null);
                    break;
                case "QuaTrinhDaoTao":
                    rdbtnQuaTrinhDaoTao.Checked = true;
                    rdbtnQuaTrinhDaoTao_Click(null, null);
                    break;
                case "TrinhDoNgoaiNgu":
                    rdbtnNgoaiNgu.Checked = true;
                    rdbtnNgoaiNgu_Click(null, null);
                    break;
                case "KhenThuong":
                    rdbtnQuaTrinhKhenThuong.Checked = true;
                    rdbtnQuaTrinhKhenThuong_Click(null, null);
                    break;
                case "KyLuat":
                    rdbtnQuaTrinhKyLuat.Checked = true;
                    rdbtnQuaTrinhKyLuat_Click(null, null);
                    break;
            }
        }

        /// <summary>
        /// Build query base on specified criterial
        /// </summary>
        /// <returns></returns>
        public string BuildSearchByThanNhanQuery(List<DieuKienTimKiem> lstDieuKienTimKiem, string madonvi)
        {
            var result = "";
            result += "Select NhanVien.MaNhanVien, HoTenKhaiSinh, MaGioiTinh, NgaySinh, HoKhau  From NhanVien, ThanNhan Where ";
            GlobalVars.g_CauHoiNguoiDung = new CauHoiNguoiDung
            {
                Bang = "ThanNhan",
                DBProvider = new DBProvider()
            };
            result += CreateQueryString("ThanNhan", lstDieuKienTimKiem);
            result += "And MaDonVi = N'" + madonvi + "' And NhanVien.MaNhanVien = ThanNhan.MaNhanVien ";
            result += "Group By NhanVien.MaNhanVien, HoTenKhaiSinh, MaGioiTinh, NgaySinh, HoKhau";
            return result;
        }

        /// <summary>
        /// Build query base on specified criterial
        /// </summary>
        /// <returns></returns>
        public string BuildSearchByHuyHieuQuery(List<DieuKienTimKiem> lstDieuKienTimKiem, string madonvi)
        {
            var result = "";
            result += "Select NhanVien.MaNhanVien, HoTenKhaiSinh, MaGioiTinh, NgaySinh, HoKhau From NhanVien, HuyHieu Where ";
            GlobalVars.g_CauHoiNguoiDung = new CauHoiNguoiDung
            {
                Bang = "HuyHieu",
                DBProvider = new DBProvider()
            };
            result += CreateQueryString("HuyHieu", lstDieuKienTimKiem);
            result += "And MaDonVi = N'" + madonvi + "' And NhanVien.MaNhanVien = HuyHieu.MaNhanVien ";
            result += "Group By NhanVien.MaNhanVien, HoTenKhaiSinh, MaGioiTinh, NgaySinh, HoKhau";
            return result;
        }

        /// <summary>
        /// Build query base on specified criterial
        /// </summary>
        /// <returns></returns>
        public string BuildSearchByNgoaiNguQuery(List<DieuKienTimKiem> lstDieuKienTimKiem, string madonvi)
        {
            var result = "";
            result += "Select NhanVien.MaNhanVien, HoTenKhaiSinh, MaGioiTinh, NgaySinh, HoKhau From NhanVien, BangNgoaiNgu Where ";
            GlobalVars.g_CauHoiNguoiDung = new CauHoiNguoiDung
            {
                Bang = "BangNgoaiNgu",
                DBProvider = new DBProvider()
            };
            result += CreateQueryString("BangNgoaiNgu", lstDieuKienTimKiem);
            result += "And MaDonVi = N'" + madonvi + "' And NhanVien.MaBangNgoaiNgu = BangNgoaiNgu.MaBangNgoaiNgu ";
            result += "Group By NhanVien.MaNhanVien, HoTenKhaiSinh, MaGioiTinh, NgaySinh, HoKhau";
            return result;
        }

        /// <summary>
        /// Build query base on specified criterial
        /// </summary>
        /// <returns></returns>
        public string BuildSearchByQuaTrinhKyLuatQuery(List<DieuKienTimKiem> lstDieuKienTimKiem, string madonvi)
        {
            var result = "";
            result += "Select NhanVien.MaNhanVien, HoTenKhaiSinh, MaGioiTinh, NgaySinh, HoKhau From NhanVien, KyLuat Where ";
            GlobalVars.g_CauHoiNguoiDung = new CauHoiNguoiDung
            {
                Bang = "KyLuat",
                DBProvider = new DBProvider()
            };
            result += CreateQueryString("KyLuat", lstDieuKienTimKiem);
            result += "And MaDonVi = N'" + madonvi + "' And NhanVien.MaNhanVien = KyLuat.MaNhanVien ";
            result += "Group By NhanVien.MaNhanVien, HoTenKhaiSinh, MaGioiTinh, NgaySinh, HoKhau";
            return result;
        }

        /// <summary>
        /// Build query base on specified criterial
        /// </summary>
        /// <returns></returns>
        public string BuildSearchByQuaTrinhKhenThuongQuery(List<DieuKienTimKiem> lstDieuKienTimKiem, string madonvi)
        {
            var result = "";
            result += "Select NhanVien.MaNhanVien, HoTenKhaiSinh, MaGioiTinh, NgaySinh, HoKhau  From NhanVien, KhenThuong Where ";
            GlobalVars.g_CauHoiNguoiDung = new CauHoiNguoiDung
            {
                Bang = "KhenThuong",
                DBProvider = new DBProvider()
            };
            result += CreateQueryString("KhenThuong", lstDieuKienTimKiem);
            result += "And MaDonVi = N'" + madonvi + "' And NhanVien.MaNhanVien = KhenThuong.MaNhanVien ";
            result += "Group By NhanVien.MaNhanVien, HoTenKhaiSinh, MaGioiTinh, NgaySinh, HoKhau";
            return result;
        }

        /// <summary>
        /// Build query base on specified criterial
        /// </summary>
        /// <returns></returns>
        public string BuildSearchByQuaTrinhDaoTaoQuery(List<DieuKienTimKiem> lstDieuKienTimKiem, string madonvi)
        {
            var result = "";
            result += "Select NhanVien.MaNhanVien, HoTenKhaiSinh, MaGioiTinh, NgaySinh, HoKhau From NhanVien, QuaTrinhDaoTao Where ";
            GlobalVars.g_CauHoiNguoiDung = new CauHoiNguoiDung
            {
                Bang = "QuaTrinhDaoTao",
                DBProvider = new DBProvider()
            };
            result += CreateQueryString("QuaTrinhDaoTao", lstDieuKienTimKiem);
            result += "And MaDonVi = N'" + madonvi + "' And NhanVien.MaNhanVien = QuaTrinhDaoTao.MaNhanVien ";
            result += "Group By NhanVien.MaNhanVien, HoTenKhaiSinh, MaGioiTinh, NgaySinh, HoKhau";
            return result;
        }

        /// <summary>
        /// Build query base on specified criterial
        /// </summary>
        /// <returns></returns>
        public string BuildSearchByQuaTrinhCongTacQuery(List<DieuKienTimKiem> lstDieuKienTimKiem, string madonvi)
        {
            var result = "";
            result += "Select NhanVien.MaNhanVien, HoTenKhaiSinh, MaGioiTinh, NgaySinh, HoKhau From NhanVien, QuaTrinhCongTac Where ";
            GlobalVars.g_CauHoiNguoiDung = new CauHoiNguoiDung
            {
                Bang = "QuaTrinhCongTac",
                DBProvider = new DBProvider()
            };
            result += CreateQueryString("QuaTrinhCongTac", lstDieuKienTimKiem);
            result += "And MaDonVi = N'" + madonvi + "' And NhanVien.MaNhanVien = QuaTrinhCongTac.MaNhanVien ";
            result += "Group By NhanVien.MaNhanVien, HoTenKhaiSinh, MaGioiTinh, NgaySinh, HoKhau";
            return result;
        }

        /// <summary>
        /// Build query base on specified criterial
        /// </summary>
        /// <returns></returns>
        public string BuildSearchByTieuChiChungQuery(List<DieuKienTimKiem> lstDieuKienTimKiem, string madonvi)
        {
            var result = "";
            result += "Select NhanVien.* From NhanVien Where ";
            GlobalVars.g_CauHoiNguoiDung = new CauHoiNguoiDung
            {
                Bang = "NhanVien",
                DBProvider = new DBProvider()
            };
            result += CreateQueryString("NhanVien", lstDieuKienTimKiem);
            result += "And MaDonVi = N'" + madonvi + "'";
            return result;
        }

        /// <summary>
        /// Create query string base on list of item in listview
        /// </summary>
        /// <returns></returns>
        public string CreateQueryString(string tableName, List<DieuKienTimKiem> lstDieuKienTimKiem)
        {
            var result = "";
            for (int i = 0; i < lstDieuKienTimKiem.Count; i++)
            {
                var item = (DieuKienTimKiem)lstDieuKienTimKiem[i];
                if (item.Attr.Type == DataType.DATETIME)
                    result += (item.AndOr.Trim() + " " + tableName + "." + item.Attr.Name.Trim() + " " + item.Condition.Trim() + " '" + item.Value.Trim() + "' ");
                else if (item.Attr.Type == DataType.STRING)
                    result += (item.AndOr.Trim() + " " + tableName + "." + item.Attr.Name.Trim() + " " + item.Condition.Trim() + " N'" + item.Value.Trim() + "' ");
                else
                    result += (item.AndOr.Trim() + " " + tableName + "." + item.Attr.Name.Trim() + " " + item.Condition.Trim() + " " + item.Value.Trim() + " ");
            }
            return result;
        }

        /// <summary>
        /// Fill data query to listview
        /// </summary>
        /// <param name="cauhoi"></param>
        public void FillQueryDataToListView(CauHoiNguoiDung cauhoi)
        {
            txtMaDonVi_TieuChiKhac.Text = cauhoi.MaDonVi;
            // Select table to query
            SelectBang(cauhoi.Bang);

            // Fill data to listview
            lstvDieuKienTimKiem.Items.Clear();
            for (int i = 0; i < cauhoi.LstDieuKien.Count; i++)
            {
                var dieukientimkiem = new DieuKienTimKiem
                {
                    Attr = new Attribute { Name = cauhoi.LstDieuKien[i].Bien },
                    Condition = cauhoi.LstDieuKien[i].DieuKien,
                    Value = cauhoi.LstDieuKien[i].GiaTri,
                    AndOr = cauhoi.LstDieuKien[i].ThuocTinhDieuKien
                };
                // Add item to lstview
                var objListViewItem = new ListViewItem
                {
                    Tag = dieukientimkiem,
                    Text = dieukientimkiem.AndOr + " " + dieukientimkiem.Attr.Name + dieukientimkiem.Condition + dieukientimkiem.Value
                };
                lstvDieuKienTimKiem.Items.Add(objListViewItem);
            }
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

        /// <summary>
        /// Load criterial corresponding with specified table
        /// </summary>
        public void LoadCriterias(Criteria criteria)
        {
            try
            {
                if (!bnLoading)
                {
                    // Show waiting form
                    GlobalVars.PreLoading();
                    //------- E ---------
                }
                // Init criteria
                Table tbl = criteria.InitCriterias();
                lstvTenTruongDuLieu.Items.Clear();
                for (int i = 0; i < tbl.Attributes.Count; i++)
                {
                    if (tbl.Attributes[i].Name.ToUpper() == "HINHANH" || tbl.Attributes[i].IsPrimaryKey || (tbl.Attributes[i].IsForeignKey && tbl.Attributes[i].Name.ToUpper() == "MANHANVIEN"))
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
                    {
                        objListViewItem.Text = tbl.Attributes[i].Name;
                    }

                    lstvTenTruongDuLieu.Items.Add(objListViewItem);
                }

                if (!bnLoading)
                {
                    // Hide waiting form
                    GlobalVars.PosLoading();
                    //------- E ---------
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Init control GiaTriTimKiem, it can combobox or textbox base on selected item in listview
        /// </summary>
        private void InitControlGiaTriTimKiem()
        {
            // Add a new combobox
            cbxGiaTriTimKiem = new DevComponents.DotNetBar.Controls.ComboBoxEx
            {
                Name = "cbxGiaTriTimKiem",
                Size = new Size(232, 20),
                Location = new Point(81, 299),
                DrawMode = DrawMode.OwnerDrawFixed,
                FormattingEnabled = true,
                ItemHeight = 14
            };
            cbxGiaTriTimKiem.Visible = false;
            groupPanel3.Controls.Add(cbxGiaTriTimKiem);

            // Add a new textbox
            txtGiaTriTimKiem = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtGiaTriTimKiem",
                Size = new Size(232, 20),
                Location = new Point(81, 299)
            };
            txtGiaTriTimKiem.Visible = true;
            groupPanel3.Controls.Add(txtGiaTriTimKiem);
        }

        /// <summary>
        /// Load data for combobox GiaTriTimKiem
        /// </summary>
        /// <param name="attr"></param>
        private void LoadControlGiaTriTimKiem(Attribute attr)
        {
            cbxDieuKien.Items.Clear();
            if (attr.IsForeignKey)
            {
                cbxGiaTriTimKiem.Visible = true;
                txtGiaTriTimKiem.Visible = false;
                switch (attr.ReferTo)
                {
                    // Use for tomtat
                    case "GioiTinh":
                        var lstGioiTinh = GioiTinhRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstGioiTinh;
                        break;
                    case "DonVi":
                        var lstDonVi = DonViRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstDonVi;
                        break;
                    case "DanToc":
                        var lstDanToc = DanTocRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstDanToc;
                        break;
                    case "TonGiao":
                        var lstTonGiao = TonGiaoRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstTonGiao;
                        break;
                    case "ThanhPhanGiaDinh":
                        var lstThanhPhanXuatThan = ThanhPhanGiaDinhRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstThanhPhanXuatThan;
                        break;
                    case "NgheNghiep":
                        var lstNgheNghiep = NgheNghiepRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstNgheNghiep;
                        break;
                    case "BangGiaoDucPhoThong":
                        var lstBangGDPT = BangGiaoDucPhoThongRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstBangGDPT;
                        break;
                    case "BangChuyenMonNghiepVu":
                        var lstBangChuyenMonNghiepVu = BangChuyenMonNghiepVuRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstBangChuyenMonNghiepVu;
                        break;
                    case "BangLyLuanChinhTri":
                        var lstBangLyLuanChinhTri = BangLyLuanChinhTriRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstBangLyLuanChinhTri;
                        break;
                    case "BangNgoaiNgu":
                        var lstTrinhDoNgoaiNgu = BangNgoaiNguRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstTrinhDoNgoaiNgu;
                        break;
                    case "HocVi":
                        var lstHocVi = HocViRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstHocVi;
                        break;
                    case "HocHam":
                        var lstTrinhDoHocVan = HocHamRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstTrinhDoHocVan;
                        break;
                    case "TinhTrangSucKhoe":
                        var lstTinhTrangSucKhoe = TinhTrangSucKhoeRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstTinhTrangSucKhoe;
                        break;
                    case "LoaiThuongBinh":
                        var lstLoaiThuongBinh = LoaiThuongBinhRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstLoaiThuongBinh;
                        break;
                    case "ChucVu":
                        var lstChucVu = ChucVuRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstChucVu;
                        break;
                    //---------------- E ----------------

                    // User for qua trinh cong tac
                    case "QuocGia":
                        var lstNuocCongTac = QuocGiaRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstNuocCongTac;
                        break;
                    case "CapUy":
                        var lstCapUy = CapUyRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstCapUy;
                        break;
                    case "CapUyKiem":
                        var lstCapUyKiem = CapUyKiemRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstCapUyKiem;
                        break;
                    case "ChucVuChinhQuyen":
                        var lstChucVuChinhQuyen = ChucVuChinhQuyenRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstChucVuChinhQuyen;
                        break;
                    //---------------- E ----------------

                    // User for qua trinh cong tac
                    case "HinhThucDaoTao":
                        var lstHinhThucDaoTao = HinhThucDaoTaoRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstHinhThucDaoTao;
                        break;
                    //---------------- E ----------------

                    // User for qua trinh khen thuong
                    case "HinhThucKhenThuong":
                        var lstHinhThucKhenThuong = HinhThucKhenThuongRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstHinhThucKhenThuong;
                        break;
                    //---------------- E ----------------

                    // User for qua trinh ky luat
                    case "HinhThucKyLuat":
                        var lstHinhThucKyLuat = HinhThucKyLuatRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstHinhThucKyLuat;
                        break;
                    case "NoiDungViPham":
                        var lstNoiDungViPham = NoiDungViPhamRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstNoiDungViPham;
                        break;
                    //---------------- E ----------------

                    // User for huy hieu nhan duoc
                    case "LoaiHuyHieu":
                        var lstLoaiHuyHieu = LoaiHuyHieuRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstLoaiHuyHieu;
                        break;
                    //---------------- E ----------------

                    // User for quan he gia dinh
                    case "QuanHe":
                        var lstQuanHe = QuanHeRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstQuanHe;
                        break;
                    //---------------- E ----------------                  
                }
                cbxGiaTriTimKiem.SelectedIndex = -1;
                cbxDieuKien.Items.Add("=");
                cbxDieuKien.Items.Add("<>");
                cbxDieuKien.SelectedIndex = -1;
            }
            else
            {
                switch (attr.Type)
                {
                    case DataType.BOOL:
                        cbxDieuKien.Items.Add("=");
                        cbxDieuKien.Items.Add("<>");
                        cbxGiaTriTimKiem.Visible = true;
                        txtGiaTriTimKiem.Visible = false;

                        var lstBool = new List<BoolDataItem>();
                        lstBool.Add(new BoolDataItem { Value = 1, Text = "Có" });
                        lstBool.Add(new BoolDataItem { Value = 0, Text = "Không" });
                        cbxGiaTriTimKiem.DataSource = lstBool;
                        break;
                    case DataType.DATETIME:
                    case DataType.STRING:
                        cbxDieuKien.Items.Add("=");
                        cbxDieuKien.Items.Add("<>");
                        cbxGiaTriTimKiem.Visible = false;
                        txtGiaTriTimKiem.Visible = true;
                        break;
                    default:
                        cbxDieuKien.Items.Add("=");
                        cbxDieuKien.Items.Add(">");
                        cbxDieuKien.Items.Add(">=");
                        cbxDieuKien.Items.Add("<");
                        cbxDieuKien.Items.Add("<=");
                        cbxDieuKien.Items.Add("<>");
                        cbxGiaTriTimKiem.Visible = false;
                        txtGiaTriTimKiem.Visible = true;
                        break;
                }
            }
        }

        /// <summary>
        /// Validate user input
        /// </summary>
        /// <param name="errorText"></param>
        /// <returns></returns>
        private bool ValidateThemDieuKien(ref string errorText)
        {
            if (cbxDieuKien.SelectedIndex == -1)
            {
                errorText = "Vui lòng chọn điều kiện!";
                return false;
            }

            if (cbxGiaTriTimKiem.Visible)
            {
                if (cbxGiaTriTimKiem.SelectedIndex == -1)
                {
                    errorText = "Vui lòng chọn giá trị cho điều kiện!";
                    return false;
                }
            }
            else
            {
                if (txtGiaTriTimKiem.Text == "")
                {
                    errorText = "Vui lòng nhập giá trị cho điều kiện!";
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Get gia tri tim kiem
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string GetGiaTriTimKiem(object item)
        {
            var value = "";
            if (item.GetType() == typeof(GioiTinh))
                value = ((GioiTinh)item).MaGioiTinh.ToString();
            else if (item.GetType() == typeof(DonVi))
                value = ((DonVi)item).MaDonVi;
            else if (item.GetType() == typeof(DanToc))
                value = ((DanToc)item).MaDanToc.ToString();
            else if (item.GetType() == typeof(TonGiao))
                value = ((TonGiao)item).MaTonGiao.ToString();
            else if (item.GetType() == typeof(ThanhPhanGiaDinh))
                value = ((ThanhPhanGiaDinh)item).MaThanhPhanGiaDinh.ToString();
            else if (item.GetType() == typeof(NgheNghiep))
                value = ((NgheNghiep)item).MaNgheNghiep.ToString();
            else if (item.GetType() == typeof(BangGiaoDucPhoThong))
                value = ((BangGiaoDucPhoThong)item).MaBangGiaoDucPhoThong.ToString();
            else if (item.GetType() == typeof(BangChuyenMonNghiepVu))
                value = ((BangChuyenMonNghiepVu)item).MaBangChuyenMonNghiepVu.ToString();
            else if (item.GetType() == typeof(BangLyLuanChinhTri))
                value = ((BangLyLuanChinhTri)item).MaBangLyLuanChinhTri.ToString();
            else if (item.GetType() == typeof(BangNgoaiNgu))
                value = ((BangNgoaiNgu)item).MaBangNgoaiNgu.ToString();
            else if (item.GetType() == typeof(HocVi))
                value = ((HocVi)item).MaHocVi.ToString();
            else if (item.GetType() == typeof(HocHam))
                value = ((HocHam)item).MaHocHam.ToString();
            else if (item.GetType() == typeof(TinhTrangSucKhoe))
                value = ((TinhTrangSucKhoe)item).MaTinhTrangSucKhoe.ToString();
            else if (item.GetType() == typeof(LoaiThuongBinh))
                value = ((LoaiThuongBinh)item).MaLoaiThuongBinh.ToString();
            else if (item.GetType() == typeof(ChucVu))
                value = ((ChucVu)item).MaChucVu.ToString();
            else if (item.GetType() == typeof(QuocGia))
                value = ((QuocGia)item).MaQuocGia.ToString();
            else if (item.GetType() == typeof(CapUy))
                value = ((CapUy)item).MaCapUy.ToString();
            else if (item.GetType() == typeof(CapUyKiem))
                value = ((CapUyKiem)item).MaCapUyKiem.ToString();
            else if (item.GetType() == typeof(ChucVuChinhQuyen))
                value = ((ChucVuChinhQuyen)item).MaChucVuChinhQuyen.ToString();
            else if (item.GetType() == typeof(HinhThucDaoTao))
                value = ((HinhThucDaoTao)item).MaHinhThucDaoTao.ToString();
            else if (item.GetType() == typeof(HinhThucKhenThuong))
                value = ((HinhThucKhenThuong)item).MaHinhThucKhenThuong.ToString();
            else if (item.GetType() == typeof(HinhThucKyLuat))
                value = ((HinhThucKyLuat)item).MaHinhThucKyLuat.ToString();
            else if (item.GetType() == typeof(NoiDungViPham))
                value = ((NoiDungViPham)item).MaNoiDungViPham.ToString();
            else if (item.GetType() == typeof(LoaiHuyHieu))
                value = ((LoaiHuyHieu)item).MaLoaiHuyHieu.ToString();
            else if (item.GetType() == typeof(QuanHe))
                value = ((QuanHe)item).MaQuanHe.ToString();
            else if (item.GetType() == typeof(BoolDataItem))
                value = ((BoolDataItem)item).Value.ToString();
            return value;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // tuansl added: STATISTIC SEARCHING RESULT 
        ///////////////////////////////////////////////////////////////////////////////////////////////

        private void lstvNhanVien_DoubleClick(object sender, EventArgs e)
        {
            if (lstvNhanVien.SelectedItems.Count > 0)
            {
                var nhanvien = (NhanVien)lstvNhanVien.SelectedItems[0].Tag;
                FrmThongTinNhanVien frm = new FrmThongTinNhanVien(nhanvien);
                frm.Handler += NothingToProcess;
                frm.ShowDialog();
            }
        }

        private void NothingToProcess(object sender, EventArgs e)
        {
        }

        private void btnChonTruong_Click(object sender, EventArgs e)
        {
            FrmChonTruong frm = new FrmChonTruong();
            frm.Handler += NothingToProcess;
            frm.ShowDialog();
        }

        /// <summary>
        /// Fill queries to listview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void UpdateTruongHienThi()
        {
            lstvNhanVien.Columns.Clear();

            if (GlobalSearch.LstTruongHienThi.Count > 0)
            {
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "MaNhanVien") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Số hiệu CC",
                        Width = 100
                    };
                    lstvNhanVien.Columns.Add(col);
                }
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "SoLyLich") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Số lý lịch",
                        Width = 100
                    };
                    lstvNhanVien.Columns.Add(col);
                }
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "SoTheDangVien") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Số thẻ ĐV",
                        Width = 100
                    };
                    lstvNhanVien.Columns.Add(col);
                }
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "HoTenKhaiSinh") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Họ tên",
                        Width = 180
                    };
                    lstvNhanVien.Columns.Add(col);
                }
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "HoTenDangDung") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Họ tên đang dùng",
                        Width = ("Họ tên đang dùng").Length  * 9
                    };
                    lstvNhanVien.Columns.Add(col);
                }
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "SoCMND") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Số CMND",
                        Width = 100
                    };
                    lstvNhanVien.Columns.Add(col);
                }
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "MaGioiTinh") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Giới tinh",
                        Width = 60
                    };
                    lstvNhanVien.Columns.Add(col);
                }
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "NgaySinh") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Ngày sinh",
                        Width = 100
                    };
                    lstvNhanVien.Columns.Add(col);
                }
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "NoiSinh") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Nơi sinh",
                        Width = 100
                    };
                    lstvNhanVien.Columns.Add(col);
                }
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "QueQuan") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Quê quán",
                        Width = 200
                    };
                    lstvNhanVien.Columns.Add(col);
                }
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "HoKhau") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Hộ khẩu",
                        Width = 200
                    };
                    lstvNhanVien.Columns.Add(col);
                }
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "NoiOHienNay") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Địa chỉ",
                        Width = 200
                    };
                    lstvNhanVien.Columns.Add(col);
                }
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "MaDonVi") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Đơn vị",
                        Width = ("Đơn vị").Length  * 9
                    };
                    lstvNhanVien.Columns.Add(col);
                }
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "CongViecChinh") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Công việc chính",
                        Width = ("Công việc chính").Length  * 9
                    };
                    lstvNhanVien.Columns.Add(col);
                }
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "NgayVaoDang") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Ngày vào đảng",
                        Width = ("Ngày vào đảng").Length  * 9
                    };
                    lstvNhanVien.Columns.Add(col);
                }
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "VaoDangTaiChiBo") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Vào đảng tại CB",
                        Width = ("Vào đảng tại CB").Length  * 9
                    };
                    lstvNhanVien.Columns.Add(col);
                }
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "NguoiGioiThieu1") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Người giới thiệu 1",
                        Width = ("Người giới thiệu 1").Length  * 9
                    };
                    lstvNhanVien.Columns.Add(col);
                }
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "ChucVuNguoi1") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Chức vụ người 1",
                        Width = ("Chức vụ người 1").Length  * 9
                    };
                    lstvNhanVien.Columns.Add(col);
                }
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "NguoiGioiThieu2") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Người giới thiệu 2",
                        Width = ("Người giới thiệu 2").Length  * 9
                    };
                    lstvNhanVien.Columns.Add(col);
                }
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "ChucVuNguoi2") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Chức vụ người 2",
                        Width = ("Chức vụ người 2").Length  * 9
                    };
                    lstvNhanVien.Columns.Add(col);
                }
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "NgayChinhThuc") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Ngày chính thức",
                        Width = ("Ngày chính thức").Length  * 9
                    };
                    lstvNhanVien.Columns.Add(col);
                }
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "ChinhThucTaiChiBo") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Chính thức tại CB",
                        Width = ("Chính thức tại CB").Length  * 9
                    };
                    lstvNhanVien.Columns.Add(col);
                }
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "NgayTuyenDung") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Ngày tuyển dụng",
                        Width = ("Ngày tuyển dụng").Length  * 9
                    };
                    lstvNhanVien.Columns.Add(col);
                }
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "CoQuanTuyenDung") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Cơ quan tuyển dụng",
                        Width = ("Cơ quan tuyển dụng").Length  * 9
                    };
                    lstvNhanVien.Columns.Add(col);
                }








                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "MaDanToc") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Dân tộc",
                        Width = ("Dân tộc").Length  * 9
                    };
                    lstvNhanVien.Columns.Add(col);
                }
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "MaTonGiao") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Tôn giáo",
                        Width = ("Tôn giáo").Length  * 9
                    };
                    lstvNhanVien.Columns.Add(col);
                }
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "MaThanhPhanGiaDinh") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Thành phần gia đình",
                        Width = ("Thành phần gia đình").Length  * 9
                    };
                    lstvNhanVien.Columns.Add(col);
                }
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "MaNgheNghiepTruocKhiDuocTuyenDung") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Nghề nghiệp trước tuyển dụng",
                        Width = ("Nghề nghiệp trước tuyển dụng").Length  * 9
                    };
                    lstvNhanVien.Columns.Add(col);
                }
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "MaBangGiaoDucPhoThong") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Bằng GDPT",
                        Width = ("Bằng GDPT").Length  * 9
                    };
                    lstvNhanVien.Columns.Add(col);
                }
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "MaBangChuyenMonNghiepVu") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Bằng CMNV",
                        Width = ("Bằng CMNV").Length  * 9
                    };
                    lstvNhanVien.Columns.Add(col);
                }
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "MaBangLyLuanChinhTri") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Bằng LLCT",
                        Width = ("Bằng LLCT").Length  * 9
                    };
                    lstvNhanVien.Columns.Add(col);
                }
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "MaBangNgoaiNgu") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Bằng NN",
                        Width = ("Bằng NN").Length  * 9
                    };
                    lstvNhanVien.Columns.Add(col);
                }
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "MaHocVi") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Học vị cao nhất",
                        Width = ("Học vị cao nhất").Length  * 9
                    };
                    lstvNhanVien.Columns.Add(col);
                }
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "MaHocHam") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Học hàm",
                        Width = ("Học hàm").Length  * 9
                    };
                    lstvNhanVien.Columns.Add(col);
                }
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "MaTinhTrangSucKhoe") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Tình trạng sức khỏe",
                        Width = ("Tình trạng sức khỏe").Length  * 9
                    };
                    lstvNhanVien.Columns.Add(col);
                }
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "MaLoaiThuongBinh") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Loại thương binh",
                        Width = ("Loại thương binh").Length  * 9
                    };
                    lstvNhanVien.Columns.Add(col);
                }
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "MaChucVu") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Chức vụ",
                        Width = ("Chức vụ").Length  * 9
                    };
                    lstvNhanVien.Columns.Add(col);
                }
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "MaChucVuKiemNhiem") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Chức vụ kiêm",
                        Width = ("Chức vụ kiêm").Length  * 9
                    };
                    lstvNhanVien.Columns.Add(col);
                }
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "MaNgachCongChuc") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Ngạch CC",
                        Width = ("Ngạch CC").Length  * 9
                    };
                    lstvNhanVien.Columns.Add(col);
                }
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, "MaHuong85") != null)
                {
                    var col = new ColumnHeader
                    {
                        Text = "Hưởng 85",
                        Width = ("Hưởng 85").Length  * 9
                    };
                    lstvNhanVien.Columns.Add(col);
                }
            }
        }

        public void InitLstTruongHienThi()
        {
            GlobalSearch.LstTruongHienThi = new Dictionary<string, QuanLyHoSoCongChuc.Utils.Attribute>();

            var criteria = new Criteria()
            {
                DBName = "NhanVien",
                DBProvider = new DBProvider()
            };

            try
            {
                // Init criteria
                Table tbl = criteria.InitCriterias();
                GlobalSearch.LstTruongHienThi.Clear();
                for (int i = 0; i < tbl.Attributes.Count; i++)
                {
                    if (tbl.Attributes[i].Name == "MaNhanVien" ||
                        tbl.Attributes[i].Name == "HoTenKhaiSinh" ||
                        tbl.Attributes[i].Name == "MaGioiTinh" ||
                        tbl.Attributes[i].Name == "NgaySinh" ||
                        tbl.Attributes[i].Name == "NoiOHienNay")
                    {
                        GlobalSearch.LstTruongHienThi.Add(tbl.Attributes[i].Name, tbl.Attributes[i]);
                    }        
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
