using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLyHoSoCongChuc.Danh_muc;
using QuanLyHoSoCongChuc.Utils;
using System.Data.SqlClient;
using System.IO;

namespace QuanLyHoSoCongChuc.Report
{
    #region Using
    using QuanLyHoSoCongChuc.Models;
    using QuanLyHoSoCongChuc.Repositories;
    using DevComponents.DotNetBar;
    #endregion
    public partial class FrmInThe : Form
    {
        // Hidden files are used to store ids 
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaDonVi;

        public FrmInThe()
        {
            InitializeComponent();
            InitHiddenFields();
        }

        /// <summary>
        /// Init hidden fields
        /// </summary>
        public void InitHiddenFields()
        {
            // Add a new textbox
            txtMaDonVi = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaDonVi",
                Text = ""
            };
            txtMaDonVi.Visible = false;
        }

        private void btnChonDonVi_Click(object sender, EventArgs e)
        {
            FrmDanhMuc frm = new FrmDanhMuc(true);
            frm.Handler += GetDonVi;
            frm.ShowDialog();
        }

        public void GetDonVi(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaDonVi.Text = comp[0];
            txtDonVi.Text = comp[1];
            lblSoThe.Text = NhanVienRepository.SelectByMaDonViConSinhHoat(comp[0]).Count.ToString();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btInThe_Click(object sender, EventArgs e)
        {
            if (txtMaDonVi.Text == "")
            {
                MessageBox.Show("Vui lòng chọn đơn vị", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            InTheFrmParent fr = new InTheFrmParent(txtMaDonVi.Text);
            fr.Show();
        }
    }
}
