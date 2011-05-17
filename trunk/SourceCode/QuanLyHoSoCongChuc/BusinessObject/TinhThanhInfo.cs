using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyHoSoCongChuc.BusinessObject
{
    public class TinhThanhInfo
    {
        private string _MaTinh;
        private string _TenTinh;

        public string MaTinh
        {
            get { return _MaTinh; }
            set { _MaTinh = value; }
        } 
       
        public string TenTinh
        {
            get { return _TenTinh; }
            set { _TenTinh = value; }
        }

        public TinhThanhInfo()
        {
        }
    }
}
