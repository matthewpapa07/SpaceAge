using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceAge
{
    class GameDriver
    {
        static NumberGenerator numGenerator = NumberGenerator.getInstance();

        public static void InitializeDriver()
        {
            
            // Generate a few identical merchant ships

        }

        public static void PassTurn(int days)
        {
            foreach (Sector currentSect in Universe.map)
            {
                //
                // TODO: Stuff or each sector
                //
            }
        }
    }
}
