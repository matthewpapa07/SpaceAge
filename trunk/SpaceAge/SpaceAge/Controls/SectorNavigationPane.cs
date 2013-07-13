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
    partial class SectorNavigationPane : UserControl
    {

        public SectorMapComplex LocalSectorMapComplex;
        public SectorNavigationPane()
        {
            InitializeComponent();
            LocalSectorMapComplex = sectorMapComplex1;
        }

        private void North_Panel_DoubleClick(object sender, EventArgs e)
        {
            UserState.PlayerShip.ExecuteMoveSector(Sector.GateDirections.North);
            sectorMapComplex1.RefreshImages();
        }

        private void South_Panel_DoubleClick(object sender, EventArgs e)
        {
            UserState.PlayerShip.ExecuteMoveSector(Sector.GateDirections.South);
            sectorMapComplex1.RefreshImages();
        }

        private void East_Panel_DoubleClick(object sender, EventArgs e)
        {
            UserState.PlayerShip.ExecuteMoveSector(Sector.GateDirections.East);
            sectorMapComplex1.RefreshImages();
        }

        private void West_Panel_DoubleClick(object sender, EventArgs e)
        {
            UserState.PlayerShip.ExecuteMoveSector(Sector.GateDirections.West);
            sectorMapComplex1.RefreshImages();
        }



    }
}
