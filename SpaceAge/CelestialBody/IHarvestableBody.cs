using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceAge
{
    interface IHarvestableBody
    {
        object DirectParent
        {
            get;
        }
        Commodity[] Resources
        {
            get;
        }
        int[] ResourcesProductivity
        {
            get;
        }
        string ToString();
    }
}
