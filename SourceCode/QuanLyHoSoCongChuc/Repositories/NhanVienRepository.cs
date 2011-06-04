using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class NhanVienRepository
	{
		public static List<NhanVien> SelectAll()
		{
			return DataContext.Instance.NhanViens.ToList();
		}

		public static NhanVien SelectByID(string manhanvien)
		{
			return DataContext.Instance.NhanViens.FirstOrDefault(item => item.MaNhanVien == manhanvien );
		}

		public static bool Insert(NhanVien obj)
		{
			try
			{
				DataContext.Instance.NhanViens.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Delete(string manhanvien)
		{
			try
			{
				var delitem = DataContext.Instance.NhanViens.FirstOrDefault(item => item.MaNhanVien == manhanvien );
				DataContext.Instance.NhanViens.DeleteObject(delitem);
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

		public static List<NhanVien> RetrieveByID(string manhanvien)
		{
			return (from item in DataContext.Instance.NhanViens where  item.MaNhanVien == manhanvien  select item).ToList();
		}

		public static List<NhanVien> SelectByMaDonVi(string madonvi)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaDonVi == madonvi select item).ToList();
			return lstItem;
		}

		public static List<NhanVien> SelectByMaDanToc(int madantoc)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaDanToc == madantoc select item).ToList();
			return lstItem;
		}

		public static List<NhanVien> SelectByMaTonGiao(int matongiao)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaTonGiao == matongiao select item).ToList();
			return lstItem;
		}

		public static List<NhanVien> SelectByMaThanhPhanGiaDinh(int mathanhphangiadinh)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaThanhPhanGiaDinh == mathanhphangiadinh select item).ToList();
			return lstItem;
		}

		public static List<NhanVien> SelectByMaNgheNghiepTruocKhiDuocTuyenDung(int manghenghieptruockhiduoctuyendung)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaNgheNghiepTruocKhiDuocTuyenDung == manghenghieptruockhiduoctuyendung select item).ToList();
			return lstItem;
		}

		public static List<NhanVien> SelectByMaBangGiaoDucPhoThong(int mabanggiaoducphothong)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaBangGiaoDucPhoThong == mabanggiaoducphothong select item).ToList();
			return lstItem;
		}

		public static List<NhanVien> SelectByMaBangChuyenMonNghiepVu(int mabangchuyenmonnghiepvu)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaBangChuyenMonNghiepVu == mabangchuyenmonnghiepvu select item).ToList();
			return lstItem;
		}

		public static List<NhanVien> SelectByMaBangLyLuanChinhTri(int mabanglyluanchinhtri)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaBangLyLuanChinhTri == mabanglyluanchinhtri select item).ToList();
			return lstItem;
		}

		public static List<NhanVien> SelectByMaBangNgoaiNgu(int mabangngoaingu)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaBangNgoaiNgu == mabangngoaingu select item).ToList();
			return lstItem;
		}

		public static List<NhanVien> SelectByMaHocVi(int mahocvi)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaHocVi == mahocvi select item).ToList();
			return lstItem;
		}

		public static List<NhanVien> SelectByMaHocHam(int mahocham)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaHocHam == mahocham select item).ToList();
			return lstItem;
		}

		public static List<NhanVien> SelectByMaTinhTrangSucKhoe(int matinhtrangsuckhoe)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaTinhTrangSucKhoe == matinhtrangsuckhoe select item).ToList();
			return lstItem;
		}

		public static List<NhanVien> SelectByMaThuongBinh(int mathuongbinh)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaThuongBinh == mathuongbinh select item).ToList();
			return lstItem;
		}

	}
}