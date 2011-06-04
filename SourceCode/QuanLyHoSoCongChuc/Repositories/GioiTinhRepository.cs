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
			return DataContext.Instance.GioiTinhs.OrderBy(item => item.TenGioiTinh).ToList();
		}

		public static GioiTinh SelectByID(int magioitinh)
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

		public static bool Delete(int magioitinh)
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

		public static List<GioiTinh> RetrieveByID(int magioitinh)
		{
			return (from item in DataContext.Instance.GioiTinhs where  item.MaGioiTinh == magioitinh  select item).ToList();
		}

	}
}