using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class LoaiNguoiDungRepository
	{
		public static List<LoaiNguoiDung> SelectAll()
		{
			return DataContext.Instance.LoaiNguoiDungs.OrderBy(item => item.TenQuyen).ToList();
		}

		public static LoaiNguoiDung SelectByID(int maquyen)
		{
			return DataContext.Instance.LoaiNguoiDungs.FirstOrDefault(item => item.MaQuyen == maquyen );
		}

		public static bool Insert(LoaiNguoiDung obj)
		{
			try
			{
				DataContext.Instance.LoaiNguoiDungs.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int maquyen)
		{
			try
			{
				var delitem = DataContext.Instance.LoaiNguoiDungs.FirstOrDefault(item => item.MaQuyen == maquyen );
				DataContext.Instance.LoaiNguoiDungs.DeleteObject(delitem);
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

		public static List<LoaiNguoiDung> RetrieveByID(int maquyen)
		{
			return (from item in DataContext.Instance.LoaiNguoiDungs where  item.MaQuyen == maquyen  select item).ToList();
		}

	}
}