﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceAge
{
    class GameDriver
    {
        public static int DAYS_PER_TICK = 1;
        static NumberGenerator numGenerator = NumberGenerator.getInstance();
        public static List<MerchantSpaceShip> AllShips = new List<MerchantSpaceShip>(200);
        public static List<RawMaterialExtractor> AllExtractors = new List<RawMaterialExtractor>(200);
        public static long Time = 0; // Keep track of game time. Could go in userstate too

        public static TimeSpan TimePeriod = TimeSpan.FromDays(1);
        public static DateTime TimeStart = new DateTime(2450, 10, 17);

        public static void InitializeDriver()
        {
            bool Switch = true;
            MerchantSpaceShip mss;
            int MerchantsPerSquare = 0;

            foreach (Sector s in Universe.map)
            {
                // Every 5 squares create a ship
                if (MerchantsPerSquare++ >= 5)
                {
                    if (Switch)
                    {
                        Switch = false;
                        mss = Preconstructs.ConstructedShips.MerchantShip1();
                        s.ShipMoveIn(mss);
                        AllShips.Add(mss);
                    }
                    else
                    {
                        Switch = true;
                        mss = Preconstructs.ConstructedShips.MerchantShip2();
                        s.ShipMoveIn(mss);
                        AllShips.Add(mss);
                    }
                    MerchantsPerSquare = 0;
                }
            }

        }

        public static void PassTurn(int days)
        {
            Time++;
            for (int i = 0; i < days; i++)
            {
                foreach (Sector currentSect in Universe.map)
                {
                    //
                    // TODO: Stuff or each sector
                    //
                }
                foreach (MerchantSpaceShip mss in AllShips)
                {
                    mss.Live();
                }
                Console.WriteLine("Global GDP is now " + MerchantSpaceShip.MoneyChangedHands.ToString());
            }
        }

        // Try and keep this static class clean, but lets have function to interpret time
        public static string TimeToStringLong()
        {
            DateTime futureDate = new DateTime(TimePeriod.Ticks * Time + TimeStart.Ticks);

            // Convert ticks to real time
            return futureDate.ToShortDateString();
        }
    }
}
