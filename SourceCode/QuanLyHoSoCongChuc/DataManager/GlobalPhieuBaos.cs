using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLyHoSoCongChuc.Models;
using System.Windows.Forms;

namespace QuanLyHoSoCongChuc.DataManager
{
    class GlobalPhieuBaos
    {
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
                //dict.Add(((ChuyenDonVi)lstvNhanVien.Items[i].Tag).MaNhanVien, ((ChuyenDonVi)lstvNhanVien.Items[i].Tag).NhanVien);
            }
            return dict;
        }
    }
}
