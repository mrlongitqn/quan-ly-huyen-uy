using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class NhatKyRepository
	{
		public static List<NhatKy> SelectAll()
		{
			return DataContext.Instance.NhatKies.ToList();
		}

		public static NhatKy SelectByID(int manhatky)
		{
			return DataContext.Instance.NhatKies.FirstOrDefault(item => item.MaNhatKy == manhatky );
		}

		public static bool Insert(NhatKy obj)
		{
			try
			{
				DataContext.Instance.NhatKies.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int manhatky)
		{
			try
			{
				var delitem = DataContext.Instance.NhatKies.FirstOrDefault(item => item.MaNhatKy == manhatky );
				DataContext.Instance.NhatKies.DeleteObject(delitem);
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

		public static List<NhatKy> RetrieveByID(int manhatky)
		{
			return (from item in DataContext.Instance.NhatKies where  item.MaNhatKy == manhatky  select item).ToList();
		}

		public static List<NhatKy> SelectByMaNguoiDung(int manguoidung)
		{
			var lstItem = (from item in DataContext.Instance.NhatKies where item.MaNguoiDung == manguoidung select item).ToList();
			return lstItem;
		}

	}
}