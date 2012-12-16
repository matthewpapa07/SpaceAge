using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceAge
{
    class Commodity
    {

        public static Commodity[] AllCommoditiesArray = GenerateAllCommodities();
        public static Commodity[] AllResourceCommoditiesArray = LinkResourceCommodities();
        public static Commodity[] CommonAtmosphere = LinkCommonAtmosphere();
        public static Commodity[] RareAtmosphere = LinkRareAtmosphere();
        public static Commodity[] CommonElements = LinkCommonElement();
        public static Commodity[] RareElements = LinkRareAtmosphere();
        public static Commodity[] ResourcesStatic = LinkStaticCommodity();

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
            Silicon, Iron, Carbon, Copper, Magnesium, Sodium, Sulfur, Lead, Nickel, Aluminum,       // CommonElements
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

        //Resource fields. For now this will not be a subclass
        public bool IsResource;
        //public int Productivity;
        public ObjectCharactaristics.ResourceCommodityType ResourceCommodityType = 0;

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
        private Commodity(CommodityEnum c, ObjectCharactaristics.ResourceCommodityType inResType,  String inDescription, int inVal) 
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
            ResourceCommodityType = inResType;
        }

        public override bool Equals(object obj)
        {
            if (obj is Commodity)
            {
                if ((obj as Commodity).CommodityType == CommodityType)
                    return true;
                else
                    return false;
            }
            else
            {
                throw new Exception();
            }
        }

        public override int GetHashCode()
        {
            return (int)CommodityType;
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
            return AllCommoditiesArray[(int)inEnum];
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
        private static Commodity[] GenerateAllCommodities()
        {
            // int numOfCommodities = sizeof(CommodityEnum);
            List<Commodity> commoditiesTempList = new List<Commodity>();
            Commodity tempCommodity;

            List<Commodity> CommonAtmo = new List<Commodity>(10);
            List<Commodity> RareAtmp = new List<Commodity>(10);
            List<Commodity> CommonEle = new List<Commodity>(10);
            List<Commodity> RareEle = new List<Commodity>(10);
            List<Commodity> StaticRes = new List<Commodity>(10);

            //Fuel = 0, Foodstuffs, RepairPatch, ScrapMetal, Coolant, CopperCabling,
            //Slaves, SpaceSteel, Ceramics, Spices,
            //ComputerComponents, Missile1, Missile2, LaserCrystal1, LaserCrystal2, 
            //MassDriverAmmo1, MassDriverAmmo2,
            //// RESOURCES BEGIN HERE
            //Oxygen, Hydrogen, Methane, SulphuricAcid, CarbonDioxide, Nitrogen, Chlorine, Helium,    // CommonAtmosphere
            //Boron, Neon, Xenon, Krypton,                                                            // RareAtmosphere
            //Silicon, Iron, Carbon, Copper, Magnesium, Sodium, Sulfur, Lead, Nickel, Amuninum,       // CommonElements
            //Titanium, Neodymium, Germanium, Gallium, Arsenic, Strontium, Gold, Silver, Platinum,    // RareElements
            //Hydrocarbons, Cellulose, Acid, Biomass, Mud, Water, Minerals                            // ResourcesStatic

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
            // Gases
            tempCommodity = new Commodity(Commodity.CommodityEnum.Oxygen, ObjectCharactaristics.ResourceCommodityType.CommonAtmosphere, "Oxygen", 20);                    
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Hydrogen, ObjectCharactaristics.ResourceCommodityType.CommonAtmosphere, "Hydrogen", 10);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Methane, ObjectCharactaristics.ResourceCommodityType.CommonAtmosphere, "Methane", 45);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.SulphuricAcid, ObjectCharactaristics.ResourceCommodityType.CommonAtmosphere, "Sulphuric Acid", 25);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.CarbonDioxide, ObjectCharactaristics.ResourceCommodityType.CommonAtmosphere, "Carbon Dioxide", 20);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Nitrogen, ObjectCharactaristics.ResourceCommodityType.CommonAtmosphere, "Nitrogen", 10);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Chlorine, ObjectCharactaristics.ResourceCommodityType.CommonAtmosphere, "Chlorine", 35);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Helium, ObjectCharactaristics.ResourceCommodityType.CommonAtmosphere, "Helium", 10);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Boron, ObjectCharactaristics.ResourceCommodityType.RareAtmosphere, "Boron", 75); // START Rare
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Neon, ObjectCharactaristics.ResourceCommodityType.RareAtmosphere, "Neon", 55);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Xenon, ObjectCharactaristics.ResourceCommodityType.RareAtmosphere, "Xenon", 60);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Krypton, ObjectCharactaristics.ResourceCommodityType.RareAtmosphere, "Krypton", 50);
            commoditiesTempList.Add(tempCommodity);
            // Elements
            tempCommodity = new Commodity(Commodity.CommodityEnum.Silicon, ObjectCharactaristics.ResourceCommodityType.CommonElement, "Silicon", 10);                            
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Iron, ObjectCharactaristics.ResourceCommodityType.CommonElement, "Iron", 10);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Carbon, ObjectCharactaristics.ResourceCommodityType.CommonElement, "Carbon", 20);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Copper, ObjectCharactaristics.ResourceCommodityType.CommonElement, "Copper", 40);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Magnesium, ObjectCharactaristics.ResourceCommodityType.CommonElement, "Magnesium", 55);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Sodium, ObjectCharactaristics.ResourceCommodityType.CommonElement, "Sodium", 45);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Sulfur, ObjectCharactaristics.ResourceCommodityType.CommonElement, "Sulfur", 45);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Lead, ObjectCharactaristics.ResourceCommodityType.CommonElement, "Lead", 10);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Nickel, ObjectCharactaristics.ResourceCommodityType.CommonElement, "Nickel", 20);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Aluminum, ObjectCharactaristics.ResourceCommodityType.CommonElement, "Aluminum", 35);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Titanium, ObjectCharactaristics.ResourceCommodityType.RareElement, "Titanium", 120); // START Rare                                    
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Neodymium, ObjectCharactaristics.ResourceCommodityType.RareElement, "Neodymium", 180);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Germanium, ObjectCharactaristics.ResourceCommodityType.RareElement, "Germanium", 195);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Gallium, ObjectCharactaristics.ResourceCommodityType.RareElement, "Gallium", 210);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Arsenic, ObjectCharactaristics.ResourceCommodityType.RareElement, "Arsenic", 140);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Strontium, ObjectCharactaristics.ResourceCommodityType.RareElement, "Strontium", 280);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Gold, ObjectCharactaristics.ResourceCommodityType.RareElement, "Gold", 300);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Silver, ObjectCharactaristics.ResourceCommodityType.RareElement, "Silver", 250);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Platinum, ObjectCharactaristics.ResourceCommodityType.RareElement, "Platinum", 330);
            commoditiesTempList.Add(tempCommodity);
            // Resources
            tempCommodity = new Commodity(Commodity.CommodityEnum.Hydrocarbons, ObjectCharactaristics.ResourceCommodityType.ResourceStatic, "Hydrocarbons", 140);                                   
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Cellulose, ObjectCharactaristics.ResourceCommodityType.ResourceStatic, "Cellulose", 120);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Acid, ObjectCharactaristics.ResourceCommodityType.ResourceStatic, "Acid", 220);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Biomass, ObjectCharactaristics.ResourceCommodityType.ResourceStatic, "Biomass", 150);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Mud, ObjectCharactaristics.ResourceCommodityType.ResourceStatic, "Mud", 175);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Water, ObjectCharactaristics.ResourceCommodityType.ResourceStatic, "Water", 20);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Minerals, ObjectCharactaristics.ResourceCommodityType.ResourceStatic, "Minerals", 20);
            commoditiesTempList.Add(tempCommodity);
            // End Resources
            // End Commodities

            NumOfCommodities = commoditiesTempList.Count;

            return commoditiesTempList.ToArray();
        }

        private static Commodity[] LinkResourceCommodities()
        {
            List<Commodity> TempList = new List<Commodity>(25);
            foreach(Commodity c in AllCommoditiesArray)
            {
                if (c.IsResource)
                    TempList.Add(c);
            }

            return TempList.ToArray();
        }

        private static Commodity[] LinkCommonAtmosphere()
        {
            List<Commodity> TempList = new List<Commodity>(10);
            foreach (Commodity c in AllResourceCommoditiesArray)
            {
                if (c.ResourceCommodityType == ObjectCharactaristics.ResourceCommodityType.CommonAtmosphere)
                    TempList.Add(c);
            }

            return TempList.ToArray();
        }

        private static Commodity[] LinkRareAtmosphere()
        {
            List<Commodity> TempList = new List<Commodity>(10);
            foreach (Commodity c in AllResourceCommoditiesArray)
            {
                if (c.ResourceCommodityType == ObjectCharactaristics.ResourceCommodityType.RareAtmosphere)
                    TempList.Add(c);
            }

            return TempList.ToArray();
        }

        private static Commodity[] LinkCommonElement()
        {
            List<Commodity> TempList = new List<Commodity>(10);
            foreach (Commodity c in AllResourceCommoditiesArray)
            {
                if (c.ResourceCommodityType == ObjectCharactaristics.ResourceCommodityType.CommonElement)
                    TempList.Add(c);
            }

            return TempList.ToArray();
        }

        private static Commodity[] LinkRareElement()
        {
            List<Commodity> TempList = new List<Commodity>(10);
            foreach (Commodity c in AllResourceCommoditiesArray)
            {
                if (c.ResourceCommodityType == ObjectCharactaristics.ResourceCommodityType.RareElement)
                    TempList.Add(c);
            }

            return TempList.ToArray();
        }

        private static Commodity[] LinkStaticCommodity()
        {
            List<Commodity> TempList = new List<Commodity>(10);
            foreach (Commodity c in AllResourceCommoditiesArray)
            {
                if (c.ResourceCommodityType == ObjectCharactaristics.ResourceCommodityType.ResourceStatic)
                    TempList.Add(c);
            }

            return TempList.ToArray();
        }

        //public static Commodity GetCommodityFromResource(ObjectCharactaristics.ResourceCommodityType RcType, int value)
        //{
        //    switch (RcType)
        //    {
        //        case ObjectCharactaristics.ResourceCommodityType.CommonAtmosphere:
        //             return getCommodityFromEnum(CommodityToC((Commodity)value));
        //        case ObjectCharactaristics.ResourceCommodityType.RareAtmosphere:
        //             return getCommodityFromEnum(CommodityToC((Commodity)value));
        //        case ObjectCharactaristics.ResourceCommodityType.CommonElement:
        //             return getCommodityFromEnum(ObjectCharactaristics.CommonElementToC((Commodity)value));
        //        case ObjectCharactaristics.ResourceCommodityType.RareElement:
        //             return getCommodityFromEnum(ObjectCharactaristics.RareElementToC((Commodity)value));
        //        case ObjectCharactaristics.ResourceCommodityType.ResourceStatic:
        //             return getCommodityFromEnum(CommodityToC((Commodity)value));
        //        default:
        //            throw new Exception();
        //    }
        //}
    }
}
