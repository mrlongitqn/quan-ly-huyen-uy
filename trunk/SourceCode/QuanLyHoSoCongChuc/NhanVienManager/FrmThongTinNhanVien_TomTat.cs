using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using QuanLyHoSoCongChuc.Models;
using QuanLyHoSoCongChuc.Repositories;
using QuanLyHoSoCongChuc.Utils;

namespace QuanLyHoSoCongChuc.NhanVienManager
{
    /// <summary>
    /// tuansl added: manage sumary info of nhanvien
    /// </summary>
    public partial class FrmThongTinNhanVien_TomTat : DevComponents.DotNetBar.Office2007Form
    {
        private NhanVien _nhanvien;
        // Hidden files are used to store ids 
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaChucVu;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaDanToc;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaTonGiao;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaThanhPhanGiaDinh;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaNgheNghiepTruocKhiDuocTuyenDung;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaGiaoDucPhoThong;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaChuyenMonNghiepVu;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaLyLuanChinhTri;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaNgoaiNgu;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaHocViCaoNhat;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaHocHam;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaTinhTrangSucKhoe;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaLoaiThuongBinh;

        public FrmThongTinNhanVien_TomTat(NhanVien nhanvien)
        {
            InitializeComponent();
            _nhanvien = nhanvien;
            LoadTomTat();
        }

        private void FrmThongTinNhanVien_TomTat_Load(object sender, EventArgs e)
        {
            
        }

        public void LoadTomTat()
        {
            txtMaNhanVien.Text = _nhanvien.MaNhanVien;
            txtSoDienThoai.Text = _nhanvien.SoDienThoai;
            txtHoTenDangDung.Text = _nhanvien.HoTenDangDung;
            txtNoiSinh.Text = _nhanvien.NoiSinh;
            txtQueQuan.Text = _nhanvien.QueQuan;
            txtHoKhau.Text = _nhanvien.HoKhau;
            txtNoiOTamTru.Text = _nhanvien.TamTru;
            picNv.Image = new Bitmap(GlobalVars.g_strPathImages + "\\" + _nhanvien.HinhAnh);
            txtChucVu.Text = _nhanvien.ChucVu.TenChucVu; 

            
        }
    }
}