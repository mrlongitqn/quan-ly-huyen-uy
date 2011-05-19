using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class TinhThanhRepository
	{
		public List<TinhThanh> SelectAll()
		{
			return DataContext.Instance.TinhThanhs.ToList();
		}

		public TinhThanh SelectByID(string matinh)
		{
			return DataContext.Instance.TinhThanhs.FirstOrDefault(item => item.MaTinh == matinh );
		}

		public bool Insert(TinhThanh obj)
		{
			try
			{
				DataContext.Instance.TinhThanhs.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Delete(string matinh)
		{
			try
			{
				var delitem = DataContext.Instance.TinhThanhs.FirstOrDefault(item => item.MaTinh == matinh );
				DataContext.Instance.TinhThanhs.DeleteObject(delitem);
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

		public List<TinhThanh> RetrieveByID(string matinh)
		{
			return (from item in DataContext.Instance.TinhThanhs where  item.MaTinh == matinh  select item).ToList();
		}

	}
}