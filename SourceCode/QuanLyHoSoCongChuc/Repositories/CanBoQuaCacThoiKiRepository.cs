using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class CanBoQuaCacThoiKiRepository
	{
		public static List<CanBoQuaCacThoiKi> SelectAll()
		{
			return DataContext.Instance.CanBoQuaCacThoiKis.ToList();
		}

		public static CanBoQuaCacThoiKi SelectByID(int macanbo)
		{
			return DataContext.Instance.CanBoQuaCacThoiKis.FirstOrDefault(item => item.MaCanBo == macanbo );
		}

		public static bool Insert(CanBoQuaCacThoiKi obj)
		{
			try
			{
				DataContext.Instance.CanBoQuaCacThoiKis.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int macanbo)
		{
			try
			{
				var delitem = DataContext.Instance.CanBoQuaCacThoiKis.FirstOrDefault(item => item.MaCanBo == macanbo );
				DataContext.Instance.CanBoQuaCacThoiKis.DeleteObject(delitem);
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

		public static List<CanBoQuaCacThoiKi> RetrieveByID(int macanbo)
		{
			return (from item in DataContext.Instance.CanBoQuaCacThoiKis where  item.MaCanBo == macanbo  select item).ToList();
		}

        /// <summary>
        /// Search can bo qua cac thoi ki
        /// </summary>
        /// <param name="nhanvien"></param>
        /// <returns></returns>
        public static List<CanBoQuaCacThoiKi> SearchCanBoQuaCacThoiKi(CanBoQuaCacThoiKiModel canbo)
        {
            var lst = (from item in DataContext.Instance.CanBoQuaCacThoiKis
                       where
                        item.MaDonVi == (canbo.MaDonVi == "" ? item.MaDonVi : canbo.MaDonVi) &&
                        item.HoTen == (canbo.HoTen == "" ? item.HoTen : canbo.HoTen)
                       select item).ToList();
            return lst;
        }
	}
}