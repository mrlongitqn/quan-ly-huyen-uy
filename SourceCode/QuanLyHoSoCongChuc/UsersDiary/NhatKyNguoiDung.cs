using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuanLyHoSoCongChuc.UsersDiary
{
    /// <summary>
    /// Class contain the number of using functionalities in app
    /// </summary>
    public class ChucNangSuDung
    {
        public string TenChucNang { get; set; }
        public string SoLan { get; set; }
    }

    /// <summary>
    /// Class contain using infos of user
    /// </summary>
    public class NhatKySuDung
    {
        public DateTime ThoiDiemVao { get; set; }
        public DateTime ThoiDiemRa { get; set; }
        public string TenMayTram { get; set; }
        public List<ChucNangSuDung> LstChucNangSuDung { get; set; }
    }

    /// <summary>
    /// Class contain info of using app
    /// </summary>
    public class NhatKyNguoiDung
    {
        #region Variables
        public string TenTruyCap { get; set; }
        public List<NhatKySuDung> LstNhatkySuDung { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Save nhat ky for using
        /// </summary>
        /// <param name="pathFile"></param>
        /// <returns></returns>
        public bool SaveNhatKySuDung(string pathFile)
        {
            // File nhat ky su dung does not exist, create new file
            if (!System.IO.File.Exists(pathFile))
            {
                if (CreateNhatKyNguoiDung(pathFile))
                {
                    return InsertNhatKyNguoiDung(pathFile);
                }
            }
            // If user exist in diary file
            if (CheckingUserExist(pathFile))
            {
                return UpdateNhatKyNguoiDung(pathFile);
            }
            // Not exist -> add new record to nhat ky file
            return InsertNhatKyNguoiDung(pathFile);
        }

        public bool CheckingUserExist(string pathFile)
        {
            try
            {
                //Create an xml document
                XmlDocument doc = new XmlDocument();
                doc.Load(pathFile);
                if (doc.SelectSingleNode("//nguoidung[@tentruycap='" + TenTruyCap + "']") != null)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Create new nhat ky su dung file
        /// </summary>
        /// <returns></returns>
        private bool CreateNhatKyNguoiDung(string pathFile)
        {
            try
            {
                //Create an xml document
                XmlDocument doc = new XmlDocument();

                //Create neccessary nodes
                XmlDeclaration declaration = doc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
                XmlComment comment = doc.CreateComment("This is an user diary file");
                XmlElement root = doc.CreateElement("danhsachnguoidung");

                //Construct the document
                doc.AppendChild(declaration);
                doc.AppendChild(comment);
                doc.AppendChild(root);

                doc.Save(pathFile);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Insert new user diary
        /// </summary>
        /// <param name="pathFile"></param>
        /// <returns></returns>
        public bool InsertNhatKyNguoiDung(string pathFile)
        {
            try
            {
                //Create an xml document
                XmlDocument doc = new XmlDocument();
                doc.Load(pathFile);
                XmlElement root = doc.DocumentElement;

                // Create node nguoidung
                XmlElement nguoidung = doc.CreateElement("nguoidung");
                XmlAttribute tentruycap = doc.CreateAttribute("tentruycap");
                tentruycap.Value = TenTruyCap;
                nguoidung.SetAttributeNode(tentruycap);

                // Append nguoi dung to root
                root.AppendChild(nguoidung);

                XmlElement nhatky = doc.CreateElement("nhatky");
                XmlElement thoidiemvao = doc.CreateElement("thoidiemvao");
                XmlElement thoidiemra = doc.CreateElement("thoidiemra");
                XmlElement tenmaytram = doc.CreateElement("tenmaytram");
                XmlElement danhsachchucnangsudung = doc.CreateElement("danhsachchucnangsudung");

                thoidiemvao.InnerText = LstNhatkySuDung[0].ThoiDiemVao.ToString();
                thoidiemra.InnerText = LstNhatkySuDung[0].ThoiDiemRa.ToString();
                tenmaytram.InnerText = LstNhatkySuDung[0].TenMayTram;

                // Append info of using to nhat ky node
                nhatky.AppendChild(thoidiemvao);
                nhatky.AppendChild(thoidiemra);
                nhatky.AppendChild(tenmaytram);
                nhatky.AppendChild(danhsachchucnangsudung);

                // Append nhat ky su dung to nguoidung node
                nguoidung.AppendChild(nhatky);

                for (int i = 0; i < LstNhatkySuDung[0].LstChucNangSuDung.Count; i++)
                {
                    XmlElement chucnangsudung = doc.CreateElement("chucnangsudung");
                    XmlElement tenchucnang = doc.CreateElement("tenchucnang");
                    XmlElement solan = doc.CreateElement("solan");

                    tenchucnang.InnerText = LstNhatkySuDung[0].LstChucNangSuDung[i].TenChucNang;
                    solan.InnerText = LstNhatkySuDung[0].LstChucNangSuDung[i].SoLan;

                    chucnangsudung.AppendChild(tenchucnang);
                    chucnangsudung.AppendChild(solan);
                    danhsachchucnangsudung.AppendChild(chucnangsudung);
                }

                doc.Save(pathFile);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Update user diary
        /// </summary>
        /// <returns></returns>
        private bool UpdateNhatKyNguoiDung(string pathFile)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(pathFile);
                XmlNode node = doc.SelectSingleNode("//nguoidung[@tentruycap='" + TenTruyCap + "']");

                XmlElement nhatky = doc.CreateElement("nhatky");
                XmlElement thoidiemvao = doc.CreateElement("thoidiemvao");
                XmlElement thoidiemra = doc.CreateElement("thoidiemra");
                XmlElement tenmaytram = doc.CreateElement("tenmaytram");
                XmlElement danhsachchucnangsudung = doc.CreateElement("danhsachchucnangsudung");

                thoidiemvao.InnerText = LstNhatkySuDung[0].ThoiDiemVao.ToString();
                thoidiemra.InnerText = LstNhatkySuDung[0].ThoiDiemRa.ToString();
                tenmaytram.InnerText = LstNhatkySuDung[0].TenMayTram;

                // Append info of using to nhat ky node
                nhatky.AppendChild(thoidiemvao);
                nhatky.AppendChild(thoidiemra);
                nhatky.AppendChild(tenmaytram);
                nhatky.AppendChild(danhsachchucnangsudung);

                // Append nhat ky su dung to nguoidung node
                node.AppendChild(nhatky);

                for (int i = 0; i < LstNhatkySuDung[0].LstChucNangSuDung.Count; i++)
                {
                    XmlElement chucnangsudung = doc.CreateElement("chucnangsudung");
                    XmlElement tenchucnang = doc.CreateElement("tenchucnang");
                    XmlElement solan = doc.CreateElement("solan");

                    tenchucnang.InnerText = LstNhatkySuDung[0].LstChucNangSuDung[i].TenChucNang;
                    solan.InnerText = LstNhatkySuDung[0].LstChucNangSuDung[i].SoLan;

                    chucnangsudung.AppendChild(tenchucnang);
                    chucnangsudung.AppendChild(solan);
                    danhsachchucnangsudung.AppendChild(chucnangsudung);
                }

                doc.Save(pathFile);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }

    
}
