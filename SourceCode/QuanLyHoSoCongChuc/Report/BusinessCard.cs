namespace QuanLyHoSoCongChuc.Report
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
        public Font LargeFont = new Font("Times New Roman", 10);

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
            //Image image1 = Image.FromFile(strPath+"\\abc.jpg");
            Image image2 = Image.FromFile(strPath+"\\Co.jpg");

            if (dto.Picture != null)
			{
                g.DrawImage(dto.Picture, offset.X + 10, offset.Y + 75, 90, 120);
			}
            if (image2 != null)
            {
                g.DrawImage(image2, offset.X + 12, offset.Y + 12, 80, 50);
            }


            g.DrawString(dto.UBND_Tinh, LargeFont, Brushes.Black, (float)offset.X + 100.0f, (float)offset.Y + 15);

            g.DrawString(dto.UBND_Huyen, LargeFont, Brushes.Black, (float)offset.X + 100.0f, (float)offset.Y + 35);

            g.DrawString("ID CÔNG CHỨC: "+dto.IDCC, LargeFont, Brushes.Black, (float)offset.X + 110.0f, (float)offset.Y + 75);

            g.DrawString("HỌ VÀ TÊN: " + dto.HoVaTen, LargeFont, Brushes.Black, (float)offset.X + 110.0f, (float)offset.Y + 100);

            g.DrawString("PHÒNG/BAN: " + dto.PhongBan, LargeFont, Brushes.Black, (float)offset.X + 110.0f, (float)offset.Y + 125);

            g.DrawString("CHỨC VỤ: " + dto.ChucVu, LargeFont, Brushes.Black, (float)offset.X + 110.0f, (float)offset.Y + 150);

            g.DrawString("SỐ HIỆU CÔNG CHỨC: " + dto.SoHieuCC, LargeFont, Brushes.Black, (float)offset.X + 110.0f, (float)offset.Y + 175);
			
		}


    }
}
