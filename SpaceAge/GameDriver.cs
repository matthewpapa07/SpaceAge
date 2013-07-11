using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

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

        //
        // Management Threads
        //
        public static Thread TakeCareOfUserThread = new Thread(new ThreadStart(TakeCareOfUserShip));

        public static void InitializeDriver()
        {
            bool Switch = true;
            MerchantSpaceShip mss;
            int MerchantsPerSquare = 0;

            foreach (Sector s in Universe.map)
            {
                // Every 5 squares create a merchant ship
                if (MerchantsPerSquare++ >= 1)
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

                foreach(RawMaterialExtractor rme in RawMaterialExtractor.PopulateSectorWithExtractors(s))
                    AllExtractors.Add(rme);

            }

            TakeCareOfUserThread.Start();
        }

        // Thread that runs in the background to ferry the user's ship around. 
        public static void TakeCareOfUserShip()
        {
            // User service loop, check conditions on an imperceptible interval
            while (UserState.ThreadsRunning)
            {
                if (UserState.ExecuteWaypoint)
                {
                    if (!UserState.PlayerShip.CurrentShipSector.Equals(UserState.PlayerShip.CurrentWaypoint))
                    {

                    }
                    else
                    {
                        // End ExecuteWaypoint because destination has been reached
                        UserState.ExecuteWaypoint = false;
                    }
                }
                Thread.Sleep(100);
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
                foreach (RawMaterialExtractor r in AllExtractors)
                {
                    r.Live();
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
