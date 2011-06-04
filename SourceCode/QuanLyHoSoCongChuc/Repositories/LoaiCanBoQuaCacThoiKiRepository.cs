using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class LoaiCanBoQuaCacThoiKiRepository
	{
		public static List<LoaiCanBoQuaCacThoiKi> SelectAll()
		{
			return DataContext.Instance.LoaiCanBoQuaCacThoiKis.OrderBy(item => item.TenLoaiCanBoQuaCacThoiKi).ToList();
		}

		public static LoaiCanBoQuaCacThoiKi SelectByID(int maloaicanboquacacthoikima)
		{
			return DataContext.Instance.LoaiCanBoQuaCacThoiKis.FirstOrDefault(item => item.MaLoaiCanBoQuaCacThoiKiMa == maloaicanboquacacthoikima );
		}

		public static bool Insert(LoaiCanBoQuaCacThoiKi obj)
		{
			try
			{
				DataContext.Instance.LoaiCanBoQuaCacThoiKis.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int maloaicanboquacacthoikima)
		{
			try
			{
				var delitem = DataContext.Instance.LoaiCanBoQuaCacThoiKis.FirstOrDefault(item => item.MaLoaiCanBoQuaCacThoiKiMa == maloaicanboquacacthoikima );
				DataContext.Instance.LoaiCanBoQuaCacThoiKis.DeleteObject(delitem);
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

		public static List<LoaiCanBoQuaCacThoiKi> RetrieveByID(int maloaicanboquacacthoikima)
		{
			return (from item in DataContext.Instance.LoaiCanBoQuaCacThoiKis where  item.MaLoaiCanBoQuaCacThoiKiMa == maloaicanboquacacthoikima  select item).ToList();
		}

	}
}