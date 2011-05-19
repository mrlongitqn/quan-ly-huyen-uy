using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class GioiTinhRepository
	{
		public static List<GioiTinh> SelectAll()
		{
			return DataContext.Instance.GioiTinhs.ToList();
		}

		public static GioiTinh SelectByID(string magioitinh)
		{
			return DataContext.Instance.GioiTinhs.FirstOrDefault(item => item.MaGioiTinh == magioitinh );
		}

		public static bool Insert(GioiTinh obj)
		{
			try
			{
				DataContext.Instance.GioiTinhs.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(string magioitinh)
		{
			try
			{
				var delitem = DataContext.Instance.GioiTinhs.FirstOrDefault(item => item.MaGioiTinh == magioitinh );
				DataContext.Instance.GioiTinhs.DeleteObject(delitem);
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

		public static List<GioiTinh> RetrieveByID(string magioitinh)
		{
			return (from item in DataContext.Instance.GioiTinhs where  item.MaGioiTinh == magioitinh  select item).ToList();
		}

	}
}