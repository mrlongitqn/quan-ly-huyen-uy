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
		public List<PhuongXa> SelectAll()
		{
			return DataContext.Instance.PhuongXas.ToList();
		}

		public PhuongXa SelectByID(string maphuongxa)
		{
			return DataContext.Instance.PhuongXas.FirstOrDefault(item => item.MaPhuongXa == maphuongxa );
		}

		public bool Insert(PhuongXa obj)
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

		public bool Delete(string maphuongxa)
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

		public List<PhuongXa> RetrieveByID(string maphuongxa)
		{
			return (from item in DataContext.Instance.PhuongXas where  item.MaPhuongXa == maphuongxa  select item).ToList();
		}

		public List<PhuongXa> SelectByQuanHuyen(string maquanhuyen, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.PhuongXas where item.MaQuanHuyen == maquanhuyen select item).ToList();
			return lstItem;
		}

	}
}