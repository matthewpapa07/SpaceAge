using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace SpaceAge
{
    class StaticGraphics
    {
        private static StaticGraphics myGraphics = new StaticGraphics();
        public Image emptySpace;
        private Image SpaceShipOne;

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

        private StaticGraphics()
        {
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            try
            {
                Stream s = myAssembly.GetManifestResourceStream("SpaceAge.Graphics.Empty.bmp");
                emptySpace = Image.FromStream(s);
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

        public Image GetSpaceShip()
        {
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            Stream s = myAssembly.GetManifestResourceStream("SpaceAge.Graphics.SpaceShip1.gif");
            SpaceShipOne = Image.FromStream(s);
            s.Close();

            return SpaceShipOne;
        }
    }
}
