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

		public static List<NhanVien> SelectByMaGioiTinh(string magioitinh)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaGioiTinh == magioitinh select item).ToList();
			return lstItem;
		}

		public static List<NhanVien> SelectByMaDanToc(string madantoc)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaDanToc == madantoc select item).ToList();
			return lstItem;
		}

		public static List<NhanVien> SelectByMaTonGiao(string matongiao)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaTonGiao == matongiao select item).ToList();
			return lstItem;
		}

		public static List<NhanVien> SelectByMaTinhTrangHonNhan(string matinhtranghonnhan)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaTinhTrangHonNhan == matinhtranghonnhan select item).ToList();
			return lstItem;
		}

		public static List<NhanVien> SelectByMaThanhPhanXuatThan(string mathanhphanxuatthan)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaThanhPhanXuatThan == mathanhphanxuatthan select item).ToList();
			return lstItem;
		}

		public static List<NhanVien> SelectByMaDienUuTienCuaGiaDinh(string madienuutiencuagiadinh)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaDienUuTienCuaGiaDinh == madienuutiencuagiadinh select item).ToList();
			return lstItem;
		}

		public static List<NhanVien> SelectByMaDienUuTienCuaBanThan(string madienuutiencuabanthan)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaDienUuTienCuaBanThan == madienuutiencuabanthan select item).ToList();
			return lstItem;
		}

		public static List<NhanVien> SelectByMaHinhThucTuyenDung(string mahinhthuctuyendung)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaHinhThucTuyenDung == mahinhthuctuyendung select item).ToList();
			return lstItem;
		}

		public static List<NhanVien> SelectByMaDonVi(string madonvi)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaDonVi == madonvi select item).ToList();
			return lstItem;
		}

		public static List<NhanVien> SelectByMaCongViec(string macongviec)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaCongViec == macongviec select item).ToList();
			return lstItem;
		}

		public static List<NhanVien> SelectByMaLoaiCanBo(string maloaicanbo)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaLoaiCanBo == maloaicanbo select item).ToList();
			return lstItem;
		}

		public static List<NhanVien> SelectByMaLoaiNghiBaoHiemXaHoi(string maloainghibaohiemxahoi)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaLoaiNghiBaoHiemXaHoi == maloainghibaohiemxahoi select item).ToList();
			return lstItem;
		}

		public static List<NhanVien> SelectByMaChucVu(string machucvu)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaChucVu == machucvu select item).ToList();
			return lstItem;
		}

		public static List<NhanVien> SelectByDoanVien(string doanvien)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.DoanVien == doanvien select item).ToList();
			return lstItem;
		}

		public static List<NhanVien> SelectByDangDTBD(string dangdtbd)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.DangDTBD == dangdtbd select item).ToList();
			return lstItem;
		}

		public static List<NhanVien> SelectByMaTrinhDoHocVan(string matrinhdohocvan)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaTrinhDoHocVan == matrinhdohocvan select item).ToList();
			return lstItem;
		}

		public static List<NhanVien> SelectByMaTrinhDoChuyenMon(string matrinhdochuyenmon)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaTrinhDoChuyenMon == matrinhdochuyenmon select item).ToList();
			return lstItem;
		}

		public static List<NhanVien> SelectByMaTrinhDoChinhTri(string matrinhdochinhtri)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaTrinhDoChinhTri == matrinhdochinhtri select item).ToList();
			return lstItem;
		}

		public static List<NhanVien> SelectByMaTrinhDoQuanLyNhaNuoc(string matrinhdoquanlynhanuoc)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaTrinhDoQuanLyNhaNuoc == matrinhdoquanlynhanuoc select item).ToList();
			return lstItem;
		}

		public static List<NhanVien> SelectByMaTrinhDoTinHoc(string matrinhdotinhoc)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaTrinhDoTinHoc == matrinhdotinhoc select item).ToList();
			return lstItem;
		}

		public static List<NhanVien> SelectByMaTrinhDoNgoaiNgu(string matrinhdongoaingu)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaTrinhDoNgoaiNgu == matrinhdongoaingu select item).ToList();
			return lstItem;
		}

		public static List<NhanVien> SelectByMaNgach(string mangach)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaNgach == mangach select item).ToList();
			return lstItem;
		}

		public static List<NhanVien> SelectByLuongCongChucDuBi(string luongcongchucdubi)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.LuongCongChucDuBi == luongcongchucdubi select item).ToList();
			return lstItem;
		}

	}
}