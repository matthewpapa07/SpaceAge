using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpaceAge
{
    class ItemList
    {
        internal List<Item> allItems = new List<Item>();
        internal int[] commoditiesQuantitiy = new int[Commodity.AllCommoditiesArray.Length];

        public ItemList()
        {

        }

        public int CommoditiesAvailable(Commodity.CommodityEnum commodityType)
        {
            return commoditiesQuantitiy[(int)commodityType];
        }

        public virtual bool AddCommodity(Commodity.CommodityEnum commodityType, int quantity)
        {
            commoditiesQuantitiy[(int)commodityType] += quantity;

            return true;
        }

        public virtual bool RemoveCommodity(Commodity.CommodityEnum commodityType, int quantity)
        {
            if (commoditiesQuantitiy[(int)commodityType] >= quantity)
            {
                commoditiesQuantitiy[(int)commodityType] -= quantity;
                return true;
            }
            else
            {
                return false;
            }
        }

        public Commodity.CommodityEnum [] getCommoditiesPresent()
        {
            List<Commodity.CommodityEnum> protoList = new List<Commodity.CommodityEnum>();

            for(int i = 0; i < Commodity.NumOfCommodities; i++)
            {
                if(commoditiesQuantitiy[i] > 0)
                    protoList.Add(Commodity.AllCommoditiesArray[i].CommodityType);
            }
            return protoList.ToArray();
        }

        public virtual bool AddItem(Item itemToAdd)
        {
            allItems.Add(itemToAdd);

            return true;
        }

        public virtual bool RemoveItem(Item itemToRemove)
        {
            if(DoesListContain(itemToRemove))
            {
                return allItems.Remove(itemToRemove);
            }
            else
                return false;
        }

        public Item[] GetItemList()
        {
            return allItems.ToArray();
        }

        public int ComputeListWeight()
        {
            int runningTotal = 0;

            for (int i = 0; i < Commodity.NumOfCommodities; i++)
            {
                runningTotal += Commodity.AllCommoditiesArray[i].UnitWeight * commoditiesQuantitiy[i];
            }

            foreach (Item i in allItems)
            {
                runningTotal += i.ItemBaseWeight;
            }

            return runningTotal;
        }

        public int ComputeListVolume()
        {
            int runningTotal = 0;

            for (int i = 0; i < Commodity.NumOfCommodities; i++)
            {
                runningTotal += Commodity.AllCommoditiesArray[i].UnitVolume * commoditiesQuantitiy[i];
            }

            foreach (Item i in allItems)
            {
                runningTotal += i.ItemBaseVolume;
            }

            return runningTotal;
        }

        public bool DoesListContain(Item i)
        {
            foreach (Item p in allItems)
            {
                if (p.Equals(i))
                    return true;
            }
            return false;
        }

        public virtual void SetCommodityListViewColumns(ListView targetListView)
        {
            targetListView.Columns.Clear();

            targetListView.Columns.Add("Commodity Name", 100);
            targetListView.Columns.Add("Num", 40);
            targetListView.Columns.Add("Class", 40);
            targetListView.Columns.Add("Vol", 40);
            targetListView.Columns.Add("Stats", 120);
        }

        public Commodity.CommodityEnum GetCommodityAtListViewIndex(int index)
        {
            return this.getCommoditiesPresent()[index];
        }

        public virtual ListViewItem[] GetCommmodityListView()
        {
            Commodity.CommodityEnum[] availableCom = this.getCommoditiesPresent();

            ListViewItem[] itemListView;

            itemListView = new ListViewItem[availableCom.Length];

            //foreach (Item i in InteractionCenter.
            for (int i = 0; i < availableCom.Length; i++)
            {
                itemListView[i] = new ListViewItem(Commodity.getCommodityFromEnum(availableCom[i]).ToString(), i);
                itemListView[i].SubItems.Add(this.CommoditiesAvailable(availableCom[i]).ToString());
                itemListView[i].SubItems.Add("Commodity");
                itemListView[i].SubItems.Add(Commodity.getCommodityFromEnum(availableCom[i]).UnitVolume.ToString());
                itemListView[i].SubItems.Add("N/A");
            }

            return itemListView;
        }

        public virtual void SetItemListViewColumns(ListView targetListView)
        {
            targetListView.Columns.Clear();

            targetListView.Columns.Add("Item Name", 100);
            targetListView.Columns.Add("Num", 40);
            targetListView.Columns.Add("Class", 40);
            targetListView.Columns.Add("Vol", 40);
            targetListView.Columns.Add("Stats", 120);
        }

        public Item GetItemAtListViewIndex(int index)
        {
            return allItems[index];
        }

        public virtual ListViewItem [] GetItemListView()
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

        public virtual void SetMixedListViewColumns(ListView targetListView)
        {
            targetListView.Columns.Clear();

            targetListView.Columns.Add("Item Name", 100);
            targetListView.Columns.Add("Num", 40);
            targetListView.Columns.Add("Class", 40);
            targetListView.Columns.Add("Vol", 40);
            targetListView.Columns.Add("Stats", 120);
        }

        public Item GetItemAtMixedListViewIndex(int index)
        {
            return allItems[index - this.getCommoditiesPresent().Length];
        }

        public Commodity.CommodityEnum GetCommodityAtMixedListViewIndex(int index)
        {
            return (Commodity.CommodityEnum)index;
        }

        public virtual ListViewItem[] GetMixedListView()
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
    }
}
