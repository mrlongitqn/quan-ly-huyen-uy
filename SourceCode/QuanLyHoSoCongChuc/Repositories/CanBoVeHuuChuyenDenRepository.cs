using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class CanBoVeHuuChuyenDenRepository
	{
		public static List<CanBoVeHuuChuyenDen> SelectAll()
		{
			return DataContext.Instance.CanBoVeHuuChuyenDens.ToList();
		}

		public static CanBoVeHuuChuyenDen SelectByID(int macanbo)
		{
			return DataContext.Instance.CanBoVeHuuChuyenDens.FirstOrDefault(item => item.MaCanBo == macanbo );
		}

		public static bool Insert(CanBoVeHuuChuyenDen obj)
		{
			try
			{
				DataContext.Instance.CanBoVeHuuChuyenDens.AddObject(obj);
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
				var delitem = DataContext.Instance.CanBoVeHuuChuyenDens.FirstOrDefault(item => item.MaCanBo == macanbo );
				DataContext.Instance.CanBoVeHuuChuyenDens.DeleteObject(delitem);
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

		public static List<CanBoVeHuuChuyenDen> RetrieveByID(int macanbo)
		{
			return (from item in DataContext.Instance.CanBoVeHuuChuyenDens where  item.MaCanBo == macanbo  select item).ToList();
		}

		public static List<CanBoVeHuuChuyenDen> SelectByMaCanBo(int macanbo)
		{
			var lstItem = (from item in DataContext.Instance.CanBoVeHuuChuyenDens where item.MaCanBo == macanbo select item).ToList();
			return lstItem;
		}

	}
}