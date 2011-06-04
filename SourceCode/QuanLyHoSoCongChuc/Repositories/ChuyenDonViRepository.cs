using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class ChuyenDonViRepository
	{
		public static List<ChuyenDonVi> SelectAll()
		{
			return DataContext.Instance.ChuyenDonVis.ToList();
		}

		public static ChuyenDonVi SelectByID(int macanbo)
		{
			return DataContext.Instance.ChuyenDonVis.FirstOrDefault(item => item.MaCanBo == macanbo );
		}

		public static bool Insert(ChuyenDonVi obj)
		{
			try
			{
				DataContext.Instance.ChuyenDonVis.AddObject(obj);
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
				var delitem = DataContext.Instance.ChuyenDonVis.FirstOrDefault(item => item.MaCanBo == macanbo );
				DataContext.Instance.ChuyenDonVis.DeleteObject(delitem);
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

		public static List<ChuyenDonVi> RetrieveByID(int macanbo)
		{
			return (from item in DataContext.Instance.ChuyenDonVis where  item.MaCanBo == macanbo  select item).ToList();
		}

		public static List<ChuyenDonVi> SelectByMaCanBo(int macanbo)
		{
			var lstItem = (from item in DataContext.Instance.ChuyenDonVis where item.MaCanBo == macanbo select item).ToList();
			return lstItem;
		}

		public static List<ChuyenDonVi> SelectByMaDonViDen(string madonviden)
		{
			var lstItem = (from item in DataContext.Instance.ChuyenDonVis where item.MaDonViDen == madonviden select item).ToList();
			return lstItem;
		}

	}
}