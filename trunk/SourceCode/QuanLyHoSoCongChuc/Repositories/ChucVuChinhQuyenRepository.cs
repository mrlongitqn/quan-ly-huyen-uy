using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class ChucVuChinhQuyenRepository
	{
		public static List<ChucVuChinhQuyen> SelectAll()
		{
			return DataContext.Instance.ChucVuChinhQuyens.OrderBy(item => item.TenChucVuChinhQuyen).ToList();
		}

		public static ChucVuChinhQuyen SelectByID(int machucvuchinhquyen)
		{
			return DataContext.Instance.ChucVuChinhQuyens.FirstOrDefault(item => item.MaChucVuChinhQuyen == machucvuchinhquyen );
		}

		public static bool Insert(ChucVuChinhQuyen obj)
		{
			try
			{
				DataContext.Instance.ChucVuChinhQuyens.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int machucvuchinhquyen)
		{
			try
			{
				var delitem = DataContext.Instance.ChucVuChinhQuyens.FirstOrDefault(item => item.MaChucVuChinhQuyen == machucvuchinhquyen );
				DataContext.Instance.ChucVuChinhQuyens.DeleteObject(delitem);
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

		public static List<ChucVuChinhQuyen> RetrieveByID(int machucvuchinhquyen)
		{
			return (from item in DataContext.Instance.ChucVuChinhQuyens where  item.MaChucVuChinhQuyen == machucvuchinhquyen  select item).ToList();
		}

	}
}