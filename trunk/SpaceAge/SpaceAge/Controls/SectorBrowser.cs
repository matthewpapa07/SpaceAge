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
        List<SpaceShip> CurrentDisplayedShips = new List<SpaceShip>();
        List<StarSystem> CurrentDispalyedStarSys = new List<StarSystem>();
        SpaceShip CurrentTarget;

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
            List<SpaceShip> NewShipList = UserState.getCurrentSector().PresentSpaceShips;
            
            List<SpaceShip> NewShips = new List<SpaceShip>();
            List<SpaceShip> RemovedShips = new List<SpaceShip>();

            {
                // Add new ships if they exist
                foreach(SpaceShip ss in NewShipList)
                {
                    if(CurrentDisplayedShips.Contains(ss))
                    {
                        // Do nothing
                    }
                    else
                    {
                        NewShips.Add(ss);
                    }
                }
                // Remove old ones if they are no logner in range
                foreach(SpaceShip ss in CurrentDisplayedShips)
                {
                    if (NewShipList.Contains(ss))
                    {
                        // Do nothing
                    }
                    else
                    {
                        RemovedShips.Add(ss);
                    }
                }
            }

            try
            {
                //listview_sectorships.Items.Clear();
                foreach (SpaceShip ss in NewShips)
                {
                    listview_sectorships.Items.Add(ss.SpaceShipListViewItem);
                    CurrentDisplayedShips.Add(ss);
                }
                foreach (SpaceShip ss in RemovedShips)
                {
                    listview_sectorships.Items.Remove(ss.SpaceShipListViewItem);
                    CurrentDisplayedShips.Remove(ss);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        void RefreshSectorItemsLv()
        {
            List<StarSystem> NewStarSysList = new List<StarSystem>(UserState.getCurrentSector().StarSystemsList);

            List<StarSystem> NewStarSystem = new List<StarSystem>();
            List<StarSystem> RemovedStarSystem = new List<StarSystem>();

            {
                // Add new ships if they exist
                foreach (StarSystem ss in NewStarSysList)
                {
                    if (CurrentDispalyedStarSys.Contains(ss))
                    {
                        // Do nothing
                    }
                    else
                    {
                        NewStarSystem.Add(ss);
                    }
                }
                // Remove old ones if they are no logner in range
                foreach (StarSystem ss in CurrentDispalyedStarSys)
                {
                    if (NewStarSysList.Contains(ss))
                    {
                        // Do nothing
                    }
                    else
                    {
                        RemovedStarSystem.Add(ss);
                    }
                }
            }

            try
            {
                //listview_sectoritems.Items.Clear();
                foreach (StarSystem ss in NewStarSystem)
                {
                    listview_sectoritems.Items.Add(ss.StarSystemListViewItem);
                    CurrentDispalyedStarSys.Add(ss);
                }
                foreach (StarSystem ss in RemovedStarSystem)
                {
                    listview_sectoritems.Items.Remove(ss.StarSystemListViewItem);
                    CurrentDispalyedStarSys.Remove(ss);
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

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            sectorNavigationPane1.LocalSectorMapComplex.ImageViewMultiplier = trackBar1.Value;
        }

        //
        // Select new taget
        //
        private void listview_sectorships_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem lvi;

            if (listview_sectorships.SelectedIndices.Count >= 1)
            {
                //
                // Keep it simple and max 1 target for now
                //
                lvi = listview_sectorships.Items[listview_sectorships.SelectedIndices[0]];

                foreach (SpaceShip ss in CurrentDisplayedShips)
                {
                    if (lvi.Equals(ss.SpaceShipListViewItem))
                    {
                        if (CurrentTarget != null)
                            CurrentTarget.IsTargeted = false;
                        CurrentTarget = ss;
                        CurrentTarget.IsTargeted = true;
                    }
                }
            }
        }

        // Simple follow code for now. Need to add code to constantly update at some point
        private void bFollow_Click(object sender, EventArgs e)
        {
            if (CurrentTarget != null)
            {
                // Only folow ships in the current sector for now
                if(CurrentTarget.CurrentShipSector.Equals(UserState.getCurrentSector()))
                    UserState.PlayerShip.SetLocalDestinationPoint(CurrentTarget.SectorFineGridLocation);
            }
        }

    }
}
