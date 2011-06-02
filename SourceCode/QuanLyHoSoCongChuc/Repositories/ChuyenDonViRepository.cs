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

		public static ChuyenDonVi SelectByID(int machuyen)
		{
			return DataContext.Instance.ChuyenDonVis.FirstOrDefault(item => item.MaChuyen == machuyen );
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

		public static bool Delete(int machuyen)
		{
			try
			{
				var delitem = DataContext.Instance.ChuyenDonVis.FirstOrDefault(item => item.MaChuyen == machuyen );
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

		public static List<ChuyenDonVi> RetrieveByID(int machuyen)
		{
			return (from item in DataContext.Instance.ChuyenDonVis where  item.MaChuyen == machuyen  select item).ToList();
		}

		public static List<ChuyenDonVi> SelectByMaNhanVien(string manhanvien)
		{
			var lstItem = (from item in DataContext.Instance.ChuyenDonVis where item.MaNhanVien == manhanvien select item).ToList();
			return lstItem;
		}

		public static List<ChuyenDonVi> SelectByMaDonViDi(string madonvidi)
		{
			var lstItem = (from item in DataContext.Instance.ChuyenDonVis where item.MaDonViDi == madonvidi select item).ToList();
			return lstItem;
		}

		public static List<ChuyenDonVi> SelectByMaDonViDen(string madonviden)
		{
			var lstItem = (from item in DataContext.Instance.ChuyenDonVis where item.MaDonViDen == madonviden select item).ToList();
			return lstItem;
		}

	}
}