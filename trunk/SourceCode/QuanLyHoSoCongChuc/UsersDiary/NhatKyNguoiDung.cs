using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using QuanLyHoSoCongChuc.Utils;

namespace QuanLyHoSoCongChuc.UsersDiary
{
    /// <summary>
    /// tuansl added: persistent class contain the number of using functionalities in app
    /// </summary>
    public class PerChucNangSuDung
    {
        public string TenChucNang { get; set; }
        public int SoLan { get; set; }

        public PerChucNangSuDung()
        {
            SoLan = 0;
        }
    }

    /// <summary>
    /// tuansl added: persistent class contain using infos of user
    /// </summary>
    public class PerNhatKyItem
    {
        public DateTime ThoiDiemVao { get; set; }
        public DateTime ThoiDiemRa { get; set; }
        public string TenMayTram { get; set; }
        public List<PerChucNangSuDung> LstChucNangSuDung { get; set; }
    }
    
}
