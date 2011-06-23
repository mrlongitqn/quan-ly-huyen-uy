using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuanLyHoSoCongChuc.Utils
{
    public class XMLProvider
    {
        public void GetConnectionInfo(ref string ErrorText)
        {
            ErrorText = "";

            XmlDocument xmlDoc = XMLReader(GlobalVars.g_strPathConfig, ref ErrorText);

            if (ErrorText != "")
            {
                return;
            }

            XmlElement xmlEle = xmlDoc.DocumentElement;

            GlobalVars.g_strDataSource = xmlEle.SelectSingleNode("servname").InnerText;
            GlobalVars.g_strDataBaseName = xmlEle.SelectSingleNode("database").InnerText;
            GlobalVars.g_strConnectionString = GlobalVars.BuildEntityConnectionString();
        }

        public XmlDocument XMLReader(string filename, ref string ErrorText)
        {
            XmlDocument xmlR = new XmlDocument();
            try
            {
                xmlR.Load(filename);
            }
            catch
            {
                ErrorText = "Không đọc được hoặc không tồn tại tập tin cấu hình";
            }

            return xmlR;
        }

        public void XMLWriter(string filename)
        {
            XmlTextWriter xmlW = new XmlTextWriter(filename, null);
            xmlW.Formatting = Formatting.Indented;

            xmlW.WriteStartDocument();
            xmlW.WriteComment("\nKhong duoc thay doi noi dung file nay!\n" +
                                "Thong so co ban:\n\t" +
                                "costatus = true : quyen Windows\n\t" +
                                "costatus = false: quyen SQL Server\n\t" +
                                "servname: ten server\n\t" +
                                "username: ten dang nhap he thong\n\t" +
                                "password: mat khau dang nhap he thong\n\t" +
                                "database: ten co so du lieu\n");
            xmlW.WriteStartElement("config");

            xmlW.WriteStartElement("costatus");
            xmlW.WriteEndElement();

            xmlW.WriteStartElement("servname");
            xmlW.WriteEndElement();

            xmlW.WriteStartElement("username");
            xmlW.WriteEndElement();

            xmlW.WriteStartElement("password");
            xmlW.WriteEndElement();

            xmlW.WriteStartElement("database");
            xmlW.WriteEndElement();

            xmlW.WriteEndElement();
            xmlW.WriteEndDocument();

            xmlW.Close();
        }

        public void XMLWriter(String filename, String servname, String database, String costatus)
        {
            XmlTextWriter xmlW = new XmlTextWriter(filename, null);
            xmlW.Formatting = Formatting.Indented;

            xmlW.WriteStartDocument();
            xmlW.WriteComment("\nKhong duoc thay doi noi dung file nay!\n" +
                                "Thong so co ban:\n\t" +
                                "costatus = true : quyen Windows\n\t" +
                                "costatus = false: quyen SQL Server\n\t" +
                                "servname: ten server\n\t" +
                                "username: ten dang nhap he thong\n\t" +
                                "password: mat khau dang nhap he thong\n\t" +
                                "database: ten co so du lieu\n");
            xmlW.WriteStartElement("config");

            xmlW.WriteStartElement("costatus");
            xmlW.WriteString(costatus);
            xmlW.WriteEndElement();

            xmlW.WriteStartElement("servname");
            xmlW.WriteString(servname);
            xmlW.WriteEndElement();

            xmlW.WriteStartElement("username");
            xmlW.WriteString("");
            xmlW.WriteEndElement();

            xmlW.WriteStartElement("password");
            xmlW.WriteString("");
            xmlW.WriteEndElement();

            xmlW.WriteStartElement("database");
            xmlW.WriteString(database);
            xmlW.WriteEndElement();

            xmlW.WriteEndElement();
            xmlW.WriteEndDocument();

            xmlW.Close();
        }

        public void XMLWriter(String filename, String servname, String database, String username, String password, String costatus)
        {
            XmlTextWriter xmlW = new XmlTextWriter(filename, null);
            xmlW.Formatting = Formatting.Indented;

            xmlW.WriteStartDocument();
            xmlW.WriteComment("\nKhong duoc thay doi noi dung file nay!\n" +
                                "Thong so co ban:\n\t" +
                                "costatus = true : quyen Windows\n\t" +
                                "costatus = false: quyen SQL Server\n\t" +
                                "servname: ten server\n\t" +
                                "username: ten dang nhap he thong\n\t" +
                                "password: mat khau dang nhap he thong\n\t" +
                                "database: ten co so du lieu\n");
            xmlW.WriteStartElement("config");

            xmlW.WriteStartElement("costatus");
            xmlW.WriteString(costatus);
            xmlW.WriteEndElement();

            xmlW.WriteStartElement("servname");
            xmlW.WriteString(servname);
            xmlW.WriteEndElement();

            xmlW.WriteStartElement("username");
            xmlW.WriteString(username);
            xmlW.WriteEndElement();

            xmlW.WriteStartElement("password");
            xmlW.WriteString(password);
            xmlW.WriteEndElement();

            xmlW.WriteStartElement("database");
            xmlW.WriteString(database);
            xmlW.WriteEndElement();

            xmlW.WriteEndElement();
            xmlW.WriteEndDocument();

            xmlW.Close();
        }
    }
}
