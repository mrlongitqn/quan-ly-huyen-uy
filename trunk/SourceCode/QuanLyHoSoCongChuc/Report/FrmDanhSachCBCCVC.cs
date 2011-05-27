using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyHoSoCongChuc.Report
{
    #region Using
    using QuanLyHoSoCongChuc.Models;
    using QuanLyHoSoCongChuc.Repositories;
    #endregion
    public partial class FrmDanhSachCBCCVC : Form
    {
        public FrmDanhSachCBCCVC()
        {
            InitializeComponent();
        }

        private void FrmDanhSachCBCCVC_Load(object sender, EventArgs e)
        {
            loadDonVi();
            cbDoiTuong.SelectedIndex = 0;
            cbKy.SelectedIndex = 0;
        }
        void loadDonVi()
        {
            var lstDonVi = DonViRepository.SelectAll();
            for (int i = 0; i < lstDonVi.Count; i++)
            {
                cbDonVi.Items.Add(new ListItem(lstDonVi[i].MaDonVi, lstDonVi[i].TenDonVi));
            }
            if (lstDonVi.Count > 0)
                cbDonVi.SelectedIndex = 0;
        }

        private void btInBieu_Click(object sender, EventArgs e)
        {
            ListItem DV = (ListItem)cbDonVi.SelectedItem;

            FrmPrintReport frm = new FrmPrintReport(4, DV.ID, "");
            frm.Show();
        }
    }
}
