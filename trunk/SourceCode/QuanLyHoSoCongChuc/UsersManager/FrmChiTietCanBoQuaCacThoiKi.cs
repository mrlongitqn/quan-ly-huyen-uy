using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using QuanLyHoSoCongChuc.Utils;
using QuanLyHoSoCongChuc.Models;
using QuanLyHoSoCongChuc.Repositories;
using QuanLyHoSoCongChuc.Danh_muc;

namespace QuanLyHoSoCongChuc.UsersManager
{
    /// <summary>
    /// tuansl added: view detail of can bo qua cac thoi ki
    /// </summary>
    public partial class FrmChiTietCanBoQuaCacThoiKi : DevComponents.DotNetBar.Office2007Form
    {
        public EventHandler Handler { get; set; }
        public string Updated = "false";

        public FrmChiTietCanBoQuaCacThoiKi()
        {
            InitializeComponent();
        }

        public FrmChiTietCanBoQuaCacThoiKi(int macanbo)
        {
            InitializeComponent();
            var canbo = CanBoQuaCacThoiKiRepository.SelectByID(macanbo);
            txtMaCanBo.Text = canbo.MaCanBo.ToString();
            txtMaDonVi.Text = canbo.MaDonVi;
            txtHoTen.Text = canbo.HoTen;
            dtNamSinh.Value = canbo.NgaySinh.Value;
            chkbxConSong.Checked = canbo.TinhTrang.Value;
            txtQueQuan.Text = canbo.QueQuan;
            txtNoiOHienNay.Text = canbo.NoiOHienNay;
            txtChucVuDaGiu.Text = canbo.ChucVuDaGiu;
            txtCoQuanDaTungLamViec.Text = canbo.CoQuanDaLamViec;
            dtNgayVaoDang.Value = canbo.NgayVaoDang.Value;
            dtNgayChinhThuc.Value = canbo.NgayChinhThuc.Value;
            txtDiDong.Text = canbo.DiDong;
            txtMayBan.Text = canbo.MayBan;
            txtDanhHieu.Text = canbo.DanhHieuDaDuocPhong;
            txtQuaTrinhCongTac.Text = canbo.QuaTrinhCongTac;
            txtThamGiaChinhTri.Text = canbo.ThamGiaChinhTriXaHoi;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            var errorText = "";
            if (!ValidateInput(ref errorText))
            {
                MessageBox.Show(errorText, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtMaCanBo.Text != "")
            {
                if (ActionUpdate())
                {
                    MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TransferDataInfo(sender, new MyEvent("true"));
                }
                else
                {
                    MessageBox.Show("Cập nhật dữ liệu thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TransferDataInfo(sender, new MyEvent("false"));
                }
            }
            else
            {
                if (ActionAdd())
                {
                    MessageBox.Show("Thêm dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TransferDataInfo(sender, new MyEvent("true"));
                }
                else
                {
                    MessageBox.Show("Cập nhật dữ liệu thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TransferDataInfo(sender, new MyEvent("false"));
                }
            }
        }

        private void btnChonQueQuan_Click(object sender, EventArgs e)
        {
            // true: enable choosing mode
            // false: disable one
            FrmDanhMucHanhChinh frm = new FrmDanhMucHanhChinh(true);
            frm.Handler += GetNguyenQuan;
            frm.ShowDialog();
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
            txtQueQuan.Text = comp[1];
        }

        /// <summary>
        /// Add a new item to DB
        /// </summary>
        /// <returns></returns>
        private bool ActionAdd()
        {
            try
            {
                var item = new CanBoQuaCacThoiKi
                {
                    HoTen = txtHoTen.Text.Trim(),
                    MaDonVi = txtMaDonVi.Text,
                    NgaySinh = dtNamSinh.Value,
                    TinhTrang = chkbxConSong.Checked ? true : false,
                    QueQuan = txtQueQuan.Text,
                    NoiOHienNay = txtNoiOHienNay.Text,
                    ChucVuDaGiu = txtChucVuDaGiu.Text,
                    CoQuanDaLamViec = txtCoQuanDaTungLamViec.Text,
                    NgayVaoDang = dtNgayVaoDang.Value,
                    NgayChinhThuc = dtNgayChinhThuc.Value,
                    DiDong = txtDiDong.Text,
                    MayBan = txtMayBan.Text,
                    DanhHieuDaDuocPhong = txtDanhHieu.Text,
                    QuaTrinhCongTac = txtQuaTrinhCongTac.Text,
                    ThamGiaChinhTriXaHoi = txtThamGiaChinhTri.Text
                };
                if (!CanBoQuaCacThoiKiRepository.Insert(item))
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Update item with specificed ID
        /// </summary>
        /// <returns></returns>
        private bool ActionUpdate()
        {
            try
            {
                var item = CanBoQuaCacThoiKiRepository.SelectByID(int.Parse(txtMaCanBo.Text));
                item.HoTen = txtHoTen.Text.Trim();
                item.MaDonVi = txtMaDonVi.Text;
                item.NgaySinh = dtNamSinh.Value;
                item.TinhTrang = chkbxConSong.Checked ? true : false;
                item.QueQuan = txtQueQuan.Text;
                item.NoiOHienNay = txtNoiOHienNay.Text;
                item.ChucVuDaGiu = txtChucVuDaGiu.Text;
                item.CoQuanDaLamViec = txtCoQuanDaTungLamViec.Text;
                item.NgayVaoDang = dtNgayVaoDang.Value;
                item.NgayChinhThuc = dtNgayChinhThuc.Value;
                item.DiDong = txtDiDong.Text;
                item.MayBan = txtMayBan.Text;
                item.DanhHieuDaDuocPhong = txtDanhHieu.Text;
                item.QuaTrinhCongTac = txtQuaTrinhCongTac.Text;
                item.ThamGiaChinhTriXaHoi = txtThamGiaChinhTri.Text;
                return CanBoQuaCacThoiKiRepository.Save();
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// tuansl added: function is used to transfer data when event would be raised
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TransferDataInfo(object sender, MyEvent e)
        {
            this.Close();
            this.Handler(this, e);
        }

        /// <summary>
        /// Validate user input
        /// </summary>
        /// <param name="isUpdate"></param>
        /// <returns></returns>
        private bool ValidateInput(ref string errorText)
        {
            // Mode update -> checking MaChucNang is exists on textbox
            if (txtHoTen.Text == "")
            {
                errorText = "Vui lòng nhập họ tên";
                return false;
            }

            if (txtMaDonVi.Text == "")
            {
                errorText = "Vui lòng chọn đơn vị";
                return false;
            }
            return true;
        }
    }
}