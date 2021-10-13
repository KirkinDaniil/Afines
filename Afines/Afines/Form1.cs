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
        DrawPoint,
        DrawEdge,
        DrawSquare,
        DrawPolygon
    }

    public partial class Form1 : Form
    {
        private DrawingState _drawingState;
        private Graphics graphic;

        private Point point;
        private Pen pen;
        private Polygon _polygon = new Polygon();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            graphic = pictureBox1.CreateGraphics();
            pen = new Pen(Color.Black);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            graphic.Clear(Color.White);
            switch (_drawingState)
            {
                case DrawingState.Default:
                    break;
                case DrawingState.DrawPoint:
                    //point = e.Location;
                    //Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    //bmp.SetPixel(point.X, point.Y, pen.Color);
                    //pictureBox1.Image = bmp;
                    break;
                case DrawingState.DrawEdge:
                    //if (Start)
                    //{
                    //    Edge edge = new Edge((point.X, point.Y), (e.Location.X, e.Location.Y));
                    //    edge.DrawEdge(graphic, pen);
                    //}
                    //else
                    //{
                    //    point = e.Location;
                    //}

                    //Start = !Start;
                    break;
                case DrawingState.DrawSquare:
                    break;
                case DrawingState.DrawPolygon:
                    graphic.Clear(Color.White);
                    _polygon.AddPoint(e.X,e.Y);
                    _polygon.Draw(graphic,pen);
                    break;
                default:
                    break;
            }

        }

        private void pointDrawer_Click(object sender, EventArgs e)
        {
            graphic.Clear(Color.White);
            _drawingState = DrawingState.DrawPoint;
        }


        private void polygonDrawer_Click(object sender, EventArgs e)
        {
            graphic.Clear(Color.White);
            _drawingState = DrawingState.DrawPolygon;
        }
    }
}
