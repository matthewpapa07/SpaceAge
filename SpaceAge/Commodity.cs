using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceAge
{
    class Commodity
    {

        public static Commodity[] allCommodities = generateCommodities();
        public static int NumOfCommodities; // Length of commodities list

        public enum CommodityEnum
        {
            Fuel = 0, Foodstuffs, RepairPatch, ScrapMetal, Coolant, CopperCabling,
            Slaves, SpaceSteel, Ceramics, Spices,
            ComputerComponents, Missile1, Missile2, LaserCrystal1, LaserCrystal2, 
            MassDriverAmmo1, MassDriverAmmo2,
            // RESOURCES BEGIN HERE
            Oxygen, Hydrogen, Methane, SulphuricAcid, CarbonDioxide, Nitrogen, Chlorine, Helium,    // CommonAtmosphere
            Boron, Neon, Xenon, Krypton,                                                            // RareAtmosphere
            Silicon, Iron, Carbon, Copper, Magnesium, Sodium, Sulfur, Lead, Nickel, Amuninum,       // CommonElements
            Titanium, Neodymium, Germanium, Gallium, Arsenic, Strontium, Gold, Silver, Platinum,    // RareElements
            Hydrocarbons, Cellulose, Acid, Biomass, Mud, Water, Minerals                            // ResourcesStatic
        };

        public CommodityEnum CommodityType;
        public String CommodityDescription;
        public CommodityEnum[] CompositeMaterials;  // Should only be needed to define "resource" commodities
        public int[] CompositeMaterialsNum;         // Should only be needed to define "resource" commodities
        public int UnitWeight;
        public int UnitVolume;
        public int BaseValue;
        public int MaxQuantity;
        public bool IsVolatile;
        public bool IsResource;

        // Constructor for regular commodities
        private Commodity(CommodityEnum c, String inDescription, int inWeight, int inVol, int inVal, int inMaxQuantity, bool inIsVolatile) 
            : base()
        {
            
            CommodityType = c;
            CommodityDescription = inDescription;
            UnitWeight = inWeight;
            UnitVolume = inVol;
            BaseValue = inVal;
            IsVolatile = inIsVolatile;
            MaxQuantity = inMaxQuantity;
            IsResource = false;
        }

        // Constructor for resource commodities
        private Commodity(CommodityEnum c, String inDescription, int inVal) 
            : base()
        {
            CommodityType = c;
            CommodityDescription = inDescription;
            UnitWeight = 1;     // for now assumed to be 1 kg
            UnitVolume = 1;     // assumed to be 1m3
            BaseValue = inVal;
            IsVolatile = false;
            MaxQuantity = 100;  // This value should never be used
            IsResource = true;
        }

        // To determine what "resource" commodities are needed to build the non resource ones
        private void setResourceDependency(CommodityEnum[] inCompositeMaterials, int[] inCompositeMaterialsNum)
        {
            if (this.IsResource)
                throw new Exception();

            CompositeMaterials = inCompositeMaterials;
            CompositeMaterialsNum = inCompositeMaterialsNum;
        }

        public static Commodity getCommodityFromEnum(CommodityEnum inEnum)
        {
            return allCommodities[(int)inEnum];
        }

        public static CommodityEnum GetRandomCommodity()
        {
            return (CommodityEnum)NumberGenerator.getInstance().GetRandNumberInRange(0, NumOfCommodities - 1);
        }

        public override string ToString()
        {
            return CommodityDescription;
        }

        //
        // Hardcode these values for now. Later abstract out weapon types and their ammo into their own class
        // Make SSS, SS, S, M, L, XL, XXL, XXXL sizes too....
        // Each item will eventually perform actions on the players ship or other items
        //
        static Commodity[] generateCommodities()
        {
            // int numOfCommodities = sizeof(CommodityEnum);
            List<Commodity> commoditiesTempList = new List<Commodity>();
            Commodity tempCommodity;

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

            //String inDescription, int inWeight, int inVol, int inVal, int inMaxQuantity, bool inIsVolatile
            // Start regular Commodities. Each needs to have resource dependency
            tempCommodity = new Commodity(Commodity.CommodityEnum.Fuel, "Fuel", 6, 1, 5, 100000, true);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Foodstuffs, "Foodstuffs", 2, 8, 10, 600, false);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.RepairPatch, "Ship Hull Repair Patch", 25, 10, 150, 10, false);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.ScrapMetal, "Scrap Metal", 50, 80, 2, 500, false);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Coolant, "Coolant", 5, 20, 60, 50, false);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.CopperCabling, "Copper Cabling", 20, 75, 180, 20, false);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Slaves, "Slaves", 1, 1, 225, 90, false);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.SpaceSteel, "Space Steel", 15, 50, 175, 250, false);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Ceramics, "Ceramics", 8, 18, 150, 250, false);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Spices, "Spices", 1, 15, 80, 800, false);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.ComputerComponents, "Computer Components", 5, 50, 525, 150, false);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Missile1, "Missile I", 5, 10, 200, 16, true);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Missile2, "Misssile II", 5, 10, 500, 8, true);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.LaserCrystal1, "Laser Crystal I", 3, 3, 3, 800, false);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.LaserCrystal2, "Laser Crystal II", 3, 3, 2, 7200, false);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.MassDriverAmmo1, "Mass Driver Ammo I", 1, 1, 1, 1200, false);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.MassDriverAmmo2, "Mass Driver Ammo II", 1, 1, 10, 600, false);
            commoditiesTempList.Add(tempCommodity);
            //
            // Next are resources, which fall under the commodity umbrella for now. Call them "resource commodities"
            //
            // Start Resources
            tempCommodity = new Commodity(Commodity.CommodityEnum.Oxygen, "Oxygen", 20);                    // Gases
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Hydrogen, "Hydrogen", 20);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Methane, "Methane", 20);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.SulphuricAcid, "Sulphuric Acid", 20);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.CarbonDioxide, "Carbon Dioxide", 20);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Nitrogen, "Nitrogen", 20);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Chlorine, "Chlorine", 20);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Helium, "Helium", 20);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Boron, "Boron", 20);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Neon, "Neon", 20);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Xenon, "Xenon", 20);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Krypton, "Krypton", 20);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Silicon, "Silicon", 20);                            // Elements
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Iron, "Iron", 20);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Carbon, "Carbon", 20);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Copper, "Copper", 20);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Magnesium, "Magnesium", 20);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Sodium, "Sodium", 20);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Sulfur, "Sulfur", 20);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Lead, "Lead", 20);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Nickel, "Nickel", 20);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Amuninum, "Amuninum", 20);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Titanium, "Titanium", 20);                                    
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Neodymium, "Neodymium", 20);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Germanium, "Germanium", 20);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Gallium, "Gallium", 20);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Arsenic, "Arsenic", 20);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Strontium, "Strontium", 20);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Gold, "Gold", 20);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Silver, "Silver", 20);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Platinum, "Platinum", 20);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Hydrocarbons, "Hydrocarbons", 20);                                   // Resources
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Cellulose, "Cellulose", 20);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Acid, "Acid", 20);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Biomass, "Biomass", 20);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Mud, "Mud", 20);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Water, "Water", 20);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Minerals, "Minerals", 20);
            commoditiesTempList.Add(tempCommodity);
            // End Resources
            // End Commodities

            NumOfCommodities = commoditiesTempList.Count;

            return commoditiesTempList.ToArray();
        }
    }
}
