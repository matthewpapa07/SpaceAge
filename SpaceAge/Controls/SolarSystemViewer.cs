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
    public partial class SolarSystemViewer : UserControl
    {
        public SolarSystemViewer()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            updateUi();   
        }

        public void updateUi()
        {

        }
    }
}
