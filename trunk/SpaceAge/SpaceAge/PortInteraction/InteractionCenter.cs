using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceAge
{
    class InteractionCenter
    {
		public enum InteractionCenterType { PlanetCity = 0, /*SpaceStation, OrbitalPlatform,*/ RawMaterialExtractor, Factory };
        InteractionCenterType CenterType;

        public Planet Parent;
        public string thisCenterName;
        public ItemStore thisStore;
        public MissionPost thisPost;
        public PeopleSource thisPeople;
        public PoliticalCenter thisPolitics;

		private InteractionCenter()
		{

		}

        public static InteractionCenter CityCenterOnPlanet(Planet inParent)
        {
            InteractionCenter thisCenter = new InteractionCenter();
            thisCenter.CenterType = InteractionCenterType.PlanetCity;
            thisCenter.Parent = inParent;
            thisCenter.thisCenterName = "Planet " + inParent.ToString() + " Trade Center";
            thisCenter.thisStore = ItemStore.GetGeneralStore(thisCenter);
            thisCenter.thisPost = new MissionPost();
            thisCenter.thisPeople = new PeopleSource();
            thisCenter.thisPolitics = new PoliticalCenter();

            return thisCenter;
        }

        public static InteractionCenter RawMaterialExtractorOnPlanet(Planet inParent)
        {
            InteractionCenter thisCenter = new InteractionCenter();
            thisCenter.CenterType = InteractionCenterType.RawMaterialExtractor;
            thisCenter.Parent = inParent;
            thisCenter.thisCenterName = "Planet " + inParent.ToString() + " Extract";
            thisCenter.thisStore = null;
            thisCenter.thisPost = null;
            thisCenter.thisPeople = null;
            thisCenter.thisPolitics = null;
            // TODO: Eventually add extractor management tab
            return thisCenter;
        }

    }
}
