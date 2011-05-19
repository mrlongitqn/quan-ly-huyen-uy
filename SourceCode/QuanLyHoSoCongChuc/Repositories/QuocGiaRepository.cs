using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class QuocGiaRepository
	{
		public List<QuocGia> SelectAll()
		{
			return DataContext.Instance.QuocGias.ToList();
		}

		public QuocGia SelectByID(int maquocgia)
		{
			return DataContext.Instance.QuocGias.FirstOrDefault(item => item.MaQuocGia == maquocgia );
		}

		public bool Insert(QuocGia obj)
		{
			try
			{
				DataContext.Instance.QuocGias.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Delete(int maquocgia)
		{
			try
			{
				var delitem = DataContext.Instance.QuocGias.FirstOrDefault(item => item.MaQuocGia == maquocgia );
				DataContext.Instance.QuocGias.DeleteObject(delitem);
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

		public List<QuocGia> RetrieveByID(int maquocgia)
		{
			return (from item in DataContext.Instance.QuocGias where  item.MaQuocGia == maquocgia  select item).ToList();
		}

	}
}