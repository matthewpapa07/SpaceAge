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
            prototype.IntializeStats(100, 100, 5, 200, 1, 1);

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
    }
}
