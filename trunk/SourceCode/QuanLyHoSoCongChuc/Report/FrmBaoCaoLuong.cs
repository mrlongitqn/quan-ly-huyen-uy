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
    public partial class FrmBaoCaoLuong : Form
    {
        String SelectedId;
        int Level;
        DataService dataService = new DataService();
        public FrmBaoCaoLuong()
        {
            InitializeComponent();
        }

        private void FrmBaoCaoLuong_Load(object sender, EventArgs e)
        {
            cbDoiTuong.SelectedIndex = 0;
            cbKy.SelectedIndex = 0;
        }
        

        private void btInBieu_Click(object sender, EventArgs e)
        {
            DateTime dt = dtNgay.Value;
            String strDt = dt.ToString("dd/MM/yyyy");
            int type = cbDoiTuong.SelectedIndex;
            List<String> ChuKi = new List<string>();
            ChuKi.Add(txtNLB1.Text);
            ChuKi.Add(txtNLB2.Text);
            ChuKi.Add(txtNLB3.Text);
            ChuKi.Add(txtNK1.Text);
            ChuKi.Add(txtNK2.Text);
            ChuKi.Add(txtNK3.Text);
            FrmPrintReport frm = new FrmPrintReport("1-" + type.ToString(), SelectedId, strDt, ChuKi, Level);
            frm.Show();
        }
        void initGird1()
        {
            grid1.Rows.Clear();
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
            grid1.Rows.Clear();
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

            grid1[0, 0] = new SourceGrid.Cells.ColumnHeader("TT");
            grid1[0, 0].RowSpan = 2;

            grid1[0, 1] = new SourceGrid.Cells.ColumnHeader("Phòng, ban, đơn vị");
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


            grid1[2, 0] = new SourceGrid.Cells.ColumnHeader(""); grid1[2, 0].View = yellowView;
            grid1[2, 1] = new SourceGrid.Cells.ColumnHeader("A"); grid1[2, 1].View = yellowView;
            grid1[2, 2] = new SourceGrid.Cells.ColumnHeader("B"); grid1[2, 2].View = yellowView;
            grid1[2, 3] = new SourceGrid.Cells.ColumnHeader("1"); grid1[2, 3].View = yellowView;
            grid1[2, 4] = new SourceGrid.Cells.ColumnHeader("2"); grid1[2, 4].View = yellowView;
            grid1[2, 5] = new SourceGrid.Cells.ColumnHeader("3"); grid1[2, 5].View = yellowView;
            grid1[2, 6] = new SourceGrid.Cells.ColumnHeader("4"); grid1[2, 6].View = yellowView;
            grid1[2, 7] = new SourceGrid.Cells.ColumnHeader("5"); grid1[2, 7].View = yellowView;
            grid1[2, 8] = new SourceGrid.Cells.ColumnHeader("6"); grid1[2, 8].View = yellowView;
            grid1[2, 9] = new SourceGrid.Cells.ColumnHeader("7"); grid1[2, 9].View = yellowView;
            grid1[2, 10] = new SourceGrid.Cells.ColumnHeader("8"); grid1[2, 10].View = yellowView;
            grid1[2, 11] = new SourceGrid.Cells.ColumnHeader("9"); grid1[2, 11].View = yellowView;
            grid1[2, 12] = new SourceGrid.Cells.ColumnHeader("10"); grid1[2, 12].View = yellowView;
            grid1[2, 13] = new SourceGrid.Cells.ColumnHeader("11"); grid1[2, 13].View = yellowView;
            grid1[2, 14] = new SourceGrid.Cells.ColumnHeader("12"); grid1[2, 14].View = yellowView;
            grid1[2, 15] = new SourceGrid.Cells.ColumnHeader("13"); grid1[2, 15].View = yellowView;
            grid1[2, 16] = new SourceGrid.Cells.ColumnHeader("14"); grid1[2, 16].View = yellowView;
            grid1[2, 17] = new SourceGrid.Cells.ColumnHeader("15"); grid1[2, 17].View = yellowView;
            grid1[2, 18] = new SourceGrid.Cells.ColumnHeader("16"); grid1[2, 18].View = yellowView;
            grid1[2, 19] = new SourceGrid.Cells.ColumnHeader("17"); grid1[2, 19].View = yellowView;
            grid1[2, 20] = new SourceGrid.Cells.ColumnHeader("18"); grid1[2, 20].View = yellowView;
            grid1[2, 21] = new SourceGrid.Cells.ColumnHeader("19"); grid1[2, 21].View = yellowView;

            grid1.AutoSizeCells();
        }
        void initGird3()
        {
            grid1.Rows.Clear();
            SourceGrid.Cells.Views.Cell yellowView = new SourceGrid.Cells.Views.Cell();
            yellowView.BackColor = Color.Lavender;
            yellowView.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;

            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.ColumnsCount = 22;
            grid1.FixedRows = 3;
            grid1.Rows.Insert(0);
            grid1.Rows.Insert(1);
            grid1.Rows.Insert(2);
            grid1.Rows.Insert(3);
            grid1.Rows[1].Height = 500;

            grid1[0, 0] = new SourceGrid.Cells.ColumnHeader("TT");
            grid1[0, 0].RowSpan = 3;

            grid1[0, 1] = new SourceGrid.Cells.ColumnHeader("Phòng, ban, đơn vị");
            grid1[0, 1].RowSpan = 3;

            grid1[0, 2] = new SourceGrid.Cells.ColumnHeader("Họ và tên");
            grid1[0, 2].RowSpan = 3;

            grid1[0, 3] = new SourceGrid.Cells.ColumnHeader("Ngày tháng năm sinh");
            grid1[0, 3].ColumnSpan = 2;
            grid1[0, 3].View = yellowView;
            grid1[1, 3] = new SourceGrid.Cells.ColumnHeader("Nam");
            grid1[1, 3].RowSpan = 2;
            grid1[1, 4] = new SourceGrid.Cells.ColumnHeader("Nữ");
            grid1[1, 4].RowSpan = 2;

            grid1[0, 5] = new SourceGrid.Cells.ColumnHeader("Trình độ chuyên môn được đào tạo");
            grid1[0, 5].RowSpan = 3;

            grid1[0, 6] = new SourceGrid.Cells.ColumnHeader("Chức danh, công việc đang đảm nhân");
            grid1[0, 6].RowSpan = 3;

            grid1[0, 7] = new SourceGrid.Cells.ColumnHeader("Ngạch & Bậc lương");
            grid1[0, 7].ColumnSpan = 2;
            grid1[0, 7].View = yellowView;
            grid1[1, 7] = new SourceGrid.Cells.ColumnHeader("Mã ngạch"); grid1[1, 7].RowSpan = 2;
            grid1[1, 8] = new SourceGrid.Cells.ColumnHeader("Bậc");grid1[1, 8].RowSpan = 2;
            
            grid1[0, 9] = new SourceGrid.Cells.ColumnHeader("Hệ số lương theo ngạch bậc");
            grid1[0, 9].ColumnSpan = 5;
            grid1[0, 9].View = yellowView;

            grid1[1, 9] = new SourceGrid.Cells.ColumnHeader("Hệ số lương của bậc trong ngạch"); grid1[1, 9].RowSpan = 2;

            grid1[1, 10] = new SourceGrid.Cells.ColumnHeader("Phụ cấp TN");
            grid1[1, 10].ColumnSpan = 2;
            grid1[2, 10] = new SourceGrid.Cells.ColumnHeader("%");
            grid1[2, 11] = new SourceGrid.Cells.ColumnHeader("Hệ số");

            grid1[1, 12] = new SourceGrid.Cells.ColumnHeader("Chênh lệch bảo lưu (nếu có)"); grid1[1, 12].RowSpan = 2;

            grid1[1, 13] = new SourceGrid.Cells.ColumnHeader("Thời gian tính nâng lương lần sau"); grid1[1, 13].RowSpan = 2;
            
            grid1[0, 14] = new SourceGrid.Cells.ColumnHeader("Hệ số phụ cấp");
            grid1[0, 14].ColumnSpan = 5;
            grid1[0, 14].View = yellowView;

            grid1[1, 14] = new SourceGrid.Cells.ColumnHeader("Chức vụ"); grid1[1, 14].RowSpan = 2;
            grid1[1, 15] = new SourceGrid.Cells.ColumnHeader("Trách nhiệm"); grid1[1, 15].RowSpan = 2;
            grid1[1, 16] = new SourceGrid.Cells.ColumnHeader("Độc hại"); grid1[1, 16].RowSpan = 2;
            grid1[1, 17] = new SourceGrid.Cells.ColumnHeader("Ưu đãi nghề"); grid1[1, 17].RowSpan = 2;
            grid1[1, 18] = new SourceGrid.Cells.ColumnHeader("Phụ cấp khác"); grid1[1, 18].RowSpan = 2;

            grid1[0, 19] = new SourceGrid.Cells.ColumnHeader("Tổng hệ số lương và phụ cấp");
            grid1[0, 19].RowSpan = 3;

            grid1[0, 20] = new SourceGrid.Cells.ColumnHeader("Tổng tiền lương và phụ cấp một tháng");
            grid1[0, 20].RowSpan = 3;

            grid1[0, 21] = new SourceGrid.Cells.ColumnHeader("Ghi chú");
            grid1[0, 21].RowSpan = 3;




            grid1[3, 0] = new SourceGrid.Cells.ColumnHeader(""); grid1[3, 0].View = yellowView;
            grid1[3, 1] = new SourceGrid.Cells.ColumnHeader("A"); grid1[3, 1].View = yellowView;
            grid1[3, 2] = new SourceGrid.Cells.ColumnHeader("B"); grid1[3, 2].View = yellowView;
            grid1[3, 3] = new SourceGrid.Cells.ColumnHeader("1"); grid1[3, 3].View = yellowView;
            grid1[3, 4] = new SourceGrid.Cells.ColumnHeader("2"); grid1[3, 4].View = yellowView;
            grid1[3, 5] = new SourceGrid.Cells.ColumnHeader("3"); grid1[3, 5].View = yellowView;
            grid1[3, 6] = new SourceGrid.Cells.ColumnHeader("4"); grid1[3, 6].View = yellowView;
            grid1[3, 7] = new SourceGrid.Cells.ColumnHeader("5"); grid1[3, 7].View = yellowView;
            grid1[3, 8] = new SourceGrid.Cells.ColumnHeader("6"); grid1[3, 8].View = yellowView;
            grid1[3, 9] = new SourceGrid.Cells.ColumnHeader("7"); grid1[3, 9].View = yellowView;
            grid1[3, 10] = new SourceGrid.Cells.ColumnHeader("8"); grid1[3, 10].View = yellowView;
            grid1[3, 11] = new SourceGrid.Cells.ColumnHeader("9"); grid1[3, 11].View = yellowView;
            grid1[3, 12] = new SourceGrid.Cells.ColumnHeader("10"); grid1[3, 12].View = yellowView;
            grid1[3, 13] = new SourceGrid.Cells.ColumnHeader("11"); grid1[3, 13].View = yellowView;
            grid1[3, 14] = new SourceGrid.Cells.ColumnHeader("12"); grid1[3, 14].View = yellowView;
            grid1[3, 15] = new SourceGrid.Cells.ColumnHeader("13"); grid1[3, 15].View = yellowView;
            grid1[3, 16] = new SourceGrid.Cells.ColumnHeader("14"); grid1[3, 16].View = yellowView;
            grid1[3, 17] = new SourceGrid.Cells.ColumnHeader("15"); grid1[3, 17].View = yellowView;
            grid1[3, 18] = new SourceGrid.Cells.ColumnHeader("16"); grid1[3, 18].View = yellowView;
            grid1[3, 19] = new SourceGrid.Cells.ColumnHeader("17"); grid1[3, 19].View = yellowView;
            grid1[3, 20] = new SourceGrid.Cells.ColumnHeader("18"); grid1[3, 20].View = yellowView;
            grid1[3, 21] = new SourceGrid.Cells.ColumnHeader("19"); grid1[3, 21].View = yellowView;

            grid1.AutoSizeCells();
        }
        private void btBaoBieu_Click(object sender, EventArgs e)
        {
            grid1.Rows.Clear();
            if (cbDoiTuong.SelectedIndex == 0)
            {
                initGird1();
                String sql = "Select * from DonVi";
                sql += " where 1=1";
                sql += LoadSql_MaDonVi();

                SqlCommand cmd = new SqlCommand(sql);
                dataService.Load(cmd);
                DataTable myDt = dataService;

                SourceGrid.Cells.Views.Cell yellowView = new SourceGrid.Cells.Views.Cell();
                yellowView.BackColor = Color.Yellow;
                yellowView.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
                for (int r = 0; r < myDt.Rows.Count; r++)
                {
                    grid1.Rows.Insert(r + 2);
                    grid1[2 + r, 0] = new SourceGrid.Cells.Cell(r + 1, typeof(int));
                    grid1[2 + r, 1] = new SourceGrid.Cells.Cell(myDt.Rows[r]["TenDonVi"], typeof(String));
                    grid1[2 + r, 2] = new SourceGrid.Cells.Cell("", typeof(String));

                    grid1[2 + r, 2] = new SourceGrid.Cells.Cell("", typeof(int));
                    grid1[2 + r, 3] = new SourceGrid.Cells.Cell("", typeof(String));
                    grid1[2 + r, 4] = new SourceGrid.Cells.Cell("", typeof(String));
                    grid1[2 + r, 5] = new SourceGrid.Cells.Cell("1", typeof(String)); grid1[2 + r, 5].View = yellowView;
                    grid1[2 + r, 6] = new SourceGrid.Cells.Cell("1", typeof(String)); grid1[2 + r, 6].View = yellowView;
                    grid1[2 + r, 7] = new SourceGrid.Cells.Cell("1", typeof(String)); grid1[2 + r, 7].View = yellowView;
                    grid1[2 + r, 8] = new SourceGrid.Cells.Cell("1", typeof(String)); grid1[2 + r, 8].View = yellowView;
                    grid1[2 + r, 9] = new SourceGrid.Cells.Cell("1", typeof(String)); grid1[2 + r, 9].View = yellowView;
                    grid1[2 + r, 10] = new SourceGrid.Cells.Cell("1", typeof(String)); grid1[2 + r, 10].View = yellowView;
                    grid1[2 + r, 11] = new SourceGrid.Cells.Cell("", typeof(String));
                    grid1[2 + r, 12] = new SourceGrid.Cells.Cell("", typeof(String));
                    grid1[2 + r, 13] = new SourceGrid.Cells.Cell("", typeof(String));
                }

                if (myDt.Rows.Count == 0)
                {
                    MessageBox.Show("No data");
                }
            }
            else if (cbDoiTuong.SelectedIndex == 1)
            {
                initGird2();

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

                SourceGrid.Cells.Views.Cell yellowView = new SourceGrid.Cells.Views.Cell();
                yellowView.BackColor = Color.Yellow;
                yellowView.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
                for (int r = 0; r < myDt.Rows.Count; r++)
                {
                    grid1.Rows.Insert(r + 3);
                    grid1[3 + r, 0] = new SourceGrid.Cells.Cell(r + 1, typeof(int));
                    grid1[3 + r, 1] = new SourceGrid.Cells.Cell(myDt.Rows[r]["TenDonVi"], typeof(String));
                    grid1[3 + r, 2] = new SourceGrid.Cells.Cell(myDt.Rows[r]["HoTenKhaiSinh"], typeof(String));

                    try
                    {
                        DateTime dt = (DateTime)myDt.Rows[r]["NgaySinhNam"];
                        grid1[3 + r, 3] = new SourceGrid.Cells.Cell(dt.ToString("dd/MM/yyyy"), typeof(String));
                    }
                    catch (Exception ex)
                    {
                        grid1[3 + r, 3] = new SourceGrid.Cells.Cell("", typeof(String));
                    }
                    try
                    {
                        DateTime dt = (DateTime)myDt.Rows[r]["NgaySinhNu"];
                        grid1[3 + r, 4] = new SourceGrid.Cells.Cell(dt.ToString("dd/MM/yyyy"), typeof(String));
                    }
                    catch (Exception ex)
                    {
                        grid1[3 + r, 4] = new SourceGrid.Cells.Cell("", typeof(String));
                    }
                    grid1[3 + r, 5] = new SourceGrid.Cells.Cell(myDt.Rows[r]["TenBangChuyenMonNghiepVu"], typeof(String));
                    grid1[3 + r, 6] = new SourceGrid.Cells.Cell(myDt.Rows[r]["TenChucVu"], typeof(String));
                    grid1[3 + r, 7] = new SourceGrid.Cells.Cell(myDt.Rows[r]["MaNgachCongChuc"], typeof(String));
                    grid1[3 + r, 8] = new SourceGrid.Cells.Cell(myDt.Rows[r]["BacLuong"], typeof(String));
                    grid1[3 + r, 9] = new SourceGrid.Cells.Cell(myDt.Rows[r]["HeSoLuong"], typeof(String));
                    grid1[3 + r, 10] = new SourceGrid.Cells.Cell("Empty", typeof(String));
                    grid1[3 + r, 11] = new SourceGrid.Cells.Cell(myDt.Rows[r]["HeSoPhuCapThamNienVuotKhung"], typeof(String));
                    grid1[3 + r, 12] = new SourceGrid.Cells.Cell(myDt.Rows[r]["ChenhLechBaoLuuHeSoLuong"], typeof(String));
                    
                    try
                    {
                        DateTime dt = (DateTime)myDt.Rows[r]["MocTinhNangLuongLanSau"];
                        grid1[3 + r, 13] = new SourceGrid.Cells.Cell(dt.ToString("dd/MM/yyyy"), typeof(String));
                    }
                    catch (Exception ex) {
                        grid1[3 + r, 13] = new SourceGrid.Cells.Cell("", typeof(String));
                    }

                    grid1[3 + r, 14] = new SourceGrid.Cells.Cell(myDt.Rows[r]["HeSoPhuCapChucVu"], typeof(String));
                    grid1[3 + r, 15] = new SourceGrid.Cells.Cell(myDt.Rows[r]["HeSoPhuCapThamNienNghe"], typeof(String));
                    grid1[3 + r, 16] = new SourceGrid.Cells.Cell(myDt.Rows[r]["HeSoPhuCapTrachNhiem"], typeof(String));
                    grid1[3 + r, 17] = new SourceGrid.Cells.Cell(myDt.Rows[r]["HeSoPhuCapDocHai"], typeof(String));
                    grid1[3 + r, 18] = new SourceGrid.Cells.Cell(myDt.Rows[r]["HeSoPhuCapUuDaiNghe"], typeof(String));
                    grid1[3 + r, 19] = new SourceGrid.Cells.Cell(myDt.Rows[r]["HeSoPhuCapKhac"], typeof(String));
                    grid1[3 + r, 20] = new SourceGrid.Cells.Cell(myDt.Rows[r]["TongHeSoLuongVaPhuCap"], typeof(String)); grid1[3 + r, 20].View = yellowView;
                    grid1[3 + r, 21] = new SourceGrid.Cells.Cell("", typeof(String)); grid1[3 + r, 21].View = yellowView;
                }

                if (myDt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }
            else if (cbDoiTuong.SelectedIndex == 2)
            {
                initGird3();
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

                SourceGrid.Cells.Views.Cell yellowView = new SourceGrid.Cells.Views.Cell();
                yellowView.BackColor = Color.Yellow;
                yellowView.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
                for (int r = 0; r < myDt.Rows.Count; r++)
                {
                    grid1.Rows.Insert(r + 4);
                    grid1[4 + r, 1] = new SourceGrid.Cells.Cell(myDt.Rows[r]["TenDonVi"], typeof(String));
                    grid1[4 + r, 2] = new SourceGrid.Cells.Cell(myDt.Rows[r]["HoTenKhaiSinh"], typeof(String));

                    try
                    {
                        DateTime dt = (DateTime)myDt.Rows[r]["NgaySinhNam"];
                        grid1[4 + r, 3] = new SourceGrid.Cells.Cell(dt.ToString("dd/MM/yyyy"), typeof(String));
                    }
                    catch (Exception ex)
                    {
                        grid1[4 + r, 3] = new SourceGrid.Cells.Cell("", typeof(String));
                    }
                    try
                    {
                        DateTime dt = (DateTime)myDt.Rows[r]["NgaySinhNu"];
                        grid1[4 + r, 4] = new SourceGrid.Cells.Cell(dt.ToString("dd/MM/yyyy"), typeof(String));
                    }
                    catch (Exception ex)
                    {
                        grid1[4 + r, 4] = new SourceGrid.Cells.Cell("", typeof(String));
                    }
                    grid1[4 + r, 5] = new SourceGrid.Cells.Cell(myDt.Rows[r]["TenBangChuyenMonNghiepVu"], typeof(String));
                    grid1[4 + r, 6] = new SourceGrid.Cells.Cell(myDt.Rows[r]["TenChucVu"], typeof(String));
                    grid1[4 + r, 7] = new SourceGrid.Cells.Cell(myDt.Rows[r]["MaNgachCongChuc"], typeof(String));
                    grid1[4 + r, 8] = new SourceGrid.Cells.Cell(myDt.Rows[r]["BacLuong"], typeof(String));
                    grid1[4 + r, 9] = new SourceGrid.Cells.Cell(myDt.Rows[r]["HeSoLuong"], typeof(String));
                    grid1[4 + r, 10] = new SourceGrid.Cells.Cell("Empty", typeof(String));
                    grid1[4 + r, 11] = new SourceGrid.Cells.Cell(myDt.Rows[r]["HeSoPhuCapThamNienVuotKhung"], typeof(String));
                    grid1[4 + r, 12] = new SourceGrid.Cells.Cell(myDt.Rows[r]["ChenhLechBaoLuuHeSoLuong"], typeof(String));

                    try
                    {
                        DateTime dt = (DateTime)myDt.Rows[r]["MocTinhNangLuongLanSau"];
                        grid1[4 + r, 13] = new SourceGrid.Cells.Cell(dt.ToString("dd/MM/yyyy"), typeof(String));
                    }
                    catch (Exception ex)
                    {
                        grid1[4 + r, 13] = new SourceGrid.Cells.Cell("", typeof(String));
                    }
                    grid1[4 + r, 14] = new SourceGrid.Cells.Cell(myDt.Rows[r]["HeSoPhuCapChucVu"], typeof(String));
                    grid1[4 + r, 15] = new SourceGrid.Cells.Cell(myDt.Rows[r]["HeSoPhuCapTrachNhiem"], typeof(String));
                    grid1[4 + r, 16] = new SourceGrid.Cells.Cell(myDt.Rows[r]["HeSoPhuCapDocHai"], typeof(String));
                    grid1[4 + r, 17] = new SourceGrid.Cells.Cell(myDt.Rows[r]["HeSoPhuCapUuDaiNghe"], typeof(String));
                    grid1[4 + r, 18] = new SourceGrid.Cells.Cell(myDt.Rows[r]["HeSoPhuCapKhac"], typeof(String));
                    grid1[4 + r, 19] = new SourceGrid.Cells.Cell(myDt.Rows[r]["TongHeSoLuongVaPhuCap"], typeof(String)); ; grid1[4 + r, 19].View = yellowView;
                    grid1[4 + r, 20] = new SourceGrid.Cells.Cell("", typeof(String)); 
                }

                if (myDt.Rows.Count == 0)
                {
                    MessageBox.Show("No data");
                }
            }

            
            

            grid1.AutoSizeCells();
            
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

        private void cbDoiTuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDoiTuong.SelectedIndex == 0)
                initGird1();
            else if(cbDoiTuong.SelectedIndex == 1)
                 initGird2();
            else if (cbDoiTuong.SelectedIndex == 2)
                initGird3();

        }

        private void btnChonDonVi_Click(object sender, EventArgs e)
        {
            FrmDanhMuc frm = new FrmDanhMuc(true);
            frm.Handler += GetDonVi;
            frm.ShowDialog();
        }
        public void GetDonVi(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            SelectedId = comp[0];
            txtDonVi.Text = comp[1];
            Level = int.Parse(comp[2]); 
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
