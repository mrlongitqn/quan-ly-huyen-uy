namespace QuanLyHoSoCongChuc.Report
{
    using System;
	using System.Drawing;
	using System.IO;
	using System.Runtime.Serialization.Formatters.Binary;


    /// <summary>
    ///    Summary description for BusinessCard.
    /// </summary>
    public class BusinessCard : System.ICloneable
    {
        public BusinessCard(string appPath)
        {
			TheAppPath = appPath;
            //
            // TODO: Add Constructor Logic here
            //
        }

        public string IDCC = "ID Công chức:..............";
        public string UBND_Tinh = "Ủy ban nhân dan tỉnh Hà tĩnh";
        public string PhongBan = "Phòng ban: .................";
        public string UBND_Huyen = "Ủy ban nhân dan huyện thạch hà";
        public string City = "City";
        public string ChucVu = "Chức vụ: ..............";
        public string SoHieuCC = "Só hiệu công chức:...........";
		public string TheAppPath;
		public string PicturePath;
		public Bitmap Picture = new Bitmap(80, 80);
		public Font LargeFont = new Font("Times New Roman", 11);
		public Font SmallFont = new Font("Times New Roman", 10);
        public string Email;
        public string HoVaTen = "Họ và tên: Đõ MInh Tuấn";
		public void GetData() 
		{
			
		}

		
		/// Fax # of the user
		public string Fax;
		/// Web Address of the user
		public string WebAddress;

		public object Clone()
		{
			BusinessCard bc = new BusinessCard("");
			bc.UBND_Huyen = UBND_Huyen;
			bc.City  = this.City;
			bc.Email = this.Email;
			bc.Fax = this.Fax;
			bc.UBND_Tinh = this.UBND_Tinh;
			bc.LargeFont = this.LargeFont;
			bc.SmallFont = this.SmallFont;
			bc.IDCC  = this.IDCC;
			bc.HoVaTen = this.HoVaTen;
			bc.ChucVu = this.ChucVu;
			bc.TheAppPath = this.TheAppPath;
			bc.WebAddress = this.WebAddress;
			bc.SoHieuCC = this.SoHieuCC;
			bc.PicturePath = this.PicturePath;
			return bc;
		}

		public void ShallowCopy(BusinessCard aCard)
		{
			this.UBND_Huyen = aCard.UBND_Huyen;
			this.City  = aCard.City;
			this.Email = aCard.Email;
			this.Fax = aCard.Fax;
			this.UBND_Tinh = aCard.UBND_Tinh;
			this.LargeFont = aCard.LargeFont;
			this.SmallFont = aCard.SmallFont;
			this.IDCC  = aCard.IDCC;
			this.HoVaTen = aCard.HoVaTen;
			this.ChucVu = aCard.ChucVu;
			this.TheAppPath = aCard.TheAppPath;
			this.WebAddress = aCard.WebAddress;
			this.SoHieuCC = aCard.SoHieuCC;
			this.PicturePath = aCard.PicturePath;
			this.Picture = aCard.Picture;
		}


		public void PaintCard(Graphics g, Point offset)
		{
            Image image1 = Image.FromFile("C:\\abc.jpg");
            Image image2 = Image.FromFile("C:\\Co.jpg");
           
			if (Picture != null)
			{
                g.DrawImage(image1, offset.X + 10, offset.Y + 75, 90, 120);
			}
            if (image2 != null)
            {
                g.DrawImage(image2, offset.X + 12, offset.Y + 12, 80, 50);
            }

			float sumHeight = 20f;

			g.DrawString(UBND_Tinh , LargeFont, Brushes.Black, (float)offset.X + 100.0f, (float)offset.Y + 15);
			sumHeight += LargeFont.Height + 3.0f;

            g.DrawString(UBND_Huyen, LargeFont, Brushes.Black, (float)offset.X + 100.0f, (float)offset.Y + 35);
			sumHeight += SmallFont.Height + 3.0f;

			g.DrawString(IDCC, LargeFont, Brushes.Black,  (float)offset.X + 110.0f, (float)offset.Y + 75);

            g.DrawString(HoVaTen, LargeFont, Brushes.Black, (float)offset.X + 110.0f, (float)offset.Y + 100);

            g.DrawString(PhongBan, LargeFont, Brushes.Black, (float)offset.X + 110.0f, (float)offset.Y + 125);

            g.DrawString(ChucVu, LargeFont, Brushes.Black, (float)offset.X + 110.0f, (float)offset.Y + 150);

            g.DrawString(SoHieuCC, LargeFont, Brushes.Black, (float)offset.X + 110.0f, (float)offset.Y + 175);
			
		}

		public void SaveCard()
		{
			try
			{
				FileStream s = new FileStream(TheAppPath + "\\business_card1.bin", FileMode.Create, FileAccess.Write);      // open the filestream
				BinaryFormatter b = new BinaryFormatter();   // create the formatter
				b.Serialize(s, this);                  // serialize the graph to the stream
				s.Close();
			}
			catch(Exception exx)
			{
				System.Console.WriteLine(exx.ToString());
			}
		}

		public BusinessCard OpenCard()
		{
			
			try
			{
				FileStream s = new FileStream(TheAppPath + "\\business_card1.bin", FileMode.Open, FileAccess.Read);      // open the filestream
				BinaryFormatter b = new BinaryFormatter();   // create the formatter
				BusinessCard bc = (BusinessCard)b.Deserialize (s); // serialize the graph to the stream
				s.Close();
				return bc;
			}
			catch(Exception nocardsaved)
			{
				System.Console.WriteLine(nocardsaved.ToString());
				return null;
			}
		}
		
		
    }
}
