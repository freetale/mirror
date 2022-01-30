using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Runtime
{
    public static class StatManager
    {
        private static string LongestMileKey = "LongestMile";
        private static string TotalMileKey = "TotalMile";

        public static int LongestMile => PlayerPrefs.GetInt(LongestMileKey, 0);
        public static int TotalMile => PlayerPrefs.GetInt(TotalMileKey, 0);

        /// <summary>
        /// last mile append, in-memory property
        /// </summary>
        public static int LastMile { get; private set; }

        /// <summary>
        /// append mile after lose condition
        /// </summary>
        /// <param name="mile">current mile</param>
        /// <returns>lost condition</returns>
        public static bool AppendMile(int mile)
        {
            LastMile = mile;
            int totalMile = TotalMile;
            bool isHighScore = false;
            if (LongestMile < mile)
            {
                isHighScore = true;
                PlayerPrefs.SetInt(LongestMileKey, mile);
            }
            PlayerPrefs.SetInt(TotalMileKey, totalMile + mile);
            PlayerPrefs.Save();
            return isHighScore;
        }
    }
}
