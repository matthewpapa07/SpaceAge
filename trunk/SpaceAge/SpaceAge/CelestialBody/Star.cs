﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SpaceAge
{
    class Star
    {
        public static int GlobalStarCounter = 0;
        public int UniqueStarNumber;

        public StarConstant.StarClass StarClass;
        public Color StarColor;
        public double StarMass;
        public string StarClassString;

        public StarSystem parent;

        public static NumberGenerator numGen = NumberGenerator.getInstance();

        public Rectangle StarRectangle;

        public Star(StarSystem s)
        {
            this.generateStar();
            this.setParent(s);
            UniqueStarNumber = GlobalStarCounter++;
        }

        public void generateStar()
        {
            double StarSizeP = numGen.GetRandDouble();

            double Counter = 0.0;
            for (int i = 0; i < StarConstant.StarTypes; i++)
            {
                Counter += StarConstant.StarP[i];
                if (StarSizeP <= Counter)
                {
                    StarClass = (StarConstant.StarClass)i;
                    break;
                }
            }

            StarMass = numGen.GetRandDoubleInRange(StarConstant.MassMin[(int)StarClass], StarConstant.MassMax[(int)StarClass]);
            StarColor = StarConstant.BaseColor[(int)StarClass];
            StarRectangle = new Rectangle(0, 0, StarConstant.RectSideLength[(int)StarClass], StarConstant.RectSideLength[(int)StarClass]);
            StarClassString = StarConstant.StarClassStr[(int)StarClass];
        }

        public void setParent(StarSystem s)
        {
            parent = s;
        }

        public override string ToString()
        {
            return Constants.intToHex(UniqueStarNumber);
        }

        public void DrawStarGraphics(Graphics GraphicsToUse, int x, int y)
        {
            StarRectangle.X = x;
            StarRectangle.Y = y;

            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(StarRectangle);
            PathGradientBrush pthGrBrush = new PathGradientBrush(path);
            pthGrBrush.CenterColor = StarColor;
            pthGrBrush.SurroundColors = new Color[] { Color.FromArgb(50, StarColor) };
            GraphicsToUse.FillEllipse(pthGrBrush, StarRectangle);
        }

        //
        // TODO: Put in my graphics library
        //
        public static Color LightenColor(Color InColor)
        {
            return InColor;
        }
    }

    static class StarConstant
    {
        //
        // Commonly Associated with Stars
        //
        public static int StarTypes = 10;
        public enum StarClass { O, B, A, F, G, K, M, L, T, Y };       // Ten total star classifications
        public static string[] StarClassStr = { "XXXL", "XXL", "XL", "L", "M", "S", "XS", "XXS", "XXS", "XXS" };
        public static double[] StarP = { 0.03, 0.07, 0.07, 0.13, 0.15, 0.2, 0.3, 0.03, 0.01, 0.01 };    // These numbers MUST total to 1
        public static Color[] BaseColor = { Color.FromArgb(0x00, 0xbf, 0xff), Color.FromArgb(0x87, 0xce, 0xeb), Color.FromArgb(0xb0, 0xe0, 0xe6),
                                            Color.FromArgb(0xf8, 0xf8, 0xff), Color.FromArgb(0xff, 0xff, 0x00), Color.FromArgb(0xff, 0xa5, 0x00),
                                            Color.FromArgb(0xff, 0x00, 0x00), Color.FromArgb(0xb2, 0x22, 0x22), Color.FromArgb(0xcd, 0x85, 0x3f),
                                            Color.FromArgb(0x8b, 0x45, 0x13) };
        public static double[] MassMin = { 16.0, 2.1, 1.4, 1.04, 0.8, 0.45, 0.30, 0.20, 0.10, 0.05 };
        public static double[] MassMax = { 30.0, 16.0, 2.1, 1.4, 1.04, 0.8, 0.45, 0.30, 0.20, 0.10 };
        
        public static int[] RectSideLength = { 45, 41, 38, 36, 34, 30, 28, 27, 26, 25 };
    }
}