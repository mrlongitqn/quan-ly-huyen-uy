using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using QuanLyHoSoCongChuc.Models;
using QuanLyHoSoCongChuc.Utils;
using QuanLyHoSoCongChuc.Repositories;

namespace QuanLyHoSoCongChuc.NhanVienManager
{
    /// <summary>
    /// tuansl added: manage progress of nhanvien
    /// </summary>
    public partial class FrmThongTinNhanVien_CacQuaTrinh : DevComponents.DotNetBar.Office2007Form
    {
        /// <summary>
        /// Enum to determine which functionality is activated
        /// </summary>
        private enum EnumCacQuaTrinh
        {
            QUATRINHCONGTAC,
            QUATRINHDAOTAO,
            KHENTHUONG,
            KYLUAT,
            HUYHIEU,
            LUONGPHUCAP
        }
        public NhanVien _nhanvien { get; set; }
        private Color imgCurrentNavImage;
        private EnumCacQuaTrinh TypeOfQuaTrinh = EnumCacQuaTrinh.QUATRINHCONGTAC;

        public FrmThongTinNhanVien_CacQuaTrinh(NhanVien nhanvien)
        {
            InitializeComponent();
            _nhanvien = nhanvien;
            InitForm();
            InitListView();
            if (_nhanvien != null)
            {
                LoadQuaTrinhCongTac();
            }
        }

        public void InitForm()
        {
            lblQuaTrinhCongTac.MouseEnter += new EventHandler(NavigationChildControl_MouseEnter);
            lblQuaTrinhCongTac.MouseLeave += new EventHandler(NavigationChildControl_MouseLeave);
            lblQuaTrinhCongTac.MouseUp += new MouseEventHandler(NavigationChildControl_MouseUp);

            lblQuaTrinhDaoTao.MouseEnter += new EventHandler(NavigationChildControl_MouseEnter);
            lblQuaTrinhDaoTao.MouseLeave += new EventHandler(NavigationChildControl_MouseLeave);
            lblQuaTrinhDaoTao.MouseUp += new MouseEventHandler(NavigationChildControl_MouseUp);

            lblKhenThuong.MouseEnter += new EventHandler(NavigationChildControl_MouseEnter);
            lblKhenThuong.MouseLeave += new EventHandler(NavigationChildControl_MouseLeave);
            lblKhenThuong.MouseUp += new MouseEventHandler(NavigationChildControl_MouseUp);

            lblKyLuat.MouseEnter += new EventHandler(NavigationChildControl_MouseEnter);
            lblKyLuat.MouseLeave += new EventHandler(NavigationChildControl_MouseLeave);
            lblKyLuat.MouseUp += new MouseEventHandler(NavigationChildControl_MouseUp);

            lblHuyHieuDang.MouseEnter += new EventHandler(NavigationChildControl_MouseEnter);
            lblHuyHieuDang.MouseLeave += new EventHandler(NavigationChildControl_MouseLeave);
            lblHuyHieuDang.MouseUp += new MouseEventHandler(NavigationChildControl_MouseUp);

            lblLuongPhuCap.MouseEnter += new EventHandler(NavigationChildControl_MouseEnter);
            lblLuongPhuCap.MouseLeave += new EventHandler(NavigationChildControl_MouseLeave);
            lblLuongPhuCap.MouseUp += new MouseEventHandler(NavigationChildControl_MouseUp);
        }

        private void NavigationChildControl_MouseEnter(Object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(LabelX))
            {
                imgCurrentNavImage = ((LabelX)sender).ForeColor;
                if (((LabelX)sender).ForeColor != Color.Crimson)
                {
                    ((LabelX)sender).ForeColor = Color.Crimson;
                }
                ((LabelX)sender).Cursor = Cursors.Hand;
            }
        }

