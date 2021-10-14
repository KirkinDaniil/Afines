using System;

namespace Afines
{
    public class Matrix
    {

        private readonly double[,] _data;
        public int N
        {
            get
            {
                return _data.GetUpperBound(0) + 1;
            }
        }
        public int M
        {
            get
            {
                return _data.GetUpperBound(1) + 1;
            }
        }

        public Matrix(int n)
        {
            _data = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                _data[i, i] = 1.0;
            }
        }
        public Matrix(int m, int n)
        {
            _data = new double[m, n];
        }

        public Matrix(double[,] data)
        {
            _data = data;
        }

        public ref double this[int row, int column] => ref _data[row, column];

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.M != b.N)
            {
                return null;
            }
            Matrix c = new Matrix(a.N, b.M);
            for (int i = 0; i < c.N; i++)
            {
                for (int j = 0; j < c.M; j++)
                {
                    double sum = 0;
                    for (int m = 0; m < a.M; m++)
                    {
                        sum += a[i, m] * b[m, j];
                    }
                    c[i, j] = sum;
                }
            }
            return c;
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.M != b.M || a.N != b.N)
            {
                return null;
            }
            Matrix c = new Matrix(a.N, b.M);
            for (int i = 0; i < c.N; i++)
            {
                for (int j = 0; j < c.M; j++)
                {
                    c[i, j] = a[i, j] + b[i, j];
                }
            }
            return c;
        }
        public static Matrix AfineShiftMatrix(double dx, double dy)
        {
            double[,] data = new double[,]
            {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { -dx, -dy, 1 }
            };
            return new Matrix(data);
        }
        public static Matrix AfineRotateMatrix(double angle)
        {
            double angleInRad = angle * Math.PI / 180;
            double[,] data = new double[,]
            {
                { Math.Cos(angleInRad), Math.Sin(angleInRad), 0 },
                { -Math.Sin(angleInRad), Math.Cos(angleInRad), 0 },
                { 0, 0, 1 }
            };
            return new Matrix(data);
        }
        public static Matrix AfineRotateAroundMatrix(double angle,double a,double b)
        {
            double phi = (angle / 180.0 * Math.PI);
            double[,] affinMatr = new double[3, 3];
            affinMatr[0, 0] = (double)Math.Cos(phi);
            affinMatr[0, 1] = (double)Math.Sin(phi);
            affinMatr[0, 2] = 0;
            affinMatr[1, 0] = (double)-Math.Sin(phi);
            affinMatr[1, 1] = (double)Math.Cos(phi);
            affinMatr[1, 2] = 0;
            affinMatr[2, 0] = (double)(-a * Math.Cos(phi) + b * Math.Sin(phi) + a);
            affinMatr[2, 1] = (double)(-a * Math.Sin(phi) - b * Math.Cos(phi) + b);
            affinMatr[2, 2] = 1;
            return new Matrix(affinMatr);
        }
        public static Matrix AfineScaleMatrix(double coef,double a,double b)
        {
            double[,] affinMatr = new double[3, 3];
            affinMatr[0, 0] = coef;
            affinMatr[0, 1] = 0;
            affinMatr[0, 2] = 0;
            affinMatr[1, 0] = 0;
            affinMatr[1, 1] = coef;
            affinMatr[1, 2] = 0;
            affinMatr[2, 0] = (1 - coef) * a;
            affinMatr[2, 1] = (1 - coef) * b;
            affinMatr[2, 2] = 1;
            return new Matrix(affinMatr);
        }
    }
}
