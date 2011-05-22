using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLyHoSoCongChuc.UserDiary;

namespace QuanLyHoSoCongChuc.Utils
{
    /// <summary>
    /// Enum is used to detemine update mode
    /// </summary>
    public enum EnumUpdateMode
    {
        UPDATE,
        DELETE,
        INSERT
    }

    /// <summary>
    /// Enum is used to determine which screen is showed
    /// </summary>
    public enum EnumChucNangHeThong
    {
        QUANLY_CHUCNANG_CHUCNANGKHENTHUONG,
        QUANLY_CHUCNANG_KYLUAT,
        QUANLY_CHUCNANG_QTBD,
        QUANLY_CHUCNANG_QTCT,
        QUANLY_CHUCNANG_QTCTMOI,
        QUANLY_CHUCNANG_THANNHAN,
        QUANLY_CHUCNANG_CHUCVU,
        QUANLY_CHUCNANG_CONGVIEC,
        QUANLY_CHUCNANG_DANHMUC,
        QUANLY_CHUCNANG_DANHMUCHANHCHINH,
        QUANLY_CHUCNANG_DANHSACHNANGLUONG,
        QUANLY_CHUCNANG_DANHSACHNHANVIEN,
        QUANLY_CHUCNANG_DANTOC,
        QUANLY_CHUCNANG_DIENUUTIENBANTHAN,
        QUANLY_CHUCNANG_DIENUUTIENGIADINH,
        QUANLY_CHUCNANG_DOIMATKHAU,
        QUANLY_CHUCNANG_DONVI,
        QUANLY_CHUCNANG_GIADINH,
        QUANLY_CHUCNANG_HINHTHUCTUYENDUNG,
        QUANLY_CHUCNANG_KHENTHUONG
    }

    public class GlobalVars
    {
        public static string g_strTenDangNhap = "qlhscc_admin";
        public static string g_strTenMayTram = "";
        public static NhatKyNguoiDung g_NhatKySuDung { get; set; }
    }
}
