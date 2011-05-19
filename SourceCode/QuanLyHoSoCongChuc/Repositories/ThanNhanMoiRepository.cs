using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class ThanNhanMoiRepository
	{
		public static List<ThanNhanMoi> SelectAll()
		{
			return DataContext.Instance.ThanNhanMois.ToList();
		}

		public static ThanNhanMoi SelectByID(int mathannhan)
		{
			return DataContext.Instance.ThanNhanMois.FirstOrDefault(item => item.MaThanNhan == mathannhan );
		}

		public static bool Insert(ThanNhanMoi obj)
		{
			try
			{
				DataContext.Instance.ThanNhanMois.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int mathannhan)
		{
			try
			{
				var delitem = DataContext.Instance.ThanNhanMois.FirstOrDefault(item => item.MaThanNhan == mathannhan );
				DataContext.Instance.ThanNhanMois.DeleteObject(delitem);
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

		public static List<ThanNhanMoi> RetrieveByID(int mathannhan)
		{
			return (from item in DataContext.Instance.ThanNhanMois where  item.MaThanNhan == mathannhan  select item).ToList();
		}

		public static List<ThanNhanMoi> SelectByQuanHe(string maquanhe, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.ThanNhanMois where item.MaQuanHe == maquanhe select item).ToList();
			return lstItem;
		}

		public static List<ThanNhanMoi> SelectByNhanVien(string manhanvien, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.ThanNhanMois where item.MaNhanVien == manhanvien select item).ToList();
			return lstItem;
		}

	}
}