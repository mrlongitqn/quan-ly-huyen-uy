using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class BangGiaoDucPhoThongRepository
	{
		public static List<BangGiaoDucPhoThong> SelectAll()
		{
			return DataContext.Instance.BangGiaoDucPhoThongs.OrderBy(item => item.TenBangGiaoDucPhoThong).ToList();
		}

		public static BangGiaoDucPhoThong SelectByID(int mabanggiaoducphothong)
		{
			return DataContext.Instance.BangGiaoDucPhoThongs.FirstOrDefault(item => item.MaBangGiaoDucPhoThong == mabanggiaoducphothong );
		}

		public static bool Insert(BangGiaoDucPhoThong obj)
		{
			try
			{
				DataContext.Instance.BangGiaoDucPhoThongs.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int mabanggiaoducphothong)
		{
			try
			{
				var delitem = DataContext.Instance.BangGiaoDucPhoThongs.FirstOrDefault(item => item.MaBangGiaoDucPhoThong == mabanggiaoducphothong );
				DataContext.Instance.BangGiaoDucPhoThongs.DeleteObject(delitem);
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

		public static List<BangGiaoDucPhoThong> RetrieveByID(int mabanggiaoducphothong)
		{
			return (from item in DataContext.Instance.BangGiaoDucPhoThongs where  item.MaBangGiaoDucPhoThong == mabanggiaoducphothong  select item).ToList();
		}

	}
}