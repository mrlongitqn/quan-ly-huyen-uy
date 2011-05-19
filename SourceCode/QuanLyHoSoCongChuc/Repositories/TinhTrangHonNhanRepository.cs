using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class TinhTrangHonNhanRepository
	{
		public static List<TinhTrangHonNhan> SelectAll()
		{
			return DataContext.Instance.TinhTrangHonNhans.ToList();
		}

		public static TinhTrangHonNhan SelectByID(string matinhtranghonnhan)
		{
			return DataContext.Instance.TinhTrangHonNhans.FirstOrDefault(item => item.MaTinhTrangHonNhan == matinhtranghonnhan );
		}

		public static bool Insert(TinhTrangHonNhan obj)
		{
			try
			{
				DataContext.Instance.TinhTrangHonNhans.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(string matinhtranghonnhan)
		{
			try
			{
				var delitem = DataContext.Instance.TinhTrangHonNhans.FirstOrDefault(item => item.MaTinhTrangHonNhan == matinhtranghonnhan );
				DataContext.Instance.TinhTrangHonNhans.DeleteObject(delitem);
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

		public static List<TinhTrangHonNhan> RetrieveByID(string matinhtranghonnhan)
		{
			return (from item in DataContext.Instance.TinhTrangHonNhans where  item.MaTinhTrangHonNhan == matinhtranghonnhan  select item).ToList();
		}

	}
}