using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class HoanCanhKinhTeRepository
	{
		public List<HoanCanhKinhTe> SelectAll()
		{
			return DataContext.Instance.HoanCanhKinhTes.ToList();
		}

		public HoanCanhKinhTe SelectByID(int mahoancanhkinhte)
		{
			return DataContext.Instance.HoanCanhKinhTes.FirstOrDefault(item => item.MaHoanCanhKinhTe == mahoancanhkinhte );
		}

		public bool Insert(HoanCanhKinhTe obj)
		{
			try
			{
				DataContext.Instance.HoanCanhKinhTes.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Delete(int mahoancanhkinhte)
		{
			try
			{
				var delitem = DataContext.Instance.HoanCanhKinhTes.FirstOrDefault(item => item.MaHoanCanhKinhTe == mahoancanhkinhte );
				DataContext.Instance.HoanCanhKinhTes.DeleteObject(delitem);
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

		public List<HoanCanhKinhTe> RetrieveByID(int mahoancanhkinhte)
		{
			return (from item in DataContext.Instance.HoanCanhKinhTes where  item.MaHoanCanhKinhTe == mahoancanhkinhte  select item).ToList();
		}

		public List<HoanCanhKinhTe> SelectByNhanVien(string manhanvien, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.HoanCanhKinhTes where item.MaNhanVien == manhanvien select item).ToList();
			return lstItem;
		}

		public List<HoanCanhKinhTe> SelectByHoatDongKinhTe(string mahoatdongkinhte, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.HoanCanhKinhTes where item.MaHoatDongKinhTe == mahoatdongkinhte select item).ToList();
			return lstItem;
		}

	}
}