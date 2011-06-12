namespace QuanLyHoSoCongChuc.DataManager
{
    partial class FrmTimNhanVien
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
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnThoat = new DevComponents.DotNetBar.ButtonX();
            this.btChon = new DevComponents.DotNetBar.ButtonX();
            this.lstvNhanVien = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.btnThoat);
            this.groupPanel1.Controls.Add(this.btChon);
            this.groupPanel1.Controls.Add(this.lstvNhanVien);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(325, 476);
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
            this.groupPanel1.TabIndex = 1;
            // 
            // btnThoat
            // 
            this.btnThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThoat.Image = global::QuanLyHoSoCongChuc.Properties.Resources.exit;
            this.btnThoat.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnThoat.Location = new System.Drawing.Point(227, 438);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 160;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btChon
            // 
            this.btChon.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btChon.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btChon.Image = global::QuanLyHoSoCongChuc.Properties.Resources.Sign_Select_icon;
            this.btChon.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btChon.Location = new System.Drawing.Point(146, 438);
            this.btChon.Name = "btChon";
            this.btChon.Size = new System.Drawing.Size(75, 23);
            this.btChon.TabIndex = 159;
            this.btChon.Text = "Chọn";
            this.btChon.Click += new System.EventHandler(this.btChon_Click);
            // 
            // lstvNhanVien
            // 
            // 
            // 
            // 
            this.lstvNhanVien.Border.Class = "ListViewBorder";
            this.lstvNhanVien.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader2});
            this.lstvNhanVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstvNhanVien.FullRowSelect = true;
            this.lstvNhanVien.GridLines = true;
            this.lstvNhanVien.Location = new System.Drawing.Point(0, 0);
            this.lstvNhanVien.MultiSelect = false;
            this.lstvNhanVien.Name = "lstvNhanVien";
            this.lstvNhanVien.Size = new System.Drawing.Size(319, 429);
            this.lstvNhanVien.TabIndex = 158;
            this.lstvNhanVien.UseCompatibleStateImageBehavior = false;
            this.lstvNhanVien.View = System.Windows.Forms.View.Details;
            this.lstvNhanVien.DoubleClick += new System.EventHandler(this.lstvCanBo_DoubleClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "STT";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 40;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Mã nhân viên";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Họ tên";
            this.columnHeader2.Width = 150;
            // 
            // FrmTimNhanVien
            // 
            this.ClientSize = new System.Drawing.Size(325, 476);
            this.Controls.Add(this.groupPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTimNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm nhân viên";
            this.Load += new System.EventHandler(this.FrmTimNhanVien_Load);
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.ListViewEx lstvNhanVien;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private DevComponents.DotNetBar.ButtonX btChon;
        private DevComponents.DotNetBar.ButtonX btnThoat;

    }
}