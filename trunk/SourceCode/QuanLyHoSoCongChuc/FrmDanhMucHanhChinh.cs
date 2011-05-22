using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using WeifenLuo.WinFormsUI.Docking;
using QuanLyHoSoCongChuc.BusinessObject;
using QuanLyHoSoCongChuc.DataLayer;
using QuanLyHoSoCongChuc.Controller;

namespace QuanLyHoSoCongChuc
{
    public partial class FrmDanhMucHanhChinh : Office2007Form
    {
        DanhMucHanhChinhControl m_DanhMucHanhChinhControl = new DanhMucHanhChinhControl();
        public FrmNhanVien frmNhanVien;

        public FrmDanhMucHanhChinh()
        {
            InitializeComponent();
        }

        
        private string m_tagNode = string.Empty;

        public string TagNode
        {
            get { return m_tagNode; }
            set { m_tagNode = value; }
        }
        
        private void FrmDanhMucHanhChinh_Load(object sender, EventArgs e)
        {
            DataService.OpenConnection();
            m_DanhMucHanhChinhControl.HienThiTreeView(treeviewDMHC);
        }

        private void trvDanhMucHanhChinh_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null && e.Node.Tag.ToString() != "")
            {
                m_tagNode = e.Node.Tag.ToString();
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            this.Close();
            frmNhanVien.m_txtQueQuan.Text = m_tagNode;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FrmThemDanhMucHanhChinh frmThemDanhMucHanhChinh = new FrmThemDanhMucHanhChinh();
            frmThemDanhMucHanhChinh.Show();
        }        
    }
}
