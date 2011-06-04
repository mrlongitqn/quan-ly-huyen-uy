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

namespace QuanLyHoSoCongChuc.Danh_muc
{
    #region Using
    using QuanLyHoSoCongChuc.Models;
    using QuanLyHoSoCongChuc.Repositories;
    using QuanLyHoSoCongChuc.OtherForms;
    #endregion
    public partial class FrmDanhMuc : Office2007Form
    {
        NhanVienControl m_NhanVienCtrl = new NhanVienControl();
        public bool EnableButtonChon = false;
        // tuansl added: event handler to transfer data to other forms
        public EventHandler Handler { get; set; }
        // Hidden files are used to store ids 
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaLoaiDonVi;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaPhanLoai;

        public FrmDanhMuc()
        {
            DataService.OpenConnection();
            InitializeComponent();
            btThem.Enabled = false;
            btXoa.Enabled = false;
            btSave.Enabled = false;
            btChon.Enabled = false;
            InitHiddenFields();
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
            if (EnableButtonChon)
                btChon.Visible = true;
            else
                btChon.Visible = false;
        }

        private void init()
        {
            loadTreeView();
        }

        private void loadTreeView()
        {
            treeView1.Nodes.Clear();
            TreeNode root = new TreeNode("039 - Đảng bộ Tỉnh Hà Tĩnh");
            root.ImageIndex = 0;

            treeView1.Nodes.Add(root); // TreeView chi add 1 lan la node goc

            try
            {
                var lstItem = QuanHuyenRepository.SelectByMaTinh("039"); //039--> Hà Tĩnh
                for (int i = 0; i < lstItem.Count; i++)
                {
                    TreeNode huyen = new TreeNode(lstItem[i].MaQuanHuyen + " - Đảnh bộ Huyện " + lstItem[i].TenQuanHuyen);
                    huyen.ImageIndex = 1;
                    root.Nodes.Add(huyen);

                    var lstItem2 = DonViRepository.SelectByMaQuanHuyen(lstItem[i].MaQuanHuyen);
                    for (int j = 0; j < lstItem2.Count; j++)
                    {
                        try
                        {
                            TreeNode donvi = new TreeNode(lstItem2[j].MaDonVi.Trim() + " - " + lstItem2[j].TenDonVi);
                            donvi.ImageIndex = 2;
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
            FrmQuanLyLoaiDonVi frm = new FrmQuanLyLoaiDonVi();//FrmLoaiCoSo();
            frm.Handler += RetrieveLoaiDonVi;
            frm.ShowDialog();
        }

        public void RetrieveLoaiDonVi(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaLoaiDonVi.Text = comp[0];
            txtLoaiDonVi.Text = comp[1];
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            string item = treeView1.SelectedNode.Text;
            string[] items = item.Split('-');
            string DonViID = items[0].Trim();

            bool Kq = DonViRepository.Delete(DonViID);
            if (Kq)
            {
                MessageBox.Show("Xóa đơn vị thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadTreeView();
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtMaDonVi.Text))
            {
                MessageBox.Show("Vui lòng nhập mã đơn vị");
                return;
            }
            if (String.IsNullOrWhiteSpace(txtTenDonVi.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đơn vị");
                return;
            }

            DonVi dv = new DonVi();
            dv.MaDonVi = txtMaDonVi.Text.Trim();
            dv.TenDonVi = txtTenDonVi.Text.Trim();

            string maQuanHuyen = treeView1.SelectedNode.Text.Split('-')[0].Trim();
            dv.MaQuanHuyen = maQuanHuyen;
            dv.MaLoaiDonVi = int.Parse(txtMaLoaiDonVi.Text);
            dv.MaPhanLoaiDonVi = int.Parse(txtMaPhanLoai.Text);

            if (DonViRepository.Insert(dv))
            {
                MessageBox.Show("Thêm 1 đơn vị mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int level = GlobalDanhMucs.GetLevelTreeView(treeView1.SelectedNode);
            if (level == 1 || level == 3)
            {
                btThem.Enabled = false;
            }
            else
            {
                btThem.Enabled = true;
            }

            if (level == 3)
            {
                btChon.Enabled = true;
                btXoa.Enabled = true;
                btSave.Enabled = true;

                string maDonVi = treeView1.SelectedNode.Text.Split('-')[0].Trim();
                var donvi = DonViRepository.SelectByID(maDonVi);
                if (donvi != null)
                {
                    txtMaDonVi.Text = donvi.MaDonVi;
                    txtMaDonVi.ReadOnly = true;
                    txtTenDonVi.Text = donvi.TenDonVi;
                    txtLoaiDonVi.Text = donvi.LoaiDonVi.TenLoaiDonVi;
                    txtMaLoaiDonVi.Text = donvi.MaLoaiDonVi.ToString();
                    txtPhanLoaiDonVi.Text = donvi.PhanLoaiDonVi.TenPhanLoai;
                    txtMaPhanLoai.Text = donvi.MaPhanLoaiDonVi.ToString();
                }
            }
            else {
                btChon.Enabled = false;
                btXoa.Enabled = false;
                btSave.Enabled = false;

                txtMaDonVi.ReadOnly = false;
                txtMaDonVi.Text = "";
                txtTenDonVi.Text = "";
                txtLoaiDonVi.Text = "";
                txtMaLoaiDonVi.Text = "";
                txtPhanLoaiDonVi.Text = "";
                txtMaPhanLoai.Text = "";
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            var dv = DonViRepository.SelectByID(txtMaDonVi.Text);

            dv.TenDonVi = txtTenDonVi.Text;
            dv.MaLoaiDonVi = int.Parse(txtMaLoaiDonVi.Text);
            dv.MaPhanLoaiDonVi = int.Parse(txtMaPhanLoai.Text);

            bool Kq = DonViRepository.Save();
            if (Kq)
            {
                MessageBox.Show("Lưu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadTreeView();
            }
        }

        private void btThemPhanLoai_Click(object sender, EventArgs e)
        {
            FrmQuanLyPhanLoaiDonVi frm = new FrmQuanLyPhanLoaiDonVi();
            frm.Handler += RetrievePhanLoaiDonVi;
            frm.ShowDialog();
        }

        public void RetrievePhanLoaiDonVi(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaPhanLoai.Text = comp[0];
            txtPhanLoaiDonVi.Text = comp[1];
        }

        /// <summary>
        /// tuansl added: raise event when user choose danhmuc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btChon_Click(object sender, EventArgs e)
        {
            var madonvi = txtMaDonVi.Text;
            var donvi = DonViRepository.SelectByID(madonvi);
            var tendonvidaydu = donvi.TenDonVi + ", huyện " + donvi.QuanHuyen.TenQuanHuyen + ", tỉnh " + donvi.QuanHuyen.TinhThanh.TenTinh;
            TransferDataInfo(this, new MyEvent(madonvi + "#" + tendonvidaydu));
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
            this.Close();
        }

        /// <summary>
        /// tuansl added: Init hidden fields to store ids
        /// </summary>
        private void InitHiddenFields()
        {
            // Add a new textbox
            txtMaLoaiDonVi = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaLoaiDonVi"
            };
            txtMaLoaiDonVi.Visible = false;

            // Add a new textbox
            txtMaPhanLoai = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaPhanLoai"
            };
            txtMaPhanLoai.Visible = false;
        }
    } 
}