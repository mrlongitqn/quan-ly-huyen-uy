using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class HoatDongKinhTeRepository
	{
		public static List<HoatDongKinhTe> SelectAll()
		{
			return DataContext.Instance.HoatDongKinhTes.OrderBy(item => item.TenHoatDongKinhTe).ToList();
		}

		public static HoatDongKinhTe SelectByID(int mahoatdongkinhte)
		{
			return DataContext.Instance.HoatDongKinhTes.FirstOrDefault(item => item.MaHoatDongKinhTe == mahoatdongkinhte );
		}

		public static bool Insert(HoatDongKinhTe obj)
		{
			try
			{
				DataContext.Instance.HoatDongKinhTes.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int mahoatdongkinhte)
		{
			try
			{
				var delitem = DataContext.Instance.HoatDongKinhTes.FirstOrDefault(item => item.MaHoatDongKinhTe == mahoatdongkinhte );
				DataContext.Instance.HoatDongKinhTes.DeleteObject(delitem);
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

		public static List<HoatDongKinhTe> RetrieveByID(int mahoatdongkinhte)
		{
			return (from item in DataContext.Instance.HoatDongKinhTes where  item.MaHoatDongKinhTe == mahoatdongkinhte  select item).ToList();
		}

	}
}