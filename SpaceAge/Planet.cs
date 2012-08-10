using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceAge
{
    class Planet
    {
        public static int GlobalPlanetNumber = 0;
        public int LocalPlanetNumber;
        public ObjectCharactaristics.PlanetSize planetSize;
        public ObjectCharactaristics.Position planetPosition;
        public StarSystem parent;
        public InteractionCenter planetInteractionCenter;       // Allow for multiple of these later...

        public Planet(StarSystem s)
        {
            this.generatePlanet();
            this.setParent(s);
            LocalPlanetNumber = GlobalPlanetNumber++;
        }

        public void generatePlanet()
        {
            planetSize = NumberGenerator.getInstance().RandomEnum<ObjectCharactaristics.PlanetSize>();
            planetPosition = NumberGenerator.getInstance().RandomEnum<ObjectCharactaristics.Position>();
            planetInteractionCenter = new InteractionCenter("Planet" + this.ToString() + " Interaction Center", this);
        }

        public void setParent(StarSystem s)
        {
            parent = s;
        }

        public override string ToString()
        {
            return Constants.intToHex(LocalPlanetNumber);
        }
    }
}
