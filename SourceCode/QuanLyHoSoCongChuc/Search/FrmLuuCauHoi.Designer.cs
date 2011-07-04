namespace QuanLyHoSoCongChuc.Search
{
    partial class FrmLuuCauHoi
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
            this.btnLuu = new DevComponents.DotNetBar.ButtonX();
            this.btnThoat = new DevComponents.DotNetBar.ButtonX();
            this.txtTenCauHoi = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelxx = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.lstvDieuKienTimKiem = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.SuspendLayout();
            // 
            // btnLuu
            // 
            this.btnLuu.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLuu.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLuu.Image = global::QuanLyHoSoCongChuc.Properties.Resources._45;
            this.btnLuu.Location = new System.Drawing.Point(90, 202);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 38;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThoat.Image = global::QuanLyHoSoCongChuc.Properties.Resources.exit;
            this.btnThoat.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnThoat.Location = new System.Drawing.Point(182, 202);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 39;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // txtTenCauHoi
            // 
            // 
            // 
            // 
            this.txtTenCauHoi.Border.Class = "TextBoxBorder";
            this.txtTenCauHoi.Location = new System.Drawing.Point(12, 171);
            this.txtTenCauHoi.Name = "txtTenCauHoi";
            this.txtTenCauHoi.Size = new System.Drawing.Size(256, 20);
            this.txtTenCauHoi.TabIndex = 37;
            // 
            // labelxx
            // 
            this.labelxx.BackColor = System.Drawing.Color.Transparent;
            this.labelxx.Location = new System.Drawing.Point(25, 149);
            this.labelxx.Name = "labelxx";
            this.labelxx.Size = new System.Drawing.Size(93, 18);
            this.labelxx.TabIndex = 36;
            this.labelxx.Text = "Tên câu hỏi";
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            this.labelX2.Location = new System.Drawing.Point(25, 12);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(93, 19);
            this.labelX2.TabIndex = 35;
            this.labelX2.Text = "Nội dung câu hỏi";
            // 
            // lstvDieuKienTimKiem
            // 
            // 
            // 
            // 
            this.lstvDieuKienTimKiem.Border.Class = "ListViewBorder";
            this.lstvDieuKienTimKiem.FullRowSelect = true;
            this.lstvDieuKienTimKiem.Location = new System.Drawing.Point(12, 34);
            this.lstvDieuKienTimKiem.MultiSelect = false;
            this.lstvDieuKienTimKiem.Name = "lstvDieuKienTimKiem";
            this.lstvDieuKienTimKiem.Size = new System.Drawing.Size(256, 97);
            this.lstvDieuKienTimKiem.TabIndex = 34;
            this.lstvDieuKienTimKiem.UseCompatibleStateImageBehavior = false;
            this.lstvDieuKienTimKiem.View = System.Windows.Forms.View.List;
            // 
            // FrmLuuCauHoi
            // 
            this.ClientSize = new System.Drawing.Size(283, 235);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.txtTenCauHoi);
            this.Controls.Add(this.labelxx);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.lstvDieuKienTimKiem);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLuuCauHoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lưu câu hỏi";
            this.Load += new System.EventHandler(this.FrmLuuCauHoi_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnLuu;
        private DevComponents.DotNetBar.ButtonX btnThoat;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTenCauHoi;
        private DevComponents.DotNetBar.LabelX labelxx;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ListViewEx lstvDieuKienTimKiem;

    }
}