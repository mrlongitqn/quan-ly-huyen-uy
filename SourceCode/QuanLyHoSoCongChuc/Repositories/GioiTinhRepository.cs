using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class GioiTinhRepository
	{
		public List<GioiTinh> SelectAll()
		{
			return DataContext.Instance.GioiTinhs.ToList();
		}

		public GioiTinh SelectByID(string magioitinh)
		{
			return DataContext.Instance.GioiTinhs.FirstOrDefault(item => item.MaGioiTinh == magioitinh );
		}

		public bool Insert(GioiTinh obj)
		{
			try
			{
				DataContext.Instance.GioiTinhs.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Delete(string magioitinh)
		{
			try
			{
				var delitem = DataContext.Instance.GioiTinhs.FirstOrDefault(item => item.MaGioiTinh == magioitinh );
				DataContext.Instance.GioiTinhs.DeleteObject(delitem);
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

		public List<GioiTinh> RetrieveByID(string magioitinh)
		{
			return (from item in DataContext.Instance.GioiTinhs where  item.MaGioiTinh == magioitinh  select item).ToList();
		}

	}
}