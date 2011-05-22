using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyHoSoCongChuc.UserDiary
{
    public class ChucNangSuDung
    {
        public string TenChucNang { get; set; }
        public string SoLan { get; set; }
    }

    public class NhatKyNguoiDung
    {
        public string TenTruyCap { get; set; }
        public DateTime ThoiDiemVao { get; set; }
        public DateTime ThoiDiemRa { get; set; }
        public string TenMayTram { get; set; }
        public List<ChucNangSuDung> LstChucNangSuDung { get; set; }
    }
}
