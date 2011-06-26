﻿namespace QuanLyHoSoCongChuc.Report
{
    using System;
	using System.Drawing;
	using System.IO;
	using System.Runtime.Serialization.Formatters.Binary;
    using System.Windows.Forms;


    /// <summary>
    ///    Summary description for BusinessCard.
    /// </summary>
    public class BusinessCard : System.ICloneable
    {
        public Font LargeFont = new Font("Times New Roman", 11);

        public BusinessCard(string appPath)
        {
			
        }

        public object Clone()
        {
            BusinessCard bc = new BusinessCard("");
           
            return bc;
        }

		public void PaintCard(Graphics g, Point offset, NhanVienDTO dto)
		{
            string strPath = Application.StartupPath;
            Image image1 = Image.FromFile(strPath+"\\abc.jpg");
            Image image2 = Image.FromFile(strPath+"\\Co.jpg");

            if (image1 != null)
			{
                g.DrawImage(image1, offset.X + 10, offset.Y + 75, 90, 120);
			}
            if (image2 != null)
            {
                g.DrawImage(image2, offset.X + 12, offset.Y + 12, 80, 50);
            }


            g.DrawString(dto.UBND_Tinh, LargeFont, Brushes.Black, (float)offset.X + 100.0f, (float)offset.Y + 15);

            g.DrawString(dto.UBND_Huyen, LargeFont, Brushes.Black, (float)offset.X + 100.0f, (float)offset.Y + 35);

            g.DrawString(dto.IDCC, LargeFont, Brushes.Black, (float)offset.X + 110.0f, (float)offset.Y + 75);

            g.DrawString(dto.HoVaTen, LargeFont, Brushes.Black, (float)offset.X + 110.0f, (float)offset.Y + 100);

            g.DrawString(dto.PhongBan, LargeFont, Brushes.Black, (float)offset.X + 110.0f, (float)offset.Y + 125);

            g.DrawString(dto.ChucVu, LargeFont, Brushes.Black, (float)offset.X + 110.0f, (float)offset.Y + 150);

            g.DrawString(dto.SoHieuCC, LargeFont, Brushes.Black, (float)offset.X + 110.0f, (float)offset.Y + 175);
			
		}


    }
}
