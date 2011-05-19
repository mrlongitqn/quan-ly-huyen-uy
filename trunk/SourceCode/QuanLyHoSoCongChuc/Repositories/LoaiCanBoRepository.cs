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
			return DataContext.Instance.LoaiCanBoes.ToList();
		}

		public static LoaiCanBo SelectByID(string maloaicanbo)
		{
			return DataContext.Instance.LoaiCanBoes.FirstOrDefault(item => item.MaLoaiCanBo == maloaicanbo );
		}

		public static bool Insert(LoaiCanBo obj)
		{
			try
			{
				DataContext.Instance.LoaiCanBoes.AddObject(obj);
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
				var delitem = DataContext.Instance.LoaiCanBoes.FirstOrDefault(item => item.MaLoaiCanBo == maloaicanbo );
				DataContext.Instance.LoaiCanBoes.DeleteObject(delitem);
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
			return (from item in DataContext.Instance.LoaiCanBoes where  item.MaLoaiCanBo == maloaicanbo  select item).ToList();
		}

	}
}