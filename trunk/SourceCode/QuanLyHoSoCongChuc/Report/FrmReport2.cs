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
            sql += " left join DanToc dv on nv.MaDanToc = dv.MaDanToc";
            sql += " left join TonGiao tg on nv.MaDanToc = tg.MaTonGiao";
            sql += " left join BangLyLuanChinhTri llct on nv.MaBangLyLuanChinhTri = llct.MaBangLyLuanChinhTri";
            sql += " left join BangNgoaiNgu bnn on nv.MaBangNgoaiNgu = bnn.MaBangNgoaiNgu";
            sql += " left join NgheNghiep nn on nv.MaNgheNghiepTruocKhiDuocTuyenDung = nn.MaNgheNghiep";
            sql += " left join DacDiemLichSu ddls on nv.MaNhanVien = ddls.MaNhanVien";
            sql += " left join HoanCanhKinhTe hckt on nv.MaNhanVien = hckt.MaNhanVien";
            sql += " where nv.MaNhanVien='" + MaNV + "' ";

            SqlCommand cmd = new SqlCommand(sql);
            dataService.Load(cmd);

            DataTable NhanVienDt = dataService;

            ReportParameter[] parames = new ReportParameter[38];
            // Parameter 1
            parames[0] = new ReportParameter("HoTen", "1) Họ và tên: " + NhanVienDt.Rows[0]["HoTenKhaiSinh"].ToString() + ". Giới tính: " + getGioiTinh(NhanVienDt.Rows[0]["HoTenKhaiSinh"].ToString()), true);

            // Parameter 2
            parames[5] = new ReportParameter("TenKhac", "2) Các tên gọi khác: ", true);

            // Parameter 3
            parames[6] = new ReportParameter("CapUy", "3) Cấp hủy hiện tại..........................., Cấp ủy kiêm..............", true);
            parames[1] = new ReportParameter("ChucVu", "- Chức vụ: " + NhanVienDt.Rows[0]["TenChucVu"].ToString() , true);
            parames[2] = new ReportParameter("HeSoPhuCap", "- Hệ số phụ cấp: " + NhanVienDt.Rows[0]["HeSoPhuCapChucVu"].ToString(), true);

            // Parameter 4
            DateTime MyDateTime = new DateTime();
            String MyString = NhanVienDt.Rows[0]["NgaySinh"].ToString();
            MyDateTime = Convert.ToDateTime(MyString);

            parames[3] = new ReportParameter("NgaySinh", "4) Sinh ngày: " + MyDateTime.Day + " tháng " + MyDateTime.Month + " năm " + MyDateTime.Year, true);

            // Parameter 5
            parames[4] = new ReportParameter("NoiSinh", "5) Nơi sinh: " + NhanVienDt.Rows[0]["NoiSinh"].ToString(), true);

            // Parameter 6
            parames[7] = new ReportParameter("QueQuan", "6) Quê quán: " + NhanVienDt.Rows[0]["QueQuan"].ToString(), true);

            // Parameter 7
            parames[8] = new ReportParameter("NoiOHienNay", "7) Nơi ở hiện nay: " + NhanVienDt.Rows[0]["NoiOHienNay"].ToString(), true);

            // Parameter 7b

            parames[9] = new ReportParameter("DienThoai", "- Điện thoại: " + NhanVienDt.Rows[0]["SoDienThoai"].ToString(), true);

            // Parameter 8
            parames[10] = new ReportParameter("DanToc", "8) Dân tộc: " + NhanVienDt.Rows[0]["TenDanToc"], true);

            // Parameter 9
            parames[11] = new ReportParameter("TonGiao", "9) Tôn giáo: " + NhanVienDt.Rows[0]["TenTonGiao"], true);

            // Parameter 10
            parames[12] = new ReportParameter("XuatThan", "10) Thành phần gia đình xuất thân: " + NhanVienDt.Rows[0]["TenThanhPhanGiaDinh"], true);

            // Parameter 11
            parames[13] = new ReportParameter("NgheNghiep", "11) Nghề nghiệp bản thân trước khi được tuyển dụng: " + NhanVienDt.Rows[0]["TenNgheNghiep"], true);

            // Parameter 12
            MyDateTime = new DateTime();
            MyString = NhanVienDt.Rows[0]["NgayTuyenDung"].ToString();
            MyDateTime = Convert.ToDateTime(MyString);
            parames[14] = new ReportParameter("NgayDuocTuyenDung", "12) Ngày được tuyển dụng: " + MyDateTime.Day + "/" + MyDateTime.Month + "/" + MyDateTime.Year + ", vào cơ quan: ..............................", true);

            // Parameter 13
            parames[15] = new ReportParameter("NgayVaoCoQuanHienDangCongTac", "13) Ngày vào cơ quan hiện đang công tác: ............, Ngày tham gia cách mạng: .....................", true);

            // Parameter 14
            MyDateTime = new DateTime();
            MyString = NhanVienDt.Rows[0]["NgayVaoDang"].ToString();
            MyDateTime = Convert.ToDateTime(MyString);

            MyString = NhanVienDt.Rows[0]["NgayChinhThuc"].ToString();
            DateTime MyDateTime2 = Convert.ToDateTime(MyString);
            parames[16] = new ReportParameter("NgayVaoDang", "14) Ngày vào Đảng Cộng Sản Việt Nam: " + MyDateTime.Day + "/" + MyDateTime.Month + "/" + MyDateTime.Year + ", Ngày chính thức: " + MyDateTime2.Day + "/" + MyDateTime2.Month + "/" + MyDateTime2.Year, true);

            // Parameter 15
            parames[17] = new ReportParameter("NgayThamGiaCacToChucChinhTri", "15) Tham gia các tổ chức chính trị (Đoàn TNCSHCM, Công đoàn, Hội): " + NhanVienDt.Rows[0]["ThamGiaCTXH"], true);

            // Parameter 16
            parames[18] = new ReportParameter("NgayNhapNgu", "16) Ngày nhập ngũ: ..............., Ngày xuất ngũ: ..............., Quân hàm, chức vụ cao nhất:...............,Năm ......", true);

            // Parameter 17
            parames[19] = new ReportParameter("TrinhDoHocVan", "17) Trình độ học vấn: Giáo dục phổ thông:" + NhanVienDt.Rows[0]["TenHocVi"], true);

            // Parameter 17a
            parames[20] = new ReportParameter("HocVi", "- Học hàm, học vị cao nhất: ....................", true);

            // Parameter 17b
            parames[21] = new ReportParameter("LyLuanChinhTri", "- Lý luận chính trị: " + NhanVienDt.Rows[0]["TenBangLyLuanChinhTri"] + ".   - Ngoại ngữ: " + NhanVienDt.Rows[0]["TenBangNgoaiNgu"], true);

            // Parameter 18
            parames[22] = new ReportParameter("CongTacChinh", "18) Công tác chính đang làm: ", true);

            // Parameter 19
            parames[23] = new ReportParameter("NgachCongChuc", "19) Ngạch công chức: ............. (Mã số: ...........). Bậc lương: ......, hệ số: ..., từ tháng ...........", true);

            // Parameter 20
            parames[24] = new ReportParameter("DanhHieu", "20) Danh hiệu được phong:", true);

            // Parameter 21
            parames[25] = new ReportParameter("SoTruong", "21) Sở trường công tác: ......................... Công việc đã làm lâu nhất: .....................", true);

            // Parameter 22
            parames[26] = new ReportParameter("KhenThuong", "22) Khen thưởng:", true);

            // Parameter 23
            parames[27] = new ReportParameter("KyLuat", "23) Kỷ luật: ", true);

            // Parameter 24
            parames[28] = new ReportParameter("TinhTrangSucKhoe", "24) Tình trạng sức khỏe: ............. Cao ........ Cân nặng ...... Nhóm máu ....", true);

            // Parameter 25
            parames[29] = new ReportParameter("CMND", "25) Số chứng minh nhân dân: " + NhanVienDt.Rows[0]["SoCMND"].ToString() + ". Thương binh loại: ..............Gia đình liệt sỹ: .............", true);

            // Parameter 28
            parames[30] = new ReportParameter("BiBatTu", "a) Khai rõ: bị bắt, bị tù (từ ngày tháng năm nào đến ngày tháng năm nào, ở đâu), đã khai báo cho ai, những vấn đề gì: " + NhanVienDt.Rows[0]["BiBatTu"].ToString(), true);
            parames[31] = new ReportParameter("LamViecChoCheDoCu", "b) Bản thân có làm việc trong chế độ cũ (cơ quan, đơn vị nào, địa điểm, chức danh, chức vụ, thời gian làm việc....): " + NhanVienDt.Rows[0]["LamViecChoCheDoCu"].ToString(), true);

            // Parameter 29
            parames[32] = new ReportParameter("QuanHeVoiToChucNN", "- Tham gia hoặc có quan hệ với các tổ chức chính trị, kinh tế, xã hội nào ở nước ngoài (làm gì, tổ chức nào, đặt trụ ở ở đâu...?): " + NhanVienDt.Rows[0]["QuanHeVoiToChucNN"].ToString(), true);
            parames[33] = new ReportParameter("ThanhNhanONuocNgoai", "- Có thân nhân (bố, mẹ, vợ, chồng, con, anh chị em ruột) ở nước ngoài (làm gì, địa chỉ...)?: " + NhanVienDt.Rows[0]["ThanhNhanONuocNgoai"].ToString().ToString(), true);

            // Parameter 31
            parames[34] = new ReportParameter("NhaODuocCap", "+ Được cấp, được thuê loại nhà: " + NhanVienDt.Rows[0]["NhaODuocCap"].ToString() + "m2, tổng diện tích sử dụng: " + NhanVienDt.Rows[0]["DienTichSuDungNhaO"].ToString() + " m2", true);
            parames[35] = new ReportParameter("NhaOTuMua", "+ Nhà tự mua, tự xây loại nhà: " + NhanVienDt.Rows[0]["NhaOTuMua"].ToString() + "m2, tổng diện tích sử dụng: " + NhanVienDt.Rows[0]["DienTichSuDungDatO"].ToString() + " m2", true);
            parames[36] = new ReportParameter("DienTichDatDuocCap", "+ Nhà tự mua, tự xây loại nhà: " + NhanVienDt.Rows[0]["DienTichDatDuocCap"].ToString() + "m2, tổng diện tích sử dụng: " + NhanVienDt.Rows[0]["DienTichDatTuMua"].ToString() + " m2", true);
            parames[37] = new ReportParameter("DienTichDatKinhDoanhTrangTrai", "- Đất sản xuất, kinh doanh: (Tổng diện tích đất được cấp, tự mua, tự khai phá...): " + NhanVienDt.Rows[0]["DienTichDatKinhDoanhTrangTrai"].ToString() + " m2", true);


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
    }
}
