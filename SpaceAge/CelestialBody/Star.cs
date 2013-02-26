using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SpaceAge
{
    class Star
    {
        public static int GlobalStarNumber = 0;
        public int LocalStarNumber;
        public ObjectCharactaristics.StarSize StarSize;
        public ObjectCharactaristics.StarType StarColor;

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
            StarRectangle = ObjectCharactaristics.StarSizeRectangles[(int)StarSize];
        }

        public void generateStar()
        {
            StarSize = NumberGenerator.getInstance().RandomEnum<ObjectCharactaristics.StarSize>();
            StarColor = NumberGenerator.getInstance().RandomEnum<ObjectCharactaristics.StarType>();
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

            GraphicsToUse.FillEllipse(ObjectCharactaristics.StarTypeBrushes[(int)StarColor], StarRectangle);
        }
    }
}
