using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpaceAge.Controls
{
    partial class InteractionCenterUi : UserControl
    {
        public IInteractableBody thisInteractionCenter = null;
        public bool NeedToRefresh = true;

        private Commodity.CommodityEnum Market_ShipCommodity_Selected = Commodity.CommodityEnum.Coolant;
        private int Market_ShipCommodity_Index = 0;
        private Commodity.CommodityEnum Market_StationCommodity_Selected = Commodity.CommodityEnum.Coolant;
        private int MarketStationCommodity_Index = 0;

        // Keep record of references to the tab pages
        TabPage Info;
        TabPage Market;
        TabPage Escrow;
        TabPage Agents;
        TabPage People;
        TabPage Politics;

        private InteractionCenterUi()
        {
            InitializeComponent();

            //
            // Properties for system listview
            //
            GraphicsLib.ApplyListviewProperties(Market_MarketCommodities);
            GraphicsLib.ApplyListviewProperties(Market_ShipCommodities);
            GraphicsLib.ApplyListviewProperties(Escrow_PlayerList);
            GraphicsLib.ApplyListviewProperties(Escrow_StoreList);

            // Set tab references for easy access. modify these indices if they ever change in the collection
            Info = tabControl1.TabPages[0];
            Market = tabControl1.TabPages[1];
            Escrow = tabControl1.TabPages[2];
            Agents = tabControl1.TabPages[3];
            People = tabControl1.TabPages[4];
            Politics = tabControl1.TabPages[5];

            ////Activate double buffering

            //this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            ////Enable the OnNotifyMessage event so we get a chance to filter out 
            //// Windows messages before they get to the form's WndProc
            //this.SetStyle(ControlStyles.EnableNotifyMessage, true);

        }

        public static InteractionCenterUi GetInteractionCenterUi(IInteractableBody thisCenter)
        {
            InteractionCenterUi icUI = new InteractionCenterUi();

            icUI.thisInteractionCenter = thisCenter;

            //
            // Check to see which tabs should be enabled
            //

            // General Info
            (icUI.Info as Control).Enabled = true;
            // ItemStore stuff
            if (icUI.thisInteractionCenter.Store != null)
            {
                (icUI.Market as Control).Enabled = true;
                (icUI.Escrow as Control).Enabled = true;
                icUI.SetItemStore(thisCenter.Store);
            }
            else
            {
                (icUI.Market as Control).Enabled = false;
                (icUI.Escrow as Control).Enabled = true;
            }

            // Mission post (agent stuff)
            if (icUI.thisInteractionCenter.MissionPost != null)
            {
                (icUI.Agents as Control).Enabled = true;
            }
            else
            {
                (icUI.Agents as Control).Enabled = false;
            }

            if (icUI.thisInteractionCenter.PeopleSource != null)
            {
                (icUI.People as Control).Enabled = true;
            }
            else
            {
                (icUI.People as Control).Enabled = false;
            }

            if (icUI.thisInteractionCenter.PoliticalCenter != null)
            {
                (icUI.Politics as Control).Enabled = true;
            }
            else
            {
                (icUI.Politics as Control).Enabled = false;
            }
            
            return icUI;
        }


        private void SetItemStore(ItemStore i)
        {
            i.SetCommodityListViewColumns(Market_MarketCommodities);
            UserState.PlayerShip.SpaceShipCargo.SetCommodityListViewAtStoreColumns(Market_ShipCommodities);
            i.SetItemListViewColumns(Escrow_StoreList);
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

            // Change this cast to conditional later when more than just planets can have trade centers
            //InteractionCenter_InfoName.Text = "Planet: " + (thisInteractionCenter.Parent as Planet).ToString();
            //Info_Population.Text = (thisInteractionCenter.Parent as Planet).Population.ToString();
            InteractionCenter_InfoName.Text = thisInteractionCenter.ToString();
            Info_Population.Text = "TODO: IInhabitable";

            InteractionCenter_Credits.Text = UserState.getPlayerFunds().ToString();
            market_cargo_space.Text = "Cargo bay: " + UserState.PlayerShip.SpaceShipCargo.ConsumedVolume + "/" + UserState.PlayerShip.SpaceShipCargo.MaxVolume + " m3";

            Market_MarketCommodities.Items.Clear();
            Market_MarketCommodities.Items.AddRange(thisInteractionCenter.Store.GetCommmodityListView());

            Market_ShipCommodities.Items.Clear();
            Market_ShipCommodities.Items.AddRange(UserState.PlayerShip.SpaceShipCargo.GetCommmodityListViewAtStore(thisInteractionCenter.Store));

            Escrow_StoreList.Items.Clear();
            Escrow_StoreList.Items.AddRange(thisInteractionCenter.Store.GetItemListView());

            Escrow_PlayerList.Items.Clear();
            Escrow_PlayerList.Items.AddRange(UserState.PlayerShip.SpaceShipCargo.GetItemListView());
        }

        public void UpdateQuantityPrices()
        {
            try
            {
                ItemStore IS = thisInteractionCenter.Store;
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
                    // Make sure the current store buys these before querying for price
                    if (thisInteractionCenter.Store.CanUserSellCommodity(CE))
                    {
                        TotalSellPrice = NumToSell * IS.QueryCommodityUserSellPrice(CE);
                    }
                    else
                    {
                        TotalSellPrice = 0;
                    }
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
            // Make sure the store is actually buying these commodities
            if(!thisInteractionCenter.Store.CanUserSellCommodity(Market_ShipCommodity_Selected))
                return; // TODO: error message

            ItemStore IS = thisInteractionCenter.Store;
            CargoItemList SC = UserState.PlayerShip.SpaceShipCargo;

            int NumToSell = Int32.Parse(SellQuantity.Text.ToString());
            int MoneyToUser = NumToSell * IS.QueryCommodityUserSellPrice(Market_ShipCommodity_Selected);

            if ((IS.GetItemStoreCash() - MoneyToUser) < 0)
            {
                // TODO: Fail Message Here
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
            ItemStore IS = thisInteractionCenter.Store;
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
