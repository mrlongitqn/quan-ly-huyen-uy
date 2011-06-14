using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class LyDoTuTranRepository
	{
		public static List<LyDoTuTran> SelectAll()
		{
			return DataContext.Instance.LyDoTuTrans.OrderBy(item => item.TenLyDoTuTran).ToList();
		}

		public static LyDoTuTran SelectByID(int malydotutran)
		{
			return DataContext.Instance.LyDoTuTrans.FirstOrDefault(item => item.MaLyDoTuTran == malydotutran );
		}

		public static bool Insert(LyDoTuTran obj)
		{
			try
			{
				DataContext.Instance.LyDoTuTrans.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int malydotutran)
		{
			try
			{
				var delitem = DataContext.Instance.LyDoTuTrans.FirstOrDefault(item => item.MaLyDoTuTran == malydotutran );
				DataContext.Instance.LyDoTuTrans.DeleteObject(delitem);
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

		public static List<LyDoTuTran> RetrieveByID(int malydotutran)
		{
			return (from item in DataContext.Instance.LyDoTuTrans where  item.MaLyDoTuTran == malydotutran  select item).ToList();
		}

	}
}