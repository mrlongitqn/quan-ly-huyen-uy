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
    public partial class FrmDanhSachNangLuong : Form
    {
        public FrmDanhSachNangLuong()
        {
            InitializeComponent();
        }

        private void FrmDanhSachNangLuong_Load(object sender, EventArgs e)
        {
            loadDonVi();
            loadNam();
            cboKy.SelectedIndex = 0;
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
        void loadNam()
        {
            for (int i = 0; i < 100; i++)
            {
                dupNam.Items.Add(1950+i);
            }
            cbDonVi.SelectedIndex = 50;
        }

        private void btInBieu_Click(object sender, EventArgs e)
        {
            String strDt = cboKy.Text + " năm " + dupNam.Text;
            ListItem DV = (ListItem)cbDonVi.SelectedItem;

            FrmPrintReport frm = new FrmPrintReport("2", DV.ID, strDt);
            frm.Show();
        }
    }
}
