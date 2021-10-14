using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Afines
{
    enum DrawingState
    {
        Default,
        PointPosAny,
        PointPosConvex,
        PointEdgePos,
        DrawPolygon
    }

    public partial class Form1 : Form
    {
        private DrawingState _drawingState;
        private Graphics graphic;
        public Bitmap bmp;

        private Point point;
        private Pen pen;
        private Polygon _polygon = new Polygon();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pen = new Pen(Color.Black);
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphic = Graphics.FromImage(bmp);
            graphic.Clear(Color.White);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            switch (_drawingState)
            {
                case DrawingState.Default:
                    break;
                case DrawingState.PointPosAny:
                    Point point = new Point(e.Location.X, e.Location.Y);
                    CheckPointInPoligon(point, _polygon);
                    //Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    //bmp.SetPixel(point.X, point.Y, pen.Color);
                    //pictureBox1.Image = bmp;
                    break;
                case DrawingState.PointPosConvex:
                    System.Drawing.Point pnt = new System.Drawing.Point(e.Location.X, e.Location.Y);
                    CheckPointInConvexPoligon(pnt, _polygon);
                    break;
                case DrawingState.PointEdgePos:
                    Point pointEdge = new Point(e.Location.X, e.Location.Y);
                    CheckPointEdgePosition(pointEdge, _polygon._edges[_polygon._edges.Count - 1]);
                    break;
                case DrawingState.DrawPolygon:
                    graphic.Clear(Color.White);
                    _polygon.AddPoint(e.X, e.Y);
                    _polygon.Draw(bmp, graphic, pen);
                    pictureBox1.Image = bmp;
                    break;
                default:
                    break;
            }

        }

        private void CheckPointEdgePosition(Point pointEdge, Edge edge)
        {
            var dx = edge.firstPoint.X - edge.secondPoint.X;
            var dy = edge.firstPoint.Y - edge.secondPoint.Y;
            double length = Math.Sqrt(dy * dy + dx * dx);
            double dist = (dx * pointEdge.Y - dy * pointEdge.X - dx * edge.firstPoint.Y + dy * edge.firstPoint.X) / length;

            if (dist > 0)
            {
                MessageBox.Show("Точка справа");
            }
            else if (dist < 0)
            {
                MessageBox.Show("Точка слева");
            }
            else 
            {
                MessageBox.Show("Точка на ребре");
            }
        }

        private void CheckPointInConvexPoligon(System.Drawing.Point p, Polygon poly)
        {
            if (poly == null)
            {
                MessageBox.Show("Сперва полигон, извольте");
            }

            int crossCount = 0;
            while (p.X < bmp.Width)
            {
                Color clr = bmp.GetPixel(p.X, p.Y);
                if (clr.R != 255 || clr.G != 255 || clr.B != 255)
                {
                    Point temp = poly._points.FirstOrDefault(point => point.X == p.X && point.Y == p.Y);
                    if (temp != null)
                    {
                        List<Edge> multicrossed = poly._edges.Where(edge => edge.firstPoint.X == p.X && edge.firstPoint.Y == p.Y ||
                        edge.secondPoint.X == p.X && edge.secondPoint.Y == p.Y).ToList();
                        foreach (Edge edge in multicrossed)
                        {
                            if (p.Y < edge.firstPoint.Y || p.Y < edge.secondPoint.Y)
                            {
                                ++crossCount;
                            }
                        }
                        p.X += 1;
                        continue;
                    }
                    ++p.X;
                    ++crossCount;
                }

                p.X += 1;
            }

            if (crossCount % 2 == 0)
            {
                MessageBox.Show("Точка не принадлежит многоугольнику");
            }
            else
            {
                MessageBox.Show("Точка принадлежит многоугольнику");
            }
        }

        private void pointDrawer_Click(object sender, EventArgs e)
        {
            _drawingState = DrawingState.PointPosAny;
        }

        private void polygonDrawer_Click(object sender, EventArgs e)
        {
            graphic.Clear(Color.White);
            _drawingState = DrawingState.DrawPolygon;
        }

        private void CheckPointInPoligon(Point p, Polygon poly)
        {
            if (poly == null)
            {
                MessageBox.Show("Сперва полигон, извольте");
            }

            double degreeSumm = 0;

            for (int i = 0; i < poly._points.Count - 1; ++i)
            {
                degreeSumm += GetDegreeBetweenEdges(p, poly._points[i], p, poly._points[i + 1]);
            }

            degreeSumm += GetDegreeBetweenEdges(p, poly._points[poly._points.Count - 1], p, poly._points[0]);

            var eps = 0.00001;
            if (Math.Abs(degreeSumm - 0) < eps)
            {
                MessageBox.Show("Точка не принадлежит многоугольнику");
            }  
            else
            {
                MessageBox.Show("Точка принадлежит многоугольнику");
            } 
        }

        private double GetDegreeBetweenEdges(Point point1, Point point2, Point point3, Point point4)
        {
            double dx1 = point2.X - point1.X;
            double dy1 = point2.Y - point1.Y;
            double dx2 = point4.X - point3.X;
            double dy2 = point4.Y - point3.Y;

            double len_e1 = Math.Sqrt(dx1 * dx1 + dy1 * dy1);
            double len_e2 = Math.Sqrt(dx2 * dx2 + dy2 * dy2);
            double scalarProd = dx1 * dx2 + dy1 * dy2;

            return Math.Acos(scalarProd / (len_e1 * len_e2)) * Math.Sign(dx1 * dy2 - dy1 * dx2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _drawingState = DrawingState.PointPosConvex;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            graphic.Clear(Color.White);
            _polygon = new Polygon();
            pictureBox1.Image = bmp;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _drawingState = DrawingState.PointEdgePos;
        }
    }
}
