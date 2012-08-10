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
    partial class UiInventory : UserControl
    {
        public CargoItemList associatedList;

        public UiInventory()
        {
            InitializeComponent();

            //
            // Properties for system listview
            //
            ui_InventoryListview.View = View.Details;
            ui_InventoryListview.FullRowSelect = true;
            ui_InventoryListview.GridLines = true;

            associatedList = UserState.PlayerShip.SpaceShipCargo;

            associatedList.SetMixedListViewColumns(ui_InventoryListview);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            UpdateUi();
        }

        public void UpdateUi()
        {
            ui_InventoryListview.Items.Clear();
            ui_InventoryListview.Items.AddRange(associatedList.GetMixedListView());
        }
    }
}
