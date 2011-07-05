namespace QuanLyHoSoCongChuc.Report
{
    using System;
	using System.Drawing;
	using System.IO;
	using System.Runtime.Serialization.Formatters.Binary;
    using System.Windows.Forms;
    using QuanLyHoSoCongChuc.Models;


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

        public Image LoadImage(byte[] imageData)
        {
            try
            {
                //Initialize image variable
                Image newImage;
                //Read image data into a memory stream
                using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
                {
                    ms.Write(imageData, 0, imageData.Length);

                    //Set image variable value using memory stream.
                    newImage = Image.FromStream(ms, true);
                }
                return newImage;
            }
            catch
            {
                return null;
            }
        }


		public void PaintCard(Graphics g, Point offset, NhanVien dto)
		{
            string strPath = Application.StartupPath;
            Image image2 = Image.FromFile(strPath + "\\Resources\\Co.jpg");

            if (dto.HinhAnh != null)
			{
                g.DrawImage(LoadImage(dto.HinhAnh), offset.X + 12, offset.Y + 75, 75, 90);
			}
            if (image2 != null)
            {
                g.DrawImage(image2, offset.X + 12, offset.Y + 12, 80, 50);
            }


            g.DrawString("Ủy ban nhân dân tỉnh Hà tĩnh", LargeFont, Brushes.Black, (float)offset.X + 100.0f, (float)offset.Y + 15);

            g.DrawString("Ủy ban nhân dân huyện Thạch Hà", LargeFont, Brushes.Black, (float)offset.X + 100.0f, (float)offset.Y + 35);

            g.DrawString("SỐ HIỆU CÔNG CHỨCC: " + dto.MaNhanVien, LargeFont, Brushes.Black, (float)offset.X + 110.0f, (float)offset.Y + 75);

            g.DrawString("HỌ VÀ TÊN: " + dto.HoTenKhaiSinh, LargeFont, Brushes.Black, (float)offset.X + 110.0f, (float)offset.Y + 100);

            g.DrawString("PHÒNG/BAN: " + (dto.MaDonVi != null ? dto.DonVi.TenDonVi : ""), LargeFont, Brushes.Black, (float)offset.X + 110.0f, (float)offset.Y + 125);

            g.DrawString("CHỨC VỤ: " + (dto.MaChucVu != null ? dto.ChucVu.TenChucVu : ""), LargeFont, Brushes.Black, (float)offset.X + 110.0f, (float)offset.Y + 150);
		}
    }
}
