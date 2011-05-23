using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class PhanLoaiDonViRepository
	{
		public static List<PhanLoaiDonVi> SelectAll()
		{
			return DataContext.Instance.PhanLoaiDonVis.ToList();
		}

		public static PhanLoaiDonVi SelectByID(string maphanloai)
		{
			return DataContext.Instance.PhanLoaiDonVis.FirstOrDefault(item => item.MaPhanLoai == maphanloai );
		}

		public static bool Insert(PhanLoaiDonVi obj)
		{
			try
			{
				DataContext.Instance.PhanLoaiDonVis.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(string maphanloai)
		{
			try
			{
				var delitem = DataContext.Instance.PhanLoaiDonVis.FirstOrDefault(item => item.MaPhanLoai == maphanloai );
				DataContext.Instance.PhanLoaiDonVis.DeleteObject(delitem);
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

		public static List<PhanLoaiDonVi> RetrieveByID(string maphanloai)
		{
			return (from item in DataContext.Instance.PhanLoaiDonVis where  item.MaPhanLoai == maphanloai  select item).ToList();
		}

	}
}