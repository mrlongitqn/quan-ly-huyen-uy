using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class NgachCongChucRepository
	{
		public List<NgachCongChuc> SelectAll()
		{
			return DataContext.Instance.NgachCongChucs.ToList();
		}

		public NgachCongChuc SelectByID(string mangachcongchuc)
		{
			return DataContext.Instance.NgachCongChucs.FirstOrDefault(item => item.MaNgachCongChuc == mangachcongchuc );
		}

		public bool Insert(NgachCongChuc obj)
		{
			try
			{
				DataContext.Instance.NgachCongChucs.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Delete(string mangachcongchuc)
		{
			try
			{
				var delitem = DataContext.Instance.NgachCongChucs.FirstOrDefault(item => item.MaNgachCongChuc == mangachcongchuc );
				DataContext.Instance.NgachCongChucs.DeleteObject(delitem);
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

		public List<NgachCongChuc> RetrieveByID(string mangachcongchuc)
		{
			return (from item in DataContext.Instance.NgachCongChucs where  item.MaNgachCongChuc == mangachcongchuc  select item).ToList();
		}

	}
}