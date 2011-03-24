namespace QuanLyHoSoCongChuc
{
    partial class FrmTimKiem2
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtFrm = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.cbo1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DGVLuong = new DevComponents.DotNetBar.Controls.DataGridViewX();
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
            ((System.ComponentModel.ISupportInitialize)(this.DGVLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(374, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Tìm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtFrm
            // 
            this.txtFrm.Location = new System.Drawing.Point(97, 78);
            this.txtFrm.Name = "txtFrm";
            this.txtFrm.Size = new System.Drawing.Size(100, 20);
            this.txtFrm.TabIndex = 1;
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(250, 76);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(100, 20);
            this.txtTo.TabIndex = 2;
            // 
            // cbo1
            // 
            this.cbo1.FormattingEnabled = true;
            this.cbo1.Items.AddRange(new object[] {
            "---",
            "Số năm công tác",
            "Độ tuổi"});
            this.cbo1.Location = new System.Drawing.Point(149, 26);
            this.cbo1.Name = "cbo1";
            this.cbo1.Size = new System.Drawing.Size(121, 21);
            this.cbo1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tìm kiếm theo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Từ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(215, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "~";
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
            this.DGVLuong.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DGVLuong.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.DGVLuong.Location = new System.Drawing.Point(0, 190);
            this.DGVLuong.Name = "DGVLuong";
            this.DGVLuong.Size = new System.Drawing.Size(691, 254);
            this.DGVLuong.TabIndex = 7;
            // 
            // HoTenNhanVien
            // 
            this.HoTenNhanVien.DataPropertyName = "HoTenNhanVien";
            this.HoTenNhanVien.HeaderText = "Họ Tên Nhân Viên";
            this.HoTenNhanVien.Name = "HoTenNhanVien";
            // 
            // MaGioiTinh
            // 
            this.MaGioiTinh.DataPropertyName = "MaGioiTinh";
            this.MaGioiTinh.HeaderText = "Giới Tính";
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
            // FrmTimKiem2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 444);
            this.Controls.Add(this.DGVLuong);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbo1);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.txtFrm);
            this.Controls.Add(this.button1);
            this.Name = "FrmTimKiem2";
            this.Text = "FrmTimKiem2";
            ((System.ComponentModel.ISupportInitialize)(this.DGVLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtFrm;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.ComboBox cbo1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
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