using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class QuaTrinhCongTacMoiRepository
	{
		public static List<QuaTrinhCongTacMoi> SelectAll()
		{
			return DataContext.Instance.QuaTrinhCongTacMois.ToList();
		}

		public static QuaTrinhCongTacMoi SelectByID(int maquatrinhcongtac)
		{
			return DataContext.Instance.QuaTrinhCongTacMois.FirstOrDefault(item => item.MaQuaTrinhCongTac == maquatrinhcongtac );
		}

		public static bool Insert(QuaTrinhCongTacMoi obj)
		{
			try
			{
				DataContext.Instance.QuaTrinhCongTacMois.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int maquatrinhcongtac)
		{
			try
			{
				var delitem = DataContext.Instance.QuaTrinhCongTacMois.FirstOrDefault(item => item.MaQuaTrinhCongTac == maquatrinhcongtac );
				DataContext.Instance.QuaTrinhCongTacMois.DeleteObject(delitem);
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

		public static List<QuaTrinhCongTacMoi> RetrieveByID(int maquatrinhcongtac)
		{
			return (from item in DataContext.Instance.QuaTrinhCongTacMois where  item.MaQuaTrinhCongTac == maquatrinhcongtac  select item).ToList();
		}

		public static List<QuaTrinhCongTacMoi> SelectByNhanVien(string manhanvien, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.QuaTrinhCongTacMois where item.MaNhanVien == manhanvien select item).ToList();
			return lstItem;
		}

		public static List<QuaTrinhCongTacMoi> SelectByNuocCongTac(int manuoccongtac, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.QuaTrinhCongTacMois where item.MaNuocCongTac == manuoccongtac select item).ToList();
			return lstItem;
		}

		public static List<QuaTrinhCongTacMoi> SelectByCapUy(int macapuy, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.QuaTrinhCongTacMois where item.MaCapUy == macapuy select item).ToList();
			return lstItem;
		}

		public static List<QuaTrinhCongTacMoi> SelectByCapUyKiem(int macapuykiem, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.QuaTrinhCongTacMois where item.MaCapUyKiem == macapuykiem select item).ToList();
			return lstItem;
		}

		public static List<QuaTrinhCongTacMoi> SelectByChucVuChinhQuyen(int machucvuchinhquyen, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.QuaTrinhCongTacMois where item.MaChucVuChinhQuyen == machucvuchinhquyen select item).ToList();
			return lstItem;
		}

	}
}