using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SpaceAge
{
    class StaticGraphics
    {
        private static StaticGraphics myGraphics = new StaticGraphics();
        public Image emptySpace;
        //public Bitmap SectorBackground = new Bitmap(SpaceAge.Properties.Resources.Background1);

        //
        // Brushes that may be used { "White", "Brown", "Orange", "Yellow", "Blue", "Red" };
        //
        public SolidBrush whiteBrush = new SolidBrush(System.Drawing.Color.White);
        public SolidBrush brownBrush = new SolidBrush(System.Drawing.Color.Brown);
        public SolidBrush yellowBrush = new SolidBrush(System.Drawing.Color.Yellow);
        public SolidBrush orangeBrush = new SolidBrush(System.Drawing.Color.Orange);
        public SolidBrush blueBrush = new SolidBrush(System.Drawing.Color.Blue);
        public SolidBrush redBrush = new SolidBrush(System.Drawing.Color.Red);
        public SolidBrush blackBrush = new SolidBrush(System.Drawing.Color.Black);
        public SolidBrush grayBrush = new SolidBrush(System.Drawing.Color.Gray);
        public SolidBrush greenBrush = new SolidBrush(System.Drawing.Color.Green);
        public SolidBrush azureBrush = new SolidBrush(System.Drawing.Color.Azure);
        public SolidBrush pinkBrush = new SolidBrush(System.Drawing.Color.Pink);
        public SolidBrush purpleBrush = new SolidBrush(System.Drawing.Color.Purple);
        public SolidBrush salmonBrush = new SolidBrush(System.Drawing.Color.Salmon);
        public SolidBrush tomatoBrush = new SolidBrush(System.Drawing.Color.Tomato);
        public SolidBrush violetBrush = new SolidBrush(System.Drawing.Color.Violet);
        public SolidBrush lgrayBrush = new SolidBrush(System.Drawing.Color.LightGray);

        //
        // Fancy brushes
        //
        public HatchBrush UniverseBorderBrush = new HatchBrush(HatchStyle.Cross, System.Drawing.Color.Red, System.Drawing.Color.Blue);
        //public HatchBrush SectorBorderBrush = new HatchBrush(HatchStyle.Percent20, Color.Red, Color.Transparent);
        public TextureBrush SectorBorderBrush = new TextureBrush(new Bitmap(SpaceAge.Properties.Resources._678124main_hubble_sparkles_1600_1600_1200));
		public TextureBrush spaceBrush;
        public Pen blackPen = new Pen(Color.Black, 2);
        public Pen greenPen = new Pen(Color.LightYellow, 2);
        public Pen whitePen = new Pen(Color.White, 2);
        public Pen redPen = new Pen(Color.Red, 2);
        public Pen bluePen = new Pen(Color.Blue, 2);

        public Pen backgroundStarPen = new Pen(Color.White, 1);


        private StaticGraphics()
        {
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            try
            {
                Stream s = myAssembly.GetManifestResourceStream("SpaceAge.Graphics.Empty.bmp");
                emptySpace = Image.FromStream(s);
                spaceBrush = new TextureBrush(emptySpace);
                s.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static StaticGraphics getStaticGraphics()
        {
            return myGraphics;
        }


        public int ScaleCoordinate(int maxOriginalCoor, int actualOriginalCoor, int maxDestCoor)
        {
            //
            // Cast everything to double for the greatest accuracy and rounding
            //
            double MaxOriginCoorD = maxOriginalCoor;
            double ActualOriginCoorD = actualOriginalCoor;
            double MaxDestCoorD = maxDestCoor;

            double result = (ActualOriginCoorD / MaxOriginCoorD) * MaxDestCoorD;

            return (int)result;
        }
    }
}
