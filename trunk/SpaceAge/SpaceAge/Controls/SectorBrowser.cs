using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SpaceAge.Controls
{
    public partial class SectorBrowser : UserControl, HumanInterfaceObj
    {
        bool ShipAlreadyMoving = false;
        EventToInvoke RefreshElementsEvent = null;
        public Thread LvRefreshTh = null;

        public SectorBrowser()
        {
            InitializeComponent();

            GraphicsLib.ApplyListviewProperties(listview_sectoritems);
            GraphicsLib.ApplyListviewProperties(listview_sectorships);

            Sector.SetSectorObjectListViewItemsMini(listview_sectoritems);
            SpaceShip.SpaceShipObjectListViewItemsMini(listview_sectorships);

            RefreshShipsLv();
            RefreshSectorItemsLv();

            RefreshElementsEvent = new EventToInvoke(RefreshElementsInEvent);

            // Start child map refresh thread
            sectorNavigationPane1.LocalSectorMapComplex.MapRefreshThread.Start();
            LvRefreshTh = new Thread(new ThreadStart(RefreshElementsTh));
            //this.Disposed
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
                foreach (SpaceShip sps in UserState.getCurrentSector().PresentSpaceShips)
                {
                    tempLv = (ListViewItem)sps.SpaceShipListViewItem.Clone();
                    listview_sectorships.Items.Add(tempLv);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        void RefreshSectorItemsLv()
        {
            ListViewItem tempLv;
            // TODO: Determine if refresh is even needed
            try
            {
                listview_sectoritems.Items.Clear();
                foreach (StarSystem sss in UserState.getCurrentSector().StarSystemsList)
                {
                    tempLv = (ListViewItem)sss.StarSystemListViewItem.Clone();
                    listview_sectoritems.Items.Add(tempLv);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
           
        }

        public void RefreshElementsThStart()
        {
            LvRefreshTh.Start();
        }

        public void RefreshElementsTh()
        {
            try
            {
                while (UserState.ThreadsRunning && !this.Disposing)
                {
                    Thread.Sleep(100);
                    if (this.IsHandleCreated && !this.Disposing)
                        this.Invoke(RefreshElementsEvent);
                }
            }
            catch
            {
            }
        }


        public void RefreshElementsInv()
        {
            this.Invoke(RefreshElementsEvent);
        }

        public void RefreshElementsInEvent()
        {
            RefreshShipsLv();
            RefreshSectorItemsLv();
            //listview_sectorships.Refresh();
            //listview_sectoritems.Refresh();
            //SectorBrowserSidePanel.Refresh();
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
            
        }

        private void bAutopilot_Click(object sender, EventArgs e)
        {
            UserState.PlayerShip.ExecuteWaypoints();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            sectorNavigationPane1.LocalSectorMapComplex.ImageViewMultiplier = trackBar1.Value;
        }

    }
}
