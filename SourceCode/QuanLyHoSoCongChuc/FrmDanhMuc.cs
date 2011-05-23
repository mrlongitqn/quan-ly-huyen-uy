using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using WeifenLuo.WinFormsUI.Docking;
using System.Windows.Forms;
using System.Reflection;
using Microsoft.ReportingServices.Rendering.ImageRenderer;
using Microsoft.Reporting.WinForms;
using DevComponents.DotNetBar;
using QuanLyHoSoCongChuc.BusinessObject;
using QuanLyHoSoCongChuc.Controller;
using QuanLyHoSoCongChuc.DataLayer;
using QuanLyHoSoCongChuc.Utils;

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
        List<PhanLoaiDonVi> lstPhanLoai;
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
            init();
            CrBaoCaoLuong rpt = new CrBaoCaoLuong();

            //reportViewerLuong.d = rpt;
            //crystalReportViewer1.Show();
            //reportViewerLuong.Refresh();
        }
        void init()
        {
            loadLoaiDonVi();
            loadPhanLoai();
            loadTreeView();
        }
        void loadPhanLoai()
        {
            lstPhanLoai = PhanLoaiDonViRepository.SelectAll();
            for (int i = 0; i < lstPhanLoai.Count; i++)
            {
                cbPhanLoai.Items.Add(new ListItem(lstPhanLoai[i].MaPhanLoai, lstPhanLoai[i].TenPhanLoai));
            }
            if (lstPhanLoai.Count > 0)
                cbPhanLoai.SelectedIndex = 0;
        }
        void loadLoaiDonVi()
        {
            lstLoaiDonVi = LoaiDonViRepository.SelectAll();
            for (int i = 0; i < lstLoaiDonVi.Count; i++)
            {
                cbLoaiDonVi.Items.Add(new ListItem(lstLoaiDonVi[i].MaLoaiDonVi, lstLoaiDonVi[i].TenLoaiDonVi));
            }
            if (lstLoaiDonVi.Count > 0)
                cbLoaiDonVi.SelectedIndex = 0;
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

            bool Kq = DonViRepository.Delete(DonViID);
            if (Kq)
            {
                MessageBox.Show("Xóa đơn vị thành công.");
                loadTreeView();
            }
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
            dv.MaPhanLoaiDonVi = PhanLoaiDV.ID;
            bool Kq = DonViRepository.Insert(dv);
            if (Kq)
            {
                MessageBox.Show("Thêm 1 đơn vị mới thành công.");
                loadTreeView();
            }
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
            int level = getLevelTreeView(treeView1.SelectedNode);
            if (level == 1 || level == 3)
            {
                btThem.Enabled = false;
                btXoa.Enabled = false;
                btSave.Enabled = false;
            }
            else
            {
                btThem.Enabled = true;
                btXoa.Enabled = true;
                btSave.Enabled = true;
            }
            if (level == 3)
            {
                btChon.Enabled = true;
            }
            else {
                btChon.Enabled = false;
            }
            string maDonVi = treeView1.SelectedNode.Text.Split('-')[0].Trim();
            var DonVi = DonViRepository.SelectByID(maDonVi);
            if (DonVi != null) 
            {
                txtMaDonVi.Text = DonVi.MaDonVi;
                txtTenDonVi.Text = DonVi.TenDonVi;

                for (int i = 0; i < lstLoaiDonVi.Count; i++)
                {
                    if (lstLoaiDonVi[i].MaLoaiDonVi == DonVi.MaLoaiDonVi)
                        cbLoaiDonVi.SelectedIndex = i;
                }
                for (int i = 0; i < lstPhanLoai.Count; i++)
                {
                    if (lstPhanLoai[i].MaPhanLoai == DonVi.MaPhanLoaiDonVi)
                        cbPhanLoai.SelectedIndex = i;
                }
            }
            
        }

        private int getLevelTreeView(TreeNode node)
        {
            if (node.Parent == null)
                return 1; // Node cha
            else
            {
                if (node.Parent.Parent == null)
                    return 2;
                else { 
                    if (node.Parent.Parent.Parent == null)
                        return 3;
                }
            }
            return -1;
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            var dv = DonViRepository.SelectByID( txtMaDonVi.Text);
            
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
            dv.MaPhanLoaiDonVi = PhanLoaiDV.ID;
            bool Kq = DonViRepository.Save();
            if (Kq)
            {
                MessageBox.Show("Lưu thành công.");
                loadTreeView();
            }
        }

        private void cbPhanLoai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btThemPhanLoai_Click(object sender, EventArgs e)
        {
            FrmThemPhanLoaiDonVi frm = new FrmThemPhanLoaiDonVi();
            frm.HandleExitForm += ShowMe;
            frm.ShowDialog();
        }

        //Process change forms screen
        public void ShowMe(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string ErrorText = "";
            switch (eventType.Data)
            {
                case MyEnum.ADD_CONTACT:
                case MyEnum.EDIT_CONTACT:
                case MyEnum.DELETE_CONTACT:
                    //LoadData(ref ErrorText);
                    break;

                case MyEnum.DEFAULT:
                    break;
            }
            Show();
        }
    } 
}