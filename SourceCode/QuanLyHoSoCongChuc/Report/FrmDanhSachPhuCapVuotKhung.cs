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
    #region Using
    using QuanLyHoSoCongChuc.Models;
    using QuanLyHoSoCongChuc.Repositories;
    #endregion
    public partial class FrmDanhSachPhuCapVuotKhung : Form
    {
        DataService dataService = new DataService();
        public FrmDanhSachPhuCapVuotKhung()
        {
            InitializeComponent();
        }

        private void FrmDanhSachPhuCapVuotKhung_Load(object sender, EventArgs e)
        {
            loadDonVi();
            loadNam();
            initGird();
            cboKy.SelectedIndex = 0;
        }
        void loadDonVi()
        {
            var lstDonVi = DonViRepository.SelectAll();
            for (int i = 0; i < lstDonVi.Count; i++)
            {
                cbDonVi.Items.Add(new ListItem(lstDonVi[i].MaDonVi, lstDonVi[i].TenDonVi));
            }
            if (lstDonVi.Count > 0)
                cbDonVi.SelectedIndex = 0;
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
            ListItem DV = (ListItem)cbDonVi.SelectedItem;
            String sql = " select nv.*, t.TenTrinhDoChuyenMon, dv.TenDonVi";
            sql += " from NhanVien nv left join TrinhDoChuyenMon t on nv.MaTrinhDoChuyenMon = t.MaTrinhDoChuyenMon";
            sql += " left join DonVi dv on nv.MaDonVi = dv.MaDonVi";
            sql += " where nv.MaDonVi='" + DV.ID + "'";

            SqlCommand cmd = new SqlCommand(sql);
            dataService.Load(cmd);
            DataTable myDt = dataService;

            for (int r = 0; r < myDt.Rows.Count; r++)
            {
                grid1.Rows.Insert(r + 3);
                grid1[3 + r, 0] = new SourceGrid.Cells.Cell(r + 1, typeof(int));
                grid1[3 + r, 1] = new SourceGrid.Cells.Cell(myDt.Rows[r]["TenDonVi"], typeof(String));
                grid1[3 + r, 2] = new SourceGrid.Cells.Cell(myDt.Rows[r]["HoTenNhanVien"], typeof(String));

                DateTime dt = (DateTime)myDt.Rows[r]["NgaySinh"];
                grid1[3 + r, 3] = new SourceGrid.Cells.Cell(dt.Year, typeof(int));
                grid1[3 + r, 4] = new SourceGrid.Cells.Cell(myDt.Rows[r]["TenTrinhDoChuyenMon"], typeof(String));
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
            ListItem DV = (ListItem)cbDonVi.SelectedItem;

            FrmPrintReport frm = new FrmPrintReport("3", DV.ID, strDt);
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
    }
}
