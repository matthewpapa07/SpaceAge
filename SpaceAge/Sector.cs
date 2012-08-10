using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SpaceAge
{
    class Sector
    {
        public const int MAX_SYSTEMS_PER_SECTOR = 5;
        public const int MAX_DISTANCE_FROM_AXIS = 5000;      //Number must be significantly larger than UiSectorMap Height/Width

        public StarSystem [] StarSystemsList;
        //public Point [] LocationPointsList;
        //Universe parent;

        public Sector(/*Universe u*/)
        {
            //setParent(u);
            generateSector();
            
        }

        public void generateSector()
        {
            NumberGenerator n;
            int systemsToPopulate;
            int coord1, coord2;

            n = NumberGenerator.getInstance();

            //
            // Tune this to change the density of systems generated
            //
            if (!n.LinearPmfResult(8, 25))
            {
                StarSystemsList = new StarSystem[0];
                return;
            }
            systemsToPopulate = n.getNumberRange(0, MAX_SYSTEMS_PER_SECTOR);
            StarSystemsList = new StarSystem[systemsToPopulate];

            for (int i = 0; i < systemsToPopulate; i++)
            {
                coord1 = n.getNumberRange(0, MAX_DISTANCE_FROM_AXIS);
                coord2 = n.getNumberRange(0, MAX_DISTANCE_FROM_AXIS);

                StarSystemsList[i] = (new StarSystem(this, new Point(coord1, coord2)));
            }
            coord1 = 0;
        }

        public int getNumOfSystems()
        {
            return StarSystemsList.Length;
        }

        public string getPrintOut()
        {
            return "Planet : " + " Systems : " + "";
        }

        //public void setParent(Universe u)
        //{
        //    parent = u;
        //}
        
    }
}
