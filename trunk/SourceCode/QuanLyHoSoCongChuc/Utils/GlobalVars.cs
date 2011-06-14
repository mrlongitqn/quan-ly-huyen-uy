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
            //ASynInvoke = new TimeTask(WaitLoad);
            //result = ASynInvoke.BeginInvoke(null, null);
        }

        public static void PosLoading()
        {
            //if (waiting != null)
            //{
            //    waiting.Close();
            //}
        }   

        public static void WaitLoad()
        {
            waiting = new FrmLoading("Đang thực hiện");
            waiting.Handler += CompleteWaiting;
            waiting.ShowDialog();
        }

        private static void CompleteWaiting(object sender, EventArgs e)
        {
            waiting = null;
        }
    }
}
