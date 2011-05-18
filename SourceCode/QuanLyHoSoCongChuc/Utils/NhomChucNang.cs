using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuanLyHoSoCongChuc.Utils
{
    public class NhomChucNang
    {
        public static List<string> DanhSachChucNang { get; set; }
        public static List<ChucNang> DanhSachNhomChucNang { get; set; }

        public static bool LoadDanhSachChucNang(string xmlPath)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlPath);

                var lstNode = doc.GetElementsByTagName("tenchucnang");
                if (lstNode != null)
                {
                    DanhSachChucNang = new List<string>();
                    for (int i = 0; i < lstNode.Count; i++)
                    {
                        DanhSachChucNang.Add(lstNode[i].InnerText);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool LoadDanhSachChucNangBelongToNguoiDung(string xmlPath)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlPath);

                var lstNode = doc.GetElementsByTagName("loainguoidung");
                if (lstNode != null)
                {
                    DanhSachNhomChucNang = new List<ChucNang>();
                    for (int i = 0; i < lstNode.Count; i++)
                    {
                        var childNodeList = lstNode[i].ChildNodes;
                        for (int j = 0; j < childNodeList.Count; j++)
                        {
                            var chucnang = new ChucNang
                            {
                                LoaiNguoiDung = lstNode[i].Attributes["id"].Value,
                                TenChucNang = childNodeList[j].InnerText
                            };
                            DanhSachNhomChucNang.Add(chucnang);
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<ChucNang> LoadDanhSachChucNangByLoaiNguoiDung(string tenloainguoidung)
        {
            var lst = new List<ChucNang>();
            try
            {

                return lst;
            }
            catch
            {
                return null;
            }
        }
    }

    public class ChucNang
    {
        public string LoaiNguoiDung { get; set; }
        public string TenChucNang { get; set; }
    }
}
