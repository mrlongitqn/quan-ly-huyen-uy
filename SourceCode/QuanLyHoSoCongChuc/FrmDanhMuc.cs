using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using WeifenLuo.WinFormsUI.Docking;
using System.Windows.Forms;
using Microsoft.ReportingServices.Rendering.ImageRenderer;
using Microsoft.Reporting.WinForms;
using DevComponents.DotNetBar;
using QuanLyHoSoCongChuc.BusinessObject;
using QuanLyHoSoCongChuc.Controller;
using QuanLyHoSoCongChuc.DataLayer;


namespace QuanLyHoSoCongChuc.Report
{
    #region Using
    using QuanLyHoSoCongChuc.Models;
    using QuanLyHoSoCongChuc.Repositories;
    #endregion
    public partial class FrmDanhMuc :  DockContent
    {
        NhanVienControl m_NhanVienCtrl = new NhanVienControl();
        public FrmDanhMuc()
        {
            DataService.OpenConnection();
            InitializeComponent();
        }

        private void FrmReportLuong_Load(object sender, EventArgs e)
        {
            loadLoaiDonVi();
            loadPhanLoai();    
            loadTreeView();
            CrBaoCaoLuong rpt = new CrBaoCaoLuong();

            //reportViewerLuong.d = rpt;
            //crystalReportViewer1.Show();
            //reportViewerLuong.Refresh();
        }

        void loadPhanLoai()
        {
            //var lstItem = PhanLoaiDonViRepository.SelectAll();
            //for (int i = 0; i < lstItem.Count; i++)
            //{
            //    cbLoaiDonVi.Items.Add(new ListItem(lstItem[i]., lstItem[i].TenDonVi));
            //}
        }
        void loadLoaiDonVi()
        {
            var lstItem = DonViRepository.SelectAll();
            for (int i = 0; i < lstItem.Count; i++)
            {
                cbLoaiDonVi.Items.Add(new ListItem(lstItem[i].MaDonVi, lstItem[i].TenDonVi));
            }
        }
        void loadTreeView()
        {
            treeView1.Nodes.Clear();
            TreeNode root = new TreeNode("Đảng bộ Tỉnh Hà Tĩnh");

            treeView1.Nodes.Add(root); // TreeView chi add 1 lan la node goc

            try
            {
                var lstItem = QuanHuyenRepository.SelectByMaTinh("039"); //039--> Hà Tĩnh
                for (int i = 0; i < lstItem.Count; i++)
                {
                    TreeNode huyen = new TreeNode("Đảnh bộ Huyện " + lstItem[i].TenQuanHuyen);
                    root.Nodes.Add(huyen);

                    var lstItem2 = DonViRepository.SelectByMaQuanHuyen(lstItem[i].MaQuanHuyen);
                    for (int j = 0; j < lstItem2.Count; j++)
                    {
                        try
                        {
                            TreeNode donvi = new TreeNode(lstItem2[i].MaDonVi + " - " + lstItem2[i].TenDonVi);
                            huyen.Nodes.Add(donvi);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message, ex.InnerException);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            

        }
        private void btnNangLuong_Click(object sender, EventArgs e)
        {
            //this.bindingSourceLuong.DataSource = NhanVienControl.LayDsLuongNhanVien(dtngaynangluong.Value.ToShortDateString());
            //this.reportViewerLuong.RefreshReport();
            //m_NhanVienCtrl.CapNhatCanSu(dtngaynangluong.Value.ToShortDateString());
            //m_NhanVienCtrl.CapNhatChuyenVien(dtngaynangluong.Value.ToShortDateString());
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThemLoaiDonVi_Click(object sender, EventArgs e)
        {
            //FrmLoaiCoSo frm = new FrmLoaiCoSo();
            //frm.ShowDialog();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            string item = treeView1.SelectedNode.Text;
            string[] items = item.Split('-');
            string DonViID = items[0].Trim();

            DonViRepository.Delete(DonViID);
            loadTreeView();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            DonVi dv = new DonVi();
            dv.MaDonVi = txtMaDonVi.Text;
            dv.TenDonVi = txtTenDonVi.Text;

            //dv.MaLoaiDonVi
            //bool Kq = DonViRepository.Insert(
        }
    }
}