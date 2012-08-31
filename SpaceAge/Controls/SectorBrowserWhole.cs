﻿using System;
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
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            UpdateUi();
        }

        public void UpdateUi()
        {
            uiMap1.drawMap();
        }

        private void ui_buttonVisitSector_Click(object sender, EventArgs e)
        {
            SectorBrowser sb = new SectorBrowser();
            //sd.TopLevel = false;
            UserInterface.thisOneInterface.SetMainPanel(sb);
        }
    }
}