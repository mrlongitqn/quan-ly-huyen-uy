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
                String sql = "select * from QuaTrinhDaoTao where MaNhanVien='" + MaNV+"' ";
                adapter = new SqlDataAdapter(sql, conn);
                //dataset = new DataSet();
                adapter.Fill(ds4RP1, "DaoTao");
            
                DataTable NhanVienDt =m_NhanVienControl.LayNhanVienTheoMa(MaNV);
                
                CrystalReport1 rpt = new CrystalReport1();

                // Parameter 1
                rpt.DataDefinition.FormulaFields["HoTen"].Text = "'1) Họ và tên: " + NhanVienDt.Rows[0]["HoTenKhaiSinh"].ToString() + ". Giới tính: " + getGioiTinh(NhanVienDt.Rows[0]["HoTenKhaiSinh"].ToString())+"'";

                // Parameter 3b
                rpt.DataDefinition.FormulaFields["ChucVu"].Text = "'- Chức vụ: " + NhanVienDt.Rows[0]["ChucVuLanhDaoKiemNhiem"].ToString() + "'";
                rpt.DataDefinition.FormulaFields["HeSoPhuCap"].Text = "'- Hệ số phụ cấp: " + NhanVienDt.Rows[0]["HeSoPhuCapKiemNhiem"].ToString() + "'";

                // Parameter 4
                DateTime MyDateTime = new DateTime();
                String MyString = NhanVienDt.Rows[0]["NgaySinh"].ToString();
                MyDateTime = Convert.ToDateTime(MyString);


                rpt.DataDefinition.FormulaFields["NgaySinh"].Text = "'4) Sinh ngày: " + MyDateTime.Day + " tháng " + MyDateTime.Month + " năm " + MyDateTime.Year + "'";

                // Parameter 5
                rpt.DataDefinition.FormulaFields["NoiSinh"].Text = "'5) Nơi sinh: " + NhanVienDt.Rows[0]["NoiSinh"].ToString() + "'";

                // Parameter 6
                rpt.DataDefinition.FormulaFields["QueQuan"].Text = "'6) Quê quán: " + NhanVienDt.Rows[0]["QueQuan"].ToString() + "'";

                // Parameter 7
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
                sql = "select * from BangLyLuanChinhTri where MaBangLyLuanChinhTri='" + NhanVienDt.Rows[0]["MaBangLyLuanChinhTri"].ToString() + "'";
                ds.Clear();
                ds = service.ExecuteQuery(sql);
                String TenBangLyLuanChinhTri = ds.Tables[0].Rows[0]["TenBangLyLuanChinhTri"].ToString() ;

                sql = "select * from TrinhDoNgoaiNgu where MaTrinhDoNgoaiNgu='" + NhanVienDt.Rows[0]["MaTrinhDoNgoaiNgu"].ToString() + "'";
                ds.Clear();
                ds = service.ExecuteQuery(sql);
                rpt.DataDefinition.FormulaFields["LyLuanChinhTri"].Text = "'- Lý luận chính trị: " + TenBangLyLuanChinhTri + ".   - Ngoại ngữ: " + ds.Tables[0].Rows[0]["TenTrinhDoNgoaiNgu"] + "'";

                // Parameter 18

                rpt.DataDefinition.FormulaFields["CongTacChinh"].Text = "'18) Công tác chính đang làm: học thêm'";

                // Parameter 19

                rpt.DataDefinition.FormulaFields["NgachCongChuc"].Text = "'19) Ngạch công chức: ............. (Mã số: ...........). Bậc lương: ......, hệ số: ..., từ tháng ...........'";

                // Parameter 20
         
                rpt.DataDefinition.FormulaFields["DanhHieu"].Text = "'20) Danh hiệu được phong: .......................................'";

                // Parameter 21
                rpt.DataDefinition.FormulaFields["SoTruong"].Text = "'21) Sở trường công tác: ......................... Công việc đã làm lâu nhất: .....................'";

                // Parameter 22

                rpt.DataDefinition.FormulaFields["KhenThuong"].Text = "'22) Khen thưởng: ................................................'";

                // Parameter 23
                rpt.DataDefinition.FormulaFields["KyLuat"].Text = "'23) Kỷ luật: ...................................................'";

                // Parameter 24
                rpt.DataDefinition.FormulaFields["TinhTrangSucKhoe"].Text = "'24) Tình trạng sức khỏe: ............. Cao ........ Cân nặng ...... Nhóm máu ....'";

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
