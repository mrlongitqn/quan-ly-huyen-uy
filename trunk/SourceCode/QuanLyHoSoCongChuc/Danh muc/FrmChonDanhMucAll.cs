using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using QuanLyHoSoCongChuc.Repositories;
using QuanLyHoSoCongChuc.Utils;

namespace QuanLyHoSoCongChuc.Danh_muc
{
    public partial class FrmChonDanhMucAll : DevComponents.DotNetBar.Office2007Form
    {
        private string _maDonVi;
        // tuansl added: event handler to transfer data to other forms
        public EventHandler Handler { get; set; }

        public FrmChonDanhMucAll()
        {
            InitializeComponent();
        }

        private void FrmChonDanhMucAll_Load(object sender, EventArgs e)
        {
            LoadDanhMuc();
        }

        public void LoadDanhMuc()
        {
            treeView1.Nodes.Clear();
            TreeNode root = new TreeNode("Danh mục đơn vị");
            root.ImageIndex = 0;
            treeView1.Nodes.Add(root);

            try
            {
                // Load list all of tinh thanh
                var lstTinhThanh = TinhThanhRepository.SelectAll();
                for (int i = 0; i < lstTinhThanh.Count; i++)
                {
                    var tinhthanh = lstTinhThanh[i];
                    TreeNode tinhthanhnode = new TreeNode(tinhthanh.MaTinh + " - " + tinhthanh.TenTinh);
                    tinhthanhnode.ImageIndex = 1;
                    root.Nodes.Add(tinhthanhnode);

                    // Load quan huyen corresponding with specified tinh thanh
                    var lstQuanHuyen = QuanHuyenRepository.SelectByMaTinh(tinhthanh.MaTinh);
                    for (int j = 0; j < lstQuanHuyen.Count; j++)
                    {
                        var huyen = lstQuanHuyen[j];
                        TreeNode huyennode = new TreeNode(huyen.MaQuanHuyen + " - " + huyen.TenQuanHuyen);
                        huyennode.ImageIndex = 2;
                        tinhthanhnode.Nodes.Add(huyennode);

                        // Load don vi by ma quan huyen
                        var lstDonVi = DonViRepository.SelectByMaQuanHuyen(huyen.MaQuanHuyen);
                        for (int k = 0; k < lstDonVi.Count; k++)
                        {
                            var donvi = lstDonVi[k];
                            TreeNode donvinode = new TreeNode(donvi.MaDonVi + " - " + donvi.TenDonVi);
                            donvinode.ImageIndex = 3;
                            huyennode.Nodes.Add(donvinode);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        private void btChon_Click(object sender, EventArgs e)
        {
            var donvi = DonViRepository.SelectByID(_maDonVi);
            var tendonvidaydu = donvi.TenDonVi + ", huyện " + donvi.QuanHuyen.TenQuanHuyen + ", tỉnh " + donvi.QuanHuyen.TinhThanh.TenTinh;
            TransferDataInfo(this, new MyEvent(_maDonVi + "#" + tendonvidaydu));
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int level = GlobalDanhMucs.GetLevelTreeView(treeView1.SelectedNode);
            if (level == 3)
                btChon.Enabled = true;
            else
                btChon.Enabled = false;

            string maDonVi = treeView1.SelectedNode.Text.Split('-')[0].Trim();
            var DonVi = DonViRepository.SelectByID(maDonVi);
            if (DonVi != null)
                _maDonVi = DonVi.MaDonVi;
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}