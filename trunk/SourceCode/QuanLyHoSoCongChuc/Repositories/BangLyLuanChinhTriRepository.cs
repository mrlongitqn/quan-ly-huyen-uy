using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class BangLyLuanChinhTriRepository
	{
		public static List<BangLyLuanChinhTri> SelectAll()
		{
			return DataContext.Instance.BangLyLuanChinhTris.OrderBy(item => item.TenBangLyLuanChinhTri).ToList();
		}

		public static BangLyLuanChinhTri SelectByID(int mabanglyluanchinhtri)
		{
			return DataContext.Instance.BangLyLuanChinhTris.FirstOrDefault(item => item.MaBangLyLuanChinhTri == mabanglyluanchinhtri );
		}

		public static bool Insert(BangLyLuanChinhTri obj)
		{
			try
			{
				DataContext.Instance.BangLyLuanChinhTris.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int mabanglyluanchinhtri)
		{
			try
			{
				var delitem = DataContext.Instance.BangLyLuanChinhTris.FirstOrDefault(item => item.MaBangLyLuanChinhTri == mabanglyluanchinhtri );
				DataContext.Instance.BangLyLuanChinhTris.DeleteObject(delitem);
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

		public static List<BangLyLuanChinhTri> RetrieveByID(int mabanglyluanchinhtri)
		{
			return (from item in DataContext.Instance.BangLyLuanChinhTris where  item.MaBangLyLuanChinhTri == mabanglyluanchinhtri  select item).ToList();
		}

	}
}