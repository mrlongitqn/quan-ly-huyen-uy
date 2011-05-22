using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class DienUuTienGiaDinhRepository
	{
		public static List<DienUuTienGiaDinh> SelectAll()
		{
			return DataContext.Instance.DienUuTienGiaDinhs.ToList();
		}

		public static DienUuTienGiaDinh SelectByID(string madienuutiengiadinh)
		{
			return DataContext.Instance.DienUuTienGiaDinhs.FirstOrDefault(item => item.MaDienUuTienGiaDinh == madienuutiengiadinh );
		}

		public static bool Insert(DienUuTienGiaDinh obj)
		{
			try
			{
				DataContext.Instance.DienUuTienGiaDinhs.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(string madienuutiengiadinh)
		{
			try
			{
				var delitem = DataContext.Instance.DienUuTienGiaDinhs.FirstOrDefault(item => item.MaDienUuTienGiaDinh == madienuutiengiadinh );
				DataContext.Instance.DienUuTienGiaDinhs.DeleteObject(delitem);
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

		public static List<DienUuTienGiaDinh> RetrieveByID(string madienuutiengiadinh)
		{
			return (from item in DataContext.Instance.DienUuTienGiaDinhs where  item.MaDienUuTienGiaDinh == madienuutiengiadinh  select item).ToList();
		}

	}
}