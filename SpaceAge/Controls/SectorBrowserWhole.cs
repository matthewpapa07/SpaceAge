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
    partial class SectorBrowserWhole : UserControl
    {
        public SectorBrowserWhole()
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
            uiMap1.drawMap(g);
        }
        public void HouseKeeping()
        {
            uiMap1.Refresh();
        }

        private void ui_buttonVisitSector_Click(object sender, EventArgs e)
        {
            SectorBrowser sb = new SectorBrowser();
            //sd.TopLevel = false;
            UserInterface.thisOneInterface.SetMainPanel(sb);
        }
    }
}
