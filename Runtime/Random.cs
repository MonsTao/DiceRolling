using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace  AdvanceRandom
{
    public class Random
    {
        private static System.Random random = new System.Random();

        private static double BoxMuller()
        {
                double v1, v2, s;
                do
                {
                    v1 = 2.0 * random.NextDouble() - 1.0;
                    v2 = 2.0 * random.NextDouble() - 1.0;
                    s = v1 * v1 + v2 * v2;
                } while (s >= 1.0 || s == 0);
                s = System.Math.Sqrt((-2.0 * System.Math.Log(s)) / s);
                return v1 * s;         
        }

        public static double BoxMuller(double mean, double standard_deviation)
        {
            return mean + BoxMuller() * standard_deviation;
        }


        public static  int GaussRandom(int min ,int max)
        {
           // Debug.Log((int)BoxMuller(min + (max - min) / 2.0, 1.0));
            return (int)BoxMuller(min + (max - min) / 2.0, 1.0);
        }
        public static float GaussRandom(float min, float max)
        {
            return (float)BoxMuller(min + (max - min) / 2.0, 1.0);
        }

        public static int AverageRandom(int min, int max)
        {
            System.Random random = new System.Random();
            //  Debug.Log(random.Next(min, max));
            return random.Next(min, max);
        }

        public static float AverageRandom(float min, float max)
        {
            return UnityEngine.Random.Range(min, max);
        }
    }
} 

