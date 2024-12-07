
using AdventOfCode2024;
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
            char[,] grid = new char[130, 130];
            int line = 0;
            int direction = 0;
            int startX = 0;
            int startY = 0;

            foreach (string s in a)
            {

                for (int col = 0; col < 130; col++)
                {
                    grid[line, col] = s[col];
                }
                line++;
            }

            Guard g = new Guard(findStartCol(grid)[0], findStartCol(grid)[1],grid);
            g.Run();//psart1
            
            Console.ReadLine();

        }

        static int[] findStartCol(char[,] grid)
        {
            for (int row = 0; row < 130; row++)
            {
                for (int col=0; col < 130; col++) {
                    if (grid[row, col] == '^') return [row, col];
                }
            }
            return [-1, -1];
        }
        
     


       

    }
}
