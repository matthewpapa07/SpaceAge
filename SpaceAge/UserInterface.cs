using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace SpaceAge
{
    public delegate void EventToInvoke();

    public partial class UserInterface : Form
    {
        Controls.UniverseMapBrowser TheMainSectorBrowserWhole;
        public static UserInterface thisOneInterface;
        private Control currentControl;
        private Control previousControl;
        EventToInvoke RefreshElementsEvent = null;
        EventToInvoke UserStateRefreshCallback = null;

        public UserInterface()
        {
            InitializeComponent();
            thisOneInterface = this;

            //
            // Properties for main form
            //
            DoubleBuffered = true;
            ResizeRedraw = true;
            KeyPreview = true;

            TheMainSectorBrowserWhole = new SpaceAge.Controls.UniverseMapBrowser();
            currentControl = TheMainSectorBrowserWhole;
            ui_MAINPANEL.Controls.Add(TheMainSectorBrowserWhole);
            UpdateUi();

            RefreshElementsEvent = new EventToInvoke(RefreshElementsInEvent);
            UserStateRefreshCallback = new EventToInvoke(RefreshElementsInv);
            UserState.OnSectorChange.Add(UserStateRefreshCallback);
            UserState.OnWaypointChange.Add(UserStateRefreshCallback);
        }

        public void UpdateUi()
        {
            ui_CoordinateLabel.Text = UserState.getCurrentSector().SectorGridLocation.ToString();
            ui_Credits.Text = UserState.getPlayerFunds().ToString();
            ui_Time.Text = GameDriver.TimeToStringLong();

            if (UserState.getCurrentWaypoint() != null)
            {
                waypointsectorcoordinates.Text = UserState.getCurrentWaypoint().SectorGridLocation.ToString();
                waypointsectordistance.Text = UserState.getCurrentWaypoint().Distance(UserState.getCurrentSector()).ToString();
            }
            else
            {
                waypointsectorcoordinates.Text = "N/A";
                waypointsectordistance.Text = "N/A";
            }

            userFuelMeter1.UpdateUi();
            TheMainSectorBrowserWhole.Refresh();
            
            //sectorBrowser1.UpdateUi();
            
        }

        private void UserInterface_Load(object sender, EventArgs e)
        {
            ui_buttonBack.Enabled = false;
        }
        private void UserInterface_KeyPress(object sender, KeyPressEventArgs e)
        {
            HumanInterfaceObj TempKeyPress;
            int key = e.KeyChar;

            //Console.WriteLine("Key pressed: " + key);

            if (key > 0)
            {
                if(currentControl is HumanInterfaceObj)
                {
                    TempKeyPress = (HumanInterfaceObj)currentControl;
                    TempKeyPress.UserKeyPress(key);
                }
            }

            UpdateUi();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void userFuelMeter1_Load(object sender, EventArgs e)
        {

        }

        public void SetMainPanel(Control ToShow)
        {
            previousControl = currentControl;
            currentControl = ToShow;
            ToShow.Dock = DockStyle.Fill;
            ToShow.BackColor = Color.Black;
            ui_MAINPANEL.Controls.Clear();
            ui_MAINPANEL.Controls.Add(ToShow);

            if (previousControl != null)
                ui_buttonBack.Enabled = true;
            else
                ui_buttonBack.Enabled = false;
        }

        private void button_sectorBrowser_Click(object sender, EventArgs e)
        {
            SetMainPanel(TheMainSectorBrowserWhole);
        }

        private void ui_buttonBack_Click(object sender, EventArgs e)
        {
            currentControl = null;
            SetMainPanel(previousControl);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // close out all threads
            UserState.ThreadsRunning = false;
            base.OnFormClosing(e);
        }

        public void RefreshElementsInv()
        {
            this.Invoke(RefreshElementsEvent);
        }

        public void RefreshElementsInEvent()
        {
            ui_CoordinateLabel.Text = UserState.getCurrentSector().SectorGridLocation.ToString();
            ui_Credits.Text = UserState.getPlayerFunds().ToString();
            ui_Time.Text = GameDriver.TimeToStringLong();

            if (UserState.getCurrentWaypoint() != null)
            {
                waypointsectorcoordinates.Text = UserState.getCurrentWaypoint().SectorGridLocation.ToString();
                waypointsectordistance.Text = UserState.getCurrentWaypoint().Distance(UserState.getCurrentSector()).ToString();
            }

            userFuelMeter1.UpdateUi();
        }
    }
}
