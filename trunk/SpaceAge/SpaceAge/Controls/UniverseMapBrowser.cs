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
        public UniverseMapBrowser()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            UpdateUi(e.Graphics);
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
            SectorBrowser sb = new SectorBrowser();
            UserInterface.thisOneInterface.SetMainPanel(sb);
        }

        public void UserKeyPress(int Key)
        {
            switch (Key)
            {
                case 'w':       // Up
                    UserState.moveUpUniverseBrowser();
                    break;
                case 's':       // Down
                    UserState.moveDownUniverseBrowser();
                    break;
                case 'a':       // Left
                    UserState.moveLeftUniverseBrowser();
                    break;
                case 'd':       // Right
                    UserState.moveRightUniverseBrowser();
                    break;
                default:
                    break;
            }
        }

    }
}
