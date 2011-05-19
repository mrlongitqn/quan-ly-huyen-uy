using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class DienUuTienBanThanRepository
	{
		public List<DienUuTienBanThan> SelectAll()
		{
			return DataContext.Instance.DienUuTienBanThans.ToList();
		}

		public DienUuTienBanThan SelectByID(string madienuutienbanthan)
		{
			return DataContext.Instance.DienUuTienBanThans.FirstOrDefault(item => item.MaDienUuTienBanThan == madienuutienbanthan );
		}

		public bool Insert(DienUuTienBanThan obj)
		{
			try
			{
				DataContext.Instance.DienUuTienBanThans.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Delete(string madienuutienbanthan)
		{
			try
			{
				var delitem = DataContext.Instance.DienUuTienBanThans.FirstOrDefault(item => item.MaDienUuTienBanThan == madienuutienbanthan );
				DataContext.Instance.DienUuTienBanThans.DeleteObject(delitem);
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

		public List<DienUuTienBanThan> RetrieveByID(string madienuutienbanthan)
		{
			return (from item in DataContext.Instance.DienUuTienBanThans where  item.MaDienUuTienBanThan == madienuutienbanthan  select item).ToList();
		}

	}
}