using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public Star(StarSystem s)
        {
            this.generateStar();
            this.setParent(s);
            LocalStarNumber = GlobalStarNumber++;
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
    }
}
