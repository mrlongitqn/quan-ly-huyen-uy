namespace QuanLyHoSoCongChuc
{
    partial class FrmThemLoaiDonVi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmThemLoaiDonVi));
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.btnThoat = new DevComponents.DotNetBar.ButtonX();
            this.txtMaDoVi = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cbLoaiDonVi = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.btnXoaDonVi = new System.Windows.Forms.Button();
            this.btnLuuDonVi = new System.Windows.Forms.Button();
            this.btnThemDonVi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelX5
            // 
            this.labelX5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX5.Location = new System.Drawing.Point(48, 3);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(368, 58);
            this.labelX5.TabIndex = 51;
            this.labelX5.Text = "THÊM LOẠI ĐƠN VỊ";
            this.labelX5.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // btnThoat
            // 
            this.btnThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThoat.Location = new System.Drawing.Point(185, 134);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(86, 30);
            this.btnThoat.TabIndex = 38;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // txtMaDoVi
            // 
            // 
            // 
            // 
            this.txtMaDoVi.Border.Class = "TextBoxBorder";
            this.txtMaDoVi.Location = new System.Drawing.Point(89, 86);
            this.txtMaDoVi.Name = "txtMaDoVi";
            this.txtMaDoVi.Size = new System.Drawing.Size(65, 20);
            this.txtMaDoVi.TabIndex = 34;
            // 
            // cbLoaiDonVi
            // 
            this.cbLoaiDonVi.DisplayMember = "Text";
            this.cbLoaiDonVi.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLoaiDonVi.FormattingEnabled = true;
            this.cbLoaiDonVi.ItemHeight = 14;
            this.cbLoaiDonVi.Location = new System.Drawing.Point(160, 86);
            this.cbLoaiDonVi.Name = "cbLoaiDonVi";
            this.cbLoaiDonVi.Size = new System.Drawing.Size(177, 20);
            this.cbLoaiDonVi.TabIndex = 30;
            this.cbLoaiDonVi.SelectedIndexChanged += new System.EventHandler(this.cbLoaiDonVi_SelectedIndexChanged);
            // 
            // labelX1
            // 
            this.labelX1.Location = new System.Drawing.Point(21, 83);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 26;
            this.labelX1.Text = "Loại đơn vị";
            // 
            // btnXoaDonVi
            // 
            this.btnXoaDonVi.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaDonVi.Image")));
            this.btnXoaDonVi.Location = new System.Drawing.Point(422, 83);
            this.btnXoaDonVi.Name = "btnXoaDonVi";
            this.btnXoaDonVi.Size = new System.Drawing.Size(28, 27);
            this.btnXoaDonVi.TabIndex = 47;
            this.btnXoaDonVi.UseVisualStyleBackColor = true;
            this.btnXoaDonVi.Click += new System.EventHandler(this.btnXoaDonVi_Click);
            // 
            // btnLuuDonVi
            // 
            this.btnLuuDonVi.Image = ((System.Drawing.Image)(resources.GetObject("btnLuuDonVi.Image")));
            this.btnLuuDonVi.Location = new System.Drawing.Point(388, 83);
            this.btnLuuDonVi.Name = "btnLuuDonVi";
            this.btnLuuDonVi.Size = new System.Drawing.Size(28, 27);
            this.btnLuuDonVi.TabIndex = 43;
            this.btnLuuDonVi.UseVisualStyleBackColor = true;
            this.btnLuuDonVi.Click += new System.EventHandler(this.btnLuuDonVi_Click);
            // 
            // btnThemDonVi
            // 
            this.btnThemDonVi.AccessibleDescription = "";
            this.btnThemDonVi.Image = ((System.Drawing.Image)(resources.GetObject("btnThemDonVi.Image")));
            this.btnThemDonVi.Location = new System.Drawing.Point(354, 83);
            this.btnThemDonVi.Name = "btnThemDonVi";
            this.btnThemDonVi.Size = new System.Drawing.Size(28, 27);
            this.btnThemDonVi.TabIndex = 39;
            this.btnThemDonVi.UseVisualStyleBackColor = true;
            this.btnThemDonVi.Click += new System.EventHandler(this.btnThemDonVi_Click);
            // 
            // FrmThemLoaiDonVi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(471, 210);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.btnXoaDonVi);
            this.Controls.Add(this.btnLuuDonVi);
            this.Controls.Add(this.btnThemDonVi);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.txtMaDoVi);
            this.Controls.Add(this.cbLoaiDonVi);
            this.Controls.Add(this.labelX1);
            this.Name = "FrmThemLoaiDonVi";
            this.Text = "FrmThemLoaiDonVi";
            this.Load += new System.EventHandler(this.FrmThemLoaiDonVi_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX5;
        private System.Windows.Forms.Button btnXoaDonVi;
        private System.Windows.Forms.Button btnLuuDonVi;
        private System.Windows.Forms.Button btnThemDonVi;
        private DevComponents.DotNetBar.ButtonX btnThoat;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaDoVi;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbLoaiDonVi;
        private DevComponents.DotNetBar.LabelX labelX1;

    }
}