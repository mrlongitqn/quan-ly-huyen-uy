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
            this.txtTenDiaDanh = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtMaDiaDanh = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblPassword = new DevComponents.DotNetBar.LabelX();
            this.lblUsername = new DevComponents.DotNetBar.LabelX();
            this.txtTenDayDu = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // treeviewDMHC
            // 
            this.treeviewDMHC.Location = new System.Drawing.Point(12, 138);
            this.treeviewDMHC.Name = "treeviewDMHC";
            this.treeviewDMHC.Size = new System.Drawing.Size(374, 223);
            this.treeviewDMHC.TabIndex = 0;
            this.treeviewDMHC.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeviewDMHC_AfterSelect);
            this.treeviewDMHC.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvDanhMucHanhChinh_NodeMouseClick);
            // 
            // btnThem
            // 
            this.btnThem.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThem.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThem.Location = new System.Drawing.Point(90, 393);
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
            this.btnChon.Location = new System.Drawing.Point(209, 393);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(75, 23);
            this.btnChon.TabIndex = 2;
            this.btnChon.Text = "Chọn";
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            // 
            // txtTenDiaDanh
            // 
            // 
            // 
            // 
            this.txtTenDiaDanh.Border.Class = "TextBoxBorder";
            this.txtTenDiaDanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDiaDanh.Location = new System.Drawing.Point(136, 57);
            this.txtTenDiaDanh.Name = "txtTenDiaDanh";
            this.txtTenDiaDanh.Size = new System.Drawing.Size(165, 20);
            this.txtTenDiaDanh.TabIndex = 156;
            // 
            // txtMaDiaDanh
            // 
            // 
            // 
            // 
            this.txtMaDiaDanh.Border.Class = "TextBoxBorder";
            this.txtMaDiaDanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaDiaDanh.Location = new System.Drawing.Point(136, 29);
            this.txtMaDiaDanh.Name = "txtMaDiaDanh";
            this.txtMaDiaDanh.Size = new System.Drawing.Size(165, 20);
            this.txtMaDiaDanh.TabIndex = 155;
            // 
            // lblPassword
            // 
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(36, 56);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(86, 22);
            this.lblPassword.TabIndex = 154;
            this.lblPassword.Text = "Tên địa danh";
            // 
            // lblUsername
            // 
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(36, 27);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(94, 22);
            this.lblUsername.TabIndex = 153;
            this.lblUsername.Text = "Mã địa danh";
            // 
            // txtTenDayDu
            // 
            // 
            // 
            // 
            this.txtTenDayDu.Border.Class = "TextBoxBorder";
            this.txtTenDayDu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDayDu.Location = new System.Drawing.Point(136, 85);
            this.txtTenDayDu.Name = "txtTenDayDu";
            this.txtTenDayDu.Size = new System.Drawing.Size(250, 20);
            this.txtTenDayDu.TabIndex = 158;
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(36, 84);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(86, 22);
            this.labelX1.TabIndex = 157;
            this.labelX1.Text = "Tên địa đầy đủ";
            // 
            // FrmDanhMucHanhChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(405, 435);
            this.Controls.Add(this.txtTenDayDu);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.txtTenDiaDanh);
            this.Controls.Add(this.txtMaDiaDanh);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
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
        private DevComponents.DotNetBar.Controls.TextBoxX txtTenDiaDanh;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaDiaDanh;
        private DevComponents.DotNetBar.LabelX lblPassword;
        private DevComponents.DotNetBar.LabelX lblUsername;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTenDayDu;
        private DevComponents.DotNetBar.LabelX labelX1;


    }
}