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
        public ObjectCharactaristics.CommonAtmosphere[] CommonAtmosphere;
        public ObjectCharactaristics.RareAtmosphere[] RareAtmosphere;
        public ObjectCharactaristics.CommonElements[] CommonElements;
        public ObjectCharactaristics.RareElements[] RareElements;
        public StarSystem parent;
        public InteractionCenter planetInteractionCenter = null;       // Allow for multiple of these later...
        public bool IsInhabited = false;
        public int Population = 0;

        public Planet(StarSystem s)
        {
            if (s == null)
                throw new Exception();
            parent = s;
            LocalPlanetNumber = GlobalPlanetNumber++;
            this.generatePlanet();
        }

        public void generatePlanet()
        {
            NumberGenerator n = NumberGenerator.getInstance();

            planetSize = n.RandomEnum<ObjectCharactaristics.PlanetSize>();
            planetPosition = n.RandomEnum<ObjectCharactaristics.Position>();

            CommonAtmosphere = n.GetEnumScaledList<ObjectCharactaristics.CommonAtmosphere>(0.8);
            RareAtmosphere = n.GetEnumScaledList<ObjectCharactaristics.RareAtmosphere>(0.45);
            CommonElements = n.GetEnumScaledList<ObjectCharactaristics.CommonElements>(0.70);
            RareElements = n.GetEnumScaledList<ObjectCharactaristics.RareElements>(0.40);

            if (CommonAtmosphere.Contains(ObjectCharactaristics.CommonAtmosphere.Oxygen) || CommonAtmosphere.Contains(ObjectCharactaristics.CommonAtmosphere.CarbonDioxide))
                if (n.LinearPmfResult(CHANCE_OF_PLANET_INHABITED))
                {
                    IsInhabited = true;
                    if (n.LinearPmfResult(CHANCE_OF_PLANET_SUPERCENTER))
                    {
                        Population = n.GetRandomNumber();
                    }
                    else
                    {
                        Population = n.GetRandNumberInRange(0, 5000000);
                    }
                    planetInteractionCenter = new InteractionCenter("Planet" + this.ToString() + " Interaction Center", this);
                }
        }

        public override string ToString()
        {
            return Constants.intToHex(LocalPlanetNumber);
        }
    }
}
