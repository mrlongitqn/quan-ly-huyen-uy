using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class ThanNhanRepository
	{
		public static List<ThanNhan> SelectAll()
		{
			return DataContext.Instance.ThanNhans.ToList();
		}

		public static ThanNhan SelectByID(string mathannhan)
		{
			return DataContext.Instance.ThanNhans.FirstOrDefault(item => item.MaThanNhan == mathannhan );
		}

		public static bool Insert(ThanNhan obj)
		{
			try
			{
				DataContext.Instance.ThanNhans.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(string mathannhan)
		{
			try
			{
				var delitem = DataContext.Instance.ThanNhans.FirstOrDefault(item => item.MaThanNhan == mathannhan );
				DataContext.Instance.ThanNhans.DeleteObject(delitem);
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

		public static List<ThanNhan> RetrieveByID(string mathannhan)
		{
			return (from item in DataContext.Instance.ThanNhans where  item.MaThanNhan == mathannhan  select item).ToList();
		}

		public static List<ThanNhan> SelectByMaNhanVien(string manhanvien)
		{
			var lstItem = (from item in DataContext.Instance.ThanNhans where item.MaNhanVien == manhanvien select item).ToList();
			return lstItem;
		}

		public static List<ThanNhan> SelectByMaQuanHe(string maquanhe)
		{
			var lstItem = (from item in DataContext.Instance.ThanNhans where item.MaQuanHe == maquanhe select item).ToList();
			return lstItem;
		}

	}
}