using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class DangHocBoiDuongDaoTaoRepository
	{
		public static List<DangHocBoiDuongDaoTao> SelectAll()
		{
			return DataContext.Instance.DangHocBoiDuongDaoTaos.ToList();
		}

		public static DangHocBoiDuongDaoTao SelectByID(string madtbd)
		{
			return DataContext.Instance.DangHocBoiDuongDaoTaos.FirstOrDefault(item => item.MaDTBD == madtbd );
		}

		public static bool Insert(DangHocBoiDuongDaoTao obj)
		{
			try
			{
				DataContext.Instance.DangHocBoiDuongDaoTaos.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(string madtbd)
		{
			try
			{
				var delitem = DataContext.Instance.DangHocBoiDuongDaoTaos.FirstOrDefault(item => item.MaDTBD == madtbd );
				DataContext.Instance.DangHocBoiDuongDaoTaos.DeleteObject(delitem);
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

		public static List<DangHocBoiDuongDaoTao> RetrieveByID(string madtbd)
		{
			return (from item in DataContext.Instance.DangHocBoiDuongDaoTaos where  item.MaDTBD == madtbd  select item).ToList();
		}

	}
}