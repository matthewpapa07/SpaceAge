using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceAge
{
    class ResourceVector
    {
        public Commodity.CommodityEnum TypeOfCommodity;
        public ItemStore WhichStore;
        public Planet WhichPlanet;      // Replace with interface later
        public int Quantity;

        public ResourceVector(Commodity.CommodityEnum inTypeOfCommodity, ItemStore inWhichStore)
        {
            TypeOfCommodity = inTypeOfCommodity;
            WhichStore = inWhichStore;
            Quantity = WhichStore.CommoditiesAvailable(TypeOfCommodity);
            WhichPlanet = (WhichStore.Parent as Planet);
        }
    }
}
