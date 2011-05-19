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
		public List<ThanNhan> SelectAll()
		{
			return DataContext.Instance.ThanNhans.ToList();
		}

		public ThanNhan SelectByID(string mathannhan)
		{
			return DataContext.Instance.ThanNhans.FirstOrDefault(item => item.MaThanNhan == mathannhan );
		}

		public bool Insert(ThanNhan obj)
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

		public bool Delete(string mathannhan)
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

		public List<ThanNhan> RetrieveByID(string mathannhan)
		{
			return (from item in DataContext.Instance.ThanNhans where  item.MaThanNhan == mathannhan  select item).ToList();
		}

		public List<ThanNhan> SelectByNhanVien(string manhanvien, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.ThanNhans where item.MaNhanVien == manhanvien select item).ToList();
			return lstItem;
		}

		public List<ThanNhan> SelectByQuanHe(string maquanhe, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.ThanNhans where item.MaQuanHe == maquanhe select item).ToList();
			return lstItem;
		}

	}
}