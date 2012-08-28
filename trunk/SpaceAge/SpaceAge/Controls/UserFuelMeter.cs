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
    public partial class UserFuelMeter : UserControl
    {
        SolidBrush aquaBrush = new SolidBrush(System.Drawing.Color.Aquamarine);
        SolidBrush blackBrush = new SolidBrush(System.Drawing.Color.Gray);
        Rectangle backRect;
        Rectangle meterRect;
        public int origWidth = 0;

        public UserFuelMeter()
        {
            InitializeComponent();
        }

        public void UpdateUi()
        {
            double fuelPecentage = (double)UserState.getFuelLevel() / (double)UserState.USER_MAX_FUEL_AMOUNT;
            double sizeTranslation = (double)origWidth * fuelPecentage;

            meterRect.Width = (int)sizeTranslation;

            using (Graphics g = this.CreateGraphics())
            {
                g.FillRectangle(blackBrush, backRect);
                g.FillRectangle(aquaBrush, meterRect);
            }
        }

        private void UserFuelMeter_Load(object sender, EventArgs e)
        {
            backRect = new Rectangle(0, 0, Width, Height);
            meterRect = new Rectangle(0, 2, Width, Height - 4);

            origWidth = Width;
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);

            using(Graphics g = this.CreateGraphics())
            {
                g.FillRectangle(blackBrush, backRect);
                g.FillRectangle(aquaBrush, meterRect);
            }
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
    }
}
