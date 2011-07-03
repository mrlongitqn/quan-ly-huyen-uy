namespace QuanLyHoSoCongChuc.Search
{
    partial class FrmMoCauHoi
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
            this.btChon = new DevComponents.DotNetBar.ButtonX();
            this.lstvCauHoi = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnXoa = new DevComponents.DotNetBar.ButtonX();
            this.btnThoat = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // btChon
            // 
            this.btChon.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btChon.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btChon.Location = new System.Drawing.Point(12, 330);
            this.btChon.Name = "btChon";
            this.btChon.Size = new System.Drawing.Size(64, 23);
            this.btChon.TabIndex = 42;
            this.btChon.Text = "Chọn";
            this.btChon.Click += new System.EventHandler(this.btChon_Click);
            // 
            // lstvCauHoi
            // 
            // 
            // 
            // 
            this.lstvCauHoi.Border.Class = "ListViewBorder";
            this.lstvCauHoi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstvCauHoi.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstvCauHoi.FullRowSelect = true;
            this.lstvCauHoi.GridLines = true;
            this.lstvCauHoi.Location = new System.Drawing.Point(0, 0);
            this.lstvCauHoi.MultiSelect = false;
            this.lstvCauHoi.Name = "lstvCauHoi";
            this.lstvCauHoi.Size = new System.Drawing.Size(292, 313);
            this.lstvCauHoi.TabIndex = 43;
            this.lstvCauHoi.UseCompatibleStateImageBehavior = false;
            this.lstvCauHoi.View = System.Windows.Forms.View.Details;
            this.lstvCauHoi.DoubleClick += new System.EventHandler(this.lstvCauHoi_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "STT";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên câu hỏi";
            this.columnHeader2.Width = 230;
            // 
            // btnXoa
            // 
            this.btnXoa.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnXoa.Image = global::QuanLyHoSoCongChuc.Properties.Resources._001_29;
            this.btnXoa.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.btnXoa.Location = new System.Drawing.Point(117, 330);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(72, 23);
            this.btnXoa.TabIndex = 41;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThoat.Image = global::QuanLyHoSoCongChuc.Properties.Resources.exit;
            this.btnThoat.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnThoat.Location = new System.Drawing.Point(205, 330);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 40;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // FrmMoCauHoi
            // 
            this.ClientSize = new System.Drawing.Size(292, 365);
            this.Controls.Add(this.lstvCauHoi);
            this.Controls.Add(this.btChon);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThoat);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMoCauHoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMoCauHoi";
            this.Load += new System.EventHandler(this.FrmMoCauHoi_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnThoat;
        private DevComponents.DotNetBar.ButtonX btnXoa;
        private DevComponents.DotNetBar.ButtonX btChon;
        private DevComponents.DotNetBar.Controls.ListViewEx lstvCauHoi;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}