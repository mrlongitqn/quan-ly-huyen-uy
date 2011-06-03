using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class NgheNghiepRepository
	{
		public static List<NgheNghiep> SelectAll()
		{
			return DataContext.Instance.NgheNghieps.OrderBy(item => item.TenNgheNghiep).ToList();
		}

		public static NgheNghiep SelectByID(int manghenghiep)
		{
			return DataContext.Instance.NgheNghieps.FirstOrDefault(item => item.MaNgheNghiep == manghenghiep );
		}

		public static bool Insert(NgheNghiep obj)
		{
			try
			{
				DataContext.Instance.NgheNghieps.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int manghenghiep)
		{
			try
			{
				var delitem = DataContext.Instance.NgheNghieps.FirstOrDefault(item => item.MaNgheNghiep == manghenghiep );
				DataContext.Instance.NgheNghieps.DeleteObject(delitem);
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

		public static List<NgheNghiep> RetrieveByID(int manghenghiep)
		{
			return (from item in DataContext.Instance.NgheNghieps where  item.MaNgheNghiep == manghenghiep  select item).ToList();
		}

	}
}