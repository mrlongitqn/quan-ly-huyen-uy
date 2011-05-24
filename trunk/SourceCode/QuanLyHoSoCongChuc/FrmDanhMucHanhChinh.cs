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
    #region Using
    using QuanLyHoSoCongChuc.Models;
    using QuanLyHoSoCongChuc.Repositories;
    #endregion
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

        private void treeviewDMHC_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int level = getLevelTreeView(treeviewDMHC.SelectedNode);
            if (level == 1) // root
            {
            }
            else if (level == 2) //Huyen
            {
                String MaHuyen = (String)treeviewDMHC.SelectedNode.Tag;
                var quanhuyen = QuanHuyenRepository.SelectByID(MaHuyen);
                txtMaDiaDanh.Text = quanhuyen.MaQuanHuyen;
                txtTenDiaDanh.Text = quanhuyen.TenQuanHuyen;
                txtTenDayDu.Text = "Huyện " + quanhuyen.TenQuanHuyen + " - Tỉnh Hà Tĩnh";
            }
            else if (level == 3) //Xã
            {
                String MaXa = (String)treeviewDMHC.SelectedNode.Tag;
                var xa = PhuongXaRepository.SelectByID(MaXa);
                txtMaDiaDanh.Text = xa.MaPhuongXa;
                txtTenDiaDanh.Text = xa.TenPhuongXa;
                txtTenDayDu.Text = "Xã " + xa.TenPhuongXa + " - Huyện " + QuanHuyenRepository.SelectByID(xa.MaQuanHuyen).TenQuanHuyen + " - Tỉnh Hà Tĩnh";
            }
            else if (level == 4) //Thôn
            {
                String MaThon = (String)treeviewDMHC.SelectedNode.Tag;
                var thon = KhoiXomRepository.SelectByID(MaThon);
                txtMaDiaDanh.Text = thon.MaKhoiXom;
                txtTenDiaDanh.Text = thon.TenKhoiXom;
                txtTenDayDu.Text = "Thôn " + thon.TenKhoiXom + " - Xã " + PhuongXaRepository.SelectByID(thon.MaPhuongXa).TenPhuongXa + " - Huyện " + QuanHuyenRepository.SelectByID(PhuongXaRepository.SelectByID(thon.MaPhuongXa).MaQuanHuyen).TenQuanHuyen + " - Tỉnh Hà Tĩnh";
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
                else
                {
                    if (node.Parent.Parent.Parent == null)
                        return 3;
                    else
                    {
                        if (node.Parent.Parent.Parent.Parent == null)
                            return 4;
                    }
                }
            }
            return -1;
        }
    }
}
