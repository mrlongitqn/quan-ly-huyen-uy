using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class ChucNangSuDungRepository
	{
		public static List<ChucNangSuDung> SelectAll()
		{
			return DataContext.Instance.ChucNangSuDungs.OrderBy(item => item.TenChucNang).ToList();
		}

		public static ChucNangSuDung SelectByID(int machucnangsudung)
		{
			return DataContext.Instance.ChucNangSuDungs.FirstOrDefault(item => item.MaChucNangSuDung == machucnangsudung );
		}

		public static bool Insert(ChucNangSuDung obj)
		{
			try
			{
				DataContext.Instance.ChucNangSuDungs.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int machucnangsudung)
		{
			try
			{
				var delitem = DataContext.Instance.ChucNangSuDungs.FirstOrDefault(item => item.MaChucNangSuDung == machucnangsudung );
				DataContext.Instance.ChucNangSuDungs.DeleteObject(delitem);
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

		public static List<ChucNangSuDung> RetrieveByID(int machucnangsudung)
		{
			return (from item in DataContext.Instance.ChucNangSuDungs where  item.MaChucNangSuDung == machucnangsudung  select item).ToList();
		}

		public static List<ChucNangSuDung> SelectByMaNhatKyItem(int manhatkyitem)
		{
			var lstItem = (from item in DataContext.Instance.ChucNangSuDungs where item.MaNhatKyItem == manhatkyitem select item).ToList();
			return lstItem;
		}

	}
}