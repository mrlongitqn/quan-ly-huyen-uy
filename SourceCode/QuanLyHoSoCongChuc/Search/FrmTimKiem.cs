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
            InitControlGiaTriTimKiem();
        }

        public FrmTimKiem(string _madonvi, string _tendaydu)
        {
            InitializeComponent();
            InitControlGiaTriTimKiem();
            txtMaDonVi.Text = _madonvi;
            txtTenDonViDayDu.Text = _tendaydu;
            txtMaDonVi_TieuChiKhac.Text = _madonvi;
        }

        public FrmTimKiem(CauHoiNguoiDung cauhoi)
        {
            InitializeComponent();
            InitControlGiaTriTimKiem();
            FillQueryDataToListView(cauhoi);
            tabControl1.SelectedTabIndex = 1;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // tuansl added: SEARCH BY TIEU CHI CHUNG
        ///////////////////////////////////////////////////////////////////////////////////////////////

        private void FrmTimKiem_Load(object sender, EventArgs e)
        {
            LoadTieuChiChung();
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
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaDonVi.Text = comp[0];
            txtTenDonViDayDu.Text = comp[1];
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

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // tuansl added: SEARCH BY TIEU CHI KHAC
        ///////////////////////////////////////////////////////////////////////////////////////////////
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbxGiaTriTimKiem;
        private DevComponents.DotNetBar.Controls.TextBoxX txtGiaTriTimKiem;

        private void btnChonDonVi_TieuChiKhac_Click(object sender, EventArgs e)
        {
            FrmDanhMuc frm = new FrmDanhMuc();
            frm.Handler += GetDonVi4TieuChiKhac;
            frm.EnableButtonChon = true;
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
            // Init list of searching condition to transfer data 
            List<DieuKienTimKiem> lstDieuKienTimKiem = new List<DieuKienTimKiem>();
            for (int i = 0; i < lstvDieuKienTimKiem.Items.Count; i++)
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
                        break;
                    case "QuaTrinhDaoTao":
                        break;
                    case "TrinhDoNgoaiNgu":
                        break;
                    case "KhenThuong":
                        break;
                    case "KyLuat":
                        break;
                }
                var ds = GlobalVars.g_CauHoiNguoiDung.SearchByCriterias(sqlQuery);
                lstvNhanVien.Items.Clear();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        var objListViewItem = new ListViewItem();
                        objListViewItem.Tag = ds.Tables[0].Rows[i]["MaNhanVien"].ToString();
                        objListViewItem.Text = ds.Tables[0].Rows[i]["MaNhanVien"].ToString();
                        objListViewItem.SubItems.Add(ds.Tables[0].Rows[i]["HoTenNhanVien"].ToString());
                        objListViewItem.SubItems.Add(ds.Tables[0].Rows[i]["TenGioiTinh"].ToString());
                        objListViewItem.SubItems.Add(ds.Tables[0].Rows[i]["NgaySinh"].ToString());
                        objListViewItem.SubItems.Add(ds.Tables[0].Rows[i]["NoiOHienTai"].ToString());
                        lstvNhanVien.Items.Add(objListViewItem);
                    }
                }
                txtTongSo.Text = "Tìm thấy " + ds.Tables[0].Rows.Count + " nhân viên";
            }
            else
            {
                MessageBox.Show("Không có giá trị tìm kiếm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        public string BuildSearchByTieuChiChungQuery(List<DieuKienTimKiem> lstDieuKienTimKiem, string madonvi)
        {
            var result = "";
            result += "Select NhanVien.*, TenGioiTinh From NhanVien, GioiTinh Where ";
            GlobalVars.g_CauHoiNguoiDung = new CauHoiNguoiDung
            {
                Bang = "NhanVien",
                DBProvider = new DBProvider()
            };
            result += CreateQueryString(lstDieuKienTimKiem);
            result += "And NhanVien.MaGioiTinh = GioiTinh.MaGioiTinh And MaDonVi = N'" + madonvi + "'";
            return result;
        }

        /// <summary>
        /// Create query string base on list of item in listview
        /// </summary>
        /// <returns></returns>
        public string CreateQueryString(List<DieuKienTimKiem> lstDieuKienTimKiem)
        {
            var result = "";
            for (int i = 0; i < lstDieuKienTimKiem.Count; i++)
            {
                var item = (DieuKienTimKiem)lstDieuKienTimKiem[i];
                if (item.Attr.Type == DataType.DATETIME)
                    result += (item.AndOr.Trim() + " " + item.Attr.Name.Trim() + " " + item.Condition.Trim() + " '" + item.Value.Trim() + "' ");
                else if (item.Attr.Type == DataType.STRING)
                    result += (item.AndOr.Trim() + " " + item.Attr.Name.Trim() + " " + item.Condition.Trim() + " N'" + item.Value.Trim() + "' ");
                else
                    result += (item.AndOr.Trim() + " " + item.Attr.Name.Trim() + " " + item.Condition.Trim() + " " + item.Value.Trim() + " ");
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
                    case "HinhThucTuyenDung":
                        var lstHinhThucTuyenDung = HinhThucTuyenDungRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstHinhThucTuyenDung;
                        break;
                    case "TrinhDoNgoaiNgu":
                        var lstTrinhDoNgoaiNgu = TrinhDoNgoaiNguRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstTrinhDoNgoaiNgu;
                        break;
                    case "TrinhDoChuyenMon":
                        var lstTrinhDoChuyenMon = TrinhDoChuyenMonRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstTrinhDoChuyenMon;
                        break;
                    case "TrinhDoChinhTri":
                        var lstTrinhDoChinhTri = TrinhDoChinhTriRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstTrinhDoChinhTri;
                        break;
                    case "TrinhDoTinHoc":
                        var lstTrinhDoTinHoc = TrinhDoTinHocRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstTrinhDoTinHoc;
                        break;
                    case "TrinhDoHocVan":
                        var lstTrinhDoHocVan = TrinhDoHocVanRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstTrinhDoHocVan;
                        break;
                    case "TrinhDoQuanLyNhaNuoc":
                        var lstTrinhDoQuanLyNhaNuoc = TrinhDoQuanLyNhaNuocRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstTrinhDoQuanLyNhaNuoc;
                        break;
                    case "CongViec":
                        var lstCongViec = CongViecRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstCongViec;
                        break;
                    case "DienUuTienGiaDinh":
                        var lstDienUuTienGiaDinh = DienUuTienGiaDinhRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstDienUuTienGiaDinh;
                        break;
                    case "DienUuTienBanThan":
                        var lstDienUuTienBanThan = DienUuTienBanThanRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstDienUuTienBanThan;
                        break;
                    case "ChucVu":
                        var lstChucVu = ChucVuRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstChucVu;
                        break;
                    case "TinhTrangHonNhan":
                        var lstTinhTrangHonNhan = TinhTrangHonNhanRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstTinhTrangHonNhan;
                        break;
                    case "TonGiao":
                        var lstTonGiao = TonGiaoRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstTonGiao;
                        break;
                    case "ThanhPhanXuatThan":
                        var lstThanhPhanXuatThan = ThanhPhanXuatThanRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstThanhPhanXuatThan;
                        break;
                    case "DangHocBoiDuongDaoTao":
                        var lstDangHocBoiDuongDaoTao = DangHocBoiDuongDaoTaoRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstDangHocBoiDuongDaoTao;
                        break;
                    case "GioiTinh":
                        var lstGioiTinh = GioiTinhRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstGioiTinh;
                        break;
                    case "DanToc":
                        var lstDanToc = DanTocRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstDanToc;
                        break;
                    case "DoanVien":
                        var lstDoanVien = DoanVienRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstDoanVien;
                        break;
                    case "Huong85":
                        var lstHuong85 = Huong85Repository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstHuong85;
                        break;
                    case "NgachCongChuc":
                        var lstNgachCongChuc = NgachCongChucRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstNgachCongChuc;
                        break;
                    case "LoaiCanBo":
                        var lstLoaiCanBo = LoaiCanBoRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstLoaiCanBo;
                        break;
                    case "LoaiNghiBaoHiemXaHoi":
                        var lstLoaiNghiBaoHiemXaHoi = LoaiNghiBaoHiemXaHoiRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstLoaiNghiBaoHiemXaHoi;
                        break;
                    case "DonVi":
                        var lstDonVi = DonViRepository.SelectAll();
                        cbxGiaTriTimKiem.DataSource = lstDonVi;
                        break;
                }
                cbxGiaTriTimKiem.SelectedIndex = -1;
                cbxDieuKien.Items.Add("=");
                cbxDieuKien.Items.Add("<>");
                cbxDieuKien.SelectedIndex = -1;
            }
            else
            {
                cbxGiaTriTimKiem.Visible = false;
                txtGiaTriTimKiem.Visible = true;
                switch (attr.Type)
                {
                    case DataType.BOOL:
                    case DataType.DATETIME:
                    case DataType.STRING:
                        cbxDieuKien.Items.Add("=");
                        cbxDieuKien.Items.Add("<>");
                        break;
                    default:
                        cbxDieuKien.Items.Add("=");
                        cbxDieuKien.Items.Add(">");
                        cbxDieuKien.Items.Add(">=");
                        cbxDieuKien.Items.Add("<");
                        cbxDieuKien.Items.Add("<=");
                        cbxDieuKien.Items.Add("<>");
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
            if (item.GetType() == typeof(HinhThucTuyenDung))
                value = ((HinhThucTuyenDung)item).MaHinhThucTuyenDung;
            else if (item.GetType() == typeof(TrinhDoNgoaiNgu))
                value = ((TrinhDoNgoaiNgu)item).MaTrinhDoNgoaiNgu;
            else if (item.GetType() == typeof(TrinhDoChuyenMon))
                value = ((TrinhDoChuyenMon)item).MaTrinhDoChuyenMon;
            else if (item.GetType() == typeof(TrinhDoChinhTri))
                value = ((TrinhDoChinhTri)item).MaTrinhDoChinhTri;
            else if (item.GetType() == typeof(TrinhDoTinHoc))
                value = ((TrinhDoTinHoc)item).MaTrinhDoTinHoc;
            else if (item.GetType() == typeof(TrinhDoHocVan))
                value = ((TrinhDoHocVan)item).MaTrinhDoHocVan;
            else if (item.GetType() == typeof(TrinhDoQuanLyNhaNuoc))
                value = ((TrinhDoQuanLyNhaNuoc)item).MaTrinhDoQuanLyNhaNuoc;
            else if (item.GetType() == typeof(CongViec))
                value = ((CongViec)item).MaCongViec;
            else if (item.GetType() == typeof(DienUuTienGiaDinh))
                value = ((DienUuTienGiaDinh)item).MaDienUuTienGiaDinh;
            else if (item.GetType() == typeof(DienUuTienBanThan))
                value = ((DienUuTienBanThan)item).MaDienUuTienBanThan;
            else if (item.GetType() == typeof(ChucVu))
                value = ((ChucVu)item).MaChucVu;
            else if (item.GetType() == typeof(TinhTrangHonNhan))
                value = ((TinhTrangHonNhan)item).MaTinhTrangHonNhan;
            else if (item.GetType() == typeof(TonGiao))
                value = ((TonGiao)item).MaTonGiao;
            else if (item.GetType() == typeof(ThanhPhanXuatThan))
                value = ((ThanhPhanXuatThan)item).MaThanhPhanXuatThan;
            else if (item.GetType() == typeof(DangHocBoiDuongDaoTao))
                value = ((DangHocBoiDuongDaoTao)item).MaDTBD;
            else if (item.GetType() == typeof(GioiTinh))
                value = ((GioiTinh)item).MaGioiTinh;
            else if (item.GetType() == typeof(DanToc))
                value = ((DanToc)item).MaDanToc;
            else if (item.GetType() == typeof(DoanVien))
                value = ((DoanVien)item).MaDoanVien;
            else if (item.GetType() == typeof(Huong85))
                value = ((Huong85)item).MaHuong;
            else if (item.GetType() == typeof(NgachCongChuc))
                value = ((NgachCongChuc)item).MaNgachCongChuc;
            else if (item.GetType() == typeof(LoaiCanBo))
                value = ((LoaiCanBo)item).MaLoaiCanBo;
            else if (item.GetType() == typeof(LoaiNghiBaoHiemXaHoi))
                value = ((LoaiNghiBaoHiemXaHoi)item).MaLoaiNghiBaoHiemXaHoi;
            else if (item.GetType() == typeof(DonVi))
                value = ((DonVi)item).MaDonVi;
            return value;
        }
        //--------------------- E --------------------------
    }
}
