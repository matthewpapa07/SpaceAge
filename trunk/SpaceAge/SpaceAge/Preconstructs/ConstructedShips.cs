using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceAge.Preconstructs
{
    class ConstructedShips
    {
        public static SpaceShip StarterShip()
        {
            SpaceShip prototype = new SpaceShip(2, 2, 1, 1);
            prototype.IntializeStats(100, 100, 5, 400, 30, 1);

            Item itemToAdd;
            Commodity.CommodityEnum commidityToAdd;
            bool EquipStatus = false;

            //
            // Add starting items
            //
            itemToAdd = ShipComponents.ShipArmor.GenerateRandom(ObjectCharactaristics.ItemSize.Small);
            prototype.SpaceShipCargo.AddItem(itemToAdd);
            EquipStatus = prototype.EquipItem(itemToAdd);
            itemToAdd = ShipComponents.ShipEngines.GenerateRandom(ObjectCharactaristics.ItemSize.Small);
            prototype.SpaceShipCargo.AddItem(itemToAdd);
            EquipStatus = prototype.EquipItem(itemToAdd);
            itemToAdd = ShipComponents.ShipEngines.GenerateRandom(ObjectCharactaristics.ItemSize.Small);
            prototype.SpaceShipCargo.AddItem(itemToAdd);
            prototype.SpaceShipCargo.AddItem(itemToAdd);
            itemToAdd = ShipComponents.ShipLaser.GenerateRandom(ObjectCharactaristics.ItemSize.Small);
            prototype.SpaceShipCargo.AddItem(itemToAdd);
            EquipStatus = prototype.EquipItem(itemToAdd);
            itemToAdd = ShipComponents.ShipScanner.GenerateShipScanner(ObjectCharactaristics.ItemSize.Small);
            prototype.SpaceShipCargo.AddItem(itemToAdd);
            EquipStatus = prototype.EquipItem(itemToAdd);
            itemToAdd = ShipComponents.ShipShield.GenerateRandom(ObjectCharactaristics.ItemSize.Small);
            prototype.SpaceShipCargo.AddItem(itemToAdd);
            EquipStatus = prototype.EquipItem(itemToAdd);
            itemToAdd = ShipComponents.ShipMissileLauncher.GenerateRandom(ObjectCharactaristics.ItemSize.Small);
            prototype.SpaceShipCargo.AddItem(itemToAdd);
            
            //
            // Add starting commodities
            //
            commidityToAdd = Commodity.CommodityEnum.Fuel;
            prototype.SpaceShipCargo.AddCommodity(commidityToAdd, 100);
            commidityToAdd = Commodity.CommodityEnum.Water;
            prototype.SpaceShipCargo.AddCommodity(commidityToAdd, 20);
            commidityToAdd = Commodity.CommodityEnum.RepairPatch;
            prototype.SpaceShipCargo.AddCommodity(commidityToAdd, 2);

            return prototype;
        }

        public static MerchantSpaceShip MerchantShip1()
        {
            // Weapons 1
            // Defense 3
            // Engines 2
            // Special 1
            MerchantSpaceShip prototype = new MerchantSpaceShip(1, 3, 2, 1);
            // Armor 100
            // Structure 100
            // Cargo 2000
            // Warp 1
            // Scan 1
            prototype.IntializeStats(100, 100, 3, 2000, 1, 1);

            Item itemToAdd;
            Commodity.CommodityEnum commidityToAdd;
            bool EquipStatus = false;

            //
            // Add starting items
            //
            itemToAdd = ShipComponents.ShipArmor.GenerateRandom(ObjectCharactaristics.ItemSize.Small);
            prototype.SpaceShipCargo.AddItem(itemToAdd);
            EquipStatus = prototype.EquipItem(itemToAdd);
            itemToAdd = ShipComponents.ShipArmor.GenerateRandom(ObjectCharactaristics.ItemSize.Small);
            prototype.SpaceShipCargo.AddItem(itemToAdd);
            EquipStatus = prototype.EquipItem(itemToAdd);
            itemToAdd = ShipComponents.ShipShield.GenerateRandom(ObjectCharactaristics.ItemSize.Small);
            prototype.SpaceShipCargo.AddItem(itemToAdd);
            EquipStatus = prototype.EquipItem(itemToAdd);
            itemToAdd = ShipComponents.ShipEngines.GenerateRandom(ObjectCharactaristics.ItemSize.Small);
            prototype.SpaceShipCargo.AddItem(itemToAdd);
            EquipStatus = prototype.EquipItem(itemToAdd);
            itemToAdd = ShipComponents.ShipEngines.GenerateRandom(ObjectCharactaristics.ItemSize.Small);
            prototype.SpaceShipCargo.AddItem(itemToAdd);
            prototype.SpaceShipCargo.AddItem(itemToAdd);
            itemToAdd = ShipComponents.ShipLaser.GenerateRandom(ObjectCharactaristics.ItemSize.Small);
            prototype.SpaceShipCargo.AddItem(itemToAdd);
            EquipStatus = prototype.EquipItem(itemToAdd);
            itemToAdd = ShipComponents.ShipScanner.GenerateShipScanner(ObjectCharactaristics.ItemSize.Small);
            prototype.SpaceShipCargo.AddItem(itemToAdd);
            EquipStatus = prototype.EquipItem(itemToAdd);

            //
            // Add starting commodities
            //
            commidityToAdd = Commodity.CommodityEnum.Fuel;
            prototype.SpaceShipCargo.AddCommodity(commidityToAdd, 200);
            commidityToAdd = Commodity.CommodityEnum.Water;
            prototype.SpaceShipCargo.AddCommodity(commidityToAdd, 20);
            commidityToAdd = Commodity.CommodityEnum.RepairPatch;
            prototype.SpaceShipCargo.AddCommodity(commidityToAdd, 2);
            commidityToAdd = Commodity.CommodityEnum.ScrapMetal;
            prototype.SpaceShipCargo.AddCommodity(commidityToAdd, 1);

            return prototype;
        }

        public static MerchantSpaceShip MerchantShip2()
        {
            // Weapons 1
            // Defense 3
            // Engines 2
            // Special 1
            MerchantSpaceShip prototype = new MerchantSpaceShip(1, 3, 3, 1);
            // Armor 100
            // Structure 100
            // Cargo 2000
            // Warp 1
            // Scan 1
            prototype.IntializeStats(100, 100, 3, 1200, 1, 1);

            Item itemToAdd;
            Commodity.CommodityEnum commidityToAdd;
            bool EquipStatus = false;

            //
            // Add starting items
            //
            itemToAdd = ShipComponents.ShipArmor.GenerateRandom(ObjectCharactaristics.ItemSize.Small);
            prototype.SpaceShipCargo.AddItem(itemToAdd);
            EquipStatus = prototype.EquipItem(itemToAdd);
            itemToAdd = ShipComponents.ShipArmor.GenerateRandom(ObjectCharactaristics.ItemSize.Small);
            prototype.SpaceShipCargo.AddItem(itemToAdd);
            EquipStatus = prototype.EquipItem(itemToAdd);
            itemToAdd = ShipComponents.ShipShield.GenerateRandom(ObjectCharactaristics.ItemSize.Small);
            prototype.SpaceShipCargo.AddItem(itemToAdd);
            EquipStatus = prototype.EquipItem(itemToAdd);
            itemToAdd = ShipComponents.ShipEngines.GenerateRandom(ObjectCharactaristics.ItemSize.Small);
            prototype.SpaceShipCargo.AddItem(itemToAdd);
            EquipStatus = prototype.EquipItem(itemToAdd);
            itemToAdd = ShipComponents.ShipEngines.GenerateRandom(ObjectCharactaristics.ItemSize.Small);
            prototype.SpaceShipCargo.AddItem(itemToAdd);
            prototype.SpaceShipCargo.AddItem(itemToAdd);
            itemToAdd = ShipComponents.ShipLaser.GenerateRandom(ObjectCharactaristics.ItemSize.Small);
            prototype.SpaceShipCargo.AddItem(itemToAdd);
            EquipStatus = prototype.EquipItem(itemToAdd);
            itemToAdd = ShipComponents.ShipScanner.GenerateShipScanner(ObjectCharactaristics.ItemSize.Small);
            prototype.SpaceShipCargo.AddItem(itemToAdd);
            EquipStatus = prototype.EquipItem(itemToAdd);

            //
            // Add starting commodities
            //
            commidityToAdd = Commodity.CommodityEnum.Fuel;
            prototype.SpaceShipCargo.AddCommodity(commidityToAdd, 200);
            commidityToAdd = Commodity.CommodityEnum.Water;
            prototype.SpaceShipCargo.AddCommodity(commidityToAdd, 20);
            commidityToAdd = Commodity.CommodityEnum.RepairPatch;
            prototype.SpaceShipCargo.AddCommodity(commidityToAdd, 2);
            commidityToAdd = Commodity.CommodityEnum.ScrapMetal;
            prototype.SpaceShipCargo.AddCommodity(commidityToAdd, 1);

            return prototype;
        }
    }
}
