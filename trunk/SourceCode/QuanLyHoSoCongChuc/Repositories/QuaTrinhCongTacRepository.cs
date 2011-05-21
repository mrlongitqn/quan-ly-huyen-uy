using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class QuaTrinhCongTacRepository
	{
		public static List<QuaTrinhCongTac> SelectAll()
		{
			return DataContext.Instance.QuaTrinhCongTacs.ToList();
		}

		public static QuaTrinhCongTac SelectByID(string maquatrinhcongtac)
		{
			return DataContext.Instance.QuaTrinhCongTacs.FirstOrDefault(item => item.MaQuaTrinhCongTac == maquatrinhcongtac );
		}

		public static bool Insert(QuaTrinhCongTac obj)
		{
			try
			{
				DataContext.Instance.QuaTrinhCongTacs.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(string maquatrinhcongtac)
		{
			try
			{
				var delitem = DataContext.Instance.QuaTrinhCongTacs.FirstOrDefault(item => item.MaQuaTrinhCongTac == maquatrinhcongtac );
				DataContext.Instance.QuaTrinhCongTacs.DeleteObject(delitem);
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

		public static List<QuaTrinhCongTac> RetrieveByID(string maquatrinhcongtac)
		{
			return (from item in DataContext.Instance.QuaTrinhCongTacs where  item.MaQuaTrinhCongTac == maquatrinhcongtac  select item).ToList();
		}

		public static List<QuaTrinhCongTac> SelectByMaNhanVien(string manhanvien)
		{
			var lstItem = (from item in DataContext.Instance.QuaTrinhCongTacs where item.MaNhanVien == manhanvien select item).ToList();
			return lstItem;
		}

	}
}