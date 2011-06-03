using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace QuanLyHoSoCongChuc
{
    public partial class FrmLoading : DevComponents.DotNetBar.Office2007Form
    {
        public FrmLoading(string str)
        {
            InitializeComponent();
            labelX1.Text = str;
        }
    }
}