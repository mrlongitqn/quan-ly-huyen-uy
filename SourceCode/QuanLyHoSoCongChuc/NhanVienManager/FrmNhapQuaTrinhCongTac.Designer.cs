namespace QuanLyHoSoCongChuc.NhanVienManager
{
    partial class FrmNhapQuaTrinhCongTac
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lstvData = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtMaNhanVien = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtHoTen = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDenThangNam = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.txtTuThangNam = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.txtChucVuChinhQuyen = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnChonChucVuChinhQuyen = new System.Windows.Forms.Button();
            this.txtCapUyKiem = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnChonCapUyKiem = new System.Windows.Forms.Button();
            this.txtCapUy = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnChonCapUy = new System.Windows.Forms.Button();
            this.txtNuocCongTac = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnChonNuocCongTac = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnHuy = new DevComponents.DotNetBar.ButtonX();
            this.btnGhi = new DevComponents.DotNetBar.ButtonX();
            this.btnThoat = new DevComponents.DotNetBar.ButtonX();
            this.btnSua = new DevComponents.DotNetBar.ButtonX();
            this.btnThem = new DevComponents.DotNetBar.ButtonX();
            this.btnXoa = new DevComponents.DotNetBar.ButtonX();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.txtChucDanh = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txtMoTaCongTac = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.panel5.Controls.Add(this.panel3);
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(212, 436);
            this.panel5.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.panel3.Controls.Add(this.lstvData);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 113);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(212, 323);
            this.panel3.TabIndex = 3;
            // 
            // lstvData
            // 
            // 
            // 
            // 
            this.lstvData.Border.Class = "ListViewBorder";
            this.lstvData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader1,
            this.columnHeader3});
            this.lstvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstvData.FullRowSelect = true;
            this.lstvData.Location = new System.Drawing.Point(0, 0);
            this.lstvData.MultiSelect = false;
            this.lstvData.Name = "lstvData";
            this.lstvData.Size = new System.Drawing.Size(212, 323);
            this.lstvData.TabIndex = 1;
            this.lstvData.UseCompatibleStateImageBehavior = false;
            this.lstvData.View = System.Windows.Forms.View.Details;
            this.lstvData.SelectedIndexChanged += new System.EventHandler(this.listViewEx1_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "STT";
            this.columnHeader2.Width = 40;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Từ";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader1.Width = 70;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đến";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 70;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.panel2.Controls.Add(this.txtMaNhanVien);
            this.panel2.Controls.Add(this.labelX1);
            this.panel2.Controls.Add(this.txtHoTen);
            this.panel2.Controls.Add(this.labelX2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(212, 113);
            this.panel2.TabIndex = 2;
            // 
            // txtMaNhanVien
            // 
            this.txtMaNhanVien.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtMaNhanVien.Border.Class = "TextBoxBorder";
            this.txtMaNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNhanVien.Location = new System.Drawing.Point(6, 81);
            this.txtMaNhanVien.Name = "txtMaNhanVien";
            this.txtMaNhanVien.ReadOnly = true;
            this.txtMaNhanVien.Size = new System.Drawing.Size(196, 20);
            this.txtMaNhanVien.TabIndex = 78;
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(12, 55);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(87, 20);
            this.labelX1.TabIndex = 77;
            this.labelX1.Text = "Mã nhân viên";
            // 
            // txtHoTen
            // 
            this.txtHoTen.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtHoTen.Border.Class = "TextBoxBorder";
            this.txtHoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTen.Location = new System.Drawing.Point(6, 29);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.ReadOnly = true;
            this.txtHoTen.Size = new System.Drawing.Size(196, 20);
            this.txtHoTen.TabIndex = 76;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(12, 6);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(58, 20);
            this.labelX2.TabIndex = 75;
            this.labelX2.Text = "Họ và tên";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.panel1.Controls.Add(this.txtDenThangNam);
            this.panel1.Controls.Add(this.txtTuThangNam);
            this.panel1.Controls.Add(this.txtChucVuChinhQuyen);
            this.panel1.Controls.Add(this.btnChonChucVuChinhQuyen);
            this.panel1.Controls.Add(this.txtCapUyKiem);
            this.panel1.Controls.Add(this.btnChonCapUyKiem);
            this.panel1.Controls.Add(this.txtCapUy);
            this.panel1.Controls.Add(this.btnChonCapUy);
            this.panel1.Controls.Add(this.txtNuocCongTac);
            this.panel1.Controls.Add(this.btnChonNuocCongTac);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.labelX11);
            this.panel1.Controls.Add(this.labelX10);
            this.panel1.Controls.Add(this.labelX9);
            this.panel1.Controls.Add(this.labelX8);
            this.panel1.Controls.Add(this.labelX6);
            this.panel1.Controls.Add(this.txtChucDanh);
            this.panel1.Controls.Add(this.labelX5);
            this.panel1.Controls.Add(this.labelX4);
            this.panel1.Controls.Add(this.txtMoTaCongTac);
            this.panel1.Controls.Add(this.labelX7);
            this.panel1.Controls.Add(this.labelX3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(212, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(619, 436);
            this.panel1.TabIndex = 2;
            // 
            // txtDenThangNam
            // 
            // 
            // 
            // 
            this.txtDenThangNam.BackgroundStyle.Class = "TextBoxBorder";
            this.txtDenThangNam.ButtonClear.Visible = true;
            this.txtDenThangNam.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.txtDenThangNam.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.txtDenThangNam.Location = new System.Drawing.Point(406, 43);
            this.txtDenThangNam.Mask = "00/0000";
            this.txtDenThangNam.Name = "txtDenThangNam";
            this.txtDenThangNam.Size = new System.Drawing.Size(75, 20);
            this.txtDenThangNam.TabIndex = 1;
            this.txtDenThangNam.Text = "";
            this.txtDenThangNam.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDenThangNam.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.txtDenThangNam.ValidatingType = typeof(System.DateTime);
            // 
            // txtTuThangNam
            // 
            // 
            // 
            // 
            this.txtTuThangNam.BackgroundStyle.Class = "TextBoxBorder";
            this.txtTuThangNam.ButtonClear.Visible = true;
            this.txtTuThangNam.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.txtTuThangNam.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.txtTuThangNam.Location = new System.Drawing.Point(188, 43);
            this.txtTuThangNam.Mask = "00/0000";
            this.txtTuThangNam.Name = "txtTuThangNam";
            this.txtTuThangNam.Size = new System.Drawing.Size(75, 20);
            this.txtTuThangNam.TabIndex = 0;
            this.txtTuThangNam.Text = "";
            this.txtTuThangNam.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTuThangNam.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.txtTuThangNam.ValidatingType = typeof(System.DateTime);
            // 
            // txtChucVuChinhQuyen
            // 
            this.txtChucVuChinhQuyen.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtChucVuChinhQuyen.Border.Class = "TextBoxBorder";
            this.txtChucVuChinhQuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChucVuChinhQuyen.Location = new System.Drawing.Point(164, 362);
            this.txtChucVuChinhQuyen.Name = "txtChucVuChinhQuyen";
            this.txtChucVuChinhQuyen.ReadOnly = true;
            this.txtChucVuChinhQuyen.Size = new System.Drawing.Size(404, 20);
            this.txtChucVuChinhQuyen.TabIndex = 317;
            // 
            // btnChonChucVuChinhQuyen
            // 
            this.btnChonChucVuChinhQuyen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnChonChucVuChinhQuyen.Image = global::QuanLyHoSoCongChuc.Properties.Resources._001_03;
            this.btnChonChucVuChinhQuyen.Location = new System.Drawing.Point(574, 357);
            this.btnChonChucVuChinhQuyen.Name = "btnChonChucVuChinhQuyen";
            this.btnChonChucVuChinhQuyen.Size = new System.Drawing.Size(28, 27);
            this.btnChonChucVuChinhQuyen.TabIndex = 316;
            this.btnChonChucVuChinhQuyen.UseVisualStyleBackColor = true;
            this.btnChonChucVuChinhQuyen.Click += new System.EventHandler(this.btnChonChucVuChinhQuyen_Click);
            // 
            // txtCapUyKiem
            // 
            this.txtCapUyKiem.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtCapUyKiem.Border.Class = "TextBoxBorder";
            this.txtCapUyKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCapUyKiem.Location = new System.Drawing.Point(164, 310);
            this.txtCapUyKiem.Name = "txtCapUyKiem";
            this.txtCapUyKiem.ReadOnly = true;
            this.txtCapUyKiem.Size = new System.Drawing.Size(404, 20);
            this.txtCapUyKiem.TabIndex = 315;
            // 
            // btnChonCapUyKiem
            // 
            this.btnChonCapUyKiem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnChonCapUyKiem.Image = global::QuanLyHoSoCongChuc.Properties.Resources._001_03;
            this.btnChonCapUyKiem.Location = new System.Drawing.Point(574, 305);
            this.btnChonCapUyKiem.Name = "btnChonCapUyKiem";
            this.btnChonCapUyKiem.Size = new System.Drawing.Size(28, 27);
            this.btnChonCapUyKiem.TabIndex = 314;
            this.btnChonCapUyKiem.UseVisualStyleBackColor = true;
            this.btnChonCapUyKiem.Click += new System.EventHandler(this.btnChonCapUyKiem_Click);
            // 
            // txtCapUy
            // 
            this.txtCapUy.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtCapUy.Border.Class = "TextBoxBorder";
            this.txtCapUy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCapUy.Location = new System.Drawing.Point(164, 284);
            this.txtCapUy.Name = "txtCapUy";
            this.txtCapUy.ReadOnly = true;
            this.txtCapUy.Size = new System.Drawing.Size(404, 20);
            this.txtCapUy.TabIndex = 313;
            // 
            // btnChonCapUy
            // 
            this.btnChonCapUy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnChonCapUy.Image = global::QuanLyHoSoCongChuc.Properties.Resources._001_03;
            this.btnChonCapUy.Location = new System.Drawing.Point(574, 279);
            this.btnChonCapUy.Name = "btnChonCapUy";
            this.btnChonCapUy.Size = new System.Drawing.Size(28, 27);
            this.btnChonCapUy.TabIndex = 312;
            this.btnChonCapUy.UseVisualStyleBackColor = true;
            this.btnChonCapUy.Click += new System.EventHandler(this.btnChonCapUy_Click);
            // 
            // txtNuocCongTac
            // 
            this.txtNuocCongTac.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNuocCongTac.Border.Class = "TextBoxBorder";
            this.txtNuocCongTac.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNuocCongTac.Location = new System.Drawing.Point(164, 258);
            this.txtNuocCongTac.Name = "txtNuocCongTac";
            this.txtNuocCongTac.ReadOnly = true;
            this.txtNuocCongTac.Size = new System.Drawing.Size(404, 20);
            this.txtNuocCongTac.TabIndex = 3;
            // 
            // btnChonNuocCongTac
            // 
            this.btnChonNuocCongTac.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnChonNuocCongTac.Image = global::QuanLyHoSoCongChuc.Properties.Resources._001_03;
            this.btnChonNuocCongTac.Location = new System.Drawing.Point(574, 253);
            this.btnChonNuocCongTac.Name = "btnChonNuocCongTac";
            this.btnChonNuocCongTac.Size = new System.Drawing.Size(28, 27);
            this.btnChonNuocCongTac.TabIndex = 310;
            this.btnChonNuocCongTac.UseVisualStyleBackColor = true;
            this.btnChonNuocCongTac.Click += new System.EventHandler(this.btnChonNuocCongTac_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.panel4.Controls.Add(this.btnHuy);
            this.panel4.Controls.Add(this.btnGhi);
            this.panel4.Controls.Add(this.btnThoat);
            this.panel4.Controls.Add(this.btnSua);
            this.panel4.Controls.Add(this.btnThem);
            this.panel4.Controls.Add(this.btnXoa);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 389);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(619, 47);
            this.panel4.TabIndex = 94;
            // 
            // btnHuy
            // 
            this.btnHuy.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHuy.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnHuy.Image = global::QuanLyHoSoCongChuc.Properties.Resources.Eraser_icon;
            this.btnHuy.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.btnHuy.Location = new System.Drawing.Point(429, 12);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(64, 23);
            this.btnHuy.TabIndex = 42;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGhi.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGhi.Image = global::QuanLyHoSoCongChuc.Properties.Resources._45;
            this.btnGhi.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.btnGhi.Location = new System.Drawing.Point(359, 12);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(64, 23);
            this.btnGhi.TabIndex = 41;
            this.btnGhi.Text = "Ghi";
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThoat.Image = global::QuanLyHoSoCongChuc.Properties.Resources.exit;
            this.btnThoat.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.btnThoat.Location = new System.Drawing.Point(500, 12);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(72, 23);
            this.btnThoat.TabIndex = 40;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnSua
            // 
            this.btnSua.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSua.Image = global::QuanLyHoSoCongChuc.Properties.Resources._001_39;
            this.btnSua.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.btnSua.Location = new System.Drawing.Point(118, 12);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(64, 23);
            this.btnSua.TabIndex = 39;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThem.Image = global::QuanLyHoSoCongChuc.Properties.Resources._001_01;
            this.btnThem.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.btnThem.Location = new System.Drawing.Point(48, 12);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(64, 23);
            this.btnThem.TabIndex = 38;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnXoa.Image = global::QuanLyHoSoCongChuc.Properties.Resources._001_29;
            this.btnXoa.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.btnXoa.Location = new System.Drawing.Point(188, 12);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(72, 23);
            this.btnXoa.TabIndex = 37;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // labelX11
            // 
            this.labelX11.BackColor = System.Drawing.Color.Transparent;
            this.labelX11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX11.Location = new System.Drawing.Point(6, 361);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(136, 20);
            this.labelX11.TabIndex = 93;
            this.labelX11.Text = "Chức vụ chính quyền";
            this.labelX11.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX10
            // 
            this.labelX10.BackColor = System.Drawing.Color.Transparent;
            this.labelX10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX10.Location = new System.Drawing.Point(55, 335);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(87, 20);
            this.labelX10.TabIndex = 92;
            this.labelX10.Text = "Chức danh";
            this.labelX10.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX9
            // 
            this.labelX9.BackColor = System.Drawing.Color.Transparent;
            this.labelX9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX9.Location = new System.Drawing.Point(6, 309);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(136, 20);
            this.labelX9.TabIndex = 91;
            this.labelX9.Text = "Cấp ủy kiêm";
            this.labelX9.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX8
            // 
            this.labelX8.BackColor = System.Drawing.Color.Transparent;
            this.labelX8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX8.Location = new System.Drawing.Point(55, 283);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(87, 20);
            this.labelX8.TabIndex = 90;
            this.labelX8.Text = "Cấp ủy";
            this.labelX8.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX6
            // 
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            this.labelX6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX6.Location = new System.Drawing.Point(55, 257);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(87, 20);
            this.labelX6.TabIndex = 89;
            this.labelX6.Text = "Nước công tác";
            this.labelX6.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtChucDanh
            // 
            // 
            // 
            // 
            this.txtChucDanh.Border.Class = "TextBoxBorder";
            this.txtChucDanh.Location = new System.Drawing.Point(164, 336);
            this.txtChucDanh.Name = "txtChucDanh";
            this.txtChucDanh.Size = new System.Drawing.Size(438, 20);
            this.txtChucDanh.TabIndex = 86;
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            this.labelX5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX5.Location = new System.Drawing.Point(308, 43);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(89, 20);
            this.labelX5.TabIndex = 77;
            this.labelX5.Text = "Đến tháng năm";
            this.labelX5.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            this.labelX4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.Location = new System.Drawing.Point(98, 43);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(82, 20);
            this.labelX4.TabIndex = 76;
            this.labelX4.Text = "Từ tháng năm";
            this.labelX4.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtMoTaCongTac
            // 
            this.txtMoTaCongTac.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtMoTaCongTac.Border.Class = "TextBoxBorder";
            this.txtMoTaCongTac.Location = new System.Drawing.Point(18, 98);
            this.txtMoTaCongTac.Multiline = true;
            this.txtMoTaCongTac.Name = "txtMoTaCongTac";
            this.txtMoTaCongTac.Size = new System.Drawing.Size(584, 141);
            this.txtMoTaCongTac.TabIndex = 2;
            // 
            // labelX7
            // 
            this.labelX7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX7.Location = new System.Drawing.Point(18, 78);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(292, 23);
            this.labelX7.TabIndex = 26;
            this.labelX7.Text = "Làm nghề gì, chức vụ, đơn vị công tác";
            // 
            // labelX3
            // 
            this.labelX3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.ForeColor = System.Drawing.Color.Crimson;
            this.labelX3.Location = new System.Drawing.Point(129, 6);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(352, 23);
            this.labelX3.TabIndex = 1;
            this.labelX3.Text = "Tóm tắt quá trình hoạt động nghề nghiệp và công tác";
            // 
            // FrmNhapQuaTrinhCongTac
            // 
            this.ClientSize = new System.Drawing.Size(831, 436);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNhapQuaTrinhCongTac";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập quá trình công tác";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmNhapQuaTrinhCongTac_FormClosed);
            this.Load += new System.EventHandler(this.FrmNhapQuaTrinhCongTac_Load);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaNhanVien;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtHoTen;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMoTaCongTac;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.TextBoxX txtChucDanh;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX labelX6;
        private System.Windows.Forms.Panel panel4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtChucVuChinhQuyen;
        private System.Windows.Forms.Button btnChonChucVuChinhQuyen;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCapUyKiem;
        private System.Windows.Forms.Button btnChonCapUyKiem;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCapUy;
        private System.Windows.Forms.Button btnChonCapUy;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNuocCongTac;
        private System.Windows.Forms.Button btnChonNuocCongTac;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv txtDenThangNam;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv txtTuThangNam;
        private DevComponents.DotNetBar.Controls.ListViewEx lstvData;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private DevComponents.DotNetBar.ButtonX btnHuy;
        private DevComponents.DotNetBar.ButtonX btnGhi;
        private DevComponents.DotNetBar.ButtonX btnThoat;
        private DevComponents.DotNetBar.ButtonX btnSua;
        private DevComponents.DotNetBar.ButtonX btnThem;
        private DevComponents.DotNetBar.ButtonX btnXoa;
    }
}