using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace QuanLyHoSoCongChuc.NhanVienManager
{
    #region Using
    using QuanLyHoSoCongChuc.Models;
    using QuanLyHoSoCongChuc.Utils;
    using QuanLyHoSoCongChuc.Repositories;
    using QuanLyHoSoCongChuc.OtherForms;
    #endregion

    /// <summary>
    /// tuansl added: manage family info of nhanvien
    /// </summary>
    public partial class FrmThongTinNhanVien_GiaDinh : DevComponents.DotNetBar.Office2007Form
    {
        #region Variables
        public NhanVien _nhanvien { get; set; }
        // Hidden files are used to store ids 
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaHoatDongKinhTe;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaHoanCanhKinhTe;
        // This variable is used to end changing on textbox
        private bool endChange = false;
        #endregion

        #region Properties
        public string TongThuNhapGiaDinh
        {
            get
            {
                return txtTongThuNhap.Text.Replace(",", "");
            }
        }
        public string NhaODuocCap
        {
            get
            {
                return txtNhaODuocCap.Text;
            }
        }
        public string NhaOTuMua
        {
            get
            {
                return txtNhaOTuMua.Text;
            }
        }
        public string DatDuocCap
        {
            get
            {
                return txtDatDuocCap.Text;
            }
        }
        public int MaHoatDongKinhTe
        {
            get
            {
                return txtMaHoatDongKinhTe.Text == "" ? -1 : int.Parse(txtMaHoatDongKinhTe.Text);
            }
        }
        public string DienTichDatKinhDoanhTrangTrai
        {
            get
            {
                return txtDienTichDatKinhDoanhTrangTrai.Text;
            }
        }
        public string TaiSanCoGiaTri
        {
            get
            {
                return txtTaiSanGiaTri.Text;
            }
        }
        public string BinhQuanDauNguoi
        {
            get
            {
                return txtBinhQuanDauNguoi.Text.Replace(",", "");
            }
        }
        public string DienTichSuDungNhaO
        {
            get
            {
                return txtDienTichSuDungNhaO.Text;
            }
        }
        public string DienTichSuDungDatO
        {
            get
            {
                return txtDienTichSuDungDat.Text;
            }
        }
        public string DatTuMua
        {
            get
            {
                return txtDatTuMua.Text;
            }
        }
        public string SoLaoDongThue
        {
            get
            {
                return txtSoLaoDongThue.Text;
            }
        }
        public string GiaTriTaiSan
        {
            get
            {
                return txtGiaTriTaiSan.Text.Replace(",", "");
            }
        }
        #endregion

        public FrmThongTinNhanVien_GiaDinh(NhanVien nhanvien)
        {
            InitializeComponent();
            InitHiddenFields();
            _nhanvien = nhanvien;
            if (_nhanvien != null)
            {
                LoadThanNhans();
                LoadHoanCanhKinhte();
            }
        }

        /// <summary>
        /// Init hidden fields
        /// </summary>
        public void InitHiddenFields()
        {
            // Add a new textbox
            txtMaHoanCanhKinhTe = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaHoanCanhKinhTe",
                Text = ""
            };
            txtMaHoanCanhKinhTe.Visible = false;

            // Add a new textbox
            txtMaHoatDongKinhTe = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaHoatDongKinhTe",
                Text = ""
            };
            txtMaHoatDongKinhTe.Visible = false;
        }

        public void InitForm()
        {
            lblQuanHeGiaDinh.MouseEnter += new EventHandler(NavigationChildControl_MouseEnter);
            lblQuanHeGiaDinh.MouseLeave += new EventHandler(NavigationChildControl_MouseLeave);
            lblQuanHeGiaDinh.MouseUp += new MouseEventHandler(NavigationChildControl_MouseUp);
        }

        private void NavigationChildControl_MouseEnter(Object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(LabelX))
            {
                ((LabelX)sender).Cursor = Cursors.Hand;
            }
        }

        private void NavigationChildControl_MouseLeave(Object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(LabelX))
            {
                ((LabelX)sender).Cursor = Cursors.Default;
            }
        }

        private void NavigationChildControl_MouseUp(Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (sender.GetType() == typeof(LabelX))
            {
                Navigate(((LabelX)sender).Name);
            }
        }

        private void Navigate(string Shortcut)
        {
            FrmNhapQuanHeGiaDinh frm = new FrmNhapQuanHeGiaDinh(_nhanvien);
            frm.Handler += GetUpdatedState_ThanNhan;
            frm.ShowDialog();
        }

        /// <summary>
        /// Get update status after show form thongtinnhanvien
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GetUpdatedState_ThanNhan(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            if (eventType.Data == "true")
            {
                LoadThanNhans();
            }
        }

        private void FrmThongTinNhanVien_GiaDinh_Load(object sender, EventArgs e)
        {
            InitForm();
            InitKeysPressEvent();
        }

        private void btnChonHDKT_Click(object sender, EventArgs e)
        {
            FrmQuanLyHoatDongKinhTe frm = new FrmQuanLyHoatDongKinhTe();
            frm.Handler += GetHoatDongKT;
            frm.ShowDialog();
        }

        public void GetHoatDongKT(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaHoatDongKinhTe.Text = comp[0];
            txtHoatDongKinhTe.Text = comp[1];
        }

        /// <summary>
        /// Load list of thannhan of specified nhanvien
        /// </summary>
        public void LoadThanNhans()
        {
            var lstItem = ThanNhanRepository.SelectByMaNhanVien(_nhanvien.MaNhanVien);
            lstvData.Items.Clear();
            for (int i = 0; i < lstItem.Count; i++)
            {
                var objListViewItem = new ListViewItem();
                objListViewItem.Tag = lstItem[i];
                objListViewItem.Text = (i + 1).ToString();
                objListViewItem.SubItems.Add(lstItem[i].QuanHe.TenQuanHe);
                objListViewItem.SubItems.Add(lstItem[i].TenThanNhan);
                objListViewItem.SubItems.Add(lstItem[i].NamSinh.ToString());
                objListViewItem.SubItems.Add(lstItem[i].ThongTinCaNhan);
                lstvData.Items.Add(objListViewItem);
            }
        }

        /// <summary>
        /// Load hoan canh kinh te of specified nhan vien
        /// </summary>
        public void LoadHoanCanhKinhte()
        {
            var lstItem = HoanCanhKinhTeRepository.SelectByMaNhanVien(_nhanvien.MaNhanVien);
            if (lstItem.Count > 0)
            {
                var item = lstItem[0];
                txtTongThuNhap.Text = item.TongThuNhapGiaDinh.ToString();
                txtBinhQuanDauNguoi.Text = item.BinhQuanDauNguoi.ToString();
                txtNhaODuocCap.Text = item.NhaODuocCap.ToString();
                txtNhaOTuMua.Text = item.NhaOTuMua.ToString();
                txtDienTichSuDungNhaO.Text = item.DienTichSuDungDatO.ToString();
                txtDienTichSuDungDat.Text = item.DienTichSuDungDatO.ToString();
                txtDatDuocCap.Text = item.DienTichDatDuocCap.ToString();
                txtDatTuMua.Text = item.DienTichDatTuMua.ToString();
                txtMaHoatDongKinhTe.Text = item.MaHoatDongKinhTe == null ? "" : item.MaHoatDongKinhTe.ToString();
                txtHoatDongKinhTe.Text = item.MaHoatDongKinhTe == null ? "" : item.HoatDongKinhTe.TenHoatDongKinhTe;
                txtDienTichDatKinhDoanhTrangTrai.Text = item.DienTichDatKinhDoanhTrangTrai.ToString();
                txtSoLaoDongThue.Text = item.SoLaoDongThue.ToString();
                txtTaiSanGiaTri.Text = item.TaiSanCoGiaTri;
                txtGiaTriTaiSan.Text = item.GiaTriTaiSan.ToString();
            }
        }

        private void txtTongThuNhap_TextChanged(object sender, EventArgs e)
        {
            if (endChange)
            {
                endChange = false;
                this.txtTongThuNhap.SelectionStart = this.txtTongThuNhap.Text.Length;
                return;
            }
            if (txtTongThuNhap.Text.Length > 0)
            {
                var strOrigin = txtTongThuNhap.Text.Replace(",", "");
                var strFormated = String.Format("{0:#,##0;Nothing}", long.Parse(strOrigin));
                if (strOrigin != strFormated)
                {
                    endChange = true;
                    this.txtTongThuNhap.Text = strFormated;
                }
            }
        }

        private void txtBinhQuanDauNguoi_TextChanged(object sender, EventArgs e)
        {
            if (endChange)
            {
                endChange = false;
                this.txtBinhQuanDauNguoi.SelectionStart = this.txtBinhQuanDauNguoi.Text.Length;
                return;
            }
            if (txtBinhQuanDauNguoi.Text.Length > 0)
            {
                var strOrigin = txtBinhQuanDauNguoi.Text.Replace(",", "");
                var strFormated = String.Format("{0:#,##0;Nothing}", long.Parse(strOrigin));
                if (strOrigin != strFormated)
                {
                    endChange = true;
                    this.txtBinhQuanDauNguoi.Text = strFormated;
                }
            }
        }

        private void txtGiaTriTaiSan_TextChanged(object sender, EventArgs e)
        {
            if (endChange)
            {
                endChange = false;
                this.txtGiaTriTaiSan.SelectionStart = this.txtGiaTriTaiSan.Text.Length;
                return;
            }
            if (txtGiaTriTaiSan.Text.Length > 0)
            {
                var strOrigin = txtGiaTriTaiSan.Text.Replace(",", "");
                var strFormated = String.Format("{0:#,##0;Nothing}", long.Parse(strOrigin));
                if (strOrigin != strFormated)
                {
                    endChange = true;
                    this.txtGiaTriTaiSan.Text = strFormated;
                }
            }
        }

        public void InitKeysPressEvent()
        {
            txtTongThuNhap.KeyPress += NavigationChildControl_KeyPress;
            txtBinhQuanDauNguoi.KeyPress += NavigationChildControl_KeyPress;
            txtDienTichSuDungNhaO.KeyPress += NavigationChildControl_KeyPress;
            txtDienTichSuDungDat.KeyPress += NavigationChildControl_KeyPress;
            txtDatDuocCap.KeyPress += NavigationChildControl_KeyPress;
            txtDatTuMua.KeyPress += NavigationChildControl_KeyPress;
            txtDienTichDatKinhDoanhTrangTrai.KeyPress += NavigationChildControl_KeyPress;
            txtSoLaoDongThue.KeyPress += NavigationChildControl_KeyPress;
            txtTaiSanGiaTri.KeyPress += NavigationChildControl_KeyPress;
            txtGiaTriTaiSan.KeyPress += NavigationChildControl_KeyPress;
        }

        private void NavigationChildControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow type number
            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}