using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class QuanHeRepository
	{
		public static List<QuanHe> SelectAll()
		{
			return DataContext.Instance.QuanHes.ToList();
		}

		public static QuanHe SelectByID(string maquanhe)
		{
			return DataContext.Instance.QuanHes.FirstOrDefault(item => item.MaQuanHe == maquanhe );
		}

		public static bool Insert(QuanHe obj)
		{
			try
			{
				DataContext.Instance.QuanHes.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(string maquanhe)
		{
			try
			{
				var delitem = DataContext.Instance.QuanHes.FirstOrDefault(item => item.MaQuanHe == maquanhe );
				DataContext.Instance.QuanHes.DeleteObject(delitem);
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

		public static List<QuanHe> RetrieveByID(string maquanhe)
		{
			return (from item in DataContext.Instance.QuanHes where  item.MaQuanHe == maquanhe  select item).ToList();
		}

	}
}