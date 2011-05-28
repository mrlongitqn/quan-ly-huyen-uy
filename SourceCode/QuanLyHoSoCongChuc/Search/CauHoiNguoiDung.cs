using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using QuanLyHoSoCongChuc.Utils;
using System.Data;

namespace QuanLyHoSoCongChuc.Search
{
    // Process search by different criticals
    public class DieuKienTimKiem
    {
        public QuanLyHoSoCongChuc.Utils.Attribute Attr { get; set; }
        public string Condition { get; set; }
        public string Value { get; set; }
        public string AndOr { get; set; }
    }

    /// <summary>
    /// Components of a condition
    /// </summary>
    public class DieuKienThanhPhan
    {
        public string ThuocTinhDieuKien { get; set; }
        public string Bien { get; set; }
        public string GiaTri { get; set; }
        public string DieuKien { get; set; }
    }
    /// <summary>
    /// Load and save user queries
    /// </summary>
    public class CauHoiNguoiDung
    {
        public string Bang { get; set; }
        public string TenCauHoi { get; set; }
        public List<DieuKienThanhPhan> LstDieuKien { get; set; }
        public DBProvider DBProvider { get; set; }

        /// <summary>
        /// Save user query
        /// </summary>
        /// <param name="pathFile"></param>
        /// <returns></returns>
        public bool SaveUserQuery(string pathFile)
        {
            // File nhat ky su dung does not exist, create new file
            if (!System.IO.File.Exists(pathFile))
            {
                if (CreateUserQuery(pathFile))
                {
                    return InsertUserQuery(pathFile);
                }
            }
            // Not exist -> add new record to nhat ky file
            return InsertUserQuery(pathFile);
        }

        /// <summary>
        /// Create new user query file
        /// </summary>
        /// <returns></returns>
        private bool CreateUserQuery(string pathFile)
        {
            try
            {
                //Create an xml document
                XmlDocument doc = new XmlDocument();

                //Create neccessary nodes
                XmlDeclaration declaration = doc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
                XmlComment comment = doc.CreateComment("This is an user queries file");
                XmlElement root = doc.CreateElement("danhsachcauhoi");

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
        /// Insert new user query
        /// </summary>
        /// <param name="pathFile"></param>
        /// <returns></returns>
        public bool InsertUserQuery(string pathFile)
        {
            try
            {
                //Create an xml document
                XmlDocument doc = new XmlDocument();
                doc.Load(pathFile);
                XmlElement root = doc.DocumentElement;

                // Create node nguoidung
                XmlElement cauhoi = doc.CreateElement("cauhoi");
                XmlAttribute tencauhoi = doc.CreateAttribute("tencauhoi");
                XmlAttribute bang = doc.CreateAttribute("bang");
                tencauhoi.Value = TenCauHoi;
                bang.Value = Bang;
                cauhoi.SetAttributeNode(tencauhoi);
                cauhoi.SetAttributeNode(bang);

                for (int i = 0; i < LstDieuKien.Count; i++)
                {
                    // Create thanhphanchuoicauhoi node
                    XmlElement thanhphanchuoicauhoi = doc.CreateElement("thanhphanchuoicauhoi");
                    XmlAttribute dieukienthanhphan = doc.CreateAttribute("dieukienthanhphan");
                    dieukienthanhphan.Value = LstDieuKien[i].ThuocTinhDieuKien;
                    thanhphanchuoicauhoi.SetAttributeNode(dieukienthanhphan);
                    cauhoi.AppendChild(thanhphanchuoicauhoi);

                    // Create childnodes for thanhphanchuoicauhoi
                    XmlElement bien = doc.CreateElement("bien");
                    XmlElement giatri = doc.CreateElement("giatri");
                    XmlElement dieukien = doc.CreateElement("dieukien");
                    bien.InnerText = LstDieuKien[i].Bien;
                    giatri.InnerText = LstDieuKien[i].GiaTri;
                    dieukien.InnerText = LstDieuKien[i].DieuKien == "<>" ? "!=" : LstDieuKien[i].DieuKien;
                    thanhphanchuoicauhoi.AppendChild(bien);
                    thanhphanchuoicauhoi.AppendChild(giatri);
                    thanhphanchuoicauhoi.AppendChild(dieukien);

                    cauhoi.AppendChild(thanhphanchuoicauhoi);
                }    

                // Append nguoi dung to root
                root.AppendChild(cauhoi);

                doc.Save(pathFile);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Checking name of new query is valid
        /// </summary>
        /// <param name="pathFile"></param>
        /// <param name="nameVerify"></param>
        /// <returns></returns>
        public bool CheckingNameQueyExist(string pathFile)
        {
            //Create an xml document
            XmlDocument doc = new XmlDocument();
            doc.Load(pathFile);
            return doc.SelectSingleNode("//cauhoi[@tencauhoi='" + TenCauHoi + "']") != null ? true : false;
        }

        /// <summary>
        /// Search by specified criterias
        /// </summary>
        /// <param name="sqlQuery"></param>
        /// <returns></returns>
        public DataSet SearchByCriterias(string sqlQuery)
        {
            // Create new connect to DB
            CreateConnection(GlobalVars.g_strTenMayTram, GlobalVars.g_strDataBaseName);

            var ds = new DataSet();
            DBProvider.SqlQuery = sqlQuery;
            DBProvider.FillDataSet(ref ds, Bang);

            return ds;
        }

        /// <summary>
        /// Create Connection
        /// </summary>
        /// <param name="dataSource"></param>
        /// <param name="dataBase"></param>
        public void CreateConnection(string dataSource, string dataBase)
        {
            DBProvider.InitDBProvider(dataSource, dataBase);
        }
    }
}
