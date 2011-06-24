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
using System.IO;

namespace QuanLyHoSoCongChuc.Report
{
    #region Using
    using QuanLyHoSoCongChuc.Models;
    using QuanLyHoSoCongChuc.Repositories;
    #endregion
    public partial class FrmInThe : Form
    {
        String SelectedId;
        int Level;
        DataService dataService = new DataService();
        public FrmInThe()
        {
            InitializeComponent();
        }

        private void FrmBaoCaoLuong_Load(object sender, EventArgs e)
        {
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
            loadDSNhanVien();
        }
        private void loadDSNhanVien()
        {
            String sql = " select * from NhanVien nv ";
            sql += " join DonVi dv on nv.MaDonVi = dv.MaDonVi";
            sql += " left join ChucVu cv on cv.MaChucVu = nv.MaChucVu";
            sql += " where 1=1";
            sql += LoadSql_MaDonVi();

            SqlCommand cmd = new SqlCommand(sql);
            DataService.OpenConnection();
            dataService.Load(cmd);
            DataTable myDt = dataService;
            for (int r = 0; r < myDt.Rows.Count; r++)
            {
                cbNhanVien.Items.Add(new ListItem(myDt.Rows[r]["MaNhanVien"].ToString(), myDt.Rows[r]["HoTenKhaiSinh"].ToString()));
            }
            lblSumThe.Text = "Tổng số: " + myDt.Rows.Count + " thẻ";
        }
        private void loadThongTinNhanVien(string MaNV)
        {
            String sql = " select * from NhanVien nv ";
            sql += " left join ChucVu cv on cv.MaChucVu = nv.MaChucVu";
            sql += " where MaNhanVien='" + MaNV + "'";
            SqlCommand cmd = new SqlCommand(sql);
            dataService.Load(cmd);
            DataTable myDt = dataService;

            txtIDCongChuc.Text = myDt.Rows[0]["MaNhanVien"].ToString();
            txtHoTen.Text = myDt.Rows[0]["HoTenKhaiSinh"].ToString();
            txtChucVu.Text = myDt.Rows[0]["TenChucVu"].ToString();
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
        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maNV = ((ListItem)cbNhanVien.SelectedItem).ID ;
            if(maNV!="")
                loadThongTinNhanVien(maNV);
        }

        private void btInThe_Click(object sender, EventArgs e)
        {
            CrInThe rpt = new CrInThe();
            rpt.SetDataSource(dataService);

            DSBaoCao1 myDS = new DSBaoCao1();
            DataTable myDt = dataService;
            myDS.Tables.Add(myDt);
            for (int i = 0; i < myDt.Rows.Count; i++)
            {
                DataRow myRow = dsBaoCao1.Tables["InThe"].NewRow();
                myRow["STT"] = i + 1;
                myRow["MaNhanVien"] = myDt.Rows[i]["MaNhanVien"];
                myRow["HoTenNhanVien"] = myDt.Rows[i]["HoTenKhaiSinh"];
                myRow["PhongBan"] = "PhongBan";
                myRow["ChucVu"] = myDt.Rows[i]["TenChucVu"];
                myRow["SoHieuCongChuc"] = "SoHieuCongChuc";

                dsBaoCao1.Tables["InThe"].Rows.Add(myRow);
            }
            rpt.SetDataSource(dsBaoCao1.Tables["InThe"]);
            rpt.DataDefinition.FormulaFields["UBND Tinh"].Text = "'" + txtUBNDT.Text + "'";
            rpt.DataDefinition.FormulaFields["UBND Huyen"].Text = "'" + txtUBNDH.Text + "'";
            this.crystalReportViewer1.ReportSource = rpt;
        }
        private void BindReport(String imagePath)
        {
            imagePath = Application.StartupPath + "\\img\\" + imagePath;
            //LoadImage(this.myDS1.Tables["InThe"].Rows[0], "LogoImage", imagePath);
        }
        private void LoadImage(DataRow objDataRow, string strImageField, string FilePath)
        {
            try
            {
                FileStream fs = new FileStream(FilePath, System.IO.FileMode.Open,
                System.IO.FileAccess.Read);
                byte[] Image = new byte[fs.Length];
                fs.Read(Image, 0, Convert.ToInt32(fs.Length));
                fs.Close();
                objDataRow[strImageField] = Image;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No image valid!");
            }
        }
    }
}
