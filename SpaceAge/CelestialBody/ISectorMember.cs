using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceAge
{
    interface ISectorMember
    {
        Sector MemberSector
        {
            get;
        }
    }
}
