using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyHoSoCongChuc.BusinessObject
{
    public class PhuongXaInfo
    {
        private string _MaPhuongXa;
        private string _TenPhuongXa;
        private string _MaQuanHuyen;

        public string MaPhuongXa
        {
            get { return _MaPhuongXa; }
            set { _MaPhuongXa = value; }
        }
        
        public string TenPhuongXa
        {
            get { return _TenPhuongXa; }
            set { _TenPhuongXa = value; }
        }
        
        public string MaQuanHuyen
        {
            get { return _MaQuanHuyen; }
            set { _MaQuanHuyen = value; }
        }

        public PhuongXaInfo()
        {
        }
    }
}
