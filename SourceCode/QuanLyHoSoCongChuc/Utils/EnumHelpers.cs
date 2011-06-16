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
        // BAO CAO
        QUANLY_CHUCNANG_BAOCAO_LUONG,
        QUANLY_CHUCNANG_BAOCAO_DSCBCCVC,
        QUANLY_CHUCNANG_BAOCAO_DSNANGLUONG,
        QUANLY_CHUCNANG_BAOCAO_DSNGHIHUU,
        QUANLY_CHUCNANG_BAOCAO_DSPHUCAPVUOTKHUNG,

        // CB QUA CAC THOI KY
        QUANLY_CHUCNANG_DSCANBOQUACACTHOIKI,
        QUANLY_CHUCNANG_TIMKIEMCB,
        QUANLY_CHUCNANG_INDSCB,

        // DANH MUC
        QUANLY_CHUCNANG_DANHMUCDONVI,
        QUANLY_CHUCNANG_DANHMUCHANHCHINH,

        // DU LIEU
        QUANLY_CHUCNANG_PHIEUBAO_CHUYENNGACH,
        QUANLY_CHUCNANG_PHIEUBAO_PHUCAP,
        QUANLY_CHUCNANG_PHIEUBAO_CHUYENDV,
        QUANLY_CHUCNANG_PHIEUBAO_BODV,
        QUANLY_CHUCNANG_PHIEUBAO_TUTRAN,

        // NHAN VIEN
        QUANLY_CHUCNANG_HOSONHANVIEN,
        QUANLY_CHUCNANG_TIMKIEMNHANVIEN,
        QUANLY_CHUCNANG_MOCAUHOITIMKIEM,

        // SAO LUU - KHOI PHUC DU LIEU
        QUANLY_CHUCNANG_KHOIPHUCDULIEU,
        QUANLY_CHUCNANG_SAOLUUDULIEU,
        QUANLY_CHUCNANG_NHATKISUDUNGHETHONG,

        QUANLY_CHUCNANG_QUANTRINGUOIDUNG,
        QUANLY_CHUCNANG_THAYDOIMATKHAU,
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
