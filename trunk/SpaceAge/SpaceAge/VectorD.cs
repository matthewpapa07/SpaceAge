using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SpaceAge
{
    class VectorD
    {
        public double X;
        public double Y;

        public VectorD(PointD inPoint)
        {
            X = inPoint.X;
            Y = inPoint.Y;
        }

        public VectorD(VectorD inVectorD)
        {
            X = inVectorD.X;
            Y = inVectorD.Y;
        }

        public VectorD(double x, double y)
        {
            X = x;
            Y = y;
        }

        public void Normalize()
        {
            double Z = X * X + Y * Y;
            Z = Math.Sqrt(Z);
            if (Z == 0)
                return;

            X = X / Z;
            Y = Y / Z;
        }

        public int GetAngle()
        {
            double temp = Math.Atan2(Y, X);
            temp *= 180;
            temp /= Math.PI;
            return (int)temp;
        }

        public void SetVector(Point p)
        {
            X = (double)p.X;
            Y = (double)p.Y;
        }

        //public override bool Equals(object obj)
        //{
        //    PointD inP = (PointD)obj;

        //    if (inP.X == X && inP.Y == Y)
        //        return true;
        //}

    }
}
