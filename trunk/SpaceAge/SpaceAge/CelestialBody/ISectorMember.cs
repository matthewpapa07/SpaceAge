using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SpaceAge
{
    /// <summary>
    /// Use this interface for anything that has a set of coordinates in the sector and can be drawn on the screen
    /// </summary>
    interface ISectorMember
    {
        Sector SectorContainer
        {
            get;
        }

        Point SectorFineGridLocation
        {
            get;
        }

        int Diameter
        {
            get;
        }

        int Mass
        {
            get;
        }

        Bitmap GetImage(int ScaledSize);
    }
}
