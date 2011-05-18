using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyHoSoCongChuc.UserDiary
{
    public class NhatKyNguoiDung
    {
        public static string TenNguoiDung { get; set; }
        public static DateTime ThoiDiemVao { get; set; }
        public static DateTime ThoiDiemRa { get; set; }
        public static string TenMayTram { get; set; }
        public static List<ChucNangSuDung> LstChucNangSuDung { get; set; }

        private class ChucNangSuDung
        {
            public string TenChucNang { get; set; }
            public string SoLan { get; set; }
        }
    }
}
