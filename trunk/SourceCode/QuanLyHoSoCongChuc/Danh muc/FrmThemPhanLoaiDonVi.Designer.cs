namespace QuanLyHoSoCongChuc
{
    partial class FrmThemPhanLoaiDonVi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmThemPhanLoaiDonVi));
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.btnThoat = new DevComponents.DotNetBar.ButtonX();
            this.txtMaPLDV = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cbPhanLoaiDonVi = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.btnXoaPLDV = new System.Windows.Forms.Button();
            this.btnLuuPLDV = new System.Windows.Forms.Button();
            this.btnThemPLDV = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelX5
            // 
            this.labelX5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX5.Location = new System.Drawing.Point(80, 12);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(368, 58);
            this.labelX5.TabIndex = 59;
            this.labelX5.Text = "THÊM PHÂN LOẠI ĐƠN VỊ";
            this.labelX5.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // btnThoat
            // 
            this.btnThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThoat.Location = new System.Drawing.Point(222, 148);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(86, 30);
            this.btnThoat.TabIndex = 55;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // txtMaPLDV
            // 
            // 
            // 
            // 
            this.txtMaPLDV.Border.Class = "TextBoxBorder";
            this.txtMaPLDV.Location = new System.Drawing.Point(118, 96);
            this.txtMaPLDV.Name = "txtMaPLDV";
            this.txtMaPLDV.Size = new System.Drawing.Size(87, 20);
            this.txtMaPLDV.TabIndex = 54;
            // 
            // cbPhanLoaiDonVi
            // 
            this.cbPhanLoaiDonVi.DisplayMember = "Text";
            this.cbPhanLoaiDonVi.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPhanLoaiDonVi.FormattingEnabled = true;
            this.cbPhanLoaiDonVi.ItemHeight = 14;
            this.cbPhanLoaiDonVi.Location = new System.Drawing.Point(211, 96);
            this.cbPhanLoaiDonVi.Name = "cbPhanLoaiDonVi";
            this.cbPhanLoaiDonVi.Size = new System.Drawing.Size(177, 20);
            this.cbPhanLoaiDonVi.TabIndex = 53;
            this.cbPhanLoaiDonVi.SelectedIndexChanged += new System.EventHandler(this.cbPhanLoaiDonVi_SelectedIndexChanged);
            // 
            // labelX1
            // 
            this.labelX1.Location = new System.Drawing.Point(12, 93);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(100, 23);
            this.labelX1.TabIndex = 52;
            this.labelX1.Text = "Phân loại đơn vị";
            // 
            // btnXoaPLDV
            // 
            this.btnXoaPLDV.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaPLDV.Image")));
            this.btnXoaPLDV.Location = new System.Drawing.Point(473, 93);
            this.btnXoaPLDV.Name = "btnXoaPLDV";
            this.btnXoaPLDV.Size = new System.Drawing.Size(28, 27);
            this.btnXoaPLDV.TabIndex = 58;
            this.btnXoaPLDV.UseVisualStyleBackColor = true;
            this.btnXoaPLDV.Click += new System.EventHandler(this.btnXoaPLDV_Click);
            // 
            // btnLuuPLDV
            // 
            this.btnLuuPLDV.Image = ((System.Drawing.Image)(resources.GetObject("btnLuuPLDV.Image")));
            this.btnLuuPLDV.Location = new System.Drawing.Point(439, 93);
            this.btnLuuPLDV.Name = "btnLuuPLDV";
            this.btnLuuPLDV.Size = new System.Drawing.Size(28, 27);
            this.btnLuuPLDV.TabIndex = 57;
            this.btnLuuPLDV.UseVisualStyleBackColor = true;
            this.btnLuuPLDV.Click += new System.EventHandler(this.btnLuuPLDV_Click);
            // 
            // btnThemPLDV
            // 
            this.btnThemPLDV.AccessibleDescription = "";
            this.btnThemPLDV.Image = ((System.Drawing.Image)(resources.GetObject("btnThemPLDV.Image")));
            this.btnThemPLDV.Location = new System.Drawing.Point(405, 93);
            this.btnThemPLDV.Name = "btnThemPLDV";
            this.btnThemPLDV.Size = new System.Drawing.Size(28, 27);
            this.btnThemPLDV.TabIndex = 56;
            this.btnThemPLDV.UseVisualStyleBackColor = true;
            this.btnThemPLDV.Click += new System.EventHandler(this.btnThemPLDV_Click);
            // 
            // FrmThemPhanLoaiDonVi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(528, 215);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.btnXoaPLDV);
            this.Controls.Add(this.btnLuuPLDV);
            this.Controls.Add(this.btnThemPLDV);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.txtMaPLDV);
            this.Controls.Add(this.cbPhanLoaiDonVi);
            this.Controls.Add(this.labelX1);
            this.Name = "FrmThemPhanLoaiDonVi";
            this.Text = "FrmThemPhanLoaiDonVi";
            this.Load += new System.EventHandler(this.FrmThemPhanLoaiDonVi_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX5;
        private System.Windows.Forms.Button btnXoaPLDV;
        private System.Windows.Forms.Button btnLuuPLDV;
        private System.Windows.Forms.Button btnThemPLDV;
        private DevComponents.DotNetBar.ButtonX btnThoat;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaPLDV;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbPhanLoaiDonVi;
        private DevComponents.DotNetBar.LabelX labelX1;
    }
}