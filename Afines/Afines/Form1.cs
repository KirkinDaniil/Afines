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
    }

    public partial class Form1 : Form
    {
        private DrawingState _drawingState;
        private Graphics graphic;
        private bool Start;
        private Point point;
        private Edge edge;
        private Pen pen;
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

            if (_drawingState == DrawingState.DrawEdge)
            {
                if (Start)
                {
                    Edge edge = new Edge((point.X, point.Y), (e.Location.X, e.Location.Y));
                    edge.DrawEdge(graphic, pen);
                }
                else 
                {
                    point = e.Location;
                }

                Start = !Start;
            }

            else if(_drawingState == DrawingState.DrawPoint)
            {
                point = e.Location;
                Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                bmp.SetPixel(point.X, point.Y, pen.Color);
                pictureBox1.Image = bmp;
            } 

            else if(_drawingState == DrawingState.DrawSquare)
            {

            }
        }

        private void pointDrawer_Click(object sender, EventArgs e)
        {
            graphic.Clear(Color.White);
            _drawingState = DrawingState.DrawPoint;
        }

        private void edgeDrawer_Click(object sender, EventArgs e)
        {
            graphic.Clear(Color.White);
            _drawingState = DrawingState.DrawEdge;
        }

        private void squareDrawer_Click(object sender, EventArgs e)
        {
            graphic.Clear(Color.White);
            _drawingState = DrawingState.DrawSquare;
        }
    }
}
