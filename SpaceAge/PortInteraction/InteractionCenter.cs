using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceAge
{
    class InteractionCenter
    {
		public enum InteractionCenterType { City, SpaceStation, OrbitalPlatform, Other };

        public object thisParent;
        public string thisCenterName;
        public ItemStore thisStore;
        public MissionPost thisPost;
        public PeopleSource thisPeople;
        public PoliticalCenter thisPolitics;

		public InteractionCenter(string centerName, object parent)
		{
            thisParent = parent;
            thisCenterName = centerName;
            thisStore = new ItemStore();
            thisPost = new MissionPost();
            thisPeople = new PeopleSource();
            thisPolitics = new PoliticalCenter();
		}
    }
}
