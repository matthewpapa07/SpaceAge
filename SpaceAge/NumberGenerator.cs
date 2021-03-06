﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SpaceAge
{
    public class NumberGenerator
    {
        private static NumberGenerator theInstance = new NumberGenerator();
        Random rnd1 = new Random();
        Random rnd2 = new Random(DateTime.Now.Millisecond - 36);

        private NumberGenerator()
        {
        }

        /// <summary>
        /// Singleton Implementation
        /// </summary>
        /// <returns>Returns instance of number generator</returns>
        public static NumberGenerator getInstance()
        {
            return theInstance;
        }

        /// <summary>
        /// Gets a random number
        /// </summary>
        /// <returns>A random number</returns>
        public int GetRandomNumber()
        {
            return rnd1.Next();
        }

        /// <summary>
        /// Generates a number in a range of numbers
        /// </summary>
        /// <param name="min">Minimum number to be genrated</param>
        /// <param name="max">Maximum number to be genrated</param>
        /// <returns></returns>
        public int GetRandNumberInRange(int min, int max)
        {
            if (min == max)
                return max;

            return rnd1.Next(min, max + 1);
        }

        public double GetRandDouble()
        {
            return rnd1.NextDouble();
        }

        public double GetRandDoubleInRange(double min, double max)
        {
            return rnd1.NextDouble() * (max - min) + min;
        }

        /// <summary>
        /// Picks a random value of an enum
        /// </summary>
        /// <typeparam name="T"> The enum type</typeparam>
        /// <returns>Value of the enum that has been picked randomly</returns>
        public T RandomEnum<T>()
        {
            T[] values = (T[])Enum.GetValues(typeof(T));
            return values[rnd1.Next(0, values.Length)];
        }
        public int MaxValesInEnum<T>()
        {
            T[] values = (T[])Enum.GetValues(typeof(T));
            return values.Length;
        }

        public T[] GetEnumScaledList<T>(double percentage)
        {
            //T[] values = (T[])Enum.GetValues(typeof(T));
            List<T> AllValues = new List<T>((T[])Enum.GetValues(typeof(T)));
            List<T> ReturnValues = new List<T>(3);
            T tempValue;

            // One value for free?? I guess...
            //T testVal = values[GetRandNumberInRange(0, values.Count - 1)];

            // See if we can add another as many times as we can
            for (int i = 0; i < AllValues.Count; i++)
            {
                if (LinearPmfResult(percentage))
                {
                    tempValue = AllValues[GetRandNumberInRange(0, AllValues.Count-1)];
                    AllValues.Remove(tempValue);
                    ReturnValues.Add(tempValue);
                }
                else
                {
                    return ReturnValues.ToArray();
                }
            }

            // In the small chance we get to fill the list...
            return ReturnValues.ToArray();
        }

        public T[] GetArrayScaledList<T>(T[] inValues, double percentage)
        {
            //T[] values = (T[])Enum.GetValues(typeof(T));
            List<T> AllValues = new List<T>(inValues);
            List<T> ReturnValues = new List<T>(10);
            T tempValue;

            // One value for free?? I guess...
            //T testVal = values[GetRandNumberInRange(0, values.Count - 1)];

            // See if we can add another as many times as we can
            for (int i = 0; i < AllValues.Count; i++)
            {
                if (LinearPmfResult(percentage))
                {
                    tempValue = AllValues[GetRandNumberInRange(0, AllValues.Count - 1)];
                    AllValues.Remove(tempValue);
                    ReturnValues.Add(tempValue);
                }
                else
                {
                    return ReturnValues.ToArray();
                }
            }

            // In the small chance we get to fill the list...
            return ReturnValues.ToArray();
        }

        //public object[] GetArrayScaledList(object [] Values, double percentage)
        //{
        //    List<object> AllValues = new List<object>(Values.Length);
        //    List<object> ReturnValues = new List<object>();
        //    object tempValue;
        //    // One value for free?? I guess...
        //    //T testVal = values[GetRandNumberInRange(0, values.Count - 1)];

        //    // See if we can add another as many times as we can
        //    for (int i = 0; i < AllValues.Count; i++)
        //    {
        //        if (LinearPmfResult(percentage))
        //        {
        //            tempValue = AllValues[GetRandNumberInRange(0, AllValues.Count - 1)];
        //            AllValues.Remove(tempValue);
        //            ReturnValues.Add(tempValue);
        //        }
        //        else
        //        {
        //            return ReturnValues.ToArray();
        //        }
        //    }

        //    // In the small chance we get to fill the list...
        //    return ReturnValues.ToArray();
        //}

        /// <summary>
        /// Returns the result of a linear PMF.
        /// </summary>
        /// <param name="expected">Numerator of PMF coefficient</param>
        /// <param name="sample">Denominator of PMF coefficient</param>
        /// <returns>Trials the PMF using pseudo random numbers</returns>
        public bool LinearPmfResult(int expected, int sample)
        {
            int temp;

            if (expected >= sample)
                return true;
            if (expected == 0)
                return false;
            if (expected >= 1 && sample >= 1)
            {
                temp = this.GetRandNumberInRange(1, sample);
                if (temp <= expected)
                    return true;
                else
                    return false;
            }

            return false;
        }

        public bool LinearPmfResult(double fraction)
        {
            if (fraction <= 0.0)
                return false;
            if (fraction > 1.0)
                return true;
            double sample = rnd1.NextDouble();
            if (sample <= fraction)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Generate a compund PMF
        /// </summary>
        /// <param name="exp"></param>
        /// <param name="sam"></param>
        /// <returns></returns>
        public int CompoundPmfResult(int exp, int sam)
        {
            int count = 0;

            while (LinearPmfResult(exp, sam))
            {
                count++;
            }

            return count;
        }

        public double GetItemStatAtLevel(int min, int max)
        {
            double ReturnVal = 0.0;
            double Percentage = 0.0;

            if (min > max)
                throw new InvalidOperationException();
            int difference = max - min;

            Percentage = PercentageAlgorithm6();
            ReturnVal = (double)difference * Percentage;
            ReturnVal += min;

            //Console.WriteLine("ReturnValue: " + ReturnVal + " \n");

            return (int)ReturnVal;
        }

        public double GetItemSupplyBasedStorePrice(int basePrice, int volume, int totalvolume)
        {
            double ratio = ((double)volume) / ((int)totalvolume);
            double result =  -(ratio*2.0 - 3.0);

            return (double)basePrice * result;
        }

        //public int[] GenerateTable()
        //{
        //}

        public double PercentageAlgorithm1(/*int level*/)
        {
            double coefficient = 0.8;
            int iterations = 20;
            int i = 1;
            //double fraction = rnd1.NextDouble();

            while (LinearPmfResult(NumberRaised(coefficient,(double)i)))
            {
                i++;
                if (i == (iterations - 1))
                {
                    break;
                }
            }

            double result = ((double)i /*+ fraction*/) / ((double)iterations);
            return result;
        }

        // y = (1/(.4*sqrt(2 × pi)))*exp((-.5)*((x-3)/.9)^2)
        public double PercentageAlgorithm2(/*int level*/)
        {
            int iterations = 20;
            int i = 1;
            //double fraction = rnd1.NextDouble();

            while (LinearPmfResult(NormalDist((double)i, 5.0, 0.4, 3.0)))
            {
                i++;
                if (i == (iterations - 1))
                {
                    break;
                }
            }


            double result = ((double)i /*+ fraction*/) / ((double)iterations);
            return result;
        }

        /// <summary>
        /// This algorithm will work OK if we have to use it
        /// </summary>
        /// <returns></returns>
        public double PercentageAlgorithm5()
        {
            double x = rnd1.NextDouble();
            double result1 = 0.0;
            double result2 = 0.0;
            double result = 0.0;

            result1 = Math.Pow(x, 24.0);
            result2 = PositiveComp(Math.Pow((1 - (x + 0.21)), 0.2) - 0.5);
            result = result1 + result2;
            return result ;
        }

        /// <summary>
        /// This algorithm will work OK if we have to use it
        /// </summary>
        /// <returns></returns>
        public double PercentageAlgorithm6()
        {
            double x = rnd2.NextDouble();
            double result1 = 0.0;
            double result2 = 0.0;
            double result = 0.0;

            result1 = Math.Pow(x, 60.0);    // Adjust this coefficient  with player level....
            result2 = PositiveComp(Math.Pow((1 - (x + 0.05)), 0.2) - 0.5);
            result = result1 + result2;

            return result;
        }

        public double PositiveComp(double d)
        {
            if (d > 0)
                return d;
            else
                return 0;
        }

        public double NumberRaised(double coefficient, double power)
        {
            return Math.Pow(coefficient, (double)power);
        }

        public double NormalDist(double x, double mu, double sigma, double sigmaInSq)
        {
            return (1 / (sigma * Math.Sqrt(2 * Math.PI))) * Math.Exp((-.5) * Math.Pow((x - mu) / sigmaInSq, 2));
        }

        private int Factorial(int x)
        {
            if (x == 0)
                return 1;
            else
                return x * Factorial(x - 1);
        }

        public Point GetPointDistanceFrom(int Distance, Point Origin)
        {
            int Xoffset = this.GetRandNumberInRange(0, Distance);
            int Yoffset = (int)Math.Sqrt(Distance * Distance + Xoffset * Xoffset);
            // Make X number negative if so
            if (LinearPmfResult(.5))
            {
                Xoffset *= (-1);
            }
            // Make X number negative if so
            if (LinearPmfResult(.5))
            {
                Yoffset *= (-1);
            }
            
            
            int Xcoor = Xoffset + Origin.X;
            int Ycoor = Yoffset + Origin.Y;


            return new Point(Xcoor, Ycoor);
        }
    }
}
