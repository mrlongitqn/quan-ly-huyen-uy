namespace QuanLyHoSoCongChuc
{
    partial class FrmDanhSachNhanVien
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
            this.DGVLuong = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.MaNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaGioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaChucVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDonVi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLuongNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SYLL = new System.Windows.Forms.DataGridViewLinkColumn();
            this.NghiHuu = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGVLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVLuong
            // 
            this.DGVLuong.AllowUserToAddRows = false;
            this.DGVLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVLuong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNhanVien,
            this.HoTenNhanVien,
            this.MaGioiTinh,
            this.MaChucVu,
            this.MaDonVi,
            this.MaLuongNhanVien,
            this.SYLL,
            this.NghiHuu});
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
            this.DGVLuong.Location = new System.Drawing.Point(0, 79);
            this.DGVLuong.Name = "DGVLuong";
            this.DGVLuong.Size = new System.Drawing.Size(844, 195);
            this.DGVLuong.TabIndex = 2;
            this.DGVLuong.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVLuong_CellContentClick);
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
            // SYLL
            // 
            this.SYLL.HeaderText = "Sơ yếu lí lịch";
            this.SYLL.Name = "SYLL";
            this.SYLL.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SYLL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // NghiHuu
            // 
            this.NghiHuu.HeaderText = "Nghỉ Hưu";
            this.NghiHuu.Name = "NghiHuu";
            // 
            // FrmDanhSachNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 274);
            this.Controls.Add(this.DGVLuong);
            this.Name = "FrmDanhSachNhanVien";
            this.Text = "FrmDanhSachNhanVien";
            this.Load += new System.EventHandler(this.FrmDanhSachNhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVLuong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX DGVLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTenNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaGioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaChucVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDonVi;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLuongNhanVien;
        private System.Windows.Forms.DataGridViewLinkColumn SYLL;
        private System.Windows.Forms.DataGridViewLinkColumn NghiHuu;

    }
}