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
    public partial class UserInterface : Form
    {
        Controls.SectorBrowserWhole TheMainSectorBrowserWhole;
        public static UserInterface thisOneInterface;
        private Control currentControl;

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

            TheMainSectorBrowserWhole = new SpaceAge.Controls.SectorBrowserWhole();
            currentControl = TheMainSectorBrowserWhole;
            ui_MAINPANEL.Controls.Add(TheMainSectorBrowserWhole);
            UpdateUi();
            //BackColor = Color.White;
        }

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    int height = ClientRectangle.Height / 3;
        //    int width = ClientRectangle.Width;
        //    int y = 0;

        //    Rectangle hatchArea = new Rectangle(0, y, width, height);
        //    y += height;
        //    Rectangle gradientArea = new Rectangle(0, y, width, height);
        //    y += height;
        //    Rectangle pathArea = new Rectangle(0, y, width, height);

        //    using (HatchBrush hatchBrush = new HatchBrush(
        //    HatchStyle.Cross, Color.Red, Color.Blue))
        //    {
        //        e.Graphics.FillRectangle(hatchBrush, hatchArea);
        //    }

        //    using (LinearGradientBrush gradientBrush = new LinearGradientBrush(
        //    gradientArea, Color.Green, Color.White,
        //    LinearGradientMode.ForwardDiagonal))
        //    {
        //        e.Graphics.FillRectangle(gradientBrush, gradientArea);
        //    }

        //    using (GraphicsPath path = new GraphicsPath())
        //    {
        //        path.AddBezier(0, y, width, y, width, y + height, 0, y + height);

        //        using (PathGradientBrush pathBrush = new PathGradientBrush(path))
        //        {
        //            pathBrush.CenterColor = Color.HotPink;
        //            pathBrush.CenterPoint = new PointF(width / 4, y + height / 2);
        //            pathBrush.SurroundColors = new Color[] {
        //                                                    Color.Yellow,
        //                                                    Color.Lavender,
        //                                                    Color.Ivory,
        //                                                    Color.Indigo
        //                                                    };

        //            e.Graphics.FillRectangle(pathBrush, pathArea);
        //        }
        //    }
        //}

        public void UpdateUi()
        {
            Sector currentSector = UserState.getCurrentSector();
            ui_CoordinateLabel.Text = UserState.playerLocation.ToString();
            ui_Credits.Text = UserState.getPlayerFunds().ToString();
            ui_Time.Text = GameDriver.TimeToStringLong();

            userFuelMeter1.UpdateUi();
            //sectorBrowser1.UpdateUi();
            
        }

        private void UserInterface_Load(object sender, EventArgs e)
        {

        }
        private void UserInterface_KeyPress(object sender, KeyPressEventArgs e)
        {
            int key = e.KeyChar;

            if (key > 0)
            {
                //Console.WriteLine("Key pressed: " + key);
                switch (key)
                {
                    case 'w':       // Up
                        UserState.moveUp();
                        break;
                    case 's':       // Down
                        UserState.moveDown();
                        break;
                    case 'a':       // Left
                        UserState.moveLeft();
                        break;
                    case 'd':       // Right
                        UserState.moveRight();
                        break;
                }
                //uiMap1.drawMap();
                TheMainSectorBrowserWhole.UpdateUi();
                UpdateUi();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void userFuelMeter1_Load(object sender, EventArgs e)
        {

        }

        public void SetMainPanel(Control ToShow)
        {
            currentControl = ToShow;
            //ToShow.Dock = DockStyle.Fill;
            ui_MAINPANEL.Controls.Clear();
            ui_MAINPANEL.Controls.Add(ToShow);
            //ToShow.Show();
        }

        private void button_sectorBrowser_Click(object sender, EventArgs e)
        {
            SetMainPanel(TheMainSectorBrowserWhole);
        }

        private void ui_buttonBack_Click(object sender, EventArgs e)
        {

        }

    }
}
