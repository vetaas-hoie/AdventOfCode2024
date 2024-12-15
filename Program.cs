
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            //string[] a = (string[])File.ReadAllLines("C:\\Users\\avetaash\\source\\repos\\AdventOfCode2024\\text.txt");
            string[] a = (string[])File.ReadAllLines(Directory.GetCurrentDirectory() + "\\..\\..\\..\\text.txt");
            Console.WriteLine("Total lines: " + a.Length);

            List<long> stones = a[0].Split(' ').Select(long.Parse).ToList();
            //List<int> stones = new List<int> { 125, 17 };

            //PrintOut(stones);

            for (int i = 0; i < 25; i++)
            {
                stones = blink(stones);
            }
            Console.WriteLine("Total number of stones: " + stones.Count);





            Console.ReadKey();
        }

        static List<long> blink(List<long> a)
        {
            int position = 0;

            // Iterate over a copy of the list
            foreach (long i in new List<long>(a))
            {
                if (i == 0)
                {
                    a[position] = 1;
                }
                else if (i.ToString().Length % 2 == 0)
                {
                    string iStr = i.ToString();
                    int halfLength = iStr.Length / 2;

                    long first = long.Parse(iStr.Substring(0, halfLength));
                    long second = long.Parse(iStr.Substring(halfLength));

                    a[position] = (long)second; // Replace the current value with the second part
                    a.Insert(position, (long)first); // Insert the first part at the same position
                    position++; // Move position forward for the next element
                }
                else
                {
                    try
                    {
                        a[position] = checked(a[position] * 2024); // Multiply by 2024
                    }catch (OverflowException) {
                        Console.WriteLine("Overflow:" + a[position]);
                    }
                }

                position++;
            }

            return a;
        }

        static void PrintOut(List<long> a) {

            foreach (int i in a) Console.Write(i + " ") ;

            Console.WriteLine();
        }


    }
}
