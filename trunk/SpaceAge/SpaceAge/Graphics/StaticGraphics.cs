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
        public Image fewSystems;
        public Image manySystems;
        private static Image spaceShipOne;

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
                s = myAssembly.GetManifestResourceStream("SpaceAge.Graphics.FewSystems.bmp");
                fewSystems = Image.FromStream(s);
                s.Close();
                s = myAssembly.GetManifestResourceStream("SpaceAge.Graphics.ManySystems.bmp");
                manySystems = Image.FromStream(s);
                s.Close();
                s = myAssembly.GetManifestResourceStream("SpaceAge.Graphics.SpaceShip1.gif");
                spaceShipOne = Image.FromStream(s);
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

        public static Image getSpaceShip()
        {
            switch (UserState.progStateLast)
            {
                case (int)UserState.lastState.Up:
                    switch (UserState.progState)
                    {
                        case (int)UserState.lastState.Up:
                            break;
                        case (int)UserState.lastState.Left:
                            spaceShipOne.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            break;
                        case (int)UserState.lastState.Right:
                            spaceShipOne.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            break;
                        case (int)UserState.lastState.Down:
                            spaceShipOne.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            break;
                        default:
                            break;
                    }
                    break;
                case (int)UserState.lastState.Left:
                    switch (UserState.progState)
                    {
                        case (int)UserState.lastState.Up:
                            spaceShipOne.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            break;
                        case (int)UserState.lastState.Left:
                            break;
                        case (int)UserState.lastState.Right:
                            spaceShipOne.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            break;
                        case (int)UserState.lastState.Down:
                            spaceShipOne.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            break;
                        default:
                            break;
                    }
                    break;
                case (int)UserState.lastState.Down:
                    switch (UserState.progState)
                    {
                        case (int)UserState.lastState.Up:
                            spaceShipOne.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            break;
                        case (int)UserState.lastState.Left:
                            spaceShipOne.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            break;
                        case (int)UserState.lastState.Right:
                            spaceShipOne.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            break;
                        case (int)UserState.lastState.Down:
                            break;
                        default:
                            break;
                    }
                    break;
                case (int)UserState.lastState.Right:
                    switch (UserState.progState)
                    {
                        case (int)UserState.lastState.Up:
                            spaceShipOne.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            break;
                        case (int)UserState.lastState.Left:
                            spaceShipOne.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            break;
                        case (int)UserState.lastState.Right:
                            break;
                        case (int)UserState.lastState.Down:
                            spaceShipOne.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            return spaceShipOne;
        }
    }
}
