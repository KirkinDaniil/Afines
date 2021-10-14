namespace Afines
{
    public class Point
    {
        public double X { set; get; }
        public double Y { set; get; }
        public Point(double x,double y)
        {
            X = x;
            Y = y;
        }
        public Matrix GetMatrix()
        {
            return new Matrix(new double[,] { { X, Y, 1 } });
        }
        public void AfineShift(double dx,double dy)
        {
            Matrix a = GetMatrix();
            Matrix res = a * Matrix.AfineShiftMatrix(dx, dy);
            X = res[0, 0];
            Y = res[0, 1];
        }
        public void AfineRotate(double angle,double x, double y)
        {
            Matrix a = GetMatrix();
            //Matrix res = a * Matrix.AfineShiftMatrix(-x, -y)*Matrix.AfineRotateMatrix(angle)*Matrix.AfineShiftMatrix(x,y);
            Matrix res = a * Matrix.AfineRotateAroundMatrix(angle, x, y);
            X = res[0, 0];
            Y = res[0, 1];
        }
        public void AfineScale(double coef,double x,double y)
        {
            Matrix a = GetMatrix();
            Matrix res = a * Matrix.AfineScaleMatrix(coef, x, y);
               
            X = res[0, 0];
            Y = res[0, 1];
        }
    }
}
