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

namespace QuanLyHoSoCongChuc.NhanVienManager
{
    /// <summary>
    /// tuansl added: manage sumary info of nhanvien
    /// </summary>
    public partial class FrmThongTinNhanVien_TomTat : DevComponents.DotNetBar.Office2007Form
    {
        private NhanVien _nhanvien;

        public FrmThongTinNhanVien_TomTat(NhanVien nhanvien)
        {
            InitializeComponent();
            _nhanvien = nhanvien;
        }

        public void LoadTomTat()
        {
            txtMaNhanVien.Text = _nhanvien.MaNhanVien;
            txtSoDienThoai.Text = _nhanvien.DienThoaiDiDong;
            txtHoTenDangDung.Text = _nhanvien.HoTenNhanVien;
            txtNoiSinh.Text = _nhanvien.NoiSinh;
            txtQueQuan.Text = _nhanvien.QueQuan;
            txtHoKhau.Text = _nhanvien.HoKhauThuongTru;
            txtNoiOTamTru.Text = _nhanvien.NoiOHienTai;
            SetSelectedDanToc(_nhanvien);
        }

        public void LoadDanToc()
        {
            var lstItem = DanTocRepository.SelectAll();
            if (lstItem.Count > 0)
            {
                cbxDanToc.DataSource = lstItem;
            }
        }

        public void SetSelectedDanToc(NhanVien nhanvien)
        {
            foreach (var item in cbxDanToc.Items)
            {
                if (((DanToc)item).MaDanToc == nhanvien.MaDanToc)
                {
                    cbxDanToc.SelectedItem = item;
                    break;
                }
            }
        }
    }
}