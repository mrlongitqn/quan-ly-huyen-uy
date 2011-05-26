namespace QuanLyHoSoCongChuc.Report
{
    partial class FrmBaoCaoLuong
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.DGVLuong = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.cbKy = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.comboItem5 = new DevComponents.Editors.ComboItem();
            this.comboItem6 = new DevComponents.Editors.ComboItem();
            this.cbDoiTuong = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.cbDonVi = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.btLuuBieu = new DevComponents.DotNetBar.ButtonX();
            this.btInBieu = new DevComponents.DotNetBar.ButtonX();
            this.btBaoBieu = new DevComponents.DotNetBar.ButtonX();
            this.cbxNhomMau = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.rdSaved = new System.Windows.Forms.RadioButton();
            this.rdFromDB = new System.Windows.Forms.RadioButton();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.dtNgay = new System.Windows.Forms.DateTimePicker();
            this.lblPassword = new DevComponents.DotNetBar.LabelX();
            this.lblUsername = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.HoTenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaGioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaChucVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDonVi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLuongNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNgach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNgachCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BacLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Huong85 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChenhLechBaoLuuHeSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HuongLuongTuNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MocTinhNangLuongLanSau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeSoPhuCapChucVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeSoPhuCapThamNienVuotKhung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeSoPhuCapKiemNhiem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeSoPhuCapKhac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVLuong)).BeginInit();
            this.panelEx1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(252, 95);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(29, 22);
            this.labelX2.TabIndex = 84;
            this.labelX2.Text = "Kỳ";
            // 
            // labelX10
            // 
            this.labelX10.BackColor = System.Drawing.Color.Transparent;
            this.labelX10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX10.Location = new System.Drawing.Point(44, 95);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(110, 25);
            this.labelX10.TabIndex = 83;
            this.labelX10.Text = "Ngày tháng năm";
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.Controls.Add(this.DGVLuong);
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(0, 248);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(844, 242);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 3;
            // 
            // DGVLuong
            // 
            this.DGVLuong.AllowUserToAddRows = false;
            this.DGVLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVLuong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HoTenNhanVien,
            this.MaGioiTinh,
            this.MaChucVu,
            this.MaDonVi,
            this.MaLuongNhanVien,
            this.MaNgach,
            this.MaNgachCC,
            this.BacLuong,
            this.HeSoLuong,
            this.Huong85,
            this.ChenhLechBaoLuuHeSoLuong,
            this.HuongLuongTuNgay,
            this.MocTinhNangLuongLanSau,
            this.HeSoPhuCapChucVu,
            this.HeSoPhuCapThamNienVuotKhung,
            this.HeSoPhuCapKiemNhiem,
            this.HeSoPhuCapKhac});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVLuong.DefaultCellStyle = dataGridViewCellStyle1;
            this.DGVLuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVLuong.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.DGVLuong.Location = new System.Drawing.Point(0, 0);
            this.DGVLuong.Name = "DGVLuong";
            this.DGVLuong.Size = new System.Drawing.Size(844, 242);
            this.DGVLuong.TabIndex = 2;
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.Controls.Add(this.groupPanel1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(844, 248);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 2;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.textBox1);
            this.groupPanel1.Controls.Add(this.textBox5);
            this.groupPanel1.Controls.Add(this.textBox6);
            this.groupPanel1.Controls.Add(this.cbKy);
            this.groupPanel1.Controls.Add(this.cbDoiTuong);
            this.groupPanel1.Controls.Add(this.cbDonVi);
            this.groupPanel1.Controls.Add(this.buttonX1);
            this.groupPanel1.Controls.Add(this.btLuuBieu);
            this.groupPanel1.Controls.Add(this.btInBieu);
            this.groupPanel1.Controls.Add(this.btBaoBieu);
            this.groupPanel1.Controls.Add(this.cbxNhomMau);
            this.groupPanel1.Controls.Add(this.rdSaved);
            this.groupPanel1.Controls.Add(this.rdFromDB);
            this.groupPanel1.Controls.Add(this.labelX4);
            this.groupPanel1.Controls.Add(this.textBox4);
            this.groupPanel1.Controls.Add(this.textBox3);
            this.groupPanel1.Controls.Add(this.textBox2);
            this.groupPanel1.Controls.Add(this.labelX3);
            this.groupPanel1.Controls.Add(this.dtNgay);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.Controls.Add(this.labelX10);
            this.groupPanel1.Controls.Add(this.lblPassword);
            this.groupPanel1.Controls.Add(this.lblUsername);
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(844, 248);
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
            this.groupPanel1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(506, 170);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(192, 22);
            this.textBox1.TabIndex = 151;
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(506, 145);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(192, 22);
            this.textBox5.TabIndex = 150;
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(506, 120);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(192, 22);
            this.textBox6.TabIndex = 149;
            // 
            // cbKy
            // 
            this.cbKy.DisplayMember = "Text";
            this.cbKy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbKy.FormattingEnabled = true;
            this.cbKy.ItemHeight = 14;
            this.cbKy.Items.AddRange(new object[] {
            this.comboItem4,
            this.comboItem5,
            this.comboItem6});
            this.cbKy.Location = new System.Drawing.Point(287, 95);
            this.cbKy.Name = "cbKy";
            this.cbKy.Size = new System.Drawing.Size(103, 20);
            this.cbKy.TabIndex = 148;
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "6 tháng đầu năm";
            // 
            // comboItem5
            // 
            this.comboItem5.Text = "6 tháng cuối năm";
            // 
            // comboItem6
            // 
            this.comboItem6.Text = "Cả năm";
            // 
            // cbDoiTuong
            // 
            this.cbDoiTuong.DisplayMember = "Text";
            this.cbDoiTuong.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDoiTuong.FormattingEnabled = true;
            this.cbDoiTuong.ItemHeight = 14;
            this.cbDoiTuong.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3});
            this.cbDoiTuong.Location = new System.Drawing.Point(150, 70);
            this.cbDoiTuong.Name = "cbDoiTuong";
            this.cbDoiTuong.Size = new System.Drawing.Size(192, 20);
            this.cbDoiTuong.TabIndex = 147;
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "Quỹ lương tổng hợp CB, CC, VC";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "Quỹ lương cán bộ, công chức";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "Quỹ lương viện chức hợp đồng";
            // 
            // cbDonVi
            // 
            this.cbDonVi.DisplayMember = "Text";
            this.cbDonVi.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDonVi.FormattingEnabled = true;
            this.cbDonVi.ItemHeight = 14;
            this.cbDonVi.Location = new System.Drawing.Point(150, 45);
            this.cbDonVi.Name = "cbDonVi";
            this.cbDonVi.Size = new System.Drawing.Size(192, 20);
            this.cbDonVi.TabIndex = 146;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(745, 78);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(80, 20);
            this.buttonX1.TabIndex = 145;
            this.buttonX1.Text = "Thoát";
            // 
            // btLuuBieu
            // 
            this.btLuuBieu.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btLuuBieu.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btLuuBieu.Location = new System.Drawing.Point(745, 48);
            this.btLuuBieu.Name = "btLuuBieu";
            this.btLuuBieu.Size = new System.Drawing.Size(80, 20);
            this.btLuuBieu.TabIndex = 144;
            this.btLuuBieu.Text = "Lưu biểu";
            // 
            // btInBieu
            // 
            this.btInBieu.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btInBieu.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btInBieu.Location = new System.Drawing.Point(653, 78);
            this.btInBieu.Name = "btInBieu";
            this.btInBieu.Size = new System.Drawing.Size(80, 20);
            this.btInBieu.TabIndex = 143;
            this.btInBieu.Text = "In biểu";
            this.btInBieu.Click += new System.EventHandler(this.btInBieu_Click);
            // 
            // btBaoBieu
            // 
            this.btBaoBieu.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btBaoBieu.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btBaoBieu.Location = new System.Drawing.Point(653, 48);
            this.btBaoBieu.Name = "btBaoBieu";
            this.btBaoBieu.Size = new System.Drawing.Size(80, 20);
            this.btBaoBieu.TabIndex = 142;
            this.btBaoBieu.Text = "Báo biểu";
            // 
            // cbxNhomMau
            // 
            this.cbxNhomMau.DisplayMember = "Text";
            this.cbxNhomMau.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxNhomMau.FormattingEnabled = true;
            this.cbxNhomMau.ItemHeight = 14;
            this.cbxNhomMau.Location = new System.Drawing.Point(460, 95);
            this.cbxNhomMau.Name = "cbxNhomMau";
            this.cbxNhomMau.Size = new System.Drawing.Size(176, 20);
            this.cbxNhomMau.TabIndex = 141;
            // 
            // rdSaved
            // 
            this.rdSaved.AutoSize = true;
            this.rdSaved.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.rdSaved.ForeColor = System.Drawing.Color.Navy;
            this.rdSaved.Location = new System.Drawing.Point(442, 71);
            this.rdSaved.Name = "rdSaved";
            this.rdSaved.Size = new System.Drawing.Size(195, 20);
            this.rdSaved.TabIndex = 99;
            this.rdSaved.Text = "Mở báo cáo đã lưu trước đây";
            this.rdSaved.UseVisualStyleBackColor = true;
            // 
            // rdFromDB
            // 
            this.rdFromDB.AutoSize = true;
            this.rdFromDB.Checked = true;
            this.rdFromDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.rdFromDB.ForeColor = System.Drawing.Color.Navy;
            this.rdFromDB.Location = new System.Drawing.Point(442, 51);
            this.rdFromDB.Name = "rdFromDB";
            this.rdFromDB.Size = new System.Drawing.Size(175, 20);
            this.rdFromDB.TabIndex = 98;
            this.rdFromDB.TabStop = true;
            this.rdFromDB.Text = "Tổng hợp từ cơ sở dữ liệu";
            this.rdFromDB.UseVisualStyleBackColor = true;
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            this.labelX4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.Location = new System.Drawing.Point(442, 121);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(84, 25);
            this.labelX4.TabIndex = 94;
            this.labelX4.Text = "Người Ký";
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(150, 170);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(192, 22);
            this.textBox4.TabIndex = 93;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(150, 145);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(192, 22);
            this.textBox3.TabIndex = 92;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(150, 120);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(192, 22);
            this.textBox2.TabIndex = 91;
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            this.labelX3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.Location = new System.Drawing.Point(44, 120);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(94, 25);
            this.labelX3.TabIndex = 90;
            this.labelX3.Text = "Người lập biểu";
            // 
            // dtNgay
            // 
            this.dtNgay.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtNgay.Checked = false;
            this.dtNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgay.Location = new System.Drawing.Point(150, 95);
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.Size = new System.Drawing.Size(85, 20);
            this.dtNgay.TabIndex = 89;
            // 
            // lblPassword
            // 
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(44, 70);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(86, 22);
            this.lblPassword.TabIndex = 12;
            this.lblPassword.Text = "Đối tượng";
            // 
            // lblUsername
            // 
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(44, 45);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(94, 22);
            this.lblUsername.TabIndex = 11;
            this.lblUsername.Text = "Tên đơn vị";
            // 
            // labelX1
            // 
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(106, 9);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(641, 34);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "BÁO CÁO LƯƠNG - QUỸ LƯƠNG";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // HoTenNhanVien
            // 
            this.HoTenNhanVien.DataPropertyName = "STT";
            this.HoTenNhanVien.HeaderText = "STT";
            this.HoTenNhanVien.Name = "HoTenNhanVien";
            // 
            // MaGioiTinh
            // 
            this.MaGioiTinh.DataPropertyName = "TenDonVi";
            this.MaGioiTinh.HeaderText = "Tên đơn vị";
            this.MaGioiTinh.Name = "MaGioiTinh";
            // 
            // MaChucVu
            // 
            this.MaChucVu.DataPropertyName = "MaChucVu";
            this.MaChucVu.HeaderText = "Chức Vụ";
            this.MaChucVu.Name = "MaChucVu";
            // 
            // MaDonVi
            // 
            this.MaDonVi.DataPropertyName = "MaDonVi";
            this.MaDonVi.HeaderText = "Đơn Vị";
            this.MaDonVi.Name = "MaDonVi";
            // 
            // MaLuongNhanVien
            // 
            this.MaLuongNhanVien.DataPropertyName = "MaLuongNhanVien";
            this.MaLuongNhanVien.HeaderText = "Mã Lương Nhân Viên";
            this.MaLuongNhanVien.Name = "MaLuongNhanVien";
            // 
            // MaNgach
            // 
            this.MaNgach.DataPropertyName = "MaNgach";
            this.MaNgach.HeaderText = "Ngạch Công Chức";
            this.MaNgach.Name = "MaNgach";
            // 
            // MaNgachCC
            // 
            this.MaNgachCC.DataPropertyName = "MaNgach";
            this.MaNgachCC.HeaderText = "Mã Ngạch";
            this.MaNgachCC.Name = "MaNgachCC";
            // 
            // BacLuong
            // 
            this.BacLuong.DataPropertyName = "BacLuong";
            this.BacLuong.HeaderText = "Bậc Lương";
            this.BacLuong.Name = "BacLuong";
            // 
            // HeSoLuong
            // 
            this.HeSoLuong.DataPropertyName = "HeSoLuong";
            this.HeSoLuong.HeaderText = "Hệ Số Lương";
            this.HeSoLuong.Name = "HeSoLuong";
            // 
            // Huong85
            // 
            this.Huong85.DataPropertyName = "LuongCongChucDuBi";
            this.Huong85.HeaderText = "Công Chức Dự Bị";
            this.Huong85.Name = "Huong85";
            // 
            // ChenhLechBaoLuuHeSoLuong
            // 
            this.ChenhLechBaoLuuHeSoLuong.DataPropertyName = "ChenhLechBaoLuuHeSoLuong";
            this.ChenhLechBaoLuuHeSoLuong.HeaderText = "Chênh Lệch Bảo Lưu Hệ Số Lương";
            this.ChenhLechBaoLuuHeSoLuong.Name = "ChenhLechBaoLuuHeSoLuong";
            // 
            // HuongLuongTuNgay
            // 
            this.HuongLuongTuNgay.DataPropertyName = "HuongLuongTuNgay";
            this.HuongLuongTuNgay.HeaderText = "Hưởng Lương Từ Ngày";
            this.HuongLuongTuNgay.Name = "HuongLuongTuNgay";
            // 
            // MocTinhNangLuongLanSau
            // 
            this.MocTinhNangLuongLanSau.DataPropertyName = "MocTinhNangLuongLanSau";
            this.MocTinhNangLuongLanSau.HeaderText = "Móc Tính Nâng Lương Lần Sau";
            this.MocTinhNangLuongLanSau.Name = "MocTinhNangLuongLanSau";
            // 
            // HeSoPhuCapChucVu
            // 
            this.HeSoPhuCapChucVu.DataPropertyName = "HeSoPhuCapChucVu";
            this.HeSoPhuCapChucVu.HeaderText = "Hệ Số Phụ Cấp Chức Vụ";
            this.HeSoPhuCapChucVu.Name = "HeSoPhuCapChucVu";
            // 
            // HeSoPhuCapThamNienVuotKhung
            // 
            this.HeSoPhuCapThamNienVuotKhung.DataPropertyName = "HeSoPhuCapThamNienVuotKhung";
            this.HeSoPhuCapThamNienVuotKhung.HeaderText = "Phụ Cấp Thâm Niên Vượt Khung";
            this.HeSoPhuCapThamNienVuotKhung.Name = "HeSoPhuCapThamNienVuotKhung";
            // 
            // HeSoPhuCapKiemNhiem
            // 
            this.HeSoPhuCapKiemNhiem.DataPropertyName = "HeSoPhuCapKiemNhiem";
            this.HeSoPhuCapKiemNhiem.HeaderText = "Hệ Số Phụ Cấp Kiêm nhiệm";
            this.HeSoPhuCapKiemNhiem.Name = "HeSoPhuCapKiemNhiem";
            // 
            // HeSoPhuCapKhac
            // 
            this.HeSoPhuCapKhac.DataPropertyName = "HeSoPhuCapKhac";
            this.HeSoPhuCapKhac.HeaderText = "Hệ Số Phụ Cấp Khác";
            this.HeSoPhuCapKhac.Name = "HeSoPhuCapKhac";
            // 
            // FrmBaoCaoLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 490);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.panelEx1);
            this.Name = "FrmBaoCaoLuong";
            this.Text = "Báo cáo lương";
            this.Load += new System.EventHandler(this.FrmBaoCaoLuong_Load);
            this.panelEx2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVLuong)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerLuong;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.LabelX lblPassword;
        private DevComponents.DotNetBar.LabelX lblUsername;
        private DevComponents.DotNetBar.LabelX labelX1;
        public System.Windows.Forms.TextBox textBox4;
        public System.Windows.Forms.TextBox textBox3;
        public System.Windows.Forms.TextBox textBox2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.DateTimePicker dtNgay;
        private DevComponents.DotNetBar.LabelX labelX4;
        private System.Windows.Forms.RadioButton rdFromDB;
        private System.Windows.Forms.RadioButton rdSaved;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbxNhomMau;
        private DevComponents.DotNetBar.ButtonX btBaoBieu;
        private DevComponents.DotNetBar.ButtonX btInBieu;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX btLuuBieu;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbDonVi;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbKy;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.Editors.ComboItem comboItem5;
        private DevComponents.Editors.ComboItem comboItem6;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbDoiTuong;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TextBox textBox5;
        public System.Windows.Forms.TextBox textBox6;
        private DevComponents.DotNetBar.Controls.DataGridViewX DGVLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTenNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaGioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaChucVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDonVi;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLuongNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNgach;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNgachCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn BacLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Huong85;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChenhLechBaoLuuHeSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn HuongLuongTuNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn MocTinhNangLuongLanSau;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeSoPhuCapChucVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeSoPhuCapThamNienVuotKhung;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeSoPhuCapKiemNhiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeSoPhuCapKhac;
    }
}