using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLyHoSoCongChuc.BusinessObject;
using QuanLyHoSoCongChuc.Controller;
using QuanLyHoSoCongChuc.DataLayer;


namespace QuanLyHoSoCongChuc
{
    public partial class FrmTimKiem2 : Form
    {
        NhanVienControl m_NhanVienControl = new NhanVienControl();
        public FrmTimKiem2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataService.OpenConnection();
            m_NhanVienControl.TimKiem(DGVLuong, cbo1.SelectedIndex, txtFrm.Text, txtTo.Text);
        }
    }
}
