using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class LuongPhuCapRepository
	{
		public static List<LuongPhuCap> SelectAll()
		{
			return DataContext.Instance.LuongPhuCaps.ToList();
		}

		public static LuongPhuCap SelectByID(int maluongphucap)
		{
			return DataContext.Instance.LuongPhuCaps.FirstOrDefault(item => item.MaLuongPhuCap == maluongphucap );
		}

		public static bool Insert(LuongPhuCap obj)
		{
			try
			{
				DataContext.Instance.LuongPhuCaps.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int maluongphucap)
		{
			try
			{
				var delitem = DataContext.Instance.LuongPhuCaps.FirstOrDefault(item => item.MaLuongPhuCap == maluongphucap );
				DataContext.Instance.LuongPhuCaps.DeleteObject(delitem);
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

		public static List<LuongPhuCap> RetrieveByID(int maluongphucap)
		{
			return (from item in DataContext.Instance.LuongPhuCaps where  item.MaLuongPhuCap == maluongphucap  select item).ToList();
		}

		public static List<LuongPhuCap> SelectByMaNhanVien(string manhanvien)
		{
			var lstItem = (from item in DataContext.Instance.LuongPhuCaps where item.MaNhanVien == manhanvien select item).ToList();
			return lstItem;
		}

		public static List<LuongPhuCap> SelectByMaNgachCongChuc(string mangachcongchuc)
		{
			var lstItem = (from item in DataContext.Instance.LuongPhuCaps where item.MaNgachCongChuc == mangachcongchuc select item).ToList();
			return lstItem;
		}

		public static List<LuongPhuCap> SelectByMaHuong85(string mahuong85)
		{
			var lstItem = (from item in DataContext.Instance.LuongPhuCaps where item.MaHuong85 == mahuong85 select item).ToList();
			return lstItem;
		}

	}
}