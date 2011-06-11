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

		public static QuaTrinhCongTac SelectByID(int maquatrinhcongtac)
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

		public static bool Delete(int maquatrinhcongtac)
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

		public static List<QuaTrinhCongTac> RetrieveByID(int maquatrinhcongtac)
		{
			return (from item in DataContext.Instance.QuaTrinhCongTacs where  item.MaQuaTrinhCongTac == maquatrinhcongtac  select item).ToList();
		}

		public static List<QuaTrinhCongTac> SelectByMaNhanVien(string manhanvien)
		{
			var lstItem = (from item in DataContext.Instance.QuaTrinhCongTacs where item.MaNhanVien == manhanvien select item).OrderBy(item => item.ThoiGianBatDau).ToList();
			return lstItem;
		}

		public static List<QuaTrinhCongTac> SelectByMaNuocCongTac(int manuoccongtac)
		{
			var lstItem = (from item in DataContext.Instance.QuaTrinhCongTacs where item.MaNuocCongTac == manuoccongtac select item).ToList();
			return lstItem;
		}

		public static List<QuaTrinhCongTac> SelectByMaCapUy(int macapuy)
		{
			var lstItem = (from item in DataContext.Instance.QuaTrinhCongTacs where item.MaCapUy == macapuy select item).ToList();
			return lstItem;
		}

		public static List<QuaTrinhCongTac> SelectByMaCapUyKiem(int macapuykiem)
		{
			var lstItem = (from item in DataContext.Instance.QuaTrinhCongTacs where item.MaCapUyKiem == macapuykiem select item).ToList();
			return lstItem;
		}

		public static List<QuaTrinhCongTac> SelectByMaChucVuChinhQuyen(int machucvuchinhquyen)
		{
			var lstItem = (from item in DataContext.Instance.QuaTrinhCongTacs where item.MaChucVuChinhQuyen == machucvuchinhquyen select item).ToList();
			return lstItem;
		}

	}
}