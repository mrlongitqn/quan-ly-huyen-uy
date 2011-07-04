namespace QuanLyHoSoCongChuc.Report
{
    using System;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;


    /// <summary>
    ///    Summary description for ParentForm.
    /// </summary>
    public class InTheFrmParent : System.Windows.Forms.Form
    {
        private InTheFrmMain ChildForm;
        private IContainer components;

        public InTheFrmParent(NhanVienDTO _dto)
        {
            ChildForm = new InTheFrmMain(_dto);
	            InitializeComponent();
				ChildForm.MdiParent = this;
				ChildForm.Show();
            //
            // Required for Windows Form Designer support
            //
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        ///    Required method for Designer support - do not modify
        ///    the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // InTheFrmParent
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.IsMdiContainer = true;
            this.Name = "InTheFrmParent";
            this.Text = "In thẻ nhân viên 2";
            this.Click += new System.EventHandler(this.ParentForm_Click);
            this.ResumeLayout(false);

		}

		protected void ParentForm_Click (object sender, System.EventArgs e)
		{

		}
    }
}
