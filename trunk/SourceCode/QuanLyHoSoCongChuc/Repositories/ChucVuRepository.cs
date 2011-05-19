using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class ChucVuRepository
	{
		public List<ChucVu> SelectAll()
		{
			return DataContext.Instance.ChucVus.ToList();
		}

		public ChucVu SelectByID(string machucvu)
		{
			return DataContext.Instance.ChucVus.FirstOrDefault(item => item.MaChucVu == machucvu );
		}

		public bool Insert(ChucVu obj)
		{
			try
			{
				DataContext.Instance.ChucVus.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Delete(string machucvu)
		{
			try
			{
				var delitem = DataContext.Instance.ChucVus.FirstOrDefault(item => item.MaChucVu == machucvu );
				DataContext.Instance.ChucVus.DeleteObject(delitem);
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

		public List<ChucVu> RetrieveByID(string machucvu)
		{
			return (from item in DataContext.Instance.ChucVus where  item.MaChucVu == machucvu  select item).ToList();
		}

	}
}