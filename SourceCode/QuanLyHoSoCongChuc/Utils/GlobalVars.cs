using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLyHoSoCongChuc.UsersDiary;
using QuanLyHoSoCongChuc.Search;
using System.Threading;

namespace QuanLyHoSoCongChuc.Utils
{
    /// <summary>
    /// Class is used to transfer data
    /// </summary>
    public class MyEvent : EventArgs
    {
        public string Data { get; set; }
        public MyEvent(string _data)
        {
            Data = _data;
        }
    }

    /// <summary>
    /// Class is used to transfer data loaded from file
    /// </summary>
    public class MyQueryEvent : EventArgs
    {
        public object Data { get; set; }
        public MyQueryEvent(object _data)
        {
            Data = _data;
        }
    }

    /// <summary>
    /// Enum is used to detemine update mode
    /// </summary>
    public enum EnumUpdateMode
    {
        UPDATE,
        DELETE,
        INSERT,
        CHOOSING
    }

    /// <summary>
    /// Enum is used to determine which screen is showed
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
    /// tuansl added: global variables
    /// </summary>
    public class GlobalVars
    {
        public static string g_strTenDangNhap = "qlhscc_admin";
        public static string g_strTenMayTram = "";
        public static string g_strPathNhatKi = "D:\\user_diary.xml";
        public static string g_strPathCauhoiTimKiem = "D:\\user_queries.xml";
        public static string g_strPathImages = "D:\\HuyenUyImages";
        public static EnumChucNangHeThong g_ChucNangSuDung;
        public static NhatKyNguoiDung g_NhatKyNguoiDung { get; set; }
        public static CauHoiNguoiDung g_CauHoiNguoiDung { get; set; }
        public static string g_strDataBaseName = "";
        public static FrmLoading waiting;
        private delegate void TimeTask();
        private static IAsyncResult result;
        private static TimeTask ASynInvoke;

        /// <summary>
        /// Retrieve name from enum
        /// </summary>
        /// <param name="chucnang"></param>
        /// <returns></returns>
        public static string RetrieveTenChucNang(EnumChucNangHeThong chucnang)
        {
            var tenchucnang = "";
            switch (chucnang)
            {
                case EnumChucNangHeThong.QUANLY_CHUCNANG_CHUCVU:
                    tenchucnang = "Quản lý chức vụ";
                    break;
                case EnumChucNangHeThong.QUANLY_CHUCNANG_CONGVIEC:
                    tenchucnang = "Quản lý công việc";
                    break;
                case EnumChucNangHeThong.QUANLY_CHUCNANG_DANHMUC:
                    tenchucnang = "Danh mục";
                    break;
                case EnumChucNangHeThong.QUANLY_CHUCNANG_DANHMUCHANHCHINH:
                    tenchucnang = "Danh mục hành chính";
                    break;
                case EnumChucNangHeThong.QUANLY_CHUCNANG_DANHSACHNANGLUONG:
                    tenchucnang = "Danh sách nâng lương";
                    break;
                case EnumChucNangHeThong.QUANLY_CHUCNANG_DANHSACHNHANVIEN:
                    tenchucnang = "Danh sách nhân viên";
                    break;
                case EnumChucNangHeThong.QUANLY_CHUCNANG_HETHONG:
                    tenchucnang = "Hệ thống";
                    break;
            }
            return tenchucnang;
        }

        /// <summary>
        /// Update chuc nang su dung
        /// </summary>
        /// <param name="chucnang"></param>
        public static void UpdateChucNangSuDung(EnumChucNangHeThong chucnang)
        {
            var tenchucnang = GlobalVars.RetrieveTenChucNang(chucnang);
            ChucNangSuDung refChucNang = null;
            if (CheckingItemIsExist(tenchucnang, ref refChucNang))
            {
                refChucNang.SoLan++;
            }
            else
            {
                var item = new ChucNangSuDung
                {
                    TenChucNang = tenchucnang,
                    SoLan = 1
                };
                g_NhatKyNguoiDung.LstNhatkySuDung[0].LstChucNangSuDung.Add(item);
            }
        }

        /// <summary>
        /// Checking item is exist in list
        /// </summary>
        /// <param name="tenchucnang"></param>
        /// <param name="refChucNang"></param>
        /// <returns></returns>
        public static bool CheckingItemIsExist(string tenchucnang, ref ChucNangSuDung refChucNang)
        {
            for (int i = 0; i < g_NhatKyNguoiDung.LstNhatkySuDung[0].LstChucNangSuDung.Count; i++)
            {
                if (g_NhatKyNguoiDung.LstNhatkySuDung[0].LstChucNangSuDung[i].TenChucNang == tenchucnang)
                {
                    refChucNang = g_NhatKyNguoiDung.LstNhatkySuDung[0].LstChucNangSuDung[i];
                    return true;
                }
            }
            return false;
        }

        public static void PreLoading()
        {
            ASynInvoke = new TimeTask(WaitLoad);
            result = ASynInvoke.BeginInvoke(null, null);
        }

        public static void PosLoading()
        {
            if (waiting != null)
            {
                waiting.Close();
                waiting = null;
            }
        }   

        public static void WaitLoad()
        {
            waiting = new FrmLoading("Đang thực hiện");
            waiting.ShowDialog();
            Thread.Sleep(500);
        }
    }
}
