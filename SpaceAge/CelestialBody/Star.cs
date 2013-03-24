using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SpaceAge
{
    class Star
    {
        //
        // Commonly Associated with Stars
        //
        public static string[] StarColorString = { "White", "Brown", "Orange", "Yellow", "Blue", "Red" };
        public static Color[] StarColors = { Color.White, Color.Brown, Color.Orange, Color.Yellow, Color.Blue, Color.Red };

        public static Rectangle[] StarSizeRectangles = new Rectangle[] { new Rectangle(0, 0, 5, 5), new Rectangle(0, 0, 6, 6), new Rectangle(0, 0, 7, 7) ,
            new Rectangle(0,0,10,10), new Rectangle(0,0,12,12), new Rectangle(0,0,15,15)};


        public static int GlobalStarNumber = 0;
        public int LocalStarNumber;
        public ObjectCharactaristics.StarSize StarSize;
        public Color StarColor;

        public StarSystem parent;

        public static NumberGenerator numGen = NumberGenerator.getInstance();

        public Rectangle StarRectangle;

        public Star(StarSystem s)
        {
            this.generateStar();
            this.setParent(s);
            LocalStarNumber = GlobalStarNumber++;

            //
            // Graphics stuff initializers
            //
            StarRectangle = StarSizeRectangles[(int)StarSize];
        }

        public void generateStar()
        {
            StarSize = NumberGenerator.getInstance().RandomEnum<ObjectCharactaristics.StarSize>();
            StarColor = StarColors[NumberGenerator.getInstance().GetRandNumberInRange(0, StarColors.Length - 1)];
        }

        public void setParent(StarSystem s)
        {
            parent = s;
        }

        public override string ToString()
        {
            return Constants.intToHex(LocalStarNumber);
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
}
