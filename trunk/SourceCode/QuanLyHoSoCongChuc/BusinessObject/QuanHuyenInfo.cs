using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyHoSoCongChuc.BusinessObject
{
    public class QuanHuyenInfo
    {
        private string _MaQuanHuyen;
        private string _TenQuanHuyen;
        private string _MaTinh;

        public string MaQuanHuyen
        {
            get { return _MaQuanHuyen; }
            set { _MaQuanHuyen = value; }
        }
        

        public string TenQuanHuyen
        {
            get { return _TenQuanHuyen; }
            set { _TenQuanHuyen = value; }
        }
        

        public string MaTinh
        {
            get { return _MaTinh; }
            set { _MaTinh = value; }
        }


        public QuanHuyenInfo()
        {
        }
    }
}
