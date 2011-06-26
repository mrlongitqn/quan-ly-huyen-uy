namespace QuanLyHoSoCongChuc.Report
{
    using System;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Data;


    /// <summary>
    ///    Summary description for Form1.
    /// </summary>
    public class InTheFrmMain : System.Windows.Forms.Form
    {

		private int XRes = 0;
		private int YRes = 0;
		private int XMargin = 0;
		private int YMargin = 0;
		private Rectangle BorderRect1 = new Rectangle();
        private Rectangle BorderRect1a = new Rectangle();
        private Rectangle BorderRect2 = new Rectangle();
        private Rectangle BorderRect2a = new Rectangle();
        private Rectangle BorderRect3 = new Rectangle();
        private Rectangle BorderRect3a = new Rectangle();
        private Rectangle BorderRect4 = new Rectangle();
        private Rectangle BorderRect4a = new Rectangle();
        private Rectangle BorderRect5 = new Rectangle();
        private Rectangle BorderRect5a = new Rectangle();
        private Rectangle BorderRect6 = new Rectangle();
        private Rectangle BorderRect6a = new Rectangle();
        private Rectangle BorderRect7 = new Rectangle();
        private Rectangle BorderRect7a = new Rectangle();
        private Rectangle BorderRect8 = new Rectangle();
        private Rectangle BorderRect8a = new Rectangle();
        
		private BusinessCard MyCard = new BusinessCard(Application.StartupPath);
		
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

        public InTheFrmMain()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
			
			this.Size = new Size(600, 500);
			this.ClientSize = new Size(printDocument1.PrinterSettings.DefaultPageSettings.PaperSize.Width, printDocument1.PrinterSettings.DefaultPageSettings.PaperSize.Height);
			this.MdiParent = ParentForm;
			BusinessCard TempCard = MyCard.OpenCard();
			if (TempCard != null) // file exists
			{
				MyCard.ShallowCopy(TempCard);
			}

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
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Menu = this.mainMenu1;
            this.Name = "InTheFrmMain";
            this.Text = "In thẻ nhân viên";
            this.ResumeLayout(false);

		}

		protected void HelpAbout_Click (object sender, System.EventArgs e)
		{
			//AboutBox  myAboutBox = new AboutBox();
			//myAboutBox.ShowDialog();
		}

		protected void FileExit_Click (object sender, System.EventArgs e)
		{
            this.Close();
		}

		

		protected void PrintFile_Click (object sender, System.EventArgs e)
		{
			printDialog1.Document = printDocument1;
			if (printDialog1.ShowDialog() == DialogResult.OK)
			 {
			  IsPrinting = true; // set to true to prevent painting borders
			  this.printDocument1.Print();
			 }
		}

		protected void printDocument1_PrintPage (object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
		Graphics g = e.Graphics;
		PrintPrinterLabels(g);
		}

		protected void PrintPreview_Click (object sender, System.EventArgs e)
		{
				 try
				{
				  PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();  // instantiate new print preview dialog
				  printPreviewDialog1.Document = this.printDocument1 ;
				  IsPrinting = false; // leave false for borders
				  printPreviewDialog1.ShowDialog();   // Show the print preview dialog, uses print page event to draw preview screen
				}
				catch(Exception exp)
				{
				  System.Console.WriteLine(exp.Message.ToString());
				} 

		}

		protected void Form1_Click (object sender, System.EventArgs e)
		{

		}

		protected void CalcBorderRect()
		{
			XRes = kXResolution; // this.printDocument1.PrinterSettings.DefaultPageSettings.PrinterResolution.X;
			YRes = kYResolution; // this.printDocument1.PrinterSettings.DefaultPageSettings.PrinterResolution.Y;
			XMargin = CalcXPrintPixels(kXMargin);
			YMargin = CalcYPrintPixels(kYMargin);
			

            //int w = printDocument1.PrinterSettings.DefaultPageSettings.PaperSize.Width / 2 + XMargin / 2;
            //int h = printDocument1.PrinterSettings.DefaultPageSettings.PaperSize.Height / 5 + YMargin;

            int w =  325;
            int h = 204;

            BorderRect1.X = 50;
            BorderRect1.Y = 50;
            BorderRect1.Width = w;
            BorderRect1.Height = h;
            BorderRect1.Inflate(1, 1);

            BorderRect1a.X = 56;
            BorderRect1a.Y = 56;
            BorderRect1a.Width = w-6*2;
            BorderRect1a.Height = 60;
            BorderRect1a.Inflate(1, 1);


            BorderRect2.X = 450;
            BorderRect2.Y = 50;
            BorderRect2.Width = w;
            BorderRect2.Height = h;
            BorderRect2.Inflate(1, 1);

            BorderRect2a.X = 450 + 6;
            BorderRect2a.Y = 50+6;
            BorderRect2a.Width = w - 6 * 2;
            BorderRect2a.Height = 60;
            BorderRect2a.Inflate(1, 1);

            BorderRect3.X = 50;
            BorderRect3.Y = 300;
            BorderRect3.Width = w;
            BorderRect3.Height = h;
            BorderRect3.Inflate(1, 1);

            BorderRect3a.X = 50+6;
            BorderRect3a.Y = 300+6;
            BorderRect3a.Width = w - 6 * 2;
            BorderRect3a.Height = 60;
            BorderRect3a.Inflate(1, 1);

            BorderRect4.X = 450;
            BorderRect4.Y = 300;
            BorderRect4.Width = w;
            BorderRect4.Height = h;
            BorderRect4.Inflate(1, 1);

            BorderRect4a.X = 450 + 6;
            BorderRect4a.Y = 300 + 6;
            BorderRect4a.Width = w - 6 * 2;
            BorderRect4a.Height = 60;
            BorderRect4a.Inflate(1, 1);

            BorderRect5.X = 50;
            BorderRect5.Y = 300+250;
            BorderRect5.Width = w;
            BorderRect5.Height = h;
            BorderRect5.Inflate(1, 1);

            BorderRect5a.X = 50 + 6;
            BorderRect5a.Y = 300 + 250 + 6;
            BorderRect5a.Width = w - 6 * 2;
            BorderRect5a.Height = 60;
            BorderRect5a.Inflate(1, 1);


            BorderRect6.X = 450;
            BorderRect6.Y = 300 + 250;
            BorderRect6.Width = w;
            BorderRect6.Height = h;
            BorderRect6.Inflate(1, 1);

            BorderRect6a.X = 450 + 6;
            BorderRect6a.Y = 300 + 250 + 6;
            BorderRect6a.Width = w - 6 * 2;
            BorderRect6a.Height = 60;
            BorderRect6a.Inflate(1, 1);

            BorderRect7.X = 50;
            BorderRect7.Y = 300 + 250*2;
            BorderRect7.Width = w;
            BorderRect7.Height = h;
            BorderRect7.Inflate(1, 1);

            BorderRect7a.X = 50 + 6;
            BorderRect7a.Y = 300 + 250 * 2 + 6;
            BorderRect7a.Width = w - 6 * 2;
            BorderRect7a.Height = 60;
            BorderRect7a.Inflate(1, 1);

            BorderRect8.X = 450;
            BorderRect8.Y = 300 + 250 * 2;
            BorderRect8.Width = w;
            BorderRect8.Height = h;
            BorderRect8.Inflate(1, 1);

            BorderRect8a.X = 450 + 6;
            BorderRect8a.Y = 300 + 250*2 + 6;
            BorderRect8a.Width = w - 6 * 2;
            BorderRect8a.Height = 60;
            BorderRect8a.Inflate(1, 1);


		}

		protected void DrawLabelPie(Graphics g, Pen p, int numX, int numY)
		{
            //int xInc = BorderRect.Width/numX;
            //int yInc = BorderRect.Height/numY;

            //for (int y = yInc + BorderRect.Top; y < BorderRect.Height; y += yInc)
            //{
            //    g.DrawLine(p, BorderRect.Left, y, BorderRect.Right, y); // ve duong ngang
            //}

            //for (int x = xInc + BorderRect.Left; x < BorderRect.Width; x += xInc)
            //{
            //    g.DrawLine(p, x, BorderRect.Top+50, x,BorderRect.Bottom+50);
            //}

		}


		protected void PrintPrinterLabels(Graphics g)
		{
			
			Pen myPen = new Pen( Color.Red, 3 );
			Rectangle rect = this.ClientRectangle;
			g.FillRectangle(Brushes.White, rect);
			CalcBorderRect();
            g.FillRectangle(Brushes.BlueViolet, BorderRect1); 
			if (IsPrinting == false)
			{
				DrawLabelPie(g, myPen, kLabelColumn ,kLabelRow);
				g.DrawRectangle(myPen, BorderRect1 );               
                g.DrawRectangle(myPen, BorderRect2);
                g.DrawRectangle(myPen, BorderRect3);
                g.DrawRectangle(myPen, BorderRect4);
                g.DrawRectangle(myPen, BorderRect5);
                g.DrawRectangle(myPen, BorderRect6);
                g.DrawRectangle(myPen, BorderRect7);
                g.DrawRectangle(myPen, BorderRect8);

			}

            //
            Pen myPen2 = new Pen(Color.Blue, 1);
            if (IsPrinting == false)
            {
                g.DrawRectangle(myPen2, BorderRect1a);
                g.DrawRectangle(myPen2, BorderRect2a);
                g.DrawRectangle(myPen2, BorderRect3a);
                g.DrawRectangle(myPen2, BorderRect4a);
                g.DrawRectangle(myPen2, BorderRect5a);
                g.DrawRectangle(myPen2, BorderRect6a);
                g.DrawRectangle(myPen2, BorderRect7a);
                g.DrawRectangle(myPen2, BorderRect8a);
            }

			int nCardWidth = BorderRect1.Width/kLabelColumn;
			int nCardHeight = BorderRect1.Height/kLabelRow;
			for (int i = 0; i < kLabelColumn; i++)
			{
				for (int j = 0; j < kLabelRow; j++)
				{
					int x = XMargin + i * nCardWidth;
					int y = YMargin + j * nCardHeight;
					
				}
				
				
			}
            MyCard.PaintCard(g, new Point(50, 50));
			myPen.Dispose();
		}

 


		protected override void OnPaint( PaintEventArgs pe )
		{
		Graphics g = pe.Graphics;
		IsPrinting = false;
		PrintPrinterLabels(g);
		}

		public int CalcXPrintPixels(float fInches)
		{
		  int nVal = 0;

		  nVal = (int)(fInches * (float)XRes);
		  return nVal;
		}

		public int CalcYPrintPixels(float fInches)
		{
		  int nVal = 0;

		  nVal = (int)(fInches * (float)YRes);
		  return nVal;
		}


       
    }
}
