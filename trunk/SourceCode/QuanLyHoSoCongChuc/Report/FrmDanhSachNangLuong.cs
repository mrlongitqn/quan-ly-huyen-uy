using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace QuanLyHoSoCongChuc.Report
{
    #region Using
    using QuanLyHoSoCongChuc.Models;
    using QuanLyHoSoCongChuc.Repositories;
    #endregion
    public partial class FrmDanhSachNangLuong : Form
    {
        DataService dataService = new DataService();
        public FrmDanhSachNangLuong()
        {
            InitializeComponent();
        }

        private void FrmDanhSachNangLuong_Load(object sender, EventArgs e)
        {
            loadDonVi();
            loadNam();
            cboKy.SelectedIndex = 0;

            this.DGVLuong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DGVLuong.ColumnHeadersHeight = 90;// this.DGVLuong.ColumnHeadersHeight * 2;
            this.DGVLuong.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            this.DGVLuong.CellPainting += new DataGridViewCellPaintingEventHandler(DGVLuong_CellPainting);
            this.DGVLuong.Paint += new PaintEventHandler(DGVLuong_Paint);

            this.DGVLuong.Scroll += new ScrollEventHandler(DGVLuong_Scroll);
            this.DGVLuong.ColumnWidthChanged += new DataGridViewColumnEventHandler(DGVLuong_ColumnWidthChanged);
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
                dupNam.Items.Add(1950+i);
            }
            dupNam.SelectedIndex = 50;
        }

        private void btInBieu_Click(object sender, EventArgs e)
        {
            String strDt = cboKy.Text + " năm " + dupNam.Text;
            ListItem DV = (ListItem)cbDonVi.SelectedItem;

            FrmPrintReport frm = new FrmPrintReport("2", DV.ID, strDt);
            frm.Show();
        }

        private void btBaoBieu_Click(object sender, EventArgs e)
        {
            DGVLuong.Rows.Clear();
            ListItem DV = (ListItem)cbDonVi.SelectedItem;
            String sql = " select nv.*, t.TenTrinhDoChuyenMon,";
            sql += " NgaySinhNam = case MaGioiTinh when 1 then NgaySinh end,";
            sql += " NgaySinhNu = case MaGioiTinh when 0 then NgaySinh end";
            sql += " from NhanVien nv left join TrinhDoChuyenMon t on nv.MaTrinhDoChuyenMon = t.MaTrinhDoChuyenMon";
            sql += " where MaDonVi='" + DV.ID + "'";


            SqlCommand cmd = new SqlCommand(sql);
            dataService.Load(cmd);
            DataTable myDt = dataService;

            for (int i = 0; i < myDt.Rows.Count; i++)
            {
                DGVLuong.Rows.Add();
                DGVLuong.Rows[i].Cells["STT"].Value = i + 1;
                
                DGVLuong.Rows[i].Cells["TenDonVi"].Value = myDt.Rows[i]["TenDonVi"].ToString();
                DGVLuong.Rows[i].Cells["HoTenNhanVien"].Value = myDt.Rows[i]["HoTenNhanVien"].ToString();
                DateTime dt = (DateTime)myDt.Rows[i]["NgaySinh"];
                DGVLuong.Rows[i].Cells["NamSinh"].Value = dt.ToString("yyyy");
                DGVLuong.Rows[i].Cells["QueQuan"].Value = myDt.Rows[i]["QueQuan"].ToString();
                DGVLuong.Rows[i].Cells["TuoiDoi"].Value = DateTime.Now.Year - dt.Year;
                dt = (DateTime)myDt.Rows[i]["NgayHopDong"];
                DGVLuong.Rows[i].Cells["NamCongTac"].Value = dt.ToString("dd/MM/yyyy");
                DGVLuong.Rows[i].Cells["HeSoLuong"].Value = myDt.Rows[i]["HeSoLuong"].ToString();
                DGVLuong.Rows[i].Cells["TenChucVu"].Value = myDt.Rows[i]["TenChucVu"].ToString();
                DGVLuong.Rows[i].Cells["TrinhDoDaoTao"].Value = myDt.Rows[i]["TenTrinhDoChuyenMon"].ToString();
                DGVLuong.Rows[i].Cells["TenTrinhDoChinhTri"].Value = myDt.Rows[i]["TenTrinhDoChinhTri"].ToString();
            }
            if (myDt.Rows.Count == 0)
            {
                MessageBox.Show("No data");
            }
        }

        private void DGVLuong_Paint(object sender, PaintEventArgs e)
        {
            Rectangle r1 = this.DGVLuong.GetCellDisplayRectangle(5, -1, true);
            Rectangle r2 = this.DGVLuong.GetCellDisplayRectangle(9, -1, true);
            int w2 = this.DGVLuong.GetCellDisplayRectangle(9, -1, true).Width;
            r1.X += 1;
            r1.Y += 1;
            r1.Width = r1.Width + r2.X -r1.X + w2 - 2;
            r1.Height = 30;// r1.Height / 2 - 2;
            e.Graphics.FillRectangle(new SolidBrush(this.DGVLuong.ColumnHeadersDefaultCellStyle.BackColor), r1);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            string str = "Mức lương đang hưởng " + cboKy.Text + " năm " + dupNam.Text;
            e.Graphics.DrawString(str,
                this.DGVLuong.ColumnHeadersDefaultCellStyle.Font,
                new SolidBrush(this.DGVLuong.ColumnHeadersDefaultCellStyle.ForeColor),
                r1,
                format);



            r1 = this.DGVLuong.GetCellDisplayRectangle(11, -1, true);
            r2 = this.DGVLuong.GetCellDisplayRectangle(18, -1, true);
            w2 = this.DGVLuong.GetCellDisplayRectangle(18, -1, true).Width;
            r1.X += 1;
            r1.Y += 1;
            r1.Width = r1.Width + r2.X - r1.X + w2 - 2;
            r1.Height = 30;// r1.Height / 2 - 2;
            e.Graphics.FillRectangle(new SolidBrush(this.DGVLuong.ColumnHeadersDefaultCellStyle.BackColor), r1);


            e.Graphics.DrawString("Kết quả nâng lương",
                this.DGVLuong.ColumnHeadersDefaultCellStyle.Font,
                new SolidBrush(this.DGVLuong.ColumnHeadersDefaultCellStyle.ForeColor),
                r1,
                format);
        }

        private void DGVLuong_Scroll(object sender, ScrollEventArgs e)
        {
            Rectangle rtHeader = this.DGVLuong.DisplayRectangle;
            rtHeader.Height = this.DGVLuong.ColumnHeadersHeight / 2;
            this.DGVLuong.Invalidate(rtHeader);
        }

        private void DGVLuong_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex > -1)
            {
                Rectangle r2 = e.CellBounds;
                r2.Y += e.CellBounds.Height / 2;
                r2.Height = e.CellBounds.Height / 2;

                e.PaintBackground(r2, true);

                e.PaintContent(r2);
                e.Handled = true;
            }
        }

        private void DGVLuong_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            Rectangle rtHeader = this.DGVLuong.DisplayRectangle;
            rtHeader.Height = this.DGVLuong.ColumnHeadersHeight / 2;
            this.DGVLuong.Invalidate(rtHeader);
        }
    }
}
