using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class NguoiDungRepository
	{
		public static List<NguoiDung> SelectAll()
		{
			return DataContext.Instance.NguoiDungs.OrderBy(item => item.TenNguoiDung).ToList();
		}

		public static NguoiDung SelectByID(int manguoidung)
		{
			return DataContext.Instance.NguoiDungs.FirstOrDefault(item => item.MaNguoiDung == manguoidung );
		}

        public static NguoiDung SelectByTenDangNhap(string tendangnhap)
        {
            return DataContext.Instance.NguoiDungs.FirstOrDefault(item => item.TenDangNhap == tendangnhap);
        }

		public static bool Insert(NguoiDung obj)
		{
			try
			{
				DataContext.Instance.NguoiDungs.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int manguoidung)
		{
			try
			{
				var delitem = DataContext.Instance.NguoiDungs.FirstOrDefault(item => item.MaNguoiDung == manguoidung );
				DataContext.Instance.NguoiDungs.DeleteObject(delitem);
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

		public static List<NguoiDung> RetrieveByID(int manguoidung)
		{
			return (from item in DataContext.Instance.NguoiDungs where  item.MaNguoiDung == manguoidung  select item).ToList();
		}

		public static List<NguoiDung> SelectByMaQuyen(int maquyen)
		{
			var lstItem = (from item in DataContext.Instance.NguoiDungs where item.MaQuyen == maquyen select item).ToList();
			return lstItem;
		}

	}
}