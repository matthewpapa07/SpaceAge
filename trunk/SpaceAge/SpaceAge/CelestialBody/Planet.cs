using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceAge
{
    class Planet : IHarvestableBody, IInteractableBody
    {
        public static double CHANCE_OF_PLANET_INHABITED = 0.37;
        public static double CHANCE_OF_PLANET_SUPERCENTER = 0.12;

        public static int GlobalPlanetNumber = 0;
        public int LocalPlanetNumber;

        // Planet resource data
        // TODO: Refactor out and up a ResourceBearing object so other things besides planets can be harvested
        public ObjectCharactaristics.PlanetSize PlanetSize;
        public ObjectCharactaristics.Position PlanetPosition;

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

            PlanetSize = n.RandomEnum<ObjectCharactaristics.PlanetSize>();
            PlanetPosition = n.RandomEnum<ObjectCharactaristics.Position>();

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
                    planetStore = ItemStore.GetGeneralStore(this);
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
    }
}
