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
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawStuff(e.Graphics);

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
                    default:
                        break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sectorMapComplex1.StartMovement();
        }
    }
}
