using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afines
{

    public class Polygon
    {
        private List<Edge> _edges;
        private List<Point> _points;
        private Point _lastPoint;
        public Polygon()
        {
            _edges = new List<Edge>();
            _points = new List<Point>();
            _lastPoint = null;
        }
        public void AddPoint(double x,double y)
        {
            Point currentPoint = new Point(x, y);
            _points.Add(currentPoint);
            if (_lastPoint != null)
            {
                _edges.Add(new Edge(_lastPoint, currentPoint));
            }
            _lastPoint = currentPoint;
        }
        public void Draw(Graphics g, Pen p)
        {
            foreach (var item in _edges)
            {
                item.DrawEdge(g, p);
            }
            // draw last edge
            if (_edges.Count != 0)
            {
                new Edge(_points[0],_points[_points.Count - 1]).DrawEdge(g,p);
            }
            
        }
    }
}
