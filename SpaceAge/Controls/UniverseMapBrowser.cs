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
    partial class UniverseMapBrowser : UserControl, HumanInterfaceObj
    {
        SectorInfo si = new SectorInfo();
        SectorBrowser sb = new SectorBrowser();
        EventToInvoke RefreshElementsEvent = null;

        public UniverseMapBrowser()
        {
            InitializeComponent();
            DoubleBuffered = true;

            UniverseMap1.RefreshParentUi = new EventToInvoke(RefreshElementsInEvent);
            sb.LvRefreshTh.Start();

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            UpdateUi(e.Graphics);
            RefreshElementsInEvent();
        }

        public void UpdateUi(Graphics g)
        {
            UniverseMap1.drawMap(g);
        }

        private void ui_buttonVisitSector_Click(object sender, EventArgs e)
        {
            //sd.TopLevel = false;
            UserInterface.thisOneInterface.SetMainPanel(si);
        }

        private void bSectorView_Click(object sender, EventArgs e)
        {
            UserInterface.thisOneInterface.SetMainPanel(sb);
        }

        public void UserKeyPress(int Key)
        {
            UniverseMap1.UserKeyPress(Key);
        }

        public void RefreshElementsInv()
        {
            this.Invoke(RefreshElementsEvent);
        }

        public void RefreshElementsInEvent()
        {
            if (UniverseMap1.ClickedSquare != null)
            {
                clickedsectorcoordinates.Text = UniverseMap1.ClickedSquare.SectorGridLocation.ToString();
                clickedsectorname.Text = UniverseMap1.ClickedSquare.ToString();
                clickedsectordistance.Text = UniverseMap1.ClickedSquare.Distance(UserState.getCurrentSector()).ToString();
            }
            else
            {
                clickedsectorcoordinates.Text = "N/A";
                clickedsectorname.Text = "N/A";
                clickedsectordistance.Text = "N/A";
            }
                
        }

        private void bSetWaypoint_Click(object sender, EventArgs e)
        {
            if (UniverseMap1.ClickedSquare != null)
            {
                UserState.setCurrentWaypoint(UniverseMap1.ClickedSquare);
            }
        }

        private void bSetHome_Click(object sender, EventArgs e)
        {
            UniverseMap1.UniverseMapCenter = UserState.getCurrentSector();
            UniverseMap1.Refresh();
        }



    }
}
