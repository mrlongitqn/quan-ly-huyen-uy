using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using QuanLyHoSoCongChuc.Models;

namespace QuanLyHoSoCongChuc.NhanVienManager
{
    /// <summary>
    /// tuansl added: manage progress of nhanvien
    /// </summary>
    public partial class FrmThongTinNhanVien_CacQuaTrinh : DevComponents.DotNetBar.Office2007Form
    {
        /// <summary>
        /// Enum to determine which functionality is activated
        /// </summary>
        private enum EnumCacQuaTrinh
        {
            QUATRINHCONGTAC,
            QUATRINHDAOTAO,
            KHENTHUONG,
            KYLUAT,
            GIADINH
        }
        private NhanVien _nhanvien;
        private Color imgCurrentNavImage;

        public FrmThongTinNhanVien_CacQuaTrinh(NhanVien nhanvien)
        {
            InitializeComponent();
            _nhanvien = nhanvien;
            InitForm();
        }

        public void InitForm()
        {
            lblQuaTrinhCongTac.MouseEnter += new EventHandler(NavigationChildControl_MouseEnter);
            lblQuaTrinhCongTac.MouseLeave += new EventHandler(NavigationChildControl_MouseLeave);
            lblQuaTrinhCongTac.MouseUp += new MouseEventHandler(NavigationChildControl_MouseUp);

            lblQuaTrinhDaoTao.MouseEnter += new EventHandler(NavigationChildControl_MouseEnter);
            lblQuaTrinhDaoTao.MouseLeave += new EventHandler(NavigationChildControl_MouseLeave);
            lblQuaTrinhDaoTao.MouseUp += new MouseEventHandler(NavigationChildControl_MouseUp);

            lblKhenThuong.MouseEnter += new EventHandler(NavigationChildControl_MouseEnter);
            lblKhenThuong.MouseLeave += new EventHandler(NavigationChildControl_MouseLeave);
            lblKhenThuong.MouseUp += new MouseEventHandler(NavigationChildControl_MouseUp);

            lblKyLuat.MouseEnter += new EventHandler(NavigationChildControl_MouseEnter);
            lblKyLuat.MouseLeave += new EventHandler(NavigationChildControl_MouseLeave);
            lblKyLuat.MouseUp += new MouseEventHandler(NavigationChildControl_MouseUp);

            lblHuyHieuDang.MouseEnter += new EventHandler(NavigationChildControl_MouseEnter);
            lblHuyHieuDang.MouseLeave += new EventHandler(NavigationChildControl_MouseLeave);
            lblHuyHieuDang.MouseUp += new MouseEventHandler(NavigationChildControl_MouseUp);
        }

        private void NavigationChildControl_MouseEnter(Object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(LabelX))
            {
                imgCurrentNavImage = ((LabelX)sender).ForeColor;
                if (((LabelX)sender).ForeColor != Color.Crimson)
                {
                    ((LabelX)sender).ForeColor = Color.Crimson;
                }
                ((LabelX)sender).Cursor = Cursors.Hand;
            }
        }

        private void NavigationChildControl_MouseLeave(Object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(LabelX))
            {
                ((LabelX)sender).ForeColor = imgCurrentNavImage;
                ((LabelX)sender).Cursor = Cursors.Default;
            }
        }

        private void NavigationChildControl_MouseUp(Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (sender.GetType() == typeof(LabelX))
            {
                imgCurrentNavImage = Color.Crimson;
                ((LabelX)sender).ForeColor = Color.Crimson;
                Navigate(((LabelX)sender).Name);
            }
        }

        private void Navigate(string Shortcut)
        {
            foreach (Control objControl in pnlChucNang.Controls)
            {
                if (objControl.GetType() == typeof(LabelX))
                {
                    switch (objControl.Name)
                    {
                        case "lblQuaTrinhCongTac":
                            if (Shortcut == "lblQuaTrinhCongTac")
                            {
                                objControl.ForeColor = Color.Crimson;
                            }
                            else
                            {
                                objControl.ForeColor = SystemColors.ControlText;
                            }
                            break;

                        case "lblQuaTrinhDaoTao":
                            if (Shortcut == "lblQuaTrinhDaoTao")
                            {
                                objControl.ForeColor = Color.Crimson;
                            }
                            else
                            {
                                objControl.ForeColor = SystemColors.ControlText;
                            }
                            break;

                        case "lblKhenThuong":
                            if (Shortcut == "lblKhenThuong")
                            {
                                objControl.ForeColor = Color.Crimson;
                            }
                            else
                            {
                                objControl.ForeColor = SystemColors.ControlText;
                            }
                            break;

                        case "lblKyLuat":
                            if (Shortcut == "lblKyLuat")
                            {
                                objControl.ForeColor = Color.Crimson;
                            }
                            else
                            {
                                objControl.ForeColor = SystemColors.ControlText;
                            }
                            break;

                        case "lblHuyHieuDang":
                            if (Shortcut == "lblHuyHieuDang")
                            {
                                objControl.ForeColor = Color.Crimson;
                            }
                            else
                            {
                                objControl.ForeColor = SystemColors.ControlText;
                            }
                            break;
                    }
                }
            }
        }
    }
}