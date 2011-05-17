using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using QuanLyHoSoCongChuc.BusinessObject;
using QuanLyHoSoCongChuc.Controller;
using QuanLyHoSoCongChuc.DataLayer;

namespace QuanLyHoSoCongChuc
{
    public partial class Report2 : Form
    {
        String MaNV;
        NhanVienControl m_NhanVienControl = new NhanVienControl();
        public Report2(String _maNV)
        {
            InitializeComponent();
            MaNV = _maNV;
        }

        private void Report2_Load(object sender, EventArgs e)
        {
            try
            {
                DataService.OpenConnection();
                DataTable NhanVienDt = m_NhanVienControl.LayNhanVienTheoMa(MaNV);

                CrystalReport2 rpt = new CrystalReport2();

                // Parameter 1
                ParameterFieldDefinitions crParameterFieldDefinitions;
                ParameterFieldDefinition crParameterFieldDefinition;
                ParameterValues crParameterValues = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
                crParameterDiscreteValue.Value = NhanVienDt.Rows[0]["HoTenNhanVien"].ToString();
                crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["name"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;
                crParameterValues.Clear();
                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

                // Parameter 2
                DateTime MyDateTime = new DateTime();
                String MyString = NhanVienDt.Rows[0]["NgaySinh"].ToString();
                MyDateTime = Convert.ToDateTime(MyString);
                ParameterFieldDefinitions crParameterFieldDefinitions2;
                ParameterFieldDefinition crParameterFieldDefinition2;
                ParameterValues crParameterValues2 = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue2 = new ParameterDiscreteValue();
                crParameterDiscreteValue2.Value = MyDateTime.Day + " tháng " + MyDateTime.Month + " năm " + MyDateTime.Year;
                crParameterFieldDefinitions2 = rpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition2 = crParameterFieldDefinitions2["ngaysinh"];
                crParameterValues2 = crParameterFieldDefinition2.CurrentValues;
                crParameterValues2.Clear();
                crParameterValues2.Add(crParameterDiscreteValue2);
                crParameterFieldDefinition2.ApplyCurrentValues(crParameterValues2);

                // Parameter 3
                ParameterFieldDefinitions crParameterFieldDefinitions3;
                ParameterFieldDefinition crParameterFieldDefinition3;
                ParameterValues crParameterValues3 = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue3 = new ParameterDiscreteValue();
                crParameterDiscreteValue3.Value = NhanVienDt.Rows[0]["NoiSinh"].ToString(); 
                crParameterFieldDefinitions3 = rpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition3 = crParameterFieldDefinitions3["noisinh"];
                crParameterValues3 = crParameterFieldDefinition3.CurrentValues;
                crParameterValues3.Clear();
                crParameterValues3.Add(crParameterDiscreteValue3);
                crParameterFieldDefinition3.ApplyCurrentValues(crParameterValues3);

                // Parameter 4
                ParameterFieldDefinitions crParameterFieldDefinitions4;
                ParameterFieldDefinition crParameterFieldDefinition4;
                ParameterValues crParameterValues4 = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue4 = new ParameterDiscreteValue();
                crParameterDiscreteValue4.Value = NhanVienDt.Rows[0]["SoSoBHXH"].ToString(); 
                crParameterFieldDefinitions4 = rpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition4 = crParameterFieldDefinitions4["BHXH"];
                crParameterValues4 = crParameterFieldDefinition4.CurrentValues;
                crParameterValues4.Clear();
                crParameterValues4.Add(crParameterDiscreteValue4);
                crParameterFieldDefinition4.ApplyCurrentValues(crParameterValues4);

                // Parameter 5
                ParameterFieldDefinitions crParameterFieldDefinitions5;
                ParameterFieldDefinition crParameterFieldDefinition5;
                ParameterValues crParameterValues5 = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue5 = new ParameterDiscreteValue();
                crParameterDiscreteValue5.Value = "................................";
                crParameterFieldDefinitions5 = rpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition5 = crParameterFieldDefinitions5["DonViCongTac"];
                crParameterValues5 = crParameterFieldDefinition5.CurrentValues;
                crParameterValues5.Clear();
                crParameterValues5.Add(crParameterDiscreteValue5);
                crParameterFieldDefinition5.ApplyCurrentValues(crParameterValues5);

                // Parameter 6
                ParameterFieldDefinitions crParameterFieldDefinitions6;
                ParameterFieldDefinition crParameterFieldDefinition6;
                ParameterValues crParameterValues6 = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue6 = new ParameterDiscreteValue();
                crParameterDiscreteValue6.Value = "1-1-2001";
                crParameterFieldDefinitions6 = rpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition6 = crParameterFieldDefinitions6["TuNgay"];
                crParameterValues6 = crParameterFieldDefinition6.CurrentValues;
                crParameterValues6.Clear();
                crParameterValues6.Add(crParameterDiscreteValue6);
                crParameterFieldDefinition6.ApplyCurrentValues(crParameterValues6);

                // Parameter 7
                ParameterFieldDefinitions crParameterFieldDefinitions7;
                ParameterFieldDefinition crParameterFieldDefinition7;
                ParameterValues crParameterValues7 = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue7 = new ParameterDiscreteValue();
                crParameterDiscreteValue7.Value = "		Nay, Ủy ban nhân dân huyện Thạch Hà thông báo cho ông: " + NhanVienDt.Rows[0]["HoTenNhanVien"].ToString() + " và các cơ quan có thẩm quyền biết để thực hiện các thủ tục liên quan.";
                crParameterFieldDefinitions7 = rpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition7 = crParameterFieldDefinitions7["LoiThongBao"];
                crParameterValues7 = crParameterFieldDefinition7.CurrentValues;
                crParameterValues7.Clear();
                crParameterValues7.Add(crParameterDiscreteValue7);
                crParameterFieldDefinition7.ApplyCurrentValues(crParameterValues7);

                // Parameter 8
                ParameterFieldDefinitions crParameterFieldDefinitions8;
                ParameterFieldDefinition crParameterFieldDefinition8;
                ParameterValues crParameterValues8 = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue8 = new ParameterDiscreteValue();
                crParameterDiscreteValue8.Value = ".................................";
                crParameterFieldDefinitions8 = rpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition8 = crParameterFieldDefinitions8["ChuTich"];
                crParameterValues8 = crParameterFieldDefinition8.CurrentValues;
                crParameterValues8.Clear();
                crParameterValues8.Add(crParameterDiscreteValue8);
                crParameterFieldDefinition8.ApplyCurrentValues(crParameterValues8);

                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
