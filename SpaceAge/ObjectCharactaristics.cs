using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SpaceAge
{

    static class ObjectCharactaristics
    {
        /// <summary>
        /// Stuff to have happen on first class usage
        /// </summary>
        static ObjectCharactaristics()
        {
            StaticGraphics staticGraphics = StaticGraphics.getStaticGraphics();
            StarTypeBrushes = new SolidBrush[] 
                {staticGraphics.whiteBrush, staticGraphics.brownBrush, staticGraphics.orangeBrush, staticGraphics.yellowBrush,
                staticGraphics.blueBrush, staticGraphics.redBrush};
            StarSizeRectangles = new Rectangle[] { new Rectangle(0, 0, 4, 4), new Rectangle(0, 0, 5, 5), new Rectangle(0, 0, 6, 6) ,
            new Rectangle(0,0,7,7), new Rectangle(0,0,8,8), new Rectangle(0,0,9,9)};
        }

        //
        // Commonly Associated with Stars
        //
        public static string[] StarColorString = { "White", "Brown", "Orange", "Yellow", "Blue", "Red" };
        public enum StarType { White, Brown, Orange, Yellow, Blue, Red };
        public static SolidBrush[] StarTypeBrushes;     // Populate on construction

        public static string[] StarSizeString = { "Dwarf", "Micro", "Normal", "Medium", "Giant", "UltraGiant" };
        public enum StarSize { Dwarf, Micro, Normal, Medium, Giant, UltraGiant};
        public static Rectangle[] StarSizeRectangles;
//        public static int [] StarSizeValues = {1000,2000,23432};  //TODO: Size Values

        //
        // Charactaristics Associated with Planets
        //
        public static string[] PlanetSizeString = { "Asteroid", "VerySmall", "Small", "Medium", "Large", "Super" };
        public enum PlanetSize { Asteroid, VerySmall, Small, Medium, Large, Super };    // Size of the planet
//        public static int[] SizeValues = { 1000, 2000, 23432 };  //TODO: Size Values

        public static string[] PositionString = { "Inner", "Middle", "Outer", "Rogue" };
        public enum Position { Inner, Middle, Outer, Rogue };                     // Position of planet from star

        //
        // Common resources on planet.
        //  ALSO UPDATE THE COMMODITY ENTRY WHEN UPDATING
        //
        public static string[] CommonAtmosphereString = { "Oxygen", "Hydrogen", "Methane", "SulphuricAcid", "CarbonDioxide", "Nitrogen", "Chlorine", "Helium"};
        public enum CommonAtmosphere { Oxygen = 0, Hydrogen, Methane, SulphuricAcid, CarbonDioxide, Nitrogen, Chlorine, Helium };
        public static Commodity.CommodityEnum CommonAtmosphereToC(CommonAtmosphere ca)
        {
            return Commodity.CommodityEnum.Oxygen + (int)ca;
        }

        public static string[] RareAtmosphereString = { "Boron", "Neon", "Xenon", "Krypton" };
        public enum RareAtmosphere { Boron = 0, Neon, Xenon, Krypton };
        public static Commodity.CommodityEnum RareAtmosphereToC(RareAtmosphere ra)
        {
            return Commodity.CommodityEnum.Boron + (int)ra;
        }

        public static string[] CommonElementsString = { "Silicon", "Iron", "Carbon", "Copper", "Magnesium", "Sodium", "Sulfur", "Lead", "Nickel", "Amuninum" };
        public enum CommonElements { Silicon = 0, Iron, Carbon, Copper, Magnesium, Sodium, Sulfur, Lead, Nickel, Amuninum };
        public static Commodity.CommodityEnum CommonElementsToC(CommonElements ce)
        {
            return Commodity.CommodityEnum.Silicon + (int)ce;
        }

        public static string[] RareElementsString = { "Titanium", "Neodymium", "Germanium", "Gallium", "Arsenic", "Strontium", "Gold", "Silver", "Platinum" };
        public enum RareElements { Titanium = 0, Neodymium, Germanium, Gallium, Arsenic, Strontium, Gold, Silver, Platinum };
        public static Commodity.CommodityEnum RareElementsToC(RareElements re)
        {
            return Commodity.CommodityEnum.Titanium + (int)re;
        }

        public static string[] ResourcesStaticString = { "Hydrocarbons", "Cellulose", "Acid", "Biomass", "Mud", "Water", "Minerals" };
        public enum ResourcesStatic  { Hydrocarbons = 0, Cellulose, Acid, Biomass, Mud, Water, Minerals };
        public static Commodity.CommodityEnum ResourcesStaticToC(ResourcesStatic rs)
        {
            return Commodity.CommodityEnum.Hydrocarbons + (int)rs;
        }

        //
        // Charactaristics assocaited with items
        //
        public static string[] ItemSizeStaticString = { "Extra Small", "Small", "Medium", "Large", "Extra Large", "N/A" };
        public enum ItemSize { ExtraSmall, Small, Medium, Large, ExraLarge, NoSize };
        public static int [] ItemSizeStatMultiplier = { 1, 3, 10, 25, 50, 1 };
        public static int[] ItemSizeStatDivider = { 5, 4, 3, 2, 1, 1 };

    }

    public abstract class Resource
    {
        public string ElementName;

        public NumberGenerator numGen = NumberGenerator.getInstance();

        public Resource()
        {
        }

        public abstract void generateResource ();

        public override string ToString()
        {
            return ElementName;
        }
    }

    public class CommonAtmosphere : Resource
    {
        ObjectCharactaristics.CommonAtmosphere atmosphere;

        public CommonAtmosphere()
        {
            generateResource();
            ElementName = ObjectCharactaristics.CommonAtmosphereString[(int)atmosphere];
        }

        public override void generateResource()
        {
            atmosphere = numGen.RandomEnum<ObjectCharactaristics.CommonAtmosphere>();
        }
    }

    public class RareAtmosphere : Resource
    {
        ObjectCharactaristics.RareAtmosphere atmosphere;

        public RareAtmosphere()
        {
            generateResource();
            ElementName = ObjectCharactaristics.RareAtmosphereString[(int)atmosphere];
        }

        public override void generateResource()
        {
            atmosphere = numGen.RandomEnum<ObjectCharactaristics.RareAtmosphere>();
        }
    }

    public class CommonElement : Resource
    {
        ObjectCharactaristics.CommonElements elements;
        
        public CommonElement ()
        {
            generateResource();
            ElementName = ObjectCharactaristics.CommonElementsString[(int)elements];
        }

        public override void generateResource()
        {
            elements = numGen.RandomEnum<ObjectCharactaristics.CommonElements>();
        }
    }

    public class RareElement : Resource
    {
        ObjectCharactaristics.RareElements elements;

        public RareElement()
        {
            generateResource();
            ElementName = ObjectCharactaristics.RareElementsString[(int)elements];
        }

        public override void generateResource()
        {
            elements = numGen.RandomEnum<ObjectCharactaristics.RareElements>();
        }
    }

    public class ResourceStatic : Resource
    {
        ObjectCharactaristics.ResourcesStatic resources;

        public ResourceStatic()
        {
            generateResource();
            ElementName = ObjectCharactaristics.ResourcesStaticString[(int)resources];
        }

        public override void generateResource()
        {
            resources = numGen.RandomEnum<ObjectCharactaristics.ResourcesStatic>();
        }
    }
}
