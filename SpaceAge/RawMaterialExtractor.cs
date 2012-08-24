using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceAge
{
    // Will go on planets and moons (todo) for now
    class RawMaterialExtractor
    {
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
        Planet Parent;
        Commodity ProducedResourceCommodity;
        ItemStore ExtractorStore;

        public int ExtractorCash = 10000000;

        // These numbers will be stored in the commodity, but for now they are constants
        int FuelUsedPerProductionCycle = 5;
        int NumberProducedPerCycle = 1;
        int ProductionCycleLength = 1;

        int CycleCount = 0;

        // This is the constructor that will be automatically applied. Cast enum to get inResourceCommodityIndex
        public RawMaterialExtractor(Planet inParent, ObjectCharactaristics.ResourceCommodityType r, int inResourceCommodityIndex)
        {
            // For now do not allow inhabited planets to be exploited
            if (Parent.IsInhabited)
                throw new Exception();

            ProducedResourceCommodity = Commodity.GetCommodityFromResource(r, inResourceCommodityIndex);
            if (ProducedResourceCommodity == null || !ProducedResourceCommodity.IsResource)
                throw new Exception();

            Parent = inParent;
            //ExtractorStore = new ItemStore(this); // Do this in driver
        }

        public void Live()
        {
            CycleCount++;
            if (CycleCount % ProductionCycleLength != 0)
            {
                return;
            }

            int FuelAvailable = ExtractorStore.CommoditiesAvailable(Commodity.CommodityEnum.Fuel);
            if (FuelAvailable / FuelUsedPerProductionCycle > 1)
            {
                ExtractorStore.RemoveCommodity(Commodity.CommodityEnum.Fuel, FuelUsedPerProductionCycle);
                ExtractorStore.AddCommodity(ProducedResourceCommodity.CommodityType, NumberProducedPerCycle);
            }
        }
    }
}
