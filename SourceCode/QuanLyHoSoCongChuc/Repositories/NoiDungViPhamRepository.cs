using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class NoiDungViPhamRepository
	{
		public static List<NoiDungViPham> SelectAll()
		{
			return DataContext.Instance.NoiDungViPhams.OrderBy(item => item.TenNoiDungViPham).ToList();
		}

		public static NoiDungViPham SelectByID(int manoidungvipham)
		{
			return DataContext.Instance.NoiDungViPhams.FirstOrDefault(item => item.MaNoiDungViPham == manoidungvipham );
		}

		public static bool Insert(NoiDungViPham obj)
		{
			try
			{
				DataContext.Instance.NoiDungViPhams.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int manoidungvipham)
		{
			try
			{
				var delitem = DataContext.Instance.NoiDungViPhams.FirstOrDefault(item => item.MaNoiDungViPham == manoidungvipham );
				DataContext.Instance.NoiDungViPhams.DeleteObject(delitem);
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

		public static List<NoiDungViPham> RetrieveByID(int manoidungvipham)
		{
			return (from item in DataContext.Instance.NoiDungViPhams where  item.MaNoiDungViPham == manoidungvipham  select item).ToList();
		}

	}
}