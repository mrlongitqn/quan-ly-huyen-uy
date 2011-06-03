using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class ThanhPhanXuatThanRepository
	{
		public static List<ThanhPhanXuatThan> SelectAll()
		{
			return DataContext.Instance.ThanhPhanXuatThans.OrderBy(item => item.TenThanhPhanXuatThan).ToList();
		}

		public static ThanhPhanXuatThan SelectByID(string mathanhphanxuatthan)
		{
			return DataContext.Instance.ThanhPhanXuatThans.FirstOrDefault(item => item.MaThanhPhanXuatThan == mathanhphanxuatthan );
		}

		public static bool Insert(ThanhPhanXuatThan obj)
		{
			try
			{
				DataContext.Instance.ThanhPhanXuatThans.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(string mathanhphanxuatthan)
		{
			try
			{
				var delitem = DataContext.Instance.ThanhPhanXuatThans.FirstOrDefault(item => item.MaThanhPhanXuatThan == mathanhphanxuatthan );
				DataContext.Instance.ThanhPhanXuatThans.DeleteObject(delitem);
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

		public static List<ThanhPhanXuatThan> RetrieveByID(string mathanhphanxuatthan)
		{
			return (from item in DataContext.Instance.ThanhPhanXuatThans where  item.MaThanhPhanXuatThan == mathanhphanxuatthan  select item).ToList();
		}

	}
}