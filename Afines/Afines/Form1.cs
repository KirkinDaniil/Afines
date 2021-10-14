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
        private Graphics _graphic;
        private Pen _pen;
        private Polygon _polygon = new Polygon();
        private Point _point = new Point(0,0);
        private Point CenterPoint
        {
            get
            {

                (_point.X, _point.Y) = (MovingPoint.Location.X, MovingPoint.Location.Y);
                _point.X += MovingPoint.Width / 2;
                _point.Y += MovingPoint.Height / 2;
                return _point;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _graphic = pictureBox1.CreateGraphics();
            _pen = new Pen(Color.Black);
            ControlExtension.Draggable(MovingPoint, true);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            _graphic.Clear(Color.White);
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
                case DrawingState.DrawPolygon:
                    _graphic.Clear(Color.White);
                    _polygon.AddPoint(e.X,e.Y);
                    _polygon.Draw(_graphic,_pen);
                    break;
                default:
                    break;
            }

        }

        private void pointDrawer_Click(object sender, EventArgs e)
        {
            _graphic.Clear(Color.White);
            _drawingState = DrawingState.DrawPoint;
        }

        private void polygonDrawer_Click(object sender, EventArgs e)
        {
            _graphic.Clear(Color.White);
            _drawingState = DrawingState.DrawPolygon;
        }

        private void DXScroll_Scroll(object sender, ScrollEventArgs e)
        {
            _graphic.Clear(Color.White);
            _polygon.AfineShift(e.NewValue - e.OldValue, 0);
            _polygon.Draw(_graphic,_pen);
        }

        private void DYScroll_Scroll(object sender, ScrollEventArgs e)
        {
            _graphic.Clear(Color.White);
            _polygon.AfineShift(0, e.NewValue - e.OldValue);
            _polygon.Draw(_graphic, _pen);
        }

        private void RotateScroll_Scroll(object sender, ScrollEventArgs e)
        {
            _graphic.Clear(Color.White);
            _polygon.AfineRotate(
                e.NewValue - e.OldValue,
                CenterPoint.X - pictureBox1.Location.X,
               CenterPoint.Y - pictureBox1.Location.Y);
            _polygon.Draw(_graphic, _pen);
        }

        private void ScaleScroll_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.NewValue == e.OldValue)
            {
                return;
            }
            _graphic.Clear(Color.White);
            _polygon.AfineScale(Math.Sign(e.NewValue - e.OldValue)+1.5,
                CenterPoint.X - pictureBox1.Location.X,
                CenterPoint.Y - pictureBox1.Location.Y);
            _polygon.Draw(_graphic, _pen);
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            _graphic.Clear(Color.White);
            _polygon.Clear();
            _drawingState = DrawingState.Default;
        }
    }
}
