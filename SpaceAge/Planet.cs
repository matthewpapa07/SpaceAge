using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceAge
{
    class Planet
    {
        public static double CHANCE_OF_PLANET_INHABITED = 0.37;
        public static double CHANCE_OF_PLANET_SUPERCENTER = 0.12;

        public static int GlobalPlanetNumber = 0;
        public int LocalPlanetNumber;
        public ObjectCharactaristics.PlanetSize planetSize;
        public ObjectCharactaristics.Position planetPosition;
        public StarSystem parent;
        public InteractionCenter planetInteractionCenter = null;       // Allow for multiple of these later...
        public bool IsInhabited = false;
        public int Population = 0;

        public Planet(StarSystem s)
        {
            if (s == null)
                throw new Exception();
            parent = s;
            this.generatePlanet();

            LocalPlanetNumber = GlobalPlanetNumber++;
        }

        public void generatePlanet()
        {
            planetSize = NumberGenerator.getInstance().RandomEnum<ObjectCharactaristics.PlanetSize>();
            planetPosition = NumberGenerator.getInstance().RandomEnum<ObjectCharactaristics.Position>();
            if (NumberGenerator.getInstance().LinearPmfResult(CHANCE_OF_PLANET_INHABITED))
            {
                IsInhabited = true;
                Population = NumberGenerator.getInstance().getNumber(); // TODO: Shape this number later
                planetInteractionCenter = new InteractionCenter("Planet" + this.ToString() + " Interaction Center", this);
            }
            else
            {
                IsInhabited = false;
            }
        }

        public override string ToString()
        {
            return Constants.intToHex(LocalPlanetNumber);
        }
    }
}
