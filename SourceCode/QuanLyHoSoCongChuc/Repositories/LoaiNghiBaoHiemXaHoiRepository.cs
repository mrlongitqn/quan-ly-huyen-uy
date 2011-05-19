using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class LoaiNghiBaoHiemXaHoiRepository
	{
		public static List<LoaiNghiBaoHiemXaHoi> SelectAll()
		{
			return DataContext.Instance.LoaiNghiBaoHiemXaHois.ToList();
		}

		public static LoaiNghiBaoHiemXaHoi SelectByID(string maloainghibaohiemxahoi)
		{
			return DataContext.Instance.LoaiNghiBaoHiemXaHois.FirstOrDefault(item => item.MaLoaiNghiBaoHiemXaHoi == maloainghibaohiemxahoi );
		}

		public static bool Insert(LoaiNghiBaoHiemXaHoi obj)
		{
			try
			{
				DataContext.Instance.LoaiNghiBaoHiemXaHois.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(string maloainghibaohiemxahoi)
		{
			try
			{
				var delitem = DataContext.Instance.LoaiNghiBaoHiemXaHois.FirstOrDefault(item => item.MaLoaiNghiBaoHiemXaHoi == maloainghibaohiemxahoi );
				DataContext.Instance.LoaiNghiBaoHiemXaHois.DeleteObject(delitem);
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

		public static List<LoaiNghiBaoHiemXaHoi> RetrieveByID(string maloainghibaohiemxahoi)
		{
			return (from item in DataContext.Instance.LoaiNghiBaoHiemXaHois where  item.MaLoaiNghiBaoHiemXaHoi == maloainghibaohiemxahoi  select item).ToList();
		}

	}
}