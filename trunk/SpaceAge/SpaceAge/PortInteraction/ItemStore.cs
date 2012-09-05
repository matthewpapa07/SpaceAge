using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpaceAge
{
    class ItemStore : ItemList
    {
        private int ItemStoreCash = 1000000000;     // 10 M starting cash
        public IInteractableBody Parent = null;

        // *In parent: internal int[] commoditiesQuantitiy = new int[Commodity.allCommodities.Length];

        // These need to maintain a one to one correspondence with the commodities list
        public bool[] WillBuy = new bool[Commodity.AllCommoditiesArray.Length];
        public bool[] WillSell = new bool[Commodity.AllCommoditiesArray.Length];

        //
        // Eventually make it to where the items are generated based on the 
        // charactaristics the store is present in
        //

        private ItemStore() 
            : base()
        {

        }

        public static ItemStore GetGeneralStore(IInteractableBody inParent)
        {
            ItemStore thisStore = new ItemStore();
            Commodity[] allCommodities = Commodity.AllCommoditiesArray;
            NumberGenerator n = NumberGenerator.getInstance();

            thisStore.Parent = inParent;
            thisStore.Parent.MemberSector.RegisteredItemStores.Add(thisStore);

            for (int i = 0; i < allCommodities.Length; i++)
            {
                // Only prepopulate commodities for now
                if(!allCommodities[i].IsResource)
                    thisStore.AddCommodity(allCommodities[i].CommodityType, (int)((n.GetRandNumberInRange(0, allCommodities[i].MaxQuantity))));

                // This constructor by default should make everything available
                //WillSell[i] = true;
                thisStore.WillBuy[i] = true;
                thisStore.WillSell[i] = true;
            }

            return thisStore;
        }

        public static ItemStore GetExtractorStore(IInteractableBody inParent)
        {
            ItemStore thisStore = new ItemStore();
            Commodity[] allCommodities = Commodity.AllCommoditiesArray;
            NumberGenerator n = NumberGenerator.getInstance();

            thisStore.Parent = inParent;
            thisStore.Parent.MemberSector.RegisteredItemStores.Add(thisStore);

            for (int i = 0; i < allCommodities.Length; i++)
            {
                thisStore.WillBuy[i] = false;
                thisStore.WillSell[i] = false;
            }

            return thisStore;
        }

        public int QueryItemUserBuyPrice(Item i)
        {
            return i.ItemBasePrice;
        }
        public int QueryItemUserSellPrice(Item i)
        {
            return i.ItemBasePrice;
        }

        public int QueryCommodityUserBuyPrice(Commodity.CommodityEnum commodityType)
        {
            if (!CanUserBuyCommodity(commodityType))
            {
                Console.WriteLine("Warning, entity is querying price for item it cannot sell");
                return int.MaxValue;
            }
            Commodity CM = Commodity.getCommodityFromEnum(commodityType);
            int baseVal = CM.BaseValue;
            int availableQuantity = this.commoditiesQuantitiy[(int)commodityType];
            int maxQuantity = CM.MaxQuantity;
            double result = NumberGenerator.getInstance().GetItemSupplyBasedStorePrice(baseVal, availableQuantity, maxQuantity);

            return (int)result;
        }
        public int QueryCommodityUserSellPrice(Commodity.CommodityEnum commodityType)
        {
            if (!CanUserSellCommodity(commodityType))
            {
                Console.WriteLine("Warning, entity is querying price for item it cannot buy");
                return 0;
            }
            Commodity CM = Commodity.getCommodityFromEnum(commodityType);
            int baseVal = CM.BaseValue;
            int availableQuantity = this.commoditiesQuantitiy[(int)commodityType];
            int maxQuantity = CM.MaxQuantity;
            double result = NumberGenerator.getInstance().GetItemSupplyBasedStorePrice(baseVal, availableQuantity, maxQuantity)*.8;

            return (int)result;
        }

        public bool UserBuyItem(Item i)
        {
            if (this.RemoveItem(i))
            {
                ItemStoreCash += QueryItemUserBuyPrice(i);
                return true;
            }
            return false;
        }

        public bool UserSellItem(Item i)
        {
            if (this.AddItem(i))
            {
                ItemStoreCash -= QueryItemUserSellPrice(i);
                return true;
            }
            return false;
        }

        public bool CanUserBuyCommodity(Commodity.CommodityEnum commodityType)
        {
            return WillSell[(int)commodityType];
        }

        public bool UserBuyCommodity(Commodity.CommodityEnum commodityType, int quantity)
        {
            if (!CanUserBuyCommodity(commodityType))
                return false;

            if (this.RemoveCommodity(commodityType, quantity))
            {
                ItemStoreCash += QueryCommodityUserBuyPrice(commodityType);
                return true;
            }
            return false;
        }

        public bool CanUserSellCommodity(Commodity.CommodityEnum commodityType)
        {
            return WillBuy[(int)commodityType];
        }

        public bool UserSellCommodity(Commodity.CommodityEnum commodityType, int quantity)
        {
            if (!CanUserSellCommodity(commodityType))
                return false;

            if(this.AddCommodity(commodityType,quantity))
            {
                ItemStoreCash -= QueryCommodityUserSellPrice(commodityType);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Set columns for a listview that shows commodities 
        /// </summary>
        /// <param name="targetListView"></param>
        public override void SetCommodityListViewColumns(ListView targetListView)
        {
            targetListView.Columns.Clear();

            targetListView.Columns.Add("Item Name", 120);
            targetListView.Columns.Add("Quantity Available", 100);
            targetListView.Columns.Add("Unit Price");
            targetListView.Columns.Add("Unit Volume");
            targetListView.Columns.Add("Class");
        }

        public override ListViewItem[] GetCommmodityListView()
        {
            Commodity.CommodityEnum[] availableCom = this.getCommoditiesPresent();

            ListViewItem[] itemListView;

            itemListView = new ListViewItem[availableCom.Length];

            //foreach (Item i in InteractionCenter.
            for (int i = 0; i < availableCom.Length; i++)
            {
                Commodity c = Commodity.getCommodityFromEnum(availableCom[i]);
                itemListView[i] = new ListViewItem(c.ToString(), i);
                itemListView[i].SubItems.Add(this.CommoditiesAvailable(availableCom[i]).ToString() + "/" + c.MaxQuantity.ToString());
                itemListView[i].SubItems.Add(this.QueryCommodityUserBuyPrice(availableCom[i]).ToString());
                itemListView[i].SubItems.Add(Commodity.getCommodityFromEnum(availableCom[i]).UnitVolume.ToString());
                itemListView[i].SubItems.Add("N/A");
            }

            return itemListView;
        }
        /*
            itemListView = new ListViewItem[Commodity.allCommodities.Length];
                
            //foreach (Item i in InteractionCenter.
            for (int i = 0; i < Commodity.allCommodities.Length; i++)
            {
                itemListView[i] = new ListViewItem(Commodity.allCommodities[i].ToString(), i);
                itemListView[i].SubItems.Add(thisStore.CommoditiesAvailable((Commodity.CommodityEnum)i).ToString() + "/" + Commodity.allCommodities[i].MaxQuantity.ToString());
                itemListView[i].SubItems.Add(Commodity.allCommodities[i].BaseValue.ToString()); // TODO: Dynamically determine price later
                itemListView[i].SubItems.Add("N/A");
            }
        */

        public override void SetItemListViewColumns(ListView targetListView)
        {
            targetListView.Columns.Clear();

            targetListView.Columns.Add("Item Name", 100);
            targetListView.Columns.Add("Num", 40);
            targetListView.Columns.Add("Class", 40);
            targetListView.Columns.Add("Vol", 40);
            targetListView.Columns.Add("Stats", 120);
        }

        public override ListViewItem[] GetItemListView()
        {
            ListViewItem[] itemListView;

            itemListView = new ListViewItem[allItems.Count];

            for (int i = 0; i < allItems.Count; i++)
            {
                itemListView[i] = new ListViewItem(allItems[i].ToString(), i);
                itemListView[i].SubItems.Add("-");
                itemListView[i].SubItems.Add(ObjectCharactaristics.ItemSizeStaticString[(int)allItems[i].ItemSize]);
                itemListView[i].SubItems.Add(allItems[i].ItemBaseVolume.ToString());
                itemListView[i].SubItems.Add(allItems[i].SpecialStat());
            }

            return itemListView;
        }

        public override void SetMixedListViewColumns(ListView targetListView)
        {
            targetListView.Columns.Clear();

            targetListView.Columns.Add("Item Name", 100);
            targetListView.Columns.Add("Num", 40);
            targetListView.Columns.Add("Class", 40);
            targetListView.Columns.Add("Vol", 40);
            targetListView.Columns.Add("Stats", 120);
        }

        public override ListViewItem[] GetMixedListView()
        {
            Commodity.CommodityEnum[] availableCom = this.getCommoditiesPresent();

            ListViewItem[] itemListView;

            itemListView = new ListViewItem[availableCom.Length + allItems.Count];

            //foreach (Item i in InteractionCenter.
            for (int i = 0; i < availableCom.Length; i++)
            {
                itemListView[i] = new ListViewItem(Commodity.getCommodityFromEnum(availableCom[i]).ToString(), i);
                itemListView[i].SubItems.Add(this.CommoditiesAvailable(availableCom[i]).ToString());
                itemListView[i].SubItems.Add("Commodity");
                itemListView[i].SubItems.Add(Commodity.getCommodityFromEnum(availableCom[i]).UnitVolume.ToString());
                itemListView[i].SubItems.Add("N/A");
            }
            for (int i = 0; i < allItems.Count; i++)
            {
                itemListView[i + availableCom.Length] = new ListViewItem(allItems[i].ToString(), i + availableCom.Length);
                itemListView[i + availableCom.Length].SubItems.Add("-");
                itemListView[i + availableCom.Length].SubItems.Add(ObjectCharactaristics.ItemSizeStaticString[(int)allItems[i].ItemSize]);
                itemListView[i + availableCom.Length].SubItems.Add(allItems[i].ItemBaseVolume.ToString());
                itemListView[i + availableCom.Length].SubItems.Add(allItems[i].SpecialStat());
            }

            return itemListView;
        }

        public int GetItemStoreCash()
        {
            return ItemStoreCash;
        }

        public void ChangeItemSoreCash(int offset)
        {
            ItemStoreCash += offset;
        }
    }
}
