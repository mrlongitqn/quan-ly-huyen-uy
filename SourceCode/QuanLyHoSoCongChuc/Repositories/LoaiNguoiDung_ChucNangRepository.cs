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
		public List<LoaiNguoiDung_ChucNang> SelectAll()
		{
			return DataContext.Instance.LoaiNguoiDung_ChucNang.ToList();
		}

		public LoaiNguoiDung_ChucNang SelectByID(int machucnangnguoidung)
		{
			return DataContext.Instance.LoaiNguoiDung_ChucNang.FirstOrDefault(item => item.MaChucNangNguoiDung == machucnangnguoidung );
		}

		public bool Insert(LoaiNguoiDung_ChucNang obj)
		{
			try
			{
				DataContext.Instance.LoaiNguoiDung_ChucNang.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Delete(int machucnangnguoidung)
		{
			try
			{
				var delitem = DataContext.Instance.LoaiNguoiDung_ChucNang.FirstOrDefault(item => item.MaChucNangNguoiDung == machucnangnguoidung );
				DataContext.Instance.LoaiNguoiDung_ChucNang.DeleteObject(delitem);
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

		public List<LoaiNguoiDung_ChucNang> RetrieveByID(int machucnangnguoidung)
		{
			return (from item in DataContext.Instance.LoaiNguoiDung_ChucNang where  item.MaChucNangNguoiDung == machucnangnguoidung  select item).ToList();
		}

		public List<LoaiNguoiDung_ChucNang> SelectByQuyen(int maquyen, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.LoaiNguoiDung_ChucNang where item.MaQuyen == maquyen select item).ToList();
			return lstItem;
		}

		public List<LoaiNguoiDung_ChucNang> SelectByChucNang(int machucnang, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.LoaiNguoiDung_ChucNang where item.MaChucNang == machucnang select item).ToList();
			return lstItem;
		}

	}
}