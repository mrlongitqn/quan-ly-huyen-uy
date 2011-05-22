using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class LoaiCanBoRepository
	{
		public static List<LoaiCanBo> SelectAll()
		{
			return DataContext.Instance.LoaiCanBos.ToList();
		}

		public static LoaiCanBo SelectByID(string maloaicanbo)
		{
			return DataContext.Instance.LoaiCanBos.FirstOrDefault(item => item.MaLoaiCanBo == maloaicanbo );
		}

		public static bool Insert(LoaiCanBo obj)
		{
			try
			{
				DataContext.Instance.LoaiCanBos.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(string maloaicanbo)
		{
			try
			{
				var delitem = DataContext.Instance.LoaiCanBos.FirstOrDefault(item => item.MaLoaiCanBo == maloaicanbo );
				DataContext.Instance.LoaiCanBos.DeleteObject(delitem);
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

		public static List<LoaiCanBo> RetrieveByID(string maloaicanbo)
		{
			return (from item in DataContext.Instance.LoaiCanBos where  item.MaLoaiCanBo == maloaicanbo  select item).ToList();
		}

	}
}