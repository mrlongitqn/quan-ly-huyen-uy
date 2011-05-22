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
        List<LoaiDonVi> lstLoaiDonVi;
        public FrmDanhMuc()
        {
            DataService.OpenConnection();
            InitializeComponent();
        }

        private string m_tagNode = string.Empty;
        public string TagNode
        {
            get { return m_tagNode; }
            set { m_tagNode = value; }
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
            //    cbPhanLoai.Items.Add(new ListItem(lstItem[i]., lstItem[i].TenDonVi));
            //}
            //if (lstItem.Count>0)
            //    cbPhanLoai.SelectedIndex = 1;
        }
        void loadLoaiDonVi()
        {
            lstLoaiDonVi = LoaiDonViRepository.SelectAll();
            for (int i = 0; i < lstLoaiDonVi.Count; i++)
            {
                cbLoaiDonVi.Items.Add(new ListItem(lstLoaiDonVi[i].MaLoaiDonVi, lstLoaiDonVi[i].TenLoaiDonVi));
            }
            if (lstLoaiDonVi.Count > 0)
                cbLoaiDonVi.SelectedIndex = 1;
        }
        void loadTreeView()
        {
            treeView1.Nodes.Clear();
            TreeNode root = new TreeNode("039 - Đảng bộ Tỉnh Hà Tĩnh");

            treeView1.Nodes.Add(root); // TreeView chi add 1 lan la node goc

            try
            {
                var lstItem = QuanHuyenRepository.SelectByMaTinh("039"); //039--> Hà Tĩnh
                for (int i = 0; i < lstItem.Count; i++)
                {
                    TreeNode huyen = new TreeNode(lstItem[i].MaQuanHuyen + " - Đảnh bộ Huyện " + lstItem[i].TenQuanHuyen);
                    root.Nodes.Add(huyen);

                    var lstItem2 = DonViRepository.SelectByMaQuanHuyen(lstItem[i].MaQuanHuyen);
                    for (int j = 0; j < lstItem2.Count; j++)
                    {
                        try
                        {
                            TreeNode donvi = new TreeNode(lstItem2[j].MaDonVi.Trim() + " - " + lstItem2[j].TenDonVi);
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
            FrmThemLoaiDonVi frm = new FrmThemLoaiDonVi();//FrmLoaiCoSo();
            frm.ShowDialog();
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

            string maQuanHuyen = treeView1.SelectedNode.Text.Split('-')[0].Trim();
            dv.MaQuanHuyen = maQuanHuyen;
            try
            {
                ListItem LoaiDV = (ListItem)cbLoaiDonVi.SelectedItem;
                dv.MaLoaiDonVi = LoaiDV.ID;
            }
            catch (Exception ex)
            {
                
            }

            ListItem PhanLoaiDV = (ListItem)cbPhanLoai.SelectedItem;
            //dv.MaPhanLoaiDonVi = PhanLoaiDV.ID;
            //bool Kq = DonViRepository.Insert(
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null && e.Node.Tag.ToString() != "")
            {
                m_tagNode = e.Node.Tag.ToString();
            }
            
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string maDonVi = treeView1.SelectedNode.Text.Split('-')[0].Trim();
            var DonVi = DonViRepository.SelectByID(maDonVi);

            txtMaDonVi.Text = DonVi.MaDonVi;
            txtTenDonVi.Text = DonVi.TenDonVi;
            cbLoaiDonVi.SelectedValue = DonVi.MaLoaiDonVi;
            for (int i = 0; i < lstLoaiDonVi.Count; i++)
            {
                if (lstLoaiDonVi[i].MaLoaiDonVi == DonVi.MaLoaiDonVi)
                    cbLoaiDonVi.SelectedIndex = i;
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {

        }

    } 
}