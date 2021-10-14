using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afines
{
    class _2Edges
    {
        private Point[] _points;
        private Edge[] _edges; 
        private int counter = 0;
        public _2Edges()
        {
            _points = new Point[4];
            for (int i = 0; i < _points.Length; i++)
            {
                _points[i] = new Point();
            }
            _edges = new Edge[2];
            _edges[0] = new Edge(_points[0], _points[1]);
            _edges[1] = new Edge(_points[2], _points[3]);
        }
        public void AddPoint(double x, double y)
        {
            _points[counter].X = x;
            _points[counter].Y = y;
            counter = (counter + 1) % _points.Length;
        }
        public void Draw(Graphics graphics,Pen p)
        {
            _edges[0].DrawEdge(graphics, p);
            _edges[1].DrawEdge(graphics, p);
            Point intersect = Edge.IntersectionPoint(_edges[0], _edges[1]);
            if (intersect != null)
            {
                Pen pen = new Pen(Color.Red);
                graphics.DrawEllipse(pen, (float)intersect.X, (float)intersect.Y, 5, 5);
            }
        }
    }
}
