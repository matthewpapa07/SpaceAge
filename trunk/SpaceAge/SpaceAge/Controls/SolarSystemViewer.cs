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
    partial class SolarSystemViewer : UserControl
    {
        private StarSystem ThisStarSystem;

        public SolarSystemViewer()
        {
            InitializeComponent();

            GraphicsLib.ApplyListviewProperties(listView_SystemStars);
            GraphicsLib.ApplyListviewProperties(listView_SystemPlanets);
            GraphicsLib.ApplyListviewProperties(listView_PlanetMoons);
            GraphicsLib.ApplyListviewProperties(listView_Ports);
            GraphicsLib.ApplyListviewProperties(listView_Factories);
            GraphicsLib.ApplyListviewProperties(listView_Extractors);

            // Stars
            listView_SystemStars.Columns.Add("Size");
            listView_SystemStars.Columns.Add("Color");
            listView_SystemStars.Columns.Add("Age");
            listView_SystemStars.Columns.Add("Gravity");

            // Planets
            listView_SystemPlanets.Columns.Add("Name");
            listView_SystemPlanets.Columns.Add("Size");
            listView_SystemPlanets.Columns.Add("Position");
            listView_SystemPlanets.Columns.Add("Inhabited");
            listView_SystemPlanets.Columns.Add("Soverignty");

            // Moons
            listView_PlanetMoons.Columns.Add("Name");
            listView_PlanetMoons.Columns.Add("Settled");
            listView_PlanetMoons.Columns.Add("Size");
        }

        public void SetSolarSystem(StarSystem ss)
        {
            ThisStarSystem = ss;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            updateUi();   
        }

        public void updateUi()
        {

        }

        private void listView_SystemStars_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView_SystemPlanets_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView_PlanetMoons_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView_Ports_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView_Factories_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView_Extractors_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_landAtPort_Click(object sender, EventArgs e)
        {

        }

        private void button_DockAtFactory_Click(object sender, EventArgs e)
        {

        }

        private void button_ManageResources_Click(object sender, EventArgs e)
        {

        }



    }
}
