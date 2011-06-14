using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class TuTranRepository
	{
		public static List<TuTran> SelectAll()
		{
			return DataContext.Instance.TuTrans.ToList();
		}

		public static TuTran SelectByID(int macanbo)
		{
			return DataContext.Instance.TuTrans.FirstOrDefault(item => item.MaCanBo == macanbo );
		}

		public static bool Insert(TuTran obj)
		{
			try
			{
				DataContext.Instance.TuTrans.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int macanbo)
		{
			try
			{
				var delitem = DataContext.Instance.TuTrans.FirstOrDefault(item => item.MaCanBo == macanbo );
				DataContext.Instance.TuTrans.DeleteObject(delitem);
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

		public static List<TuTran> RetrieveByID(int macanbo)
		{
			return (from item in DataContext.Instance.TuTrans where  item.MaCanBo == macanbo  select item).ToList();
		}

		public static List<TuTran> SelectByMaCanBo(int macanbo)
		{
			var lstItem = (from item in DataContext.Instance.TuTrans where item.MaCanBo == macanbo select item).ToList();
			return lstItem;
		}

		public static List<TuTran> SelectByMaLyDoTuTran(int malydotutran)
		{
			var lstItem = (from item in DataContext.Instance.TuTrans where item.MaLyDoTuTran == malydotutran select item).ToList();
			return lstItem;
		}

	}
}