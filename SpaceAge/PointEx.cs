using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SpaceAge
{
    class PointEx
    {
        public int X = 0;
        public int Y = 0;

        public PointEx(int inx, int iny)
        {
            X = inx;
            Y = iny;
        }

        public PointEx(PointD InPoint)
        {
            X = (int)InPoint.X;
            Y = (int)InPoint.Y;
        }

        public PointEx(Point inPoint)
        {
            X = inPoint.X;
            Y = inPoint.Y;
        }

        public void ReplaceDataFromPointEx(PointEx inPoint)
        {
            X = inPoint.X;
            Y = inPoint.Y;
        }

        public int Distance(PointEx OtherPt)
        {
            double x = X - OtherPt.X;
            double y = Y - OtherPt.Y;

            x = Math.Pow(x, 2);
            y = Math.Pow(y, 2);

            double determinant = x + y;

            return (int)Math.Sqrt(determinant);
        }

        public override bool Equals(object obj)
        {
            if (obj is PointEx)
            {
                PointEx OtherPoint = (PointEx)obj;
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
            return new Point(X, Y);
        }
    }
}
