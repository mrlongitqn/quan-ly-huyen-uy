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
    public partial class FrmReportLuong2 :  DockContent
    {
        NhanVienControl m_NhanVienCtrl = new NhanVienControl();
        public FrmReportLuong2()
        {
            DataService.OpenConnection();
            InitializeComponent();
        }

        private void FrmReportLuong_Load(object sender, EventArgs e)
        {
            CrBaoCaoLuong rpt = new CrBaoCaoLuong();
            //reportViewerLuong.d = rpt;
            //crystalReportViewer1.Show();
            //reportViewerLuong.Refresh();
        }

        void loadTreeView()
        {
            treeView1.Nodes.Clear();
            QLHSCC_DataContextDataContext data = new QLHSCC_DataContextDataContext();
            var quanhuyen = from q in data.QuanHuyens
                            select q;
            foreach (QuanHuyen qh in quanhuyen)
            {
                TreeNode tnParent = new TreeNode();
                tnParent.Text = qh.TenQuanHuyen;
                tnParent.Value = qh.MaQuanHuyen;
                tnParent.PopulateOnDemand = true;
                tnParent.ToolTip = "Click to get Child";
                tnParent.SelectAction = TreeNodeSelectAction.SelectExpand;
                tnParent.Expand();
                tnParent.Selected = true;
                treeView1.Nodes.Add(tnParent);
                FillChild(tnParent, tnParent.Value);


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
    }
}