using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class LucLuongVuTrangRepository
	{
		public List<LucLuongVuTrang> SelectAll()
		{
			return DataContext.Instance.LucLuongVuTrangs.ToList();
		}

		public LucLuongVuTrang SelectByID(string malucluongvutrang, string manhanvien)
		{
			return DataContext.Instance.LucLuongVuTrangs.FirstOrDefault(item => item.MaLucLuongVuTrang == malucluongvutrang &&  item.MaNhanVien == manhanvien );
		}

		public bool Insert(LucLuongVuTrang obj)
		{
			try
			{
				DataContext.Instance.LucLuongVuTrangs.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Delete(string malucluongvutrang, string manhanvien)
		{
			try
			{
				var delitem = DataContext.Instance.LucLuongVuTrangs.FirstOrDefault(item => item.MaLucLuongVuTrang == malucluongvutrang &&  item.MaNhanVien == manhanvien );
				DataContext.Instance.LucLuongVuTrangs.DeleteObject(delitem);
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

		public List<LucLuongVuTrang> RetrieveByID(string malucluongvutrang, string manhanvien)
		{
			return (from item in DataContext.Instance.LucLuongVuTrangs where  item.MaLucLuongVuTrang == malucluongvutrang &&  item.MaNhanVien == manhanvien  select item).ToList();
		}

		public List<LucLuongVuTrang> SelectByNhanVien(string manhanvien, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.LucLuongVuTrangs where item.MaNhanVien == manhanvien select item).ToList();
			return lstItem;
		}

	}
}