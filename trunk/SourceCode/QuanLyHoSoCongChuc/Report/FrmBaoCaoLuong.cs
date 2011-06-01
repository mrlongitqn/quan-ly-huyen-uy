using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyHoSoCongChuc.Report
{
    #region Using
    using QuanLyHoSoCongChuc.Models;
    using QuanLyHoSoCongChuc.Repositories;
    #endregion
    public partial class FrmBaoCaoLuong : Form
    {
        public FrmBaoCaoLuong()
        {
            InitializeComponent();
        }

        private void FrmBaoCaoLuong_Load(object sender, EventArgs e)
        {
            loadDonVi();
            cbDoiTuong.SelectedIndex = 0;
            cbKy.SelectedIndex = 0;
            initGird2();
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

        private void btInBieu_Click(object sender, EventArgs e)
        {
            DateTime dt = dtNgay.Value;
            String strDt = dt.ToString("dd/MM/yyyy");
            ListItem DV = (ListItem)cbDonVi.SelectedItem;
            int type = cbDoiTuong.SelectedIndex;

            FrmPrintReport frm = new FrmPrintReport("1-"+type.ToString(), DV.ID, strDt);
            frm.Show();
        }
        void initGird1()
        {
            SourceGrid.Cells.Views.Cell yellowView = new SourceGrid.Cells.Views.Cell();
            yellowView.BackColor = Color.Lavender;
            yellowView.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;

            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.ColumnsCount = 14;
            grid1.FixedRows = 2;
            grid1.Rows.Insert(0);
            grid1.Rows.Insert(1);

            grid1[0, 0] = new SourceGrid.Cells.ColumnHeader("STT");
            grid1[0, 0].RowSpan = 2;
            grid1[0, 1] = new SourceGrid.Cells.ColumnHeader("Đơn vị");
            grid1[0, 1].RowSpan = 2;
            grid1[0, 2] = new SourceGrid.Cells.ColumnHeader("Tổng biên chế được giao năm");
            grid1[0, 2].ColumnSpan = 4;
            grid1[0, 2].View = yellowView;

            grid1[1, 2] = new SourceGrid.Cells.ColumnHeader("Tổng số");
            grid1[1, 3] = new SourceGrid.Cells.ColumnHeader("CB, công chức");
            grid1[1, 4] = new SourceGrid.Cells.ColumnHeader("CB, viên chức");
            grid1[1, 5] = new SourceGrid.Cells.ColumnHeader("Hợp đồng 68/CP");

            grid1[0, 6] = new SourceGrid.Cells.ColumnHeader("Tổng biên chế hiện nay");
            grid1[0, 6].ColumnSpan = 4;
            grid1[0, 6].View = yellowView;

            grid1[1, 6] = new SourceGrid.Cells.ColumnHeader("Tổng số");
            grid1[1, 7] = new SourceGrid.Cells.ColumnHeader("CB, công chức");
            grid1[1, 8] = new SourceGrid.Cells.ColumnHeader("CB, viên chức");
            grid1[1, 9] = new SourceGrid.Cells.ColumnHeader("Hợp đồng 68/CP");

            grid1[0, 10] = new SourceGrid.Cells.ColumnHeader("Hệ số lương theo");
            grid1[0, 10].ColumnSpan = 4;
            grid1[0, 10].View = yellowView;

            grid1[1, 10] = new SourceGrid.Cells.ColumnHeader("Hệ số lương của bậc trong ngạch");

            grid1[1, 11] = new SourceGrid.Cells.ColumnHeader("Hệ số phụ cấp thâm niên VK");
            grid1[1, 12] = new SourceGrid.Cells.ColumnHeader("Chức vụ");
            grid1[1, 13] = new SourceGrid.Cells.ColumnHeader("Thâm niên nghề");

            grid1.AutoSizeCells();
        }
        void initGird2()
        {
            SourceGrid.Cells.Views.Cell yellowView = new SourceGrid.Cells.Views.Cell();
            yellowView.BackColor = Color.Lavender;
            yellowView.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;

            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.ColumnsCount = 22;
            grid1.FixedRows = 3;
            grid1.Rows.Insert(0);
            grid1.Rows.Insert(1);
            grid1.Rows.Insert(2);
            grid1.Rows[1].Height = 500;

            grid1[0, 0] = new SourceGrid.Cells.ColumnHeader("Phòng, ban, đơn vị");
            grid1[0, 0].RowSpan = 2;
            grid1[0, 1] = new SourceGrid.Cells.ColumnHeader("TT");
            grid1[0, 1].RowSpan = 2;
            grid1[0, 2] = new SourceGrid.Cells.ColumnHeader("Họ và Tên");
            grid1[0, 2].RowSpan = 2;
            grid1[0, 3] = new SourceGrid.Cells.ColumnHeader("Ngày tháng năm sinh");
            grid1[0, 3].ColumnSpan = 2;
            grid1[0, 3].View = yellowView;

            grid1[1, 3] = new SourceGrid.Cells.ColumnHeader("Nam");
            grid1[1, 4] = new SourceGrid.Cells.ColumnHeader("Nữ");
            grid1[0, 5] = new SourceGrid.Cells.ColumnHeader("Trình độ chuyên môn được đào tạo");
            grid1[0, 5].RowSpan = 2;
            grid1[0, 6] = new SourceGrid.Cells.ColumnHeader("Chức danh, công việc đang đảm nhân");
            grid1[0, 6].RowSpan = 2;
            grid1[0, 7] = new SourceGrid.Cells.ColumnHeader("Ngạch & Bậc lương");
            grid1[0, 7].ColumnSpan = 2;
            grid1[0, 7].View = yellowView;
            grid1[1, 7] = new SourceGrid.Cells.ColumnHeader("Mã ngạch");
            grid1[1, 8] = new SourceGrid.Cells.ColumnHeader("Bậc");
            grid1[0, 9] = new SourceGrid.Cells.ColumnHeader("Hệ số lương theo ngạch bậc");
            grid1[0, 9].ColumnSpan = 5;
            grid1[0, 9].View = yellowView;

            grid1[1, 9] = new SourceGrid.Cells.ColumnHeader("Hệ số lương của bậc trong ngạch");
            grid1[1, 10] = new SourceGrid.Cells.ColumnHeader("% Phụ cấp TNV");
            grid1[1, 11] = new SourceGrid.Cells.ColumnHeader("Hệ sô Phụ cấp TNV");
            grid1[1, 12] = new SourceGrid.Cells.ColumnHeader("Chênh lệch bảo lưu");
            grid1[1, 13] = new SourceGrid.Cells.ColumnHeader("Thời gian tính nâng lương lần sau");
            
            grid1[0, 14] = new SourceGrid.Cells.ColumnHeader("Hệ số phụ cấp");
            grid1[0, 14].ColumnSpan = 6;
            grid1[0, 14].View = yellowView;

            grid1[1, 14] = new SourceGrid.Cells.ColumnHeader("Chức vụ");
            grid1[1, 15] = new SourceGrid.Cells.ColumnHeader("Thâm niên nghề");
            grid1[1, 16] = new SourceGrid.Cells.ColumnHeader("Trách nhiệm");
            grid1[1, 17] = new SourceGrid.Cells.ColumnHeader("Độc hại");
            grid1[1, 18] = new SourceGrid.Cells.ColumnHeader("Ưu đãi nghề");
            grid1[1, 19] = new SourceGrid.Cells.ColumnHeader("Phụ cấp khác");

            grid1[0, 20] = new SourceGrid.Cells.ColumnHeader("Hệ số lương và phụ cấp");
            grid1[0, 20].RowSpan = 2;
            grid1[0, 21] = new SourceGrid.Cells.ColumnHeader("Tổng tiền lương và phụ cấp 1 tháng");
            grid1[0, 21].RowSpan = 2;


            grid1[2, 0] = new SourceGrid.Cells.ColumnHeader("A");
            grid1[2, 1] = new SourceGrid.Cells.ColumnHeader("");
            grid1[2, 2] = new SourceGrid.Cells.ColumnHeader("B");
            grid1[2, 3] = new SourceGrid.Cells.ColumnHeader("1");
            grid1[2, 4] = new SourceGrid.Cells.ColumnHeader("2");
            grid1[2, 5] = new SourceGrid.Cells.ColumnHeader("3");
            grid1[2, 6] = new SourceGrid.Cells.ColumnHeader("4");
            grid1[2, 7] = new SourceGrid.Cells.ColumnHeader("5");
            grid1[2, 8] = new SourceGrid.Cells.ColumnHeader("6");
            grid1[2, 9] = new SourceGrid.Cells.ColumnHeader("7");
            grid1[2, 10] = new SourceGrid.Cells.ColumnHeader("8");
            grid1[2, 11] = new SourceGrid.Cells.ColumnHeader("9");
            grid1[2, 12] = new SourceGrid.Cells.ColumnHeader("10");
            grid1[2, 13] = new SourceGrid.Cells.ColumnHeader("11");
            grid1[2, 14] = new SourceGrid.Cells.ColumnHeader("12");
            grid1[2, 15] = new SourceGrid.Cells.ColumnHeader("13");
            grid1[2, 16] = new SourceGrid.Cells.ColumnHeader("14");
            grid1[2, 17] = new SourceGrid.Cells.ColumnHeader("15");
            grid1[2, 18] = new SourceGrid.Cells.ColumnHeader("16");
            grid1[2, 19] = new SourceGrid.Cells.ColumnHeader("17");
            grid1[2, 20] = new SourceGrid.Cells.ColumnHeader("18");
            grid1[2, 21] = new SourceGrid.Cells.ColumnHeader("19");

            grid1.AutoSizeCells();
        }
        private void btBaoBieu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chua lam xong");
        }
    }
}
