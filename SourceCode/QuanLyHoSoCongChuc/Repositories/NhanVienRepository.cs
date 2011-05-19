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
		public List<NhanVien> SelectAll()
		{
			return DataContext.Instance.NhanViens.ToList();
		}

		public NhanVien SelectByID(string manhanvien)
		{
			return DataContext.Instance.NhanViens.FirstOrDefault(item => item.MaNhanVien == manhanvien );
		}

		public bool Insert(NhanVien obj)
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

		public bool Delete(string manhanvien)
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

		public List<NhanVien> RetrieveByID(string manhanvien)
		{
			return (from item in DataContext.Instance.NhanViens where  item.MaNhanVien == manhanvien  select item).ToList();
		}

		public List<NhanVien> SelectByGioiTinh(string magioitinh, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaGioiTinh == magioitinh select item).ToList();
			return lstItem;
		}

		public List<NhanVien> SelectByDanToc(string madantoc, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaDanToc == madantoc select item).ToList();
			return lstItem;
		}

		public List<NhanVien> SelectByTonGiao(string matongiao, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaTonGiao == matongiao select item).ToList();
			return lstItem;
		}

		public List<NhanVien> SelectByTinhTrangHonNhan(string matinhtranghonnhan, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaTinhTrangHonNhan == matinhtranghonnhan select item).ToList();
			return lstItem;
		}

		public List<NhanVien> SelectByThanhPhanXuatThan(string mathanhphanxuatthan, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaThanhPhanXuatThan == mathanhphanxuatthan select item).ToList();
			return lstItem;
		}

		public List<NhanVien> SelectByDienUuTienCuaGiaDinh(string madienuutiencuagiadinh, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaDienUuTienCuaGiaDinh == madienuutiencuagiadinh select item).ToList();
			return lstItem;
		}

		public List<NhanVien> SelectByDienUuTienCuaBanThan(string madienuutiencuabanthan, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaDienUuTienCuaBanThan == madienuutiencuabanthan select item).ToList();
			return lstItem;
		}

		public List<NhanVien> SelectByHinhThucTuyenDung(string mahinhthuctuyendung, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaHinhThucTuyenDung == mahinhthuctuyendung select item).ToList();
			return lstItem;
		}

		public List<NhanVien> SelectByDonVi(string madonvi, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaDonVi == madonvi select item).ToList();
			return lstItem;
		}

		public List<NhanVien> SelectByCongViec(string macongviec, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaCongViec == macongviec select item).ToList();
			return lstItem;
		}

		public List<NhanVien> SelectByLoaiCanBo(string maloaicanbo, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaLoaiCanBo == maloaicanbo select item).ToList();
			return lstItem;
		}

		public List<NhanVien> SelectByLoaiNghiBaoHiemXaHoi(string maloainghibaohiemxahoi, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaLoaiNghiBaoHiemXaHoi == maloainghibaohiemxahoi select item).ToList();
			return lstItem;
		}

		public List<NhanVien> SelectByChucVu(string machucvu, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaChucVu == machucvu select item).ToList();
			return lstItem;
		}

		public List<NhanVien> SelectByDoanVien(string doanvien, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.DoanVien == doanvien select item).ToList();
			return lstItem;
		}

		public List<NhanVien> SelectByngDTBD(string dangdtbd, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.DangDTBD == dangdtbd select item).ToList();
			return lstItem;
		}

		public List<NhanVien> SelectByTrinhDoHocVan(string matrinhdohocvan, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaTrinhDoHocVan == matrinhdohocvan select item).ToList();
			return lstItem;
		}

		public List<NhanVien> SelectByTrinhDoChuyenMon(string matrinhdochuyenmon, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaTrinhDoChuyenMon == matrinhdochuyenmon select item).ToList();
			return lstItem;
		}

		public List<NhanVien> SelectByTrinhDoChinhTri(string matrinhdochinhtri, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaTrinhDoChinhTri == matrinhdochinhtri select item).ToList();
			return lstItem;
		}

		public List<NhanVien> SelectByTrinhDoQuanLyNhaNuoc(string matrinhdoquanlynhanuoc, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaTrinhDoQuanLyNhaNuoc == matrinhdoquanlynhanuoc select item).ToList();
			return lstItem;
		}

		public List<NhanVien> SelectByTrinhDoTinHoc(string matrinhdotinhoc, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaTrinhDoTinHoc == matrinhdotinhoc select item).ToList();
			return lstItem;
		}

		public List<NhanVien> SelectByTrinhDoNgoaiNgu(string matrinhdongoaingu, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaTrinhDoNgoaiNgu == matrinhdongoaingu select item).ToList();
			return lstItem;
		}

		public List<NhanVien> SelectByNgach(string mangach, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.MaNgach == mangach select item).ToList();
			return lstItem;
		}

		public List<NhanVien> SelectByLuongCongChucDuBi(string luongcongchucdubi, int page, int pageSize)
		{
			var lstItem = (from item in DataContext.Instance.NhanViens where item.LuongCongChucDuBi == luongcongchucdubi select item).ToList();
			return lstItem;
		}

	}
}