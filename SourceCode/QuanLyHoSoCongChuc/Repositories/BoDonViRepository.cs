using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class BoDonViRepository
	{
		public static List<BoDonVi> SelectAll()
		{
			return DataContext.Instance.BoDonVis.ToList();
		}

		public static BoDonVi SelectByID(int macanbo)
		{
			return DataContext.Instance.BoDonVis.FirstOrDefault(item => item.MaCanBo == macanbo );
		}

		public static bool Insert(BoDonVi obj)
		{
			try
			{
				DataContext.Instance.BoDonVis.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int macanbo)
		{
			try
			{
				var delitem = DataContext.Instance.BoDonVis.FirstOrDefault(item => item.MaCanBo == macanbo );
				DataContext.Instance.BoDonVis.DeleteObject(delitem);
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

		public static List<BoDonVi> RetrieveByID(int macanbo)
		{
			return (from item in DataContext.Instance.BoDonVis where  item.MaCanBo == macanbo  select item).ToList();
		}

		public static List<BoDonVi> SelectByMaCanBo(int macanbo)
		{
			var lstItem = (from item in DataContext.Instance.BoDonVis where item.MaCanBo == macanbo select item).ToList();
			return lstItem;
		}

		public static List<BoDonVi> SelectByMaHinhThucBoDonVi(int mahinhthucbodonvi)
		{
			var lstItem = (from item in DataContext.Instance.BoDonVis where item.MaHinhThucBoDonVi == mahinhthucbodonvi select item).ToList();
			return lstItem;
		}

	}
}