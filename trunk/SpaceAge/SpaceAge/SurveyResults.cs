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
    partial class SurveyResults : Form
    {
        public SurveyResults()
        {
            InitializeComponent();
        }

        public void SetSurveyObject(Object o)
        {
            if(o is Planet)
                planetViewer1.SetPlanet(o as Planet);
        }
    }
}
