using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class CanBoQuaCacThoiKiRepository
	{
		public static List<CanBoQuaCacThoiKi> SelectAll()
		{
			return DataContext.Instance.CanBoQuaCacThoiKis.ToList();
		}

		public static CanBoQuaCacThoiKi SelectByID(int macanbo)
		{
			return DataContext.Instance.CanBoQuaCacThoiKis.FirstOrDefault(item => item.MaCanBo == macanbo );
		}

		public static bool Insert(CanBoQuaCacThoiKi obj)
		{
			try
			{
				DataContext.Instance.CanBoQuaCacThoiKis.AddObject(obj);
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
				var delitem = DataContext.Instance.CanBoQuaCacThoiKis.FirstOrDefault(item => item.MaCanBo == macanbo );
				DataContext.Instance.CanBoQuaCacThoiKis.DeleteObject(delitem);
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

		public static List<CanBoQuaCacThoiKi> RetrieveByID(int macanbo)
		{
			return (from item in DataContext.Instance.CanBoQuaCacThoiKis where  item.MaCanBo == macanbo  select item).ToList();
		}

		public static List<CanBoQuaCacThoiKi> SelectByMaLoaiCanBo(int maloaicanbo)
		{
			var lstItem = (from item in DataContext.Instance.CanBoQuaCacThoiKis where item.MaLoaiCanBo == maloaicanbo select item).ToList();
			return lstItem;
		}

		public static List<CanBoQuaCacThoiKi> SelectByMaDonVi(string madonvi)
		{
			var lstItem = (from item in DataContext.Instance.CanBoQuaCacThoiKis where item.MaDonVi == madonvi select item).ToList();
			return lstItem;
		}

		public static List<CanBoQuaCacThoiKi> SelectByMaNhanVien(string manhanvien)
		{
			var lstItem = (from item in DataContext.Instance.CanBoQuaCacThoiKis where item.MaNhanVien == manhanvien select item).ToList();
			return lstItem;
		}

	}
}