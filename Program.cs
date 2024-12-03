
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            List<string> all = new List<string>();
            foreach (string s in a)
            {
                all.AddRange(Parsestring(s));
            }
            int sum = 0;

            foreach (string s in all)
            {
                MatchCollection m = Regex.Matches(s, @"\d+");
                sum += Int32.Parse(m[0].Value) * Int32.Parse(m[1].Value);
            }

            Console.WriteLine("Totalsum: " + sum);

            List<string> all2 = new List<string>();
            
            
            //Part2
            //Monterer alle linjer til en sammenhengdende streng
            string newstring = "";
            foreach (string s in a)
            {
                newstring += s;
            }
            string[] newstr = { newstring }; //monterer i en array for gjenbruk av ekisterende kode som ikke virket.

            foreach (string s in newstr)
            {
                //Splitter string på don't()
                string[] donts = s.Split(new string[] { "don't()" }, StringSplitOptions.None);
                int i = 0;
                foreach (string s1 in donts)
                {
                    if (i == 0)
                    {
                        //parser alle frem til første dont()
                        all2.AddRange(Parsestring(s1));
                        i++;
                    }
                    else
                    {
                        //Parser alle etter første do()
                        if (s1.IndexOf("do()") > -1)
                        {
                            string substring = s1.Substring(s1.IndexOf("do()"), s1.Length - s1.IndexOf("do()"));
                            all2.AddRange(Parsestring(substring));
                        }
                        i++;
                    }
                }
            }
            int sum2 = 0;

            foreach (string s in all2)
            {
                MatchCollection m = Regex.Matches(s, @"\d+");
                sum2 += Int32.Parse(m[0].Value) * Int32.Parse(m[1].Value);
            }

            Console.WriteLine("Totalsum med do's and dont's: " + sum2);

            Console.ReadKey();
        }


        private static List<string> Parsestring(string s)
        {
            //returnerer Liste med alle mul(x,x)

            List<string> b = new List<string>();
            MatchCollection a = Regex.Matches(s, "mul\\(\\d{1,3},\\d{1,3}\\)");

            foreach (Match m in a)
            {
                b.Add(m.Value);
            }
            return b;
        }

    }
}
