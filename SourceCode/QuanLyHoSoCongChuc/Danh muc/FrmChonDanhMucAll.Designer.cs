namespace QuanLyHoSoCongChuc.Danh_muc
{
    partial class FrmChonDanhMucAll
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
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.btnThoat = new DevComponents.DotNetBar.ButtonX();
            this.btChon = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.btnThoat);
            this.groupPanel2.Controls.Add(this.btChon);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupPanel2.Location = new System.Drawing.Point(0, 454);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(447, 45);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanel2.TabIndex = 158;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(447, 499);
            this.treeView1.TabIndex = 157;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // btnThoat
            // 
            this.btnThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThoat.Image = global::QuanLyHoSoCongChuc.Properties.Resources.exit;
            this.btnThoat.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnThoat.Location = new System.Drawing.Point(331, 7);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Text = "Thoát";
            // 
            // btChon
            // 
            this.btChon.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btChon.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btChon.Image = global::QuanLyHoSoCongChuc.Properties.Resources.Sign_Select_icon;
            this.btChon.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btChon.Location = new System.Drawing.Point(239, 7);
            this.btChon.Name = "btChon";
            this.btChon.Size = new System.Drawing.Size(75, 23);
            this.btChon.TabIndex = 5;
            this.btChon.Text = "Chọn";
            this.btChon.Click += new System.EventHandler(this.btChon_Click);
            // 
            // FrmChonDanhMucAll
            // 
            this.ClientSize = new System.Drawing.Size(447, 499);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.treeView1);
            this.Name = "FrmChonDanhMucAll";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn danh mục";
            this.Load += new System.EventHandler(this.FrmChonDanhMucAll_Load);
            this.groupPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.ButtonX btnThoat;
        private DevComponents.DotNetBar.ButtonX btChon;
        private System.Windows.Forms.TreeView treeView1;
    }
}