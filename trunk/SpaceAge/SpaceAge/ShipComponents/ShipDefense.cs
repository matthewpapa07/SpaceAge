using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceAge.ShipComponents
{
    abstract class ShipDefense : Item
    {
        public int BaseDefenseValue = 0;
        public int RechargeCoefficient = 0;

        private static NumberGenerator numGen = NumberGenerator.getInstance();

        public ShipDefense()
            : base()
        {
            //
            // Nothing to do here for now
            //
        }

        public override string SpecialStat()
        {
            return "Avg DEF: " + BaseDefenseValue;
        }

        public int GetAverageDefense()
        {
            return BaseDefenseValue;
        }
    }
}
