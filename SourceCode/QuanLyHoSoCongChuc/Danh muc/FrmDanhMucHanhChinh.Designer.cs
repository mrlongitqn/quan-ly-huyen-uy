namespace QuanLyHoSoCongChuc.Danh_muc
{
    partial class FrmDanhMucHanhChinh
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDanhMucHanhChinh));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.treeviewDMHC = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtMaDiaDanh = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtTenDayDu = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtTenDiaDanh = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblPassword = new DevComponents.DotNetBar.LabelX();
            this.lblUsername = new DevComponents.DotNetBar.LabelX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnChon = new DevComponents.DotNetBar.ButtonX();
            this.btnCapNhat = new DevComponents.DotNetBar.ButtonX();
            this.btnXoa = new DevComponents.DotNetBar.ButtonX();
            this.btnThem = new DevComponents.DotNetBar.ButtonX();
            this.btnThoat = new DevComponents.DotNetBar.ButtonX();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(447, 562);
            this.panel2.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.treeviewDMHC);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 105);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(447, 457);
            this.panel4.TabIndex = 4;
            // 
            // treeviewDMHC
            // 
            this.treeviewDMHC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeviewDMHC.ImageIndex = 0;
            this.treeviewDMHC.ImageList = this.imageList1;
            this.treeviewDMHC.Location = new System.Drawing.Point(0, 0);
            this.treeviewDMHC.Name = "treeviewDMHC";
            this.treeviewDMHC.SelectedImageIndex = 4;
            this.treeviewDMHC.Size = new System.Drawing.Size(447, 457);
            this.treeviewDMHC.TabIndex = 3;
            this.treeviewDMHC.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeviewDMHC_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "book_red.ico");
            this.imageList1.Images.SetKeyName(1, "tinhthanh.gif");
            this.imageList1.Images.SetKeyName(2, "quanhuyen.jpg");
            this.imageList1.Images.SetKeyName(3, "houses.ico");
            this.imageList1.Images.SetKeyName(4, "81.png");
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtMaDiaDanh);
            this.panel3.Controls.Add(this.txtTenDayDu);
            this.panel3.Controls.Add(this.labelX1);
            this.panel3.Controls.Add(this.txtTenDiaDanh);
            this.panel3.Controls.Add(this.lblPassword);
            this.panel3.Controls.Add(this.lblUsername);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(447, 105);
            this.panel3.TabIndex = 3;
            // 
            // txtMaDiaDanh
            // 
            // 
            // 
            // 
            this.txtMaDiaDanh.Border.Class = "TextBoxBorder";
            this.txtMaDiaDanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaDiaDanh.Location = new System.Drawing.Point(108, 14);
            this.txtMaDiaDanh.Name = "txtMaDiaDanh";
            this.txtMaDiaDanh.Size = new System.Drawing.Size(101, 20);
            this.txtMaDiaDanh.TabIndex = 159;
            // 
            // txtTenDayDu
            // 
            // 
            // 
            // 
            this.txtTenDayDu.Border.Class = "TextBoxBorder";
            this.txtTenDayDu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDayDu.Location = new System.Drawing.Point(108, 68);
            this.txtTenDayDu.Name = "txtTenDayDu";
            this.txtTenDayDu.Size = new System.Drawing.Size(289, 20);
            this.txtTenDayDu.TabIndex = 158;
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(12, 67);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(90, 22);
            this.labelX1.TabIndex = 157;
            this.labelX1.Text = "Tên đầy đủ";
            // 
            // txtTenDiaDanh
            // 
            // 
            // 
            // 
            this.txtTenDiaDanh.Border.Class = "TextBoxBorder";
            this.txtTenDiaDanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDiaDanh.Location = new System.Drawing.Point(108, 42);
            this.txtTenDiaDanh.Name = "txtTenDiaDanh";
            this.txtTenDiaDanh.Size = new System.Drawing.Size(188, 20);
            this.txtTenDiaDanh.TabIndex = 156;
            // 
            // lblPassword
            // 
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(12, 41);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(90, 22);
            this.lblPassword.TabIndex = 154;
            this.lblPassword.Text = "Tên địa danh";
            // 
            // lblUsername
            // 
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(12, 12);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(90, 22);
            this.lblUsername.TabIndex = 153;
            this.lblUsername.Text = "Mã địa danh";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnChon);
            this.panel1.Controls.Add(this.btnCapNhat);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 519);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(447, 43);
            this.panel1.TabIndex = 9;
            // 
            // btnChon
            // 
            this.btnChon.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnChon.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnChon.Image = global::QuanLyHoSoCongChuc.Properties.Resources.Sign_Select_icon1;
            this.btnChon.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnChon.Location = new System.Drawing.Point(12, 8);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(75, 23);
            this.btnChon.TabIndex = 10;
            this.btnChon.Text = "Chọn";
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCapNhat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCapNhat.Image = global::QuanLyHoSoCongChuc.Properties.Resources._45;
            this.btnCapNhat.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.btnCapNhat.Location = new System.Drawing.Point(266, 8);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(75, 23);
            this.btnCapNhat.TabIndex = 9;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnXoa.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnXoa.Image = global::QuanLyHoSoCongChuc.Properties.Resources._001_29;
            this.btnXoa.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnXoa.Location = new System.Drawing.Point(185, 8);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 8;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThem.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThem.Image = global::QuanLyHoSoCongChuc.Properties.Resources._001_01;
            this.btnThem.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnThem.Location = new System.Drawing.Point(104, 8);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThoat.Image = global::QuanLyHoSoCongChuc.Properties.Resources.exit;
            this.btnThoat.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnThoat.Location = new System.Drawing.Point(360, 8);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // FrmDanhMucHanhChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(447, 562);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDanhMucHanhChinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh Mục Hành Chính";
            this.Load += new System.EventHandler(this.FrmDanhMucHanhChinh_Load);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TreeView treeviewDMHC;
        private System.Windows.Forms.Panel panel3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaDiaDanh;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTenDayDu;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTenDiaDanh;
        private DevComponents.DotNetBar.LabelX lblPassword;
        private DevComponents.DotNetBar.LabelX lblUsername;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX btnThem;
        private DevComponents.DotNetBar.ButtonX btnThoat;
        private DevComponents.DotNetBar.ButtonX btnCapNhat;
        private DevComponents.DotNetBar.ButtonX btnXoa;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.ButtonX btnChon;



    }
}