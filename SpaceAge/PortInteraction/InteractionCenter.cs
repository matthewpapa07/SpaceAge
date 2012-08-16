using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceAge
{
    class InteractionCenter
    {
		public enum InteractionCenterType { City, SpaceStation, OrbitalPlatform, Other };

        public Planet Parent;
        public string thisCenterName;
        public ItemStore thisStore;
        public MissionPost thisPost;
        public PeopleSource thisPeople;
        public PoliticalCenter thisPolitics;

		public InteractionCenter(string centerName, Planet inParent)
		{
            Parent = inParent;
            thisCenterName = centerName;
            thisStore = new ItemStore(this);
            thisPost = new MissionPost();
            thisPeople = new PeopleSource();
            thisPolitics = new PoliticalCenter();
		}
    }
}
