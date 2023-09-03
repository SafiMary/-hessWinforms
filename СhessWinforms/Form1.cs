using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace СhessWinforms
{

    public partial class Form1 : Form
    {
        
        PictureBox picturebox1 = new PictureBox
        {
            Visible = true,
            SizeMode = PictureBoxSizeMode.Zoom,
        };
        PictureBox picturebox2 = new PictureBox
        {
            Visible = true,
            SizeMode = PictureBoxSizeMode.Zoom,
        };

        int col,row;
        
        public Form1()
        {   
            InitializeComponent();
            picturebox1.ImageLocation = @"C:\Users\safim\source\repos\СhessWinforms\СhessWinforms\bin\Debug\Image\king.png";
            picturebox2.ImageLocation = @"C:\Users\safim\source\repos\СhessWinforms\СhessWinforms\bin\Debug\Image\queen.png"; 
            tableLayoutPanel1.CellPaint += (object sender, TableLayoutCellPaintEventArgs e) =>
            {
                Brush brush = ((e.Column & 1) != (e.Row & 1)) ? Brushes.Black : Brushes.White;
                e.Graphics.FillRectangle(brush, e.CellBounds);
                if(e.Column == 0)
                {
                    
                }
            };
            comboBoxFigur.Items.AddRange(new string[] { "Король", "Дама" });
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            
        }
      
       
        private void tableLayoutPanel1_Click(object sender, EventArgs e)
        {
             findPoint(tableLayoutPanel1.PointToClient(Cursor.Position));
            if (comboBoxFigur.SelectedIndex == 0)
            {
                tableLayoutPanel1.Controls.Add(picturebox1,col,row);  
            }
            if (comboBoxFigur.SelectedIndex == 1)
            {
                tableLayoutPanel1.Controls.Add(picturebox2, col, row);
            }
        }
       
      private void findPoint(Point point)
        {
            if (point.X > tableLayoutPanel1.Width || point.Y > tableLayoutPanel1.Height)
                return;

            int w = tableLayoutPanel1.Width;
            int h = tableLayoutPanel1.Height;
            int[] widths = tableLayoutPanel1.GetColumnWidths();

            int i;
            for (i = widths.Length - 1; i >= 0 && point.X < w; i--)
                w -= widths[i];
             col = i + 1;

            int[] heights = tableLayoutPanel1.GetRowHeights();
            for (i = heights.Length - 1; i >= 0 && point.Y < h; i--)
                h -= heights[i];

             row = i + 1;
            
        }

       
       
    }


    }
    
