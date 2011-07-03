using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using QuanLyHoSoCongChuc.Utils;
using QuanLyHoSoCongChuc.Models;

namespace QuanLyHoSoCongChuc.Search
{
    public partial class FrmChonTruong : Office2007Form
    {
        public EventHandler Handler { get; set; }

        public FrmChonTruong()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            var criteria = new Criteria()
            {
                DBName = "NhanVien",
                DBProvider = new DBProvider()
            };
            LoadCriterias(criteria);
        }

        /// <summary>
        /// Load criterial corresponding with specified table
        /// </summary>
        public void LoadCriterias(Criteria criteria)
        {
            try
            {
                // Show waiting form
                GlobalVars.PreLoading();
                //------- E ---------

                // Init criteria
                Table tbl = criteria.InitCriterias();
                lstvTenTruongDuLieu.Items.Clear();
                for (int i = 0; i < tbl.Attributes.Count; i++)
                {
                    if (tbl.Attributes[i].Name.ToUpper() == "HINHANH" || (tbl.Attributes[i].IsForeignKey && tbl.Attributes[i].Name.ToUpper() == "MANHANVIEN"))
                        continue;
                    var objListViewItem = new ListViewItem();
                    objListViewItem.Tag = tbl.Attributes[i];

                    if (tbl.Attributes[i].IsForeignKey)
                    {
                        if (tbl.Attributes[i].Name.Substring(0, 2).ToUpper() == "MA")
                            objListViewItem.SubItems.Add(tbl.Attributes[i].Name.Substring(2));
                        else
                            objListViewItem.SubItems.Add(tbl.Attributes[i].Name);
                    }
                    else
                    {
                        objListViewItem.SubItems.Add(tbl.Attributes[i].Name);
                    }

                    lstvTenTruongDuLieu.Items.Add(objListViewItem);
                }

                // Hide waiting form
                GlobalVars.PosLoading();
                //------- E ---------
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        private void btChon_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstvTenTruongDuLieu.Items.Count; i++)
            {
                if (lstvTenTruongDuLieu.Items[i].Checked)
                {
                    if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, ((QuanLyHoSoCongChuc.Utils.Attribute)lstvTenTruongDuLieu.Items[i].Tag).Name) == null)
                    {
                        GlobalSearch.LstTruongHienThi.Add(((QuanLyHoSoCongChuc.Utils.Attribute)lstvTenTruongDuLieu.Items[i].Tag).Name, (QuanLyHoSoCongChuc.Utils.Attribute)lstvTenTruongDuLieu.Items[i].Tag);
                    }
                }
            }

            TransferDataInfo(sender, new MyEvent(""));
        }

        /// <summary>
        /// tuansl added: function is used to transfer data when event would be raised
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TransferDataInfo(object sender, MyEvent e)
        {
            this.Close();
            this.Handler(this, e);
        }

        private void FrmChonTruong_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < lstvTenTruongDuLieu.Items.Count; i++)
            {
                var att = (QuanLyHoSoCongChuc.Utils.Attribute)lstvTenTruongDuLieu.Items[i].Tag;
                if (GlobalSearch.GetAttInDict(GlobalSearch.LstTruongHienThi, att.Name) != null)
                {
                    lstvTenTruongDuLieu.Items[i].Checked = true;
                }
            }
        }
    }
}
