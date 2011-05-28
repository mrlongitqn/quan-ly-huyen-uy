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
    public partial class FrmBaoCaoLuong : Form
    {
        public FrmBaoCaoLuong()
        {
            InitializeComponent();
        }

        private void FrmBaoCaoLuong_Load(object sender, EventArgs e)
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
            DateTime dt = dtNgay.Value;
            String strDt = dt.ToString("dd/MM/yyyy");
            ListItem DV = (ListItem)cbDonVi.SelectedItem;
            int type = cbDoiTuong.SelectedIndex;

            FrmPrintReport frm = new FrmPrintReport("1-"+type.ToString(), DV.ID, strDt);
            frm.Show();
        }

        private void btBaoBieu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chua lam xong");
        }
    }
}
