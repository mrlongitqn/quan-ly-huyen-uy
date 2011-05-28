using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Models
{
    public class CanBoQuaCacThoiKiModel
    {
        public string MaDonVi { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool TinhTrang { get; set; }
        public string QueQuan { get; set; }
        public string NoiOHienNay { get; set; }
        public string ChucVuDaGiu { get; set; }
        public string CoQuanDaLamViec { get; set; }
        public DateTime NgayVaoDang { get; set; }
        public DateTime NgayChinhThuc { get; set; }
        public string DiDong { get; set; }
        public string MayBan { get; set; }
        public string DanhHieuDaDuocPhong { get; set; }
        public string QuaTrinhCongTac { get; set; }
        public string ThamGiaChinhTriXaHoi { get; set; }
    }

}