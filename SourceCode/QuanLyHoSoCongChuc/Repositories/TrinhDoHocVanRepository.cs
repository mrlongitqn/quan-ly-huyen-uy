using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class TrinhDoHocVanRepository
	{
		public List<TrinhDoHocVan> SelectAll()
		{
			return DataContext.Instance.TrinhDoHocVans.ToList();
		}

		public TrinhDoHocVan SelectByID(string matrinhdohocvan)
		{
			return DataContext.Instance.TrinhDoHocVans.FirstOrDefault(item => item.MaTrinhDoHocVan == matrinhdohocvan );
		}

		public bool Insert(TrinhDoHocVan obj)
		{
			try
			{
				DataContext.Instance.TrinhDoHocVans.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Delete(string matrinhdohocvan)
		{
			try
			{
				var delitem = DataContext.Instance.TrinhDoHocVans.FirstOrDefault(item => item.MaTrinhDoHocVan == matrinhdohocvan );
				DataContext.Instance.TrinhDoHocVans.DeleteObject(delitem);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Save()
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

		public List<TrinhDoHocVan> RetrieveByID(string matrinhdohocvan)
		{
			return (from item in DataContext.Instance.TrinhDoHocVans where  item.MaTrinhDoHocVan == matrinhdohocvan  select item).ToList();
		}

	}
}