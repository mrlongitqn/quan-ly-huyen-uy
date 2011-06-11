using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using QuanLyHoSoCongChuc.Models;
using QuanLyHoSoCongChuc.Repositories;
using QuanLyHoSoCongChuc.Utils;
using QuanLyHoSoCongChuc.Danh_muc;
using QuanLyHoSoCongChuc.OtherForms;
using System.IO;

namespace QuanLyHoSoCongChuc.NhanVienManager
{
    /// <summary>
    /// tuansl added: manage sumary info of nhanvien
    /// </summary>
    public partial class FrmThongTinNhanVien_TomTat : DevComponents.DotNetBar.Office2007Form
    {
        #region Variables
        private NhanVien _nhanvien;
        // Hidden files are used to store ids 
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaChucVu;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaDanToc;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaTonGiao;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaThanhPhanGiaDinh;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaNgheNghiepTruocKhiDuocTuyenDung;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaGiaoDucPhoThong;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaChuyenMonNghiepVu;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaLyLuanChinhTri;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaNgoaiNgu;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaHocViCaoNhat;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaHocHam;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaTinhTrangSucKhoe;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaLoaiThuongBinh;
        public string PathHinhAnh { get; set; }
        #endregion

        #region Properties
        public string MaNhanVien
        {
            get
            {
                return txtMaNhanVien.Text;
            }
        }
        public int MaDanToc
        {
            get
            {
                return txtMaDanToc.Text == "" ? -1 : int.Parse(txtMaDanToc.Text);
            }
        }
        public int MaTonGiao
        {
            get
            {
                return txtMaTonGiao.Text == "" ? -1 : int.Parse(txtMaTonGiao.Text);
            }
        }
        public int MaThanhPhanGiaDinh
        {
            get
            {
                return txtMaThanhPhanGiaDinh.Text == "" ? -1 : int.Parse(txtMaThanhPhanGiaDinh.Text);
            }
        }
        public int MaNgheNghiepTruocKhiDuocTuyenDung
        {
            get
            {
                return txtMaNgheNghiepTruocKhiDuocTuyenDung.Text == "" ? -1 : int.Parse(txtMaNgheNghiepTruocKhiDuocTuyenDung.Text);
            }
        }
        public int MaBangGiaoDucPhoThong
        {
            get
            {
                return txtMaGiaoDucPhoThong.Text == "" ? -1 : int.Parse(txtMaGiaoDucPhoThong.Text);
            }
        }
        public int MaBangChuyenMonNghiepVu
        {
            get
            {
                return txtMaChuyenMonNghiepVu.Text == "" ? -1 : int.Parse(txtMaChuyenMonNghiepVu.Text);
            }
        }
        public int MaBangLyLuanChinhTri
        {
            get
            {
                return txtMaLyLuanChinhTri.Text == "" ? -1 : int.Parse(txtMaLyLuanChinhTri.Text);
            }
        }
        public int MaBangNgoaiNgu
        {
            get
            {
                return txtMaNgoaiNgu.Text == "" ? -1 : int.Parse(txtMaNgoaiNgu.Text);
            }
        }
        public int MaHocVi
        {
            get
            {
                return txtMaHocViCaoNhat.Text == "" ? -1 : int.Parse(txtMaHocViCaoNhat.Text);
            }
        }
        public int MaHocHam
        {
            get
            {
                return txtMaHocHam.Text == "" ? -1 : int.Parse(txtMaHocHam.Text);
            }
        }
        public int MaTinhTrangSucKhoe
        {
            get
            {
                return txtMaTinhTrangSucKhoe.Text == "" ? -1 : int.Parse(txtMaTinhTrangSucKhoe.Text);
            }
        }
        public int MaLoaiThuongBinh
        {
            get
            {
                return txtMaLoaiThuongBinh.Text == "" ? -1 : int.Parse(txtMaLoaiThuongBinh.Text);
            }
        }
        public int MaChucVu
        {
            get
            {
                return txtMaChucVu.Text == "" ? -1 : int.Parse(txtMaChucVu.Text);
            }
        }
        public string HinhAnh
        {
            get
            {
                return "";
            }
        }
        public string HoTenDangDung
        {
            get
            {
                return txtHoTenDangDung.Text;
            }
        }
        public string NoiSinh
        {
            get
            {
                return txtNoiSinh.Text;
            }
        }
        public string QueQuan
        {
            get
            {
                return txtQueQuan.Text;
            }
        }
        public string HoKhau
        {
            get
            {
                return txtHoKhau.Text;
            }
        }
        public string TamTru
        {
            get
            {
                return txtNoiOTamTru.Text;
            }
        }
        public string CongViecChinh
        {
            get
            {
                return txtCongViecChinh.Text;
            }
        }
        public DateTime NgayVaoDang
        {
            get
            {
                return dtNgayVaoDang.Value;
            }
        }
        public string VaoDangTaiChiBo
        {
            get
            {
                return txtTaiChiBoVaoDang.Text;
            }
        }
        public string NguoiGioiThieu1
        {
            get
            {
                return txtNguoiGioiThieu1.Text;
            }
        }
        public string ChucVuNguoi1
        {
            get
            {
                return txtChucVuNguoi1.Text;
            }
        }
        public string NguoiGioiThieu2
        {
            get
            {
                return txtNguoiGioiThieu2.Text;
            }
        }
        public string ChucVuNguoi2
        {
            get
            {
                return txtChucVuNguoi2.Text;
            }
        }
        public DateTime NgayChinhThuc
        {
            get
            {
                return dtNgayChinhThuc.Value;
            }
        }
        public string ChinhThucTaiChiBo
        {
            get
            {
                return txtTaiChiBoChinhThuc.Text;
            }
        }
        public DateTime NgayTuyenDung
        {
            get
            {
                return dtNgayTuyenDung.Value;
            }
        }
        public string CoQuanTuyenDung
        {
            get
            {
                return txtCoQuanTuyenDung.Text;
            }
        }
        public DateTime NgayVaoDoan
        {
            get
            {
                return dtNgayVaoDoan.Value;
            }
        }
        public string ChiDoan
        {
            get
            {
                return txtChiDoan.Text;
            }
        }
        public string ThamGiaCTXH
        {
            get
            {
                return txtThamGiaCTXH.Text;
            }
        }
        public DateTime NgayNhapNgu
        {
            get
            {
                return dtNgayNhapNgu.Value;
            }
        }
        public DateTime NgayXuatNgu
        {
            get
            {
                return dtNgayXuatNgu.Value;
            }
        }
        public bool GiaDinhLietSy
        {
            get
            {
                return ckbxGiaDinhLietSy.Checked;
            }
        }
        public bool GiaDinhCoCongVoiCM
        {
            get
            {
                return ckbxGiaDinhCoCongCM.Checked;
            }
        }
        public string SoCMND
        {
            get
            {
                return txtSoCMND.Text;
            }
        }
        public DateTime NgayMienSHD
        {
            get
            {
                return dtMienSHD.Value;
            }
        }
        public bool ConSinhHoat
        {
            get
            {
                return true;
            }
        }
        public string SoDienThoai
        {
            get
            {
                return txtSoDienThoai.Text;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// null: insert new nhanvien
        /// not null: update info of a nhanvien
        /// </summary>
        /// <param name="nhanvien"></param>
        public FrmThongTinNhanVien_TomTat(NhanVien nhanvien = null)
        {
            InitializeComponent();
            InitHiddenFields();
            _nhanvien = nhanvien;
            if (_nhanvien != null)
            {
                LoadData();
                LoadDataToHiddenFileds();
            }
            PathHinhAnh = "";
        }

        private void FrmThongTinNhanVien_TomTat_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Load base info of nhanvien that are showed in form tomtat
        /// </summary>
        public void LoadData()
        {
            txtMaNhanVien.Text = _nhanvien.MaNhanVien;
            txtSoDienThoai.Text = _nhanvien.SoDienThoai;
            txtHoTenDangDung.Text = _nhanvien.HoTenDangDung;
            txtNoiSinh.Text = _nhanvien.NoiSinh;
            txtQueQuan.Text = _nhanvien.QueQuan;
            txtHoKhau.Text = _nhanvien.HoKhau;
            txtNoiOTamTru.Text = _nhanvien.TamTru;

            if (System.IO.File.Exists(GlobalVars.g_strPathImages + "\\" + _nhanvien.HinhAnh))
            {
                picNv.Image = new Bitmap(GlobalVars.g_strPathImages + "\\" + _nhanvien.HinhAnh);
            }

            if (_nhanvien.HinhAnh != null)
            {
                LoadImage(_nhanvien.HinhAnh);
            }

            txtCongViecChinh.Text = _nhanvien.CongViecChinh;
            dtNgayVaoDang.Value = _nhanvien.NgayVaoDang.Value;
            txtTaiChiBoVaoDang.Text = _nhanvien.VaoDangTaiChiBo;
            txtNguoiGioiThieu1.Text = _nhanvien.NguoiGioiThieu1;
            txtChucVuNguoi1.Text = _nhanvien.ChucVuNguoi1;
            txtChucVuNguoi2.Text = _nhanvien.ChucVuNguoi2;
            txtNguoiGioiThieu2.Text = _nhanvien.NguoiGioiThieu2;
            dtNgayChinhThuc.Value = _nhanvien.NgayChinhThuc.Value;
            txtTaiChiBoChinhThuc.Text = _nhanvien.ChinhThucTaiChiBo;
            dtNgayTuyenDung.Value = _nhanvien.NgayTuyenDung.Value;
            txtCoQuanTuyenDung.Text = _nhanvien.CoQuanTuyenDung;
            dtNgayVaoDoan.Value = _nhanvien.NgayVaoDoan.Value;
            txtChiDoan.Text = _nhanvien.ChiDoan;
            txtThamGiaCTXH.Text = _nhanvien.ThamGiaCTXH;
            dtNgayNhapNgu.Value = _nhanvien.NgayNhapNgu.Value;
            dtNgayXuatNgu.Value = _nhanvien.NgayXuatNgu.Value;

            ckbxGiaDinhLietSy.Checked = _nhanvien.GiaDinhLietSy.Value;
            ckbxGiaDinhCoCongCM.Checked = _nhanvien.GiaDinhCoCongVoiCM.Value;
            txtSoCMND.Text = _nhanvien.SoCMND;
            dtMienSHD.Value = _nhanvien.NgayMienSHD.Value;

            txtChucVu.Text = _nhanvien.MaChucVu == null ? "" : _nhanvien.ChucVu.TenChucVu;
            txtDanToc.Text = _nhanvien.MaDanToc == null ? "" : _nhanvien.DanToc.TenDanToc;
            txtTonGiao.Text = _nhanvien.MaTonGiao == null ? "" : _nhanvien.TonGiao.TenTonGiao;
            txtThanhPhanGiaDinh.Text = _nhanvien.MaThanhPhanGiaDinh == null ? "" : _nhanvien.ThanhPhanGiaDinh.TenThanhPhanGiaDinh;
            txtNgheNghiepTruocKhiDuocTuyenDung.Text = _nhanvien.MaNgheNghiepTruocKhiDuocTuyenDung == null ? "" : _nhanvien.NgheNghiep.TenNgheNghiep;
            txtGiaoDucPhoThong.Text = _nhanvien.MaBangGiaoDucPhoThong == null ? "" : _nhanvien.BangGiaoDucPhoThong.TenBangGiaoDucPhoThong;
            txtChuyenMonNghiepVu.Text = _nhanvien.MaBangChuyenMonNghiepVu == null ? "" : _nhanvien.BangChuyenMonNghiepVu.TenBangChuyenMonNghiepVu;
            txtLyLuanChinhTri.Text = _nhanvien.MaBangLyLuanChinhTri == null ? "" : _nhanvien.BangLyLuanChinhTri.TenBangLyLuanChinhTri;
            txtNgoaiNgu.Text = _nhanvien.MaBangNgoaiNgu == null ? "" : _nhanvien.BangNgoaiNgu.TenBangNgoaiNgu;
            txtHocViCaoNhat.Text = _nhanvien.MaHocVi == null ? "" : _nhanvien.HocVi.TenHocVi;
            txtHocHam.Text = _nhanvien.MaHocHam == null ? "" : _nhanvien.HocHam.TenHocHam;
            txtTinhTrangSucKhoe.Text = _nhanvien.MaTinhTrangSucKhoe == null ? "" : _nhanvien.TinhTrangSucKhoe.TenTinhTrangSucKhoe;
            txtLoaiThuongBinh.Text = _nhanvien.MaLoaiThuongBinh == null ? "" : _nhanvien.LoaiThuongBinh.TenLoaiThuongBinh;

        }

        public void LoadImage(byte[] imageData)
        {
            try
            {
                //Initialize image variable
                Image newImage;
                //Read image data into a memory stream
                using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
                {
                    ms.Write(imageData, 0, imageData.Length);

                    //Set image variable value using memory stream.
                    newImage = Image.FromStream(ms, true);
                }

                //set picture
                picNv.Image = newImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Load info of nhanvien and set for hidden fields
        /// </summary>
        public void LoadDataToHiddenFileds()
        {
            txtMaChucVu.Text = _nhanvien.MaChucVu.ToString();
            txtMaDanToc.Text = _nhanvien.MaDanToc.ToString();
            txtMaTonGiao.Text = _nhanvien.MaTonGiao.ToString();
            txtMaThanhPhanGiaDinh.Text = _nhanvien.MaThanhPhanGiaDinh.ToString();
            txtMaNgheNghiepTruocKhiDuocTuyenDung.Text = _nhanvien.MaNgheNghiepTruocKhiDuocTuyenDung.ToString();
            txtMaGiaoDucPhoThong.Text = _nhanvien.MaBangGiaoDucPhoThong.ToString();
            txtMaChuyenMonNghiepVu.Text = _nhanvien.MaBangChuyenMonNghiepVu.ToString();
            txtMaLyLuanChinhTri.Text = _nhanvien.MaBangLyLuanChinhTri.ToString();
            txtMaNgoaiNgu.Text = _nhanvien.MaBangNgoaiNgu.ToString();
            txtMaHocViCaoNhat.Text = _nhanvien.MaHocVi.ToString();
            txtMaHocHam.Text = _nhanvien.MaHocHam.ToString();
            txtMaTinhTrangSucKhoe.Text = _nhanvien.MaTinhTrangSucKhoe.ToString();
            txtMaLoaiThuongBinh.Text = _nhanvien.MaLoaiThuongBinh.ToString();
        }

        /// <summary>
        /// Init hidden fields
        /// </summary>
        public void InitHiddenFields()
        {
            // Add a new textbox
            txtMaChucVu = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaChucVu",
                Text = ""
            };
            txtMaChucVu.Visible = false;

            // Add a new textbox
            txtMaDanToc = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaDanToc",
                Text = ""
            };
            txtMaDanToc.Visible = false;

            // Add a new textbox
            txtMaTonGiao = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaTonGiao",
                Text = ""
            };
            txtMaTonGiao.Visible = false;

            // Add a new textbox
            txtMaThanhPhanGiaDinh = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaThanhPhanGiaDinh",
                Text = ""
            };
            txtMaThanhPhanGiaDinh.Visible = false;

            // Add a new textbox
            txtMaNgheNghiepTruocKhiDuocTuyenDung = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaNgheNghiepTruocKhiDuocTuyenDung",
                Text = ""
            };
            txtMaNgheNghiepTruocKhiDuocTuyenDung.Visible = false;

