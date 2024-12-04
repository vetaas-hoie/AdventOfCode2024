
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace AdventOfCode
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Reading File: ");
            string[] a = (string[])File.ReadAllLines(Directory.GetCurrentDirectory() + "\\..\\..\\..\\text.txt");
            Console.WriteLine("Total lines: " + a.Length);
            char[,] grid = new char[140, 140];
            Console.WriteLine(grid[0, 1]);
            int line = 0;
            foreach (string s in a)
            {

                for (int col = 0; col < 140; col++)
                {
                    grid[line, col] = s[col];
                }
                line++;
            }

            Console.WriteLine("Total: " + StarSearch(grid) + "\n");
            Console.WriteLine("Total part 2: " + NewStarSearch(grid) + "\n");
            Console.ReadLine();



            static int StarSearch(char[,] grid) //PArt1
            {
                int count = 0;

                for (int col = 0; col < grid.GetLength(0); col++)
                {
                    for (int row = 0; row < grid.GetLength(0); row++)
                    {
                        if (grid[row, col] != 'X') continue;
                        count += CheckN(grid, row, col) +
                            CheckNE(grid, row, col) +
                            CheckE(grid, row, col) +
                            CheckSE(grid, row, col) +
                            CheckS(grid, row, col) +
                            CheckSW(grid, row, col) +
                            CheckW(grid, row, col) +
                            CheckNW(grid, row, col);
                    }
                }
                return count;
            }


            static int CheckN(char[,] grid, int rom, int col)
            {
                try
                {
                    if (
                            grid[rom - 1, col] == 'M' &&
                            grid[rom - 2, col] == 'A' &&
                            grid[rom - 3, col] == 'S') return 1;

                    return 0;

                }
                catch { return 0; }
            }
            static int CheckS(char[,] grid, int rom, int col)
            {
                try
                {
                    if (
                            grid[rom + 1, col] == 'M' &&
                            grid[rom + 2, col] == 'A' &&
                            grid[rom + 3, col] == 'S') return 1;

                    return 0;

                }
                catch { return 0; }
            }
            static int CheckE(char[,] grid, int rom, int col)
            {
                try
                {
                    if (
                            grid[rom, col + 1] == 'M' &&
                            grid[rom, col + 2] == 'A' &&
                            grid[rom, col + 3] == 'S') return 1;

                    return 0;

                }
                catch { return 0; }
            }
            static int CheckW(char[,] grid, int rom, int col)
            {
                try
                {
                    if (
                            grid[rom, col - 1] == 'M' &&
                            grid[rom, col - 2] == 'A' &&
                            grid[rom, col - 3] == 'S') return 1;

                    return 0;

                }
                catch { return 0; }
            }
            static int CheckNE(char[,] grid, int rom, int col)
            {
                try
                {
                    if (
                            grid[rom - 1, col + 1] == 'M' &&
                            grid[rom - 2, col + 2] == 'A' &&
                            grid[rom - 3, col + 3] == 'S') return 1;

                    return 0;

                }
                catch { return 0; }
            }
            static int CheckNW(char[,] grid, int rom, int col)
            {
                try
                {
                    if (
                            grid[rom - 1, col - 1] == 'M' &&
                            grid[rom - 2, col - 2] == 'A' &&
                            grid[rom - 3, col - 3] == 'S') return 1;

                    return 0;

                }
                catch { return 0; }
            }
            static int CheckSE(char[,] grid, int rom, int col)
            {
                try
                {
                    if (
                            grid[rom + 1, col + 1] == 'M' &&
                            grid[rom + 2, col + 2] == 'A' &&
                            grid[rom + 3, col + 3] == 'S') return 1;

                    return 0;

                }
                catch { return 0; }
            }
            static int CheckSW(char[,] grid, int rom, int col)
            {
                try
                {
                    if (
                            grid[rom + 1, col - 1] == 'M' &&
                            grid[rom + 2, col - 2] == 'A' &&
                            grid[rom + 3, col - 3] == 'S') return 1;

                    return 0;

                }
                catch { return 0; }
            }


            static int NewStarSearch(char[,] grid)//part2
            {
                int count = 0;

                for (int row = 0; row < grid.GetLength(0); row++)
                {
                    for (int col = 0; col < grid.GetLength(0); col++)
                    {
                        if (grid[row, col] != 'A') continue;
                        count += CheckforStar(grid, row, col);
                    }
                }
                return count;
            }

            static int CheckforStar(char[,] grid, int row, int col)
            {
                try
                {
                    if (((grid[row - 1, col - 1] == 'M' && grid[row + 1, col + 1] == 'S') || (grid[row - 1, col - 1] == 'S' && grid[row + 1, col + 1] == 'M')) &&
                    ((grid[row - 1, col + 1] == 'M' && grid[row + 1, col - 1] == 'S') || (grid[row - 1, col + 1] == 'S' && grid[row + 1, col - 1] == 'M')))
                        return 1;
                    return 0;

                }
                catch { return 0; }
            }


        }

    }
}
