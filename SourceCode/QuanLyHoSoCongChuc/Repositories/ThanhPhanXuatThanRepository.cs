using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class ThanhPhanXuatThanRepository
	{
		public List<ThanhPhanXuatThan> SelectAll()
		{
			return DataContext.Instance.ThanhPhanXuatThans.ToList();
		}

		public ThanhPhanXuatThan SelectByID(string mathanhphanxuatthan)
		{
			return DataContext.Instance.ThanhPhanXuatThans.FirstOrDefault(item => item.MaThanhPhanXuatThan == mathanhphanxuatthan );
		}

		public bool Insert(ThanhPhanXuatThan obj)
		{
			try
			{
				DataContext.Instance.ThanhPhanXuatThans.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Delete(string mathanhphanxuatthan)
		{
			try
			{
				var delitem = DataContext.Instance.ThanhPhanXuatThans.FirstOrDefault(item => item.MaThanhPhanXuatThan == mathanhphanxuatthan );
				DataContext.Instance.ThanhPhanXuatThans.DeleteObject(delitem);
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

		public List<ThanhPhanXuatThan> RetrieveByID(string mathanhphanxuatthan)
		{
			return (from item in DataContext.Instance.ThanhPhanXuatThans where  item.MaThanhPhanXuatThan == mathanhphanxuatthan  select item).ToList();
		}

	}
}