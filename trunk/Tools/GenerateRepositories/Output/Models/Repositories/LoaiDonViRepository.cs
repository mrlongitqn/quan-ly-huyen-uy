using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class LoaiDonViRepository
	{
		public static List<LoaiDonVi> SelectAll()
		{
			return DataContext.Instance.LoaiDonVis.ToList();
		}

		public static LoaiDonVi SelectByID(string maloaidonvi)
		{
			return DataContext.Instance.LoaiDonVis.FirstOrDefault(item => item.MaLoaiDonVi == maloaidonvi );
		}

		public static bool Insert(LoaiDonVi obj)
		{
			try
			{
				DataContext.Instance.LoaiDonVis.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(string maloaidonvi)
		{
			try
			{
				var delitem = DataContext.Instance.LoaiDonVis.FirstOrDefault(item => item.MaLoaiDonVi == maloaidonvi );
				DataContext.Instance.LoaiDonVis.DeleteObject(delitem);
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

		public static List<LoaiDonVi> RetrieveByID(string maloaidonvi)
		{
			return (from item in DataContext.Instance.LoaiDonVis where  item.MaLoaiDonVi == maloaidonvi  select item).ToList();
		}

	}
}