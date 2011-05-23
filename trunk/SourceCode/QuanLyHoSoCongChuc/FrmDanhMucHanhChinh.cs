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
using QuanLyHoSoCongChuc.Utils;

namespace QuanLyHoSoCongChuc
{
    public partial class FrmDanhMucHanhChinh : Office2007Form
    {
        DanhMucHanhChinhControl m_DanhMucHanhChinhControl = new DanhMucHanhChinhControl();
        public FrmNhanVien frmNhanVien;
        // tuansl added: event handler to transfer data to other forms
        public EventHandler Handler { get; set; }

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

        private void btnThem_Click(object sender, EventArgs e)
        {
            FrmThemDanhMucHanhChinh frmThemDanhMucHanhChinh = new FrmThemDanhMucHanhChinh();
            frmThemDanhMucHanhChinh.Show();
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            //var xa = txtMaDonVi.Text;
            //var donvi = DonViRepository.SelectByID(madonvi);
            //var tendonvidaydu = donvi.TenDonVi + ", huyện " + donvi.QuanHuyen.TenQuanHuyen + ", tỉnh " + donvi.QuanHuyen.TinhThanh.TenTinh;
            //TransferDataInfo(this, new MyEvent(madonvi + "#" + tendonvidaydu));
        }

        /// <summary>
        /// tuansl added: function is used to transfer data when event would be raised
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TransferDataInfo(object sender, MyEvent e)
        {
            this.Close();
            this.Handler(this, e);
        }
    }
}
