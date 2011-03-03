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
    public partial class Report1 : Form
    {
        SqlConnection conn;
        SqlDataAdapter adapter;
       
        String MaNV;
        NhanVienControl m_NhanVienControl = new NhanVienControl();
        public Report1(String _maNV)
        {
            InitializeComponent();
            MaNV = _maNV;
        }

        private void Report1_Load(object sender, EventArgs e)
        {
            try
            {
                DataService.OpenConnection();
                conn = new SqlConnection(DataService.m_ConnectString );
                conn.Open();
                String sql = "select * from DaoTao where MaNhanVien='" + MaNV+"' ";
                adapter = new SqlDataAdapter(sql, conn);
                //dataset = new DataSet();
                adapter.Fill(ds4RP1, "DaoTao");
            
                DataTable NhanVienDt =m_NhanVienControl.LayNhanVienTheoMa(MaNV);
                
                CrystalReport1 rpt = new CrystalReport1();

                // Parameter 1
                //ParameterFieldDefinitions crParameterFieldDefinitions1;
                //ParameterFieldDefinition crParameterFieldDefinition1;
                //ParameterValues crParameterValues1 = new ParameterValues();
                //ParameterDiscreteValue crParameterDiscreteValue1 = new ParameterDiscreteValue();
                //crParameterDiscreteValue1.Value = "1) Họ và tên:" + NhanVienDt.Rows[0]["HoTenNhanVien"].ToString() + ". Giới tính: " + getGioiTinh(NhanVienDt.Rows[0]["HoTenNhanVien"].ToString());
                //crParameterFieldDefinitions1 = rpt.DataDefinition.ParameterFields;
                //crParameterFieldDefinition1 = crParameterFieldDefinitions1["HoTen"];
                //crParameterValues1 = crParameterFieldDefinition1.CurrentValues;
                //crParameterValues1.Clear();
                //crParameterValues1.Add(crParameterDiscreteValue1);
                //crParameterFieldDefinition1.ApplyCurrentValues(crParameterValues1);

                rpt.DataDefinition.FormulaFields["HoTen"].Text = "'1) Họ và tên: " + NhanVienDt.Rows[0]["HoTenNhanVien"].ToString() + ". Giới tính: " + getGioiTinh(NhanVienDt.Rows[0]["HoTenNhanVien"].ToString())+"'";

                // Parameter 4
                //ParameterFieldDefinitions crParameterFieldDefinitions4;
                //ParameterFieldDefinition crParameterFieldDefinition4;
                //ParameterValues crParameterValues4 = new ParameterValues();
                //ParameterDiscreteValue crParameterDiscreteValue4 = new ParameterDiscreteValue();
                DateTime MyDateTime = new DateTime();
                String MyString = NhanVienDt.Rows[0]["NgaySinh"].ToString();
                MyDateTime = Convert.ToDateTime(MyString);

                //crParameterDiscreteValue4.Value = "4) Sinh ngày: " + MyDateTime.Day + " tháng " + MyDateTime.Month + " năm " + MyDateTime.Year;//03 tháng 01 năm 1987";
                //crParameterFieldDefinitions4 = rpt.DataDefinition.ParameterFields;
                //crParameterFieldDefinition4 = crParameterFieldDefinitions4["NgaySinh"];
                //crParameterValues4 = crParameterFieldDefinition4.CurrentValues;
                //crParameterValues4.Clear();
                //crParameterValues4.Add(crParameterDiscreteValue4);
                //crParameterFieldDefinition4.ApplyCurrentValues(crParameterValues4);

                rpt.DataDefinition.FormulaFields["NgaySinh"].Text = "'4) Sinh ngày: " + MyDateTime.Day + " tháng " + MyDateTime.Month + " năm " + MyDateTime.Year + "'";

                // Parameter 5
                //ParameterFieldDefinitions crParameterFieldDefinitions5;
                //ParameterFieldDefinition crParameterFieldDefinition5;
                //ParameterValues crParameterValues5 = new ParameterValues();
                //ParameterDiscreteValue crParameterDiscreteValue5 = new ParameterDiscreteValue();
                //crParameterDiscreteValue5.Value = "5) Nơi sinh: " + NhanVienDt.Rows[0]["NoiSinh"].ToString(); ;
                //crParameterFieldDefinitions5 = rpt.DataDefinition.ParameterFields;
                //crParameterFieldDefinition5 = crParameterFieldDefinitions5["NoiSinh"];
                //crParameterValues5 = crParameterFieldDefinition5.CurrentValues;
                //crParameterValues5.Clear();
                //crParameterValues5.Add(crParameterDiscreteValue5);
                //crParameterFieldDefinition5.ApplyCurrentValues(crParameterValues5);

                rpt.DataDefinition.FormulaFields["NoiSinh"].Text = "'5) Nơi sinh: " + NhanVienDt.Rows[0]["NoiSinh"].ToString() + "'";

                // Parameter 6
                //ParameterFieldDefinitions crParameterFieldDefinitions6;
                //ParameterFieldDefinition crParameterFieldDefinition6;
                //ParameterValues crParameterValues6 = new ParameterValues();
                //ParameterDiscreteValue crParameterDiscreteValue6 = new ParameterDiscreteValue();
                //crParameterDiscreteValue6.Value = "6) Quê quán: " + NhanVienDt.Rows[0]["QueQuan"].ToString(); 
                //crParameterFieldDefinitions6 = rpt.DataDefinition.ParameterFields;
                //crParameterFieldDefinition6 = crParameterFieldDefinitions6["QueQuan"];
                //crParameterValues6 = crParameterFieldDefinition6.CurrentValues;
                //crParameterValues6.Clear();
                //crParameterValues6.Add(crParameterDiscreteValue6);
                //crParameterFieldDefinition6.ApplyCurrentValues(crParameterValues6);

                rpt.DataDefinition.FormulaFields["QueQuan"].Text = "'6) Quê quán: " + NhanVienDt.Rows[0]["QueQuan"].ToString() + "'";

                // Parameter 7
                //ParameterFieldDefinitions crParameterFieldDefinitions7;
                //ParameterFieldDefinition crParameterFieldDefinition7;
                //ParameterValues crParameterValues7 = new ParameterValues();
                //ParameterDiscreteValue crParameterDiscreteValue7 = new ParameterDiscreteValue();
                //crParameterDiscreteValue7.Value = "7) Nơi ở hiện nay: "+ NhanVienDt.Rows[0]["NoiOHienTai"].ToString(); 
                //crParameterFieldDefinitions7 = rpt.DataDefinition.ParameterFields;
                //crParameterFieldDefinition7 = crParameterFieldDefinitions7["NoiOHienNay"];
                //crParameterValues7 = crParameterFieldDefinition7.CurrentValues;
                //crParameterValues7.Clear();
                //crParameterValues7.Add(crParameterDiscreteValue7);
                //crParameterFieldDefinition7.ApplyCurrentValues(crParameterValues7);

                rpt.DataDefinition.FormulaFields["NoiOHienNay"].Text = "'7) Nơi ở hiện nay: " + NhanVienDt.Rows[0]["NoiOHienTai"].ToString() + "'";

                // Parameter 7b
  
                rpt.DataDefinition.FormulaFields["DienThoai"].Text = "'- Điện thoại: " + NhanVienDt.Rows[0]["DienThoaiDiDong"].ToString() + "'";

                // Parameter 8
  
                DataService service = new DataService();
                sql = "select * from DanToc where MaDanToc='" + NhanVienDt.Rows[0]["MaDanToc"].ToString() + "'";
                DataSet ds = service.ExecuteQuery(sql);
                rpt.DataDefinition.FormulaFields["DanToc"].Text = "'8) Dân tộc: " + ds.Tables[0].Rows[0]["TenDanToc"]+ "'";

                // Parameter 9
                sql = "select * from TonGiao where MaTonGiao='" + NhanVienDt.Rows[0]["MaTonGiao"].ToString() + "'";
                ds.Clear();
                ds = service.ExecuteQuery(sql);
                rpt.DataDefinition.FormulaFields["TonGiao"].Text = "'9) Tôn giáo: " + ds.Tables[0].Rows[0]["TenTonGiao"] + "'";

                // Parameter 10

                sql = "select * from ThanhPhanXuatThan where MaThanhPhanXuatThan='" + NhanVienDt.Rows[0]["MaThanhPhanXuatThan"].ToString() + "'";
                ds.Clear();
                ds = service.ExecuteQuery(sql);
                rpt.DataDefinition.FormulaFields["XuatThan"].Text = "'10) Thành phần gia đình xuất thân: " + ds.Tables[0].Rows[0]["TenThanhPhanXuatThan"] + "'";

                // Parameter 11
                rpt.DataDefinition.FormulaFields["NgheNghiep"].Text = "'11) Nghề nghiệp bản thân trước khi được tuyển dụng: .......................'";

                // Parameter 12
                MyDateTime = new DateTime();
                MyString = NhanVienDt.Rows[0]["NgayTuyenDung"].ToString();
                MyDateTime = Convert.ToDateTime(MyString);
                rpt.DataDefinition.FormulaFields["NgayDuocTuyenDung"].Text = "'12) Ngày được tuyển dụng: " + MyDateTime.Day + "/" + MyDateTime.Month + "/" + MyDateTime.Year + ", vào cơ quan: ..............................'";

                // Parameter 13

                rpt.DataDefinition.FormulaFields["NgayVaoCoQuanHienDangCongTac"].Text = "'13) Ngày vào cơ quan hiện đang công tác: ............, Ngày tham gia cách mạng: .....................'";

                // Parameter 14
                MyDateTime = new DateTime();
                MyString = NhanVienDt.Rows[0]["NgayVaoDang"].ToString();
                MyDateTime = Convert.ToDateTime(MyString);

                MyString = NhanVienDt.Rows[0]["NgayChinhThuc"].ToString();
                DateTime MyDateTime2 = Convert.ToDateTime(MyString);
                rpt.DataDefinition.FormulaFields["NgayVaoDang"].Text = "'14) Ngày vào Đảng Cộng Sản Việt Nam: " + MyDateTime.Day + "/" + MyDateTime.Month + "/" + MyDateTime.Year + ", Ngày chính thức: " + MyDateTime2.Day + "/" + MyDateTime2.Month + "/" + MyDateTime2.Year + "'";

                // Parameter 15
                //ParameterFieldDefinitions crParameterFieldDefinitions15;
                //ParameterFieldDefinition crParameterFieldDefinition15;
                //ParameterValues crParameterValues15 = new ParameterValues();
                //ParameterDiscreteValue crParameterDiscreteValue15 = new ParameterDiscreteValue();

                MyString = NhanVienDt.Rows[0]["NgayThamGiaTCCTXH"].ToString();
                MyDateTime = Convert.ToDateTime(MyString);
                rpt.DataDefinition.FormulaFields["NgayThamGiaCacToChucChinhTri"].Text = "'15) Ngày tham gia các tổ chức chính trị (Đoàn TNCSHCM, Công đoàn, Hội): " + MyDateTime.Day + "/" + MyDateTime.Month + "/" + MyDateTime.Year + "'";

                // Parameter 16
                rpt.DataDefinition.FormulaFields["NgayNhapNgu"].Text = "'16) Ngày nhập ngũ: ..............., Ngày xuất ngũ: ..............., Quân hàm, chức vụ cao nhất:...............,Năm ......'";

                // Parameter 17
                sql = "select * from TrinhDoHocVan where MaTrinhDoHocVan='" + NhanVienDt.Rows[0]["MaTrinhDoHocVan"].ToString() + "'";
                ds.Clear();
                ds = service.ExecuteQuery(sql);
                rpt.DataDefinition.FormulaFields["TrinhDoHocVan"].Text = "'17) Trình độ học vấn: Giáo dục phổ thông:" + ds.Tables[0].Rows[0]["TenTrinhDoHocVan"] + "'";

                // Parameter 17a
                rpt.DataDefinition.FormulaFields["HocVi"].Text = "'- Học hàm, học vị cao nhất: Cử nhân, năm 2010, chuyên ngành Công nghệ thông tin'";

                // Parameter 17b
                rpt.DataDefinition.FormulaFields["LyLuanChinhTri"].Text = "'- Lý luận chính trị: Sơ cấp.   -Ngoại ngữ: Anh'";

                // Parameter 18
                //ParameterFieldDefinitions crParameterFieldDefinitions18;
                //ParameterFieldDefinition crParameterFieldDefinition18;
                //ParameterValues crParameterValues18 = new ParameterValues();
                //ParameterDiscreteValue crParameterDiscreteValue18 = new ParameterDiscreteValue();
                //crParameterDiscreteValue18.Value = "18) Công tác chính đang làm: học thêm";
                //crParameterFieldDefinitions18 = rpt.DataDefinition.ParameterFields;
                //crParameterFieldDefinition18 = crParameterFieldDefinitions18["CongTacChinh"];
                //crParameterValues18 = crParameterFieldDefinition18.CurrentValues;
                //crParameterValues18.Clear();
                //crParameterValues18.Add(crParameterDiscreteValue18);
                //crParameterFieldDefinition18.ApplyCurrentValues(crParameterValues18);
                rpt.DataDefinition.FormulaFields["CongTacChinh"].Text = "'18) Công tác chính đang làm: học thêm'";

                // Parameter 19
                //ParameterFieldDefinitions crParameterFieldDefinitions19;
                //ParameterFieldDefinition crParameterFieldDefinition19;
                //ParameterValues crParameterValues19 = new ParameterValues();
                //ParameterDiscreteValue crParameterDiscreteValue19 = new ParameterDiscreteValue();
                //crParameterDiscreteValue19.Value = "19) Ngạch công chức: ko biết (Mã số: .................). Bậc lương: ......, hệ số: 8, từ tháng 8/1999";
                //crParameterFieldDefinitions19 = rpt.DataDefinition.ParameterFields;
                //crParameterFieldDefinition19 = crParameterFieldDefinitions19["NgachCongChuc"];
                //crParameterValues19 = crParameterFieldDefinition19.CurrentValues;
                //crParameterValues19.Clear();
                //crParameterValues19.Add(crParameterDiscreteValue19);
                //crParameterFieldDefinition19.ApplyCurrentValues(crParameterValues19);
                rpt.DataDefinition.FormulaFields["NgachCongChuc"].Text = "'19) Ngạch công chức: ko biết (Mã số: .................). Bậc lương: ......, hệ số: 8, từ tháng 8/1999'";

                // Parameter 20
                //ParameterFieldDefinitions crParameterFieldDefinitions20;
                //ParameterFieldDefinition crParameterFieldDefinition20;
                //ParameterValues crParameterValues20 = new ParameterValues();
                //ParameterDiscreteValue crParameterDiscreteValue20 = new ParameterDiscreteValue();
                //crParameterDiscreteValue20.Value = "20) Danh hiệu được phong: Anh hùng lao động, năm 2000";
                //crParameterFieldDefinitions20 = rpt.DataDefinition.ParameterFields;
                //crParameterFieldDefinition20 = crParameterFieldDefinitions20["DanhHieu"];
                //crParameterValues20 = crParameterFieldDefinition20.CurrentValues;
                //crParameterValues20.Clear();
                //crParameterValues20.Add(crParameterDiscreteValue20);
                //crParameterFieldDefinition20.ApplyCurrentValues(crParameterValues20);

                rpt.DataDefinition.FormulaFields["DanhHieu"].Text = "'20) Danh hiệu được phong: Anh hùng lao động, năm 2000'";

                // Parameter 21
                rpt.DataDefinition.FormulaFields["SoTruong"].Text = "'21) Sở trường công tác: Chơi game. Công việc đã làm lâu nhất: Chơi fifa'";

                // Parameter 22

                rpt.DataDefinition.FormulaFields["KhenThuong"].Text = "'22) Khen thưởng: .............'";

                // Parameter 23
                rpt.DataDefinition.FormulaFields["KyLuat"].Text = "'23) Kỷ luật: .............'";

                // Parameter 24
                rpt.DataDefinition.FormulaFields["TinhTrangSucKhoe"].Text = "'24) Tình trạng sức khỏe: bình thường. Cao 1m70. Cân nặng 72kg. Nhóm máu A'";

                rpt.DataDefinition.FormulaFields["CMND"].Text = "'25) Số chứng minh nhân dân: " + NhanVienDt.Rows[0]["SoChungMinhNhanDan"].ToString() + ". Thương binh loại: ..............Gia đình liệt sỹ: .............'";

                rpt.SetDataSource(ds4RP1);

                
                crystalReportViewer1.ReportSource = rpt;
                //crystalReportViewer1.Show();
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public String getGioiTinh(String Ma)
        {
            if (Ma == "0")
                return "Nữ";
            else
                return "Nam";
        }
    }
}
