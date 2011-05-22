using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class TrinhDoChuyenMonRepository
	{
		public static List<TrinhDoChuyenMon> SelectAll()
		{
			return DataContext.Instance.TrinhDoChuyenMons.ToList();
		}

		public static TrinhDoChuyenMon SelectByID(string matrinhdochuyenmon)
		{
			return DataContext.Instance.TrinhDoChuyenMons.FirstOrDefault(item => item.MaTrinhDoChuyenMon == matrinhdochuyenmon );
		}

		public static bool Insert(TrinhDoChuyenMon obj)
		{
			try
			{
				DataContext.Instance.TrinhDoChuyenMons.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(string matrinhdochuyenmon)
		{
			try
			{
				var delitem = DataContext.Instance.TrinhDoChuyenMons.FirstOrDefault(item => item.MaTrinhDoChuyenMon == matrinhdochuyenmon );
				DataContext.Instance.TrinhDoChuyenMons.DeleteObject(delitem);
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

		public static List<TrinhDoChuyenMon> RetrieveByID(string matrinhdochuyenmon)
		{
			return (from item in DataContext.Instance.TrinhDoChuyenMons where  item.MaTrinhDoChuyenMon == matrinhdochuyenmon  select item).ToList();
		}

	}
}