            // Add a new textbox
            txtMaGiaoDucPhoThong = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaGiaoDucPhoThong",
                Text = ""
            };
            txtMaGiaoDucPhoThong.Visible = false;

            // Add a new textbox
            txtMaChuyenMonNghiepVu = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaChuyenMonNghiepVu",
                Text = ""
            };
            txtMaChuyenMonNghiepVu.Visible = false;

            // Add a new textbox
            txtMaLyLuanChinhTri = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaLyLuanChinhTri",
                Text = ""
            };
            txtMaLyLuanChinhTri.Visible = false;

            // Add a new textbox
            txtMaNgoaiNgu = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaNgoaiNgu",
                Text = ""
            };
            txtMaNgoaiNgu.Visible = false;

            // Add a new textbox
            txtMaHocViCaoNhat = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaHocViCaoNhat",
                Text = ""
            };
            txtMaHocViCaoNhat.Visible = false;

            // Add a new textbox
            txtMaHocHam = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaHocHam",
                Text = ""
            };
            txtMaHocHam.Visible = false;

            // Add a new textbox
            txtMaTinhTrangSucKhoe = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaTinhTrangSucKhoe",
                Text = ""
            };
            txtMaTinhTrangSucKhoe.Visible = false;

            // Add a new textbox
            txtMaLoaiThuongBinh = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaLoaiThuongBinh",
                Text = ""
            };
            txtMaLoaiThuongBinh.Visible = false;
        }
        #endregion

        private void btnChonNoiSinh_Click(object sender, EventArgs e)
        {
            FrmDanhMucHanhChinh frm = new FrmDanhMucHanhChinh(true);
            frm.Handler += GetNoiSinh;
            frm.ShowDialog();
        }

        public void GetNoiSinh(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            var item = PhuongXaRepository.SelectByID(comp[0]);
            txtNoiSinh.Text = item.MaPhuongXa + "." + item.QuanHuyen.MaQuanHuyen + "." + item.QuanHuyen.TinhThanh.MaTinh;
        }

        private void btnChonQueQuan_Click(object sender, EventArgs e)
        {
            FrmDanhMucHanhChinh frm = new FrmDanhMucHanhChinh(true);
            frm.Handler += GetQueQuan;
            frm.ShowDialog();
        }

        public void GetQueQuan(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            var item = PhuongXaRepository.SelectByID(comp[0]);
            txtQueQuan.Text = item.MaPhuongXa + "." + item.QuanHuyen.MaQuanHuyen + "." + item.QuanHuyen.TinhThanh.MaTinh;
        }

        private void btnChonChucVu_Click(object sender, EventArgs e)
        {
            FrmQuanLyChucVu frm = new FrmQuanLyChucVu();
            frm.Handler += GetChucVu;
            frm.ShowDialog();
        }

        public void GetChucVu(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaChucVu.Text = comp[0];
            txtChucVu.Text = comp[1];
        }

        private void btnChonDanToc_Click(object sender, EventArgs e)
        {
            FrmQuanLyDanToc frm = new FrmQuanLyDanToc();
            frm.Handler += GetDanToc;
            frm.ShowDialog();
        }

        public void GetDanToc(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaDanToc.Text = comp[0];
            txtDanToc.Text = comp[1];
        }

        private void btnChonThanhPhanXuatThan_Click(object sender, EventArgs e)
        {
            FrmQuanLyThanhPhanGiaDinh frm = new FrmQuanLyThanhPhanGiaDinh();
            frm.Handler += GetThanhPhanGiaDinh;
            frm.ShowDialog();
        }

        public void GetThanhPhanGiaDinh(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaThanhPhanGiaDinh.Text = comp[0];
            txtThanhPhanGiaDinh.Text = comp[1];
        }

        private void btnChonTonGiao_Click(object sender, EventArgs e)
        {
            FrmQuanLyTonGiao frm = new FrmQuanLyTonGiao();
            frm.Handler += GetTonGiao;
            frm.ShowDialog();
        }

        public void GetTonGiao(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaTonGiao.Text = comp[0];
            txtTonGiao.Text = comp[1];
        }

        private void btnChonNgheNghiepTruocKhiDuocTuyenDung_Click(object sender, EventArgs e)
        {
            FrmQuanLyNgheNghiep frm = new FrmQuanLyNgheNghiep();
            frm.Handler += GetNgheNghiep;
            frm.ShowDialog();
        }

        public void GetNgheNghiep(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaNgheNghiepTruocKhiDuocTuyenDung.Text = comp[0];
            txtNgheNghiepTruocKhiDuocTuyenDung.Text = comp[1];
        }

        private void btnChonGDPT_Click(object sender, EventArgs e)
        {
            FrmQuanLyBangGiaoDucPhoThong frm = new FrmQuanLyBangGiaoDucPhoThong();
            frm.Handler += GetBangGiaoDucPhoThong;
            frm.ShowDialog();
        }

        public void GetBangGiaoDucPhoThong(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaGiaoDucPhoThong.Text = comp[0];
            txtGiaoDucPhoThong.Text = comp[1];
        }

        private void btnChonCMNV_Click(object sender, EventArgs e)
        {
            FrmQuanLyBangChuyenMonNghiepVu frm = new FrmQuanLyBangChuyenMonNghiepVu();
            frm.Handler += GetCMNV;
            frm.ShowDialog();
        }

        public void GetCMNV(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaChuyenMonNghiepVu.Text = comp[0];
            txtChuyenMonNghiepVu.Text = comp[1];
        }

        private void btnChonLLCT_Click(object sender, EventArgs e)
        {
            FrmQuanLyBangLyLuanChinhTri frm = new FrmQuanLyBangLyLuanChinhTri();
            frm.Handler += GetLLCT;
            frm.ShowDialog();
        }

        public void GetLLCT(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaLyLuanChinhTri.Text = comp[0];
            txtLyLuanChinhTri.Text = comp[1];
        }

        private void btnChonNgoaiNgu_Click(object sender, EventArgs e)
        {
            FrmQuanLyBangNgoaiNgu frm = new FrmQuanLyBangNgoaiNgu();
            frm.Handler += GetBangNgoaiNgu;
            frm.ShowDialog();
        }

        public void GetBangNgoaiNgu(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaNgoaiNgu.Text = comp[0];
            txtNgoaiNgu.Text = comp[1];
        }

        private void btnChonHocViCaoNhat_Click(object sender, EventArgs e)
        {
            FrmQuanLyHocVi frm = new FrmQuanLyHocVi();
            frm.Handler += GetHocViCaoNhat;
            frm.ShowDialog();
        }

        public void GetHocViCaoNhat(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaHocViCaoNhat.Text = comp[0];
            txtHocViCaoNhat.Text = comp[1];
        }

        private void btnChonHocHam_Click(object sender, EventArgs e)
        {
            FrmQuanLyHocHam frm = new FrmQuanLyHocHam();
            frm.Handler += GetHocHam;
            frm.ShowDialog();
        }

        public void GetHocHam(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaHocHam.Text = comp[0];
            txtHocHam.Text = comp[1];
        }

        private void btnChonTinhTrangSucKhoe_Click(object sender, EventArgs e)
        {
            FrmQuanLyTinhTrangSucKhoe frm = new FrmQuanLyTinhTrangSucKhoe();
            frm.Handler += GetTTSK;
            frm.ShowDialog();
        }

        public void GetTTSK(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaTinhTrangSucKhoe.Text = comp[0];
            txtTinhTrangSucKhoe.Text = comp[1];
        }

        private void btnChonThuongBinh_Click(object sender, EventArgs e)
        {
            FrmQuanLyLoaiThuongBinh frm = new FrmQuanLyLoaiThuongBinh();
            frm.Handler += GetLoaiThuongBinh;
            frm.ShowDialog();
        }

        public void GetLoaiThuongBinh(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaLoaiThuongBinh.Text = comp[0];
            txtLoaiThuongBinh.Text = comp[1];
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PathHinhAnh = openFileDialog1.FileName;
                picNv.Image = new Bitmap(PathHinhAnh);
            }
        }

        private void btnBocAnh_Click(object sender, EventArgs e)
        {
            picNv.Image = null;
        }

    }
}