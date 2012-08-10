using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpaceAge
{
    partial class SpaceshipStatus : UserControl
    {
        public SpaceshipStatus()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            UpdateUi();
        }

        public void UpdateUi()
        {
            ui_SpaceConsumed.Text = "Cargo bay: " + uiInventory1.associatedList.ConsumedVolume + "/" + uiInventory1.associatedList.MaxVolume + " m3";
        }
    }
}
