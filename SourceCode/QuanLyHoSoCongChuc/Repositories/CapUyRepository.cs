using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class CapUyRepository
	{
		public static List<CapUy> SelectAll()
		{
			return DataContext.Instance.CapUys.ToList();
		}

		public static CapUy SelectByID(int macapuy)
		{
			return DataContext.Instance.CapUys.FirstOrDefault(item => item.MaCapUy == macapuy );
		}

		public static bool Insert(CapUy obj)
		{
			try
			{
				DataContext.Instance.CapUys.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int macapuy)
		{
			try
			{
				var delitem = DataContext.Instance.CapUys.FirstOrDefault(item => item.MaCapUy == macapuy );
				DataContext.Instance.CapUys.DeleteObject(delitem);
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

		public static List<CapUy> RetrieveByID(int macapuy)
		{
			return (from item in DataContext.Instance.CapUys where  item.MaCapUy == macapuy  select item).ToList();
		}

	}
}