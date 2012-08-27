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

        // Planet resource data
        // TODO: Refactor out and up a ResourceBearing object so other things besides planets can be harvested
        public ObjectCharactaristics.PlanetSize PlanetSize;
        public ObjectCharactaristics.Position PlanetPosition;
        public ObjectCharactaristics.CommonAtmosphere[] CommonAtmosphere;
        public ObjectCharactaristics.RareAtmosphere[] RareAtmosphere;
        public ObjectCharactaristics.CommonElements[] CommonElements;
        public ObjectCharactaristics.RareElements[] RareElements;
        public ObjectCharactaristics.ResourcesStatic[] ResourcesStatic;
        public int[] CommonAtmosphereQuantity;
        public int[] RareAtmosphereQuantity;
        public int[] CommonElementsQuantity;
        public int[] RareElementsQuantity;
        public int[] ResourcesStaticQuantity;

        public StarSystem Parent;
        public InteractionCenter PlanetInteractionCenter = null;       // Allow for multiple of these later...
        public List<RawMaterialExtractor> PlanetExtractors = new List<RawMaterialExtractor>(2);
        public bool IsInhabited = false;
        public int Population = 0;

        public Planet(StarSystem s)
        {
            if (s == null)
                throw new Exception();
            Parent = s;
            LocalPlanetNumber = GlobalPlanetNumber++;
            this.generatePlanet();
        }

        public void generatePlanet()
        {
            NumberGenerator n = NumberGenerator.getInstance();

            PlanetSize = n.RandomEnum<ObjectCharactaristics.PlanetSize>();
            PlanetPosition = n.RandomEnum<ObjectCharactaristics.Position>();

            generateResources();

            if (CommonAtmosphere.Contains(ObjectCharactaristics.CommonAtmosphere.Oxygen) || CommonAtmosphere.Contains(ObjectCharactaristics.CommonAtmosphere.CarbonDioxide))
            {
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
                    PlanetInteractionCenter = InteractionCenter.CityCenterOnPlanet(this);
                }
            }
        }

        private void generateResources()
        {
            NumberGenerator n = NumberGenerator.getInstance();

            CommonAtmosphere = n.GetEnumScaledList<ObjectCharactaristics.CommonAtmosphere>(0.8);
            RareAtmosphere = n.GetEnumScaledList<ObjectCharactaristics.RareAtmosphere>(0.45);
            CommonElements = n.GetEnumScaledList<ObjectCharactaristics.CommonElements>(0.70);
            RareElements = n.GetEnumScaledList<ObjectCharactaristics.RareElements>(0.40);
            ResourcesStatic = n.GetEnumScaledList<ObjectCharactaristics.ResourcesStatic>(0.60);

            CommonAtmosphereQuantity = new int[CommonAtmosphere.Length];
            RareAtmosphereQuantity = new int[RareAtmosphere.Length];
            CommonElementsQuantity = new int[CommonElements.Length];
            RareElementsQuantity = new int[RareElements.Length];
            ResourcesStaticQuantity = new int[ResourcesStatic.Length];

            // The following code generates somewhat of productivity factors for any commerce and mining
            // Start off with gasses. That will be hard
            //double wholefraction = 1.0;
            //double partialfraction = 0.0;
            for (int i = (CommonAtmosphere.Length - 1); i >= 0 ; i--)
            {
            //    wholefraction = 8.0;
                CommonAtmosphereQuantity[i] = 0;
            }
            for (int i = (RareAtmosphere.Length - 1); i >= 0 ; i--)
            {
                RareAtmosphereQuantity[i] = 0;
            }

            // Elements should be easier
            for (int i = 0; i < CommonElements.Length; i++)
            {
                CommonElementsQuantity[i] = n.GetRandNumberInRange(1, 50);
            }
            for (int i = 0; i < RareElements.Length; i++)
            {
                RareElementsQuantity[i] = n.GetRandNumberInRange(1, 15);
            }
            for (int i = 0; i < ResourcesStatic.Length; i++)
            {
                ResourcesStaticQuantity[i] = n.GetRandNumberInRange(1, 25);
            }

        }
        

        // Helper method to find the productivity value of a certain harvestable resource commodity
        public int FindProductivityOfInternalResource(ObjectCharactaristics.ResourceCommodityType rct, int rct_index)
        {
            switch (rct)
            {
                case ObjectCharactaristics.ResourceCommodityType.CommonAtmosphere:
                    ObjectCharactaristics.CommonAtmosphere tempCA = (ObjectCharactaristics.CommonAtmosphere)rct_index;
                    for (int i = 0; i < CommonAtmosphere.Length; i++)
                    {
                        if (CommonAtmosphere[i] == tempCA)
                            return CommonAtmosphereQuantity[i];
                    }
                    break;
                case ObjectCharactaristics.ResourceCommodityType.RareAtmosphere:
                    ObjectCharactaristics.RareAtmosphere tempRA = (ObjectCharactaristics.RareAtmosphere)rct_index;
                    for (int i = 0; i < RareAtmosphere.Length; i++)
                    {
                        if (RareAtmosphere[i] == tempRA)
                            return RareAtmosphereQuantity[i];
                    }
                    break;
                case ObjectCharactaristics.ResourceCommodityType.CommonElement:
                    ObjectCharactaristics.CommonElements tempCE = (ObjectCharactaristics.CommonElements)rct_index;
                    for (int i = 0; i < CommonElements.Length; i++)
                    {
                        if (CommonElements[i] == tempCE)
                            return CommonElementsQuantity[i];
                    }
                    break;
                case ObjectCharactaristics.ResourceCommodityType.RareElement:
                    ObjectCharactaristics.RareElements tempRE = (ObjectCharactaristics.RareElements)rct_index;
                    for (int i = 0; i < RareElements.Length; i++)
                    {
                        if (RareElements[i] == tempRE)
                            return RareElementsQuantity[i];
                    }
                    break;
                case ObjectCharactaristics.ResourceCommodityType.ResourceStatic:
                    ObjectCharactaristics.ResourcesStatic tempRS = (ObjectCharactaristics.ResourcesStatic)rct_index;
                    for (int i = 0; i < ResourcesStatic.Length; i++)
                    {
                        if (ResourcesStatic[i] == tempRS)
                            return ResourcesStaticQuantity[i];
                    }
                    break;
                default:
                    throw new Exception();
            }
            // we should not get here....
            throw new Exception();
        }

        public override string ToString()
        {
            return Constants.intToHex(LocalPlanetNumber);
        }
    }
}
