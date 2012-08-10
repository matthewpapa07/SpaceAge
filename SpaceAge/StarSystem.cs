using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SpaceAge
{
    class StarSystem
    {
        const int MIN_PLANETS_PER_SYSTEM = 0;
        const int MAX_PLANETS_PER_SYSTEM = 15;
//        const int MAX_STARS_PER_SYSTEM = 2;         // Maximum of binary system for now
        const int CHANCE_OF_MULTIPLE_STARS = 15;
        const int STAR_SYSTEM_NAME_MAX = 8;           // Length of generated names. Will be half letters and half numbers

        public static int GlobalStarSystemNumber = 0;
        public int LocalStarSystemNumber;

        public Star [] stars;
        public Planet [] planets;

        public Point sectorLocation;
        public Sector parent;
        public string SystemName;


        public StarSystem(Sector s, Point location)
        {
            setParent(s);
            LocalStarSystemNumber = GlobalStarSystemNumber++;
            generateStarSystem();
            sectorLocation = location;
        }

        public void generateStarSystem()
        {
            NumberGenerator numGen = NumberGenerator.getInstance();
            int numStars;
            int numPlanets = numGen.getNumberRange(MAX_PLANETS_PER_SYSTEM, MAX_PLANETS_PER_SYSTEM);

            if (numGen.LinearPmfResult(CHANCE_OF_MULTIPLE_STARS, 100))
                numStars = 2;
            else
                numStars = 1;

            stars = new Star[numStars];
            planets = new Planet[numPlanets];

            //
            // Generate Stars
            //
            for (int i = 0; i < numStars; i++)
            {
                stars[i] = new Star(this);
            }

            //
            // Generate Planets
            //
            for (int i = 0; i < numPlanets; i++)
            {
                planets[i] = new Planet(this);
            }

            char[] name = new char[STAR_SYSTEM_NAME_MAX];
            for (int i = 1; i <= STAR_SYSTEM_NAME_MAX; i++)
            {
                if(i <= (STAR_SYSTEM_NAME_MAX/2))
                    name[i-1] = (char)numGen.getNumberRange(65,80);
                else
                    name[i - 1] = (char)numGen.getNumberRange(48, 57);
            }
            SystemName = new string(name);
        }

        public void setParent(Sector s)
        {
            parent = s;
        }

        public string getName()
        {
            //
            // Add hex name generated here??
            //
            return SystemName;
        }
    }
}
