using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class Huong85Repository
	{
		public static List<Huong85> SelectAll()
		{
			return DataContext.Instance.Huong85s.ToList();
		}

		public static Huong85 SelectByID(string mahuong)
		{
			return DataContext.Instance.Huong85s.FirstOrDefault(item => item.MaHuong == mahuong );
		}

		public static bool Insert(Huong85 obj)
		{
			try
			{
				DataContext.Instance.Huong85s.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(string mahuong)
		{
			try
			{
				var delitem = DataContext.Instance.Huong85s.FirstOrDefault(item => item.MaHuong == mahuong );
				DataContext.Instance.Huong85s.DeleteObject(delitem);
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

		public static List<Huong85> RetrieveByID(string mahuong)
		{
			return (from item in DataContext.Instance.Huong85s where  item.MaHuong == mahuong  select item).ToList();
		}

	}
}