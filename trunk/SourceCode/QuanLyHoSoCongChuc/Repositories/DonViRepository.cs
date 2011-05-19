using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class DonViRepository
	{
		public List<DonVi> SelectAll()
		{
			return DataContext.Instance.DonVis.ToList();
		}

		public DonVi SelectByID(string madonvi)
		{
			return DataContext.Instance.DonVis.FirstOrDefault(item => item.MaDonVi == madonvi );
		}

		public bool Insert(DonVi obj)
		{
			try
			{
				DataContext.Instance.DonVis.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Delete(string madonvi)
		{
			try
			{
				var delitem = DataContext.Instance.DonVis.FirstOrDefault(item => item.MaDonVi == madonvi );
				DataContext.Instance.DonVis.DeleteObject(delitem);
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

		public List<DonVi> RetrieveByID(string madonvi)
		{
			return (from item in DataContext.Instance.DonVis where  item.MaDonVi == madonvi  select item).ToList();
		}

		public List<DonVi> SelectByLoaiDonVi(string maloaidonvi, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.DonVis where item.MaLoaiDonVi == maloaidonvi select item).ToList();
			return lstItem;
		}

		public List<DonVi> SelectByQuanHuyen(string maquanhuyen, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.DonVis where item.MaQuanHuyen == maquanhuyen select item).ToList();
			return lstItem;
		}

	}
}