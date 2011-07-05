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

        public InTheFrmParent(string _madonvi)
        {
            InitializeComponent();

            ChildForm = new InTheFrmMain(_madonvi);
            ChildForm.MdiParent = this;
            ChildForm.Show();
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
            this.ClientSize = new System.Drawing.Size(837, 589);
            this.IsMdiContainer = true;
            this.Name = "InTheFrmParent";
            this.Text = "In thẻ nhân viên";
            this.ResumeLayout(false);

		}
    }
}
