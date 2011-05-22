using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class KhoiXomRepository
	{
		public static List<KhoiXom> SelectAll()
		{
			return DataContext.Instance.KhoiXoms.ToList();
		}

		public static KhoiXom SelectByID(string makhoixom)
		{
			return DataContext.Instance.KhoiXoms.FirstOrDefault(item => item.MaKhoiXom == makhoixom );
		}

		public static bool Insert(KhoiXom obj)
		{
			try
			{
				DataContext.Instance.KhoiXoms.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(string makhoixom)
		{
			try
			{
				var delitem = DataContext.Instance.KhoiXoms.FirstOrDefault(item => item.MaKhoiXom == makhoixom );
				DataContext.Instance.KhoiXoms.DeleteObject(delitem);
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

		public static List<KhoiXom> RetrieveByID(string makhoixom)
		{
			return (from item in DataContext.Instance.KhoiXoms where  item.MaKhoiXom == makhoixom  select item).ToList();
		}

		public static List<KhoiXom> SelectByMaPhuongXa(string maphuongxa)
		{
			var lstItem = (from item in DataContext.Instance.KhoiXoms where item.MaPhuongXa == maphuongxa select item).ToList();
			return lstItem;
		}

	}
}