using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SpaceAge
{
    class Planet : IHarvestableBody, IInteractableBody, ISectorMember
    {
        public static double CHANCE_OF_PLANET_INHABITED = 0.37;
        public static double CHANCE_OF_PLANET_SUPERCENTER = 0.12;

        public static int GlobalPlanetNumber = 0;
        public int LocalPlanetNumber;

        // Planet resource data
        public PlanetConstant.PlanetSize PlanetSize;
        public PlanetConstant.Position PlanetPosition;
        public int PlanetDistanceFromStar;
        public Point PlanetLocation;
        public int PlanetDiameter;
        public int PlanetMass;

        //
        // Resources, as per IHarvestableBody
        //
        private Commodity[] resources;
        private int[] resourcesProductivity;

        public StarSystem Parent;

        //
        // Data fields as per IInteractableBody
        //
        private List<RawMaterialExtractor> planetExtractors = new List<RawMaterialExtractor>(2);
        private ItemStore planetStore = null;
        private MissionPost planetPost = null;
        private PeopleSource planetPeople = null;
        private PoliticalCenter planetPolitics = null;

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

            PlanetSize = n.RandomEnum<PlanetConstant.PlanetSize>();
            PlanetPosition = n.RandomEnum<PlanetConstant.Position>();
            PlanetDistanceFromStar = (int) (n.GetRandDoubleInRange(.85, 1.15) * PlanetConstant.PositionBaseDistance[(int)PlanetPosition]);
            PlanetLocation = n.GetPointDistanceFrom(PlanetDistanceFromStar, Parent.StarSystemLocation);
            PlanetDiameter = PlanetConstant.PlanetSizeDiameter[(int)PlanetSize];
            PlanetMass = n.GetRandNumberInRange(1000000, 100000000);

            generateResources();

            if (resources.Contains(Commodity.getCommodityFromEnum(Commodity.CommodityEnum.Oxygen)) ||
                resources.Contains(Commodity.getCommodityFromEnum(Commodity.CommodityEnum.CarbonDioxide)))
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
                    planetStore = ItemStore.GetGeneralStore(this, this);
                }
            }
        }

        private void generateResources()
        {
            List<Commodity> returnList = new List<Commodity>(10);
            int[] returnProductivity;
            NumberGenerator n = NumberGenerator.getInstance();

            Commodity[] commonAtmosphere = n.GetArrayScaledList<Commodity>(Commodity.CommonAtmosphere, 0.8);
            Commodity[] rareAtmosphere = n.GetArrayScaledList<Commodity>(Commodity.RareAtmosphere, 0.45);
            Commodity[] commonElements = n.GetArrayScaledList<Commodity>(Commodity.CommonElements, 0.70);
            Commodity[] rareElements = n.GetArrayScaledList<Commodity>(Commodity.RareElements, 0.40);
            Commodity[] resourcesStatic = n.GetArrayScaledList<Commodity>(Commodity.ResourcesStatic, 0.60);

            foreach (Commodity c in commonAtmosphere)
            {
                returnList.Add(c);
            }
            foreach (Commodity c in rareAtmosphere)
            {
                returnList.Add(c);
            }
            foreach (Commodity c in commonElements)
            {
                returnList.Add(c);
            }
            foreach (Commodity c in rareElements)
            {
                returnList.Add(c);
            }
            foreach (Commodity c in resourcesStatic)
            {
                returnList.Add(c);
            }

            returnProductivity = new int[returnList.Count];
            for (int i = 0; i < returnList.Count; i++)
            {
                //TODO: Produce this number randomly again based on the resource commodity class
                returnProductivity[i] = n.GetRandNumberInRange(1, 50);
            }

            resources = returnList.ToArray();
            resourcesProductivity = returnProductivity;
        }


        // Helper method to find the productivity value of a certain harvestable resource commodity
        // TODO: put this in interface
        public int FindProductivityOfInternalResource(Commodity c)
        {
            for (int i = 0; i < resources.Length; i++)
            {
                if (resources[i].Equals(c))
                {
                    return resourcesProductivity[i];
                }
                else
                    continue;
            }

            //Should not get here
            throw new Exception();
        }

        public void AddExtractors(RawMaterialExtractor[] tempExtractor)
        {
            foreach(RawMaterialExtractor e in tempExtractor)
                planetExtractors.Add(e);
        }
        public void AddExtractor(RawMaterialExtractor tempExtractor)
        {
            planetExtractors.Add(tempExtractor);
        }

        public override string ToString()
        {
            return Constants.intToHex(LocalPlanetNumber);
        }

        /// <summary>
        /// IHarvestable accessors
        /// </summary>
        /// 
        public object DirectParent
        {
            get
            {
                return Parent;
            }
        }
        public Commodity[] Resources
        {
            get
            {
                return resources;
            }
        }
        public int[] ResourcesProductivity
        {
            get
            {
                return resourcesProductivity;
            }
        }

        //
        // Member functions in order to implement IInteractableBody
        //
        public RawMaterialExtractor[] Extractors
        {
            get
            {
                return planetExtractors.ToArray();
            }
        }
        public Factory[] Factories
        {
            get
            {
                throw new NotImplementedException();
                //return null; // not implemented
            }
        }
        public ItemStore Store
        {
            get
            {
                return planetStore;
            }
        }
        public MissionPost MissionPost
        {
            get
            {
                return planetPost;
            }
        }
        public PeopleSource PeopleSource
        {
            get
            {
                return planetPeople;
            }
        }
        public PoliticalCenter PoliticalCenter
        {
            get
            {
                return planetPolitics;
            }
        }
        //public ISectorMember SectorMember
        //{
        //    get
        //    {
        //        return this as ISectorMember;
        //    }
        //}

        /// <summary>
        /// As per ISectorMember
        /// </summary>
        public Sector MemberSector
        {
            get
            {
                return Parent.parent;
            }
        }

        public Point SectorLocation
        {
            get
            {
                return PlanetLocation;
            }
        }

        public int Diameter
        {
            get
            {
                return PlanetDiameter;
            }
        }

        public int Mass
        {
            get
            {
                return PlanetMass;
            }
        }

        public Sector SectorMember
        {
            get
            {
                return Parent.parent;
            }
        }

        public static class PlanetConstant
        {
            //
            // Charactaristics Associated with Planets
            //
            public static string[] PlanetSizeString = { "Asteroid", "Very Small", "Small", "Medium", "Large", "Super" };
            public enum PlanetSize { Asteroid, VerySmall, Small, Medium, Large, Super };    // Size of the planet
            public static int[] PlanetSizeDiameter = { 5, 10, 20, 15, 20, 25, 30 };  // Need better Size Values

            public static string[] PositionString = { "Inner", "Middle", "Outer", "Rogue" };
            public enum Position { Inner, Middle, Outer, Rogue };                     // Position of planet from star
            public static int[] PositionBaseDistance = { 100, 300, 500, 1000 };

            // TODO: Planet gravity, and orbits too?
        }
    }
}
