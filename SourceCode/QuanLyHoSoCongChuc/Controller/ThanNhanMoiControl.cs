using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using QuanLyHoSoCongChuc.DataLayer;
using QuanLyHoSoCongChuc.BusinessObject;

namespace QuanLyHoSoCongChuc.Controller
{
    public class ThanNhanMoiControl
    {
        ThanNhanMoiData m_ThanNhanMoiData = new ThanNhanMoiData();
        public DataTable LayDanhSachThanNhan(string MaNhanVien)
        {
            DataTable dt = m_ThanNhanMoiData.LayDanhSachThanNhan(MaNhanVien);
            return dt;
        }

        public void ThemThanNhan(ThanNhanMoiInfo tn)
        {
            m_ThanNhanMoiData.ThemThanNhan(tn);
        }

        public void HienThiDanhSachThanNhan(DataGridView dgv, string MaNhanVien)
        {
            DataTable dt = LayDanhSachThanNhan(MaNhanVien);
            dgv.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                Object[] obj = new Object[4];
                obj[0] = row["STT"];
                obj[1] = row["TenQuanHe"];
                obj[2] = row["TenThanNhan"];
                obj[3] = row["MaThanNhan"];
                dgv.Rows.Add(obj);
            }
        }

        public void HienThiDanhSachThanNhanDayDu(DataGridView dgv, string MaNhanVien)
        {
            DataTable dt = LayDanhSachThanNhan(MaNhanVien);
            dgv.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                Object[] obj = new Object[5];
                obj[0] = row["STT"];
                obj[1] = row["TenQuanHe"];
                obj[2] = row["TenThanNhan"];
                obj[3] = row["NamSinh"];
                obj[4] = row["ThongTinCaNhan"];
                dgv.Rows.Add(obj);
            }
        }



        public void XoaThanNhan(int MaThanNhan)
        {
            m_ThanNhanMoiData.XoaThanNhan(MaThanNhan);
        }


        public ThanNhanMoiInfo LayThongTinThanNhan(int MaThanNhan)
        {
            return m_ThanNhanMoiData.LayThongTinThanNhan(MaThanNhan);
        }

        public void CapNhatThanNhan(ThanNhanMoiInfo tn)
        {
            m_ThanNhanMoiData.CapNhatThanNhan(tn);
        }
    }
}
