using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using QuanLyHoSoCongChuc.Repositories;
using QuanLyHoSoCongChuc.Models;
using QuanLyHoSoCongChuc.Utils;
using QuanLyHoSoCongChuc.Danh_muc;

namespace QuanLyHoSoCongChuc.NhanVienManager
{
    /// <summary>
    /// tuansl added: main form is used to manage infos of nhanvien
    /// </summary>
    public partial class FrmThongTinNhanVien : DevComponents.DotNetBar.Office2007Form
    {
        private string _maNhanVien;
        private Color imgCurrentNavImage;
        private FrmThongTinNhanVien_TomTat frmThongTinNhanVien_TomTat;
        private FrmThongTinNhanVien_CacQuaTrinh frmThongTinNhanVien_CacQuaTrinh;
        private FrmThongTinNhanVien_GiaDinh frmThongTinNhanVien_GiaDinh;
        private FrmThongTinNhanVien_DacDiemLichSu frmThongTinNhanVien_DacDiemLichSu;
        private FrmThongTinNhanVien_LuongPhuCap frmThongTinNhanVien_LuongPhuCap;

        public FrmThongTinNhanVien()
        {
            InitializeComponent();
        }

        public FrmThongTinNhanVien(string manhanvien)
        {
            InitializeComponent();
            _maNhanVien = manhanvien;
            LoadGioiTinh();
            LoadThongTinNhanVien();
        }

        private void FrmThongTinNhanVien_Load(object sender, EventArgs e)
        {
            
        }

        public void LoadThongTinNhanVien()
        {
            //var nhanvien = NhanVienRepository.SelectByID(_maNhanVien);
            //txtMaDonVi.Text = nhanvien.MaDonVi;
            //txtTenDonViDayDu.Text = nhanvien.DonVi.TenDonVi;
            //txtHoTenKhaiSinh.Text = nhanvien.HoTenNhanVien;
            //SetSelectedGioiTinh(nhanvien);
            //dtSinhNgay.Value = nhanvien.NgaySinh.Value;

            //InitForm(nhanvien);
        }

        public void InitForm(NhanVien nhanvien)
        {
            lblTomTat.MouseEnter += new EventHandler(NavigationChildControl_MouseEnter);
            lblTomTat.MouseLeave += new EventHandler(NavigationChildControl_MouseLeave);
            lblTomTat.MouseUp += new MouseEventHandler(NavigationChildControl_MouseUp);

            lblCacQuaTrinh.MouseEnter += new EventHandler(NavigationChildControl_MouseEnter);
            lblCacQuaTrinh.MouseLeave += new EventHandler(NavigationChildControl_MouseLeave);
            lblCacQuaTrinh.MouseUp += new MouseEventHandler(NavigationChildControl_MouseUp);

            lblDacDiemLS.MouseEnter += new EventHandler(NavigationChildControl_MouseEnter);
            lblDacDiemLS.MouseLeave += new EventHandler(NavigationChildControl_MouseLeave);
            lblDacDiemLS.MouseUp += new MouseEventHandler(NavigationChildControl_MouseUp);

            lblGiaDinh.MouseEnter += new EventHandler(NavigationChildControl_MouseEnter);
            lblGiaDinh.MouseLeave += new EventHandler(NavigationChildControl_MouseLeave);
            lblGiaDinh.MouseUp += new MouseEventHandler(NavigationChildControl_MouseUp);

            lblLuongPhuCap.MouseEnter += new EventHandler(NavigationChildControl_MouseEnter);
            lblLuongPhuCap.MouseLeave += new EventHandler(NavigationChildControl_MouseLeave);
            lblLuongPhuCap.MouseUp += new MouseEventHandler(NavigationChildControl_MouseUp);

            frmThongTinNhanVien_TomTat = new FrmThongTinNhanVien_TomTat(nhanvien);
            frmThongTinNhanVien_TomTat.TopLevel = false;
            frmThongTinNhanVien_TomTat.FormBorderStyle = FormBorderStyle.None;
            frmThongTinNhanVien_TomTat.Dock = DockStyle.Fill;

            frmThongTinNhanVien_CacQuaTrinh = new FrmThongTinNhanVien_CacQuaTrinh(nhanvien);
            frmThongTinNhanVien_CacQuaTrinh.TopLevel = false;
            frmThongTinNhanVien_CacQuaTrinh.FormBorderStyle = FormBorderStyle.None;
            frmThongTinNhanVien_CacQuaTrinh.Dock = DockStyle.Fill;

            frmThongTinNhanVien_DacDiemLichSu = new FrmThongTinNhanVien_DacDiemLichSu(nhanvien);
            frmThongTinNhanVien_DacDiemLichSu.TopLevel = false;
            frmThongTinNhanVien_DacDiemLichSu.FormBorderStyle = FormBorderStyle.None;
            frmThongTinNhanVien_DacDiemLichSu.Dock = DockStyle.Fill;

            frmThongTinNhanVien_GiaDinh = new FrmThongTinNhanVien_GiaDinh(nhanvien);
            frmThongTinNhanVien_GiaDinh.TopLevel = false;
            frmThongTinNhanVien_GiaDinh.FormBorderStyle = FormBorderStyle.None;
            frmThongTinNhanVien_GiaDinh.Dock = DockStyle.Fill;

            frmThongTinNhanVien_LuongPhuCap = new FrmThongTinNhanVien_LuongPhuCap(nhanvien);
            frmThongTinNhanVien_LuongPhuCap.TopLevel = false;
            frmThongTinNhanVien_LuongPhuCap.FormBorderStyle = FormBorderStyle.None;
            frmThongTinNhanVien_LuongPhuCap.Dock = DockStyle.Fill;

            //Add to middle view
            pnlChangeView.Controls.Clear();
            pnlChangeView.Controls.Add(frmThongTinNhanVien_TomTat);
            frmThongTinNhanVien_TomTat.Show();
        }

