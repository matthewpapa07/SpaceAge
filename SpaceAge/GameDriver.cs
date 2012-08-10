using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceAge
{
    class GameDriver
    {
        NumberGenerator numGenerator = NumberGenerator.getInstance();

        public GameDriver()
        {
        }
        public void PassTurn()
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
