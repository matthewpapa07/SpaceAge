﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SpaceAge
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    //UserInterface ui = new UserInterface();
        //    Thread.Sleep(6000);
        //}

        static void Main()
        {
            Application.EnableVisualStyles();

            Universe.GenerateUniverse(Constants.UNIVERSE_WIDTH, Constants.UNIVERSE_HEIGHT);
            Universe.RunSupplementalGeneration();
            GameDriver.InitializeDriver();
            Application.Run(new UserInterface());
        }
    }
}
