using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuanLyHoSoCongChuc.Search
{
    public class DanhSachCauHoiNguoiDung
    {
        public List<CauHoiNguoiDung> LstCauHoiNguoiDung { get; set; }

        /// <summary>
        /// Load user queries
        /// </summary>
        /// <param name="pathFile"></param>
        /// <returns></returns>
        public bool LoadUserQueries(string pathFile)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(pathFile);

                XmlNodeList lstquery = doc.GetElementsByTagName("cauhoi");
                if (lstquery != null)
                {
                    LstCauHoiNguoiDung = new List<CauHoiNguoiDung>();
                    for (int i = 0; i < lstquery.Count; i++)
                    {
                        var query = new CauHoiNguoiDung
                        {
                            TenCauHoi = lstquery[i].Attributes["tencauhoi"].Value,
                            Bang = lstquery[i].Attributes["bang"].Value,
                            MaDonVi = lstquery[i].Attributes["madonvi"].Value,
                            LstDieuKien = LoadDieuKienThanhPhan(lstquery[i])
                        };
                        LstCauHoiNguoiDung.Add(query);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<DieuKienThanhPhan> LoadDieuKienThanhPhan(XmlNode cauhoi)
        {
            var lst = new List<DieuKienThanhPhan>();
            var lstDieuKienThanhPhan = cauhoi.ChildNodes;
            for (int i = 0; i < lstDieuKienThanhPhan.Count; i++)
            {
                var dieukien = new DieuKienThanhPhan
                {
                    ThuocTinhDieuKien = lstDieuKienThanhPhan[i].Attributes["dieukienthanhphan"].Value,
                    Bien = lstDieuKienThanhPhan[i].ChildNodes[0].InnerText,
                    GiaTri = lstDieuKienThanhPhan[i].ChildNodes[1].InnerText,
                    DieuKien = lstDieuKienThanhPhan[i].ChildNodes[2].InnerText == "!=" ? "<>" : lstDieuKienThanhPhan[i].ChildNodes[2].InnerText
                };
                lst.Add(dieukien);
            }
            return lst;
        }

        /// <summary>
        /// Remove cau hoi
        /// </summary>
        /// <param name="pathFile"></param>
        /// <param name="RemovedName"></param>
        /// <returns></returns>
        public bool RemoveCauHoi(string pathFile, string RemovedName)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(pathFile);
                XmlNode node = doc.SelectSingleNode("//cauhoi[@tencauhoi='" + RemovedName + "']");
                if (node != null)
                {
                    doc.DocumentElement.RemoveChild(node);
                    doc.Save(pathFile);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
