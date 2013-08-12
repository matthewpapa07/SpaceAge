using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceAge
{
    static class GraphicsLib
    {
        public static void ApplyListviewProperties(ListView lv)
        {
            lv.View = View.Details;
            lv.FullRowSelect = true;
            lv.GridLines = true;
            lv.MultiSelect = false;
        }

        public static Color ColorMix(Color c1, Color c2)
        {

            int _r = Math.Min((c1.R + c2.R), 255);
            int _g = Math.Min((c1.G + c2.G), 255);
            int _b = Math.Min((c1.B + c2.B), 255);

            return Color.FromArgb(Convert.ToByte(_r),
                             Convert.ToByte(_g),
                             Convert.ToByte(_b));
        }

        public static Bitmap RotateBitmap(Bitmap b, float angle)
        {
            //create a new empty bitmap to hold rotated image
            Bitmap returnBitmap = new Bitmap(b.Width, b.Height);
            //make a graphics object from the empty bitmap
            Graphics g = Graphics.FromImage(returnBitmap);
            //move rotation point to center of image
            g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
            //rotate
            g.RotateTransform(angle);
            //move image back
            g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
            //draw passed in image onto graphics object
            g.DrawImage(b, new Point(0, 0));
            return returnBitmap;
        }

        public static Bitmap RotateBitmapEx(Bitmap b, int angle)
        {
            //create a new empty bitmap to hold rotated image
            Bitmap returnBitmap = new Bitmap(b.Width, b.Height);
            //make a graphics object from the empty bitmap
            Graphics g = Graphics.FromImage(returnBitmap);
            //move rotation point to center of image
            g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
            //rotate
            angle = angle + 360;
            angle = angle + 270;
            angle = angle % 360;
            g.RotateTransform(angle);
            //move image back
            g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
            //draw passed in image onto graphics object
            g.DrawImage(b, new Point(0, 0));
            return returnBitmap;
        }

        public static PointEx GetPointInRelativeGrid(Point ActualCoor, Point GridStart, Point GridDimensions)
        {
            //if(((GridStart.X - ActualCoor.X) > 0) && ((GridStart.Y - ActualCoor.Y) > 0))
            if ((ActualCoor.X > GridStart.X) && (ActualCoor.Y > GridStart.Y))
            {
                if((ActualCoor.X < (GridStart.X + GridDimensions.X)) && (ActualCoor.Y < (GridStart.Y + GridDimensions.Y)))
                {
                    return new PointEx(ActualCoor.X - GridStart.X, ActualCoor.Y - GridStart.Y);
                }
            }
            return null;
        }

        public static void DrawImageEx(Graphics GraphicsToUse, Bitmap BmToDraw, PointEx DrawLocation)
        {
            int x = DrawLocation.X - (BmToDraw.Width / 2);
            int y = DrawLocation.Y - (BmToDraw.Height / 2); 
            Rectangle OutRect = new Rectangle(0, 0, BmToDraw.Width, BmToDraw.Height);
            if (x < 0)
            {
                OutRect.Width += x;
                OutRect.X = Math.Abs(x);
                x = 0;
            }
            if (y < 0)
            {
                OutRect.Height += y;
                OutRect.Y = Math.Abs(y);
                y = 0;
            }
            //GraphicsToUse.DrawImage(BmToDraw, DrawLocation.X, DrawLocation.Y);
            GraphicsToUse.DrawImage(BmToDraw, x, y, OutRect, GraphicsUnit.Pixel);
        }

    }
}
