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
            LoadDanToc();
            LoadTonGiao();
            LoadNgheNghiepTruocTuyenDung();
            LoadThanhPhanGiaDinh();
        }

        private void FrmThongTinNhanVien_TomTat_Load(object sender, EventArgs e)
        {
            LoadTomTat();
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
            SetSelectedTonGiao(_nhanvien);
            SetSelectedNgheNghiepTruocTuyenDung(_nhanvien);
            SetSelectedThanhPhanXuatThan(_nhanvien);
        }

        public void LoadDanToc()
        {
            var lstItem = DanTocRepository.SelectAll();
            if (lstItem.Count > 0)
            {
                cbxDanToc.DataSource = lstItem;
            }
        }

        public void LoadTonGiao()
        {
            var lstItem = TonGiaoRepository.SelectAll();
            if (lstItem.Count > 0)
            {
                cbxTonGiao.DataSource = lstItem;
            }
        }

        public void LoadNgheNghiepTruocTuyenDung()
        {
            var lstItem = NgheNghiepRepository.SelectAll();
            if (lstItem.Count > 0)
            {
                cbxNgheNghiepTruocKhiDuocTuyenDung.DataSource = lstItem;
            }
        }

        public void LoadThanhPhanGiaDinh()
        {
            var lstItem = ThanhPhanXuatThanRepository.SelectAll();
            if (lstItem.Count > 0)
            {
                cbxThanhPhanGiaDinh.DataSource = lstItem;
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

        public void SetSelectedTonGiao(NhanVien nhanvien)
        {
            foreach (var item in cbxTonGiao.Items)
            {
                if (((TonGiao)item).MaTonGiao == nhanvien.MaTonGiao)
                {
                    cbxTonGiao.SelectedItem = item;
                    break;
                }
            }
        }

        public void SetSelectedThanhPhanXuatThan(NhanVien nhanvien)
        {
            foreach (var item in cbxThanhPhanGiaDinh.Items)
            {
                if (((ThanhPhanXuatThan)item).MaThanhPhanXuatThan == nhanvien.MaThanhPhanXuatThan)
                {
                    cbxThanhPhanGiaDinh.SelectedItem = item;
                    break;
                }
            }
        }

        public void SetSelectedNgheNghiepTruocTuyenDung(NhanVien nhanvien)
        {
            foreach (var item in cbxNgheNghiepTruocKhiDuocTuyenDung.Items)
            {
                if (((NgheNghiep)item).MaNgheNghiep == nhanvien.MaNgheNghiepTruocTuyenDung)
                {
                    cbxNgheNghiepTruocKhiDuocTuyenDung.SelectedItem = item;
                    break;
                }
            }
        }
    }
}