        private void NavigationChildControl_MouseEnter(Object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(LabelX))
            {
                imgCurrentNavImage = ((LabelX)sender).ForeColor;
                if (((LabelX)sender).ForeColor != Color.Lime)
                {
                    ((LabelX)sender).ForeColor = Color.Lime;
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
                imgCurrentNavImage = Color.Lime;
                ((LabelX)sender).ForeColor = Color.Lime;
                Navigate(((LabelX)sender).Name);
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
                        case "lblTomTat":
                            if (Shortcut == "lblTomTat")
                            {
                                objControl.ForeColor = Color.Lime;
                                pnlChangeView.Controls.Clear();
                                pnlChangeView.Controls.Add(frmThongTinNhanVien_TomTat);
                                frmThongTinNhanVien_TomTat.Show();
                            }
                            else
                            {
                                objControl.ForeColor = Color.White;
                            }
                            break;

                        case "lblCacQuaTrinh":
                            if (Shortcut == "lblCacQuaTrinh")
                            {
                                objControl.ForeColor = Color.Lime;
                                pnlChangeView.Controls.Clear();
                                pnlChangeView.Controls.Add(frmThongTinNhanVien_CacQuaTrinh);
                                frmThongTinNhanVien_CacQuaTrinh.Show();
                            }
                            else
                            {
                                objControl.ForeColor = Color.White;
                            }
                            break;

                        case "lblDacDiemLS":
                            if (Shortcut == "lblDacDiemLS")
                            {
                                objControl.ForeColor = Color.Lime;
                                pnlChangeView.Controls.Clear();
                                pnlChangeView.Controls.Add(frmThongTinNhanVien_DacDiemLichSu);
                                frmThongTinNhanVien_DacDiemLichSu.Show();
                            }
                            else
                            {
                                objControl.ForeColor = Color.White;
                            }
                            break;

                        case "lblGiaDinh":
                            if (Shortcut == "lblGiaDinh")
                            {
                                objControl.ForeColor = Color.Lime;
                                pnlChangeView.Controls.Clear();
                                pnlChangeView.Controls.Add(frmThongTinNhanVien_GiaDinh);
                                frmThongTinNhanVien_GiaDinh.Show();
                            }
                            else
                            {
                                objControl.ForeColor = Color.White;
                            }
                            break;

                        case "lblLuongPhuCap":
                            if (Shortcut == "lblLuongPhuCap")
                            {
                                objControl.ForeColor = Color.Lime;
                                pnlChangeView.Controls.Clear();
                                pnlChangeView.Controls.Add(frmThongTinNhanVien_LuongPhuCap);
                                frmThongTinNhanVien_LuongPhuCap.Show();
                            }
                            else
                            {
                                objControl.ForeColor = Color.White;
                            }
                            break;
                    }
                }
            }
        }

        public void SetSelectedGioiTinh(NhanVien nhanvien)
        {
            foreach (var item in cbxGioiTinh.Items)
            {
                //if (((GioiTinh)item).MaGioiTinh == nhanvien.MaGioiTinh)
                //{
                //    cbxGioiTinh.SelectedItem = item;
                //    break;
                //}
            }
        }

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
    }
}