using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyHoSoCongChuc.Models
{
    public class NhanVienModel
    {
        public string MaDonVi { get; set; }
        public int MaDanToc { get; set; }
        public int MaTonGiao { get; set; }
        public int MaThanhPhanGiaDinh { get; set; }
        public int MaNgheNghiepTruocKhiDuocTuyenDung { get; set; }
        public int MaBangGiaoDucPhoThong { get; set; }
        public int MaBangChuyenMonNghiepVu { get; set; }
        public int MaBangLyLuanChinhTri { get; set; }
        public int MaBangNgoaiNgu { get; set; }
        public int MaHocVi { get; set; }
        public int MaHocHam { get; set; }
        public int MaTinhTrangSucKhoe { get; set; }
        public int MaThuongBinh { get; set; }
        public string HinhAnh { get; set; }
        public string HoTenKhaiSinh { get; set; }
        public string HoTenDangDung { get; set; }
        public DateTime NgaySinh { get; set; }
        public string NoiSinh { get; set; }
        public string QueQuan { get; set; }
        public string HoKhau { get; set; }
        public string TamTru { get; set; }
        public string CongViecChinh { get; set; }
        public DateTime NgayVaoDang { get; set; }
        public string VaoDangTaiChiBo { get; set; }
        public string NguoiGioiThieu1 { get; set; }
        public string ChucVuNguoi1 { get; set; }
        public string NguoiGioiThieu2 { get; set; }
        public string ChucVuNguoi2 { get; set; }
        public DateTime NgayChinhThuc { get; set; }
        public string ChinhThucTaiChiBo { get; set; }
        public DateTime NgayTuyenDung { get; set; }
        public string CoQuanTuyenDung { get; set; }
        public DateTime NgayVaoDoan { get; set; }
        public string ChiDoan { get; set; }
        public string ThamGiaCTXH { get; set; }
        public DateTime NgayNhapNgu { get; set; }
        public DateTime NgayXuatNgu { get; set; }
        public bool GiaDinhLietSy { get; set; }
        public bool GiaDinhCoCongVoiCM { get; set; }
        public string SoCMND { get; set; }
        public DateTime NgayMienSHD { get; set; }
        public bool ConSinhHoat { get; set; }

        // tuansl: add manually
        public int TuoiDoi { get; set; }
        public int TuoiDang { get; set; }
        // ---------------- E ------------------
    }
}
