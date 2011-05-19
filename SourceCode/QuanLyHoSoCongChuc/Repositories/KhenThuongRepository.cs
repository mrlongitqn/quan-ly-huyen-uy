using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class KhenThuongRepository
	{
		public static List<KhenThuong> SelectAll()
		{
			return DataContext.Instance.KhenThuongs.ToList();
		}

		public static KhenThuong SelectByID(string makhenthuong)
		{
			return DataContext.Instance.KhenThuongs.FirstOrDefault(item => item.MaKhenThuong == makhenthuong );
		}

		public static bool Insert(KhenThuong obj)
		{
			try
			{
				DataContext.Instance.KhenThuongs.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(string makhenthuong)
		{
			try
			{
				var delitem = DataContext.Instance.KhenThuongs.FirstOrDefault(item => item.MaKhenThuong == makhenthuong );
				DataContext.Instance.KhenThuongs.DeleteObject(delitem);
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

		public static List<KhenThuong> RetrieveByID(string makhenthuong)
		{
			return (from item in DataContext.Instance.KhenThuongs where  item.MaKhenThuong == makhenthuong  select item).ToList();
		}

		public static List<KhenThuong> SelectByNhanVien(string manhanvien, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.KhenThuongs where item.MaNhanVien == manhanvien select item).ToList();
			return lstItem;
		}

	}
}