using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class BangChuyenMonNghiepVuRepository
	{
		public static List<BangChuyenMonNghiepVu> SelectAll()
		{
			return DataContext.Instance.BangChuyenMonNghiepVus.OrderBy(item => item.TenBangChuyenMonNghiepVu).ToList();
		}

		public static BangChuyenMonNghiepVu SelectByID(int mabangchuyenmonnghiepvu)
		{
			return DataContext.Instance.BangChuyenMonNghiepVus.FirstOrDefault(item => item.MaBangChuyenMonNghiepVu == mabangchuyenmonnghiepvu );
		}

		public static bool Insert(BangChuyenMonNghiepVu obj)
		{
			try
			{
				DataContext.Instance.BangChuyenMonNghiepVus.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int mabangchuyenmonnghiepvu)
		{
			try
			{
				var delitem = DataContext.Instance.BangChuyenMonNghiepVus.FirstOrDefault(item => item.MaBangChuyenMonNghiepVu == mabangchuyenmonnghiepvu );
				DataContext.Instance.BangChuyenMonNghiepVus.DeleteObject(delitem);
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

		public static List<BangChuyenMonNghiepVu> RetrieveByID(int mabangchuyenmonnghiepvu)
		{
			return (from item in DataContext.Instance.BangChuyenMonNghiepVus where  item.MaBangChuyenMonNghiepVu == mabangchuyenmonnghiepvu  select item).ToList();
		}

	}
}