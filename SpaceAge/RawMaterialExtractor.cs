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
        Commodity.CommodityEnum ProducedCommodities;
        ItemStore ExtractorStore;

        // This is the constructor that will be automatically applied
        public RawMaterialExtractor(Planet inParent)
        {
            // For now do not allow inhabited planets to be exploited
            if (Parent.IsInhabited)
                throw new Exception();

            Parent = inParent;
            ExtractorStore = new ItemStore(this);
        }

        
    }
}
