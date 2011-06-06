using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

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
                CrBaoCaoLuong1 rpt = new CrBaoCaoLuong1();
                rpt.DataDefinition.FormulaFields["NgayThang"].Text = "'" + strDt + "'";
                rpt.DataDefinition.FormulaFields["NLB1"].Text = "'" + ChuKi[0] + "'";
                rpt.DataDefinition.FormulaFields["NLB2"].Text = "'" + ChuKi[1] + "'";
                rpt.DataDefinition.FormulaFields["NLB3"].Text = "'" + ChuKi[2] + "'";
                rpt.DataDefinition.FormulaFields["NK1"].Text = "'" + ChuKi[3] + "'";
                rpt.DataDefinition.FormulaFields["NK2"].Text = "'" + ChuKi[4] + "'";
                rpt.DataDefinition.FormulaFields["NK3"].Text = "'" + ChuKi[5] + "'";
                rpt.SetDataSource(myDt);
                this.crystalReportViewer1.ReportSource = rpt;

            }
            else if (BaoCao == "1-1")// Bao cáo lương - 1
            {
                this.Text = "Báo cáo lương";
                String sql = " select nv.*, t.TenBangChuyenMonNghiepVu,";
                sql += " NgaySinhNam = case MaGioiTinh when 1 then NgaySinh end,";
                sql += " NgaySinhNu = case MaGioiTinh when 0 then NgaySinh end";
                sql += " from NhanVien nv left join BangChuyenMonNghiepVu t on nv.MaBangChuyenMonNghiepVu = t.MaBangChuyenMonNghiepVu";
                sql += " where 1=1";
                sql += LoadSql_MaDonVi();


                SqlCommand cmd = new SqlCommand(sql);
                dataService.Load(cmd);
                DataTable myDt = dataService;
                CrBaoCaoLuong2 rpt = new CrBaoCaoLuong2();
                rpt.DataDefinition.FormulaFields["NgayThang"].Text = "'" + strDt + "'";
                rpt.DataDefinition.FormulaFields["NLB1"].Text = "'" + ChuKi[0] + "'";
                rpt.DataDefinition.FormulaFields["NLB2"].Text = "'" + ChuKi[1] + "'";
                rpt.DataDefinition.FormulaFields["NLB3"].Text = "'" + ChuKi[2] + "'";
                rpt.DataDefinition.FormulaFields["NK1"].Text = "'" + ChuKi[3] + "'";
                rpt.DataDefinition.FormulaFields["NK2"].Text = "'" + ChuKi[4] + "'";
                rpt.DataDefinition.FormulaFields["NK3"].Text = "'" + ChuKi[5] + "'";
                rpt.SetDataSource(myDt);
                this.crystalReportViewer1.ReportSource = rpt;
            }
            else if (BaoCao == "1-2") // Bao cáo lương - 2
            {
                this.Text = "Báo cáo lương";
                String sql = " select nv.*, t.TenBangChuyenMonNghiepVu,";
                sql += " NgaySinhNam = case MaGioiTinh when 1 then NgaySinh end,";
                sql += " NgaySinhNu = case MaGioiTinh when 0 then NgaySinh end";
                sql += " from NhanVien nv left join BangChuyenMonNghiepVu t on nv.MaBangChuyenMonNghiepVu = t.MaBangChuyenMonNghiepVu";
                sql += " where 1=1";
                sql += LoadSql_MaDonVi();


                SqlCommand cmd = new SqlCommand(sql);
                dataService.Load(cmd);
                DataTable myDt = dataService;
                CrBaoCaoLuong3 rpt = new CrBaoCaoLuong3();
                rpt.DataDefinition.FormulaFields["NgayThang"].Text = "'" + strDt + "'";
                rpt.DataDefinition.FormulaFields["NLB1"].Text = "'" + ChuKi[0] + "'";
                rpt.DataDefinition.FormulaFields["NLB2"].Text = "'" + ChuKi[1] + "'";
                rpt.DataDefinition.FormulaFields["NLB3"].Text = "'" + ChuKi[2] + "'";
                rpt.DataDefinition.FormulaFields["NK1"].Text = "'" + ChuKi[3] + "'";
                rpt.DataDefinition.FormulaFields["NK2"].Text = "'" + ChuKi[4] + "'";
                rpt.DataDefinition.FormulaFields["NK3"].Text = "'" + ChuKi[5] + "'";
                rpt.SetDataSource(myDt);
                this.crystalReportViewer1.ReportSource = rpt;
            }
            else if (BaoCao == "2") // danh sách nâng lương
            {
                this.Text = "Danh sách nâng lương";
                String sql = " select nv.*, t.TenBangChuyenMonNghiepVu,";
                sql += " NgaySinhNam = case MaGioiTinh when 1 then NgaySinh end,";
                sql += " NgaySinhNu = case MaGioiTinh when 0 then NgaySinh end";
                sql += " from NhanVien nv left join BangChuyenMonNghiepVu t on nv.MaBangChuyenMonNghiepVu = t.MaBangChuyenMonNghiepVu";
                sql += " where 1=1";
                sql += LoadSql_MaDonVi();


                SqlCommand cmd = new SqlCommand(sql);
                dataService.Load(cmd);
                DataTable myDt = dataService;
                CrDanhSachNangLuong rpt = new CrDanhSachNangLuong();
                rpt.DataDefinition.FormulaFields["NgayThang"].Text = "'" + strDt + "'";
                rpt.DataDefinition.FormulaFields["NLB1"].Text = "'" + ChuKi[0] + "'";
                rpt.DataDefinition.FormulaFields["NLB2"].Text = "'" + ChuKi[1] + "'";
                rpt.DataDefinition.FormulaFields["NLB3"].Text = "'" + ChuKi[2] + "'";
                rpt.DataDefinition.FormulaFields["NK1"].Text = "'" + ChuKi[3] + "'";
                rpt.DataDefinition.FormulaFields["NK2"].Text = "'" + ChuKi[4] + "'";
                rpt.DataDefinition.FormulaFields["NK3"].Text = "'" + ChuKi[5] + "'";
                rpt.SetDataSource(myDt);
                this.crystalReportViewer1.ReportSource = rpt;
            }
            else if (BaoCao == "3") // Danh sách phụ cấp thâm niên vượt khung
            {
                this.Text = "Danh sách phụ cấp thâm niên vượt khung";
                String sql = " select nv.*, t.TenBangChuyenMonNghiepVu, dv.TenDonVi";
                sql += " from NhanVien nv left join BangChuyenMonNghiepVu t on nv.MaBangChuyenMonNghiepVu = t.MaBangChuyenMonNghiepVu";
                sql += " left join DonVi dv on nv.MaDonVi = dv.MaDonVi";
                sql += " where 1=1";
                sql += LoadSql_MaDonVi();


                SqlCommand cmd = new SqlCommand(sql);
                dataService.Load(cmd);
                DataTable myDt = dataService;
                CrBaoCaoDanhSachVuotKhung rpt = new CrBaoCaoDanhSachVuotKhung();
                rpt.DataDefinition.FormulaFields["NgayThang"].Text = "'" + strDt + "'";
                rpt.DataDefinition.FormulaFields["Title"].Text = "'DANH SÁCH KẾT QUẢ NÂNG PCTNVK CB, CC UBND HUYỆN "+strDt.ToUpper()+"'";
                rpt.DataDefinition.FormulaFields["NLB1"].Text = "'" + ChuKi[0] + "'";
                rpt.DataDefinition.FormulaFields["NLB2"].Text = "'" + ChuKi[1] + "'";
                rpt.DataDefinition.FormulaFields["NLB3"].Text = "'" + ChuKi[2] + "'";
                rpt.DataDefinition.FormulaFields["NK1"].Text = "'" + ChuKi[3] + "'";
                rpt.DataDefinition.FormulaFields["NK2"].Text = "'" + ChuKi[4] + "'";
                rpt.DataDefinition.FormulaFields["NK3"].Text = "'" + ChuKi[5] + "'";
                rpt.SetDataSource(myDt);
                this.crystalReportViewer1.ReportSource = rpt;
            }
            else if (BaoCao == "4-0") // Danh sách CB, CC, VC và hợp đồng 1    
            {
                this.Text = "Danh sách CB, CC, VC và hợp đồng";
                String sql = " select nv.*, cv.TenChucVu, t.TenBangChuyenMonNghiepVu, tt.TenBangLyLuanChinhTri";
                sql += " from NhanVien nv left join ChucVu cv on nv.MaChucVu = cv.MaChucVu";
                sql += " left join BangChuyenMonNghiepVu t on nv.MaBangChuyenMonNghiepVu = t.MaBangChuyenMonNghiepVu";
                sql += " left join BangLyLuanChinhTri tt on nv.MaBangLyLuanChinhTri = tt.MaBangLyLuanChinhTri";
                sql += " where 1=1";
                sql += LoadSql_MaDonVi();

                SqlCommand cmd = new SqlCommand(sql);
                dataService.Load(cmd);
                DataTable myDt = dataService;
                CrBaoCaoDanhSachCBCCVC1 rpt = new CrBaoCaoDanhSachCBCCVC1();
                rpt.DataDefinition.FormulaFields["NgayThang"].Text = "'" + strDt + "'";
                rpt.DataDefinition.FormulaFields["NLB1"].Text = "'" + ChuKi[0] + "'";
                rpt.DataDefinition.FormulaFields["NLB2"].Text = "'" + ChuKi[1] + "'";
                rpt.DataDefinition.FormulaFields["NLB3"].Text = "'" + ChuKi[2] + "'";
                rpt.DataDefinition.FormulaFields["NK1"].Text = "'" + ChuKi[3] + "'";
                rpt.DataDefinition.FormulaFields["NK2"].Text = "'" + ChuKi[4] + "'";
                rpt.DataDefinition.FormulaFields["NK3"].Text = "'" + ChuKi[5] + "'";
                rpt.SetDataSource(myDt);
                this.crystalReportViewer1.ReportSource = rpt;
            }
            else if (BaoCao == "4-1") // Danh sách CB, CC, VC và hợp đồng 2    
            {
                this.Text = "Danh sách CB, CC, VC và hợp đồng";
                String sql = " select nv.*, cv.TenChucVu, t.TenBangChuyenMonNghiepVu, tt.TenBangLyLuanChinhTri";
                sql += " from NhanVien nv left join ChucVu cv on nv.MaChucVu = cv.MaChucVu";
                sql += " left join BangChuyenMonNghiepVu t on nv.MaBangChuyenMonNghiepVu = t.MaBangChuyenMonNghiepVu";
                sql += " left join BangLyLuanChinhTri tt on nv.MaBangLyLuanChinhTri = tt.MaBangLyLuanChinhTri";
                sql += " where 1=1";
                sql += LoadSql_MaDonVi();

                SqlCommand cmd = new SqlCommand(sql);
                dataService.Load(cmd);
                DataTable myDt = dataService;
                CrBaoCaoDanhSachCBCCVC2 rpt = new CrBaoCaoDanhSachCBCCVC2();
                rpt.DataDefinition.FormulaFields["NgayThang"].Text = "'" + strDt + "'";
                rpt.DataDefinition.FormulaFields["NLB1"].Text = "'" + ChuKi[0] + "'";
                rpt.DataDefinition.FormulaFields["NLB2"].Text = "'" + ChuKi[1] + "'";
                rpt.DataDefinition.FormulaFields["NLB3"].Text = "'" + ChuKi[2] + "'";
                rpt.DataDefinition.FormulaFields["NK1"].Text = "'" + ChuKi[3] + "'";
                rpt.DataDefinition.FormulaFields["NK2"].Text = "'" + ChuKi[4] + "'";
                rpt.DataDefinition.FormulaFields["NK3"].Text = "'" + ChuKi[5] + "'";
                rpt.SetDataSource(myDt);
                this.crystalReportViewer1.ReportSource = rpt;
            }
            else if (BaoCao == "4-2") // Danh sách CB, CC, VC và hợp đồng 3  
            {
                this.Text = "Danh sách CB, CC, VC và hợp đồng";
                String sql = " select nv.*, cv.TenChucVu, t.TenBangChuyenMonNghiepVu, tt.TenBangLyLuanChinhTri";
                sql += " from NhanVien nv left join ChucVu cv on nv.MaChucVu = cv.MaChucVu";
                sql += " left join BangChuyenMonNghiepVu t on nv.MaBangChuyenMonNghiepVu = t.MaBangChuyenMonNghiepVu";
                sql += " left join BangLyLuanChinhTri tt on nv.MaBangLyLuanChinhTri = tt.MaBangLyLuanChinhTri";
                sql += " where 1=1";
                sql += LoadSql_MaDonVi();

                SqlCommand cmd = new SqlCommand(sql);
                dataService.Load(cmd);
                DataTable myDt = dataService;
                CrBaoCaoDanhSachCBCCVC3 rpt = new CrBaoCaoDanhSachCBCCVC3();
                rpt.DataDefinition.FormulaFields["NgayThang"].Text = "'" + strDt + "'";
                rpt.DataDefinition.FormulaFields["NLB1"].Text = "'" + ChuKi[0] + "'";
                rpt.DataDefinition.FormulaFields["NLB2"].Text = "'" + ChuKi[1] + "'";
                rpt.DataDefinition.FormulaFields["NLB3"].Text = "'" + ChuKi[2] + "'";
                rpt.DataDefinition.FormulaFields["NK1"].Text = "'" + ChuKi[3] + "'";
                rpt.DataDefinition.FormulaFields["NK2"].Text = "'" + ChuKi[4] + "'";
                rpt.DataDefinition.FormulaFields["NK3"].Text = "'" + ChuKi[5] + "'";
                rpt.SetDataSource(myDt);
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
                sql += " left join DonVi dv on nv.MaDonVi = dv.MaDonVi";
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
    }
}
