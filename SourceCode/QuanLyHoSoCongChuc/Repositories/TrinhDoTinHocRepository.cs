using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class TrinhDoTinHocRepository
	{
		public List<TrinhDoTinHoc> SelectAll()
		{
			return DataContext.Instance.TrinhDoTinHocs.ToList();
		}

		public TrinhDoTinHoc SelectByID(string matrinhdotinhoc)
		{
			return DataContext.Instance.TrinhDoTinHocs.FirstOrDefault(item => item.MaTrinhDoTinHoc == matrinhdotinhoc );
		}

		public bool Insert(TrinhDoTinHoc obj)
		{
			try
			{
				DataContext.Instance.TrinhDoTinHocs.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Delete(string matrinhdotinhoc)
		{
			try
			{
				var delitem = DataContext.Instance.TrinhDoTinHocs.FirstOrDefault(item => item.MaTrinhDoTinHoc == matrinhdotinhoc );
				DataContext.Instance.TrinhDoTinHocs.DeleteObject(delitem);
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

		public List<TrinhDoTinHoc> RetrieveByID(string matrinhdotinhoc)
		{
			return (from item in DataContext.Instance.TrinhDoTinHocs where  item.MaTrinhDoTinHoc == matrinhdotinhoc  select item).ToList();
		}

	}
}