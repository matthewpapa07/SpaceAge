using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpaceAge
{
    public partial class SectorDetails : Form
    {
        public SectorDetails()
        {
            InitializeComponent();
            
        }


        public void UpdateUi()
        {

            sectorBrowser1.UpdateUi();
        }
    }
}
