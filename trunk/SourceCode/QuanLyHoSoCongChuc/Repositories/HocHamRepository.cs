using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class HocHamRepository
	{
		public static List<HocHam> SelectAll()
		{
			return DataContext.Instance.HocHams.OrderBy(item => item.TenHocHam).ToList();
		}

		public static HocHam SelectByID(int mahocham)
		{
			return DataContext.Instance.HocHams.FirstOrDefault(item => item.MaHocHam == mahocham );
		}

		public static bool Insert(HocHam obj)
		{
			try
			{
				DataContext.Instance.HocHams.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int mahocham)
		{
			try
			{
				var delitem = DataContext.Instance.HocHams.FirstOrDefault(item => item.MaHocHam == mahocham );
				DataContext.Instance.HocHams.DeleteObject(delitem);
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

		public static List<HocHam> RetrieveByID(int mahocham)
		{
			return (from item in DataContext.Instance.HocHams where  item.MaHocHam == mahocham  select item).ToList();
		}

	}
}