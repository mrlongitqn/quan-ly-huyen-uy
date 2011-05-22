using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class DanTocRepository
	{
		public static List<DanToc> SelectAll()
		{
			return DataContext.Instance.DanTocs.ToList();
		}

		public static DanToc SelectByID(string madantoc)
		{
			return DataContext.Instance.DanTocs.FirstOrDefault(item => item.MaDanToc == madantoc );
		}

		public static bool Insert(DanToc obj)
		{
			try
			{
				DataContext.Instance.DanTocs.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(string madantoc)
		{
			try
			{
				var delitem = DataContext.Instance.DanTocs.FirstOrDefault(item => item.MaDanToc == madantoc );
				DataContext.Instance.DanTocs.DeleteObject(delitem);
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

		public static List<DanToc> RetrieveByID(string madantoc)
		{
			return (from item in DataContext.Instance.DanTocs where  item.MaDanToc == madantoc  select item).ToList();
		}

	}
}