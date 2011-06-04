using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class LoaiHuyHieuRepository
	{
		public static List<LoaiHuyHieu> SelectAll()
		{
			return DataContext.Instance.LoaiHuyHieux.OrderBy(item => item.TenLoaiHuyHieu).ToList();
		}

		public static LoaiHuyHieu SelectByID(int maloaihuyhieu)
		{
			return DataContext.Instance.LoaiHuyHieux.FirstOrDefault(item => item.MaLoaiHuyHieu == maloaihuyhieu );
		}

		public static bool Insert(LoaiHuyHieu obj)
		{
			try
			{
				DataContext.Instance.LoaiHuyHieux.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int maloaihuyhieu)
		{
			try
			{
				var delitem = DataContext.Instance.LoaiHuyHieux.FirstOrDefault(item => item.MaLoaiHuyHieu == maloaihuyhieu );
				DataContext.Instance.LoaiHuyHieux.DeleteObject(delitem);
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

		public static List<LoaiHuyHieu> RetrieveByID(int maloaihuyhieu)
		{
			return (from item in DataContext.Instance.LoaiHuyHieux where  item.MaLoaiHuyHieu == maloaihuyhieu  select item).ToList();
		}

	}
}