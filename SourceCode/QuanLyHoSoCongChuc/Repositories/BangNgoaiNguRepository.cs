using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class BangNgoaiNguRepository
	{
		public static List<BangNgoaiNgu> SelectAll()
		{
			return DataContext.Instance.BangNgoaiNgus.OrderBy(item => item.TenBangNgoaiNgu).ToList();
		}

		public static BangNgoaiNgu SelectByID(int mabangngoaingu)
		{
			return DataContext.Instance.BangNgoaiNgus.FirstOrDefault(item => item.MaBangNgoaiNgu == mabangngoaingu );
		}

		public static bool Insert(BangNgoaiNgu obj)
		{
			try
			{
				DataContext.Instance.BangNgoaiNgus.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int mabangngoaingu)
		{
			try
			{
				var delitem = DataContext.Instance.BangNgoaiNgus.FirstOrDefault(item => item.MaBangNgoaiNgu == mabangngoaingu );
				DataContext.Instance.BangNgoaiNgus.DeleteObject(delitem);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Save()
		{
			try
			{
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static List<BangNgoaiNgu> RetrieveByID(int mabangngoaingu)
		{
			return (from item in DataContext.Instance.BangNgoaiNgus where  item.MaBangNgoaiNgu == mabangngoaingu  select item).ToList();
		}

	}
}