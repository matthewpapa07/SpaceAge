using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpaceAge
{
    class CargoItemList : ItemList
    {
        public SpaceShip ParentShip = null;

        public int MaxVolume = 0;
        public int ConsumedVolume = 0;

        public CargoItemList(int inMaxVolume) 
            : base()
        {
            MaxVolume = inMaxVolume;
            ConsumedVolume = base.ComputeListVolume();
        }

        public CargoItemList(int inMaxVolume, SpaceShip parent)
            : base()
        {
            MaxVolume = inMaxVolume;
            ConsumedVolume = base.ComputeListVolume();
            ParentShip = parent;
        }

        public bool ChangeVolume(int inNewMaxVolume)
        {
            if (ConsumedVolume > inNewMaxVolume)
            {
                //
                // Reject the volume change
                //
                return false;
            }

            MaxVolume = inNewMaxVolume;

            return true;
        }
        

        public override bool AddItem(Item itemToAdd)
        {
            if (IsThereSpaceForThis(itemToAdd))
            {
                base.AddItem(itemToAdd);
                RefreshConsumedSpace();
                return true;
            }
            return false;
        }

        public override bool RemoveItem(Item itemToRemove)
        {
            bool result = base.RemoveItem(itemToRemove);

            if (result)
            {
                RefreshConsumedSpace();
                return result;
            }
            else
                return result;
        }

        public override bool AddCommodity(Commodity.CommodityEnum commodityType, int quantity)
        {
            if (IsThereSpaceForThis(commodityType, quantity))
            {
                base.AddCommodity(commodityType, quantity);
                RefreshConsumedSpace();
                return true;
            }
            return false;
        }

        public override bool RemoveCommodity(Commodity.CommodityEnum commodityType, int quantity)
        {
            bool result = base.RemoveCommodity(commodityType, quantity);

            if (result)
            {
                RefreshConsumedSpace();
                return result;
            }
            return false;
        }

        private bool IsThereSpaceForThis(Item i)
        {
            if ((ConsumedVolume + i.ItemBaseVolume) > MaxVolume)
            {
                return false;
            }
            return true;
        }

        private bool IsThereSpaceForThis(Commodity.CommodityEnum c, int quantity)
        {
            if ((ConsumedVolume + Commodity.getCommodityFromEnum(c).UnitVolume*quantity) > MaxVolume)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// This method can make some other methods more efficient as long as its called only
        /// when the list is changed
        /// </summary>
        private void RefreshConsumedSpace()
        {
            ConsumedVolume = base.ComputeListVolume();
        }

        public void SetCommodityListViewAtStoreColumns(ListView targetListView)
        {
            targetListView.Columns.Clear();

            targetListView.Columns.Add("Item Name", 120);
            targetListView.Columns.Add("Quantity ", 60);
            targetListView.Columns.Add("Sell Price");
            targetListView.Columns.Add("Unit Volume");
            targetListView.Columns.Add("Class");
        }

        public ListViewItem[] GetCommmodityListViewAtStore(ItemStore IS)
        {
            Commodity.CommodityEnum[] availableCom = this.getCommoditiesPresent();

            ListViewItem[] itemListView;

            itemListView = new ListViewItem[availableCom.Length];

            //foreach (Item i in InteractionCenter.
            for (int i = 0; i < availableCom.Length; i++)
            {
                Commodity c = Commodity.getCommodityFromEnum(availableCom[i]);
                itemListView[i] = new ListViewItem(c.ToString(), i);
                itemListView[i].SubItems.Add(this.CommoditiesAvailable(availableCom[i]).ToString());
                itemListView[i].SubItems.Add(IS.QueryCommodityUserSellPrice(availableCom[i]).ToString());
                itemListView[i].SubItems.Add(Commodity.getCommodityFromEnum(availableCom[i]).UnitVolume.ToString());
                itemListView[i].SubItems.Add("N/A");
            }

            return itemListView;
        }
    }
}
