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
        private ObjectCharactaristics.CommonAtmosphere[] commonAtmosphere;
        private ObjectCharactaristics.RareAtmosphere[] rareAtmosphere;
        private ObjectCharactaristics.CommonElements[] commonElements;
        private ObjectCharactaristics.RareElements[] rareElements;
        private ObjectCharactaristics.ResourcesStatic[] resourcesStatic;
        private int[] commonAtmosphereQuantity;
        private int[] rareAtmosphereQuantity;
        private int[] commonElementsQuantity;
        private int[] rareElementsQuantity;
        private int[] resourcesStaticQuantity;

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

            if (commonAtmosphere.Contains(ObjectCharactaristics.CommonAtmosphere.Oxygen) || commonAtmosphere.Contains(ObjectCharactaristics.CommonAtmosphere.CarbonDioxide))
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
                }
            }
        }

        private void generateResources()
        {
            NumberGenerator n = NumberGenerator.getInstance();

            commonAtmosphere = n.GetEnumScaledList<ObjectCharactaristics.CommonAtmosphere>(0.8);
            rareAtmosphere = n.GetEnumScaledList<ObjectCharactaristics.RareAtmosphere>(0.45);
            commonElements = n.GetEnumScaledList<ObjectCharactaristics.CommonElements>(0.70);
            rareElements = n.GetEnumScaledList<ObjectCharactaristics.RareElements>(0.40);
            resourcesStatic = n.GetEnumScaledList<ObjectCharactaristics.ResourcesStatic>(0.60);

            commonAtmosphereQuantity = new int[commonAtmosphere.Length];
            rareAtmosphereQuantity = new int[rareAtmosphere.Length];
            commonElementsQuantity = new int[commonElements.Length];
            rareElementsQuantity = new int[rareElements.Length];
            resourcesStaticQuantity = new int[resourcesStatic.Length];

            // The following code generates somewhat of productivity factors for any commerce and mining
            // Start off with gasses. That will be hard
            //double wholefraction = 1.0;
            //double partialfraction = 0.0;
            for (int i = (commonAtmosphere.Length - 1); i >= 0 ; i--)
            {
            //    wholefraction = 8.0;
                commonAtmosphereQuantity[i] = 0;
            }
            for (int i = (rareAtmosphere.Length - 1); i >= 0 ; i--)
            {
                rareAtmosphereQuantity[i] = 0;
            }

            // Elements should be easier
            for (int i = 0; i < commonElements.Length; i++)
            {
                commonElementsQuantity[i] = n.GetRandNumberInRange(1, 50);
            }
            for (int i = 0; i < rareElements.Length; i++)
            {
                rareElementsQuantity[i] = n.GetRandNumberInRange(1, 15);
            }
            for (int i = 0; i < resourcesStatic.Length; i++)
            {
                resourcesStaticQuantity[i] = n.GetRandNumberInRange(1, 25);
            }

        }
        

        // Helper method to find the productivity value of a certain harvestable resource commodity
        public int FindProductivityOfInternalResource(ObjectCharactaristics.ResourceCommodityType rct, int rct_index)
        {
            switch (rct)
            {
                case ObjectCharactaristics.ResourceCommodityType.CommonAtmosphere:
                    ObjectCharactaristics.CommonAtmosphere tempCA = (ObjectCharactaristics.CommonAtmosphere)rct_index;
                    for (int i = 0; i < commonAtmosphere.Length; i++)
                    {
                        if (commonAtmosphere[i] == tempCA)
                            return commonAtmosphereQuantity[i];
                    }
                    break;
                case ObjectCharactaristics.ResourceCommodityType.RareAtmosphere:
                    ObjectCharactaristics.RareAtmosphere tempRA = (ObjectCharactaristics.RareAtmosphere)rct_index;
                    for (int i = 0; i < rareAtmosphere.Length; i++)
                    {
                        if (rareAtmosphere[i] == tempRA)
                            return rareAtmosphereQuantity[i];
                    }
                    break;
                case ObjectCharactaristics.ResourceCommodityType.CommonElement:
                    ObjectCharactaristics.CommonElements tempCE = (ObjectCharactaristics.CommonElements)rct_index;
                    for (int i = 0; i < commonElements.Length; i++)
                    {
                        if (commonElements[i] == tempCE)
                            return commonElementsQuantity[i];
                    }
                    break;
                case ObjectCharactaristics.ResourceCommodityType.RareElement:
                    ObjectCharactaristics.RareElements tempRE = (ObjectCharactaristics.RareElements)rct_index;
                    for (int i = 0; i < rareElements.Length; i++)
                    {
                        if (rareElements[i] == tempRE)
                            return rareElementsQuantity[i];
                    }
                    break;
                case ObjectCharactaristics.ResourceCommodityType.ResourceStatic:
                    ObjectCharactaristics.ResourcesStatic tempRS = (ObjectCharactaristics.ResourcesStatic)rct_index;
                    for (int i = 0; i < resourcesStatic.Length; i++)
                    {
                        if (resourcesStatic[i] == tempRS)
                            return resourcesStaticQuantity[i];
                    }
                    break;
                default:
                    throw new Exception();
            }
            // we should not get here....
            throw new Exception();
        }

        public void AddExtractors(RawMaterialExtractor [] tempExtractor)
        {
            foreach(RawMaterialExtractor e in tempExtractor)
                planetExtractors.Add(e);
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
        public ObjectCharactaristics.CommonAtmosphere[] CommonAtmosphere
        {
            get
            {
                return commonAtmosphere;
            }
        }
        public ObjectCharactaristics.RareAtmosphere[] RareAtmosphere
        {
            get
            {
                return rareAtmosphere;
            }
        }
        public ObjectCharactaristics.CommonElements[] CommonElements
        {
            get
            {
                return commonElements;
            }
        }
        public ObjectCharactaristics.RareElements[] RareElements
        {
            get
            {
                return rareElements;
            }
        }
        public ObjectCharactaristics.ResourcesStatic[] ResourcesStatic
        {
            get
            {
                return resourcesStatic;
            }
        }
        public int[] CommonAtmosphereQuantity
        {
            get
            {
                return commonAtmosphereQuantity;
            }
        }
        public int[] RareAtmosphereQuantity
        {
            get
            {
                return rareAtmosphereQuantity;
            }
        }
        public int[] CommonElementsQuantity
        {
            get
            {
                return commonElementsQuantity;
            }
        }
        public int[] RareElementsQuantity
        {
            get
            {
                return rareElementsQuantity;
            }
        }
        public int[] ResourcesStaticQuantity
        {
            get
            {
                return resourcesStaticQuantity;
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
