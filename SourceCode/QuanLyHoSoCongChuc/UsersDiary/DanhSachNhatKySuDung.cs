using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuanLyHoSoCongChuc.UsersDiary
{
    /// <summary>
    /// Class contain using diary for all of user
    /// </summary>
    public class DanhSachNhatKySuDung
    {
        public List<NhatKyNguoiDung> LstNhatKyNguoiDung { get; set; }

        /// <summary>
        /// Load diary of users
        /// </summary>
        /// <param name="pathFile"></param>
        /// <returns></returns>
        public bool LoadDiary(string pathFile)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(pathFile);

                XmlNodeList lstnguoidung = doc.GetElementsByTagName("nguoidung");
                if (lstnguoidung != null)
                {
                    LstNhatKyNguoiDung = new List<NhatKyNguoiDung>();
                    for (int i = 0; i < lstnguoidung.Count; i++)
                    {
                        LstNhatKyNguoiDung.Add(LoadNhatKyNguoiDung(lstnguoidung[i]));
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Load nguoidung node
        /// </summary>
        /// <param name="nguoidung"></param>
        /// <returns></returns>
        public NhatKyNguoiDung LoadNhatKyNguoiDung(XmlNode nguoidung)
        {
            var nhatkynguoidung = new NhatKyNguoiDung
            {
                TenTruyCap = nguoidung.Attributes["tentruycap"].Value,
                LstNhatkySuDung = new List<NhatKySuDung>()
            };
            // Get list of diary for specified user
            XmlNodeList lstnhatky = nguoidung.ChildNodes;
            for (int i = 0; i < lstnhatky.Count; i++)
            {
                nhatkynguoidung.LstNhatkySuDung.Add(LoadNhatKySuDung(lstnhatky[i]));

            }
            return nhatkynguoidung;
        }

        /// <summary>
        /// Load nhatky node
        /// </summary>
        /// <param name="nhatky"></param>
        /// <returns></returns>
        public NhatKySuDung LoadNhatKySuDung(XmlNode nhatky)
        {
            var nhatkysudung = new NhatKySuDung()
            {
                ThoiDiemVao = DateTime.Parse(nhatky.ChildNodes[0].InnerText),
                ThoiDiemRa = DateTime.Parse(nhatky.ChildNodes[1].InnerText),
                TenMayTram = nhatky.ChildNodes[2].InnerText,
                LstChucNangSuDung = new List<ChucNangSuDung>()
            };
            XmlNodeList lstDanhSachChucNang = nhatky.ChildNodes[3].ChildNodes;
            for (int i = 0; i < lstDanhSachChucNang.Count; i++)
            {
                var chucnang = new ChucNangSuDung
                {
                    TenChucNang = lstDanhSachChucNang[i].ChildNodes[0].InnerText,
                    SoLan = lstDanhSachChucNang[i].ChildNodes[1].InnerText
                };
                nhatkysudung.LstChucNangSuDung.Add(chucnang);
            }
            return nhatkysudung;
        }
    }
}
