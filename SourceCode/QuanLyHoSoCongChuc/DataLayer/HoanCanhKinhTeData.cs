using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using QuanLyHoSoCongChuc.BusinessObject;

namespace QuanLyHoSoCongChuc.DataLayer
{
    public class HoanCanhKinhTeData
    {
        public HoanCanhKinhTeInfo LayThongTinHoanCanhKinhTe(string MaNhanVien)
        {
            HoanCanhKinhTeInfo hc = new HoanCanhKinhTeInfo();
            if (DataService.m_ConnectString == "")
                DataService.ConnectionString();
            string ConnectionString = DataService.m_ConnectString;

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM HoanCanhKinhTe WHERE MaNhanVien = @MaNhanVien";
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.NChar, 10).Value = MaNhanVien;
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    hc.MaHoanCanhKinhTe = (int)dr["MaHoanCanhKinhTe"];
                    hc.MaNhanVien = (string)dr["MaNhanVien"];
                    hc.TongThuNhapGiaDinh = (string)dr["TongThuNhapGiaDinh"];
                    hc.NhaODuocCap = (string)dr["NhaODuocCap"];
                    hc.NhaOTuMua = (string)dr["NhaOTuMua"];
                    hc.MaHoatDongKinhTe = (string)dr["MaHoatDongKinhTe"];
                    hc.DienTichDatKinhDoanhTrangTrai = (string)dr["DienTichDatKinhDoanhTrangTrai"];
                    hc.TaiSanCoGiaTri = (string)dr["TaiSanCoGiaTri"];
                    hc.BinhQuanDauNguoi = (string)dr["BinhQuanDauNguoi"];
                    hc.DienTichSuDungNhaO = (string)dr["DienTichSuDungNhaO"];
                    hc.DienTichSuDungDatO = (string)dr["DienTichSuDungDatO"];
                    hc.DatTuMua = (string)dr["DatTuMua"];
                    hc.SoLaoDongThue = (string)dr["SoLaoDongThue"];
                    hc.GiaTriTaiSan = (string)dr["GiaTriTaiSan"];

                    break;
                }

