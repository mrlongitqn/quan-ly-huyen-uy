using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class KyLuatRepository
	{
		public List<KyLuat> SelectAll()
		{
			return DataContext.Instance.KyLuats.ToList();
		}

		public KyLuat SelectByID(string makyluat, string manhanvien)
		{
			return DataContext.Instance.KyLuats.FirstOrDefault(item => item.MaKyLuat == makyluat &&  item.MaNhanVien == manhanvien );
		}

		public bool Insert(KyLuat obj)
		{
			try
			{
				DataContext.Instance.KyLuats.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Delete(string makyluat, string manhanvien)
		{
			try
			{
				var delitem = DataContext.Instance.KyLuats.FirstOrDefault(item => item.MaKyLuat == makyluat &&  item.MaNhanVien == manhanvien );
				DataContext.Instance.KyLuats.DeleteObject(delitem);
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

		public List<KyLuat> RetrieveByID(string makyluat, string manhanvien)
		{
			return (from item in DataContext.Instance.KyLuats where  item.MaKyLuat == makyluat &&  item.MaNhanVien == manhanvien  select item).ToList();
		}

		public List<KyLuat> SelectByNhanVien(string manhanvien, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.KyLuats where item.MaNhanVien == manhanvien select item).ToList();
			return lstItem;
		}

	}
}