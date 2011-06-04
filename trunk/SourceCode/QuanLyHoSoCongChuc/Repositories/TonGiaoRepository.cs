using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class TonGiaoRepository
	{
		public static List<TonGiao> SelectAll()
		{
			return DataContext.Instance.TonGiaos.OrderBy(item => item.TenTonGiao).ToList();
		}

		public static TonGiao SelectByID(int matongiao)
		{
			return DataContext.Instance.TonGiaos.FirstOrDefault(item => item.MaTonGiao == matongiao );
		}

		public static bool Insert(TonGiao obj)
		{
			try
			{
				DataContext.Instance.TonGiaos.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int matongiao)
		{
			try
			{
				var delitem = DataContext.Instance.TonGiaos.FirstOrDefault(item => item.MaTonGiao == matongiao );
				DataContext.Instance.TonGiaos.DeleteObject(delitem);
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

		public static List<TonGiao> RetrieveByID(int matongiao)
		{
			return (from item in DataContext.Instance.TonGiaos where  item.MaTonGiao == matongiao  select item).ToList();
		}

	}
}