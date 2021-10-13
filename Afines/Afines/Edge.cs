using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afines
{
    public class Edge
    {
        public (double X, double Y) firstPoint { get; set; }
        public (double X, double Y) secondPoint { get; set; }

        public Edge((double, double) _first, (double, double) _second)
        {
            firstPoint = _first;
            secondPoint = _second;
        }

        private void Swap(ref int x, ref int y)
        {
            int t = x;
            x = y;
            y = t;
        }

        private void DrawPoint(Graphics g, bool steep, int x, int y, double gradient)
        {
            gradient = 1 - gradient;
            //g = pictureBox1.CreateGraphics();
            Bitmap bm = new Bitmap(1, 1);
            bm.SetPixel(0, 0, Color.FromArgb((int)(255 * gradient), (int)(255 * gradient), (int)(255 * gradient)));
            if (steep)
                g.DrawImageUnscaled(bm, y, x);
            else
                g.DrawImageUnscaled(bm, x, y);

        }

        public void DrawEdge(Graphics g, Pen p)
        {
            int x0 = (int)firstPoint.X;
            int y0 = (int)firstPoint.Y;
            int x1 = (int)secondPoint.X;
            int y1 = (int)secondPoint.Y;
            bool steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);
            if (steep)
            {
                Swap(ref x0, ref y0);
                Swap(ref x1, ref y1);
            }
            if (x0 > x1)
            {
                Swap(ref x0, ref x1);
                Swap(ref y0, ref y1);
            }

            DrawPoint(g, steep, x0, y0, 1);
            DrawPoint(g, steep, x1, y1, 1);
            float deltaX = x1 - x0;
            float deltaY = y1 - y0;
            float gradient = deltaY / deltaX;
            float y = y0 + gradient;
            for (var x = x0 + 1; x <= x1 - 1; x++)
            {
                DrawPoint(g, steep, x, (int)y, 1 - (y - (int)y));
                DrawPoint(g, steep, x, (int)y + 1, y - (int)y);
                y += gradient;
            }
        }
    }
}
