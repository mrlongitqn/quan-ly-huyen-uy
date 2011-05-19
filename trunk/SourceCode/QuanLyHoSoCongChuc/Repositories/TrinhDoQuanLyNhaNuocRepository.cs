using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class TrinhDoQuanLyNhaNuocRepository
	{
		public List<TrinhDoQuanLyNhaNuoc> SelectAll()
		{
			return DataContext.Instance.TrinhDoQuanLyNhaNuocs.ToList();
		}

		public TrinhDoQuanLyNhaNuoc SelectByID(string matrinhdoquanlynhanuoc)
		{
			return DataContext.Instance.TrinhDoQuanLyNhaNuocs.FirstOrDefault(item => item.MaTrinhDoQuanLyNhaNuoc == matrinhdoquanlynhanuoc );
		}

		public bool Insert(TrinhDoQuanLyNhaNuoc obj)
		{
			try
			{
				DataContext.Instance.TrinhDoQuanLyNhaNuocs.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Delete(string matrinhdoquanlynhanuoc)
		{
			try
			{
				var delitem = DataContext.Instance.TrinhDoQuanLyNhaNuocs.FirstOrDefault(item => item.MaTrinhDoQuanLyNhaNuoc == matrinhdoquanlynhanuoc );
				DataContext.Instance.TrinhDoQuanLyNhaNuocs.DeleteObject(delitem);
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

		public List<TrinhDoQuanLyNhaNuoc> RetrieveByID(string matrinhdoquanlynhanuoc)
		{
			return (from item in DataContext.Instance.TrinhDoQuanLyNhaNuocs where  item.MaTrinhDoQuanLyNhaNuoc == matrinhdoquanlynhanuoc  select item).ToList();
		}

	}
}