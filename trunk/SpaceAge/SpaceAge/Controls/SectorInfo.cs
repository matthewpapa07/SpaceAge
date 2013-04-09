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
    partial class SectorInfo : UserControl
    {
        ListViewItem[] SectorContentsListview;
        ListViewItem[] SystemContentsListView;
        StarSystem[] SectorSystems;

        //
        // These references are for the systemlist
        //
        StarSystem currentlySelectedSystem = null;
        Object [] allObjects = null;
        Object currentObject = null;

        public SectorInfo()
        {
            InitializeComponent();

            DoubleBuffered = true;
            ResizeRedraw = true;

            //
            // Properties for system listview
            //
            GraphicsLib.ApplyListviewProperties(ui_SectorList);
            GraphicsLib.ApplyListviewProperties(ui_SystemList);

            SpaceAge.Controls.SectorMapSimple uiM = new SpaceAge.Controls.SectorMapSimple(UserState.getCurrentSector());
            uiM.Dock = DockStyle.Fill;
            ui_SectorMapPanel.Controls.Add(uiM);

            ui_SystemList.Columns.Clear();

            ui_SystemList.Columns.Add("Object Type", 80);
            ui_SystemList.Columns.Add("Size");
            ui_SystemList.Columns.Add("Coordinates");
            ui_SystemList.Columns.Add("Inhabited");

            ui_SectorList.Columns.Clear();
            //
            // Add columns
            //
            ui_SectorList.Columns.Add("Name", 80);
            ui_SectorList.Columns.Add("Stars");
            ui_SectorList.Columns.Add("Planets");
            ui_SectorList.Columns.Add("Soverignty");

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

        private void ui_SurveyObject_Click(object sender, EventArgs e)
        {
            if (currentObject == null)
                return;
            if (!(currentObject is Planet))
                return;

            Planet p = currentObject as Planet;

            SpaceAge.Controls.PlanetViewer Pview = new SpaceAge.Controls.PlanetViewer();
            Pview.SetPlanet(p);
            UserInterface.thisOneInterface.SetMainPanel(Pview);
        }

        public void UpdateStarSystemList()
        {
            ui_SectorList.Items.Clear();

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
                    SystemContentsListView[i].SubItems.Add(s.StarClassString);
                    SystemContentsListView[i].SubItems.Add(s.StarColor.ToString() + " " + s.UniqueStarNumber.ToString());
                    SystemContentsListView[i].SubItems.Add("N/A");

                    allObjects[i] = currentlySelectedSystem.stars[i];
                }
                Planet p;
                for (int i = 0; i < numPlanets; i++)
                {
                    p = currentlySelectedSystem.planets[i];
                    SystemContentsListView[i + numStars] = new ListViewItem("Planet " + p.ToString(), i + numStars);
                    SystemContentsListView[i + numStars].SubItems.Add(ObjectCharactaristics.PlanetSizeString[(int)p.PlanetSize]);
                    SystemContentsListView[i + numStars].SubItems.Add(ObjectCharactaristics.PositionString[(int)p.PlanetPosition]);
                    SystemContentsListView[i + numStars].SubItems.Add(p.IsInhabited.ToString());
                    allObjects[i + numStars] = currentlySelectedSystem.planets[i];
                }

                ui_SystemList.Items.AddRange(SystemContentsListView);
            }
            else
                currentlySelectedSystem = null;
        }

        private void ui_SectorList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSolarSystemList();
            if(currentlySelectedSystem != null)
                button_Approach.Enabled = true;
            else
                button_Approach.Enabled = false;
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

                    ui_SurveyObject.Enabled = true; // Always allow planet survey
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

            SpaceAge.Controls.InteractionCenterUi interactUi = SpaceAge.Controls.InteractionCenterUi.GetInteractionCenterUi(p);
            UserInterface.thisOneInterface.SetMainPanel(interactUi);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_Approach_Click(object sender, EventArgs e)
        {
            if (currentlySelectedSystem != null)
            {
                SpaceAge.Controls.SolarSystemViewer ssv = new SpaceAge.Controls.SolarSystemViewer();
                ssv.SetSolarSystem(currentlySelectedSystem);
                UserInterface.thisOneInterface.SetMainPanel(ssv);
            }
        }
    }
}
