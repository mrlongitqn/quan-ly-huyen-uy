using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class KyLuatRepository
	{
		public static List<KyLuat> SelectAll()
		{
			return DataContext.Instance.KyLuats.ToList();
		}

		public static KyLuat SelectByID(int makyluat)
		{
			return DataContext.Instance.KyLuats.FirstOrDefault(item => item.MaKyLuat == makyluat );
		}

		public static bool Insert(KyLuat obj)
		{
			try
			{
				DataContext.Instance.KyLuats.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int makyluat)
		{
			try
			{
				var delitem = DataContext.Instance.KyLuats.FirstOrDefault(item => item.MaKyLuat == makyluat );
				DataContext.Instance.KyLuats.DeleteObject(delitem);
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

		public static List<KyLuat> RetrieveByID(int makyluat)
		{
			return (from item in DataContext.Instance.KyLuats where  item.MaKyLuat == makyluat  select item).ToList();
		}

		public static List<KyLuat> SelectByMaNhanVien(string manhanvien)
		{
			var lstItem = (from item in DataContext.Instance.KyLuats where item.MaNhanVien == manhanvien select item).ToList();
			return lstItem;
		}

		public static List<KyLuat> SelectByMaHinhThucKyLuat(int mahinhthuckyluat)
		{
			var lstItem = (from item in DataContext.Instance.KyLuats where item.MaHinhThucKyLuat == mahinhthuckyluat select item).ToList();
			return lstItem;
		}

		public static List<KyLuat> SelectByMaNoiDungViPham(int manoidungvipham)
		{
			var lstItem = (from item in DataContext.Instance.KyLuats where item.MaNoiDungViPham == manoidungvipham select item).ToList();
			return lstItem;
		}

	}
}