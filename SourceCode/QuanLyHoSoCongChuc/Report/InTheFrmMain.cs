namespace QuanLyHoSoCongChuc.Report
{
    using System;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Data;
    using QuanLyHoSoCongChuc.Repositories;
    using System.IO;
using System.Collections.Generic;
using QuanLyHoSoCongChuc.Models;


    /// <summary>
    ///    Summary description for Form1.
    /// </summary>
    public class InTheFrmMain : System.Windows.Forms.Form
    {
		private Rectangle BorderRect1 = new Rectangle();
        private Rectangle BorderRect1a = new Rectangle();
        private Rectangle BorderRect2 = new Rectangle();
        private Rectangle BorderRect2a = new Rectangle();

        public BusinessCard MyCard = new BusinessCard(Application.StartupPath);
		
		private const int kLabelRow  = 5;
		private const int kLabelColumn  = 2;
		private const float kXMargin = 0.75f;
		private const float kYMargin = 0.50f;
		private const int	kXResolution = 100;
        private const int kYResolution = 100;
        private IContainer components;
		private System.Windows.Forms.MenuItem FileExit;
		private System.Windows.Forms.PrintDialog printDialog1;
		private System.Windows.Forms.MenuItem PrintFile;
		private System.Windows.Forms.MenuItem PrintPreview;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Drawing.Printing.PrintDocument printDocument1;
        private bool IsPrinting = false;

        private string MaDonVi;
        private int numPage = 0;
        private List<NhanVien> lstItem = new List<NhanVien>();
        private int countPage = 0;

        public InTheFrmMain(string _madonvi)
        {
            InitializeComponent();
			
			this.MdiParent = ParentForm;
            
            MaDonVi = _madonvi;
            lstItem = NhanVienRepository.SelectByMaDonViConSinhHoat(MaDonVi);
            numPage = lstItem.Count > 10 ? (lstItem.Count / 10 + 1) : 1;
        }

        #region InitializeComponent
        /// <summary>
        ///    Required method for Designer support - do not modify
        ///    the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InTheFrmMain));
            this.PrintPreview = new System.Windows.Forms.MenuItem();
            this.FileExit = new System.Windows.Forms.MenuItem();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.PrintFile = new System.Windows.Forms.MenuItem();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.SuspendLayout();
            // 
            // PrintPreview
            // 
            this.PrintPreview.Index = 0;
            this.PrintPreview.Text = "Xem trước khi in";
            this.PrintPreview.Click += new System.EventHandler(this.PrintPreview_Click);
            // 
            // FileExit
            // 
            this.FileExit.Index = 2;
            this.FileExit.Text = "Đóng";
            this.FileExit.Click += new System.EventHandler(this.FileExit_Click);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.PrintPreview,
            this.PrintFile,
            this.FileExit});
            this.menuItem1.Text = "Menu";
            // 
            // PrintFile
            // 
            this.PrintFile.Index = 1;
            this.PrintFile.Text = "In";
            this.PrintFile.Click += new System.EventHandler(this.PrintFile_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(792, 677);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.MaximizeBox = false;
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // InTheFrmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(705, 543);
            this.Menu = this.mainMenu1;
            this.Name = "InTheFrmMain";
            this.Text = "In thẻ nhân viên";
            this.Load += new System.EventHandler(this.InTheFrmMain_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.InTheFrmMain_Paint);
            this.ResumeLayout(false);

		}
        #endregion

        public void FileExit_Click(object sender, System.EventArgs e)
		{
            this.Close();
		}

        public void PrintFile_Click(object sender, System.EventArgs e)
		{
			printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                IsPrinting = true; // set to true to prevent painting borders
                this.printDocument1.Print();
            }
		}

        public void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (countPage < numPage)
            {
                Graphics g = e.Graphics;
                PrintPrinterLabels(g);
                countPage++;
            }
            else
            {
                countPage = 0;
            }

            if (numPage > 1)
            {
                e.HasMorePages = true;
            }
        }

		public void PrintPreview_Click (object sender, System.EventArgs e)
		{
            try
            {
                PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();  // instantiate new print preview dialog
                printPreviewDialog1.Document = this.printDocument1;
                IsPrinting = false; // leave false for borders
                printPreviewDialog1.ShowDialog();   // Show the print preview dialog, uses print page event to draw preview screen
            }
            catch (Exception exp)
            {
                System.Console.WriteLine(exp.Message.ToString());
            }
		}

        public void Form1_Click(object sender, System.EventArgs e)
		{

		}

		public void PrintPrinterLabels(Graphics g)
		{
            int w = 350;
            int h = 184;
			Pen myPen = new Pen( Color.Red, 3 );
            Pen myPen2 = new Pen(Color.Blue, 1);
            Rectangle rect = new Rectangle(0, 0, 4000, 2000);
			g.FillRectangle(Brushes.White, rect);

            BorderRect1.X = 50;
            BorderRect1.Y = 50;
            BorderRect1.Width = w;
            BorderRect1.Height = h;
            BorderRect1.Inflate(1, 1);

            BorderRect1a.X = 56;
            BorderRect1a.Y = 56;
            BorderRect1a.Width = w - 6 * 2;
            BorderRect1a.Height = 60;
            BorderRect1a.Inflate(1, 1);

            BorderRect2.X = 450;
            BorderRect2.Y = 50;
            BorderRect2.Width = w;
            BorderRect2.Height = h;
            BorderRect2.Inflate(1, 1);

            BorderRect2a.X = 450 + 6;
            BorderRect2a.Y = 50 + 6;
            BorderRect2a.Width = w - 6 * 2;
            BorderRect2a.Height = 60;
            BorderRect2a.Inflate(1, 1);

            for (int i = 0; i < lstItem.Count; i++)
            {
                if (i % 2 == 0)
                {
                    g.FillRectangle(Brushes.Aquamarine, BorderRect1);

                    if (IsPrinting == false)
                    {
                        g.DrawRectangle(myPen, BorderRect1);
                    }

                    if (IsPrinting == false)
                    {
                        g.DrawRectangle(myPen2, BorderRect1a);
                    }

                    MyCard.PaintCard(g, new Point(50, BorderRect1.Y), lstItem[i]);
                    BorderRect1.Y += BorderRect1.Height + 10;
                    BorderRect1a.Y += BorderRect1.Height + 10;
                }
                else if (i % 2 != 0)
                {
                    g.FillRectangle(Brushes.Aquamarine, BorderRect2);

                    if (IsPrinting == false)
                    {
                        g.DrawRectangle(myPen, BorderRect2);
                    }

                    if (IsPrinting == false)
                    {
                        g.DrawRectangle(myPen2, BorderRect2a);
                    }

                    MyCard.PaintCard(g, new Point(450, BorderRect2.Y), lstItem[i]);
                    BorderRect2.Y += BorderRect2.Height + 10;
                    BorderRect2a.Y += BorderRect2.Height + 10;
                }
            }

			myPen.Dispose();
            myPen2.Dispose();
		}

        private void InTheFrmMain_Load(object sender, EventArgs e)
        {

        }

        private void InTheFrmMain_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            IsPrinting = false;
            PrintPrinterLabels(g);
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            BorderRect1.Y += 2;
            BorderRect1a.Y += 2;
            BorderRect2.Y += 2;
            BorderRect2a.Y += 2;
            this.Invalidate();
        }
    }
}
