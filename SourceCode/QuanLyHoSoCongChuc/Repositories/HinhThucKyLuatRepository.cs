using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class HinhThucKyLuatRepository
	{
		public static List<HinhThucKyLuat> SelectAll()
		{
			return DataContext.Instance.HinhThucKyLuats.OrderBy(item => item.TenHinhThucKyLuat).ToList();
		}

		public static HinhThucKyLuat SelectByID(int mahinhthuckyluat)
		{
			return DataContext.Instance.HinhThucKyLuats.FirstOrDefault(item => item.MaHinhThucKyLuat == mahinhthuckyluat );
		}

		public static bool Insert(HinhThucKyLuat obj)
		{
			try
			{
				DataContext.Instance.HinhThucKyLuats.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int mahinhthuckyluat)
		{
			try
			{
				var delitem = DataContext.Instance.HinhThucKyLuats.FirstOrDefault(item => item.MaHinhThucKyLuat == mahinhthuckyluat );
				DataContext.Instance.HinhThucKyLuats.DeleteObject(delitem);
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

		public static List<HinhThucKyLuat> RetrieveByID(int mahinhthuckyluat)
		{
			return (from item in DataContext.Instance.HinhThucKyLuats where  item.MaHinhThucKyLuat == mahinhthuckyluat  select item).ToList();
		}

	}
}