using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;
using SpaceAge.Controls;

namespace SpaceAge
{
    public delegate void EventToInvoke();

    public partial class UserInterface : Form
    {
        // Top level controls only (the ones that fit in the main pane)
        UniverseMapBrowser ub = new UniverseMapBrowser();
        SectorInfo si = new SectorInfo();
        SectorBrowser sb = new SectorBrowser();

        // Track user browsing so we can have a back button and context info
        private Control currentControl;
        private Control previousControl;

        public static UserInterface thisOneInterface;
        EventToInvoke RefreshElementsEvent = null;
        EventToInvoke UserStateRefreshCallback = null;
        EventToInvoke PeriodicRefreshMenusEvent = null;

        Thread PeriodicRefreshMenusThread;

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

            RefreshElementsEvent = new EventToInvoke(RefreshElementsInEvent);
            UserStateRefreshCallback = new EventToInvoke(RefreshElementsInv);
            PeriodicRefreshMenusEvent = new EventToInvoke(PeriodicRefreshMenus);

            PeriodicRefreshMenusThread = new Thread(new ThreadStart(RefreshMenus));
            //PeriodicRefreshMenusThread.Start();

            UserState.OnSectorChange.Add(UserStateRefreshCallback);
            UserState.OnWaypointChange.Add(UserStateRefreshCallback);

            // Background threads for top level menus
            sb.LvRefreshTh.Start();
            
            // Start off in the sector browser
            SetMainPanel(sb);

            // Invoke a refresh to make sure everything is fresh from the start
            UpdateUi();
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
            ub.Refresh();
            
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

        public void RefreshMenus()
        {
            // User service loop, check conditions on an imperceptible interval
            while (UserState.ThreadsRunning)
            {
                this.Invoke(PeriodicRefreshMenusEvent);
                Thread.Sleep(100);
            }

        }
        public void PeriodicRefreshMenus()
        {
            RefreshElementsInEvent();
        }

        private void ui_bUniverseBrowser_Click(object sender, EventArgs e)
        {
            SetMainPanel(ub);
        }

        private void ui_bSectorBrowser_Click(object sender, EventArgs e)
        {
            SetMainPanel(sb);
        }
    }
}
