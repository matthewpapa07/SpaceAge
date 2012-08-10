using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceAge.ShipComponents
{
    abstract class ShipWeapon : Item
    {
        public int BaseRateOfFire = 0;
        public int BaseDamage = 0;

        public static NumberGenerator numGen = NumberGenerator.getInstance();

        public ShipWeapon()
            : base()
        {
            //
            // Nothing to do here for now
            //
        }

        public override string SpecialStat()
        {
            return "Avg DPS: " + BaseDamage*BaseRateOfFire;
        }

        //
        // Function for getting the damage for weapons. May be overriden. 
        // TODO: ItemList to look for AMMO
        //
        public int GetDamage()
        {
            return BaseDamage;
        }

        public int GetAverageDamage()
        {
            return BaseDamage;
        }
    }
}
