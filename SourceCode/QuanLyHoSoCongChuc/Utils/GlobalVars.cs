using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyHoSoCongChuc.Utils
{
    #region Using
    using QuanLyHoSoCongChuc.UsersDiary;
    using QuanLyHoSoCongChuc.Search;
    using System.Threading;
    using QuanLyHoSoCongChuc.Models;
    #endregion
    /// <summary>
    /// tuansl added: global variables
    /// </summary>
    public class GlobalVars
    {
        private delegate void TimeTask();
        private static IAsyncResult result;
        private static TimeTask ASynInvoke;
        public static FrmLoading waiting;

        public static string g_strTenMayTram = "";
        public static string g_strPathCauhoiTimKiem;
        public static CauHoiNguoiDung g_CauHoiNguoiDung { get; set; }
        public static string g_strDataBaseName = "";

        public static NguoiDung g_CurrentUser { get; set; }
        public static PerNhatKyItem g_PerNhatKyItem { get; set; }

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
                // BAO CAO
                case EnumChucNangHeThong.QUANLY_CHUCNANG_BAOCAO_LUONG:
                    tenchucnang = "BC lương";
                    break;
                case EnumChucNangHeThong.QUANLY_CHUCNANG_BAOCAO_DSCBCCVC:
                    tenchucnang = "BC danh sách CB-CC-VC";
                    break;
                case EnumChucNangHeThong.QUANLY_CHUCNANG_BAOCAO_DSNANGLUONG:
                    tenchucnang = "BC danh sách nâng lương";
                    break;
                case EnumChucNangHeThong.QUANLY_CHUCNANG_BAOCAO_DSNGHIHUU:
                    tenchucnang = "BC danh sách nghỉ hưu";
                    break;
                case EnumChucNangHeThong.QUANLY_CHUCNANG_BAOCAO_DSPHUCAPVUOTKHUNG:
                    tenchucnang = "BC danh sách PC vượt khung";
                    break;

                // CB QUA CAC THOI KY
                case EnumChucNangHeThong.QUANLY_CHUCNANG_DSCANBOQUACACTHOIKI:
                    tenchucnang = "Cán bộ qua các thời kì";
                    break;
                case EnumChucNangHeThong.QUANLY_CHUCNANG_TIMKIEMCB:
                    tenchucnang = "Tìm kiếm cán bộ";
                    break;
                case EnumChucNangHeThong.QUANLY_CHUCNANG_INDSCB:
                    tenchucnang = "In danh sách cán bộ";
                    break;

                // DANH MUC
                case EnumChucNangHeThong.QUANLY_CHUCNANG_DANHMUCDONVI:
                    tenchucnang = "Danh mục đơn vị";
                    break;
                case EnumChucNangHeThong.QUANLY_CHUCNANG_DANHMUCHANHCHINH:
                    tenchucnang = "Danh mục hành chính";
                    break;

                // DU LIEU
                case EnumChucNangHeThong.QUANLY_CHUCNANG_PHIEUBAO_CHUYENNGACH:
                    tenchucnang = "Phiếu báo chuyển ngạch";
                    break;
                case EnumChucNangHeThong.QUANLY_CHUCNANG_PHIEUBAO_PHUCAP:
                    tenchucnang = "Phiếu báo phụ cấp";
                    break;
                case EnumChucNangHeThong.QUANLY_CHUCNANG_PHIEUBAO_CHUYENDV:
                    tenchucnang = "Phiếu báo chuyển đơn vị";
                    break;
                case EnumChucNangHeThong.QUANLY_CHUCNANG_PHIEUBAO_BODV:
                    tenchucnang = "Phiếu báo bỏ đơn vị";
                    break;
                case EnumChucNangHeThong.QUANLY_CHUCNANG_PHIEUBAO_TUTRAN:
                    tenchucnang = "Phiếu báo từ trần";
                    break;

                // HO SO NHAN VIEN
                case EnumChucNangHeThong.QUANLY_CHUCNANG_HOSONHANVIEN:
                    tenchucnang = "Hồ sơ nhân viên";
                    break;
                case EnumChucNangHeThong.QUANLY_CHUCNANG_TIMKIEMNHANVIEN:
                    tenchucnang = "Tìm kiếm nhân viên";
                    break;
                case EnumChucNangHeThong.QUANLY_CHUCNANG_MOCAUHOITIMKIEM:
                    tenchucnang = "Mở câu hỏi tìm kiếm";
                    break;

                // SAO LUU - KHOI PHUC DU LIEU
                case EnumChucNangHeThong.QUANLY_CHUCNANG_SAOLUUDULIEU:
                    tenchucnang = "Sao lưu dữ liệu";
                    break;
                case EnumChucNangHeThong.QUANLY_CHUCNANG_KHOIPHUCDULIEU:
                    tenchucnang = "Khôi phục dữ liệu";
                    break;
                case EnumChucNangHeThong.QUANLY_CHUCNANG_NHATKISUDUNGHETHONG:
                    tenchucnang = "Nhật ký sử dụng hệ thống";
                    break;

                case EnumChucNangHeThong.QUANLY_CHUCNANG_QUANTRINGUOIDUNG:
                    tenchucnang = "Quản trị người dùng";
                    break;
                case EnumChucNangHeThong.QUANLY_CHUCNANG_THAYDOIMATKHAU:
                    tenchucnang = "Thay đổi mật khẩu";
                    break;
            }
            return tenchucnang;
        }

        public static EnumChucNangHeThong RetrieveFuncsNotAllowUsing(string tenchucnang)
        {
            EnumChucNangHeThong func = EnumChucNangHeThong.QUANLY_CHUCNANG_BAOCAO_LUONG;
            if (tenchucnang == "BC lương")
            {
                func = EnumChucNangHeThong.QUANLY_CHUCNANG_BAOCAO_LUONG;
            }
            else if (tenchucnang == "BC danh sách CB-CC-VC")
            {
                func = EnumChucNangHeThong.QUANLY_CHUCNANG_BAOCAO_DSCBCCVC;
            }
            else if (tenchucnang == "BC danh sách nâng lương")
            {
                func = EnumChucNangHeThong.QUANLY_CHUCNANG_BAOCAO_DSNANGLUONG;
            }
            else if (tenchucnang == "BC danh sách nghỉ hưu")
            {
                func = EnumChucNangHeThong.QUANLY_CHUCNANG_BAOCAO_DSNGHIHUU;
            }
            else if (tenchucnang == "BC danh sách PC vượt khung")
            {
                func = EnumChucNangHeThong.QUANLY_CHUCNANG_BAOCAO_DSPHUCAPVUOTKHUNG;
            }
            else if (tenchucnang == "Cán bộ qua các thời kì")
            {
                func = EnumChucNangHeThong.QUANLY_CHUCNANG_DSCANBOQUACACTHOIKI;
            }
            else if (tenchucnang == "Tìm kiếm cán bộ")
            {
                func = EnumChucNangHeThong.QUANLY_CHUCNANG_TIMKIEMCB;
            }
            else if (tenchucnang == "In danh sách cán bộ")
            {
                func = EnumChucNangHeThong.QUANLY_CHUCNANG_INDSCB;
            }
            else if (tenchucnang == "Danh mục đơn vị")
            {
                func = EnumChucNangHeThong.QUANLY_CHUCNANG_DANHMUCDONVI;
            }
            else if (tenchucnang == "Danh mục hành chính")
            {
                func = EnumChucNangHeThong.QUANLY_CHUCNANG_DANHMUCHANHCHINH;
            }
            else if (tenchucnang == "Phiếu báo chuyển ngạch")
            {
                func = EnumChucNangHeThong.QUANLY_CHUCNANG_PHIEUBAO_CHUYENNGACH;
            }
            else if (tenchucnang == "Phiếu báo phụ cấp")
            {
                func = EnumChucNangHeThong.QUANLY_CHUCNANG_PHIEUBAO_PHUCAP;
            }
            else if (tenchucnang == "Phiếu báo chuyển đơn vị")
            {
                func = EnumChucNangHeThong.QUANLY_CHUCNANG_PHIEUBAO_CHUYENDV;
            }
            else if (tenchucnang == "Phiếu báo bỏ đơn vị")
            {
                func = EnumChucNangHeThong.QUANLY_CHUCNANG_PHIEUBAO_BODV;
            }
            else if (tenchucnang == "Phiếu báo từ trần")
            {
                func = EnumChucNangHeThong.QUANLY_CHUCNANG_PHIEUBAO_TUTRAN;
            }
            else if (tenchucnang == "Hồ sơ nhân viên")
            {
                func = EnumChucNangHeThong.QUANLY_CHUCNANG_HOSONHANVIEN;
            }
            else if (tenchucnang == "Tìm kiếm nhân viên")
            {
                func = EnumChucNangHeThong.QUANLY_CHUCNANG_TIMKIEMNHANVIEN;
            }
            else if (tenchucnang == "Mở câu hỏi tìm kiếm")
            {
                func = EnumChucNangHeThong.QUANLY_CHUCNANG_MOCAUHOITIMKIEM;
            }
            else if (tenchucnang == "Sao lưu dữ liệu")
            {
                func = EnumChucNangHeThong.QUANLY_CHUCNANG_SAOLUUDULIEU;
            }
            else if (tenchucnang == "Khôi phục dữ liệu")
            {
                func = EnumChucNangHeThong.QUANLY_CHUCNANG_KHOIPHUCDULIEU;
            }
            else if (tenchucnang == "Nhật ký sử dụng hệ thống")
            {
                func = EnumChucNangHeThong.QUANLY_CHUCNANG_NHATKISUDUNGHETHONG;
            }
            else if (tenchucnang == "Quản trị người dùng")
            {
                func = EnumChucNangHeThong.QUANLY_CHUCNANG_QUANTRINGUOIDUNG;
            }
            else if (tenchucnang == "Thay đổi mật khẩu")
            {
                func = EnumChucNangHeThong.QUANLY_CHUCNANG_THAYDOIMATKHAU;
            }
            return func;
        }

        /// <summary>
        /// Update chuc nang su dung
        /// </summary>
        /// <param name="chucnang"></param>
        public static void UpdateChucNangSuDung(EnumChucNangHeThong chucnang)
        {
            var tenchucnang = GlobalVars.RetrieveTenChucNang(chucnang);
            PerChucNangSuDung refChucNang = null;
            if (CheckingItemIsExist(tenchucnang, ref refChucNang))
            {
                refChucNang.SoLan++;
            }
            else
            {
                var item = new PerChucNangSuDung
                {
                    TenChucNang = tenchucnang,
                    SoLan = 1
                };
                g_PerNhatKyItem.LstChucNangSuDung.Add(item);
            }
        }

        /// <summary>
        /// Checking item is exist in list
        /// </summary>
        /// <param name="tenchucnang"></param>
        /// <param name="refChucNang"></param>
        /// <returns></returns>
        public static bool CheckingItemIsExist(string tenchucnang, ref PerChucNangSuDung refChucNang)
        {
            for (int i = 0; i < g_PerNhatKyItem.LstChucNangSuDung.Count; i++)
            {
                if (g_PerNhatKyItem.LstChucNangSuDung[i].TenChucNang.ToUpper() == tenchucnang.ToUpper())
                {
                    refChucNang = g_PerNhatKyItem.LstChucNangSuDung[i];
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
        }
    }
}
