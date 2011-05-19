using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class QuaTrinhBoiDuongRepository
	{
		public static List<QuaTrinhBoiDuong> SelectAll()
		{
			return DataContext.Instance.QuaTrinhBoiDuongs.ToList();
		}

		public static QuaTrinhBoiDuong SelectByID(string maquatrinhboiduong)
		{
			return DataContext.Instance.QuaTrinhBoiDuongs.FirstOrDefault(item => item.MaQuaTrinhBoiDuong == maquatrinhboiduong );
		}

		public static bool Insert(QuaTrinhBoiDuong obj)
		{
			try
			{
				DataContext.Instance.QuaTrinhBoiDuongs.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(string maquatrinhboiduong)
		{
			try
			{
				var delitem = DataContext.Instance.QuaTrinhBoiDuongs.FirstOrDefault(item => item.MaQuaTrinhBoiDuong == maquatrinhboiduong );
				DataContext.Instance.QuaTrinhBoiDuongs.DeleteObject(delitem);
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

		public static List<QuaTrinhBoiDuong> RetrieveByID(string maquatrinhboiduong)
		{
			return (from item in DataContext.Instance.QuaTrinhBoiDuongs where  item.MaQuaTrinhBoiDuong == maquatrinhboiduong  select item).ToList();
		}

		public static List<QuaTrinhBoiDuong> SelectByNhanVien(string manhanvien, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.QuaTrinhBoiDuongs where item.MaNhanVien == manhanvien select item).ToList();
			return lstItem;
		}

	}
}