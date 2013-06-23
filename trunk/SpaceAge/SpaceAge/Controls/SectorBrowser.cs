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
            Sector.SetSectorObjectListViewItemsMini(listview_sectoritems);
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawStuff(e.Graphics);
            sectorMapComplex1.MapRefreshThread.Start();
            sectorMapComplex1.ShipVelocityThread.Start();
            sectorMapComplex1.KeyboardCheckThread.Start();

        }

        public void DrawStuff(Graphics GraphicsToUse)
        {

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
    }
}
