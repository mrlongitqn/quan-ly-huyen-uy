using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyHoSoCongChuc.BusinessObject
{
    public class QuaTrinhCongTacMoiInfo
    {
        private int _MaQuaTrinhCongTac;
        private string _MaNhanVien;
        private string _MoTaCongTac;
        private int _MaNuocCongTac;
        private int _MaCapUy;
        private int _MaCapUyKiem;
        private string _ChucDanh;
        private int _MaChucVuChinhQuyen;
        private DateTime _ThoiGianBatDau;
        private DateTime _ThoiGianKetThuc;

        public DateTime ThoiGianKetThuc
        {
            get { return _ThoiGianKetThuc; }
            set { _ThoiGianKetThuc = value; }
        }

        public DateTime ThoiGianBatDau
        {
            get { return _ThoiGianBatDau; }
            set { _ThoiGianBatDau = value; }
        }        
        
        public int MaChucVuChinhQuyen
        {
            
            get { return _MaChucVuChinhQuyen; }
            set { _MaChucVuChinhQuyen = value; }
        }

        public string ChucDanh
        {
            get { return _ChucDanh; }
            set { _ChucDanh = value; }
        }

        public int MaCapUyKiem
        {
            get { return _MaCapUyKiem; }
            set { _MaCapUyKiem = value; }
        }

        public int MaCapUy
        {
            get { return _MaCapUy; }
            set { _MaCapUy = value; }
        }

        public int MaNuocCongTac
        {
            get { return _MaNuocCongTac; }
            set { _MaNuocCongTac = value; }
        }

        public string MoTaCongTac
        {
            get { return _MoTaCongTac; }
            set { _MoTaCongTac = value; }
        }

        public string MaNhanVien
        {
            get { return _MaNhanVien; }
            set { _MaNhanVien = value; }
        }

        public int MaQuaTrinhCongTac
        {
            get { return _MaQuaTrinhCongTac; }
            set { _MaQuaTrinhCongTac = value; }
        }

    }
}
