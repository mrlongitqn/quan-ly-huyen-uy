using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace QuanLyHoSoCongChuc.Report
{
    public partial class FrmReport2 : Form
    {
        DataService dataService = new DataService();
        String MaNV;
        public FrmReport2(String _MaNV)
        {
            MaNV = _MaNV;
            InitializeComponent();
        }

        private void FrmReport2_Load(object sender, EventArgs e)
        {
            String sql = "";
            DataService.OpenConnection();
            this.reportViewer1.LocalReport.ReportPath = "Report\\RptSYLL.rdlc";
            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            /////////////////////////////////////////////////////////////////////////////
            // Set parameter
            sql = "select * from NhanVien nv left join ChucVu cv on nv.MaChucVu = cv.MaChucVu";
            sql += " left join ";
            sql += "                  (select * from LuongPhuCap l1";
            sql += "                  where MaLuongPhuCap not in";
            sql += "                  (";
            sql += "                  select distinct l2.MaLuongPhuCap from LuongPhuCap l2 ";
            sql += "                  join LuongPhuCap l3 on (l2.MaNhanVien = l3.MaNhanVien and l2.MaLuongPhuCap < l3.MaLuongPhuCap)";
            sql += "                  )) as temp on nv.MaNhanVien = temp.MaNhanVien";
            sql += " left join ThanhPhanGiaDinh tpgd on nv.MaThanhPhanGiaDinh = tpgd.MaThanhPhanGiaDinh";
            sql += " left join HocVi hv on nv.MaHocVi = hv.MaHocVi";
            sql += " left join HocHam hh on nv.MaHocHam = hh.MaHocHam";
            sql += " left join DanToc dv on nv.MaDanToc = dv.MaDanToc";
            sql += " left join TonGiao tg on nv.MaDanToc = tg.MaTonGiao";
            sql += " left join BangLyLuanChinhTri llct on nv.MaBangLyLuanChinhTri = llct.MaBangLyLuanChinhTri";
            sql += " left join BangGiaoDucPhoThong gdpt on nv.MaBangGiaoDucPhoThong = gdpt.MaBangGiaoDucPhoThong";
            sql += " left join BangChuyenMonNghiepVu cmnv on nv.MaBangChuyenMonNghiepVu = cmnv.MaBangChuyenMonNghiepVu";
            sql += " left join BangNgoaiNgu bnn on nv.MaBangNgoaiNgu = bnn.MaBangNgoaiNgu";
            sql += " left join NgheNghiep nn on nv.MaNgheNghiepTruocKhiDuocTuyenDung = nn.MaNgheNghiep";
            sql += " left join DacDiemLichSu ddls on nv.MaNhanVien = ddls.MaNhanVien";
            sql += " left join HoanCanhKinhTe hckt on nv.MaNhanVien = hckt.MaNhanVien";
            sql += " left join TinhTrangSucKhoe ttsk on nv.MaTinhTrangSucKhoe = ttsk.MaTinhTrangSucKhoe";
            sql += " left join LoaiThuongBinh ltb on nv.MaLoaiThuongBinh = ltb.MaLoaiThuongBinh";
            sql += " where nv.MaNhanVien='" + MaNV + "' ";

            SqlCommand cmd = new SqlCommand(sql);
            dataService.Load(cmd);

            DataTable NhanVienDt = dataService;

            ReportParameter[] parames = new ReportParameter[48];
            // Parameter 0
            
            parames[0] = new ReportParameter("HoTen", "1) Họ và tên: " + NhanVienDt.Rows[0]["HoTenKhaiSinh"].ToString() + ".            Giới tính: " + getGioiTinh(NhanVienDt.Rows[0]["HoTenKhaiSinh"].ToString()), true);

            // Parameter 1
            DateTime MyDateTime = new DateTime();
            String MyString = NhanVienDt.Rows[0]["NgaySinh"].ToString();
            MyDateTime = Convert.ToDateTime(MyString);

            parames[1] = new ReportParameter("NgaySinh", "2) Sinh ngày: " + MyDateTime.Day + " tháng " + MyDateTime.Month + " năm " + MyDateTime.Year, true);

            // Parameter 2
            parames[2] = new ReportParameter("TenKhac", "3) Các tên gọi khác: " + NhanVienDt.Rows[0]["HoTenDangDung"].ToString(), true);

            // Parameter 3
            parames[3] = new ReportParameter("NoiSinh", "4) Nơi sinh: " + NhanVienDt.Rows[0]["NoiSinh"].ToString(), true);

            // Parameter 4
            parames[4] = new ReportParameter("QueQuan", "5) Quê quán: " + NhanVienDt.Rows[0]["QueQuan"].ToString(), true);

            // Parameter 5
            parames[5] = new ReportParameter("DanToc", "6) Dân tộc: " + NhanVienDt.Rows[0]["TenDanToc"].ToString(), true);

            // Parameter 6
            parames[6] = new ReportParameter("TonGiao", "7) Tôn giáo: " + NhanVienDt.Rows[0]["TenTonGiao"].ToString(), true);

            // Parameter 7
            parames[7] = new ReportParameter("HoKhau", "8) Hộ khẩu thường trú: " + NhanVienDt.Rows[0]["HoKhau"].ToString(), true);

            // Parameter 8
            parames[8] = new ReportParameter("NoiOHienNay", "9) Nơi ở hiện nay: " + NhanVienDt.Rows[0]["NoiOHienNay"].ToString(), true);

            // Parameter 9
            parames[9] = new ReportParameter("NgheNghiep", "10) Nghề nghiệp bản thân trước khi được tuyển dụng: " + NhanVienDt.Rows[0]["TenNgheNghiep"].ToString(), true);

            // Parameter 10
            parames[10] = new ReportParameter("NgayDuocTuyenDung", "11) Ngày tuyển dụng: " + (NhanVienDt.Rows[0]["NgayTuyenDung"].ToString() == "" ? "" : String.Format("{0:dd/MM/yyyy}", DateTime.Parse(NhanVienDt.Rows[0]["NgayTuyenDung"].ToString()))), true);

            // Parameter 11
            parames[11] = new ReportParameter("CoQuanTuyenDung", "12) Cơ quan tuyển dụng: " + NhanVienDt.Rows[0]["CoQuanTuyenDung"].ToString(), true);

            // Parameter 12
            parames[12] = new ReportParameter("NgayTuyenDungChinhThuc", "13) Ngày tuyển dụng chính thức: " + (NhanVienDt.Rows[0]["NgayTuyenDungChinhThuc"].ToString() == "" ? "" : String.Format("{0:dd/MM/yyyy}", DateTime.Parse(NhanVienDt.Rows[0]["NgayTuyenDungChinhThuc"].ToString()))), true);

            // Parameter 13
            parames[13] = new ReportParameter("CoQuanTuyenDungChinhThuc", "14) Tuyển dụng chính thức tại chi bộ: " + NhanVienDt.Rows[0]["TuyenDungChinhThucTaiChiBo"].ToString(), true);

            // Parameter 14
            parames[14] = new ReportParameter("ChucVu", "15) Chức vụ: " + NhanVienDt.Rows[0]["TenChucVu"].ToString(), true);

            // Parameter 15
            parames[15] = new ReportParameter("CapUy", "16) Cấp ủy: ......................... ", true);

            // Parameter 16
            parames[16] = new ReportParameter("CongTacChinh", "17) Công tác chính đang làm: " + NhanVienDt.Rows[0]["CongViecChinh"].ToString(), true);

            // Parameter 17
            parames[17] = new ReportParameter("TrinhDoGDPT", "18) Trình độ GDPT: " + NhanVienDt.Rows[0]["TenBangGiaoDucPhoThong"].ToString(), true);

            // Parameter 18
            parames[18] = new ReportParameter("TrinhDoCMNV", "19) Trình độ CMNV: " + NhanVienDt.Rows[0]["TenBangChuyenMonNghiepVu"].ToString(), true);

            // Parameter 19
            parames[19] = new ReportParameter("LyLuanChinhTri", "20) Trình độ LLCT: " + NhanVienDt.Rows[0]["TenBangLyLuanChinhTri"].ToString(), true);

            // Parameter 20
            parames[20] = new ReportParameter("NgoaiNgu", "21) Ngoại ngữ: " + NhanVienDt.Rows[0]["TenBangNgoaiNgu"].ToString(), true);

            // Parameter 21
            parames[21] = new ReportParameter("HocVi", "22) Học vị: " + NhanVienDt.Rows[0]["TenHocVi"].ToString(), true);

            // Parameter 22
            parames[22] = new ReportParameter("HocHam", "23) Học hàm: " + NhanVienDt.Rows[0]["TenHocHam"].ToString(), true);

            // Parameter 23
            parames[23] = new ReportParameter("NgayVaoDang", "24) Ngày vào đảng: " + (NhanVienDt.Rows[0]["NgayVaoDang"].ToString() == "" ? "" : String.Format("{0:dd/MM/yyyy}", DateTime.Parse(NhanVienDt.Rows[0]["NgayVaoDang"].ToString()))), true);

            // Parameter 24
            parames[24] = new ReportParameter("VaoDangTaiChiBo", "25) Tại chi bộ: " + NhanVienDt.Rows[0]["VaoDangTaiChiBo"].ToString(), true);

            // Parameter 25
            parames[25] = new ReportParameter("NgayVaoDangChinhThuc", "26) Ngày vào đảng chính thức: " + (NhanVienDt.Rows[0]["NgayVaoDangChinhThuc"].ToString() == "" ? "" : String.Format("{0:dd/MM/yyyy}", DateTime.Parse(NhanVienDt.Rows[0]["NgayVaoDangChinhThuc"].ToString()))), true);

            // Parameter 26
            parames[26] = new ReportParameter("VaoDangChinhThucTaiChiBo", "27) Tại chi bộ: " + NhanVienDt.Rows[0]["VaoDangChinhThucTaiChiBo"].ToString(), true);

            // Parameter 27
            parames[27] = new ReportParameter("NgayThamGiaCacToChucChinhTri", "28) Tham gia các tổ chức chính trị (Đoàn TNCSHCM, Công đoàn, Hội): " + NhanVienDt.Rows[0]["ThamGiaCTXH"].ToString(), true);

            // Parameter 28
            parames[28] = new ReportParameter("NgayNhapNgu", "29) Ngày nhập ngũ: " + (NhanVienDt.Rows[0]["NgayNhapNgu"].ToString() == "" ? "" : String.Format("{0:dd/MM/yyyy}", DateTime.Parse(NhanVienDt.Rows[0]["NgayNhapNgu"].ToString()))), true);

            // Parameter 29
            parames[29] = new ReportParameter("NgayXuatNgu", "30) Ngày xuất ngũ: " + (NhanVienDt.Rows[0]["NgayXuatNgu"].ToString() == "" ? "" : String.Format("{0:dd/MM/yyyy}", DateTime.Parse(NhanVienDt.Rows[0]["NgayXuatNgu"].ToString()))), true);

            // Parameter 30
            parames[30] = new ReportParameter("TinhTrangSucKhoe", "31) Tình trạng sức khỏe: " + NhanVienDt.Rows[0]["TenTinhTrangSucKhoe"].ToString() + ", Cao ........ Cân nặng ...... Nhóm máu ....", true);

            // Parameter 31
            parames[31] = new ReportParameter("GiaDinhLietSy", "32) Gia đình liệt sỹ: " + (bool.Parse(NhanVienDt.Rows[0]["GiaDinhLietSy"].ToString()) == true ? "Có" : "Không"), true);
            
            // Parameter 32
            parames[32] = new ReportParameter("GiaDinhCoCongCM", "33) Gia đình có công CM: " + (bool.Parse(NhanVienDt.Rows[0]["GiaDinhCoCongVoiCM"].ToString()) == true ? "Có" : "Không"), true);
            
            // Parameter 33
            parames[33] = new ReportParameter("CMND", "34) Số chứng minh nhân dân: " + NhanVienDt.Rows[0]["SoCMND"].ToString(), true);

            // Parameter 34
            parames[34] = new ReportParameter("XuatThan", "35) Thành phần gia đình xuất thân: " + NhanVienDt.Rows[0]["TenThanhPhanGiaDinh"].ToString(), true);

            // Parameter 35
            parames[35] = new ReportParameter("BiBatTu", "a) Khai rõ: bị bắt, bị tù (từ ngày tháng năm nào đến ngày tháng năm nào, ở đâu), đã khai báo cho ai, những vấn đề gì: " + NhanVienDt.Rows[0]["BiBatTu"].ToString(), true);

            // Parameter 36
            parames[36] = new ReportParameter("LamViecChoCheDoCu", "b) Bản thân có làm việc trong chế độ cũ (cơ quan, đơn vị nào, địa điểm, chức danh, chức vụ, thời gian làm việc....): " + NhanVienDt.Rows[0]["LamViecChoCheDoCu"].ToString(), true);

            // Parameter 37
            parames[37] = new ReportParameter("QuanHeVoiToChucNN", "- Tham gia hoặc có quan hệ với các tổ chức chính trị, kinh tế, xã hội nào ở nước ngoài (làm gì, tổ chức nào, đặt trụ ở ở đâu...?): " + NhanVienDt.Rows[0]["QuanHeVoiToChucNN"].ToString(), true);

            // Parameter 38
            parames[38] = new ReportParameter("ThanhNhanONuocNgoai", "- Có thân nhân (bố, mẹ, vợ, chồng, con, anh chị em ruột) ở nước ngoài (làm gì, địa chỉ...)?: " + NhanVienDt.Rows[0]["ThanhNhanONuocNgoai"].ToString().ToString(), true);

            // Parameter 39
            parames[39] = new ReportParameter("NhaODuocCap", "+ Được cấp, được thuê loại nhà: " + NhanVienDt.Rows[0]["NhaODuocCap"].ToString() + "m2, tổng diện tích sử dụng: " + NhanVienDt.Rows[0]["DienTichSuDungNhaO"].ToString() + " m2", true);
            parames[40] = new ReportParameter("NhaOTuMua", "+ Nhà tự mua, tự xây loại nhà: " + NhanVienDt.Rows[0]["NhaOTuMua"].ToString() + "m2, tổng diện tích sử dụng: " + NhanVienDt.Rows[0]["DienTichSuDungDatO"].ToString() + " m2", true);
            parames[41] = new ReportParameter("DienTichDatDuocCap", "+ Nhà tự mua, tự xây loại nhà: " + NhanVienDt.Rows[0]["DienTichDatDuocCap"].ToString() + "m2, tổng diện tích sử dụng: " + NhanVienDt.Rows[0]["DienTichDatTuMua"].ToString() + " m2", true);
            parames[42] = new ReportParameter("DienTichDatKinhDoanhTrangTrai", "- Đất sản xuất, kinh doanh: (Tổng diện tích đất được cấp, tự mua, tự khai phá...): " + NhanVienDt.Rows[0]["DienTichDatKinhDoanhTrangTrai"].ToString() + " m2", true);

            parames[43] = new ReportParameter("NguoiGioiThieu1", "16.1a) Người giới thiệu 1: " + NhanVienDt.Rows[0]["NguoiGioiThieu1"].ToString(), true);
            parames[44] = new ReportParameter("ChucVuNguoi1", "Chức vũ Đ.vị: " + NhanVienDt.Rows[0]["ChucVuNguoi1"].ToString(), true);
            parames[45] = new ReportParameter("NguoiGioiThieu2", "16.1b) Người giới thiệu 2: " + NhanVienDt.Rows[0]["NguoiGioiThieu2"].ToString(), true);
            parames[46] = new ReportParameter("ChucVuNguoi2", "Chức vũ Đ.vị: " + NhanVienDt.Rows[0]["ChucVuNguoi2"].ToString(), true);
            // Parameter 31
            parames[47] = new ReportParameter("ThuongBinh", "32) Thương binh: " + NhanVienDt.Rows[0]["TenLoaiThuongBinh"].ToString(), true);
            
            this.reportViewer1.LocalReport.EnableExternalImages = true;

            this.reportViewer1.LocalReport.SetParameters(parames);
            ////////////////////////////////////////////////////////////////////////////
            sql = "";
            sql += " select * from QuaTrinhDaoTao qtdt";
            sql += " left join HinhThucDaoTao htdt on qtdt.MaHinhThucDaoTao = htdt.MaHinhThucDaoTao";
            sql += " left join BangGiaoDucPhoThong gdpt on qtdt.MaBangGiaoDucPhoThong = gdpt.MaBangGiaoDucPhoThong";
            sql += " left join BangLyLuanChinhTri llct on qtdt.MaBangLyLuanChinhTri = llct.MaBangLyLuanChinhTri";
            sql += " left join BangNgoaiNgu nn on qtdt.MaBangNgoaiNgu = nn.MaBangNgoaiNgu";
            sql += " left join BangChuyenMonNghiepVu cmnv on qtdt.MaBangChuyenMonNghiepVu = cmnv.MaBangChuyenMonNghiepVu";
            sql+=" where MaNhanVien='" + MaNV + "' ";

            
            cmd = new SqlCommand(sql);
            dataService.Load(cmd);

            DSBaoCao1 myDS = new DSBaoCao1();
            DataTable myDt = dataService;

            for (int i = 0; i < myDt.Rows.Count; i++)
            {
                DataRow myRow = dsBaoCao1.Tables["QuaTrinhDaoTao"].NewRow();
                myRow["TenTruong"] = myDt.Rows[i]["TenTruong"];
                myRow["NganhHoc"] = myDt.Rows[i]["NganhHoc"];
                myRow["HinhThucHoc"] = myDt.Rows[i]["TenHinhThucDaoTao"];

                String CC = "";
                if (!String.IsNullOrEmpty(myDt.Rows[i]["TenBangGiaoDucPhoThong"].ToString()))
                {
                    CC += myDt.Rows[i]["TenBangGiaoDucPhoThong"].ToString();
                }
                if (!String.IsNullOrEmpty(myDt.Rows[i]["TenBangLyLuanChinhTri"].ToString()))
                {
                    CC += ", ";
                    CC += myDt.Rows[i]["TenBangLyLuanChinhTri"].ToString();
                }
                if (!String.IsNullOrEmpty(myDt.Rows[i]["TenBangNgoaiNgu"].ToString()))
                {
                    CC += ", ";
                    CC += myDt.Rows[i]["TenBangNgoaiNgu"].ToString();
                }
                if (!String.IsNullOrEmpty(myDt.Rows[i]["TenBangChuyenMonNghiepVu"].ToString()))
                {
                    CC += ", ";
                    CC += myDt.Rows[i]["TenBangChuyenMonNghiepVu"].ToString();
                }
                myRow["ChungChi"] = CC;

                DateTime dt = new DateTime();
                String ThoiGianHoc = "";
                try
                {
                    dt = (DateTime)myDt.Rows[i]["ThoiGianBatDau"];
                    ThoiGianHoc = dt.ToString("dd/MM/yyyy") + "-";
                }
                catch (Exception ex) { }
                try
                {
                    dt = (DateTime)myDt.Rows[i]["ThoiGianKetThuc"];
                    ThoiGianHoc = dt.ToString("dd/MM/yyyy");
                }
                catch (Exception ex) { }
                myRow["ThoiGianHoc"] = ThoiGianHoc;

                dsBaoCao1.Tables["QuaTrinhDaoTao"].Rows.Add(myRow);
            }


            ReportDataSource rptDataSource = new ReportDataSource("QuaTrinhDaoTao", dsBaoCao1.Tables["QuaTrinhDaoTao"]);
            this.reportViewer1.LocalReport.DataSources.Add(rptDataSource);

            
            /////////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////
            sql = "";
            sql += " select HinhAnh from NhanVien";
            sql += " where MaNhanVien='" + MaNV + "' ";


            cmd = new SqlCommand(sql);
            dataService.Load(cmd);

            myDS = new DSBaoCao1();
            myDt = dataService;

            for (int i = 0; i < myDt.Rows.Count; i++)
            {
                DataRow myRow = dsBaoCao1.Tables["HinhAnhNhanVien"].NewRow();
                myRow["HinhAnh"] = myDt.Rows[i]["HinhAnh"];

                dsBaoCao1.Tables["HinhAnhNhanVien"].Rows.Add(myRow);
            }


            ReportDataSource rptDataSource4 = new ReportDataSource("HinhAnhNhanVien", dsBaoCao1.Tables["HinhAnhNhanVien"]);
            this.reportViewer1.LocalReport.DataSources.Add(rptDataSource4);


            /////////////////////////////////////////////////////////////////////////////////////////////////////
            sql = "";
            sql += " select * from NhanVien nv";
            sql += " join ThanNhan tn on nv.MaNhanVien = tn.MaNhanVien";
            sql += " left join QuanHe qh on qh.MaQuanHe = tn.MaQuanHe";
            sql+=" where nv.MaNhanVien='" + MaNV + "' ";

            cmd = new SqlCommand(sql);
            dataService.Load(cmd);
            myDS = new DSBaoCao1();
            myDt = dataService;

            for (int i = 0; i < myDt.Rows.Count; i++)
            {
                DataRow myRow = dsBaoCao1.Tables["ThanNhan"].NewRow();

                myRow["MaThanNhan"] = myDt.Rows[i]["MaThanNhan"];
                myRow["TenThanNhan"] = myDt.Rows[i]["TenThanNhan"];
                myRow["TenQuanHe"] = myDt.Rows[i]["TenQuanHe"];
                myRow["NamSinh"] = myDt.Rows[i]["NamSinh"];
                myRow["ThongTinCaNhan"] = myDt.Rows[i]["ThongTinCaNhan"];

                dsBaoCao1.Tables["ThanNhan"].Rows.Add(myRow);
            }
            ReportDataSource rptDataSource2 = new ReportDataSource("ThanNhan", dsBaoCao1.Tables["ThanNhan"]);
            this.reportViewer1.LocalReport.DataSources.Add(rptDataSource2);
            ///////////////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////
            sql = "";
            sql += " SELECT * FROM QuaTrinhCongTac qtct";
            sql += " left join ChucVuChinhQuyen cvcq on cvcq.MaChucVuChinhQuyen = qtct.MaChucVuChinhQuyen";
            sql+=" where MaNhanVien='" + MaNV + "' ";

            cmd = new SqlCommand(sql);
            dataService.Load(cmd);
            myDS = new DSBaoCao1();
            myDt = dataService;

            for (int i = 0; i < myDt.Rows.Count; i++)
            {
                DataRow myRow = dsBaoCao1.Tables["QuaTrinhCongTac"].NewRow();

                String TT = "";
                if (!String.IsNullOrEmpty(myDt.Rows[i]["ChucDanh"].ToString()))
                {
                    TT += myDt.Rows[i]["ChucDanh"].ToString();
                }
                if (!String.IsNullOrEmpty(myDt.Rows[i]["TenChucVuChinhQuyen"].ToString()))
                {
                    TT += ", ";
                    TT += myDt.Rows[i]["TenChucVuChinhQuyen"].ToString();
                }
                if (!String.IsNullOrEmpty(myDt.Rows[i]["MoTaCongTac"].ToString()))
                {
                    TT += ", ";
                    TT += myDt.Rows[i]["MoTaCongTac"].ToString();
                }

                myRow["TomTat"] = TT;

                DateTime dt = new DateTime();
                String ThoiGianCongTac = "";
                try
                {
                    dt = (DateTime)myDt.Rows[i]["ThoiGianBatDau"];
                    ThoiGianCongTac = dt.ToString("dd/MM/yyyy") + "-";
                }
                catch (Exception ex) { }
                try
                {
                    dt = (DateTime)myDt.Rows[i]["ThoiGianKetThuc"];
                    ThoiGianCongTac = dt.ToString("dd/MM/yyyy");
                }
                catch (Exception ex) { }
                myRow["ThoiGianCongTac"] = ThoiGianCongTac;

                dsBaoCao1.Tables["QuaTrinhCongTac"].Rows.Add(myRow);
            }
            ReportDataSource rptDataSource3 = new ReportDataSource("QuaTrinhCongTac", dsBaoCao1.Tables["QuaTrinhCongTac"]);
            this.reportViewer1.LocalReport.DataSources.Add(rptDataSource3);
            ////////////////////////////////////////////////////////////////////////////
           

            
            this.reportViewer1.RefreshReport();
        }
        public String getGioiTinh(String Ma)
        {
            if (Ma == "0")
                return "Nữ";
            else
                return "Nam";
        }
        public String GetGiaDinhLietSy(String Ma)
        {
            if (Ma == "True") return "Có";
            else return "";
        }
    }
}
