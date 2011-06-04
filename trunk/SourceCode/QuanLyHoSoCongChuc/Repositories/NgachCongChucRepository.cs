using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class NgachCongChucRepository
	{
		public static List<NgachCongChuc> SelectAll()
		{
			return DataContext.Instance.NgachCongChucs.OrderBy(item => item.TenNgachCongChuc).ToList();
		}

		public static NgachCongChuc SelectByID(string mangachcongchuc)
		{
			return DataContext.Instance.NgachCongChucs.FirstOrDefault(item => item.MaNgachCongChuc == mangachcongchuc );
		}

		public static bool Insert(NgachCongChuc obj)
		{
			try
			{
				DataContext.Instance.NgachCongChucs.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(string mangachcongchuc)
		{
			try
			{
				var delitem = DataContext.Instance.NgachCongChucs.FirstOrDefault(item => item.MaNgachCongChuc == mangachcongchuc );
				DataContext.Instance.NgachCongChucs.DeleteObject(delitem);
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

		public static List<NgachCongChuc> RetrieveByID(string mangachcongchuc)
		{
			return (from item in DataContext.Instance.NgachCongChucs where  item.MaNgachCongChuc == mangachcongchuc  select item).ToList();
		}

	}
}