
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


            List<int> list1 = parse(a, 1);
            List<int> list2 = parse(a, 2);
            //Sorterer
            list1.Sort();
            list2.Sort();

            //Del 1---------------------------------------------------------------------------------------
            int distance = 0;
            for (int i = 0; i < list1.Count; i++) { 
                distance += Math.Abs(list1[i] - list2[i]);
                    }
            Console.WriteLine("Total distance: " + distance);

            //Del 2---------------------------------------------------------------------------------------
            int similarityScore = 0;
            foreach (int i in list1) {
                similarityScore += i * list2.FindAll(c => c.Equals(i)).Count();
            }
            Console.WriteLine("Similarity Score: " + similarityScore);
          
            Console.ReadKey();
           
            
        }

        static List<int> parse(string[] list, int col)
        {
            List<int> ints = new List<int>();
            foreach (string i in list) {
                int a = 0;
                switch (col)
                {
                    case <= 1:
                     a = Int32.Parse(i.Split(' ').First());
                     break;

                    case > 1:
                        a = Int32.Parse(i.Split(' ').Last());
                        break;
                }
                ints.Add(a);
                           
            }
            return ints;

        }


    }
}
