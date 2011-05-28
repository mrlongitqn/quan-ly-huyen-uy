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
        String MaDV;
        String strDt;
        DataService dataService = new DataService();
        public FrmPrintReport(String _BC, String _MaDV, String _dt)
        {
            InitializeComponent();
            BaoCao = _BC;
            MaDV = _MaDV;
            strDt = _dt;
        }

        private void FrmPrintReport_Load(object sender, EventArgs e)
        {
            DataService.OpenConnection();
            if (BaoCao == "1-0") // Bao cáo lương - 0
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM DonVi where MaDonVi='" + MaDV + "'");
                dataService.Load(cmd);
                DataTable myDt = dataService;
                CrBaoCaoLuong1 rpt = new CrBaoCaoLuong1();
                rpt.DataDefinition.FormulaFields["NgayThang"].Text = "'" + strDt + "'";

                rpt.SetDataSource(myDt);
                this.crystalReportViewer1.ReportSource = rpt;

            }
            else if (BaoCao == "1-1")// Bao cáo lương - 1
            {
                String sql = " select nv.*, t.TenTrinhDoChuyenMon,";
                sql += " NgaySinhNam = case MaGioiTinh when 1 then NgaySinh end,";
                sql += " NgaySinhNu = case MaGioiTinh when 0 then NgaySinh end";
                sql += " from NhanVien nv left join TrinhDoChuyenMon t on nv.MaTrinhDoChuyenMon = t.MaTrinhDoChuyenMon";
                sql += " where MaDonVi='" + MaDV + "'";


                SqlCommand cmd = new SqlCommand(sql);
                dataService.Load(cmd);
                DataTable myDt = dataService;
                CrBaoCaoLuong2 rpt = new CrBaoCaoLuong2();
                rpt.DataDefinition.FormulaFields["NgayThang"].Text = "'" + strDt + "'";

                rpt.SetDataSource(myDt);
                this.crystalReportViewer1.ReportSource = rpt;
            }
            else if (BaoCao == "1-2") // Bao cáo lương - 2
            {
                String sql = " select nv.*, t.TenTrinhDoChuyenMon,";
                sql += " NgaySinhNam = case MaGioiTinh when 1 then NgaySinh end,";
                sql += " NgaySinhNu = case MaGioiTinh when 0 then NgaySinh end";
                sql += " from NhanVien nv left join TrinhDoChuyenMon t on nv.MaTrinhDoChuyenMon = t.MaTrinhDoChuyenMon";
                sql += " where MaDonVi='" + MaDV + "'";


                SqlCommand cmd = new SqlCommand(sql);
                dataService.Load(cmd);
                DataTable myDt = dataService;
                CrBaoCaoLuong3 rpt = new CrBaoCaoLuong3();
                rpt.DataDefinition.FormulaFields["NgayThang"].Text = "'" + strDt + "'";

                rpt.SetDataSource(myDt);
                this.crystalReportViewer1.ReportSource = rpt;
            }
            else if (BaoCao == "2") // danh sách nâng lương
            {

                String sql = " select nv.*, t.TenTrinhDoChuyenMon,";
                sql += " NgaySinhNam = case MaGioiTinh when 1 then NgaySinh end,";
                sql += " NgaySinhNu = case MaGioiTinh when 0 then NgaySinh end";
                sql += " from NhanVien nv left join TrinhDoChuyenMon t on nv.MaTrinhDoChuyenMon = t.MaTrinhDoChuyenMon";
                sql += " where MaDonVi='" + MaDV + "'";


                SqlCommand cmd = new SqlCommand(sql);
                dataService.Load(cmd);
                DataTable myDt = dataService;
                CrDanhSachNangLuong rpt = new CrDanhSachNangLuong();
                rpt.DataDefinition.FormulaFields["NgayThang"].Text = "'" + strDt + "'";

                rpt.SetDataSource(myDt);
                this.crystalReportViewer1.ReportSource = rpt;
            }
            else if (BaoCao == "4-0") // Danh sách CB, CC, VC và hợp đồng 1    
            {

                String sql = " select nv.*, cv.TenChucVu, t.TenTrinhDoChuyenMon, tt.TenTrinhDoChinhTri";
                sql += " from NhanVien nv left join ChucVu cv on nv.MaChucVu = cv.MaChucVu";
                sql += " left join TrinhDoChuyenMon t on nv.MaTrinhDoChuyenMon = t.MaTrinhDoChuyenMon";
                sql += " left join TrinhDoChinhTri tt on nv.MaTrinhDoChinhTri = tt.MaTrinhDoChinhTri";
                sql += " where MaDonVi='" + MaDV + "'";

                SqlCommand cmd = new SqlCommand(sql);
                dataService.Load(cmd);
                DataTable myDt = dataService;
                CrBaoCaoDanhSachCBCCVC1 rpt = new CrBaoCaoDanhSachCBCCVC1();
                rpt.DataDefinition.FormulaFields["NgayThang"].Text = "'" + strDt + "'";

                rpt.SetDataSource(myDt);
                this.crystalReportViewer1.ReportSource = rpt;
            }
            else if (BaoCao == "4-1") // Danh sách CB, CC, VC và hợp đồng 2    
            {

                String sql = " select nv.*, cv.TenChucVu, t.TenTrinhDoChuyenMon, tt.TenTrinhDoChinhTri";
                sql += " from NhanVien nv left join ChucVu cv on nv.MaChucVu = cv.MaChucVu";
                sql += " left join TrinhDoChuyenMon t on nv.MaTrinhDoChuyenMon = t.MaTrinhDoChuyenMon";
                sql += " left join TrinhDoChinhTri tt on nv.MaTrinhDoChinhTri = tt.MaTrinhDoChinhTri";
                sql += " where MaDonVi='" + MaDV + "'";

                SqlCommand cmd = new SqlCommand(sql);
                dataService.Load(cmd);
                DataTable myDt = dataService;
                CrBaoCaoDanhSachCBCCVC2 rpt = new CrBaoCaoDanhSachCBCCVC2();
                rpt.DataDefinition.FormulaFields["NgayThang"].Text = "'" + strDt + "'";

                rpt.SetDataSource(myDt);
                this.crystalReportViewer1.ReportSource = rpt;
            }
            else if (BaoCao == "4-2") // Danh sách CB, CC, VC và hợp đồng 3  
            {

                String sql = " select nv.*, cv.TenChucVu, t.TenTrinhDoChuyenMon, tt.TenTrinhDoChinhTri";
                sql += " from NhanVien nv left join ChucVu cv on nv.MaChucVu = cv.MaChucVu";
                sql += " left join TrinhDoChuyenMon t on nv.MaTrinhDoChuyenMon = t.MaTrinhDoChuyenMon";
                sql += " left join TrinhDoChinhTri tt on nv.MaTrinhDoChinhTri = tt.MaTrinhDoChinhTri";
                sql += " where MaDonVi='" + MaDV + "'";

                SqlCommand cmd = new SqlCommand(sql);
                dataService.Load(cmd);
                DataTable myDt = dataService;
                CrBaoCaoDanhSachCBCCVC3 rpt = new CrBaoCaoDanhSachCBCCVC3();
                rpt.DataDefinition.FormulaFields["NgayThang"].Text = "'" + strDt + "'";

                rpt.SetDataSource(myDt);
                this.crystalReportViewer1.ReportSource = rpt;
            }
            else if (BaoCao == "5") // Danh sách đủ tuổi về hưu, đủ năm công tác về hưu
            {

                String sql = " select * from NhanVien";
                //sql += " from NhanVien nv left join ChucVu cv on nv.MaChucVu = cv.MaChucVu";
                //sql += " left join TrinhDoChuyenMon t on nv.MaTrinhDoChuyenMon = t.MaTrinhDoChuyenMon";
                //sql += " left join TrinhDoChinhTri tt on nv.MaTrinhDoChinhTri = tt.MaTrinhDoChinhTri";
                //sql += " where MaDonVi='" + MaDV + "'";

                SqlCommand cmd = new SqlCommand(sql);
                dataService.Load(cmd);
                DataTable myDt = dataService;
                CrDanhSachNghiHuu rpt = new CrDanhSachNghiHuu();

                rpt.SetDataSource(myDt);
                this.crystalReportViewer1.ReportSource = rpt;
            }
            else
            {
                MessageBox.Show("Chua tao report");
            }
        }
    }
}
