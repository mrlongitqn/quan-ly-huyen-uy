using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class LoaiNguoiDung_ChucNangRepository
	{
		public static List<LoaiNguoiDung_ChucNang> SelectAll()
		{
			return DataContext.Instance.LoaiNguoiDung_ChucNangs.ToList();
		}

		public static LoaiNguoiDung_ChucNang SelectByID(int machucnangnguoidung)
		{
			return DataContext.Instance.LoaiNguoiDung_ChucNangs.FirstOrDefault(item => item.MaChucNangNguoiDung == machucnangnguoidung );
		}

		public static bool Insert(LoaiNguoiDung_ChucNang obj)
		{
			try
			{
				DataContext.Instance.LoaiNguoiDung_ChucNangs.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int machucnangnguoidung)
		{
			try
			{
				var delitem = DataContext.Instance.LoaiNguoiDung_ChucNangs.FirstOrDefault(item => item.MaChucNangNguoiDung == machucnangnguoidung );
				DataContext.Instance.LoaiNguoiDung_ChucNangs.DeleteObject(delitem);
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

		public static List<LoaiNguoiDung_ChucNang> RetrieveByID(int machucnangnguoidung)
		{
			return (from item in DataContext.Instance.LoaiNguoiDung_ChucNangs where  item.MaChucNangNguoiDung == machucnangnguoidung  select item).ToList();
		}

		public static List<LoaiNguoiDung_ChucNang> SelectByMaQuyen(int maquyen)
		{
			var lstItem = (from item in DataContext.Instance.LoaiNguoiDung_ChucNangs where item.MaQuyen == maquyen select item).ToList();
			return lstItem;
		}

		public static List<LoaiNguoiDung_ChucNang> SelectByMaChucNang(int machucnang)
		{
			var lstItem = (from item in DataContext.Instance.LoaiNguoiDung_ChucNangs where item.MaChucNang == machucnang select item).ToList();
			return lstItem;
		}

	}
}