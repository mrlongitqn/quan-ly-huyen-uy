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
using QuanLyHoSoCongChuc.Repositories;
using QuanLyHoSoCongChuc.Models;

namespace QuanLyHoSoCongChuc.Danh_muc
{
    public enum EnumDiaDanh
    {
        TINHTHANH,
        QUANHUYEN,
        PHUONGXA
    }

    public partial class FrmDanhMucHanhChinh : Office2007Form
    {
        // tuansl added: event handler to transfer data to other forms
        public EventHandler Handler { get; set; }
        private EnumDiaDanh ModeDiaDanh;
        public bool EnableButtonChon = false;

        public FrmDanhMucHanhChinh()
        {
            InitializeComponent();
        }

        public FrmDanhMucHanhChinh(bool enableChon)
        {
            InitializeComponent();
            EnableButtonChon = enableChon;
        }

        private void FrmDanhMucHanhChinh_Load(object sender, EventArgs e)
        {
            // Show waiting form
            GlobalVars.PreLoading();
            //------- E ---------

            if (EnableButtonChon)
                btnChon.Visible = true;
            else
                btnChon.Visible = false;
            
            LoadDanhMucHanhChinh();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FrmThemDanhMucHanhChinh frm = new FrmThemDanhMucHanhChinh();
            frm.Handler += GetUpdateState; 
            frm.ShowDialog();
        }

        /// <summary>
        /// Re-load danh muc hanh chinh after execute updating
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GetUpdateState(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            var data = eventType.Data;
            if (data == "true")
            {
                LoadDanhMucHanhChinh();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var errorText = "";
            if (!ValidateInput(EnumUpdateMode.DELETE, ref errorText))
            {
                MessageBox.Show(errorText, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool updated = false;
            switch (ModeDiaDanh)
            {
                case EnumDiaDanh.TINHTHANH:
                    updated = TinhThanhRepository.Delete(txtMaDiaDanh.Text.Trim());
                    break;
                    
                case EnumDiaDanh.QUANHUYEN:
                    updated = QuanHuyenRepository.Delete(txtMaDiaDanh.Text.Trim());
                    break;

                case EnumDiaDanh.PHUONGXA:
                    updated = PhuongXaRepository.Delete(txtMaDiaDanh.Text.Trim());
                    break;
            }
            if (updated)
            {
                MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhMucHanhChinh();
            }
            else
            {
                MessageBox.Show("Cập nhật dữ liệu thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            var errorText = "";
            if (!ValidateInput(EnumUpdateMode.DELETE, ref errorText))
            {
                MessageBox.Show(errorText, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool updated = false;
            switch (ModeDiaDanh)
            {
                case EnumDiaDanh.TINHTHANH:
                    var tinhthanh = TinhThanhRepository.SelectByID(txtMaDiaDanh.Text.Trim());
                    tinhthanh.TenTinh = txtTenDiaDanh.Text.Trim();
                    updated = TinhThanhRepository.Save();
                    break;

                case EnumDiaDanh.QUANHUYEN:
                    var quanhuyen = QuanHuyenRepository.SelectByID(txtMaDiaDanh.Text.Trim());
                    quanhuyen.TenQuanHuyen = txtTenDiaDanh.Text.Trim();
                    updated = TinhThanhRepository.Save();
                    break;

                case EnumDiaDanh.PHUONGXA:
                    var phuongxa = PhuongXaRepository.SelectByID(txtMaDiaDanh.Text.Trim());
                    phuongxa.TenPhuongXa = txtTenDiaDanh.Text.Trim();
                    updated = TinhThanhRepository.Save();
                    break;
            }
            if (updated)
            {
                MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhMucHanhChinh();
            }
            else
            {
                MessageBox.Show("Cập nhật dữ liệu thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void treeviewDMHC_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int level = GlobalDanhMucs.GetLevelTreeView(treeviewDMHC.SelectedNode);
            if (level == 1)
            {
                btnChon.Enabled = false;
                return;
            }
            var comp = treeviewDMHC.SelectedNode.Text.Split(new char[] { '-' });
            var madiadanh = comp[0].Trim();
            var tendiadanh = comp[1].Trim();

            txtMaDiaDanh.Text = madiadanh;
            txtTenDiaDanh.Text = tendiadanh;

            if (level == 2)
            {
                txtTenDayDu.Text = tendiadanh;
                btnChon.Enabled = false;
                ModeDiaDanh = EnumDiaDanh.TINHTHANH;
            }
            else if (level == 3)
            {
                var quanhuyen = QuanHuyenRepository.SelectByID(madiadanh);
                txtTenDayDu.Text = quanhuyen.TenQuanHuyen + ", " + quanhuyen.TinhThanh.TenTinh;
                btnChon.Enabled = false;
                ModeDiaDanh = EnumDiaDanh.QUANHUYEN;
            }
            else if (level == 4)
            {
                var phuongxa = PhuongXaRepository.SelectByID(madiadanh);
                txtTenDayDu.Text = phuongxa.TenPhuongXa + ", " + phuongxa.QuanHuyen.TenQuanHuyen + ", " + phuongxa.QuanHuyen.TinhThanh.TenTinh;
                btnChon.Enabled = true;
                ModeDiaDanh = EnumDiaDanh.PHUONGXA;
            } 
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            var madiadanh = txtMaDiaDanh.Text;
            var tendonvidaydu = txtTenDayDu.Text;
            TransferDataInfo(this, new MyEvent(madiadanh + "#" + tendonvidaydu));
        }

        /// <summary>
        /// Validate user input
        /// </summary>
        /// <param name="isUpdate"></param>
        /// <returns></returns>
        private bool ValidateInput(EnumUpdateMode mode, ref string errorText)
        {
            // Mode update -> checking MaChucNang is exists on textbox
            if (mode == EnumUpdateMode.UPDATE || mode == EnumUpdateMode.DELETE)
            {
                if (txtMaDiaDanh.Text == "")
                {
                    errorText = "Vui lòng chọn địa danh";
                    return false;
                }
            }
            if (mode != EnumUpdateMode.DELETE)
            {
                if (txtTenDiaDanh.Text == "")
                {
                    errorText = "Vui lòng nhập tên địa danh";
                    return false;
                }
            }

            return true;
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

        /// <summary>
        /// Load danh muc hanh chinh from DB
        /// </summary>
        private void LoadDanhMucHanhChinh()
        {
            treeviewDMHC.Nodes.Clear();
            TreeNode root = new TreeNode("Danh mục hành chính");
            root.ImageIndex = 0;
            treeviewDMHC.Nodes.Add(root);

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

                        // Load phuong xa corresponding with specified quan huyen
                        var lstPhuongXa = PhuongXaRepository.SelectByMaQuanHuyen(huyen.MaQuanHuyen);
                        for (int k = 0; k < lstPhuongXa.Count; k++)
                        {
                            var phuongxa = lstPhuongXa[k];
                            TreeNode phuongxanode = new TreeNode(phuongxa.MaPhuongXa + " - " + phuongxa.TenPhuongXa);
                            phuongxanode.ImageIndex = 3;
                            huyennode.Nodes.Add(phuongxanode);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        private void FrmDanhMucHanhChinh_Shown(object sender, EventArgs e)
        {
            // Hide waiting form
            GlobalVars.PosLoading();
            //------- E ---------
        }
    }
}
