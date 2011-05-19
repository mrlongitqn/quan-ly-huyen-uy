using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class TrinhDoNgoaiNguRepository
	{
		public List<TrinhDoNgoaiNgu> SelectAll()
		{
			return DataContext.Instance.TrinhDoNgoaiNgus.ToList();
		}

		public TrinhDoNgoaiNgu SelectByID(string matrinhdongoaingu)
		{
			return DataContext.Instance.TrinhDoNgoaiNgus.FirstOrDefault(item => item.MaTrinhDoNgoaiNgu == matrinhdongoaingu );
		}

		public bool Insert(TrinhDoNgoaiNgu obj)
		{
			try
			{
				DataContext.Instance.TrinhDoNgoaiNgus.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Delete(string matrinhdongoaingu)
		{
			try
			{
				var delitem = DataContext.Instance.TrinhDoNgoaiNgus.FirstOrDefault(item => item.MaTrinhDoNgoaiNgu == matrinhdongoaingu );
				DataContext.Instance.TrinhDoNgoaiNgus.DeleteObject(delitem);
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

		public List<TrinhDoNgoaiNgu> RetrieveByID(string matrinhdongoaingu)
		{
			return (from item in DataContext.Instance.TrinhDoNgoaiNgus where  item.MaTrinhDoNgoaiNgu == matrinhdongoaingu  select item).ToList();
		}

	}
}