        private void NavigationChildControl_MouseLeave(Object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(LabelX))
            {
                ((LabelX)sender).ForeColor = imgCurrentNavImage;
                ((LabelX)sender).Cursor = Cursors.Default;
            }
        }

        private void NavigationChildControl_MouseUp(Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (sender.GetType() == typeof(LabelX))
            {
                imgCurrentNavImage = Color.Crimson;
                ((LabelX)sender).ForeColor = Color.Crimson;
                Navigate(((LabelX)sender).Name);
            }
        }

        /// <summary>
        /// Init listview corresponding with specified quatrinh
        /// </summary>
        public void InitListView()
        {
            switch (TypeOfQuaTrinh)
            {
                case EnumCacQuaTrinh.QUATRINHCONGTAC:
                    lstvQuaTrinh.Columns.Clear();
                    lstvQuaTrinh.Columns.Insert(0, "STT", 40, HorizontalAlignment.Center);
                    lstvQuaTrinh.Columns.Insert(1, "Từ tháng năm", 100, HorizontalAlignment.Center);
                    lstvQuaTrinh.Columns.Insert(2, "Đến tháng năm", 100, HorizontalAlignment.Center);
                    lstvQuaTrinh.Columns.Insert(3, "Đơn vị chức vụ", 420);
                    break;

                case EnumCacQuaTrinh.QUATRINHDAOTAO:
                    lstvQuaTrinh.Columns.Clear();
                    lstvQuaTrinh.Columns.Insert(0, "STT", 40, HorizontalAlignment.Center);
                    lstvQuaTrinh.Columns.Insert(1, "Từ tháng năm", 100, HorizontalAlignment.Center);
                    lstvQuaTrinh.Columns.Insert(2, "Đến tháng năm", 100, HorizontalAlignment.Center);
                    lstvQuaTrinh.Columns.Insert(3, "Trường ngành học văn bằng", 420);
                    break;

                case EnumCacQuaTrinh.KHENTHUONG:
                    lstvQuaTrinh.Columns.Clear();
                    lstvQuaTrinh.Columns.Insert(0, "STT", 40, HorizontalAlignment.Center);
                    lstvQuaTrinh.Columns.Insert(1, "Năm", 50, HorizontalAlignment.Center);
                    lstvQuaTrinh.Columns.Insert(2, "Hình thức KT", 100);
                    lstvQuaTrinh.Columns.Insert(3, "Lý do", 470);
                    break;

                case EnumCacQuaTrinh.KYLUAT:
                    lstvQuaTrinh.Columns.Clear();
                    lstvQuaTrinh.Columns.Insert(0, "STT", 40, HorizontalAlignment.Center);
                    lstvQuaTrinh.Columns.Insert(1, "Năm", 50, HorizontalAlignment.Center);
                    lstvQuaTrinh.Columns.Insert(2, "Hình thức KL", 100);
                    lstvQuaTrinh.Columns.Insert(3, "Lý do", 470);
                    break;

                case EnumCacQuaTrinh.HUYHIEU:
                    lstvQuaTrinh.Columns.Clear();
                    lstvQuaTrinh.Columns.Insert(0, "STT", 40, HorizontalAlignment.Center);
                    lstvQuaTrinh.Columns.Insert(1, "Năm", 50, HorizontalAlignment.Center);
                    lstvQuaTrinh.Columns.Insert(2, "Loại", 570);
                    break;

                case EnumCacQuaTrinh.LUONGPHUCAP:
                    lstvQuaTrinh.Columns.Clear();
                    lstvQuaTrinh.Columns.Insert(0, "STT", 40, HorizontalAlignment.Center);
                    lstvQuaTrinh.Columns.Insert(1, "Ngày/Tháng/Năm", 120, HorizontalAlignment.Center);
                    lstvQuaTrinh.Columns.Insert(2, "Ngạch công chức", 500);
                    break;
            }
        }

        private void Navigate(string Shortcut)
        {
            foreach (Control objControl in pnlChucNang.Controls)
            {
                if (objControl.GetType() == typeof(LabelX))
                {
                    switch (objControl.Name)
                    {
                        case "lblQuaTrinhCongTac":
                            if (Shortcut == "lblQuaTrinhCongTac")
                            {
                                objControl.ForeColor = Color.Crimson;
                                TypeOfQuaTrinh = EnumCacQuaTrinh.QUATRINHCONGTAC;
                                InitListView();
                                LoadQuaTrinhCongTac();
                            }
                            else
                            {
                                objControl.ForeColor = SystemColors.ControlText;
                            }
                            break;

                        case "lblQuaTrinhDaoTao":
                            if (Shortcut == "lblQuaTrinhDaoTao")
                            {
                                objControl.ForeColor = Color.Crimson;
                                TypeOfQuaTrinh = EnumCacQuaTrinh.QUATRINHDAOTAO;
                                InitListView();
                                LoadQuaTrinhDaoTao();
                            }
                            else
                            {
                                objControl.ForeColor = SystemColors.ControlText;
                            }
                            break;

                        case "lblKhenThuong":
                            if (Shortcut == "lblKhenThuong")
                            {
                                objControl.ForeColor = Color.Crimson;
                                TypeOfQuaTrinh = EnumCacQuaTrinh.KHENTHUONG;
                                InitListView();
                                LoadQuaTrinhKhenThuong();
                            }
                            else
                            {
                                objControl.ForeColor = SystemColors.ControlText;
                            }
                            break;

                        case "lblKyLuat":
                            if (Shortcut == "lblKyLuat")
                            {
                                objControl.ForeColor = Color.Crimson;
                                TypeOfQuaTrinh = EnumCacQuaTrinh.KYLUAT;
                                InitListView();
                                LoadQuaTrinhKyLuat();
                            }
                            else
                            {
                                objControl.ForeColor = SystemColors.ControlText;
                            }
                            break;

                        case "lblHuyHieuDang":
                            if (Shortcut == "lblHuyHieuDang")
                            {
                                objControl.ForeColor = Color.Crimson;
                                TypeOfQuaTrinh = EnumCacQuaTrinh.HUYHIEU;
                                InitListView();
                                LoadHuyHieu();
                            }
                            else
                            {
                                objControl.ForeColor = SystemColors.ControlText;
                            }
                            break;

                        case "lblLuongPhuCap":
                            if (Shortcut == "lblLuongPhuCap")
                            {
                                objControl.ForeColor = Color.Crimson;
                                TypeOfQuaTrinh = EnumCacQuaTrinh.LUONGPHUCAP;
                                InitListView();
                                LoadLuongPhuCap();
                            }
                            else
                            {
                                objControl.ForeColor = SystemColors.ControlText;
                            }
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Load qua trinh cong tac
        /// </summary>
        public void LoadQuaTrinhCongTac()
        {
            var lstItem = QuaTrinhCongTacRepository.SelectByMaNhanVien(_nhanvien.MaNhanVien);
            lstvQuaTrinh.Items.Clear();
            for (int i = 0; i < lstItem.Count; i++)
            {
                var objListViewItem = new ListViewItem();
                objListViewItem.Tag = lstItem[i];
                objListViewItem.Text = (i + 1).ToString();
                objListViewItem.SubItems.Add(String.Format("{0:MM/yyyy}", lstItem[i].ThoiGianBatDau.Value));
                objListViewItem.SubItems.Add(String.Format("{0:MM/yyyy}", lstItem[i].ThoiGianKetThuc.Value));
                objListViewItem.SubItems.Add(lstItem[i].MoTaCongTac);
                lstvQuaTrinh.Items.Add(objListViewItem);
            }
        }

        /// <summary>
        /// Load qua trinh dao tao
        /// </summary>
        public void LoadQuaTrinhDaoTao()
        {
            var lstItem = QuaTrinhDaoTaoRepository.SelectByMaNhanVien(_nhanvien.MaNhanVien);
            lstvQuaTrinh.Items.Clear();
            for (int i = 0; i < lstItem.Count; i++)
            {
                var objListViewItem = new ListViewItem();
                objListViewItem.Tag = lstItem[i];
                objListViewItem.Text = (i + 1).ToString();
                objListViewItem.SubItems.Add(String.Format("{0:MM/yyyy}", lstItem[i].ThoiGianBatDau.Value));
                objListViewItem.SubItems.Add(String.Format("{0:MM/yyyy}", lstItem[i].ThoiGianKetThuc.Value));
                objListViewItem.SubItems.Add(lstItem[i].NganhHoc);
                lstvQuaTrinh.Items.Add(objListViewItem);
            }
        }

        /// <summary>
        /// Load qua trinh khen thuong
        /// </summary>
        public void LoadQuaTrinhKhenThuong()
        {
            var lstItem = KhenThuongRepository.SelectByMaNhanVien(_nhanvien.MaNhanVien);
            lstvQuaTrinh.Items.Clear();
            for (int i = 0; i < lstItem.Count; i++)
            {
                var objListViewItem = new ListViewItem();
                objListViewItem.Tag = lstItem[i];
                objListViewItem.Text = (i + 1).ToString();
                objListViewItem.SubItems.Add(lstItem[i].NamNhan.ToString());
                objListViewItem.SubItems.Add(lstItem[i].HinhThucKhenThuong.TenHinhThucKhenThuong);
                objListViewItem.SubItems.Add(lstItem[i].GhiChu);
                lstvQuaTrinh.Items.Add(objListViewItem);
            }
        }

        /// <summary>
        /// Load qua trinh ky luat
        /// </summary>
        public void LoadQuaTrinhKyLuat()
        {
            var lstItem = KyLuatRepository.SelectByMaNhanVien(_nhanvien.MaNhanVien);
            lstvQuaTrinh.Items.Clear();
            for (int i = 0; i < lstItem.Count; i++)
            {
                var objListViewItem = new ListViewItem();
                objListViewItem.Tag = lstItem[i];
                objListViewItem.Text = (i + 1).ToString();
                objListViewItem.SubItems.Add(lstItem[i].NamKyLuat.ToString());
                objListViewItem.SubItems.Add(lstItem[i].HinhThucKyLuat.TenHinhThucKyLuat);
                objListViewItem.SubItems.Add(lstItem[i].LyDo);
                lstvQuaTrinh.Items.Add(objListViewItem);
            }
        }

        /// <summary>
        /// Load qua trinh ky luat
        /// </summary>
        public void LoadHuyHieu()
        {
            var lstItem = HuyHieuRepository.SelectByMaNhanVien(_nhanvien.MaNhanVien);
            lstvQuaTrinh.Items.Clear();
            for (int i = 0; i < lstItem.Count; i++)
            {
                var objListViewItem = new ListViewItem();
                objListViewItem.Tag = lstItem[i];
                objListViewItem.Text = (i + 1).ToString();
                objListViewItem.SubItems.Add(lstItem[i].NamNhan.ToString());
                objListViewItem.SubItems.Add(lstItem[i].LoaiHuyHieu.TenLoaiHuyHieu);
                lstvQuaTrinh.Items.Add(objListViewItem);
            }
        }

        /// <summary>
        /// Load qua trinh ky luat
        /// </summary>
        public void LoadLuongPhuCap()
        {
            var lstItem = LuongPhuCapRepository.SelectByMaNhanVien(_nhanvien.MaNhanVien);
            lstvQuaTrinh.Items.Clear();
            for (int i = 0; i < lstItem.Count; i++)
            {
                var objListViewItem = new ListViewItem();
                objListViewItem.Tag = lstItem[i];
                objListViewItem.Text = (i + 1).ToString();
                objListViewItem.SubItems.Add(String.Format("{0:dd/MM/yyyy}", lstItem[i].NgayThangNam.Value));
                objListViewItem.SubItems.Add(lstItem[i].MaNgachCongChuc == null ? "" : lstItem[i].NgachCongChuc.TenNgachCongChuc);
                lstvQuaTrinh.Items.Add(objListViewItem);
            }
        }

        /// <summary>
        /// Get update status after show form thongtinnhanvien
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GetUpdatedState_QTDaoTao(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            if (eventType.Data == "true")
            {
                LoadQuaTrinhDaoTao();
            }
        }

        /// <summary>
        /// Get update status after show form thongtinnhanvien
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GetUpdatedState_QTKhenThuong(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            if (eventType.Data == "true")
            {
                LoadQuaTrinhKhenThuong();
            }
        }

        /// <summary>
        /// Get update status after show form thongtinnhanvien
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GetUpdatedState_QTKyLuat(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            if (eventType.Data == "true")
            {
                LoadQuaTrinhKyLuat();
            }
        }

        /// <summary>
        /// Get update status after show form thongtinnhanvien
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GetUpdatedState_HuyHieu(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            if (eventType.Data == "true")
            {
                LoadHuyHieu();
            }
        }

        /// <summary>
        /// Get update status after show form thongtinnhanvien
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GetUpdatedState_LuongPhuCap(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            if (eventType.Data == "true")
            {
                LoadLuongPhuCap();
            }
        }

        /// <summary>
        /// Get update status after show form thongtinnhanvien
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GetUpdatedState_QTCongTac(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            if (eventType.Data == "true")
            {
                LoadQuaTrinhCongTac();
            }
        }

        private void btnCapNhatDuLieu_Click(object sender, EventArgs e)
        {
            switch (TypeOfQuaTrinh)
            {
                case EnumCacQuaTrinh.QUATRINHCONGTAC:
                    FrmNhapQuaTrinhCongTac frm1 = new FrmNhapQuaTrinhCongTac(_nhanvien);
                    frm1.Handler += GetUpdatedState_QTCongTac;
                    frm1.ShowDialog();
                    break;

                case EnumCacQuaTrinh.QUATRINHDAOTAO:
                    FrmNhapQuaTrinhDaoTao frm2 = new FrmNhapQuaTrinhDaoTao(_nhanvien);
                    frm2.Handler += GetUpdatedState_QTDaoTao;
                    frm2.ShowDialog();
                    break;

                case EnumCacQuaTrinh.KHENTHUONG:
                    FrmNhapQuaTrinhKhenThuong frm3 = new FrmNhapQuaTrinhKhenThuong(_nhanvien);
                    frm3.Handler += GetUpdatedState_QTKhenThuong;
                    frm3.ShowDialog();
                    break;

                case EnumCacQuaTrinh.KYLUAT:
                    FrmNhapQuaTrinhKyLuat frm4 = new FrmNhapQuaTrinhKyLuat(_nhanvien);
                    frm4.Handler += GetUpdatedState_QTKyLuat;
                    frm4.ShowDialog();
                    break;

                case EnumCacQuaTrinh.HUYHIEU:
                    FrmNhapHuyHieuDaDuocTang frm5 = new FrmNhapHuyHieuDaDuocTang(_nhanvien);
                    frm5.Handler += GetUpdatedState_HuyHieu;
                    frm5.ShowDialog();
                    break;

                case EnumCacQuaTrinh.LUONGPHUCAP:
                    FrmNhapLuongPhuCap frm6 = new FrmNhapLuongPhuCap(_nhanvien);
                    frm6.Handler += GetUpdatedState_LuongPhuCap;
                    frm6.ShowDialog();
                    break;
            }
        }
    }
}