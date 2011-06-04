using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class CapUyKiemRepository
	{
		public static List<CapUyKiem> SelectAll()
		{
			return DataContext.Instance.CapUyKiems.OrderBy(item => item.TenCapUyKiem).ToList();
		}

		public static CapUyKiem SelectByID(int macapuykiem)
		{
			return DataContext.Instance.CapUyKiems.FirstOrDefault(item => item.MaCapUyKiem == macapuykiem );
		}

		public static bool Insert(CapUyKiem obj)
		{
			try
			{
				DataContext.Instance.CapUyKiems.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int macapuykiem)
		{
			try
			{
				var delitem = DataContext.Instance.CapUyKiems.FirstOrDefault(item => item.MaCapUyKiem == macapuykiem );
				DataContext.Instance.CapUyKiems.DeleteObject(delitem);
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

		public static List<CapUyKiem> RetrieveByID(int macapuykiem)
		{
			return (from item in DataContext.Instance.CapUyKiems where  item.MaCapUyKiem == macapuykiem  select item).ToList();
		}

	}
}