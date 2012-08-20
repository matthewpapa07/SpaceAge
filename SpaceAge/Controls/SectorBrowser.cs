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
    partial class SectorBrowser : UserControl
    {
        ListViewItem[] SectorContentsListview;
        ListViewItem[] SystemContentsListView;
        SectorDetails  parentForm;
        StarSystem[] SectorSystems;

        //
        // These references are for the systemlist
        //
        StarSystem currentlySelectedSystem = null;
        Object [] allObjects = null;
        Object currentObject = null;

        public SectorBrowser()
        {
            InitializeComponent();

            DoubleBuffered = true;
            ResizeRedraw = true;

            //
            // Properties for system listview
            //
            ui_SectorList.View = View.Details;
            ui_SectorList.FullRowSelect = true;
            ui_SectorList.GridLines = true;
            ui_SectorList.MultiSelect = false;

            ui_SystemList.View = View.Details;
            ui_SystemList.FullRowSelect = true;
            ui_SystemList.GridLines = true;
            ui_SystemList.MultiSelect = false;

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            UpdateUi();
        }

        public void UpdateUi()
        {
            UpdateStarSystemList();
            UpdateSolarSystemList();

        }

        public void setParent(SectorDetails s)
        {
            parentForm = s;
        }

        private void ui_SurveyObject_Click(object sender, EventArgs e)
        {
            if (currentObject == null)
                return;
            if (!(currentObject is Planet))
                return;

            Planet p = (Planet)currentObject;
            SurveyResults surveyResults = new SurveyResults();
            surveyResults.SetSurveyObject(p);
            surveyResults.Show();
        }

        public void UpdateStarSystemList()
        {
            ui_SectorList.Items.Clear();
            ui_SectorList.Columns.Clear();
            //
            // Add columns
            //
            ui_SectorList.Columns.Add("Name", 80);
            ui_SectorList.Columns.Add("Stars");
            ui_SectorList.Columns.Add("Planets");

            Sector currentSector = UserState.getCurrentSector();

            if (currentSector == null)
                return;

            SectorSystems = currentSector.StarSystemsList;
            SectorContentsListview = new ListViewItem[SectorSystems.Length];

            for (int i = 0; i < SectorSystems.Length; i++)
            {
                SectorContentsListview[i] = new ListViewItem(SectorSystems[i].getName(), i);
                SectorContentsListview[i].SubItems.Add(SectorSystems[i].stars.Length.ToString());
                SectorContentsListview[i].SubItems.Add(SectorSystems[i].planets.Length.ToString());
                SectorContentsListview[i].SubItems.Add("C");
            }

            ui_SectorList.Items.AddRange(SectorContentsListview);
        }

        public void UpdateSolarSystemList()
        {
            if (ui_SectorList.SelectedIndices.Count >= 1)
            {
                ui_SystemList.Items.Clear();
                ui_SystemList.Columns.Clear();

                ui_SystemList.Columns.Add("Object Type", 80);
                ui_SystemList.Columns.Add("Size");
                ui_SystemList.Columns.Add("Coordinates");
                ui_SystemList.Columns.Add("Inhabited");

                int indexSelected = ui_SectorList.SelectedIndices[0];
                currentlySelectedSystem = SectorSystems[indexSelected];

                int numStars = currentlySelectedSystem.stars.Length;
                int numPlanets = currentlySelectedSystem.planets.Length;
                allObjects = new Object[numStars + numPlanets];

                SystemContentsListView = new ListViewItem[numStars + numPlanets];
                //
                // Do this for every type of object (more to come later, like stations, black holes, complexes and artifacts)
                //
                Star s;
                for (int i = 0; i < numStars; i++)
                {
                    s = currentlySelectedSystem.stars[i];
                    SystemContentsListView[i] = new ListViewItem("Star " + s.ToString(), i);
                    SystemContentsListView[i].SubItems.Add(ObjectCharactaristics.StarSizeString[(int)s.starSize]);
                    SystemContentsListView[i].SubItems.Add(ObjectCharactaristics.StarTypeString[(int)s.starType] + " " + s.LocalStarNumber.ToString());
                    SystemContentsListView[i].SubItems.Add("N/A");

                    allObjects[i] = currentlySelectedSystem.stars[i];
                }
                Planet p;
                for (int i = 0; i < numPlanets; i++)
                {
                    p = currentlySelectedSystem.planets[i];
                    SystemContentsListView[i + numStars] = new ListViewItem("Planet " + p.ToString(), i + numStars);
                    SystemContentsListView[i + numStars].SubItems.Add(ObjectCharactaristics.PlanetSizeString[(int)p.planetSize]);
                    SystemContentsListView[i + numStars].SubItems.Add(ObjectCharactaristics.PositionString[(int)p.planetPosition]);
                    SystemContentsListView[i + numStars].SubItems.Add(p.IsInhabited.ToString());
                    allObjects[i + numStars] = currentlySelectedSystem.planets[i];
                }

                ui_SystemList.Items.AddRange(SystemContentsListView);
            }
        }

        private void ui_SectorList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSolarSystemList();
        }

        private void ui_SystemList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_SystemList.SelectedIndices.Count >= 1)
            {
                int selectedIndex = ui_SystemList.SelectedIndices[0];
                currentObject = allObjects[selectedIndex];
                if (currentObject is Planet)
                {
                    if ((currentObject as Planet).IsInhabited)
                    {
                        ui_Interaction.Enabled = true;
                    }
                    else
                        ui_Interaction.Enabled = false;

                    ui_SurveyObject.Enabled = true;
                }
                else
                {
                    ui_Interaction.Enabled = false;
                    ui_SurveyObject.Enabled = false;
                }
                //
                // Add checks for other types to enable other buttons later
                //
            }
        }

        private void ui_Interaction_Click(object sender, EventArgs e)
        {
            if (currentObject == null)
                return;
            if (!(currentObject is Planet))
                return;
            
            Planet p = (Planet)currentObject;

            InteractionCenterUi interactUi = new InteractionCenterUi();
            interactUi.SetInteractionCenter(p.planetInteractionCenter);
            interactUi.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
