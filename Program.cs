
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
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

            List<string> rul = GetRules(a);
            List<string> upd = GetUpdates(a);
            List<int[]> rules = ParseRule(rul);
            List<List<int>> updates = ParseUpdate(upd);
            int sum = 0;
            foreach (List<int> update in updates) {

                if (CheckUpdate(update, rules)) sum += update[update.Count / 2];

            }

            Console.WriteLine("Total sum of approved updates: " + sum);

            Console.ReadKey();
        }


        static List<string> GetRules(string[] file)
        {
            List<string> rules = new List<string>(); 
            foreach (string rule in file)
            {
                if (rule == "") break;
                rules.Add(rule);
            }
            return rules;

        }

        static List<string> GetUpdates(string[] file)
        {
            List<string> updates = new List<string>();
            bool wait = true;
            foreach (string rule in file)
            {
                if (!wait) { 
                    updates.Add(rule);
                }

                if (wait && rule =="")
                {
                    wait = false;
                }
            }
               return updates;
        }

        static List<int[]> ParseRule(List<string> a) {
            List<int[]> rules = new List<int[]>();
            
            foreach (string rule in a)
            {
                rules.Add(rule.Split('|').Select(int.Parse).ToArray());
            }

            return rules;
        
        }

        static List<List<int>> ParseUpdate(List<string> a) {
            List<List<int>> updates = new List<List<int>>();
            foreach (string update in a)
            {
                int[] i = update.Split(',').Select(int.Parse).ToArray();
                updates.Add(i.ToList());
            }
            return updates;
        }

        static bool CheckUpdate(List<int> update, List<int[]> rules)
        {
           foreach(int[] rule in rules)
            {
                int r1 = update.FindIndex((c)=> c == rule[0]);
                
                int r2 = update.FindIndex((c)=> c == rule[1]);
                if (r1 == -1 || r2 == -1 || (r1 < r2)) continue;
                else return false;
            }
            return true;
        }
    }
}

