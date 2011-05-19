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
		public List<QuaTrinhCongTacMoi> SelectAll()
		{
			return DataContext.Instance.QuaTrinhCongTacMois.ToList();
		}

		public QuaTrinhCongTacMoi SelectByID(int maquatrinhcongtac)
		{
			return DataContext.Instance.QuaTrinhCongTacMois.FirstOrDefault(item => item.MaQuaTrinhCongTac == maquatrinhcongtac );
		}

		public bool Insert(QuaTrinhCongTacMoi obj)
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

		public bool Delete(int maquatrinhcongtac)
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

		public bool Save()
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

		public List<QuaTrinhCongTacMoi> RetrieveByID(int maquatrinhcongtac)
		{
			return (from item in DataContext.Instance.QuaTrinhCongTacMois where  item.MaQuaTrinhCongTac == maquatrinhcongtac  select item).ToList();
		}

		public List<QuaTrinhCongTacMoi> SelectByNhanVien(string manhanvien, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.QuaTrinhCongTacMois where item.MaNhanVien == manhanvien select item).ToList();
			return lstItem;
		}

		public List<QuaTrinhCongTacMoi> SelectByNuocCongTac(int manuoccongtac, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.QuaTrinhCongTacMois where item.MaNuocCongTac == manuoccongtac select item).ToList();
			return lstItem;
		}

		public List<QuaTrinhCongTacMoi> SelectByCapUy(int macapuy, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.QuaTrinhCongTacMois where item.MaCapUy == macapuy select item).ToList();
			return lstItem;
		}

		public List<QuaTrinhCongTacMoi> SelectByCapUyKiem(int macapuykiem, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.QuaTrinhCongTacMois where item.MaCapUyKiem == macapuykiem select item).ToList();
			return lstItem;
		}

		public List<QuaTrinhCongTacMoi> SelectByChucVuChinhQuyen(int machucvuchinhquyen, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.QuaTrinhCongTacMois where item.MaChucVuChinhQuyen == machucvuchinhquyen select item).ToList();
			return lstItem;
		}

	}
}