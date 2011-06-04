using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class HinhThucBoDonViRepository
	{
		public static List<HinhThucBoDonVi> SelectAll()
		{
			return DataContext.Instance.HinhThucBoDonVis.OrderBy(item => item.TenHinhThuc).ToList();
		}

		public static HinhThucBoDonVi SelectByID(int mahinhthu)
		{
			return DataContext.Instance.HinhThucBoDonVis.FirstOrDefault(item => item.MaHinhThu == mahinhthu );
		}

		public static bool Insert(HinhThucBoDonVi obj)
		{
			try
			{
				DataContext.Instance.HinhThucBoDonVis.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int mahinhthu)
		{
			try
			{
				var delitem = DataContext.Instance.HinhThucBoDonVis.FirstOrDefault(item => item.MaHinhThu == mahinhthu );
				DataContext.Instance.HinhThucBoDonVis.DeleteObject(delitem);
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

		public static List<HinhThucBoDonVi> RetrieveByID(int mahinhthu)
		{
			return (from item in DataContext.Instance.HinhThucBoDonVis where  item.MaHinhThu == mahinhthu  select item).ToList();
		}

	}
}