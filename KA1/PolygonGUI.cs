using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KA1
{
    class PolygonGUI : Polygon
    {
        private const int RADIUS = 8; //радиус кружка точки
        private static Font DRAW_FONT = new Font("Arial", 8, FontStyle.Bold); //шрифт номера точки
        private static StringFormat FORMAT = new StringFormat(); //формат отрисовки номера
        private double MaxPerimeter = 0;
        static PolygonGUI()
        {
            FORMAT.Alignment = StringAlignment.Center;
            FORMAT.LineAlignment = StringAlignment.Center;
        }
        private PictureBox pb;
        private Graphics canvas;
        public PolygonGUI(PictureBox pb)
        {
            this.pb = pb;
            canvas = pb.CreateGraphics();
        }

        public new bool AddPoint(int X, int Y)
        {
            foreach(Point p in points)
            {
                if(Math.Pow(p.X - X, 2) + Math.Pow(p.Y - Y, 2) < Math.Pow(2 * RADIUS, 2))
                {
                    return false;
                }
            }
            base.AddPoint(X, Y);
            canvas.FillEllipse(Brushes.Yellow, X - RADIUS, Y - RADIUS, 2 * RADIUS, 2 * RADIUS);
            canvas.DrawEllipse(Pens.Black, X - RADIUS, Y - RADIUS, 2 * RADIUS, 2 * RADIUS);
            canvas.DrawString((points.Count - 1).ToString(), DRAW_FONT, Brushes.Black, X, Y, FORMAT);
            return true;
        }

        public void CreatePolygonGUI(ref long progress, ref long total)
        {
            MaxPerimeter = base.CreatePolygon(ref progress, ref total);
            if (MaxPerimeter > 0)
            {
                for(int i = 0; i < points.Count; ++i)
                {
                    canvas.DrawLine(Pens.Coral, points[i].X, points[i].Y, points[(i + 1) % points.Count].X, points[(i + 1) % points.Count].Y);
                }
               
            }
            return ;
        }

        public void Clear()
        {
            canvas.Clear(SystemColors.Control);
            points = new List<Point>();
        }

    }
}
