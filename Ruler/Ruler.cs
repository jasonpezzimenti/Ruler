using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ruler
{
    public partial class Ruler : Control
    {
        public enum Directions
        {
            Horizontal = 0,
            Vertical
        }

        [Browsable(true)]
        [Category("Appearance")]
        public Directions Direction { get; set; }

        [Browsable(false)]
        public bool IsDragging { get; set; }

        [Browsable(false)]
        public bool RequestDrawing { get; set; }

        private List<int[]> markers = new List<int[]>();

        private Point[] smallLinePoints;
        private Point[] largeLinePoints;
        private bool isDrawingIndicator;
        private int indicatorLocation;
        private int xMarkerLocation;
        private int yMarkerLocation;
        private bool isDrawingMarker;
        private bool isDrawingLength;
        private string length;
        private SizeF lengthTextSize;

        public Ruler()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            if (this.BackColor == Color.Transparent)
            {
                this.BackColor = this.Parent.BackColor;
            }
        }

        public event EventHandler OnIndicatorLocationChanged;

        public void IndicatorLocationChanged(object sender, EventArgs e)
        {
            if (OnIndicatorLocationChanged != null)
            {
                OnIndicatorLocationChanged(indicatorLocation, EventArgs.Empty);
            }
        }

        public enum Markers
        {
            All = 0,
            Current
        }

        public Markers Marker { get; set; }

        public void DrawMarker(int xMarkerLocation, int yMarkerLocation)
        {
            markers.Add(
                new int[]
                {
                    xMarkerLocation,
                    yMarkerLocation
                });

            this.Refresh();
        }

        public void ClearMarker(Markers marker)
        {
            if (markers.Count >= 1)
            {
                switch (marker)
                {
                    case Markers.All:
                        markers.Clear();
                        break;
                    case Markers.Current:
                        markers.Remove(markers[markers.Count - 1]);
                        break;
                }
            }

            this.Refresh();
        }

        public void DrawIndicator(int location)
        {
            isDrawingIndicator = true;
            indicatorLocation = location;

            this.Refresh();
        }

        public int GetIndicatorLocation()
        {
            return indicatorLocation;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            DrawRuler(e);
        }

        private void DrawRuler(PaintEventArgs e)
        {
            if (Direction == Directions.Horizontal)
            {
                for (int index = 0; index < this.Width; index++)
                {
                    if (index % 50 == 0)
                    {
                        smallLinePoints = new Point[]
                            {
                        new Point(
                            index,
                            0
                        ),
                        new Point(
                            index,
                            10
                            )
                            };

                        using (Pen pen = new Pen(
                            new SolidBrush(
                                Color.FromArgb(
                                28, 124, 254
                                )
                                ),
                            1.0f
                            ))
                        {
                            e.Graphics.DrawLine(
                                pen,
                                smallLinePoints[0],
                                smallLinePoints[1]
                                );
                        }

                        string number = index.ToString();

                        SizeF textSize = e.Graphics.MeasureString(
                            number,
                            new Font(
                                this.Font.FontFamily,
                                this.Font.Size
                                )
                            );

                        e.Graphics.DrawString(
                            number,
                            new Font(
                                this.Font.FontFamily,
                                this.Font.Size
                                ),
                            new SolidBrush(
                                Color.FromArgb(
                                28, 124, 254
                                )
                                ),
                            ((index) - (textSize.Width / 2)),
                            10
                            );
                    }
                    else if (index % 2 == 0)
                    {
                        smallLinePoints = new Point[]
                        {
                                new Point(
                                    index,
                                    0
                                    ),
                                new Point(
                                    index,
                                    5
                                    )
                            };

                        using (Pen pen = new Pen(
                            Color.FromArgb(
                                246, 209, 150
                                ),
                            1.0f
                            )
                        )
                        {
                            e.Graphics.DrawLine(
                                pen,
                                smallLinePoints[0],
                                smallLinePoints[1]
                                );
                        }
                    }
                    else
                    {
                        if (index % 50 == 25)
                        {
                            smallLinePoints = new Point[]
                            {
                        new Point(
                            index,
                            0
                            ),
                        new Point(
                            index,
                            5
                            )
                            };

                            using (Pen pen = new Pen(
                                Color.Black,
                                1.0f
                                )
                                )
                            {
                                e.Graphics.DrawLine(
                                    pen,
                                    smallLinePoints[0],
                                    smallLinePoints[1]
                                    );
                            }
                        }
                    }
                }

                if (isDrawingIndicator)
                {
                    e.Graphics.DrawLine(
                        new Pen(
                            Brushes.Black,
                            1.0f
                            ),
                        new Point(
                            indicatorLocation,
                            0
                            ),
                        new Point(
                            indicatorLocation,
                            20
                            )
                        );
                }
            }
            else
            {
                StringFormat format = new StringFormat(
                    StringFormatFlags.DirectionVertical
                    );

                for (int index = 0; index < this.Height; index++)
                {
                    if (index % 50 == 0)
                    {
                        smallLinePoints = new Point[]
                            {
                        new Point(
                            0,
                            index
                        ),
                        new Point(
                            10,
                            index
                            )
                            };

                        using (Pen pen = new Pen(
                            Color.FromArgb(
                                28, 124, 254
                                ),
                            1.0f
                            ))
                        {
                            e.Graphics.DrawLine(
                                pen,
                                smallLinePoints[0],
                                smallLinePoints[1]
                                );
                        }

                        string number = index.ToString();

                        SizeF textSize = e.Graphics.MeasureString(
                            number,
                            new Font(
                                this.Font.FontFamily,
                                this.Font.Size
                                )
                            );

                        e.Graphics.DrawString(
                            number,
                            new Font(
                                this.Font.FontFamily,
                                this.Font.Size
                                ),
                            new SolidBrush(
                                Color.FromArgb(
                                28, 124, 254
                                )
                                ),
                            10,
                            ((index) - (textSize.Height / 2)),
                            format
                            );
                    }
                    else if (index % 2 == 0)
                    {
                        smallLinePoints = new Point[]
                        {
                                new Point(
                                    0,
                                    index
                                    ),
                                new Point(
                                    5,
                                    index
                                    )
                            };

                        using (Pen pen = new Pen(
                            Color.FromArgb(
                                246, 209, 150
                                ),
                            1.0f
                            )
                        )
                        {
                            e.Graphics.DrawLine(
                                pen,
                                smallLinePoints[0],
                                smallLinePoints[1]
                                );
                        }
                    }
                    else
                    {
                        if (index % 50 == 25)
                        {
                            smallLinePoints = new Point[]
                            {
                        new Point(
                            0,
                            index
                            ),
                        new Point(
                            5,
                            index
                            )
                            };

                            using (Pen pen = new Pen(
                                Color.Black,
                                1.0f
                                )
                                )
                            {
                                e.Graphics.DrawLine(
                                    pen,
                                    smallLinePoints[0],
                                    smallLinePoints[1]
                                    );
                            }
                        }
                    }
                }

                if (isDrawingIndicator)
                {
                    e.Graphics.DrawLine(
                        new Pen(
                            Brushes.Black,
                            1.0f
                            ),
                        new Point(
                            0,
                            indicatorLocation
                            ),
                        new Point(
                            20,
                            indicatorLocation
                            )
                        );
                }
            }

            if (!IsDragging)
            {
                if (isDrawingMarker || RequestDrawing)
                {
                    if (Direction == Directions.Horizontal)
                    {
                        foreach (int[] markerLocation in markers)
                        {
                            e.Graphics.DrawLine(
                                new Pen(
                                    new SolidBrush(
                                        Color.FromArgb(
                                            248, 109, 117
                                            )
                                        ),
                                    1.0f
                                    ),
                                new Point(
                                    markerLocation[0],
                                    0
                                    ),
                                new Point(
                                    markerLocation[0],
                                    this.Height
                                    )
                                );
                        }
                    }
                    else
                    {
                        foreach (int[] markerLocation in markers)
                        {
                            e.Graphics.DrawLine(
                                new Pen(
                                    new SolidBrush(
                                        Color.FromArgb(
                                            248, 109, 117
                                            )
                                        ),
                                    1.0f
                                    ),
                                new Point(
                                    0,
                                    markerLocation[1]
                                    ),
                                new Point(
                                    this.Width,
                                    markerLocation[1]
                                    )
                                );
                        }
                    }
                }
            }

            if (isDrawingLength)
            {
                e.Graphics.DrawString(
                    length,
                    this.Font,
                    Brushes.Black,
                    new Point(
                        (this.Width / 2) - (int)(lengthTextSize.Width / 2),
                        (this.Height - (int)lengthTextSize.Height - this.Margin.Bottom)
                        )
                    );
            }
        }

        private void Ruler_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right && e.Button != MouseButtons.Middle)
            {
                if (OnIndicatorLocationChanged != null)
                {
                    OnIndicatorLocationChanged.Invoke(indicatorLocation, EventArgs.Empty);
                }

                if (!IsDragging)
                {
                    // Draw a marker to indicate where the user has clicked.
                    xMarkerLocation = e.Location.X;
                    yMarkerLocation = e.Location.Y;

                    markers.Add(
                        new int[]
                        {
                    xMarkerLocation,
                    yMarkerLocation
                        });
                }

                isDrawingMarker = true;

            this.Refresh();
            }
        }

        private void Ruler_SizeChanged(object sender, EventArgs e)
        {
            if (Direction == Directions.Horizontal)
            {
                length = this.Width.ToString();
            }
            else
            {
                length = this.Height.ToString();
            }

            lengthTextSize = this.CreateGraphics().MeasureString(
                length,
                this.Font
                );

            isDrawingLength = true;

            this.Refresh();
        }

        private void Ruler_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.Direction == Directions.Horizontal)
            {
                length = e.Location.X.ToString();
            }
            else
            {
                length = e.Location.Y.ToString();
            }

            lengthTextSize = this.CreateGraphics().MeasureString(
                length,
                this.Font
                );

            isDrawingLength = true;

            this.Refresh();
        }

        private void Ruler_MouseLeave(object sender, EventArgs e)
        {
            length = this.Width.ToString();

            lengthTextSize = this.CreateGraphics().MeasureString(
                length,
                this.Font
                );

            isDrawingLength = true;

            this.Refresh();
        }
    }
}
