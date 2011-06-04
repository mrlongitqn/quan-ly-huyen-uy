using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class HinhThucKhenThuongRepository
	{
		public static List<HinhThucKhenThuong> SelectAll()
		{
			return DataContext.Instance.HinhThucKhenThuongs.OrderBy(item => item.TenHinhThucKhenThuong).ToList();
		}

		public static HinhThucKhenThuong SelectByID(int mahinhthuckhenthuong)
		{
			return DataContext.Instance.HinhThucKhenThuongs.FirstOrDefault(item => item.MaHinhThucKhenThuong == mahinhthuckhenthuong );
		}

		public static bool Insert(HinhThucKhenThuong obj)
		{
			try
			{
				DataContext.Instance.HinhThucKhenThuongs.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int mahinhthuckhenthuong)
		{
			try
			{
				var delitem = DataContext.Instance.HinhThucKhenThuongs.FirstOrDefault(item => item.MaHinhThucKhenThuong == mahinhthuckhenthuong );
				DataContext.Instance.HinhThucKhenThuongs.DeleteObject(delitem);
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

		public static List<HinhThucKhenThuong> RetrieveByID(int mahinhthuckhenthuong)
		{
			return (from item in DataContext.Instance.HinhThucKhenThuongs where  item.MaHinhThucKhenThuong == mahinhthuckhenthuong  select item).ToList();
		}

	}
}