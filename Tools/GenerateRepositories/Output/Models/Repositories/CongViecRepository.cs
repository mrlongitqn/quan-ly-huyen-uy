using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class CongViecRepository
	{
		public static List<CongViec> SelectAll()
		{
			return DataContext.Instance.CongViecs.ToList();
		}

		public static CongViec SelectByID(string macongviec)
		{
			return DataContext.Instance.CongViecs.FirstOrDefault(item => item.MaCongViec == macongviec );
		}

		public static bool Insert(CongViec obj)
		{
			try
			{
				DataContext.Instance.CongViecs.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(string macongviec)
		{
			try
			{
				var delitem = DataContext.Instance.CongViecs.FirstOrDefault(item => item.MaCongViec == macongviec );
				DataContext.Instance.CongViecs.DeleteObject(delitem);
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

		public static List<CongViec> RetrieveByID(string macongviec)
		{
			return (from item in DataContext.Instance.CongViecs where  item.MaCongViec == macongviec  select item).ToList();
		}

	}
}