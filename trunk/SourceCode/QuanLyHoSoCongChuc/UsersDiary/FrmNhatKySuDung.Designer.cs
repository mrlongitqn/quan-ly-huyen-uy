namespace QuanLyHoSoCongChuc.UsersDiary
{
    partial class FrmNhatKySuDung
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDong = new DevComponents.DotNetBar.ButtonX();
            this.btnTim = new DevComponents.DotNetBar.ButtonX();
            this.btnXoa = new DevComponents.DotNetBar.ButtonX();
            this.btnIn = new DevComponents.DotNetBar.ButtonX();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstvNhatKySuDung = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstvChucNangSuDung = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDong);
            this.panel1.Controls.Add(this.btnTim);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnIn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 542);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(860, 51);
            this.panel1.TabIndex = 0;
            // 
            // btnDong
            // 
            this.btnDong.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDong.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDong.Image = global::QuanLyHoSoCongChuc.Properties.Resources.exit;
            this.btnDong.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnDong.Location = new System.Drawing.Point(567, 14);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 23);
            this.btnDong.TabIndex = 19;
            this.btnDong.Text = "Đóng";
            // 
            // btnTim
            // 
            this.btnTim.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTim.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnTim.Image = global::QuanLyHoSoCongChuc.Properties.Resources.find;
            this.btnTim.Location = new System.Drawing.Point(236, 14);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(81, 23);
            this.btnTim.TabIndex = 18;
            this.btnTim.Text = "Tìm";
            // 
            // btnXoa
            // 
            this.btnXoa.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXoa.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnXoa.Image = global::QuanLyHoSoCongChuc.Properties.Resources._001_29;
            this.btnXoa.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.btnXoa.Location = new System.Drawing.Point(458, 14);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(72, 23);
            this.btnXoa.TabIndex = 17;
            this.btnXoa.Text = "Xóa";
            // 
            // btnIn
            // 
            this.btnIn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnIn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnIn.Image = global::QuanLyHoSoCongChuc.Properties.Resources.action_print;
            this.btnIn.ImageFixedSize = new System.Drawing.Size(16, 20);
            this.btnIn.Location = new System.Drawing.Point(356, 14);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(79, 23);
            this.btnIn.TabIndex = 15;
            this.btnIn.Text = "In";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstvNhatKySuDung);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lstvChucNangSuDung);
            this.splitContainer1.Size = new System.Drawing.Size(860, 542);
            this.splitContainer1.SplitterDistance = 574;
            this.splitContainer1.TabIndex = 1;
            // 
            // lstvNhatKySuDung
            // 
            // 
            // 
            // 
            this.lstvNhatKySuDung.Border.Class = "ListViewBorder";
            this.lstvNhatKySuDung.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lstvNhatKySuDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstvNhatKySuDung.Location = new System.Drawing.Point(0, 0);
            this.lstvNhatKySuDung.Name = "lstvNhatKySuDung";
            this.lstvNhatKySuDung.Size = new System.Drawing.Size(574, 542);
            this.lstvNhatKySuDung.TabIndex = 0;
            this.lstvNhatKySuDung.UseCompatibleStateImageBehavior = false;
            this.lstvNhatKySuDung.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "STT";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên truy cập";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Ngày giờ vào";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Ngày giờ ra";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Tên máy trạm";
            this.columnHeader5.Width = 165;
            // 
            // lstvChucNangSuDung
            // 
            // 
            // 
            // 
            this.lstvChucNangSuDung.Border.Class = "ListViewBorder";
            this.lstvChucNangSuDung.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lstvChucNangSuDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstvChucNangSuDung.Location = new System.Drawing.Point(0, 0);
            this.lstvChucNangSuDung.Name = "lstvChucNangSuDung";
            this.lstvChucNangSuDung.Size = new System.Drawing.Size(282, 542);
            this.lstvChucNangSuDung.TabIndex = 0;
            this.lstvChucNangSuDung.UseCompatibleStateImageBehavior = false;
            this.lstvChucNangSuDung.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "STT";
            this.columnHeader6.Width = 40;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Các chức năng sử dụng";
            this.columnHeader7.Width = 160;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Số lần";
            // 
            // FrmNhatKySuDung
            // 
            this.ClientSize = new System.Drawing.Size(860, 593);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmNhatKySuDung";
            this.Text = "Nhật ký sử dụng";
            this.Load += new System.EventHandler(this.FrmNhatKySuDung_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevComponents.DotNetBar.Controls.ListViewEx lstvNhatKySuDung;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private DevComponents.DotNetBar.Controls.ListViewEx lstvChucNangSuDung;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private DevComponents.DotNetBar.ButtonX btnTim;
        private DevComponents.DotNetBar.ButtonX btnXoa;
        private DevComponents.DotNetBar.ButtonX btnIn;
        private DevComponents.DotNetBar.ButtonX btnDong;

    }
}