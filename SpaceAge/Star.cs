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
        public ObjectCharactaristics.StarSize starSize;
        public ObjectCharactaristics.StarType starType;

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
            starSize = NumberGenerator.getInstance().RandomEnum<ObjectCharactaristics.StarSize>();
            starType = NumberGenerator.getInstance().RandomEnum<ObjectCharactaristics.StarType>();
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
