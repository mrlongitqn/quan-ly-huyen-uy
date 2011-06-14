using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyHoSoCongChuc.Utils
{
    /// <summary>
    /// tuansl added: Enum is used to detemine update mode
    /// </summary>
    public enum EnumUpdateMode
    {
        DEFAULT,
        UPDATE,
        DELETE,
        INSERT,
        CHOOSING
    }

    /// <summary>
    /// tuansl added: Enum is used to determine which screen is showed
    /// </summary>
    public enum EnumChucNangHeThong
    {
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
        QUANLY_CHUCNANG_KETNOICSDL,
        QUANLY_CHUCNANG_KHENTHUONG,
        QUANLY_CHUCNANG_KYLUAT,
        QUANLY_CHUCNANG_LOAICANBO,
        QUANLY_CHUCNANG_LOAINGHIBHXH,
        QUANLY_CHUCNANG_LUONG,
        QUANLY_CHUCNANG_HETHONG,
        QUANLY_CHUCNANG_NGACHCONGCHUC,
        QUANLY_CHUCNANG_NHANVIEN,
        QUANLY_CHUCNANG_NHAPQUANHEGIADINH,
        QUANLY_CHUCNANG_QUANHE
    }

    /// <summary>
    /// tuansl added: used to determine canbo belong to which loaicanbo
    /// </summary>
    public enum EnumLoaiCanBoQuaCacThoiKi
    {
        CHUYEN_DONVI,
        BO_DONVI,
        TUTRAN,
        NOIKHAC_CHUYENDEN
    }
}
