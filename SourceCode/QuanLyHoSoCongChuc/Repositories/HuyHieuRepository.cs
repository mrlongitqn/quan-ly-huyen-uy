using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class HuyHieuRepository
	{
		public static List<HuyHieu> SelectAll()
		{
			return DataContext.Instance.HuyHieux.ToList();
		}

		public static HuyHieu SelectByID(int mahuyhieu)
		{
			return DataContext.Instance.HuyHieux.FirstOrDefault(item => item.MaHuyHieu == mahuyhieu );
		}

		public static bool Insert(HuyHieu obj)
		{
			try
			{
				DataContext.Instance.HuyHieux.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int mahuyhieu)
		{
			try
			{
				var delitem = DataContext.Instance.HuyHieux.FirstOrDefault(item => item.MaHuyHieu == mahuyhieu );
				DataContext.Instance.HuyHieux.DeleteObject(delitem);
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

		public static List<HuyHieu> RetrieveByID(int mahuyhieu)
		{
			return (from item in DataContext.Instance.HuyHieux where  item.MaHuyHieu == mahuyhieu  select item).ToList();
		}

		public static List<HuyHieu> SelectByMaNhanVien(string manhanvien)
		{
			var lstItem = (from item in DataContext.Instance.HuyHieux where item.MaNhanVien == manhanvien select item).ToList();
			return lstItem;
		}

		public static List<HuyHieu> SelectByMaLoaiHuyHieu(int maloaihuyhieu)
		{
			var lstItem = (from item in DataContext.Instance.HuyHieux where item.MaLoaiHuyHieu == maloaihuyhieu select item).ToList();
			return lstItem;
		}

	}
}