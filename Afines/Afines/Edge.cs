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
        public Afines.Point firstPoint { get; set; }
        public Afines.Point secondPoint { get; set; }

        public Edge(Afines.Point _first, Afines.Point _second)
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
            g.DrawLine(p, (int)firstPoint.X, (int)firstPoint.Y, (int)secondPoint.X, (int)secondPoint.Y);
            /*
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
            */
        }
        public static bool IsBetween(double a, double b,double c)
        {
            return Math.Min(a, b) <= c && Math.Max(a, b) >= c;
        }
        public static Afines.Point IntersectionPoint(Edge e1, Edge e2)
        {
            double x1 = e1.firstPoint.X,
                x2 = e1.secondPoint.X,
                x3 = e2.firstPoint.X,
                x4 = e2.secondPoint.X;

            double y1 = e1.firstPoint.Y,
                 y2 = e1.secondPoint.Y,
                 y3 = e2.firstPoint.Y,
                 y4 = e2.secondPoint.Y;

            double n;
            if (y2 - y1 != 0)
            {  // a(y)
                double q = (x2 - x1) / (y1 - y2);
                double sn = (x3 - x4) + (y3 - y4) * q; 
                if (sn == 0) 
                { 
                    return null; 
                }  // c(x) + c(y)*q
                double fn = (x3 - x1) + (y3 - y1) * q;   // b(x) + b(y)*q
                n = fn / sn;
            }
            else
            {
                if (y3 == y4) 
                { 
                    return null; 
                }  // b(y)
                n = (y3 - y1) / (y3 - y4);   // c(y)/b(y)
            }
            double ansX = x3 + (x4 - x3) * n;  // x3 + (-b(x))*n
            double ansY = y3 + (y4 - y3) * n;  // y3 +(-b(y))*n

            if (IsBetween(x1,x2,ansX) && IsBetween(y1,y2,ansY) 
                && IsBetween(x3, x4, ansX) && IsBetween(y3, y4, ansY))
            {
                return new Point(ansX, ansY);
            }
            else
            {
                return null;
            }
            

        }
    }
}
