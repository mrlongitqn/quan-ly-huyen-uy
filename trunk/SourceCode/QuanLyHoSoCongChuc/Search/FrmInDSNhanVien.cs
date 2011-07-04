using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using QuanLyHoSoCongChuc.Utils;

namespace QuanLyHoSoCongChuc.Search
{
    /// <summary>
    /// tuansl added: store user query in file
    /// </summary>
    public partial class FrmInDSNhanVien : Form
    {
        private ListView lstvNhanVien;
        public Font LargeFont = new Font("Times New Roman", 12, FontStyle.Bold);
        public Font NormalFont = new Font("Times New Roman", 10);

        public FrmInDSNhanVien(ListView _lstvNhanVien)
        {
            InitializeComponent();
            lstvNhanVien = _lstvNhanVien;

            this.Size = new Size(600 * 2, 500);
            this.ClientSize = new Size(printDocument1.PrinterSettings.DefaultPageSettings.PaperSize.Width, printDocument1.PrinterSettings.DefaultPageSettings.PaperSize.Height);
            this.MdiParent = ParentForm;

            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
        }

        public void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            PrintPrinterLabels(g);
        }

        public void PrintPrinterLabels(Graphics g)
        {
            Pen myPen = new Pen(Color.Red, 3);
            //Rectangle rect = this.ClientRectangle;
            Rectangle rect = new Rectangle(0, 0, 4000, 2000);
            g.FillRectangle(Brushes.White, rect);

            PaintHeader(g, new Point(20, 20));
            PaintList(g, new Point(20, 20));
        }

        public void PaintHeader(Graphics g, Point offset)
        {
            var xCor = offset.X;
            var yCor = offset.Y;
            for (int i = 0; i < lstvNhanVien.Columns.Count; i++)
            {
                g.DrawString(lstvNhanVien.Columns[i].Text, LargeFont, Brushes.Black, xCor, yCor);
                xCor += lstvNhanVien.Columns[i].Width + offset.X;
            }
        }
        public void PaintList(Graphics g, Point offset)
        {
            var xCor = offset.X;
            var yCor = offset.Y + 30;
            for (int i = 0; i < lstvNhanVien.Items.Count; i++)
            {
                g.DrawString(lstvNhanVien.Items[i].Text, NormalFont, Brushes.Black, xCor + 20, yCor);
                xCor += lstvNhanVien.Columns[0].Width + offset.X;

                for (int j = 1; j < lstvNhanVien.Columns.Count; j++)
                {
                    if (IsDateType(lstvNhanVien.Items[i].SubItems[j].Text))
                    {
                        g.DrawString(String.Format("{0:dd/MM/yyyy}", DateTime.Parse(lstvNhanVien.Items[i].SubItems[j].Text)), NormalFont, Brushes.Black, xCor, yCor);
                    }
                    else
                    {
                        g.DrawString(lstvNhanVien.Items[i].SubItems[j].Text, NormalFont, Brushes.Black, xCor, yCor);
                    }

                    xCor += lstvNhanVien.Columns[j].Width + offset.X;
                }
                xCor = offset.X;
                yCor += 30;
            }
        }

        public bool IsDateType(string data)
        {
            try
            {
                var date = DateTime.Parse(data);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void PrintPreview_Click(object sender, EventArgs e)
        {
            try
            {
                PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();  // instantiate new print preview dialog
                printPreviewDialog1.Document = this.printDocument1;
                printPreviewDialog1.ShowDialog();   // Show the print preview dialog, uses print page event to draw preview screen
            }
            catch (Exception exp)
            {
                System.Console.WriteLine(exp.Message.ToString());
            } 
        }

        private void PrintFile_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                this.printDocument1.Print();
            }
        }

        private void FileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmInDSNhanVien_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            PrintPrinterLabels(g);
        }
    }
}