using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using QuanLyHoSoCongChuc.Utils;

namespace QuanLyHoSoCongChuc.UsersDiary
{
    /// <summary>
    /// tuansl added: form is used to manage user diary
    /// </summary>
    public partial class FrmNhatKySuDung : DevComponents.DotNetBar.Office2007Form
    {
        private DanhSachNhatKySuDung lstUserDaries = new DanhSachNhatKySuDung();
        public FrmNhatKySuDung()
        {
            InitializeComponent();
        }

        private void FrmNhatKySuDung_Load(object sender, EventArgs e)
        {
            if (LoadUserDiary(GlobalVars.g_strPathNhatKi))
            {
                try
                {
                    var count = 1;
                    lstvNhatKySuDung.Items.Clear();
                    for (int i = 0; i < lstUserDaries.LstNhatKyNguoiDung.Count; i++)
                    {
                        // Get user
                        var nguoidung = lstUserDaries.LstNhatKyNguoiDung[i];
                        for (int j = 0; j < nguoidung.LstNhatkySuDung.Count; j++)
                        {
                            // Get nhatkysudung of user
                            var nhatkysudung = nguoidung.LstNhatkySuDung[j];
                            var objListViewItem = new ListViewItem();
                            objListViewItem.Tag = nguoidung.TenTruyCap + "-" + nhatkysudung.ThoiDiemVao;
                            objListViewItem.Text = count.ToString();
                            objListViewItem.SubItems.Add(nguoidung.TenTruyCap);
                            objListViewItem.SubItems.Add(String.Format("{0:dd/MM/yyyy HH:mm:ss}", nhatkysudung.ThoiDiemVao));
                            objListViewItem.SubItems.Add(String.Format("{0:dd/MM/yyyy HH:mm:ss}", nhatkysudung.ThoiDiemRa));
                            objListViewItem.SubItems.Add(nhatkysudung.TenMayTram);
                            lstvNhatKySuDung.Items.Add(objListViewItem);
                            count++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }
        }

        private void lstvNhatKySuDung_Click(object sender, EventArgs e)
        {
            try
            {
                ListView.SelectedListViewItemCollection lstview = this.lstvNhatKySuDung.SelectedItems;
                if (lstview.Count > 0)
                {
                    // loop for list of used functionalities
                    var count2 = 1;
                    lstvChucNangSuDung.Items.Clear();
                    var nhatkysudung = GetNhatKySuDung(lstview[0].Tag.ToString());
                    for (int k = 0; k < nhatkysudung.LstChucNangSuDung.Count; k++)
                    {
                        var chucnangsudung = nhatkysudung.LstChucNangSuDung[k];
                        var objlistviewitem = new ListViewItem();
                        objlistviewitem.Text = count2.ToString();
                        objlistviewitem.SubItems.Add(chucnangsudung.TenChucNang.ToString());
                        objlistviewitem.SubItems.Add(chucnangsudung.SoLan.ToString());
                        lstvChucNangSuDung.Items.Add(objlistviewitem);
                        count2++;
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Load user diary has been saved in xml file
        /// </summary>
        /// <param name="pathFile"></param>
        /// <returns></returns>
        public bool LoadUserDiary(string pathFile)
        {
            if (lstUserDaries.LoadDiary(pathFile))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Get nhatkysudung base on tentruycap and thoidiemvao
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public NhatKySuDung GetNhatKySuDung(string tag)
        {
            NhatKySuDung nhatkysudung = null;
            string[] comp = tag.Split(new char[] { '-' });
            var tentruycap = comp[0];
            var thoidiemvao = comp[1];
            for (int i = 0; i < lstUserDaries.LstNhatKyNguoiDung.Count; i++)
            {
                if (lstUserDaries.LstNhatKyNguoiDung[i].TenTruyCap == tentruycap)
                {
                    var nguoidung = lstUserDaries.LstNhatKyNguoiDung[i];
                    for (int j = 0; j < nguoidung.LstNhatkySuDung.Count; j++)
                    {
                        if (nguoidung.LstNhatkySuDung[j].ThoiDiemVao == DateTime.Parse(thoidiemvao))
                        {
                            nhatkysudung = nguoidung.LstNhatkySuDung[j];
                            break;
                        }
                    }
                    if (nhatkysudung != null)
                        break;
                }
            }
            return nhatkysudung;
        }
    }
}