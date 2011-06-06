using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLyHoSoCongChuc.Danh_muc;
using QuanLyHoSoCongChuc.Utils;
using System.Data.SqlClient;

namespace QuanLyHoSoCongChuc.Report
{
    #region Using
    using QuanLyHoSoCongChuc.Models;
    using QuanLyHoSoCongChuc.Repositories;
    #endregion
    public partial class FrmDanhSachPhuCapVuotKhung : Form
    {
        DataService dataService = new DataService();
        String SelectedId;
        int Level;
        public FrmDanhSachPhuCapVuotKhung()
        {
            InitializeComponent();
        }

        private void FrmDanhSachPhuCapVuotKhung_Load(object sender, EventArgs e)
        {
            loadNam();
            initGird();
            cboKy.SelectedIndex = 0;
        }
       
        void loadNam()
        {
            for (int i = 0; i < 100; i++)
            {
                dupNam.Items.Add(1950 + i);
            }
            dupNam.SelectedIndex = 50;
        }

        private void btBaoBieu_Click(object sender, EventArgs e)
        {
            grid1.Rows.Clear();
            initGird();
            String sql = " select nv.*, t.TenBangChuyenMonNghiepVu, dv.TenDonVi";
            sql += " from NhanVien nv left join BangChuyenMonNghiepVu t on nv.MaBangChuyenMonNghiepVu = t.MaBangChuyenMonNghiepVu";
            sql += " left join DonVi dv on nv.MaDonVi = dv.MaDonVi";
            sql += " where 1=1";
            sql += LoadSql_MaDonVi();

            SqlCommand cmd = new SqlCommand(sql);
            dataService.Load(cmd);
            DataTable myDt = dataService;

            for (int r = 0; r < myDt.Rows.Count; r++)
            {
                grid1.Rows.Insert(r + 3);
                grid1[3 + r, 0] = new SourceGrid.Cells.Cell(r + 1, typeof(int));
                grid1[3 + r, 1] = new SourceGrid.Cells.Cell(myDt.Rows[r]["TenDonVi"], typeof(String));
                grid1[3 + r, 2] = new SourceGrid.Cells.Cell(myDt.Rows[r]["HoTenKhaiSinh"], typeof(String));

                DateTime dt = (DateTime)myDt.Rows[r]["NgaySinh"];
                grid1[3 + r, 3] = new SourceGrid.Cells.Cell(dt.Year, typeof(int));
                grid1[3 + r, 4] = new SourceGrid.Cells.Cell(myDt.Rows[r]["TenBangChuyenMonNghiepVu"], typeof(String));
                grid1[3 + r, 5] = new SourceGrid.Cells.Cell("", typeof(String));
                grid1[3 + r, 6] = new SourceGrid.Cells.Cell("", typeof(String));
                grid1[3 + r, 7] = new SourceGrid.Cells.Cell("", typeof(String));
                grid1[3 + r, 8] = new SourceGrid.Cells.Cell("", typeof(String));
                grid1[3 + r, 9] = new SourceGrid.Cells.Cell("", typeof(String));
                grid1[3 + r, 10] = new SourceGrid.Cells.Cell("", typeof(String));
                grid1[3 + r, 11] = new SourceGrid.Cells.Cell("", typeof(String));
                grid1[3 + r, 12] = new SourceGrid.Cells.Cell("", typeof(String));
                grid1[3 + r, 13] = new SourceGrid.Cells.Cell("", typeof(String));
                grid1[3 + r, 14] = new SourceGrid.Cells.Cell("", typeof(String));
                grid1[3 + r, 15] = new SourceGrid.Cells.Cell("", typeof(String));
                grid1[3 + r, 16] = new SourceGrid.Cells.Cell("", typeof(String));
                grid1[3 + r, 17] = new SourceGrid.Cells.Cell("", typeof(String));
            }

            grid1.AutoSizeCells();
            if (myDt.Rows.Count == 0)
            {
                MessageBox.Show("No data");
            }
        }

