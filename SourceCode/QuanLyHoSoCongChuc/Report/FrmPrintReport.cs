using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyHoSoCongChuc.Controller;

namespace QuanLyHoSoCongChuc.Report
{
    public partial class FrmPrintReport : Form
    {
        String BaoCao = "";
        String SelectedId;
        String strDt;
        List<String> ChuKi = new List<string>();
        int Level;
        DataService dataService = new DataService();
        public FrmPrintReport(String _BC, String _MaDV, String _dt, List<String> _ChuKi, int _level)
        {
            InitializeComponent();
            BaoCao = _BC;
            SelectedId = _MaDV;
            strDt = _dt;
            ChuKi = _ChuKi;
            Level = _level;
        }

        private void FrmPrintReport_Load(object sender, EventArgs e)
        {
            DataService.OpenConnection();
            if (BaoCao == "1-0") // Bao cáo lương - 0
            {
                this.Text = "Báo cáo lương";
                String sql = " SELECT * FROM DonVi where 1=1";
                sql += LoadSql_MaDonVi();
                SqlCommand cmd = new SqlCommand(sql);

                dataService.Load(cmd);
                DataTable myDt = dataService;
                DSBaoCao1 myDS = new DSBaoCao1();

                //myDS.Tables.Add(myDt);
                for (int i = 0; i < myDt.Rows.Count; i++)
                {
                    DataRow myRow = dsBaoCao1.Tables["BCLuong1"].NewRow();
                    myRow["STT"] = i+1;
                    myRow["TenDonVi"] = myDt.Rows[i]["TenDonVi"];
                    myRow["TongSo1"] = "TongSo1";
                    myRow["CBCC1"] = "CBCC1";
                    myRow["CBVC1"] = "CBVC1";
                    myRow["HD681"] = "HD681";

                    myRow["TongSo2"] = "TongSo2";
                    myRow["CBCC2"] = "CBCC2";
                    myRow["CBVC2"] = "CBVC2";
                    myRow["HD682"] = "HD682";

                    myRow["HeSoLuong"] = 1;
                    myRow["HeSoPCTNVK"] =2;
                    myRow["ChucVu"] = "ChucVu";
                    myRow["ThamNienNghe"] = 3;

                    dsBaoCao1.Tables["BCLuong1"].Rows.Add(myRow);
                }
                CrBaoCaoLuong1 rpt = new CrBaoCaoLuong1();
                rpt.DataDefinition.FormulaFields["NgayThang"].Text = "'" + strDt + "'";
                rpt.DataDefinition.FormulaFields["NLB1"].Text = "'" + ChuKi[0] + "'";
                rpt.DataDefinition.FormulaFields["NLB2"].Text = "'" + ChuKi[1] + "'";
                rpt.DataDefinition.FormulaFields["NLB3"].Text = "'" + ChuKi[2] + "'";
                rpt.DataDefinition.FormulaFields["NK1"].Text = "'" + ChuKi[3] + "'";
                rpt.DataDefinition.FormulaFields["NK2"].Text = "'" + ChuKi[4] + "'";
                rpt.DataDefinition.FormulaFields["NK3"].Text = "'" + ChuKi[5] + "'";

                rpt.SetDataSource(dsBaoCao1.Tables["BCLuong1"]);
                this.crystalReportViewer1.ReportSource = rpt;
            }
            else if (BaoCao == "1-1")// Bao cáo lương - 1
            {
                this.Text = "Báo cáo lương";

                String sql = " select *, cv.TenChucVu, ng.TenNgachCongChuc, temp.MaNgachCongChuc,";
                sql += " temp.BacLuong, temp.HeSoLuong, temp.HeSoPhuCapThamNienVuotKhung,";
                sql += " temp.ChenhLechBaoLuuHeSoLuong, temp.MocTinhNangLuongLanSau, ";
                sql += " temp.HeSoPhuCapChucVu, temp.HeSoPhuCapThamNienNghe, temp.HeSoPhuCapTrachNhiem, ";
                sql += " temp.HeSoPhuCapDocHai, temp.HeSoPhuCapUuDaiNghe, temp.HeSoPhuCapKhac,";

                sql += " temp.HeSoPhuCapThamNienVuotKhung+ temp.ChenhLechBaoLuuHeSoLuong +";
                sql += " temp.HeSoPhuCapChucVu+ temp.HeSoPhuCapThamNienNghe+ temp.HeSoPhuCapTrachNhiem+ ";
                sql += " temp.HeSoPhuCapDocHai+ temp.HeSoPhuCapUuDaiNghe+ temp.HeSoPhuCapKhac as  TongHeSoLuongVaPhuCap,";
                sql += " t.TenBangChuyenMonNghiepVu,dv.TenDonVi,";
                sql += " NgaySinhNam = case MaGioiTinh when 1 then NgaySinh end,";
                sql += " NgaySinhNu = case MaGioiTinh when 0 then NgaySinh end";
                sql += " from NhanVien nv";
                sql += " join DonVi dv on nv.MaDonVi = dv.MaDonVi";
                sql += " left join ChucVu cv on nv.MaChucVu = cv.MaChucVu";
                sql += " left join NgachCongChuc ng on nv.MaNgachCongChuc = ng.MaNgachCongChuc";
                sql += " left join BangChuyenMonNghiepVu t on nv.MaBangChuyenMonNghiepVu = t.MaBangChuyenMonNghiepVu";
                sql += " left join";
                sql += " (select * from LuongPhuCap l1";
                sql += " where MaLuongPhuCap not in";
                sql += " (";
                sql += " select distinct l2.MaLuongPhuCap from LuongPhuCap l2 ";
                sql += " join LuongPhuCap l3 on (l2.MaNhanVien = l3.MaNhanVien and l2.MaLuongPhuCap < l3.MaLuongPhuCap)";
                sql += " )) as temp on nv.MaNhanVien = temp.MaNhanVien";

                sql += " where 1=1";
                sql += " and nv.MaLoaiNhanVien in(1, 2)";
                sql += LoadSql_MaDonVi();


                SqlCommand cmd = new SqlCommand(sql);
                dataService.Load(cmd);
                DataTable myDt = dataService;
                DSBaoCao1 myDS = new DSBaoCao1();

                myDS.Tables.Add(myDt);
                for (int i = 0; i < myDt.Rows.Count; i++)
                {
                    DataRow myRow = dsBaoCao1.Tables["BCLuong2"].NewRow();
                    myRow["STT"] = i + 1;
                    myRow["TenDonVi"] = myDt.Rows[i]["TenDonVi"];
                    myRow["HoTen"] = myDt.Rows[i]["HoTenKhaiSinh"];
                    try
                    {
                        DateTime dt = (DateTime)myDt.Rows[i]["NgaySinhNam"];
                        myRow["NgaySinhNam"] = dt.ToString("dd/MM/yyyy");
                    }
                    catch (Exception ex) { }
                    try
                    {
                        DateTime dt = (DateTime)myDt.Rows[i]["NgaySinhNu"];
                        myRow["NgaySinhNu"] = dt.ToString("dd/MM/yyyy");
                    }
                    catch (Exception ex) { }
                    myRow["TrinhDoDaoTao"] = myDt.Rows[i]["TenBangChuyenMonNghiepVu"];
                    myRow["CongViecDangDN"] = myDt.Rows[i]["TenChucVu"];
                    myRow["MaNgach"] = myDt.Rows[i]["MaNgachCongChuc"];

                    myRow["Bac"] = myDt.Rows[i]["BacLuong"];
                    myRow["HeSoLuong"] = myDt.Rows[i]["HeSoLuong"];
                    myRow["%"] = "";
                    myRow["HeSo"] = myDt.Rows[i]["HeSoPhuCapThamNienVuotKhung"];
                    myRow["ChenhLechBL"] = myDt.Rows[i]["ChenhLechBaoLuuHeSoLuong"];

                    try
                    {
                        DateTime dt = (DateTime)myDt.Rows[i]["MocTinhNangLuongLanSau"];
                        myRow["ThoiGianNLSau"] = dt.ToString("dd/MM/yyyy");
                    }
                    catch (Exception ex) { }

                    myRow["ChucVu"] = myDt.Rows[i]["HeSoPhuCapChucVu"];

                    myRow["ThamNienNghe"] = myDt.Rows[i]["HeSoPhuCapThamNienNghe"];
                    myRow["TrachNhiem"] = myDt.Rows[i]["HeSoPhuCapTrachNhiem"];
                    myRow["DocHai"] = myDt.Rows[i]["HeSoPhuCapDocHai"];
                    myRow["UuDaiNghe"] = myDt.Rows[i]["HeSoPhuCapUuDaiNghe"];

                    myRow["PhuCapKhac"] = myDt.Rows[i]["HeSoPhuCapKhac"];
                    myRow["TongHeSo"] = myDt.Rows[i]["TongHeSoLuongVaPhuCap"];
                    myRow["TongTien"] = "";

     
                    dsBaoCao1.Tables["BCLuong2"].Rows.Add(myRow);
                }
                CrBaoCaoLuong2 rpt = new CrBaoCaoLuong2();
                rpt.DataDefinition.FormulaFields["NgayThang"].Text = "'" + strDt + "'";
                rpt.DataDefinition.FormulaFields["NLB1"].Text = "'" + ChuKi[0] + "'";
                rpt.DataDefinition.FormulaFields["NLB2"].Text = "'" + ChuKi[1] + "'";
                rpt.DataDefinition.FormulaFields["NLB3"].Text = "'" + ChuKi[2] + "'";
                rpt.DataDefinition.FormulaFields["NK1"].Text = "'" + ChuKi[3] + "'";
                rpt.DataDefinition.FormulaFields["NK2"].Text = "'" + ChuKi[4] + "'";
                rpt.DataDefinition.FormulaFields["NK3"].Text = "'" + ChuKi[5] + "'";
                rpt.SetDataSource(dsBaoCao1.Tables["BCLuong2"]);
                this.crystalReportViewer1.ReportSource = rpt;
            }
            else if (BaoCao == "1-2") // Bao cáo lương - 2
            {
                this.Text = "Báo cáo lương";
                String sql = " select *, cv.TenChucVu, ng.TenNgachCongChuc, temp.MaNgachCongChuc,";
                sql += " temp.BacLuong, temp.HeSoLuong, temp.HeSoPhuCapThamNienVuotKhung,";
                sql += " temp.ChenhLechBaoLuuHeSoLuong, temp.MocTinhNangLuongLanSau, ";
                sql += " temp.HeSoPhuCapChucVu, temp.HeSoPhuCapThamNienNghe, temp.HeSoPhuCapTrachNhiem, ";
                sql += " temp.HeSoPhuCapDocHai, temp.HeSoPhuCapUuDaiNghe, temp.HeSoPhuCapKhac,";

                sql += " temp.HeSoPhuCapThamNienVuotKhung+ temp.ChenhLechBaoLuuHeSoLuong +";
                sql += " temp.HeSoPhuCapChucVu+ temp.HeSoPhuCapThamNienNghe+ temp.HeSoPhuCapTrachNhiem+ ";
                sql += " temp.HeSoPhuCapDocHai+ temp.HeSoPhuCapUuDaiNghe+ temp.HeSoPhuCapKhac as  TongHeSoLuongVaPhuCap,";
                sql += " t.TenBangChuyenMonNghiepVu,dv.TenDonVi,";
                sql += " NgaySinhNam = case MaGioiTinh when 1 then NgaySinh end,";
                sql += " NgaySinhNu = case MaGioiTinh when 0 then NgaySinh end";
                sql += " from NhanVien nv";
                sql += " join DonVi dv on nv.MaDonVi = dv.MaDonVi";
                sql += " left join ChucVu cv on nv.MaChucVu = cv.MaChucVu";
                sql += " left join NgachCongChuc ng on nv.MaNgachCongChuc = ng.MaNgachCongChuc";
                sql += " left join BangChuyenMonNghiepVu t on nv.MaBangChuyenMonNghiepVu = t.MaBangChuyenMonNghiepVu";
                sql += " left join";
                sql += " (select * from LuongPhuCap l1";
                sql += " where MaLuongPhuCap not in";
                sql += " (";
                sql += " select distinct l2.MaLuongPhuCap from LuongPhuCap l2 ";
                sql += " join LuongPhuCap l3 on (l2.MaNhanVien = l3.MaNhanVien and l2.MaLuongPhuCap < l3.MaLuongPhuCap)";
                sql += " )) as temp on nv.MaNhanVien = temp.MaNhanVien";

                sql += " where 1=1";
                sql += " and nv.MaLoaiNhanVien in(3, 4)";
                sql += LoadSql_MaDonVi();

                SqlCommand cmd = new SqlCommand(sql);
                dataService.Load(cmd);
                DataTable myDt = dataService;
                DSBaoCao1 myDS = new DSBaoCao1();

                myDS.Tables.Add(myDt);
                for (int i = 0; i < myDt.Rows.Count; i++)
                {
                    DataRow myRow = dsBaoCao1.Tables["BCLuong2"].NewRow();
                    myRow["STT"] = i + 1;
                    myRow["TenDonVi"] = myDt.Rows[i]["TenDonVi"];
                    myRow["HoTen"] = myDt.Rows[i]["HoTenKhaiSinh"];
                    try
                    {
                        DateTime dt = (DateTime)myDt.Rows[i]["NgaySinhNam"];
                        myRow["NgaySinhNam"] = dt.ToString("dd/MM/yyyy");
                    }
                    catch (Exception ex) { }
                    try
                    {
                        DateTime dt = (DateTime)myDt.Rows[i]["NgaySinhNu"];
                        myRow["NgaySinhNu"] = dt.ToString("dd/MM/yyyy");
                    }
                    catch (Exception ex) { }
                    myRow["TrinhDoDaoTao"] = myDt.Rows[i]["TenBangChuyenMonNghiepVu"];
                    myRow["CongViecDangDN"] = myDt.Rows[i]["TenChucVu"];
                    myRow["MaNgach"] = myDt.Rows[i]["MaNgachCongChuc"];

                    myRow["Bac"] = myDt.Rows[i]["BacLuong"];
                    myRow["HeSoLuong"] = myDt.Rows[i]["HeSoLuong"];
                    myRow["%"] = "";
                    myRow["HeSo"] = myDt.Rows[i]["HeSoPhuCapThamNienVuotKhung"];
                    myRow["ChenhLechBL"] = myDt.Rows[i]["ChenhLechBaoLuuHeSoLuong"];

                    try
                    {
                        DateTime dt = (DateTime)myDt.Rows[i]["MocTinhNangLuongLanSau"];
                        myRow["ThoiGianNLSau"] = dt.ToString("dd/MM/yyyy");
                    }
                    catch (Exception ex) { }

                    myRow["ChucVu"] = myDt.Rows[i]["HeSoPhuCapChucVu"];

                    myRow["TrachNhiem"] = myDt.Rows[i]["HeSoPhuCapTrachNhiem"];
                    myRow["DocHai"] = myDt.Rows[i]["HeSoPhuCapDocHai"];
                    myRow["UuDaiNghe"] = myDt.Rows[i]["HeSoPhuCapUuDaiNghe"];

                    myRow["PhuCapKhac"] = myDt.Rows[i]["HeSoPhuCapKhac"];
                    myRow["TongHeSo"] = myDt.Rows[i]["TongHeSoLuongVaPhuCap"];
                    myRow["TongTien"] = "";

                    dsBaoCao1.Tables["BCLuong2"].Rows.Add(myRow);
                }
                CrBaoCaoLuong3 rpt = new CrBaoCaoLuong3();
                rpt.DataDefinition.FormulaFields["NgayThang"].Text = "'" + strDt + "'";
                rpt.DataDefinition.FormulaFields["NLB1"].Text = "'" + ChuKi[0] + "'";
                rpt.DataDefinition.FormulaFields["NLB2"].Text = "'" + ChuKi[1] + "'";
                rpt.DataDefinition.FormulaFields["NLB3"].Text = "'" + ChuKi[2] + "'";
                rpt.DataDefinition.FormulaFields["NK1"].Text = "'" + ChuKi[3] + "'";
                rpt.DataDefinition.FormulaFields["NK2"].Text = "'" + ChuKi[4] + "'";
                rpt.DataDefinition.FormulaFields["NK3"].Text = "'" + ChuKi[5] + "'";
                rpt.SetDataSource(dsBaoCao1.Tables["BCLuong2"]);
                this.crystalReportViewer1.ReportSource = rpt;
            }
            else if (BaoCao == "2") // danh sách nâng lương
            {
                this.Text = "Danh sách nâng lương";
                String sql = " select nv.*, t.TenBangChuyenMonNghiepVu, dv.TenDonVi";
                //sql += " NgaySinhNam = case MaGioiTinh when 1 then NgaySinh end,";
                //sql += " NgaySinhNu = case MaGioiTinh when 0 then NgaySinh end";
                sql += " from NhanVien nv left join BangChuyenMonNghiepVu t on nv.MaBangChuyenMonNghiepVu = t.MaBangChuyenMonNghiepVu";
                sql += " join DonVi dv on nv.MaDonVi = dv.MaDonVi";
                sql += " where 1=1";
                sql += LoadSql_MaDonVi();


                SqlCommand cmd = new SqlCommand(sql);
                dataService.Load(cmd);
                DataTable myDt = dataService;
                DSBaoCao1 myDS = new DSBaoCao1();

                myDS.Tables.Add(myDt);
                for (int i = 0; i < myDt.Rows.Count; i++)
                {
                    DataRow myRow = dsBaoCao1.Tables["DSNangLuong"].NewRow();
                    myRow["STT"] = i + 1;
                    myRow["TenDonVi"] = myDt.Rows[i]["TenDonVi"];
                    myRow["HoTen"] = myDt.Rows[i]["HoTenKhaiSinh"];
                    try { 
                        DateTime dt = (DateTime)myDt.Rows[i]["NgaySinh"];
                        myRow["NamSinh"] = dt.ToString("yyyy");
                    }
                    catch(Exception ex){}
                    
                    myRow["TrinhDoDaoTao"] = myDt.Rows[i]["TenBangChuyenMonNghiepVu"];
                    myRow["TenNgach1"] = "HD681";
                    myRow["MaNgach1"] = "TongSo2";
                    myRow["Bac1"] = "CBCC2";
                    myRow["HeSoLuong1"] = "CBVC2";
                    myRow["HeSoCL1"] = "CBVC2";
                    myRow["NgayThangNamHuong1"] = "HD682";

                    myRow["TenNgach2"] = "HD681";
                    myRow["MaNgach2"] = "TongSo2";
                    myRow["Bac2"] = "CBCC2";
                    myRow["HeSoLuong2"] = "CBVC2";
                    myRow["HeSoCL2"] = "CBVC2";
                    myRow["NgayThangNamHuong2"] = "HD682";

                    myRow["ChenhLech"] = "HD682";
                    myRow["SoThangDuocHuong"] = "HD682";
                    myRow["TongTienLuongTang"] = "HD682";

                    dsBaoCao1.Tables["DSNangLuong"].Rows.Add(myRow);
                }
                CrDanhSachNangLuong rpt = new CrDanhSachNangLuong();
                rpt.DataDefinition.FormulaFields["NgayThang"].Text = "'" + strDt + "'";
                rpt.DataDefinition.FormulaFields["NLB1"].Text = "'" + ChuKi[0] + "'";
                rpt.DataDefinition.FormulaFields["NLB2"].Text = "'" + ChuKi[1] + "'";
                rpt.DataDefinition.FormulaFields["NLB3"].Text = "'" + ChuKi[2] + "'";
                rpt.DataDefinition.FormulaFields["NK1"].Text = "'" + ChuKi[3] + "'";
                rpt.DataDefinition.FormulaFields["NK2"].Text = "'" + ChuKi[4] + "'";
                rpt.DataDefinition.FormulaFields["NK3"].Text = "'" + ChuKi[5] + "'";
                rpt.SetDataSource(dsBaoCao1.Tables["DSNangLuong"]);
                this.crystalReportViewer1.ReportSource = rpt;
            }
            else if (BaoCao == "3") // Danh sách phụ cấp thâm niên vượt khung
            {
                this.Text = "Danh sách phụ cấp thâm niên vượt khung";
                String sql = " select nv.*, t.TenBangChuyenMonNghiepVu, dv.TenDonVi";
                sql += " from NhanVien nv left join BangChuyenMonNghiepVu t on nv.MaBangChuyenMonNghiepVu = t.MaBangChuyenMonNghiepVu";
                sql += " join DonVi dv on nv.MaDonVi = dv.MaDonVi";
                sql += " where 1=1";
                sql += LoadSql_MaDonVi();


                SqlCommand cmd = new SqlCommand(sql);
                dataService.Load(cmd);
                DataTable myDt = dataService;
                DSBaoCao1 myDS = new DSBaoCao1();

                myDS.Tables.Add(myDt);
                for (int i = 0; i < myDt.Rows.Count; i++)
                {
                    DataRow myRow = dsBaoCao1.Tables["PCVK"].NewRow();
                    myRow["STT"] = i + 1;
                    myRow["TenDonVi"] = myDt.Rows[i]["TenDonVi"];
                    myRow["HoTen"] = myDt.Rows[i]["HoTenKhaiSinh"];
                    try
                    {
                        DateTime dt = (DateTime)myDt.Rows[i]["NgaySinh"];
                        myRow["NamSinh"] = dt.ToString("yyyy");
                    }
                    catch (Exception ex) { }

                    myRow["TrinhDoDaoTao"] = myDt.Rows[i]["TenBangChuyenMonNghiepVu"];
                    myRow["TenNgach1"] = "HD681";
                    myRow["MaNgach1"] = "TongSo2";
                    myRow["BacCuoi1"] = "CBCC2";
                    myRow["HeSoLuongMoi1"] = "CBVC2";
                    myRow["%PC1"] = "CBVC2";
                    myRow["HeSoPC1"] = "CBVC2";
                    myRow["HeSoCL1"] = "CBVC2";
                    myRow["NgayHuong1"] = "HD682";

                    myRow["%PC2"] = "CBVC2";
                    myRow["HeSoPC2"] = "CBVC2";
                    myRow["HeSoCL2"] = "CBVC2";
                    myRow["NgayHuong2"] = "HD682";

                    myRow["ChenhLech"] = "HD682";
                    dsBaoCao1.Tables["PCVK"].Rows.Add(myRow);
                }
                CrBaoCaoDanhSachVuotKhung rpt = new CrBaoCaoDanhSachVuotKhung();
                rpt.DataDefinition.FormulaFields["NgayThang"].Text = "'" + strDt + "'";
                rpt.DataDefinition.FormulaFields["Title"].Text = "'DANH SÁCH KẾT QUẢ NÂNG PCTNVK CB, CC UBND HUYỆN "+strDt.ToUpper()+"'";
                rpt.DataDefinition.FormulaFields["NLB1"].Text = "'" + ChuKi[0] + "'";
                rpt.DataDefinition.FormulaFields["NLB2"].Text = "'" + ChuKi[1] + "'";
                rpt.DataDefinition.FormulaFields["NLB3"].Text = "'" + ChuKi[2] + "'";
                rpt.DataDefinition.FormulaFields["NK1"].Text = "'" + ChuKi[3] + "'";
                rpt.DataDefinition.FormulaFields["NK2"].Text = "'" + ChuKi[4] + "'";
                rpt.DataDefinition.FormulaFields["NK3"].Text = "'" + ChuKi[5] + "'";
                rpt.SetDataSource(dsBaoCao1.Tables["PCVK"]);
                this.crystalReportViewer1.ReportSource = rpt;
            }
            else if (BaoCao == "4-0") // Danh sách CB, CC, VC và hợp đồng 1    
            {
                this.Text = "Danh sách CB, CC, VC và hợp đồng";
                String sql = " select nv.*, cv.TenChucVu, t.TenBangChuyenMonNghiepVu, t.ChuyenNganh, tt.TenBangLyLuanChinhTri";
                sql += " from NhanVien nv left join ChucVu cv on nv.MaChucVu = cv.MaChucVu";
                sql += " left join BangChuyenMonNghiepVu t on nv.MaBangChuyenMonNghiepVu = t.MaBangChuyenMonNghiepVu";
                sql += " left join BangLyLuanChinhTri tt on nv.MaBangLyLuanChinhTri = tt.MaBangLyLuanChinhTri";
                sql += " join DonVi dv on nv.MaDonVi = dv.MaDonVi";
                sql += " where 1=1";
                sql += LoadSql_MaDonVi();

                SqlCommand cmd = new SqlCommand(sql);
                dataService.Load(cmd);
                DataTable myDt = dataService;

                DSBaoCao1 myDS = new DSBaoCao1();

                myDS.Tables.Add(myDt);
                for (int i = 0; i < myDt.Rows.Count; i++)
                {
                    DataRow myRow = dsBaoCao1.Tables["NhanVien"].NewRow();
                    myRow["MaNhanVien"] = myDt.Rows[i]["MaNhanVien"];
                    myRow["MaGioiTinh"] = myDt.Rows[i]["MaGioiTinh"];
                    myRow["HoTenKhaiSinh"] = myDt.Rows[i]["HoTenKhaiSinh"];
                    myRow["QueQuan"] = myDt.Rows[i]["QueQuan"];
                    myRow["TamTru"] = myDt.Rows[i]["NoiOHienNay"];
                    myRow["TenChucVu"] = myDt.Rows[i]["TenChucVu"];
                    myRow["TenBangChuyenMonNghiepVu"] = myDt.Rows[i]["TenBangChuyenMonNghiepVu"];
                    myRow["ChuyenNganh"] = myDt.Rows[i]["ChuyenNganh"];
                    myRow["TenBangLyLuanChinhTri"] = myDt.Rows[i]["TenBangLyLuanChinhTri"];

                    DateTime dt = new DateTime();
                    
                    try
                    {
                        dt = (DateTime)myDt.Rows[i]["NgaySinh"];
                        myRow["NgaySinh"] = dt.ToString("dd/MM/yyyy");
                    }
                    catch (Exception ex) { }
                   
                    dsBaoCao1.Tables["NhanVien"].Rows.Add(myRow);
                }

                CrBaoCaoDanhSachCBCCVC1 rpt = new CrBaoCaoDanhSachCBCCVC1();
                rpt.DataDefinition.FormulaFields["NgayThang"].Text = "'" + strDt + "'";
                rpt.DataDefinition.FormulaFields["NLB1"].Text = "'" + ChuKi[0] + "'";
                rpt.DataDefinition.FormulaFields["NLB2"].Text = "'" + ChuKi[1] + "'";
                rpt.DataDefinition.FormulaFields["NLB3"].Text = "'" + ChuKi[2] + "'";
                rpt.DataDefinition.FormulaFields["NK1"].Text = "'" + ChuKi[3] + "'";
                rpt.DataDefinition.FormulaFields["NK2"].Text = "'" + ChuKi[4] + "'";
                rpt.DataDefinition.FormulaFields["NK3"].Text = "'" + ChuKi[5] + "'";
                rpt.SetDataSource(dsBaoCao1.Tables["NhanVien"]);
                this.crystalReportViewer1.ReportSource = rpt;
            }
            else if (BaoCao == "4-1") // Danh sách CB, CC, VC và hợp đồng 2    
            {
                this.Text = "Danh sách CB, CC, VC và hợp đồng";
                String sql = " select nv.*, cv.TenChucVu, t.TenBangChuyenMonNghiepVu,t.ChuyenNganh, tt.TenBangLyLuanChinhTri";
                sql += " from NhanVien nv left join ChucVu cv on nv.MaChucVu = cv.MaChucVu";
                sql += " left join BangChuyenMonNghiepVu t on nv.MaBangChuyenMonNghiepVu = t.MaBangChuyenMonNghiepVu";
                sql += " left join BangLyLuanChinhTri tt on nv.MaBangLyLuanChinhTri = tt.MaBangLyLuanChinhTri";
                sql += " join DonVi dv on nv.MaDonVi = dv.MaDonVi";
                sql += " where 1=1";
                sql += LoadSql_MaDonVi();

                SqlCommand cmd = new SqlCommand(sql);
                dataService.Load(cmd);
                DataTable myDt = dataService;

                DSBaoCao1 myDS = new DSBaoCao1();

                myDS.Tables.Add(myDt);
                for (int i = 0; i < myDt.Rows.Count; i++)
                {
                    DataRow myRow = dsBaoCao1.Tables["NhanVien"].NewRow();
                    myRow["MaNhanVien"] = myDt.Rows[i]["MaNhanVien"];
                    myRow["MaGioiTinh"] = myDt.Rows[i]["MaGioiTinh"];
                    myRow["HoTenKhaiSinh"] = myDt.Rows[i]["HoTenKhaiSinh"];
                    myRow["QueQuan"] = myDt.Rows[i]["QueQuan"];
                    myRow["TamTru"] = myDt.Rows[i]["NoiOHienNay"];
                    myRow["TenChucVu"] = myDt.Rows[i]["TenChucVu"];
                    myRow["TenBangChuyenMonNghiepVu"] = myDt.Rows[i]["TenBangChuyenMonNghiepVu"];
                    myRow["ChuyenNganh"] = myDt.Rows[i]["ChuyenNganh"];
                    myRow["TenBangLyLuanChinhTri"] = myDt.Rows[i]["TenBangLyLuanChinhTri"];

                    DateTime dt = new DateTime();

                    try
                    {
                        dt = (DateTime)myDt.Rows[i]["NgaySinh"];
                        myRow["NgaySinh"] = dt.ToString("dd/MM/yyyy");
                    }
                    catch (Exception ex) { }

                    dsBaoCao1.Tables["NhanVien"].Rows.Add(myRow);
                }

                CrBaoCaoDanhSachCBCCVC2 rpt = new CrBaoCaoDanhSachCBCCVC2();
                rpt.DataDefinition.FormulaFields["NgayThang"].Text = "'" + strDt + "'";
                rpt.DataDefinition.FormulaFields["NLB1"].Text = "'" + ChuKi[0] + "'";
                rpt.DataDefinition.FormulaFields["NLB2"].Text = "'" + ChuKi[1] + "'";
                rpt.DataDefinition.FormulaFields["NLB3"].Text = "'" + ChuKi[2] + "'";
                rpt.DataDefinition.FormulaFields["NK1"].Text = "'" + ChuKi[3] + "'";
                rpt.DataDefinition.FormulaFields["NK2"].Text = "'" + ChuKi[4] + "'";
                rpt.DataDefinition.FormulaFields["NK3"].Text = "'" + ChuKi[5] + "'";
                rpt.SetDataSource(dsBaoCao1.Tables["NhanVien"]);
                this.crystalReportViewer1.ReportSource = rpt;
            }
            else if (BaoCao == "4-2") // Danh sách CB, CC, VC và hợp đồng 3  
            {
                this.Text = "Danh sách CB, CC, VC và hợp đồng";
                String sql = " select nv.*, cv.TenChucVu, t.TenBangChuyenMonNghiepVu, t.ChuyenNganh, tt.TenBangLyLuanChinhTri";
                sql += " from NhanVien nv left join ChucVu cv on nv.MaChucVu = cv.MaChucVu";
                sql += " left join BangChuyenMonNghiepVu t on nv.MaBangChuyenMonNghiepVu = t.MaBangChuyenMonNghiepVu";
                sql += " left join BangLyLuanChinhTri tt on nv.MaBangLyLuanChinhTri = tt.MaBangLyLuanChinhTri";
                sql += " join DonVi dv on nv.MaDonVi = dv.MaDonVi";
                sql += " where 1=1";
                sql += LoadSql_MaDonVi();

                SqlCommand cmd = new SqlCommand(sql);
                dataService.Load(cmd);
                DataTable myDt = dataService;

                DSBaoCao1 myDS = new DSBaoCao1();

                myDS.Tables.Add(myDt);
                for (int i = 0; i < myDt.Rows.Count; i++)
                {
                    DataRow myRow = dsBaoCao1.Tables["NhanVien"].NewRow();
                    myRow["MaNhanVien"] = myDt.Rows[i]["MaNhanVien"];
                    myRow["MaGioiTinh"] = myDt.Rows[i]["MaGioiTinh"];
                    myRow["HoTenKhaiSinh"] = myDt.Rows[i]["HoTenKhaiSinh"];
                    myRow["QueQuan"] = myDt.Rows[i]["QueQuan"];
                    myRow["TamTru"] = myDt.Rows[i]["NoiOHienNay"];
                    myRow["TenChucVu"] = myDt.Rows[i]["TenChucVu"];
                    myRow["TenBangChuyenMonNghiepVu"] = myDt.Rows[i]["TenBangChuyenMonNghiepVu"];
                    myRow["ChuyenNganh"] = myDt.Rows[i]["ChuyenNganh"];
                    myRow["TenBangLyLuanChinhTri"] = myDt.Rows[i]["TenBangLyLuanChinhTri"];

                    DateTime dt = new DateTime();

                    try
                    {
                        dt = (DateTime)myDt.Rows[i]["NgaySinh"];
                        myRow["NgaySinh"] = dt.ToString("dd/MM/yyyy");
                    }
                    catch (Exception ex) { }

                    dsBaoCao1.Tables["NhanVien"].Rows.Add(myRow);
                }

                CrBaoCaoDanhSachCBCCVC3 rpt = new CrBaoCaoDanhSachCBCCVC3();
                rpt.DataDefinition.FormulaFields["NgayThang"].Text = "'" + strDt + "'";
                rpt.DataDefinition.FormulaFields["NLB1"].Text = "'" + ChuKi[0] + "'";
                rpt.DataDefinition.FormulaFields["NLB2"].Text = "'" + ChuKi[1] + "'";
                rpt.DataDefinition.FormulaFields["NLB3"].Text = "'" + ChuKi[2] + "'";
                rpt.DataDefinition.FormulaFields["NK1"].Text = "'" + ChuKi[3] + "'";
                rpt.DataDefinition.FormulaFields["NK2"].Text = "'" + ChuKi[4] + "'";
                rpt.DataDefinition.FormulaFields["NK3"].Text = "'" + ChuKi[5] + "'";
                rpt.SetDataSource(dsBaoCao1.Tables["NhanVien"]);
                this.crystalReportViewer1.ReportSource = rpt;
            }
            else if (BaoCao == "5") // Danh sách đủ tuổi về hưu, đủ năm công tác về hưu
            {
                this.Text = "Danh sách đủ tuổi về hưu, đủ năm công tác về hưu";
                String sql = " select nv.*, cv.TenChucVu, t.TenBangChuyenMonNghiepVu,t.ChuyenNganh, tt.TenBangLyLuanChinhTri, dv.TenDonVi, lpc.HeSoLuong, -1 as TuoiDoi, ";
                sql += " DATEADD (yyyy ,  (case MaGioiTinh when 1 then 60 else 55 end) , NgaySinh ) as ThoiGianBatDauTru";
                sql += " from NhanVien nv left join ChucVu cv on nv.MaChucVu = cv.MaChucVu";
                sql += " left join BangChuyenMonNghiepVu t on nv.MaBangChuyenMonNghiepVu = t.MaBangChuyenMonNghiepVu";
                sql += " left join BangLyLuanChinhTri tt on nv.MaBangLyLuanChinhTri = tt.MaBangLyLuanChinhTri";
                sql += " join DonVi dv on nv.MaDonVi = dv.MaDonVi";
                sql += " left join LuongPhuCap lpc on lpc.MaNhanVien = nv.MaNhanVien";
                sql += " where 1=1";
                sql += LoadSql_MaDonVi();

                sql += " and (DATEDIFF(YYYY, NgaySinh, GETDATE()) > ";
                sql += " case MaGioiTinh";
                sql += " when 1 then 60";
                sql += " else 55";
                sql += " end)";
                sql += " or";
                sql += " ((DATEDIFF(YYYY, NgaySinh, GETDATE()) = ";
                sql += " case MaGioiTinh";
                sql += " when 1 then 60";
                sql += " else 55";
                sql += " end)";
                sql += " and";
                sql += " (datepart(mm,getdate()) - datepart(mm,NgaySinh) ) >= 6";
                sql += " )";

                SqlCommand cmd = new SqlCommand(sql);
                dataService.Load(cmd);
                DataTable myDt = dataService;

                DSBaoCao1 myDS = new DSBaoCao1();
                
                myDS.Tables.Add(myDt);
                for (int i = 0; i < myDt.Rows.Count; i++)
                {
                    DataRow myRow = dsBaoCao1.Tables["NhanVien"].NewRow();
                    myRow["MaNhanVien"] = myDt.Rows[i]["MaNhanVien"];
                    myRow["MaGioiTinh"] = myDt.Rows[i]["MaGioiTinh"];
                    myRow["HoTenKhaiSinh"] = myDt.Rows[i]["HoTenKhaiSinh"];
                    myRow["TenDonVi"] = myDt.Rows[i]["TenDonVi"];
                    myRow["QueQuan"] = myDt.Rows[i]["QueQuan"];
                    myRow["TuoiDoi"] = myDt.Rows[i]["TuoiDoi"];
                    myRow["HeSoLuong"] = myDt.Rows[i]["HeSoLuong"];
                    myRow["TenChucVu"] = myDt.Rows[i]["TenChucVu"];
                    myRow["TenBangChuyenMonNghiepVu"] = myDt.Rows[i]["TenBangChuyenMonNghiepVu"];
                    myRow["ChuyenNganh"] = myDt.Rows[i]["ChuyenNganh"];
                    myRow["TenBangLyLuanChinhTri"] = myDt.Rows[i]["TenBangLyLuanChinhTri"];
  
                    DateTime dt = (DateTime)myDt.Rows[i]["NgaySinh"];
                    myRow["TuoiDoi"] = DateTime.Now.Year - dt.Year;
                    try
                    {
                        dt = (DateTime)myDt.Rows[i]["NgayChinhThuc"];
                        myRow["NgayChinhThuc"] = dt.ToString("dd/MM/yyyy");
                    }
                    catch (Exception ex) { }
                    try
                    {
                        dt = (DateTime)myDt.Rows[i]["NgaySinh"];
                        myRow["NgaySinh"] = dt.ToString("dd/MM/yyyy");
                    }
                    catch (Exception ex) { }
                    try
                    {
                        dt = (DateTime)myDt.Rows[i]["ThoiGianBatDauTru"];
                        myRow["ThoiGianBatDauTru"] = dt.ToString("dd/MM/yyyy");
                    }
                    catch (Exception ex) { }
                    dsBaoCao1.Tables["NhanVien"].Rows.Add(myRow);
                }

                CrDanhSachNghiHuu rpt = new CrDanhSachNghiHuu();
                rpt.DataDefinition.FormulaFields["NgayThang"].Text = "'" + strDt + "'";
                rpt.DataDefinition.FormulaFields["NLB1"].Text = "'" + ChuKi[0] + "'";
                rpt.DataDefinition.FormulaFields["NLB2"].Text = "'" + ChuKi[1] + "'";
                rpt.DataDefinition.FormulaFields["NLB3"].Text = "'" + ChuKi[2] + "'";
                rpt.DataDefinition.FormulaFields["NK1"].Text = "'" + ChuKi[3] + "'";
                rpt.DataDefinition.FormulaFields["NK2"].Text = "'" + ChuKi[4] + "'";
                rpt.DataDefinition.FormulaFields["NK3"].Text = "'" + ChuKi[5] + "'";
                rpt.SetDataSource(dsBaoCao1.Tables["NhanVien"]);
                this.crystalReportViewer1.ReportSource = rpt;
            }
            else if (BaoCao == "6") // SYLL
            {
                //String MaNV = SelectedId;

                //this.Text = "Sơ yếu lí lịch";
                //CrSYLL rpt = new CrSYLL();
                
                //String sql = "select * from NhanVien nv left join ChucVu cv on nv.MaChucVu = cv.MaChucVu";
                //sql+= " left join ";
                //sql+= "                  (select * from LuongPhuCap l1";
                //sql+= "                  where MaLuongPhuCap not in";
                //sql+= "                  (";
                //sql+= "                  select distinct l2.MaLuongPhuCap from LuongPhuCap l2 ";
                //sql+= "                  join LuongPhuCap l3 on (l2.MaNhanVien = l3.MaNhanVien and l2.MaLuongPhuCap < l3.MaLuongPhuCap)";
                //sql+= "                  )) as temp on nv.MaNhanVien = temp.MaNhanVien";
                //sql+= " left join ThanhPhanGiaDinh tpgd on nv.MaThanhPhanGiaDinh = tpgd.MaThanhPhanGiaDinh";
                //sql+= " left join HocVi hv on nv.MaHocVi = hv.MaHocVi";
                //sql+= " left join DanToc dv on nv.MaDanToc = dv.MaDanToc";
                //sql+= " left join TonGiao tg on nv.MaDanToc = tg.MaTonGiao";
                //sql+= " left join BangLyLuanChinhTri llct on nv.MaBangLyLuanChinhTri = llct.MaBangLyLuanChinhTri";
                //sql+= " left join BangNgoaiNgu bnn on nv.MaBangNgoaiNgu = bnn.MaBangNgoaiNgu";
                //sql+= " left join NgheNghiep nn on nv.MaNgheNghiepTruocKhiDuocTuyenDung = nn.MaNgheNghiep";
                //sql+= " left join DacDiemLichSu ddls on nv.MaNhanVien = ddls.MaNhanVien";
                //sql+= " left join HoanCanhKinhTe hckt on nv.MaNhanVien = hckt.MaNhanVien";
                //sql+= " where nv.MaNhanVien='" + MaNV + "' ";

                //DataService.OpenConnection();
                //SqlCommand cmd = new SqlCommand(sql);
                //dataService.Load(cmd);

                //DataTable NhanVienDt = dataService;

                //// Parameter 1
                //rpt.DataDefinition.FormulaFields["HoTen"].Text = "'1) Họ và tên: " + NhanVienDt.Rows[0]["HoTenKhaiSinh"].ToString() + ". Giới tính: " + getGioiTinh(NhanVienDt.Rows[0]["HoTenKhaiSinh"].ToString()) + "'";

                //// Parameter 3b
                //rpt.DataDefinition.FormulaFields["ChucVu"].Text = "'- Chức vụ: " + NhanVienDt.Rows[0]["TenChucVu"].ToString() + "'";
                //rpt.DataDefinition.FormulaFields["HeSoPhuCap"].Text = "'- Hệ số phụ cấp: " + NhanVienDt.Rows[0]["HeSoPhuCapChucVu"].ToString() + "'";

                //// Parameter 4
                //DateTime MyDateTime = new DateTime();
                //String MyString = NhanVienDt.Rows[0]["NgaySinh"].ToString();
                //MyDateTime = Convert.ToDateTime(MyString);


                //rpt.DataDefinition.FormulaFields["NgaySinh"].Text = "'4) Sinh ngày: " + MyDateTime.Day + " tháng " + MyDateTime.Month + " năm " + MyDateTime.Year + "'";

                //// Parameter 5
                //rpt.DataDefinition.FormulaFields["NoiSinh"].Text = "'5) Nơi sinh: " + NhanVienDt.Rows[0]["NoiSinh"].ToString() + "'";

                //// Parameter 6
                //rpt.DataDefinition.FormulaFields["QueQuan"].Text = "'6) Quê quán: " + NhanVienDt.Rows[0]["QueQuan"].ToString() + "'";

                //// Parameter 7
                //rpt.DataDefinition.FormulaFields["NoiOHienNay"].Text = "'7) Nơi ở hiện nay: " + NhanVienDt.Rows[0]["NoiOHienNay"].ToString() + "'";

                //// Parameter 7b

                //rpt.DataDefinition.FormulaFields["DienThoai"].Text = "'- Điện thoại: " + NhanVienDt.Rows[0]["SoDienThoai"].ToString() + "'";

                //// Parameter 8
                //rpt.DataDefinition.FormulaFields["DanToc"].Text = "'8) Dân tộc: " + NhanVienDt.Rows[0]["TenDanToc"] + "'";

                //// Parameter 9
                //rpt.DataDefinition.FormulaFields["TonGiao"].Text = "'9) Tôn giáo: " + NhanVienDt.Rows[0]["TenTonGiao"] + "'";

                //// Parameter 10
                //rpt.DataDefinition.FormulaFields["XuatThan"].Text = "'10) Thành phần gia đình xuất thân: " + NhanVienDt.Rows[0]["TenThanhPhanGiaDinh"] + "'";

                //// Parameter 11
                //rpt.DataDefinition.FormulaFields["NgheNghiep"].Text = "'11) Nghề nghiệp bản thân trước khi được tuyển dụng: " + NhanVienDt.Rows[0]["TenNgheNghiep"] + "'";

                //// Parameter 12
                //MyDateTime = new DateTime();
                //MyString = NhanVienDt.Rows[0]["NgayTuyenDung"].ToString();
                //MyDateTime = Convert.ToDateTime(MyString);
                //rpt.DataDefinition.FormulaFields["NgayDuocTuyenDung"].Text = "'12) Ngày được tuyển dụng: " + MyDateTime.Day + "/" + MyDateTime.Month + "/" + MyDateTime.Year + ", vào cơ quan: ..............................'";

                //// Parameter 13

                //rpt.DataDefinition.FormulaFields["NgayVaoCoQuanHienDangCongTac"].Text = "'13) Ngày vào cơ quan hiện đang công tác: ............, Ngày tham gia cách mạng: .....................'";

                //// Parameter 14
                //MyDateTime = new DateTime();
                //MyString = NhanVienDt.Rows[0]["NgayVaoDang"].ToString();
                //MyDateTime = Convert.ToDateTime(MyString);

                //MyString = NhanVienDt.Rows[0]["NgayChinhThuc"].ToString();
                //DateTime MyDateTime2 = Convert.ToDateTime(MyString);
                //rpt.DataDefinition.FormulaFields["NgayVaoDang"].Text = "'14) Ngày vào Đảng Cộng Sản Việt Nam: " + MyDateTime.Day + "/" + MyDateTime.Month + "/" + MyDateTime.Year + ", Ngày chính thức: " + MyDateTime2.Day + "/" + MyDateTime2.Month + "/" + MyDateTime2.Year + "'";

                //// Parameter 15
                //rpt.DataDefinition.FormulaFields["NgayThamGiaCacToChucChinhTri"].Text = "'15) Tham gia các tổ chức chính trị (Đoàn TNCSHCM, Công đoàn, Hội): " + NhanVienDt.Rows[0]["ThamGiaCTXH"] + "'";

                //// Parameter 16
                //rpt.DataDefinition.FormulaFields["NgayNhapNgu"].Text = "'16) Ngày nhập ngũ: ..............., Ngày xuất ngũ: ..............., Quân hàm, chức vụ cao nhất:...............,Năm ......'";

                //// Parameter 17
                //rpt.DataDefinition.FormulaFields["TrinhDoHocVan"].Text = "'17) Trình độ học vấn: Giáo dục phổ thông:" + NhanVienDt.Rows[0]["TenHocVi"] + "'";

                //// Parameter 17a
                //rpt.DataDefinition.FormulaFields["HocVi"].Text = "'- Học hàm, học vị cao nhất: ....................'";

                //// Parameter 17b
                //rpt.DataDefinition.FormulaFields["LyLuanChinhTri"].Text = "'- Lý luận chính trị: " + NhanVienDt.Rows[0]["TenBangLyLuanChinhTri"] + ".   - Ngoại ngữ: " + NhanVienDt.Rows[0]["TenBangNgoaiNgu"] + "'";

                //// Parameter 18

                //rpt.DataDefinition.FormulaFields["CongTacChinh"].Text = "'18) Công tác chính đang làm: học thêm'";

                //// Parameter 19

                //rpt.DataDefinition.FormulaFields["NgachCongChuc"].Text = "'19) Ngạch công chức: ............. (Mã số: ...........). Bậc lương: ......, hệ số: ..., từ tháng ...........'";

                //// Parameter 20

                //rpt.DataDefinition.FormulaFields["DanhHieu"].Text = "'20) Danh hiệu được phong: .......................................'";

                //// Parameter 21
                //rpt.DataDefinition.FormulaFields["SoTruong"].Text = "'21) Sở trường công tác: ......................... Công việc đã làm lâu nhất: .....................'";

                //// Parameter 22

                //rpt.DataDefinition.FormulaFields["KhenThuong"].Text = "'22) Khen thưởng: ................................................'";

                //// Parameter 23
                //rpt.DataDefinition.FormulaFields["KyLuat"].Text = "'23) Kỷ luật: ...................................................'";

                //// Parameter 24
                //rpt.DataDefinition.FormulaFields["TinhTrangSucKhoe"].Text = "'24) Tình trạng sức khỏe: ............. Cao ........ Cân nặng ...... Nhóm máu ....'";

                //// Parameter 25
                //rpt.DataDefinition.FormulaFields["CMND"].Text = "'25) Số chứng minh nhân dân: " + NhanVienDt.Rows[0]["SoCMND"].ToString() + ". Thương binh loại: ..............Gia đình liệt sỹ: .............'";

                //// Parameter 28
                //rpt.DataDefinition.FormulaFields["BiBatTu"].Text = "'a) Khai rõ: bị bắt, bị tù (từ ngày tháng năm nào đến ngày tháng năm nào, ở đâu), đã khai báo cho ai, những vấn đề gì: " + NhanVienDt.Rows[0]["BiBatTu"].ToString() + "'";
                //rpt.DataDefinition.FormulaFields["LamViecChoCheDoCu"].Text = "'b) Bản thân có làm việc trong chế độ cũ (cơ quan, đơn vị nào, địa điểm, chức danh, chức vụ, thời gian làm việc....): " + NhanVienDt.Rows[0]["LamViecChoCheDoCu"].ToString() + "'";

                //// Parameter 29
                //rpt.DataDefinition.FormulaFields["QuanHeVoiToChucNN"].Text = "'- Tham gia hoặc có quan hệ với các tổ chức chính trị, kinh tế, xã hội nào ở nước ngoài (làm gì, tổ chức nào, đặt trụ ở ở đâu...?): " + NhanVienDt.Rows[0]["QuanHeVoiToChucNN"].ToString() + "'";
                //rpt.DataDefinition.FormulaFields["ThanhNhanONuocNgoai"].Text = "'- Có thân nhân (bố, mẹ, vợ, chồng, con, anh chị em ruột) ở nước ngoài (làm gì, địa chỉ...)?: " + NhanVienDt.Rows[0]["ThanhNhanONuocNgoai"].ToString() + "'";

                //// Parameter 31
                //rpt.DataDefinition.FormulaFields["NhaODuocCap"].Text = "'+ Được cấp, được thuê loại nhà: " + NhanVienDt.Rows[0]["NhaODuocCap"].ToString() + "m2, tổng diện tích sử dụng: "+ NhanVienDt.Rows[0]["DienTichSuDungNhaO"].ToString() + "m2 '";
                //rpt.DataDefinition.FormulaFields["NhaOTuMua"].Text = "'+ Nhà tự mua, tự xây loại nhà: " + NhanVienDt.Rows[0]["NhaOTuMua"].ToString() + "m2, tổng diện tích sử dụng: " + NhanVienDt.Rows[0]["DienTichSuDungDatO"].ToString() + "m2 '";
                //rpt.DataDefinition.FormulaFields["DienTichDatDuocCap"].Text = "'+ Nhà tự mua, tự xây loại nhà: " + NhanVienDt.Rows[0]["DienTichDatDuocCap"].ToString() + "m2, tổng diện tích sử dụng: " + NhanVienDt.Rows[0]["DienTichDatTuMua"].ToString() + "m2 '";
                //rpt.DataDefinition.FormulaFields["DienTichDatKinhDoanhTrangTrai"].Text = "'- Đất sản xuất, kinh doanh: (Tổng diện tích đất được cấp, tự mua, tự khai phá...): " + NhanVienDt.Rows[0]["DienTichDatKinhDoanhTrangTrai"].ToString() + " m2'";
                

                //sql = "";
                //sql+=" select * from QuaTrinhDaoTao qtdt";
                //sql+=" left join HinhThucDaoTao htdt on qtdt.MaHinhThucDaoTao = htdt.MaHinhThucDaoTao";
                //sql+=" left join BangGiaoDucPhoThong gdpt on qtdt.MaBangGiaoDucPhoThong = gdpt.MaBangGiaoDucPhoThong";
                //sql+=" left join BangLyLuanChinhTri llct on qtdt.MaBangLyLuanChinhTri = llct.MaBangLyLuanChinhTri";
                //sql+=" left join BangNgoaiNgu nn on qtdt.MaBangNgoaiNgu = nn.MaBangNgoaiNgu";
                //sql+=" left join BangChuyenMonNghiepVu cmnv on qtdt.MaBangChuyenMonNghiepVu = cmnv.MaBangChuyenMonNghiepVu";
                ////sql+=" where MaNhanVien='" + MaNV + "' ";
                
                //cmd = new SqlCommand(sql);
                //dataService.Load(cmd);
                //DSBaoCao1 myDS = new DSBaoCao1();
                //DataTable myDt = dataService;

                //for (int i = 0; i < myDt.Rows.Count; i++)
                //{
                //    DataRow myRow = dsBaoCao1.Tables["QuaTrinhDaoTao"].NewRow();
                //    myRow["TenTruong"] = myDt.Rows[i]["TenTruong"];
                //    myRow["NganhHoc"] = myDt.Rows[i]["NganhHoc"];
                //    myRow["HinhThucHoc"] = myDt.Rows[i]["TenHinhThucDaoTao"];

                //    String CC = "";
                //    if(!String.IsNullOrEmpty(myDt.Rows[i]["TenBangGiaoDucPhoThong"].ToString())){
                //        CC += myDt.Rows[i]["TenBangGiaoDucPhoThong"].ToString();
                //    }
                //    if (!String.IsNullOrEmpty(myDt.Rows[i]["TenBangLyLuanChinhTri"].ToString()))
                //    {
                //        CC += ", ";
                //        CC += myDt.Rows[i]["TenBangLyLuanChinhTri"].ToString();
                //    }
                //    if (!String.IsNullOrEmpty(myDt.Rows[i]["TenBangNgoaiNgu"].ToString()))
                //    {
                //        CC += ", ";
                //        CC += myDt.Rows[i]["TenBangNgoaiNgu"].ToString();
                //    }
                //    if (!String.IsNullOrEmpty(myDt.Rows[i]["TenBangChuyenMonNghiepVu"].ToString()))
                //    {
                //        CC += ", ";
                //        CC += myDt.Rows[i]["TenBangChuyenMonNghiepVu"].ToString();
                //    }
                //    myRow["ChungChi"] = CC;

                //    DateTime dt = new DateTime();
                //    String ThoiGianHoc = "";
                //    try
                //    {
                //        dt = (DateTime)myDt.Rows[i]["ThoiGianBatDau"];
                //        ThoiGianHoc = dt.ToString("dd/MM/yyyy")+"-";
                //    }
                //    catch (Exception ex) { }
                //    try
                //    {
                //        dt = (DateTime)myDt.Rows[i]["ThoiGianKetThuc"];
                //        ThoiGianHoc = dt.ToString("dd/MM/yyyy");
                //    }
                //    catch (Exception ex) { }
                //    myRow["ThoiGianHoc"] = ThoiGianHoc;

                //    dsBaoCao1.Tables["QuaTrinhDaoTao"].Rows.Add(myRow);
                //}

                ///////////////////////////////////////////////////////////////////
                //sql = "";
                //sql += " SELECT * FROM QuaTrinhCongTac qtct";
                //sql += " left join ChucVuChinhQuyen cvcq on cvcq.MaChucVuChinhQuyen = qtct.MaChucVuChinhQuyen";
              
                ////sql+=" where MaNhanVien='" + MaNV + "' ";

                //cmd = new SqlCommand(sql);
                //dataService.Load(cmd);
                //myDS = new DSBaoCao1();
                //myDt = dataService;

                //for (int i = 0; i < myDt.Rows.Count; i++)
                //{
                //    DataRow myRow = dsBaoCao1.Tables["QuaTrinhCongTac"].NewRow();

                //    String TT = "";
                //    if (!String.IsNullOrEmpty(myDt.Rows[i]["ChucDanh"].ToString()))
                //    {
                //        TT += myDt.Rows[i]["ChucDanh"].ToString();
                //    }
                //    if (!String.IsNullOrEmpty(myDt.Rows[i]["TenChucVuChinhQuyen"].ToString()))
                //    {
                //        TT += ", ";
                //        TT += myDt.Rows[i]["TenChucVuChinhQuyen"].ToString();
                //    }
                //    if (!String.IsNullOrEmpty(myDt.Rows[i]["MoTaCongTac"].ToString()))
                //    {
                //        TT += ", ";
                //        TT += myDt.Rows[i]["MoTaCongTac"].ToString();
                //    }
                   
                //    myRow["TomTat"] = TT;

                //    DateTime dt = new DateTime();
                //    String ThoiGianCongTac = "";
                //    try
                //    {
                //        dt = (DateTime)myDt.Rows[i]["ThoiGianBatDau"];
                //        ThoiGianCongTac = dt.ToString("dd/MM/yyyy") + "-";
                //    }
                //    catch (Exception ex) { }
                //    try
                //    {
                //        dt = (DateTime)myDt.Rows[i]["ThoiGianKetThuc"];
                //        ThoiGianCongTac = dt.ToString("dd/MM/yyyy");
                //    }
                //    catch (Exception ex) { }
                //    myRow["ThoiGianCongTac"] = ThoiGianCongTac;

                //    dsBaoCao1.Tables["QuaTrinhCongTac"].Rows.Add(myRow);
                //}
                //////////////////////////////////////////////////////////////////////////////
                ///////////////////////////////////////////////////////////////////
                //sql = "";
                //sql += " select * from NhanVien nv";
                //sql += " left join ThanNhan tn on nv.MaNhanVien = tn.MaNhanVien";
                //sql += " left join QuanHe qh on qh.MaQuanHe = tn.MaQuanHe";

                ////sql+=" where nv.MaNhanVien='" + MaNV + "' ";

                //cmd = new SqlCommand(sql);
                //dataService.Load(cmd);
                //myDS = new DSBaoCao1();
                //myDt = dataService;

                //for (int i = 0; i < myDt.Rows.Count; i++)
                //{
                //    DataRow myRow = dsBaoCao1.Tables["ThanNhan"].NewRow();

                //    myRow["MaThanNhan"] = myDt.Rows[i]["MaThanNhan"];
                //    myRow["TenThanNhan"] = myDt.Rows[i]["TenThanNhan"];
                //    myRow["TenQuanHe"] = myDt.Rows[i]["TenQuanHe"];
                //    myRow["NamSinh"] = myDt.Rows[i]["NamSinh"];
                //    myRow["ThongTinCaNhan"] = myDt.Rows[i]["ThongTinCaNhan"];

                //    dsBaoCao1.Tables["ThanNhan"].Rows.Add(myRow);
                //}
                //rpt.SetDataSource(dsBaoCao1);

                //crystalReportViewer1.ReportSource = rpt;
                ////crystalReportViewer1.Show();
                //crystalReportViewer1.Refresh();
            }
            else
            {
                MessageBox.Show("Chua tao report");
            }
        }
        private String LoadSql_MaDonVi()
        {
            String sql = "";
            if (Level == 1)//Cap tinh
            {
                sql += " and MaQuanHuyen in (";
                sql += " Select MaQuanHuyen from QuanHuyen where MaTinh='" + SelectedId + "'";
                sql += " )";
            }
            if (Level == 2)//Cap huyen
            {
                sql += " and MaQuanHuyen ='" + SelectedId + "'";
            }
            return sql;
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
