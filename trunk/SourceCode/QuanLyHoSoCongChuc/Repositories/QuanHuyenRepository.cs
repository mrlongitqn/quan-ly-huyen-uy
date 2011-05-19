using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class QuanHuyenRepository
	{
		public List<QuanHuyen> SelectAll()
		{
			return DataContext.Instance.QuanHuyens.ToList();
		}

		public QuanHuyen SelectByID(string maquanhuyen)
		{
			return DataContext.Instance.QuanHuyens.FirstOrDefault(item => item.MaQuanHuyen == maquanhuyen );
		}

		public bool Insert(QuanHuyen obj)
		{
			try
			{
				DataContext.Instance.QuanHuyens.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Delete(string maquanhuyen)
		{
			try
			{
				var delitem = DataContext.Instance.QuanHuyens.FirstOrDefault(item => item.MaQuanHuyen == maquanhuyen );
				DataContext.Instance.QuanHuyens.DeleteObject(delitem);
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

		public List<QuanHuyen> RetrieveByID(string maquanhuyen)
		{
			return (from item in DataContext.Instance.QuanHuyens where  item.MaQuanHuyen == maquanhuyen  select item).ToList();
		}

		public List<QuanHuyen> SelectByTinh(string matinh, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.QuanHuyens where item.MaTinh == matinh select item).ToList();
			return lstItem;
		}

	}
}