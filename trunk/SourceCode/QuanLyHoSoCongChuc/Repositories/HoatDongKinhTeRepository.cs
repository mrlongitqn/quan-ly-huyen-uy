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
		public List<HoatDongKinhTe> SelectAll()
		{
			return DataContext.Instance.HoatDongKinhTes.ToList();
		}

		public HoatDongKinhTe SelectByID(string mahoatdongkinhte)
		{
			return DataContext.Instance.HoatDongKinhTes.FirstOrDefault(item => item.MaHoatDongKinhTe == mahoatdongkinhte );
		}

		public bool Insert(HoatDongKinhTe obj)
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

		public bool Delete(string mahoatdongkinhte)
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

		public bool Save()
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

		public List<HoatDongKinhTe> RetrieveByID(string mahoatdongkinhte)
		{
			return (from item in DataContext.Instance.HoatDongKinhTes where  item.MaHoatDongKinhTe == mahoatdongkinhte  select item).ToList();
		}

	}
}