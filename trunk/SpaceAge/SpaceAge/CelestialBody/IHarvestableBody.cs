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
        ObjectCharactaristics.CommonAtmosphere[] CommonAtmosphere
        {
            get;
        }
        ObjectCharactaristics.RareAtmosphere[] RareAtmosphere
        {
            get;
        }
        ObjectCharactaristics.CommonElements[] CommonElements
        {
            get;
        }
        ObjectCharactaristics.RareElements[] RareElements
        {
            get;
        }
        ObjectCharactaristics.ResourcesStatic[] ResourcesStatic
        {
            get;
        }
        int[] CommonAtmosphereQuantity
        {
            get;
        }
        int[] RareAtmosphereQuantity
        {
            get;
        }
        int[] CommonElementsQuantity
        {
            get;
        }
        int[] RareElementsQuantity
        {
            get;
        }
        int[] ResourcesStaticQuantity
        {
            get;
        }
        string ToString();
    }
}
