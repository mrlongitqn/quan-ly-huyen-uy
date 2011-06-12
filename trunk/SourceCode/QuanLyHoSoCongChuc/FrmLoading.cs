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
    /// <summary>
    /// tuansl added: show loading form when retrieve data
    /// </summary>
    public partial class FrmLoading : DevComponents.DotNetBar.Office2007Form
    {
        public EventHandler Handler { get; set; }

        public FrmLoading(string str)
        {
            InitializeComponent();
            labelX1.Text = str;
        }

        private void FrmLoading_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Handler(this, e);
        }
    }
}