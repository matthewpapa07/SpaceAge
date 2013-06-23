﻿using System;
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
    public partial class UserInterface : Form
    {
        Controls.UniverseMapBrowser TheMainSectorBrowserWhole;
        public static UserInterface thisOneInterface;
        private Control currentControl;
        private Control previousControl;

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
        }

        public void UpdateUi()
        {
            Sector currentSector = UserState.getCurrentSector();
            ui_CoordinateLabel.Text = UserState.UniverseSectorGridLocation.ToString();
            ui_Credits.Text = UserState.getPlayerFunds().ToString();
            ui_Time.Text = GameDriver.TimeToStringLong();

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
            //ToShow.Show();
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

    }
}
