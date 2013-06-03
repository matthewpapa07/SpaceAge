using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
