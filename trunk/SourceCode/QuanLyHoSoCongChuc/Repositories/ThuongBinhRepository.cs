using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class ThuongBinhRepository
	{
		public static List<ThuongBinh> SelectAll()
		{
			return DataContext.Instance.ThuongBinhs.OrderBy(item => item.TenThuongBinh).ToList();
		}

		public static ThuongBinh SelectByID(int mathuongbinh)
		{
			return DataContext.Instance.ThuongBinhs.FirstOrDefault(item => item.MaThuongBinh == mathuongbinh );
		}

		public static bool Insert(ThuongBinh obj)
		{
			try
			{
				DataContext.Instance.ThuongBinhs.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int mathuongbinh)
		{
			try
			{
				var delitem = DataContext.Instance.ThuongBinhs.FirstOrDefault(item => item.MaThuongBinh == mathuongbinh );
				DataContext.Instance.ThuongBinhs.DeleteObject(delitem);
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

		public static List<ThuongBinh> RetrieveByID(int mathuongbinh)
		{
			return (from item in DataContext.Instance.ThuongBinhs where  item.MaThuongBinh == mathuongbinh  select item).ToList();
		}

	}
}