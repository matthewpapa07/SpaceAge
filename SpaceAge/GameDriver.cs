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

        public static DateTime TimeStart = new DateTime(2450, 10, 17);
        public static long GameTimeTicksSinceTimeStart = 0;

        //
        // Management Threads
        //
        public static Thread GameTimeThread = new Thread(new ThreadStart(GameTimeFunc));
        public static Thread TakeCareOfUserThread = new Thread(new ThreadStart(TakeCareOfUserShip));
        public static Thread TakeCareOfAiThread = new Thread(new ThreadStart(TakeCareOfAiShip));
        public static Thread StationLivingThread = new Thread(new ThreadStart(StationLiving));

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

            GameTimeThread.Start();
            TakeCareOfUserThread.Start();
            TakeCareOfAiThread.Start();
            StationLivingThread.Start();
            SpaceShip.UserSpaceShipMovementThread.Start();
        }

        // Game time ticker. Should be just used as a reference to the user, progromatic events will be based on real time
        public static void GameTimeFunc()
        {
            // User service loop, check conditions on an imperceptible interval
            while (UserState.ThreadsRunning)
            {
                GameTimeTicksSinceTimeStart += TimeSpan.FromMinutes(5).Ticks;
                Thread.Sleep(200);
            }
        }


        // Thread that runs in the background to ferry the user's ship around. 
        public static void TakeCareOfUserShip()
        {
            // User service loop, check conditions on an imperceptible interval
            while (UserState.ThreadsRunning)
            {
                if (UserState.PlayerShip.ShipState == SpaceShip.SpaceShipState.MovingSectors && UserState.PlayerShip.CurrentWaypoint != null)
                {
                    if (!UserState.PlayerShip.CurrentShipSector.Equals(UserState.PlayerShip.CurrentWaypoint))
                    {
                        UserState.PlayerShip.ExecuteMoveSector(UserState.PlayerShip.CurrentShipSector.GetNextSectorDirection(UserState.PlayerShip.CurrentWaypoint));
                    }
                }
                Thread.Sleep(100);
            }
        }

        public static void TakeCareOfAiShip()
        {
            // User service loop, check conditions on an imperceptible interval
            while (UserState.ThreadsRunning)
            {
                Thread.Sleep(100);
            }
        }

        public static void StationLiving()
        {
            while (UserState.ThreadsRunning)
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
                for (int i = 0; i < 10; i++)
                {
                    if (UserState.ThreadsRunning)
                        Thread.Sleep(1000);
                    else
                        break;
                }
            }
        }


        // Try and keep this static class clean, but lets have function to interpret time
        public static string TimeToStringLong()
        {
            DateTime futureDate = new DateTime(GameTimeTicksSinceTimeStart + TimeStart.Ticks);

            // Convert ticks to real time
            return futureDate.ToString();
        }
    }
}
