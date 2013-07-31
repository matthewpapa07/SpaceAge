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
        private StarSystem ThisStarSystem = null;
        private Planet CurrentPlanet = null;
        private Star CurrentStar = null;
//        private Moon CurrentMoon = null;

        public bool PlanetsNeedRefresh = true;
        public bool MoonsNeedRefresh = true;
        public bool StarsNeedRefresh = true;

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
            listView_SystemStars.Columns.Add("Name");
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

            // Extractors
            listView_Extractors.Columns.Add("Extractor Type", 400);
        }

        public void SetSolarSystem(StarSystem ss)
        {
            ThisStarSystem = ss;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (ThisStarSystem == null)
                throw new Exception();

            updateUi();   
        }

        public void updateUi()
        {
            if (PlanetsNeedRefresh)
                UpdatePlanets();
            if (MoonsNeedRefresh)
                UpdateMoons();
            if (StarsNeedRefresh)
                UpdateStars();
        }

        public void UpdateStars()
        {
            ListViewItem[] Liststars = new ListViewItem[ThisStarSystem.stars.Length];
            Star s;
            for (int i = 0; i < ThisStarSystem.stars.Length; i++)
            {
                s = ThisStarSystem.stars[i];
                Liststars[i] = new ListViewItem(s.ToString(), i);
                Liststars[i].SubItems.Add(s.StarClassString);
                Liststars[i].SubItems.Add(s.StarColor.ToString());
                Liststars[i].SubItems.Add("TODO");
                Liststars[i].SubItems.Add("TODO");
            }
            listView_SystemStars.Items.Clear();
            listView_SystemStars.Items.AddRange(Liststars);
            StarsNeedRefresh = false;
        }

        public void UpdatePlanets()
        {
            ListViewItem[] ListPlanets = new ListViewItem[ThisStarSystem.planets.Length];
            Planet p;
            for (int i = 0; i < ThisStarSystem.planets.Length; i++)
            {
                p = ThisStarSystem.planets[i];
                ListPlanets[i] = new ListViewItem(p.ToString(), i);
                ListPlanets[i].SubItems.Add(Planet.PlanetConstant.PlanetSizeString[(int)p.PlanetSize]);
                ListPlanets[i].SubItems.Add(Planet.PlanetConstant.PositionString[(int)p.PlanetPosition]);
                if (p.IsInhabited)
                    ListPlanets[i].SubItems.Add("Yes");
                else
                    ListPlanets[i].SubItems.Add("No");
                ListPlanets[i].SubItems.Add("TODO");
            }
            listView_SystemPlanets.Items.Clear();
            listView_SystemPlanets.Items.AddRange(ListPlanets);
            PlanetsNeedRefresh = false;
        }

        public void RefreshResourceExtractors()
        {
            if (CurrentPlanet == null)
            {
                listView_Extractors.Items.Clear();
                return;
            }
            IInteractableBody target = CurrentPlanet;
            // TODO: Add moon checks when they are implemented

            RawMaterialExtractor[] extractors = target.Extractors;
            if (extractors.Length == 0)
            {
                listView_Extractors.Items.Clear();
                return;
            }
            ListViewItem[] listExtractors = new ListViewItem[extractors.Length];
            for (int i = 0; i < extractors.Length; i++)
            {
                listExtractors[i] = new ListViewItem(extractors[i].ToString());
            }
            listView_Extractors.Items.Clear();
            listView_Extractors.Items.AddRange(listExtractors);
        }

        public void UpdateMoons()
        {
            MoonsNeedRefresh = false; 
        }

        private void listView_SystemStars_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_SystemStars.SelectedIndices.Count >= 1)
            {
                CurrentStar = ThisStarSystem.stars[listView_SystemStars.SelectedItems[0].ImageIndex];
            }
            else
            {
                CurrentStar = null;
            }
        }

        private void listView_SystemPlanets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_SystemPlanets.SelectedIndices.Count >= 1)
            {
                CurrentPlanet = ThisStarSystem.planets[listView_SystemPlanets.SelectedItems[0].ImageIndex];
            }
            else
            {
                CurrentPlanet = null;
            }
            RefreshResourceExtractors();
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
