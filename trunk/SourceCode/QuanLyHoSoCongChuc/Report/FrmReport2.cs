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
        public FrmReport2()
        {
            InitializeComponent();
        }

        private void FrmReport2_Load(object sender, EventArgs e)
        {
            String sql = "";
            sql += " select * from QuaTrinhDaoTao qtdt";
            sql += " left join HinhThucDaoTao htdt on qtdt.MaHinhThucDaoTao = htdt.MaHinhThucDaoTao";
            sql += " left join BangGiaoDucPhoThong gdpt on qtdt.MaBangGiaoDucPhoThong = gdpt.MaBangGiaoDucPhoThong";
            sql += " left join BangLyLuanChinhTri llct on qtdt.MaBangLyLuanChinhTri = llct.MaBangLyLuanChinhTri";
            sql += " left join BangNgoaiNgu nn on qtdt.MaBangNgoaiNgu = nn.MaBangNgoaiNgu";
            sql += " left join BangChuyenMonNghiepVu cmnv on qtdt.MaBangChuyenMonNghiepVu = cmnv.MaBangChuyenMonNghiepVu";
            //sql+=" where MaNhanVien='" + MaNV + "' ";

            DataService.OpenConnection();
            SqlCommand cmd = new SqlCommand(sql);
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

            //ReportParameter[] parames = new ReportParameter[1];
            //parames[0] = new ReportParameter("aaa", "9", true);
            //this.reportViewer1.LocalReport.SetParameters(parames);
            //this.reportViewer1.LocalReport.Refresh(); 
            /////////////////////////////////////////////////////////////////////////////////////////////////////

            sql = "";
            sql += " select * from NhanVien nv";
            sql += " left join ThanNhan tn on nv.MaNhanVien = tn.MaNhanVien";
            sql += " left join QuanHe qh on qh.MaQuanHe = tn.MaQuanHe";

            //sql+=" where nv.MaNhanVien='" + MaNV + "' ";

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

            //sql+=" where MaNhanVien='" + MaNV + "' ";

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
            this.reportViewer1.LocalReport.ReportPath = "Report\\RptSYLL.rdlc";
            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            this.reportViewer1.RefreshReport();
        }
    }
}
