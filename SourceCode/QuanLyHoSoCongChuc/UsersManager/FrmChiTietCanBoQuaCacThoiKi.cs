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
using QuanLyHoSoCongChuc.DataManager;

namespace QuanLyHoSoCongChuc.UsersManager
{
    /// <summary>
    /// tuansl added: view detail of can bo qua cac thoi ki
    /// </summary>
    public partial class FrmChiTietCanBoQuaCacThoiKi : DevComponents.DotNetBar.Office2007Form
    {
        public EventHandler Handler { get; set; }
        public bool Updated = false;
        private CanBoVeHuuChuyenDen _canbo;
        private string _maDonVi;

        public FrmChiTietCanBoQuaCacThoiKi(string madonvi)
        {
            InitializeComponent();
            _maDonVi = madonvi;
            txtMaDonVi.Text = madonvi;
        }

        public FrmChiTietCanBoQuaCacThoiKi(CanBoQuaCacThoiKi canbo)
        {
            InitializeComponent();
            _canbo = canbo.CanBoVeHuuChuyenDen;
            txtMaDonVi.Text = canbo.MaDonVi;

            txtMaCanBo.Text = _canbo.MaCanBo.ToString();
            txtHoTen.Text = _canbo.HoTen;
            dtNamSinh.Value = _canbo.NgaySinh.Value;
            chkbxConSong.Checked = _canbo.ConSong.Value;
            txtQueQuan.Text = _canbo.QueQuan;
            txtNoiOHienNay.Text = _canbo.NoiOHienNay;
            txtChucVuDaGiu.Text = _canbo.ChucVuDaGiu;
            txtCoQuanDaTungLamViec.Text = _canbo.CoQuanDaLamViec;
            dtNgayVaoDang.Value = _canbo.NgayVaoDang.Value;
            dtNgayChinhThuc.Value = _canbo.NgayChinhThuc.Value;
            txtDiDong.Text = _canbo.DiDong;
            txtMayBan.Text = _canbo.MayBan;
            txtDanhHieu.Text = _canbo.DanhHieuDaDuocPhong;
            txtQuaTrinhCongTac.Text = _canbo.QuaTrinhCongTac;
            txtThamGiaChinhTri.Text = _canbo.ThamGiaChinhTriXaHoi;
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
                    Updated = true;
                }
            }
            else
            {
                if (ActionAdd())
                {
                    Updated = true;
                }
            }

            if (Updated)
            {
                MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                // Open connection
                DataContext.Instance.Connection.Open();
                // Define a transaction for the operations
                using (var transaction = DataContext.Instance.Connection.BeginTransaction())
                {
                    var canbo = new CanBoQuaCacThoiKi
                    {
                        MaLoaiCanBo = LoaiCanBoQuaCacThoiKiRepository.SelectByName(GlobalPhieuBaos.NOIKHAC_CHUYENDEN).MaLoaiCanBoQuaCacThoiKiMa,
                        MaDonVi = txtMaDonVi.Text
                    };
                    if (CanBoQuaCacThoiKiRepository.Insert(canbo))
                    {
                        var item = new CanBoVeHuuChuyenDen
                        {
                            MaCanBo = canbo.MaCanBo,
                            HoTen = txtHoTen.Text.Trim(),
                            NgaySinh = dtNamSinh.Value,
                            ConSong = chkbxConSong.Checked ? true : false,
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
                        if (!CanBoVeHuuChuyenDenRepository.Insert(item))
                        {
                            return false;
                        }
                    }

                    // Mark the transaction as complete
                    transaction.Commit();
                    DataContext.Instance.Connection.Close();
                    return true;
                }
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
                _canbo.HoTen = txtHoTen.Text.Trim();
                _canbo.NgaySinh = dtNamSinh.Value;
                _canbo.ConSong = chkbxConSong.Checked ? true : false;
                _canbo.QueQuan = txtQueQuan.Text;
                _canbo.NoiOHienNay = txtNoiOHienNay.Text;
                _canbo.ChucVuDaGiu = txtChucVuDaGiu.Text;
                _canbo.CoQuanDaLamViec = txtCoQuanDaTungLamViec.Text;
                _canbo.NgayVaoDang = dtNgayVaoDang.Value;
                _canbo.NgayChinhThuc = dtNgayChinhThuc.Value;
                _canbo.DiDong = txtDiDong.Text;
                _canbo.MayBan = txtMayBan.Text;
                _canbo.DanhHieuDaDuocPhong = txtDanhHieu.Text;
                _canbo.QuaTrinhCongTac = txtQuaTrinhCongTac.Text;
                _canbo.ThamGiaChinhTriXaHoi = txtThamGiaChinhTri.Text;
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
            return true;
        }

        private void FrmChiTietCanBoQuaCacThoiKi_FormClosed(object sender, FormClosedEventArgs e)
        {
            TransferDataInfo(sender, new MyEvent(Updated ? "true" : "false"));
        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {
            int start = this.txtHoTen.SelectionStart;
            this.txtHoTen.Text = this.txtHoTen.Text.ToUpper();
            this.txtHoTen.SelectionStart = start;
        }
    }
}