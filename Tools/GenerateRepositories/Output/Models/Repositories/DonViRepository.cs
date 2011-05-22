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
		public static List<DonVi> SelectAll()
		{
			return DataContext.Instance.DonVis.ToList();
		}

		public static DonVi SelectByID(string madonvi)
		{
			return DataContext.Instance.DonVis.FirstOrDefault(item => item.MaDonVi == madonvi );
		}

		public static bool Insert(DonVi obj)
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

		public static bool Delete(string madonvi)
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

		public static List<DonVi> RetrieveByID(string madonvi)
		{
			return (from item in DataContext.Instance.DonVis where  item.MaDonVi == madonvi  select item).ToList();
		}

		public static List<DonVi> SelectByMaLoaiDonVi(string maloaidonvi)
		{
			var lstItem = (from item in DataContext.Instance.DonVis where item.MaLoaiDonVi == maloaidonvi select item).ToList();
			return lstItem;
		}

		public static List<DonVi> SelectByMaQuanHuyen(string maquanhuyen)
		{
			var lstItem = (from item in DataContext.Instance.DonVis where item.MaQuanHuyen == maquanhuyen select item).ToList();
			return lstItem;
		}

		public static List<DonVi> SelectByMaPhanLoaiDonVi(string maphanloaidonvi)
		{
			var lstItem = (from item in DataContext.Instance.DonVis where item.MaPhanLoaiDonVi == maphanloaidonvi select item).ToList();
			return lstItem;
		}

	}
}