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
		public List<TonGiao> SelectAll()
		{
			return DataContext.Instance.TonGiaos.ToList();
		}

		public TonGiao SelectByID(string matongiao)
		{
			return DataContext.Instance.TonGiaos.FirstOrDefault(item => item.MaTonGiao == matongiao );
		}

		public bool Insert(TonGiao obj)
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

		public bool Delete(string matongiao)
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

		public List<TonGiao> RetrieveByID(string matongiao)
		{
			return (from item in DataContext.Instance.TonGiaos where  item.MaTonGiao == matongiao  select item).ToList();
		}

	}
}