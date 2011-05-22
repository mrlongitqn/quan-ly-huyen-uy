namespace QuanLyHoSoCongChuc
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
            this.treeviewDMHC = new System.Windows.Forms.TreeView();
            this.btnThem = new DevComponents.DotNetBar.ButtonX();
            this.btnChon = new DevComponents.DotNetBar.ButtonX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // treeviewDMHC
            // 
            this.treeviewDMHC.Location = new System.Drawing.Point(12, 43);
            this.treeviewDMHC.Name = "treeviewDMHC";
            this.treeviewDMHC.Size = new System.Drawing.Size(374, 223);
            this.treeviewDMHC.TabIndex = 0;
            this.treeviewDMHC.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvDanhMucHanhChinh_NodeMouseClick);
            // 
            // btnThem
            // 
            this.btnThem.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThem.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThem.Location = new System.Drawing.Point(37, 298);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnChon
            // 
            this.btnChon.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnChon.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnChon.Location = new System.Drawing.Point(156, 298);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(75, 23);
            this.btnChon.TabIndex = 2;
            this.btnChon.Text = "Chọn";
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX3.Location = new System.Drawing.Point(285, 298);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(75, 23);
            this.buttonX3.TabIndex = 3;
            this.buttonX3.Text = "buttonX3";
            // 
            // FrmDanhMucHanhChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(409, 333);
            this.Controls.Add(this.buttonX3);
            this.Controls.Add(this.btnChon);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.treeviewDMHC);
            this.DoubleBuffered = true;
            this.Name = "FrmDanhMucHanhChinh";
            this.Text = "Danh Mục Hành Chính";
            this.Load += new System.EventHandler(this.FrmDanhMucHanhChinh_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeviewDMHC;
        private DevComponents.DotNetBar.ButtonX btnThem;
        private DevComponents.DotNetBar.ButtonX btnChon;
        private DevComponents.DotNetBar.ButtonX buttonX3;


    }
}