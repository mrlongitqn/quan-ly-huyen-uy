using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class ThanhPhanGiaDinhRepository
	{
		public static List<ThanhPhanGiaDinh> SelectAll()
		{
			return DataContext.Instance.ThanhPhanGiaDinhs.OrderBy(item => item.TenThanhPhanGiaDinh).ToList();
		}

		public static ThanhPhanGiaDinh SelectByID(int mathanhphangiadinh)
		{
			return DataContext.Instance.ThanhPhanGiaDinhs.FirstOrDefault(item => item.MaThanhPhanGiaDinh == mathanhphangiadinh );
		}

		public static bool Insert(ThanhPhanGiaDinh obj)
		{
			try
			{
				DataContext.Instance.ThanhPhanGiaDinhs.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int mathanhphangiadinh)
		{
			try
			{
				var delitem = DataContext.Instance.ThanhPhanGiaDinhs.FirstOrDefault(item => item.MaThanhPhanGiaDinh == mathanhphangiadinh );
				DataContext.Instance.ThanhPhanGiaDinhs.DeleteObject(delitem);
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

		public static List<ThanhPhanGiaDinh> RetrieveByID(int mathanhphangiadinh)
		{
			return (from item in DataContext.Instance.ThanhPhanGiaDinhs where  item.MaThanhPhanGiaDinh == mathanhphangiadinh  select item).ToList();
		}

	}
}