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
    /// tuansl added: manage historical charaterize info of nhanvien
    /// </summary>
    public partial class FrmThongTinNhanVien_DacDiemLichSu : DevComponents.DotNetBar.Office2007Form
    {
        private NhanVien _nhanvien;

        #region Properties
        public DateTime NgayVaoDangLan2
        {
            get
            {
                return dtNgayVaoDangLan2.Value;
            }
        }
        public string VaoDangLan2TaiChiBo
        {
            get
            {
                return txtVaoDangLan2TaiChiBo.Text;
            }
        }
        public string NguoiGioiThieu1
        {
            get
            {
                return txtNguoiGioiThieu1.Text;
            }
        }
        public string ChucVuNguoi1
        {
            get
            {
                return txtChucVuNguoi1.Text;
            }
        }
        public string NguoiGioiThieu2
        {
            get
            {
                return txtNguoiGioiThieu2.Text;
            }
        }
        public string ChucVuNguoi2
        {
            get
            {
                return txtChucVuNguoi2.Text;
            }
        }
        public DateTime NgayChinhThucLan2
        {
            get
            {
                return dtNgayChinhThucLan2.Value;
            }
        }
        public string ChinhThucLan2TaiChiBo
        {
            get
            {
                return txtChinhThucLan2TaiChiBo.Text;
            }
        }
        public DateTime NgayKhoiPhucDang
        {
            get
            {
                return dtNgayKhoiPhucDang.Value;
            }
        }
        public string KhoiPhucDangtaiChiBo
        {
            get
            {
                return txtKhoiPhucDangtaiChiBo.Text;
            }
        }
        public string BiBatTu
        {
            get
            {
                return txtBiBatTu.Text;
            }
        }
        public string LamViecChoCheDoCu
        {
            get
            {
                return txtLamViecChoCheDoCu.Text;
            }
        }
        public string DaDiNuocNgoai
        {
            get
            {
                return txtDaDiNuocNgoai.Text;
            }
        }
        public string QuanHeVoiToChucNN
        {
            get
            {
                return txtQuanHeVoiToChucNN.Text;
            }
        }
        public string ThanhNhanONuocNgoai
        {
            get
            {
                return txtThanhNhanONuocNgoai.Text;
            }
        }
        public string NhanXetCuaDonVi
        {
            get
            {
                return txtNhanXetCuaDonVi.Text;
            }
        }
        #endregion

        public FrmThongTinNhanVien_DacDiemLichSu(NhanVien nhanvien)
        {
            InitializeComponent();
            _nhanvien = nhanvien;
            if (_nhanvien != null)
            {
                LoadData();
            }
        }

        /// <summary>
        /// Load base info of nhanvien that are showed in form tomtat
        /// </summary>
        public void LoadData()
        {
            var lstItem = DacDiemLichSuRepository.SelectByMaNhanVien(_nhanvien.MaNhanVien);
            if (lstItem.Count > 0)
            {
                var dacdiemls = lstItem[0];
                dtNgayVaoDangLan2.Value = dacdiemls.NgayVaoDangLan2.Value;
                txtVaoDangLan2TaiChiBo.Text = dacdiemls.VaoDangLan2TaiChiBo;
                txtNguoiGioiThieu1.Text = dacdiemls.NguoiGioiThieu1;
                txtChucVuNguoi1.Text = dacdiemls.ChucVuNguoi1;
                txtNguoiGioiThieu2.Text = dacdiemls.NguoiGioiThieu2;
                txtChucVuNguoi2.Text = dacdiemls.ChucVuNguoi2;
                dtNgayChinhThucLan2.Value = dacdiemls.NgayChinhThucLan2.Value;
                txtChinhThucLan2TaiChiBo.Text = dacdiemls.ChinhThucLan2TaiChiBo;
                dtNgayKhoiPhucDang.Value = dacdiemls.NgayKhoiPhucDang.Value;
                txtKhoiPhucDangtaiChiBo.Text = dacdiemls.KhoiPhucDangtaiChiBo;
                txtBiBatTu.Text = dacdiemls.BiBatTu;
                txtLamViecChoCheDoCu.Text = dacdiemls.LamViecChoCheDoCu;
                txtDaDiNuocNgoai.Text = dacdiemls.DaDiNuocNgoai;
                txtQuanHeVoiToChucNN.Text = dacdiemls.QuanHeVoiToChucNN;
                txtThanhNhanONuocNgoai.Text = dacdiemls.ThanhNhanONuocNgoai;
                txtNhanXetCuaDonVi.Text = dacdiemls.NhanXetCuaDonVi;
            }
        }
    }
}