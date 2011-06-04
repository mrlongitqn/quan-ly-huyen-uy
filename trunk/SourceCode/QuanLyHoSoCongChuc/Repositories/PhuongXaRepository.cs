using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class PhuongXaRepository
	{
		public static List<PhuongXa> SelectAll()
		{
			return DataContext.Instance.PhuongXas.OrderBy(item => item.TenPhuongXa).ToList();
		}

		public static PhuongXa SelectByID(string maphuongxa)
		{
			return DataContext.Instance.PhuongXas.FirstOrDefault(item => item.MaPhuongXa == maphuongxa );
		}

		public static bool Insert(PhuongXa obj)
		{
			try
			{
				DataContext.Instance.PhuongXas.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(string maphuongxa)
		{
			try
			{
				var delitem = DataContext.Instance.PhuongXas.FirstOrDefault(item => item.MaPhuongXa == maphuongxa );
				DataContext.Instance.PhuongXas.DeleteObject(delitem);
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

		public static List<PhuongXa> RetrieveByID(string maphuongxa)
		{
			return (from item in DataContext.Instance.PhuongXas where  item.MaPhuongXa == maphuongxa  select item).ToList();
		}

		public static List<PhuongXa> SelectByMaQuanHuyen(string maquanhuyen)
		{
			var lstItem = (from item in DataContext.Instance.PhuongXas where item.MaQuanHuyen == maquanhuyen select item).ToList();
			return lstItem;
		}

	}
}