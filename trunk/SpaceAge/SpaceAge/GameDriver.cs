using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceAge
{
    class GameDriver
    {
        static NumberGenerator numGenerator = NumberGenerator.getInstance();
        static List<MerchantSpaceShip> AllShips = new List<MerchantSpaceShip>(200);

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
}
