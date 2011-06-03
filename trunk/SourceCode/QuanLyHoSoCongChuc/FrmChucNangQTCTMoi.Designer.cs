namespace QuanLyHoSoCongChuc
{
    partial class FrmChucNangQTCTMoi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtIdDangVien = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cmbHoTen = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvQuaTrinhCongTac = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiGianBatDau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiGianKetThuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaQTCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoTaCongTac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNuocCongTac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaCapUy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChucDanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaCapUyKiem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaChucVuChinhQuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtpThoiGianKetThuc = new System.Windows.Forms.DateTimePicker();
            this.dtpThoiGianBatdau = new System.Windows.Forms.DateTimePicker();
            this.cmbChucVuChinhQuyen = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.txtChucDanh = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.cmbCapUyKiem = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.cmbCapUy = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.cmbNuocCongTac = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtMoTaCongTac = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.txtSTT = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.btnThem = new DevComponents.DotNetBar.ButtonX();
            this.btnSua = new DevComponents.DotNetBar.ButtonX();
            this.btnXoa = new DevComponents.DotNetBar.ButtonX();
            this.btnThoat = new DevComponents.DotNetBar.ButtonX();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuaTrinhCongTac)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtIdDangVien);
            this.groupBox1.Controls.Add(this.cmbHoTen);
            this.groupBox1.Controls.Add(this.labelX2);
            this.groupBox1.Controls.Add(this.labelX1);
            this.groupBox1.Location = new System.Drawing.Point(12, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 110);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtIdDangVien
            // 
            // 
            // 
            // 
            this.txtIdDangVien.Border.Class = "TextBoxBorder";
            this.txtIdDangVien.Location = new System.Drawing.Point(6, 83);
            this.txtIdDangVien.Name = "txtIdDangVien";
            this.txtIdDangVien.ReadOnly = true;
            this.txtIdDangVien.Size = new System.Drawing.Size(222, 20);
            this.txtIdDangVien.TabIndex = 3;
            // 
            // cmbHoTen
            // 
            this.cmbHoTen.DisplayMember = "Text";
            this.cmbHoTen.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbHoTen.FormattingEnabled = true;
            this.cmbHoTen.ItemHeight = 14;
            this.cmbHoTen.Location = new System.Drawing.Point(6, 36);
            this.cmbHoTen.Name = "cmbHoTen";
            this.cmbHoTen.Size = new System.Drawing.Size(222, 20);
            this.cmbHoTen.TabIndex = 2;
            this.cmbHoTen.SelectedIndexChanged += new System.EventHandler(this.cmbHoTen_SelectedIndexChanged);
            // 
            // labelX2
            // 
            this.labelX2.Location = new System.Drawing.Point(6, 59);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "ID đảng viên";
            // 
            // labelX1
            // 
            this.labelX1.Location = new System.Drawing.Point(6, 11);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Họ và tên";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvQuaTrinhCongTac);
            this.groupBox2.Location = new System.Drawing.Point(12, 111);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(234, 323);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // dgvQuaTrinhCongTac
            // 
            this.dgvQuaTrinhCongTac.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuaTrinhCongTac.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.ThoiGianBatDau,
            this.ThoiGianKetThuc,
            this.MaQTCT,
            this.MoTaCongTac,
            this.MaNuocCongTac,
            this.MaCapUy,
            this.ChucDanh,
            this.MaCapUyKiem,
            this.MaChucVuChinhQuyen});
            this.dgvQuaTrinhCongTac.Location = new System.Drawing.Point(6, 10);
            this.dgvQuaTrinhCongTac.Name = "dgvQuaTrinhCongTac";
            this.dgvQuaTrinhCongTac.Size = new System.Drawing.Size(222, 309);
            this.dgvQuaTrinhCongTac.TabIndex = 0;
            this.dgvQuaTrinhCongTac.SelectionChanged += new System.EventHandler(this.dgvQuaTrinhCongTac_SelectionChanged);
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.Width = 30;
            // 
            // ThoiGianBatDau
            // 
            this.ThoiGianBatDau.HeaderText = "Từ";
            this.ThoiGianBatDau.Name = "ThoiGianBatDau";
            this.ThoiGianBatDau.ReadOnly = true;
            this.ThoiGianBatDau.Width = 75;
            // 
            // ThoiGianKetThuc
            // 
            this.ThoiGianKetThuc.HeaderText = "Đến";
            this.ThoiGianKetThuc.Name = "ThoiGianKetThuc";
            this.ThoiGianKetThuc.ReadOnly = true;
            this.ThoiGianKetThuc.Width = 75;
            // 
            // MaQTCT
            // 
            this.MaQTCT.HeaderText = "Ma QTCT";
            this.MaQTCT.Name = "MaQTCT";
            this.MaQTCT.Visible = false;
            // 
            // MoTaCongTac
            // 
            this.MoTaCongTac.HeaderText = "Mô tả công tác";
            this.MoTaCongTac.Name = "MoTaCongTac";
            this.MoTaCongTac.Visible = false;
            // 
            // MaNuocCongTac
            // 
            this.MaNuocCongTac.HeaderText = "Nước Công Tác";
            this.MaNuocCongTac.Name = "MaNuocCongTac";
            this.MaNuocCongTac.Visible = false;
            // 
            // MaCapUy
            // 
            this.MaCapUy.HeaderText = "Cấp ủy";
            this.MaCapUy.Name = "MaCapUy";
            this.MaCapUy.Visible = false;
            // 
            // ChucDanh
            // 
            this.ChucDanh.HeaderText = "Chức danh";
            this.ChucDanh.Name = "ChucDanh";
            this.ChucDanh.Visible = false;
            // 
            // MaCapUyKiem
            // 
            this.MaCapUyKiem.HeaderText = "Mã cấp ủy kiệm";
            this.MaCapUyKiem.Name = "MaCapUyKiem";
            this.MaCapUyKiem.Visible = false;
            // 
            // MaChucVuChinhQuyen
            // 
            this.MaChucVuChinhQuyen.HeaderText = "Mã Chức vụ chính quyền";
            this.MaChucVuChinhQuyen.Name = "MaChucVuChinhQuyen";
            this.MaChucVuChinhQuyen.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtpThoiGianKetThuc);
            this.groupBox3.Controls.Add(this.dtpThoiGianBatdau);
            this.groupBox3.Controls.Add(this.cmbChucVuChinhQuyen);
            this.groupBox3.Controls.Add(this.labelX12);
            this.groupBox3.Controls.Add(this.txtChucDanh);
            this.groupBox3.Controls.Add(this.labelX11);
            this.groupBox3.Controls.Add(this.cmbCapUyKiem);
            this.groupBox3.Controls.Add(this.labelX10);
            this.groupBox3.Controls.Add(this.cmbCapUy);
            this.groupBox3.Controls.Add(this.labelX9);
            this.groupBox3.Controls.Add(this.cmbNuocCongTac);
            this.groupBox3.Controls.Add(this.labelX8);
            this.groupBox3.Controls.Add(this.groupPanel1);
            this.groupBox3.Controls.Add(this.txtMoTaCongTac);
            this.groupBox3.Controls.Add(this.labelX7);
            this.groupBox3.Controls.Add(this.labelX6);
            this.groupBox3.Controls.Add(this.labelX5);
            this.groupBox3.Controls.Add(this.txtSTT);
            this.groupBox3.Controls.Add(this.labelX4);
            this.groupBox3.Controls.Add(this.labelX3);
            this.groupBox3.Location = new System.Drawing.Point(252, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(550, 388);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // dtpThoiGianKetThuc
            // 
            this.dtpThoiGianKetThuc.Location = new System.Drawing.Point(345, 37);
            this.dtpThoiGianKetThuc.Name = "dtpThoiGianKetThuc";
            this.dtpThoiGianKetThuc.Size = new System.Drawing.Size(199, 20);
            this.dtpThoiGianKetThuc.TabIndex = 21;
            // 
            // dtpThoiGianBatdau
            // 
            this.dtpThoiGianBatdau.CustomFormat = "DD-MM-YYYY";
            this.dtpThoiGianBatdau.Location = new System.Drawing.Point(111, 37);
            this.dtpThoiGianBatdau.Name = "dtpThoiGianBatdau";
            this.dtpThoiGianBatdau.Size = new System.Drawing.Size(199, 20);
            this.dtpThoiGianBatdau.TabIndex = 20;
            // 
            // cmbChucVuChinhQuyen
            // 
            this.cmbChucVuChinhQuyen.DisplayMember = "Text";
            this.cmbChucVuChinhQuyen.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbChucVuChinhQuyen.FormattingEnabled = true;
            this.cmbChucVuChinhQuyen.ItemHeight = 14;
            this.cmbChucVuChinhQuyen.Location = new System.Drawing.Point(104, 355);
            this.cmbChucVuChinhQuyen.Name = "cmbChucVuChinhQuyen";
            this.cmbChucVuChinhQuyen.Size = new System.Drawing.Size(438, 20);
            this.cmbChucVuChinhQuyen.TabIndex = 19;
            // 
            // labelX12
            // 
            this.labelX12.Location = new System.Drawing.Point(6, 352);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(92, 23);
            this.labelX12.TabIndex = 18;
            this.labelX12.Text = "C. vụ chính quyền";
            // 
            // txtChucDanh
            // 
            // 
            // 
            // 
            this.txtChucDanh.Border.Class = "TextBoxBorder";
            this.txtChucDanh.Location = new System.Drawing.Point(104, 333);
            this.txtChucDanh.Name = "txtChucDanh";
            this.txtChucDanh.Size = new System.Drawing.Size(438, 20);
            this.txtChucDanh.TabIndex = 17;
            // 
            // labelX11
            // 
            this.labelX11.Location = new System.Drawing.Point(41, 333);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(57, 23);
            this.labelX11.TabIndex = 16;
            this.labelX11.Text = "Chức danh";
            // 
            // cmbCapUyKiem
            // 
            this.cmbCapUyKiem.DisplayMember = "Text";
            this.cmbCapUyKiem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCapUyKiem.FormattingEnabled = true;
            this.cmbCapUyKiem.ItemHeight = 14;
            this.cmbCapUyKiem.Location = new System.Drawing.Point(104, 310);
            this.cmbCapUyKiem.Name = "cmbCapUyKiem";
            this.cmbCapUyKiem.Size = new System.Drawing.Size(438, 20);
            this.cmbCapUyKiem.TabIndex = 15;
            // 
            // labelX10
            // 
            this.labelX10.Location = new System.Drawing.Point(31, 310);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(67, 23);
            this.labelX10.TabIndex = 14;
            this.labelX10.Text = "Cấp ủy kiêm";
            // 
            // cmbCapUy
            // 
            this.cmbCapUy.DisplayMember = "Text";
            this.cmbCapUy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCapUy.FormattingEnabled = true;
            this.cmbCapUy.ItemHeight = 14;
            this.cmbCapUy.Location = new System.Drawing.Point(104, 287);
            this.cmbCapUy.Name = "cmbCapUy";
            this.cmbCapUy.Size = new System.Drawing.Size(438, 20);
            this.cmbCapUy.TabIndex = 13;
            // 
            // labelX9
            // 
            this.labelX9.Location = new System.Drawing.Point(61, 287);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(37, 23);
            this.labelX9.TabIndex = 12;
            this.labelX9.Text = "Cấp ủy";
            // 
            // cmbNuocCongTac
            // 
            this.cmbNuocCongTac.DisplayMember = "Text";
            this.cmbNuocCongTac.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbNuocCongTac.FormattingEnabled = true;
            this.cmbNuocCongTac.ItemHeight = 14;
            this.cmbNuocCongTac.Location = new System.Drawing.Point(104, 264);
            this.cmbNuocCongTac.Name = "cmbNuocCongTac";
            this.cmbNuocCongTac.Size = new System.Drawing.Size(385, 20);
            this.cmbNuocCongTac.TabIndex = 11;
            // 
            // labelX8
            // 
            this.labelX8.Location = new System.Drawing.Point(23, 264);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(75, 23);
            this.labelX8.TabIndex = 10;
            this.labelX8.Text = "Nước công tác";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.groupPanel1.Location = new System.Drawing.Point(31, 246);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(495, 3);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanel1.TabIndex = 9;
            // 
            // txtMoTaCongTac
            // 
            // 
            // 
            // 
            this.txtMoTaCongTac.Border.Class = "TextBoxBorder";
            this.txtMoTaCongTac.Location = new System.Drawing.Point(18, 103);
            this.txtMoTaCongTac.Multiline = true;
            this.txtMoTaCongTac.Name = "txtMoTaCongTac";
            this.txtMoTaCongTac.Size = new System.Drawing.Size(526, 132);
            this.txtMoTaCongTac.TabIndex = 8;
            // 
            // labelX7
            // 
            this.labelX7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX7.Location = new System.Drawing.Point(18, 80);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(292, 23);
            this.labelX7.TabIndex = 7;
            this.labelX7.Text = "Làm nghề gì, chức vụ, đơn vị công tác";
            // 
            // labelX6
            // 
            this.labelX6.Location = new System.Drawing.Point(316, 38);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(32, 23);
            this.labelX6.TabIndex = 6;
            this.labelX6.Text = "Đến";
            // 
            // labelX5
            // 
            this.labelX5.Location = new System.Drawing.Point(94, 38);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(19, 23);
            this.labelX5.TabIndex = 3;
            this.labelX5.Text = "Từ";
            // 
            // txtSTT
            // 
            // 
            // 
            // 
            this.txtSTT.Border.Class = "TextBoxBorder";
            this.txtSTT.Location = new System.Drawing.Point(41, 39);
            this.txtSTT.Name = "txtSTT";
            this.txtSTT.Size = new System.Drawing.Size(46, 20);
            this.txtSTT.TabIndex = 2;
            // 
            // labelX4
            // 
            this.labelX4.Location = new System.Drawing.Point(18, 39);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(30, 23);
            this.labelX4.TabIndex = 1;
            this.labelX4.Text = "STT";
            // 
            // labelX3
            // 
            this.labelX3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.ForeColor = System.Drawing.Color.Crimson;
            this.labelX3.Location = new System.Drawing.Point(31, 10);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(352, 23);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = "Tóm tắt quá trình hoạt động nghề nghiệp và công tác";
            // 
            // btnThem
            // 
            this.btnThem.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThem.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(252, 396);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(81, 38);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSua.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(334, 396);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(81, 38);
            this.btnSua.TabIndex = 0;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnXoa.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(416, 396);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(81, 38);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(721, 396);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(81, 38);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // FrmChucNangQTCTMoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(806, 436);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmChucNangQTCTMoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chức năng quá trình công tác";
            this.Load += new System.EventHandler(this.FrmChucNangQTCTMoi_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuaTrinhCongTac)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtIdDangVien;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbHoTen;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvQuaTrinhCongTac;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSTT;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbChucVuChinhQuyen;
        private DevComponents.DotNetBar.LabelX labelX12;
        private DevComponents.DotNetBar.Controls.TextBoxX txtChucDanh;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbCapUyKiem;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbCapUy;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbNuocCongTac;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMoTaCongTac;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.ButtonX btnThem;
        private DevComponents.DotNetBar.ButtonX btnSua;
        private DevComponents.DotNetBar.ButtonX btnXoa;
        private DevComponents.DotNetBar.ButtonX btnThoat;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGianBatDau;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGianKetThuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaQTCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoTaCongTac;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNuocCongTac;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCapUy;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChucDanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCapUyKiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaChucVuChinhQuyen;
        private System.Windows.Forms.DateTimePicker dtpThoiGianKetThuc;
        private System.Windows.Forms.DateTimePicker dtpThoiGianBatdau;

    }
}