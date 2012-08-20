﻿using System;
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
            Fuel = 0, Water, Uranium, Foodstuffs, RepairPatch, ScrapMetal, Coolant, CopperCabling,
            Slaves, Minerals, PreciousMetals, SpaceSteel, Hydrogen, Titanium, Ceramics, Spices,
            ComputerComponents, Biomass, Hydrocarbons,Missile1, Missile2, LaserCrystal1, LaserCrystal2, 
            MassDriverAmmo1, MassDriverAmmo2
        };

        public CommodityEnum CommodityType;
        public String CommodityDescription;
        public int UnitWeight;
        public int UnitVolume;
        public int BaseValue;
        public int MaxQuantity;
        public bool IsVolatile;
        public bool IsResource;

        public Commodity(CommodityEnum c, String inDescription, int inWeight, int inVol, int inVal, int inMaxQuantity, bool inIsVolatile) : base()
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

        // For Resoources
        public Commodity(CommodityEnum c)
        {
            IsResource = true;
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

            /*
            Fuel = 0, Water, Uranium, Foodstuffs, RepairPatch, ScrapMetal, Coolant, CopperCabling,
            Slaves, Minerals, PreciousMetals, SpaceSteel, Hydrogen, Titanium, Ceramics, Spices,
            ComputerComponents, Biomass, Hydrocarbons,Missile1, Missile2, LaserCrystal1, LaserCrystal2, 
            MassDriverAmmo1, MassDriverAmmo2
             * */

            //String inDescription, int inWeight, int inVol, int inVal, int inMaxQuantity, bool inIsVolatile
            tempCommodity = new Commodity(Commodity.CommodityEnum.Fuel, "Fuel", 6, 1, 5, 100000, true);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Water, "Water", 1, 1, 1, 800, false);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Uranium, "Uranium", 50, 10, 800, 200, false);
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
            tempCommodity = new Commodity(Commodity.CommodityEnum.Minerals, "Minerals", 25, 5, 60, 200, false);
            commoditiesTempList.Add(tempCommodity);
            //String inDescription, int inWeight, int inVol, int inVal, int inMaxQuantity, bool inIsVolatile
            tempCommodity = new Commodity(Commodity.CommodityEnum.PreciousMetals, "Precious Metals", 1, 1, 8000, 35, false);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.SpaceSteel, "Space Steel", 15, 50, 175, 250, false);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Hydrogen, "Hydrogen", 1, 3, 8, 12000, true);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Titanium, "Titanium", 4, 50, 300, 250, false);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Ceramics, "Ceramics", 8, 18, 150, 250, false);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Spices, "Spices", 1, 15, 80, 800, false);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.ComputerComponents, "Computer Components", 5, 50, 525, 150, false);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Biomass, "Biomass", 8, 35, 75, 1600, false);
            commoditiesTempList.Add(tempCommodity);
            tempCommodity = new Commodity(Commodity.CommodityEnum.Hydrocarbons, "Hydrocarbons", 2, 50, 175, 250, true);
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
            // Next are resources, which fall under the commodity umbrella for now
            //


            NumOfCommodities = commoditiesTempList.Count;

            return commoditiesTempList.ToArray();
        }
    }
}
