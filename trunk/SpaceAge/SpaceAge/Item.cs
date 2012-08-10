using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceAge
{
    abstract class Item
    {
        public ObjectCharactaristics.ItemSize ItemSize;

        static int MasterUniqueIdentifier = 100;
        public int UniqueIdentifier = -1;

        // TODO: Hide base price and make generation dynamic based on the item's stats
        public int ItemBasePrice = 1;
        public int ItemBaseWeight = 1;
        public int ItemBaseVolume = 1;

        public bool IsGenericItem = true;

        public Item()
        {
            UniqueIdentifier = ++MasterUniqueIdentifier;
            ItemSize = ObjectCharactaristics.ItemSize.NoSize; //No Size by default
        }

        public override bool Equals(object obj)
        {
            //return base.Equals(obj);
            if(obj is Item)
            {
                Item i = (Item)obj;
                if (this.UniqueIdentifier == i.UniqueIdentifier)
                {
                    return true;
                }
            }
            return false;
        }

        public abstract string SpecialStat();
        public abstract override string ToString();
        
    }
}