                con.Close();
            }
            return hc;
        }


        public void ThemHoanCanhKinhTe(HoanCanhKinhTeInfo hc)
        {
            if (DataService.m_ConnectString == "")
                DataService.ConnectionString();
            string ConnectionString = DataService.m_ConnectString;

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO HoanCanhKinhTe (MaNhanVien, TongThuNhapGiaDinh, NhaODuocCap, NhaOTuMua, DatDuocCap, MaHoatDongKinhTe, DienTichDatKinhDoanhTrangTrai, TaiSanCoGiaTri, BinhQuanDauNguoi, DienTichSuDungNhaO, DienTichSuDungDatO, DatTuMua, SoLaoDongThue, GiaTriTaiSan) VALUES (@MaNhanVien, @TongThuNhapGiaDinh, @NhaODuocCap, @NhaOTuMua, @DatDuocCap, @MaHoatDongKinhTe, @DienTichDatKinhDoanhTrangTrai, @TaiSanCoGiaTri, @BinhQuanDauNguoi, @DienTichSuDungNhaO, @DienTichSuDungDatO, @DatTuMua, @SoLaoDongThue, @GiaTriTaiSan)";
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.NChar, 10).Value = hc.MaNhanVien;
                cmd.Parameters.Add("@TongThuNhapGiaDinh", SqlDbType.NChar, 50).Value = hc.TongThuNhapGiaDinh;
                cmd.Parameters.Add("@NhaODuocCap", SqlDbType.NVarChar, 50).Value = hc.NhaODuocCap;
                cmd.Parameters.Add("@NhaOTuMua", SqlDbType.NVarChar, 50).Value = hc.NhaOTuMua;
                cmd.Parameters.Add("@DatDuocCap", SqlDbType.NVarChar, 50).Value = hc.DatDuocCap;
                cmd.Parameters.Add("@MaHoatDongKinhTe", SqlDbType.NChar, 10).Value = hc.MaHoatDongKinhTe;
                cmd.Parameters.Add("@DienTichDatKinhDoanhTrangTrai", SqlDbType.NVarChar, 50).Value = hc.DienTichDatKinhDoanhTrangTrai;
                cmd.Parameters.Add("@TaiSanCoGiaTri", SqlDbType.NVarChar, 150).Value = hc.TaiSanCoGiaTri;
                cmd.Parameters.Add("@BinhQuanDauNguoi", SqlDbType.NVarChar, 50).Value = hc.BinhQuanDauNguoi;
                cmd.Parameters.Add("@DienTichSuDungNhaO", SqlDbType.NVarChar, 50).Value = hc.DienTichSuDungNhaO;
                cmd.Parameters.Add("@DienTichSuDungDatO", SqlDbType.NVarChar, 50).Value = hc.DienTichSuDungDatO;
                cmd.Parameters.Add("@DatTuMua", SqlDbType.NVarChar, 50).Value = hc.DatTuMua;
                cmd.Parameters.Add("@SoLaoDongThue", SqlDbType.NVarChar, 50).Value = hc.SoLaoDongThue;
                cmd.Parameters.Add("@GiaTriTaiSan", SqlDbType.NVarChar, 50).Value = hc.GiaTriTaiSan;
                
                con.Open();

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }


        public void CapNhatCanhKinhTe(HoanCanhKinhTeInfo hc)
        {
            if (DataService.m_ConnectString == "")
                DataService.ConnectionString();
            string ConnectionString = DataService.m_ConnectString;

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE HoanCanhKinhTe  SET TongThuNhapGiaDinh=@TongThuNhapGiaDinh, NhaODuocCap=@NhaODuocCap, NhaOTuMua=@NhaOTuMua, DatDuocCap=@DatDuocCap, MaHoatDongKinhTe=@MaHoatDongKinhTe, DienTichDatKinhDoanhTrangTrai=@DienTichDatKinhDoanhTrangTrai, TaiSanCoGiaTri=@TaiSanCoGiaTri, BinhQuanDauNguoi=@BinhQuanDauNguoi, DienTichSuDungNhaO=@DienTichSuDungNhaO, DienTichSuDungDatO=@DienTichSuDungDatO, DatTuMua=@DatTuMua, SoLaoDongThue=@SoLaoDongThue, GiaTriTaiSan=@GiaTriTaiSan WHERE MaNhanVien=@MaNhanVien";
                
                cmd.Parameters.Add("@TongThuNhapGiaDinh", SqlDbType.NChar, 50).Value = hc.TongThuNhapGiaDinh;
                cmd.Parameters.Add("@NhaODuocCap", SqlDbType.NVarChar, 50).Value = hc.NhaODuocCap;
                cmd.Parameters.Add("@NhaOTuMua", SqlDbType.NVarChar, 50).Value = hc.NhaOTuMua;
                cmd.Parameters.Add("@DatDuocCap", SqlDbType.NVarChar, 50).Value = hc.NhaODuocCap;
                cmd.Parameters.Add("@MaHoatDongKinhTe", SqlDbType.NChar, 10).Value = hc.MaHoatDongKinhTe;
                cmd.Parameters.Add("@DienTichDatKinhDoanhTrangTrai", SqlDbType.NVarChar, 50).Value = hc.DienTichDatKinhDoanhTrangTrai;
                cmd.Parameters.Add("@TaiSanCoGiaTri", SqlDbType.NVarChar, 150).Value = hc.TaiSanCoGiaTri;
                cmd.Parameters.Add("@BinhQuanDauNguoi", SqlDbType.NVarChar, 50).Value = hc.BinhQuanDauNguoi;
                cmd.Parameters.Add("@DienTichSuDungNhaO", SqlDbType.NVarChar, 50).Value = hc.DienTichSuDungNhaO;
                cmd.Parameters.Add("@DienTichSuDungDatO", SqlDbType.NVarChar, 50).Value = hc.DienTichSuDungDatO;
                cmd.Parameters.Add("@DatTuMua", SqlDbType.NVarChar, 50).Value = hc.DatTuMua;
                cmd.Parameters.Add("@SoLaoDongThue", SqlDbType.NVarChar, 50).Value = hc.SoLaoDongThue;
                cmd.Parameters.Add("@GiaTriTaiSan", SqlDbType.NVarChar, 50).Value = hc.GiaTriTaiSan;
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.NChar, 10).Value = hc.MaNhanVien;
                con.Open();

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public bool KiemTraTonTaiHoanCanhNhanVien(string MaNhanVien)
        {
            bool bReturn = true;
            if (DataService.m_ConnectString == "")
                DataService.ConnectionString();
            string ConnectionString = DataService.m_ConnectString;

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT MaHoanCanhKinhTe FROM HoanCanhKinhTe WHERE MaNhanVien = @MaNhanVien";
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.NChar, 10).Value = MaNhanVien;
                con.Open();
                Object obj = cmd.ExecuteScalar();
                if (obj == null)
                {
                    bReturn = false;
                }
            }

            return bReturn;
        }

    }
}
