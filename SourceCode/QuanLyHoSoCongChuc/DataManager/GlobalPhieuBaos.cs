using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLyHoSoCongChuc.Models;
using System.Windows.Forms;
using QuanLyHoSoCongChuc.Repositories;

namespace QuanLyHoSoCongChuc.DataManager
{
    public class GlobalPhieuBaos
    {
        public static string CHUYEN_DONVI = "CHUYỂN ĐƠN VỊ";
        public static string BO_DONVI = "BỎ ĐƠN VỊ";
        public static string TUTRAN = "TỪ TRẦN";
        public static string NOIKHAC_CHUYENDEN = "NƠI KHÁC CHUYỂN ĐẾN";

        public static Dictionary<string, NhanVien> GetListNhanVienLoaded(ListView lstvNhanVien)
        {
            var dict = new Dictionary<string, NhanVien>();
            for (int i = 0; i < lstvNhanVien.Items.Count; i++)
            {
                dict.Add(((NhanVien)lstvNhanVien.Items[i].Tag).MaNhanVien, (NhanVien)lstvNhanVien.Items[i].Tag);
            }
            return dict;
        }

        public static Dictionary<string, NhanVien> GetListNhanVienChuyenDiLoaded(ListView lstvNhanVien)
        {
            var dict = new Dictionary<string, NhanVien>();
            for (int i = 0; i < lstvNhanVien.Items.Count; i++)
            {
                dict.Add(((NhanVien)lstvNhanVien.Items[i].Tag).MaNhanVien, (NhanVien)lstvNhanVien.Items[i].Tag);
            }
            return dict;
        }

        public static Dictionary<string, NhanVien> GetListOfNhanVienKhongConSinhHoat(string madonvi)
        {
            var dict = new Dictionary<string, NhanVien>();
            var lstvNhanVien = NhanVienRepository.SelectByMaDonVi(madonvi);
            for (int i = 0; i < lstvNhanVien.Count; i++)
            {
                if (!lstvNhanVien[i].ConSinhHoat.Value)
                {
                    dict.Add(lstvNhanVien[i].MaNhanVien, lstvNhanVien[i]);
                }
            }
            return dict;
        }
    }
}
