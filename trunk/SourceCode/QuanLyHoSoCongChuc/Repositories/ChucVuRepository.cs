using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class ChucVuRepository
	{
		public static List<ChucVu> SelectAll()
		{
			return DataContext.Instance.ChucVus.OrderBy(item => item.TenChucVu).ToList();
		}

		public static ChucVu SelectByID(int machucvu)
		{
			return DataContext.Instance.ChucVus.FirstOrDefault(item => item.MaChucVu == machucvu );
		}

		public static bool Insert(ChucVu obj)
		{
			try
			{
				DataContext.Instance.ChucVus.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int machucvu)
		{
			try
			{
				var delitem = DataContext.Instance.ChucVus.FirstOrDefault(item => item.MaChucVu == machucvu );
				DataContext.Instance.ChucVus.DeleteObject(delitem);
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

		public static List<ChucVu> RetrieveByID(int machucvu)
		{
			return (from item in DataContext.Instance.ChucVus where  item.MaChucVu == machucvu  select item).ToList();
		}

	}
}