        private void btInBieu_Click(object sender, EventArgs e)
        {
            String strDt = cboKy.Text + " năm " + dupNam.Text;
            List<String> ChuKi = new List<string>();
            ChuKi.Add(txtNLB1.Text);
            ChuKi.Add(txtNLB2.Text);
            ChuKi.Add(txtNLB3.Text);
            ChuKi.Add(txtNK1.Text);
            ChuKi.Add(txtNK2.Text);
            ChuKi.Add(txtNK3.Text);
            FrmPrintReport frm = new FrmPrintReport("3", SelectedId, strDt, ChuKi, Level);
            frm.Show();
        }
        void initGird()
        {
            SourceGrid.Cells.Views.Cell yellowView = new SourceGrid.Cells.Views.Cell();
            yellowView.BackColor = Color.Lavender;
            yellowView.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;

            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.ColumnsCount = 18;
            grid1.FixedRows = 3;
            grid1.Rows.Insert(0);
            grid1.Rows.Insert(1);
            grid1.Rows.Insert(2);

            grid1[0, 0] = new SourceGrid.Cells.ColumnHeader("TT"); grid1[0, 0].RowSpan = 2;
            grid1[0, 1] = new SourceGrid.Cells.ColumnHeader("Đơn vị"); grid1[0, 1].RowSpan = 2;
            grid1[0, 2] = new SourceGrid.Cells.ColumnHeader("Họ và Tên"); grid1[0, 2].RowSpan = 2;
            grid1[0, 3] = new SourceGrid.Cells.ColumnHeader("Năm sinh"); grid1[0, 3].RowSpan = 2;
            grid1[0, 4] = new SourceGrid.Cells.ColumnHeader("Trình độ đào tạo"); grid1[0, 4].RowSpan = 2;
            
            grid1[0, 5] = new SourceGrid.Cells.ColumnHeader("Mức lương đang hưởng");
            grid1[0, 5].ColumnSpan = 8;
            grid1[0, 5].View = yellowView;

            grid1[1, 5] = new SourceGrid.Cells.ColumnHeader("Tên ngạch");
            grid1[1, 6] = new SourceGrid.Cells.ColumnHeader("Mã ngạch");
            grid1[1, 7] = new SourceGrid.Cells.ColumnHeader("Bậc cuối cùng trong ngạch");
            grid1[1, 8] = new SourceGrid.Cells.ColumnHeader("Hệ số lương của bậc cuối");
            grid1[1, 9] = new SourceGrid.Cells.ColumnHeader("% Phụ cấp thâm niên vượt khung");
            grid1[1, 10] = new SourceGrid.Cells.ColumnHeader("Hệ sô Phụ cấp TNVK đang hưởng");
            grid1[1, 11] = new SourceGrid.Cells.ColumnHeader("Hệ số chênh lệch bảo lưu (nếu có)");
            grid1[1, 12] = new SourceGrid.Cells.ColumnHeader("Ngày tháng năm hưởng");

            grid1[0, 13] = new SourceGrid.Cells.ColumnHeader("Kết quả nâng mức phụ cấp thâm niên vượt khung");
            grid1[0, 13].ColumnSpan = 5;
            grid1[0, 13].View = yellowView;

            grid1[1, 13] = new SourceGrid.Cells.ColumnHeader("% Phụ cấp thâm niên vượt khung");
            grid1[1, 14] = new SourceGrid.Cells.ColumnHeader("Hệ sô Phụ cấp TNVK được hưởng");
            grid1[1, 15] = new SourceGrid.Cells.ColumnHeader("Hệ số chênh lệch bảo lưu (nếu có)");
            grid1[1, 16] = new SourceGrid.Cells.ColumnHeader("Ngày tháng năm hưởng");
            grid1[1, 17] = new SourceGrid.Cells.ColumnHeader("Chênh lệch hệ số do tăng PCTNVK");

            grid1[2, 0] = new SourceGrid.Cells.ColumnHeader("1");
            grid1[2, 1] = new SourceGrid.Cells.ColumnHeader("2");
            grid1[2, 2] = new SourceGrid.Cells.ColumnHeader("3");
            grid1[2, 3] = new SourceGrid.Cells.ColumnHeader("4");
            grid1[2, 4] = new SourceGrid.Cells.ColumnHeader("5");
            grid1[2, 5] = new SourceGrid.Cells.ColumnHeader("6");
            grid1[2, 6] = new SourceGrid.Cells.ColumnHeader("7");
            grid1[2, 7] = new SourceGrid.Cells.ColumnHeader("8");
            grid1[2, 8] = new SourceGrid.Cells.ColumnHeader("9");
            grid1[2, 9] = new SourceGrid.Cells.ColumnHeader("10");
            grid1[2, 10] = new SourceGrid.Cells.ColumnHeader("11");
            grid1[2, 11] = new SourceGrid.Cells.ColumnHeader("12");
            grid1[2, 12] = new SourceGrid.Cells.ColumnHeader("13");
            grid1[2, 13] = new SourceGrid.Cells.ColumnHeader("14");
            grid1[2, 14] = new SourceGrid.Cells.ColumnHeader("15");
            grid1[2, 15] = new SourceGrid.Cells.ColumnHeader("16");
            grid1[2, 16] = new SourceGrid.Cells.ColumnHeader("17");
            grid1[2, 17] = new SourceGrid.Cells.ColumnHeader("18");
          
            grid1.AutoSizeCells();
        }

        public void GetDonVi(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            SelectedId = comp[0];
            txtDonVi.Text = comp[1];
            Level = int.Parse(comp[2]);
        }

        private void btnChonDonVi_Click(object sender, EventArgs e)
        {
            FrmDanhMuc frm = new FrmDanhMuc();
            frm.Handler += GetDonVi;
            frm.EnableButtonChon = true;
            frm.ShowDialog();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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
