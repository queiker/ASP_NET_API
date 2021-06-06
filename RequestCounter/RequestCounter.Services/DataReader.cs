﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RequestCounter.Services
{
    /// <summary>
    /// This class is supposed to be implemented as part of TASK "Save counts". Pay attention to setting of the file added to project
    /// </summary>
    internal static class DataReader
    {
        private static readonly string fileName = "request-counts.txt";

        internal static Dictionary<string, int> ReadFromFile()
        {
            var lines  = File.ReadAllLines(GetFullFilePath());
            Dictionary<string, int> stats = new Dictionary<string, int>();
            foreach (var line in lines)
            {
                string[] splitted = line.Split(",");
                if (splitted.Length == 2)
                {
                    stats.Add(splitted[0], int.Parse(splitted[1]));
                }
            }

            return stats;
            //Put code reading data from file here
        }

        internal static void WriteToFile(Dictionary<string, int> stats)
        {
            //Put code writing to file here
            List<string> filelines = new List<string>();
            foreach (var line in stats)
            {
                filelines.Add($"{line.Key},{line.Value}");
            }
            File.WriteAllLines(GetFullFilePath(), filelines);
        }

        /// <summary>
        /// Use it to resolve full path to the file. 
        /// </summary>
        /// <returns></returns>
        private static string GetFullFilePath()
        {
            string filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            var fullPath = Path.Combine(filePath, fileName);
            return fullPath;
        }
    }
}
