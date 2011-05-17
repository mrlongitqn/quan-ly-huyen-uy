using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyHoSoCongChuc.BusinessObject
{
    public class ThanNhanMoiInfo
    {
        private int _MaThanNhan;
        private string _TenThanNhan;
        private string _MaQuanHe;
        private int _NamSinh;
        private string _ThongTinCaNhan;
        private string _MaNhanVien;

        public string MaNhanVien
        {
            get { return _MaNhanVien; }
            set { _MaNhanVien = value; }
        }

        public string ThongTinCaNhan
        {
            get { return _ThongTinCaNhan; }
            set { _ThongTinCaNhan = value; }
        }

        public int NamSinh
        {
            get { return _NamSinh; }
            set { _NamSinh = value; }
        }

        public string MaQuanHe
        {
            get { return _MaQuanHe; }
            set { _MaQuanHe = value; }
        }

        public string TenThanNhan
        {
            get { return _TenThanNhan; }
            set { _TenThanNhan = value; }
        }

        public int MaThanNhan
        {
            get { return _MaThanNhan; }
            set { _MaThanNhan = value; }
        }
    }
}
