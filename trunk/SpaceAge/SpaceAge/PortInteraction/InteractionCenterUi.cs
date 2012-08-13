using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpaceAge
{
    partial class InteractionCenterUi : Form
    {
        InteractionCenter thisInteractionCenter = null;
        public bool NeedToRefresh = true;

        private Commodity.CommodityEnum Market_ShipCommodity_Selected = Commodity.CommodityEnum.Coolant;
        private int Market_ShipCommodity_Index = 0;
        private Commodity.CommodityEnum Market_StationCommodity_Selected = Commodity.CommodityEnum.Coolant;
        private int MarketStationCommodity_Index = 0;

        public InteractionCenterUi()
        {
            InitializeComponent();

            //
            // Properties for system listview
            //
            Market_MarketCommodities.View = View.Details;
            Market_MarketCommodities.FullRowSelect = true;
            Market_MarketCommodities.GridLines = true;
            Market_MarketCommodities.HideSelection = false;

            Market_ShipCommodities.View = View.Details;
            Market_ShipCommodities.FullRowSelect = true;
            Market_ShipCommodities.GridLines = true;
            Market_ShipCommodities.HideSelection = false;

            Escrow_PlayerList.View = View.Details;
            Escrow_PlayerList.FullRowSelect = true;
            Escrow_PlayerList.GridLines = true;

            Escrow_StoreList.View = View.Details;
            Escrow_StoreList.FullRowSelect = true;
            Escrow_StoreList.GridLines = true;
            ////Activate double buffering
            //this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            ////Enable the OnNotifyMessage event so we get a chance to filter out 
            //// Windows messages before they get to the form's WndProc
            //this.SetStyle(ControlStyles.EnableNotifyMessage, true);

        }

        public void SetInteractionCenter(InteractionCenter i)
        {
            thisInteractionCenter = i;
            thisInteractionCenter.thisStore.SetCommodityListViewColumns(Market_MarketCommodities);
            UserState.PlayerShip.SpaceShipCargo.SetCommodityListViewAtStoreColumns(Market_ShipCommodities);
            thisInteractionCenter.thisStore.SetItemListViewColumns(Escrow_StoreList);
            UserState.PlayerShip.SpaceShipCargo.SetItemListViewColumns(Escrow_PlayerList);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            UpdateUi();
        }

        public void UpdateUi()
        {
            if (thisInteractionCenter == null)
                return;
            if (NeedToRefresh)
            {
                UpdateLists();
                UpdateQuantityPrices();
            }
        }

        public void UpdateLists()
        {
            NeedToRefresh = false;
            InteractionCenter_Credits.Text = UserState.getPlayerFunds().ToString();
            market_cargo_space.Text = "Cargo bay: " + UserState.PlayerShip.SpaceShipCargo.ConsumedVolume + "/" + UserState.PlayerShip.SpaceShipCargo.MaxVolume + " m3";

            Market_MarketCommodities.Items.Clear();
            Market_MarketCommodities.Items.AddRange(thisInteractionCenter.thisStore.GetCommmodityListView());

            Market_ShipCommodities.Items.Clear();
            Market_ShipCommodities.Items.AddRange(UserState.PlayerShip.SpaceShipCargo.GetCommmodityListViewAtStore(thisInteractionCenter.thisStore));

            Escrow_StoreList.Items.Clear();
            Escrow_StoreList.Items.AddRange(thisInteractionCenter.thisStore.GetItemListView());

            Escrow_PlayerList.Items.Clear();
            Escrow_PlayerList.Items.AddRange(UserState.PlayerShip.SpaceShipCargo.GetItemListView());
        }

        public void UpdateQuantityPrices()
        {
            try
            {
                ItemStore IS = thisInteractionCenter.thisStore;
                CargoItemList SC = UserState.PlayerShip.SpaceShipCargo;
                Commodity.CommodityEnum CE;

                int NumToBuy = Int32.Parse(BuyQuantity.Text.ToString());
                int NumToSell = Int32.Parse(SellQuantity.Text.ToString());
                int TotalBuyPrice = 0;
                int TotalSellPrice = 0;

                if (Market_MarketCommodities.SelectedItems.Count >= 1)
                {
                    CE = IS.GetCommodityAtListViewIndex(Market_MarketCommodities.SelectedItems[0].ImageIndex);
                    Market_StationCommodity_Selected = CE;
                    MarketStationCommodity_Index = (Market_MarketCommodities.SelectedItems[0].ImageIndex);
                    TotalBuyPrice = NumToBuy * IS.QueryCommodityUserBuyPrice(CE);
                }
                if (Market_ShipCommodities.SelectedItems.Count >= 1)
                {
                    CE = SC.GetCommodityAtListViewIndex(Market_ShipCommodities.SelectedItems[0].ImageIndex);
                    Market_ShipCommodity_Index = Market_ShipCommodities.SelectedItems[0].ImageIndex;
                    Market_ShipCommodity_Selected = CE;
                    TotalSellPrice = NumToSell * IS.QueryCommodityUserSellPrice(CE);
                }

                BuyPrice.Text = TotalBuyPrice.ToString();
                SellPrice.Text = TotalSellPrice.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        private void InteractionCenterUi_Load(object sender, EventArgs e)
        {

        }

        private void SellQuantity_TextChanged(object sender, EventArgs e)
        {
            UpdateQuantityPrices();
        }

        private void BuyQuantity_TextChanged(object sender, EventArgs e)
        {
            UpdateQuantityPrices();
        }

        private void Market_ShipCommodities_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateQuantityPrices();
        }

        private void Market_MarketCommodities_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateQuantityPrices();
        }

        private void tab_escrow_Click(object sender, EventArgs e)
        {

        }

        private void InteractionCenter_SellButton_Click(object sender, EventArgs e)
        {
            ItemStore IS = thisInteractionCenter.thisStore;
            CargoItemList SC = UserState.PlayerShip.SpaceShipCargo;

            int NumToSell = Int32.Parse(SellQuantity.Text.ToString());
            int MoneyToUser = NumToSell * IS.QueryCommodityUserSellPrice(Market_ShipCommodity_Selected);

            if ((IS.GetItemStoreCash() - MoneyToUser) < 0)
            {
                // Fail Message Here
                return;
            }

            if(SC.RemoveCommodity(Market_ShipCommodity_Selected, NumToSell))
            {
                if (IS.UserSellCommodity(Market_ShipCommodity_Selected, NumToSell))
                {
                    UserState.changePlayerFunds(MoneyToUser);
                }
                else
                {
                    // TODO : Failure and fallthrough conditions
                }
            }


            UpdateLists();
        }

        private void InteractionCenter_BuyButton_Click(object sender, EventArgs e)
        {
            ItemStore IS = thisInteractionCenter.thisStore;
            CargoItemList SC = UserState.PlayerShip.SpaceShipCargo;

            int NumToBuy = Int32.Parse(BuyQuantity.Text.ToString());
            int CostToUser = NumToBuy * IS.QueryCommodityUserBuyPrice(Market_StationCommodity_Selected);

            if ((UserState.getPlayerFunds() - CostToUser) < 0)
            {
                // Fail Message Here
                return;
            }

            if (IS.UserBuyCommodity(Market_StationCommodity_Selected, NumToBuy))
            {
                if(SC.AddCommodity(Market_StationCommodity_Selected, NumToBuy))
                {
                    UserState.changePlayerFunds(-CostToUser);
                }
                else
                {
                    // TODO : Failure and fallthrough conditions
                }
            }
            
            UpdateLists();
        }

    }
}
