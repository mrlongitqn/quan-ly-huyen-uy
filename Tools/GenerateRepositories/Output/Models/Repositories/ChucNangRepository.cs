using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class ChucNangRepository
	{
		public static List<ChucNang> SelectAll()
		{
			return DataContext.Instance.ChucNangs.ToList();
		}

		public static ChucNang SelectByID(int machucnang)
		{
			return DataContext.Instance.ChucNangs.FirstOrDefault(item => item.MaChucNang == machucnang );
		}

		public static bool Insert(ChucNang obj)
		{
			try
			{
				DataContext.Instance.ChucNangs.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int machucnang)
		{
			try
			{
				var delitem = DataContext.Instance.ChucNangs.FirstOrDefault(item => item.MaChucNang == machucnang );
				DataContext.Instance.ChucNangs.DeleteObject(delitem);
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

		public static List<ChucNang> RetrieveByID(int machucnang)
		{
			return (from item in DataContext.Instance.ChucNangs where  item.MaChucNang == machucnang  select item).ToList();
		}

	}
}