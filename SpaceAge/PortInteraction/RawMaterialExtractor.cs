using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceAge
{
    // Will go on planets and moons (todo) for now
    class RawMaterialExtractor : IInteractableBody
    {
        public static double CHANCE_OF_EXTRACTOR_PRESENT = 0.18;    //For early game generation
        //
        //Fuel = 0, Water, Foodstuffs, RepairPatch, ScrapMetal, Coolant, CopperCabling,
        //Slaves, Minerals, SpaceSteel, Ceramics, Spices,
        //ComputerComponents, Missile1, Missile2, LaserCrystal1, LaserCrystal2, 
        //MassDriverAmmo1, MassDriverAmmo2,
        //// RESOURCES BEGIN HERE
        //Oxygen, Hydrogen, Methane, SulphuricAcid, CarbonDioxide, Nitrogen, Chlorine, Helium,    // CommonAtmosphere
        //Boron, Neon, Xenon, Krypton,                                                            // RareAtmosphere
        //Silicon, Iron, Carbon, Copper, Magnesium, Sodium, Sulfur, Lead, Nickel, Amuninum,       // CommonElements
        //Titanium, Neodymium, Germanium, Gallium, Arsenic, Strontium, Gold, Silver, Platinum,    // RareElements
        //Hydrocarbons, Cellulose, Acid, Biomass, Mud                                             // ResourcesStatic
        //
        public IInteractableBody Parent;
        public Commodity ProducedResourceCommodity;

        private RawMaterialExtractor[] dummyExtractors = null;
        private ItemStore extractorStore;
        private MissionPost dummyPost = null;
        private PeopleSource dummyPeople = null;
        private PoliticalCenter dummyPolitics = null;

        public int ExtractorCash = 10000000;

        // These numbers will be stored in the commodity, but for now they are constants
        public int FuelUsedPerProductionCycle = 5;
        public int NumberProducedPerCycle = 1;
        public int ProductionCycleLength = 1;

        private int CycleCount = 0;
        public int Productivity = 0;

        // This is the constructor that will be automatically applied. Cast enum to get inResourceCommodityIndex
        public RawMaterialExtractor(IInteractableBody inParent, ObjectCharactaristics.ResourceCommodityType r, int inResourceCommodityIndex)
        {
            Parent = inParent;

            // Check to make sure the input object is harvestable
            if (!(Parent is IHarvestableBody))
                throw new Exception();

            // TODO: do not allow inhabited planets to be exploited
            //if (Parent.IsInhabited)
            //    throw new Exception();

            ProducedResourceCommodity = Commodity.GetCommodityFromResource(r, inResourceCommodityIndex);
            if (ProducedResourceCommodity == null || !ProducedResourceCommodity.IsResource)
                throw new Exception();

            extractorStore = ItemStore.GetExtractorStore(Parent);

            // Now set which items this store will accept to buy and sell
            for (int i = 0; i < Commodity.NumOfCommodities; i++)
            {
                if (Commodity.AllCommoditiesArray[i].CommodityType == Commodity.CommodityEnum.Fuel)
                    extractorStore.WillBuy[i] = true;
                else
                    extractorStore.WillBuy[i] = false;
                if (Commodity.AllCommoditiesArray[i].CommodityType == ProducedResourceCommodity.CommodityType)
                    extractorStore.WillSell[i] = true;
                else
                    extractorStore.WillSell[i] = false;
            }

            // TODO: IHARVESTABLE
            // Finally set the productivity
            //Productivity = Parent.FindProductivityOfInternalResource(r, inResourceCommodityIndex);
            Productivity = 50;
        }

        public static RawMaterialExtractor[] PopulateSectorWithExtractors(Sector s)
        {
            NumberGenerator numGen = NumberGenerator.getInstance();
            List<RawMaterialExtractor> tempGlobalExtList = new List<RawMaterialExtractor>(3);
            List<RawMaterialExtractor> tempLocalExtList = new List<RawMaterialExtractor>(3);
            RawMaterialExtractor tempExtractor;
            Planet[] ResourceLadenPlanets;
            int pickIndex = 0;

            // Populate some planets with raw material extractors
            ResourceLadenPlanets = ResourceVector.GetPlanetsWithResources(s);
            pickIndex = 0;
            // Check planet for resources, then use a simple probability to decide whether to put an extractor there
            foreach (Planet p in ResourceLadenPlanets)
            {
                if (p.IsInhabited)
                    continue;
                if (p.CommonAtmosphere.Length >= 1)
                {
                    if (numGen.LinearPmfResult(CHANCE_OF_EXTRACTOR_PRESENT))
                    {
                        pickIndex = numGen.GetRandNumberInRange(0, p.CommonAtmosphere.Length - 1);
                        tempExtractor = new RawMaterialExtractor(p, ObjectCharactaristics.ResourceCommodityType.CommonAtmosphere,
                                                                                (int)p.CommonAtmosphere[pickIndex]);
                        tempLocalExtList.Add(tempExtractor);
                        tempGlobalExtList.Add(tempExtractor); // So all extractors can be registered
                    }
                }
                if (p.RareAtmosphere.Length >= 1)
                {
                    if (numGen.LinearPmfResult(CHANCE_OF_EXTRACTOR_PRESENT))
                    {
                        pickIndex = numGen.GetRandNumberInRange(0, p.RareAtmosphere.Length - 1);
                        tempExtractor = new RawMaterialExtractor(p, ObjectCharactaristics.ResourceCommodityType.RareAtmosphere,
                                                                                (int)p.RareAtmosphere[pickIndex]);
                        tempLocalExtList.Add(tempExtractor);
                        tempGlobalExtList.Add(tempExtractor); // So all extractors can be registered
                    }
                }
                if (p.CommonElements.Length >= 1)
                {
                    if (numGen.LinearPmfResult(CHANCE_OF_EXTRACTOR_PRESENT))
                    {
                        pickIndex = numGen.GetRandNumberInRange(0, p.CommonElements.Length - 1);
                        tempExtractor = new RawMaterialExtractor(p, ObjectCharactaristics.ResourceCommodityType.CommonElement,
                                                                                (int)p.CommonElements[pickIndex]);
                        tempLocalExtList.Add(tempExtractor);
                        tempGlobalExtList.Add(tempExtractor); // So all extractors can be registered
                    }
                }
                if (p.RareElements.Length >= 1)
                {
                    if (numGen.LinearPmfResult(CHANCE_OF_EXTRACTOR_PRESENT))
                    {
                        pickIndex = numGen.GetRandNumberInRange(0, p.RareElements.Length - 1);
                        tempExtractor = new RawMaterialExtractor(p, ObjectCharactaristics.ResourceCommodityType.RareElement,
                                                                                (int)p.RareElements[pickIndex]);
                        tempLocalExtList.Add(tempExtractor);
                        tempGlobalExtList.Add(tempExtractor); // So all extractors can be registered
                    }
                }
                if (p.ResourcesStatic.Length >= 1)
                {
                    if (numGen.LinearPmfResult(CHANCE_OF_EXTRACTOR_PRESENT))
                    {
                        pickIndex = numGen.GetRandNumberInRange(0, p.ResourcesStatic.Length - 1);
                        tempExtractor = new RawMaterialExtractor(p, ObjectCharactaristics.ResourceCommodityType.ResourceStatic,
                                                                                (int)p.ResourcesStatic[pickIndex]);
                        tempLocalExtList.Add(tempExtractor);
                        tempGlobalExtList.Add(tempExtractor); // So all extractors can be registered
                    }
                }

                p.AddExtractors(tempLocalExtList.ToArray());
                tempLocalExtList.Clear();
            }
            return tempGlobalExtList.ToArray();
        }

        public void Live()
        {
            CycleCount++;
            if (CycleCount % ProductionCycleLength != 0)
            {
                return;
            }

            int FuelAvailable = extractorStore.CommoditiesAvailable(Commodity.CommodityEnum.Fuel);
            if (FuelAvailable / FuelUsedPerProductionCycle > 1)
            {
                extractorStore.RemoveCommodity(Commodity.CommodityEnum.Fuel, FuelUsedPerProductionCycle);
                extractorStore.AddCommodity(ProducedResourceCommodity.CommodityType, NumberProducedPerCycle);
            }
        }

        //
        // Member functions in order to implement IInteractableBody
        //
        public object DirectParent
        {
            get
            {
                return Parent;
            }
        }
        public RawMaterialExtractor[] Extractors
        {
            get
            {
                return dummyExtractors;
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
                return extractorStore;
            }
        }
        public MissionPost MissionPost
        {
            get
            {
                return dummyPost;
            }
        }
        public PeopleSource PeopleSource
        {
            get
            {
                return dummyPeople;
            }
        }
        public PoliticalCenter PoliticalCenter
        {
            get
            {
                return dummyPolitics;
            }
        }

        /// <summary>
        /// As per ISectorMember
        /// </summary>
        public Sector MemberSector
        {
            get
            {
                return Parent.MemberSector;
            }
        }

        public override string ToString()
        {
            return ProducedResourceCommodity.ToString() + " Extractor";
        }
    }
}
