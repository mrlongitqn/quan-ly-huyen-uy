using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class TinhTrangSucKhoeRepository
	{
		public static List<TinhTrangSucKhoe> SelectAll()
		{
			return DataContext.Instance.TinhTrangSucKhoes.OrderBy(item => item.TenTinhTrangSucKhoe).ToList();
		}

		public static TinhTrangSucKhoe SelectByID(int matinhtrangsuckhoe)
		{
			return DataContext.Instance.TinhTrangSucKhoes.FirstOrDefault(item => item.MaTinhTrangSucKhoe == matinhtrangsuckhoe );
		}

		public static bool Insert(TinhTrangSucKhoe obj)
		{
			try
			{
				DataContext.Instance.TinhTrangSucKhoes.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int matinhtrangsuckhoe)
		{
			try
			{
				var delitem = DataContext.Instance.TinhTrangSucKhoes.FirstOrDefault(item => item.MaTinhTrangSucKhoe == matinhtrangsuckhoe );
				DataContext.Instance.TinhTrangSucKhoes.DeleteObject(delitem);
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

		public static List<TinhTrangSucKhoe> RetrieveByID(int matinhtrangsuckhoe)
		{
			return (from item in DataContext.Instance.TinhTrangSucKhoes where  item.MaTinhTrangSucKhoe == matinhtrangsuckhoe  select item).ToList();
		}

	}
}