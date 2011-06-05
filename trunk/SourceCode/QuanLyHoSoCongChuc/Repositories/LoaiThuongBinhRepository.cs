using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class LoaiThuongBinhRepository
	{
		public static List<LoaiThuongBinh> SelectAll()
		{
			return DataContext.Instance.LoaiThuongBinhs.OrderBy(item => item.TenLoaiThuongBinh).ToList();
		}

		public static LoaiThuongBinh SelectByID(int maloaithuongbinh)
		{
			return DataContext.Instance.LoaiThuongBinhs.FirstOrDefault(item => item.MaLoaiThuongBinh == maloaithuongbinh );
		}

		public static bool Insert(LoaiThuongBinh obj)
		{
			try
			{
				DataContext.Instance.LoaiThuongBinhs.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int maloaithuongbinh)
		{
			try
			{
				var delitem = DataContext.Instance.LoaiThuongBinhs.FirstOrDefault(item => item.MaLoaiThuongBinh == maloaithuongbinh );
				DataContext.Instance.LoaiThuongBinhs.DeleteObject(delitem);
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

		public static List<LoaiThuongBinh> RetrieveByID(int maloaithuongbinh)
		{
			return (from item in DataContext.Instance.LoaiThuongBinhs where  item.MaLoaiThuongBinh == maloaithuongbinh  select item).ToList();
		}

	}
}