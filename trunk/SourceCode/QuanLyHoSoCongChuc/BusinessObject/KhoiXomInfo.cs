using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyHoSoCongChuc.BusinessObject
{
    public class KhoiXomInfo
    {
        private string _MaKhoiXom;
        private string _TenKhoiXom;
        private string _MaPhuongXa;
        
        public string MaKhoiXom
        {
            get { return _MaKhoiXom; }
            set { _MaKhoiXom = value; }
        }
        

        public string TenKhoiXom
        {
            get { return _TenKhoiXom; }
            set { _TenKhoiXom = value; }
        }
        

        public string MaPhuongXa
        {
            get { return _MaPhuongXa; }
            set { _MaPhuongXa = value; }
        }


        public KhoiXomInfo()
        {
        }
    }
}
