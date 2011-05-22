using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class NguoiDungRepository
	{
		public static List<NguoiDung> SelectAll()
		{
			return DataContext.Instance.NguoiDungs.ToList();
		}

		public static NguoiDung SelectByID(string manguoidung)
		{
			return DataContext.Instance.NguoiDungs.FirstOrDefault(item => item.MaNguoiDung == manguoidung );
		}

		public static bool Insert(NguoiDung obj)
		{
			try
			{
				DataContext.Instance.NguoiDungs.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(string manguoidung)
		{
			try
			{
				var delitem = DataContext.Instance.NguoiDungs.FirstOrDefault(item => item.MaNguoiDung == manguoidung );
				DataContext.Instance.NguoiDungs.DeleteObject(delitem);
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

		public static List<NguoiDung> RetrieveByID(string manguoidung)
		{
			return (from item in DataContext.Instance.NguoiDungs where  item.MaNguoiDung == manguoidung  select item).ToList();
		}

	}
}