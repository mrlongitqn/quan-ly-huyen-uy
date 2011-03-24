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

        private void cbo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbo1.SelectedIndex==0)
            {
                txtFrm.Enabled=false;
                txtTo.Enabled=false;
            }
            else
            {
                txtFrm.Enabled=true;
                txtTo.Enabled=true;
            }

        }
    }
}
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
