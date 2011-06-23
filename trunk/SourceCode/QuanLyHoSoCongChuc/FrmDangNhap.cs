using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using QuanLyHoSoCongChuc.BusinessObject;
using QuanLyHoSoCongChuc.Controller;
using System.Data.SqlClient;
using DevComponents.DotNetBar;
using QuanLyHoSoCongChuc.Utils;

namespace QuanLyHoSoCongChuc
{
    public partial class FrmDangNhap : Office2007Form
    {
        public EventHandler Handler { get; set; }
        public bool pressOk = false;

        public FrmDangNhap()
        {
            InitializeComponent();
        }

        //Click dang nhap
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            pressOk = true;
            this.Close();
            this.Handler(this, new MyEvent(txtUsername.Text.Trim() + "#" + txtPassword.Text.Trim()));
        }

        //Click thoat
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!pressOk)
            {
                Application.Exit();
            }
        }
    }
}