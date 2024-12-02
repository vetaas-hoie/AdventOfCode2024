using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reading File: ");
            string[] input = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\..\\..\\..\\text.txt");
            Console.WriteLine("Total lines: " + input.Length);
            List<List<int>> reports = input.Select(ParseString).ToList();

            int safeReports = 0, safeReportPart2=0;

            foreach (var report in reports)
            {
                if (IsRising(report) || IsFalling(report))
                {
                    safeReports++;
                    safeReportPart2++;
                }
                else if (CanBeSafeWithOneRemoval(report))
                {
                    safeReportPart2++;
                }
            }

            Console.WriteLine("Safe Reports: " + safeReports);
            Console.WriteLine("Safe Reports with dampener: " + safeReportPart2);
            Console.ReadKey();
        }

        private static bool IsRising(List<int> levels)
        {
            for (int i = 1; i < levels.Count; i++)
            {
                if (levels[i - 1] >= levels[i] || Math.Abs(levels[i - 1] - levels[i]) < 1 || Math.Abs(levels[i - 1] - levels[i]) > 3)
                {
                    return false;
                }
            }
            return true;
        }

        private static bool IsFalling(List<int> levels)
        {
            for (int i = 1; i < levels.Count; i++)
            {
                if (levels[i - 1] <= levels[i] || Math.Abs(levels[i - 1] - levels[i]) < 1 || Math.Abs(levels[i - 1] - levels[i]) > 3)
                {
                    return false;
                }
            }
            return true;
        }

        private static bool CanBeSafeWithOneRemoval(List<int> levels)
        {
            for (int i = 0; i < levels.Count; i++)
            {
                
                var modifiedLevels = new List<int>(levels);
                modifiedLevels.RemoveAt(i);

                
                if (IsRising(modifiedLevels) || IsFalling(modifiedLevels))
                {
                    return true;
                }
            }
            return false;
        }

        private static List<int> ParseString(string s)
        {
            return s.Split(' ').Select(int.Parse).ToList();
        }
    }
}
