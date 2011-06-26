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
		private InTheFrmMain ChildForm = new InTheFrmMain();
		

        /// <summary>
        ///    Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components;
		private System.Windows.Forms.MainMenu mainMenu1;

        public InTheFrmParent()
        {
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
			this.components = new System.ComponentModel.Container ();
			this.mainMenu1 = new System.Windows.Forms.MainMenu ();
			//@this.TrayHeight = 90;
			//@this.TrayLargeIcon = false;
			//@this.TrayAutoArrange = true;
			//@mainMenu1.SetLocation (new System.Drawing.Point (7, 7));
			this.Text = "In thẻ nhân viên";
			this.AutoScaleBaseSize = new System.Drawing.Size (5, 13);
			this.IsMdiContainer = true;
			this.Menu = this.mainMenu1;
			this.Click += new System.EventHandler (this.ParentForm_Click);
		}

		protected void ParentForm_Click (object sender, System.EventArgs e)
		{

		}
    }
}
