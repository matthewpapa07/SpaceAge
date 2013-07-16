using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SpaceAge
{
    class PointD
    {
        public double X = 0;
        public double Y = 0;

        public PointD(double inx, double iny)
        {
            X = inx;
            Y = iny;
        }

        public PointD(PointD InPoint)
        {
            X = InPoint.X;
            Y = InPoint.Y;
        }


        public PointD(Point inPoint)
        {
            X = inPoint.X;
            Y = inPoint.Y;
        }

        public void ReplaceDataFromPoint(Point inPoint)
        {
            X = inPoint.X;
            Y = inPoint.Y;
        }

        public double Distance(PointD OtherPt)
        {
            double x = X - OtherPt.X;
            double y = Y - OtherPt.Y;

            x = Math.Pow(x, 2);
            y = Math.Pow(y, 2);

            double determinant = x + y;

            return Math.Sqrt(determinant);
        }

        public override bool Equals(object obj)
        {
            if (obj is PointD)
            {
                PointD OtherPoint = (PointD)obj;
                if (OtherPoint.X == X)
                    if (OtherPoint.Y == Y)
                        return true;

                return false;
            }
            else
                throw new FormatException();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public Point ToPoint()
        {
            return new Point((int)X, (int)Y);
        }
    }
}
