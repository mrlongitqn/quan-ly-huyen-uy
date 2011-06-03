using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class HinhThucDaoTaoRepository
	{
		public static List<HinhThucDaoTao> SelectAll()
		{
			return DataContext.Instance.HinhThucDaoTaos.ToList();
		}

		public static HinhThucDaoTao SelectByID(int mahinhthucdaotao)
		{
			return DataContext.Instance.HinhThucDaoTaos.FirstOrDefault(item => item.MaHinhThucDaoTao == mahinhthucdaotao );
		}

		public static bool Insert(HinhThucDaoTao obj)
		{
			try
			{
				DataContext.Instance.HinhThucDaoTaos.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int mahinhthucdaotao)
		{
			try
			{
				var delitem = DataContext.Instance.HinhThucDaoTaos.FirstOrDefault(item => item.MaHinhThucDaoTao == mahinhthucdaotao );
				DataContext.Instance.HinhThucDaoTaos.DeleteObject(delitem);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Save()
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

		public static List<HinhThucDaoTao> RetrieveByID(int mahinhthucdaotao)
		{
			return (from item in DataContext.Instance.HinhThucDaoTaos where  item.MaHinhThucDaoTao == mahinhthucdaotao  select item).ToList();
		}

	}
}