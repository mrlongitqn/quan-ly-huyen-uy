namespace QuanLyHoSoCongChuc.Search
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.txtFrm = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.cbo1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DGVLuong = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.MaNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayHopDong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaGioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaChucVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDonVi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLuongNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.txtFrm.Enabled = false;
            this.txtFrm.Location = new System.Drawing.Point(97, 78);
            this.txtFrm.Name = "txtFrm";
            this.txtFrm.Size = new System.Drawing.Size(100, 20);
            this.txtFrm.TabIndex = 1;
            // 
            // txtTo
            // 
            this.txtTo.Enabled = false;
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
            this.cbo1.SelectedIndexChanged += new System.EventHandler(this.cbo1_SelectedIndexChanged);
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
            this.MaNhanVien,
            this.HoTenNhanVien,
            this.NgaySinh,
            this.NgayHopDong,
            this.MaGioiTinh,
            this.MaChucVu,
            this.MaDonVi,
            this.MaLuongNhanVien});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVLuong.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGVLuong.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DGVLuong.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.DGVLuong.Location = new System.Drawing.Point(0, 198);
            this.DGVLuong.Name = "DGVLuong";
            this.DGVLuong.Size = new System.Drawing.Size(691, 246);
            this.DGVLuong.TabIndex = 7;
            // 
            // MaNhanVien
            // 
            this.MaNhanVien.DataPropertyName = "MaNhanVien";
            this.MaNhanVien.HeaderText = "Mã NV";
            this.MaNhanVien.Name = "MaNhanVien";
            // 
            // HoTenNhanVien
            // 
            this.HoTenNhanVien.DataPropertyName = "HoTenNhanVien";
            this.HoTenNhanVien.HeaderText = "Họ tên nhân viên";
            this.HoTenNhanVien.Name = "HoTenNhanVien";
            // 
            // NgaySinh
            // 
            this.NgaySinh.DataPropertyName = "NgaySinh";
            this.NgaySinh.HeaderText = "Ngày sinh";
            this.NgaySinh.Name = "NgaySinh";
            // 
            // NgayHopDong
            // 
            this.NgayHopDong.DataPropertyName = "NgayHopDong";
            this.NgayHopDong.HeaderText = "Ngày hợp đồng";
            this.NgayHopDong.Name = "NgayHopDong";
            // 
            // MaGioiTinh
            // 
            this.MaGioiTinh.DataPropertyName = "MaGioiTinh";
            this.MaGioiTinh.HeaderText = "Giới tính";
            this.MaGioiTinh.Name = "MaGioiTinh";
            // 
            // MaChucVu
            // 
            this.MaChucVu.DataPropertyName = "MaChucVu";
            this.MaChucVu.HeaderText = "Chức vụ";
            this.MaChucVu.Name = "MaChucVu";
            // 
            // MaDonVi
            // 
            this.MaDonVi.DataPropertyName = "MaDonVi";
            this.MaDonVi.HeaderText = "Đơn vị";
            this.MaDonVi.Name = "MaDonVi";
            // 
            // MaLuongNhanVien
            // 
            this.MaLuongNhanVien.DataPropertyName = "MaLuongNhanVien";
            this.MaLuongNhanVien.HeaderText = "Mã lương nhân viên";
            this.MaLuongNhanVien.Name = "MaLuongNhanVien";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTenNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayHopDong;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaGioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaChucVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDonVi;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLuongNhanVien;
    }
}