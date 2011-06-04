namespace QuanLyHoSoCongChuc
{
    partial class FrmThemDanhMucHanhChinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmThemDanhMucHanhChinh));
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.cmbTinhThanh = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbQuanHuyen = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbPhuongXa = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtMaTinhThanh = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtMaQuanHuyen = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtMaPhuongXa = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnThoat = new DevComponents.DotNetBar.ButtonX();
            this.btnThemTinhThanh = new System.Windows.Forms.Button();
            this.btnThemQuanHuyen = new System.Windows.Forms.Button();
            this.btnThemPhuongXa = new System.Windows.Forms.Button();
            this.btnLuuTinhThanh = new System.Windows.Forms.Button();
            this.btnLuuQuanHuyen = new System.Windows.Forms.Button();
            this.btnLuuPhuongXa = new System.Windows.Forms.Button();
            this.btnXoaTinhThanh = new System.Windows.Forms.Button();
            this.btnXoaQuanHuyen = new System.Windows.Forms.Button();
            this.btnXoaPhuongXa = new System.Windows.Forms.Button();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.Location = new System.Drawing.Point(17, 83);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 20);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Tên tỉnh thành";
            // 
            // labelX2
            // 
            this.labelX2.Location = new System.Drawing.Point(17, 126);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 20);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "Quận / Huyện";
            // 
            // labelX3
            // 
            this.labelX3.Location = new System.Drawing.Point(17, 168);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 20);
            this.labelX3.TabIndex = 2;
            this.labelX3.Text = "Phường, xã";
            // 
            // cmbTinhThanh
            // 
            this.cmbTinhThanh.DisplayMember = "Text";
            this.cmbTinhThanh.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTinhThanh.FormattingEnabled = true;
            this.cmbTinhThanh.ItemHeight = 14;
            this.cmbTinhThanh.Location = new System.Drawing.Point(156, 83);
            this.cmbTinhThanh.Name = "cmbTinhThanh";
            this.cmbTinhThanh.Size = new System.Drawing.Size(177, 20);
            this.cmbTinhThanh.TabIndex = 4;
            this.cmbTinhThanh.SelectedIndexChanged += new System.EventHandler(this.cmbTinhThanh_SelectedIndexChanged);
            // 
            // cmbQuanHuyen
            // 
            this.cmbQuanHuyen.DisplayMember = "Text";
            this.cmbQuanHuyen.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbQuanHuyen.FormattingEnabled = true;
            this.cmbQuanHuyen.ItemHeight = 14;
            this.cmbQuanHuyen.Location = new System.Drawing.Point(156, 126);
            this.cmbQuanHuyen.Name = "cmbQuanHuyen";
            this.cmbQuanHuyen.Size = new System.Drawing.Size(177, 20);
            this.cmbQuanHuyen.TabIndex = 5;
            this.cmbQuanHuyen.SelectedIndexChanged += new System.EventHandler(this.cmbQuanHuyen_SelectedIndexChanged);
            // 
            // cmbPhuongXa
            // 
            this.cmbPhuongXa.DisplayMember = "Text";
            this.cmbPhuongXa.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPhuongXa.FormattingEnabled = true;
            this.cmbPhuongXa.ItemHeight = 14;
            this.cmbPhuongXa.Location = new System.Drawing.Point(156, 168);
            this.cmbPhuongXa.Name = "cmbPhuongXa";
            this.cmbPhuongXa.Size = new System.Drawing.Size(177, 20);
            this.cmbPhuongXa.TabIndex = 6;
            this.cmbPhuongXa.SelectedIndexChanged += new System.EventHandler(this.cmbPhuongXa_SelectedIndexChanged);
            // 
            // txtMaTinhThanh
            // 
            // 
            // 
            // 
            this.txtMaTinhThanh.Border.Class = "TextBoxBorder";
            this.txtMaTinhThanh.Location = new System.Drawing.Point(106, 83);
            this.txtMaTinhThanh.Name = "txtMaTinhThanh";
            this.txtMaTinhThanh.Size = new System.Drawing.Size(44, 20);
            this.txtMaTinhThanh.TabIndex = 8;
            // 
            // txtMaQuanHuyen
            // 
            // 
            // 
            // 
            this.txtMaQuanHuyen.Border.Class = "TextBoxBorder";
            this.txtMaQuanHuyen.Location = new System.Drawing.Point(106, 126);
            this.txtMaQuanHuyen.Name = "txtMaQuanHuyen";
            this.txtMaQuanHuyen.Size = new System.Drawing.Size(44, 20);
            this.txtMaQuanHuyen.TabIndex = 9;
            // 
            // txtMaPhuongXa
            // 
            // 
            // 
            // 
            this.txtMaPhuongXa.Border.Class = "TextBoxBorder";
            this.txtMaPhuongXa.Location = new System.Drawing.Point(106, 168);
            this.txtMaPhuongXa.Name = "txtMaPhuongXa";
            this.txtMaPhuongXa.Size = new System.Drawing.Size(44, 20);
            this.txtMaPhuongXa.TabIndex = 10;
            // 
            // btnThoat
            // 
            this.btnThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThoat.Location = new System.Drawing.Point(193, 209);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(86, 30);
            this.btnThoat.TabIndex = 12;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnThemTinhThanh
            // 
            this.btnThemTinhThanh.Image = ((System.Drawing.Image)(resources.GetObject("btnThemTinhThanh.Image")));
            this.btnThemTinhThanh.Location = new System.Drawing.Point(350, 80);
            this.btnThemTinhThanh.Name = "btnThemTinhThanh";
            this.btnThemTinhThanh.Size = new System.Drawing.Size(28, 27);
            this.btnThemTinhThanh.TabIndex = 13;
            this.btnThemTinhThanh.UseVisualStyleBackColor = true;
            this.btnThemTinhThanh.Click += new System.EventHandler(this.btnThemTinhThanh_Click);
            // 
            // btnThemQuanHuyen
            // 
            this.btnThemQuanHuyen.Image = ((System.Drawing.Image)(resources.GetObject("btnThemQuanHuyen.Image")));
            this.btnThemQuanHuyen.Location = new System.Drawing.Point(350, 123);
            this.btnThemQuanHuyen.Name = "btnThemQuanHuyen";
            this.btnThemQuanHuyen.Size = new System.Drawing.Size(28, 27);
            this.btnThemQuanHuyen.TabIndex = 14;
            this.btnThemQuanHuyen.UseVisualStyleBackColor = true;
            this.btnThemQuanHuyen.Click += new System.EventHandler(this.btnThemQuanHuyen_Click);
            // 
            // btnThemPhuongXa
            // 
            this.btnThemPhuongXa.Image = ((System.Drawing.Image)(resources.GetObject("btnThemPhuongXa.Image")));
            this.btnThemPhuongXa.Location = new System.Drawing.Point(350, 165);
            this.btnThemPhuongXa.Name = "btnThemPhuongXa";
            this.btnThemPhuongXa.Size = new System.Drawing.Size(28, 27);
            this.btnThemPhuongXa.TabIndex = 15;
            this.btnThemPhuongXa.UseVisualStyleBackColor = true;
            this.btnThemPhuongXa.Click += new System.EventHandler(this.btnThemPhuongXa_Click);
            // 
            // btnLuuTinhThanh
            // 
            this.btnLuuTinhThanh.Image = ((System.Drawing.Image)(resources.GetObject("btnLuuTinhThanh.Image")));
            this.btnLuuTinhThanh.Location = new System.Drawing.Point(384, 80);
            this.btnLuuTinhThanh.Name = "btnLuuTinhThanh";
            this.btnLuuTinhThanh.Size = new System.Drawing.Size(28, 27);
            this.btnLuuTinhThanh.TabIndex = 17;
            this.btnLuuTinhThanh.UseVisualStyleBackColor = true;
            this.btnLuuTinhThanh.Click += new System.EventHandler(this.btnLuuTinhThanh_Click);
            // 
            // btnLuuQuanHuyen
            // 
            this.btnLuuQuanHuyen.Image = ((System.Drawing.Image)(resources.GetObject("btnLuuQuanHuyen.Image")));
            this.btnLuuQuanHuyen.Location = new System.Drawing.Point(384, 123);
            this.btnLuuQuanHuyen.Name = "btnLuuQuanHuyen";
            this.btnLuuQuanHuyen.Size = new System.Drawing.Size(28, 27);
            this.btnLuuQuanHuyen.TabIndex = 18;
            this.btnLuuQuanHuyen.UseVisualStyleBackColor = true;
            this.btnLuuQuanHuyen.Click += new System.EventHandler(this.btnLuuQuanHuyen_Click);
            // 
            // btnLuuPhuongXa
            // 
            this.btnLuuPhuongXa.Image = ((System.Drawing.Image)(resources.GetObject("btnLuuPhuongXa.Image")));
            this.btnLuuPhuongXa.Location = new System.Drawing.Point(384, 165);
            this.btnLuuPhuongXa.Name = "btnLuuPhuongXa";
            this.btnLuuPhuongXa.Size = new System.Drawing.Size(28, 27);
            this.btnLuuPhuongXa.TabIndex = 19;
            this.btnLuuPhuongXa.UseVisualStyleBackColor = true;
            this.btnLuuPhuongXa.Click += new System.EventHandler(this.btnLuuPhuongXa_Click);
            // 
            // btnXoaTinhThanh
            // 
            this.btnXoaTinhThanh.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaTinhThanh.Image")));
            this.btnXoaTinhThanh.Location = new System.Drawing.Point(418, 80);
            this.btnXoaTinhThanh.Name = "btnXoaTinhThanh";
            this.btnXoaTinhThanh.Size = new System.Drawing.Size(28, 27);
            this.btnXoaTinhThanh.TabIndex = 21;
            this.btnXoaTinhThanh.UseVisualStyleBackColor = true;
            this.btnXoaTinhThanh.Click += new System.EventHandler(this.btnXoaTinhThanh_Click);
            // 
            // btnXoaQuanHuyen
            // 
            this.btnXoaQuanHuyen.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaQuanHuyen.Image")));
            this.btnXoaQuanHuyen.Location = new System.Drawing.Point(418, 123);
            this.btnXoaQuanHuyen.Name = "btnXoaQuanHuyen";
            this.btnXoaQuanHuyen.Size = new System.Drawing.Size(28, 27);
            this.btnXoaQuanHuyen.TabIndex = 22;
            this.btnXoaQuanHuyen.UseVisualStyleBackColor = true;
            this.btnXoaQuanHuyen.Click += new System.EventHandler(this.btnXoaQuanHuyen_Click);
            // 
            // btnXoaPhuongXa
            // 
            this.btnXoaPhuongXa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaPhuongXa.Image")));
            this.btnXoaPhuongXa.Location = new System.Drawing.Point(418, 167);
            this.btnXoaPhuongXa.Name = "btnXoaPhuongXa";
            this.btnXoaPhuongXa.Size = new System.Drawing.Size(28, 27);
            this.btnXoaPhuongXa.TabIndex = 23;
            this.btnXoaPhuongXa.UseVisualStyleBackColor = true;
            this.btnXoaPhuongXa.Click += new System.EventHandler(this.btnXoaPhuongXa_Click);
            // 
            // labelX5
            // 
            this.labelX5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX5.Location = new System.Drawing.Point(44, 12);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(368, 58);
            this.labelX5.TabIndex = 25;
            this.labelX5.Text = "THÊM DANH MỤC HÀNH CHÍNH";
            // 
            // FrmThemDanhMucHanhChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(452, 251);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.btnXoaPhuongXa);
            this.Controls.Add(this.btnXoaQuanHuyen);
            this.Controls.Add(this.btnXoaTinhThanh);
            this.Controls.Add(this.btnLuuPhuongXa);
            this.Controls.Add(this.btnLuuQuanHuyen);
            this.Controls.Add(this.btnLuuTinhThanh);
            this.Controls.Add(this.btnThemPhuongXa);
            this.Controls.Add(this.btnThemQuanHuyen);
            this.Controls.Add(this.btnThemTinhThanh);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.txtMaPhuongXa);
            this.Controls.Add(this.txtMaQuanHuyen);
            this.Controls.Add(this.txtMaTinhThanh);
            this.Controls.Add(this.cmbPhuongXa);
            this.Controls.Add(this.cmbQuanHuyen);
            this.Controls.Add(this.cmbTinhThanh);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmThemDanhMucHanhChinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm Danh Mục Hành Chính";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmThemDanhMucHanhChinh_FormClosed);
            this.Load += new System.EventHandler(this.FrmThemDanhMucHanhChinh_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbTinhThanh;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbQuanHuyen;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbPhuongXa;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaTinhThanh;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaQuanHuyen;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaPhuongXa;
        private DevComponents.DotNetBar.ButtonX btnThoat;
        private System.Windows.Forms.Button btnThemTinhThanh;
        private System.Windows.Forms.Button btnThemQuanHuyen;
        private System.Windows.Forms.Button btnThemPhuongXa;
        private System.Windows.Forms.Button btnLuuTinhThanh;
        private System.Windows.Forms.Button btnLuuQuanHuyen;
        private System.Windows.Forms.Button btnLuuPhuongXa;
        private System.Windows.Forms.Button btnXoaTinhThanh;
        private System.Windows.Forms.Button btnXoaQuanHuyen;
        private System.Windows.Forms.Button btnXoaPhuongXa;
        private DevComponents.DotNetBar.LabelX labelX5;
    }
}