using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ruler
{
    public partial class Window : Form
    {
        private bool pressing;
        private Point lastMouseLocation;
        private Point firstMouseLocation;
        private int initialWidth;
        private int initialHeight;
        private Point currentMouseLocation;
        private bool moving;
        private bool isResizing;
        private Size initialSize;

        public Window()
        {
            InitializeComponent();

            ruler.ContextMenu = contextMenu;
        }

        private void ruler_Paint(object sender, PaintEventArgs e)
        {
            // Draw a border around the control.
            e.Graphics.DrawLine(
                new Pen(
                    Brushes.Black,
                    1.0f
                    ),
                new Point(
                    1,
                    0
                    ),
                new Point(
                    1,
                    this.Height - (int)1.0f
                    )
                );
        }

        private void ruler_MouseDown(object sender, MouseEventArgs e)
        {
            pressing = true;
            firstMouseLocation = e.Location;
            initialWidth = this.Width;
            initialHeight = this.Height;
        }

        private void ruler_MouseMove(object sender, MouseEventArgs e)
        {
            int location = -1;

            if (ruler.Direction == Ruler.Directions.Horizontal)
            {
                location = e.Location.X;
            }
            else
            {
                location = e.Location.Y;
            }

            ruler.DrawIndicator(location);

            if (ruler.Direction == Ruler.Directions.Horizontal)
            {
                if (e.X >= this.Width || e.X >= (this.Width - 3))
                {
                    isResizing = true;

                    this.Cursor = Cursors.SizeWE;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                }

                if (pressing)
                {
                    ruler.IsDragging = true;

                    currentMouseLocation = e.Location;

                    if (!isResizing)
                    {
                        this.Left = this.Left += currentMouseLocation.X - firstMouseLocation.X;
                        this.Top = this.Top += currentMouseLocation.Y - firstMouseLocation.Y;

                        moving = true;
                    }
                    else
                    {
                        this.Width = (e.X - firstMouseLocation.X) + initialWidth;
                    }
                }
            }
            else
            {
                if (e.Y >= this.Height || e.Y >= (this.Height - 3))
                {
                    isResizing = true;

                    this.Cursor = Cursors.SizeNS;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                }

                if (pressing)
                {
                    ruler.IsDragging = true;

                    currentMouseLocation = e.Location;

                    if (!isResizing)
                    {
                        this.Left = this.Left += currentMouseLocation.X - firstMouseLocation.X;
                        this.Top = this.Top += currentMouseLocation.Y - firstMouseLocation.Y;

                        moving = true;
                    }
                    else
                    {
                        this.Height = (e.Y - firstMouseLocation.Y) + initialHeight;
                    }
                }
            }
        }

        private void ruler_MouseUp(object sender, MouseEventArgs e)
        {
            pressing = false;
            lastMouseLocation = e.Location;

            ruler.IsDragging = false;
            isResizing = false;
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            ruler.ClearMarker(Ruler.Markers.All);
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            ruler.ClearMarker(Ruler.Markers.Current);
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void menuItem6_Click(object sender, EventArgs e)
        {
            ruler.Direction = Ruler.Directions.Horizontal;
            this.Size = initialSize;

            ruler.Dock = DockStyle.Fill;
        }

        private void Window_Shown(object sender, EventArgs e)
        {
            initialSize = Size;
        }

        private void menuItem7_Click(object sender, EventArgs e)
        {
            ruler.Direction = Ruler.Directions.Vertical;
            this.Size = new Size(
                initialSize.Height,
                700
                );

            ruler.Dock = DockStyle.Fill;
        }

        private void menuItem9_Click(object sender, EventArgs e)
        {
            if (((MenuItem)sender).Checked)
            {
                this.TopMost = false;

                ((MenuItem)sender).Checked = false;
            }
            else
            {
                this.BringToFront();
                this.TopMost = true;

                ((MenuItem)sender).Checked = true;
            }
        }
    }
}
