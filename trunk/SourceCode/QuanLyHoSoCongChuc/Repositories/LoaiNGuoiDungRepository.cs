using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class LoaiNGuoiDungRepository
	{
		public List<LoaiNGuoiDung> SelectAll()
		{
			return DataContext.Instance.LoaiNGuoiDungs.ToList();
		}

		public LoaiNGuoiDung SelectByID(int maquyen)
		{
			return DataContext.Instance.LoaiNGuoiDungs.FirstOrDefault(item => item.MaQuyen == maquyen );
		}

		public bool Insert(LoaiNGuoiDung obj)
		{
			try
			{
				DataContext.Instance.LoaiNGuoiDungs.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Delete(int maquyen)
		{
			try
			{
				var delitem = DataContext.Instance.LoaiNGuoiDungs.FirstOrDefault(item => item.MaQuyen == maquyen );
				DataContext.Instance.LoaiNGuoiDungs.DeleteObject(delitem);
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

		public List<LoaiNGuoiDung> RetrieveByID(int maquyen)
		{
			return (from item in DataContext.Instance.LoaiNGuoiDungs where  item.MaQuyen == maquyen  select item).ToList();
		}

	}
}