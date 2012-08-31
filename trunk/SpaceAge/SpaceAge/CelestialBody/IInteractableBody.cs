using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceAge
{
    interface IInteractableBody : ISectorMember
    {
        object DirectParent
        {
            get;
        }
        RawMaterialExtractor[] Extractors
        {
            get;
        }
        Factory[] Factories
        {
            get;
        }

        ItemStore Store
        {
            get;
        }
        MissionPost MissionPost
        {
            get;
        }
        PeopleSource PeopleSource
        {
            get;
        }
        PoliticalCenter PoliticalCenter
        {
            get;
        }
        string ToString();
    }
}
