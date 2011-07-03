namespace QuanLyHoSoCongChuc.Search
{
    partial class FrmChonTruong
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
            this.lstvTenTruongDuLieu = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btChon = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // lstvTenTruongDuLieu
            // 
            // 
            // 
            // 
            this.lstvTenTruongDuLieu.Border.Class = "ListViewBorder";
            this.lstvTenTruongDuLieu.CheckBoxes = true;
            this.lstvTenTruongDuLieu.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstvTenTruongDuLieu.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstvTenTruongDuLieu.FullRowSelect = true;
            this.lstvTenTruongDuLieu.GridLines = true;
            this.lstvTenTruongDuLieu.Location = new System.Drawing.Point(0, 0);
            this.lstvTenTruongDuLieu.MultiSelect = false;
            this.lstvTenTruongDuLieu.Name = "lstvTenTruongDuLieu";
            this.lstvTenTruongDuLieu.Size = new System.Drawing.Size(287, 406);
            this.lstvTenTruongDuLieu.TabIndex = 0;
            this.lstvTenTruongDuLieu.UseCompatibleStateImageBehavior = false;
            this.lstvTenTruongDuLieu.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Chọn";
            this.columnHeader1.Width = 50;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên trường";
            this.columnHeader2.Width = 230;
            // 
            // btChon
            // 
            this.btChon.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btChon.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btChon.Image = global::QuanLyHoSoCongChuc.Properties.Resources._45;
            this.btChon.Location = new System.Drawing.Point(176, 416);
            this.btChon.Name = "btChon";
            this.btChon.Size = new System.Drawing.Size(79, 23);
            this.btChon.TabIndex = 45;
            this.btChon.Text = "Cập nhật";
            this.btChon.Click += new System.EventHandler(this.btChon_Click);
            // 
            // FrmChonTruong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 448);
            this.Controls.Add(this.btChon);
            this.Controls.Add(this.lstvTenTruongDuLieu);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmChonTruong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmChonTruong";
            this.Load += new System.EventHandler(this.FrmChonTruong_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ListViewEx lstvTenTruongDuLieu;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private DevComponents.DotNetBar.ButtonX btChon;
    }
}