using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class QuaTrinhDaoTaoRepository
	{
		public List<QuaTrinhDaoTao> SelectAll()
		{
			return DataContext.Instance.QuaTrinhDaoTaos.ToList();
		}

		public QuaTrinhDaoTao SelectByID(string maquatrinhdaotao)
		{
			return DataContext.Instance.QuaTrinhDaoTaos.FirstOrDefault(item => item.MaQuaTrinhDaoTao == maquatrinhdaotao );
		}

		public bool Insert(QuaTrinhDaoTao obj)
		{
			try
			{
				DataContext.Instance.QuaTrinhDaoTaos.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Delete(string maquatrinhdaotao)
		{
			try
			{
				var delitem = DataContext.Instance.QuaTrinhDaoTaos.FirstOrDefault(item => item.MaQuaTrinhDaoTao == maquatrinhdaotao );
				DataContext.Instance.QuaTrinhDaoTaos.DeleteObject(delitem);
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

		public List<QuaTrinhDaoTao> RetrieveByID(string maquatrinhdaotao)
		{
			return (from item in DataContext.Instance.QuaTrinhDaoTaos where  item.MaQuaTrinhDaoTao == maquatrinhdaotao  select item).ToList();
		}

		public List<QuaTrinhDaoTao> SelectByNhanVien(string manhanvien, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.QuaTrinhDaoTaos where item.MaNhanVien == manhanvien select item).ToList();
			return lstItem;
		}

	}
}