using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using QuanLyHoSoCongChuc.Utils;
using WeifenLuo.WinFormsUI.Docking;

namespace QuanLyHoSoCongChuc.Search
{
    /// <summary>
    /// tuansl added: store user query in file
    /// </summary>
    public partial class FrmInDSNhanVienParent : DockContent
    {
        public FrmInDSNhanVienParent(ListView _lstvNhanVien)
        {
            InitializeComponent();

            FrmInDSNhanVien ChildForm = new FrmInDSNhanVien(_lstvNhanVien);
            ChildForm.MdiParent = this;
            ChildForm.Show();
        }
    }
}