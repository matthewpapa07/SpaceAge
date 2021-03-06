﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceAge
{
    // TODO: Instead of have this be an integral part of the sector, in the near future just use it to correlate different objects
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

        public Sector ParentSector;
        public string SystemName;

        public ListViewItem StarSystemListViewItem;


        public StarSystem(Sector s)
        {
            setParent(s);
            LocalStarSystemNumber = GlobalStarSystemNumber++;
            generateStarSystem();

            StarSystemListViewItem = new ListViewItem(SystemName);
            StarSystemListViewItem.SubItems.Add(stars.Length.ToString());
            StarSystemListViewItem.SubItems.Add(planets.Length.ToString());
            StarSystemListViewItem.SubItems.Add("N/A");
        }

        public void generateStarSystem()
        {
            NumberGenerator numGen = NumberGenerator.getInstance();
            int numStars;
            int numPlanets = numGen.GetRandNumberInRange(MIN_PLANETS_PER_SYSTEM, MAX_PLANETS_PER_SYSTEM);
            int coord1, coord2;

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
                coord1 = numGen.GetRandNumberInRange(Sector.SECTOR_EDGE_PADDING, Sector.MAX_DISTANCE_FROM_AXIS - Sector.SECTOR_EDGE_PADDING);
                coord2 = numGen.GetRandNumberInRange(Sector.SECTOR_EDGE_PADDING, Sector.MAX_DISTANCE_FROM_AXIS - Sector.SECTOR_EDGE_PADDING);
                stars[i] = new Star(this, new Point(coord1, coord2));
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
                    name[i-1] = (char)numGen.GetRandNumberInRange(65,80);
                else
                    name[i - 1] = (char)numGen.GetRandNumberInRange(48, 57);
            }
            SystemName = new string(name);
        }

        public void setParent(Sector s)
        {
            ParentSector = s;
        }

        public string getName()
        {
            //
            // Add hex name generated here??
            //
            return SystemName;
        }

        public Sector MemberSector
        {
            get
            {
                return ParentSector;
            }
        }


    }
}
