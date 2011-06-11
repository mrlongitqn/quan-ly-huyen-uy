using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class DacDiemLichSuRepository
	{
		public static List<DacDiemLichSu> SelectAll()
		{
			return DataContext.Instance.DacDiemLichSus.ToList();
		}

		public static DacDiemLichSu SelectByID(int madacdiemls)
		{
			return DataContext.Instance.DacDiemLichSus.FirstOrDefault(item => item.MaDacDiemLS == madacdiemls );
		}

		public static bool Insert(DacDiemLichSu obj)
		{
			try
			{
				DataContext.Instance.DacDiemLichSus.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int madacdiemls)
		{
			try
			{
				var delitem = DataContext.Instance.DacDiemLichSus.FirstOrDefault(item => item.MaDacDiemLS == madacdiemls );
				DataContext.Instance.DacDiemLichSus.DeleteObject(delitem);
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

		public static List<DacDiemLichSu> RetrieveByID(int madacdiemls)
		{
			return (from item in DataContext.Instance.DacDiemLichSus where  item.MaDacDiemLS == madacdiemls  select item).ToList();
		}

		public static List<DacDiemLichSu> SelectByMaNhanVien(string manhanvien)
		{
			var lstItem = (from item in DataContext.Instance.DacDiemLichSus where item.MaNhanVien == manhanvien select item).ToList();
			return lstItem;
		}

	}
}