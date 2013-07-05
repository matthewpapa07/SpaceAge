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
    public partial class SectorBrowser : UserControl, HumanInterfaceObj
    {
        bool ShipAlreadyMoving = false;
        Sector CurrentSector = UserState.getCurrentSector();

        public SectorBrowser()
        {
            InitializeComponent();

            GraphicsLib.ApplyListviewProperties(listview_sectoritems);
            GraphicsLib.ApplyListviewProperties(listview_sectorships);

            Sector.SetSectorObjectListViewItemsMini(listview_sectoritems);
            SpaceShip.SpaceShipObjectListViewItemsMini(listview_sectorships);

            RefreshShipsLv();
            RefreshSectorItemsLv();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawStuff(e.Graphics);
        }

        public void DrawStuff(Graphics GraphicsToUse)
        {

        }

        void RefreshShipsLv()
        {
            ListViewItem tempLv;
            // TODO: Determine if refresh is even needed
            try
            {
                listview_sectorships.Items.Clear();
                foreach (SpaceShip sps in CurrentSector.PresentSpaceShips)
                {
                    tempLv = (ListViewItem)sps.SpaceShipListViewItem.Clone();
                    listview_sectorships.Items.Add(tempLv);
                }
            }
            catch
            {
            }
        }

        void RefreshSectorItemsLv()
        {
            ListViewItem tempLv;
            // TODO: Determine if refresh is even needed
            try
            {
                listview_sectoritems.Items.Clear();
                foreach (StarSystem sss in CurrentSector.StarSystemsList)
                {
                    tempLv = (ListViewItem)sss.StarSystemListViewItem.Clone();
                    listview_sectoritems.Items.Add(tempLv);
                }
            }
            catch
            {
            }
           
        }

        public void UserKeyPress(int Key)
        {
            if (!ShipAlreadyMoving)
            {
                switch (Key)
                {
                    case 'w':       // Up
                        break;
                    case 's':       // Down
                        break;
                    case 'a':       // Left
                        break;
                    case 'd':       // Right
                        break;
                    case ' ':       // Stop
                        break;
                    default:
                        break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //sectorMapComplex1.StartMovement();
        }

        private void sectorMapComplex1_Click(object sender, EventArgs e)
        {

        }

        private void SectorBrowser_Leave(object sender, EventArgs e)
        {

        }

        private void SectorBrowser_Enter(object sender, EventArgs e)
        {
            sectorNavigationPane1.LocalSectorMapComplex.MapRefreshThread.Start();
            sectorNavigationPane1.LocalSectorMapComplex.ShipVelocityThread.Start();
        }

    }
}
