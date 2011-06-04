using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class QuaTrinhDaoTaoRepository
	{
		public static List<QuaTrinhDaoTao> SelectAll()
		{
			return DataContext.Instance.QuaTrinhDaoTaos.OrderBy(item => item.TenTruong).ToList();
		}

		public static QuaTrinhDaoTao SelectByID(int maquatrinhdaotao)
		{
			return DataContext.Instance.QuaTrinhDaoTaos.FirstOrDefault(item => item.MaQuaTrinhDaoTao == maquatrinhdaotao );
		}

		public static bool Insert(QuaTrinhDaoTao obj)
		{
			try
			{
				DataContext.Instance.QuaTrinhDaoTaos.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(int maquatrinhdaotao)
		{
			try
			{
				var delitem = DataContext.Instance.QuaTrinhDaoTaos.FirstOrDefault(item => item.MaQuaTrinhDaoTao == maquatrinhdaotao );
				DataContext.Instance.QuaTrinhDaoTaos.DeleteObject(delitem);
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

		public static List<QuaTrinhDaoTao> RetrieveByID(int maquatrinhdaotao)
		{
			return (from item in DataContext.Instance.QuaTrinhDaoTaos where  item.MaQuaTrinhDaoTao == maquatrinhdaotao  select item).ToList();
		}

		public static List<QuaTrinhDaoTao> SelectByMaNhanVien(string manhanvien)
		{
			var lstItem = (from item in DataContext.Instance.QuaTrinhDaoTaos where item.MaNhanVien == manhanvien select item).ToList();
			return lstItem;
		}

		public static List<QuaTrinhDaoTao> SelectByMaNuocDaoTao(int manuocdaotao)
		{
			var lstItem = (from item in DataContext.Instance.QuaTrinhDaoTaos where item.MaNuocDaoTao == manuocdaotao select item).ToList();
			return lstItem;
		}

		public static List<QuaTrinhDaoTao> SelectByMaHinhThucDaoTao(int mahinhthucdaotao)
		{
			var lstItem = (from item in DataContext.Instance.QuaTrinhDaoTaos where item.MaHinhThucDaoTao == mahinhthucdaotao select item).ToList();
			return lstItem;
		}

		public static List<QuaTrinhDaoTao> SelectByMaBangGiaoDucPhoThong(int mabanggiaoducphothong)
		{
			var lstItem = (from item in DataContext.Instance.QuaTrinhDaoTaos where item.MaBangGiaoDucPhoThong == mabanggiaoducphothong select item).ToList();
			return lstItem;
		}

		public static List<QuaTrinhDaoTao> SelectByMaBangLyLuanChinhTri(int mabanglyluanchinhtri)
		{
			var lstItem = (from item in DataContext.Instance.QuaTrinhDaoTaos where item.MaBangLyLuanChinhTri == mabanglyluanchinhtri select item).ToList();
			return lstItem;
		}

		public static List<QuaTrinhDaoTao> SelectByMaBangNgoaiNgu(int mabangngoaingu)
		{
			var lstItem = (from item in DataContext.Instance.QuaTrinhDaoTaos where item.MaBangNgoaiNgu == mabangngoaingu select item).ToList();
			return lstItem;
		}

		public static List<QuaTrinhDaoTao> SelectByMaBangChuyenMonNghiepVu(int mabangchuyenmonnghiepvu)
		{
			var lstItem = (from item in DataContext.Instance.QuaTrinhDaoTaos where item.MaBangChuyenMonNghiepVu == mabangchuyenmonnghiepvu select item).ToList();
			return lstItem;
		}

		public static List<QuaTrinhDaoTao> SelectByMaHocHam(int mahocham)
		{
			var lstItem = (from item in DataContext.Instance.QuaTrinhDaoTaos where item.MaHocHam == mahocham select item).ToList();
			return lstItem;
		}

	}
}