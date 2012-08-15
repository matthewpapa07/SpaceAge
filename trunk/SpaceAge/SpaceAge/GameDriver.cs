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
            // For now generate a ship in each sector of alternating types
            foreach(Sector s in Universe.map)
            {
                if (Switch)
                {
                    mss = Preconstructs.ConstructedShips.MerchantShip1();
                    s.ShipMoveIn(mss);
                    AllShips.Add(mss);
                    Switch = false;
                }
                else
                {
                    mss = Preconstructs.ConstructedShips.MerchantShip2();
                    s.ShipMoveIn(mss);
                    AllShips.Add(mss);
                    Switch = true;
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
        }
    }
}
