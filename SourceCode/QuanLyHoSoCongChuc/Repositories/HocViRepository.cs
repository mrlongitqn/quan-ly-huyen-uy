using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class HocViRepository
	{
		public static List<HocVi> SelectAll()
		{
			return DataContext.Instance.HocVis.OrderBy(item => item.TenHocVi).ToList();
		}

		public static HocVi SelectByID(int mahocvi)
		{
			return DataContext.Instance.HocVis.FirstOrDefault(item => item.MaHocVi == mahocvi );
		}

		public static bool Insert(HocVi obj)
		{
			try
			{
				DataContext.Instance.HocVis.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int mahocvi)
		{
			try
			{
				var delitem = DataContext.Instance.HocVis.FirstOrDefault(item => item.MaHocVi == mahocvi );
				DataContext.Instance.HocVis.DeleteObject(delitem);
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

		public static List<HocVi> RetrieveByID(int mahocvi)
		{
			return (from item in DataContext.Instance.HocVis where  item.MaHocVi == mahocvi  select item).ToList();
		}

	}
}