using System.Collections.Generic;

namespace day3
{
    public class Solution
    {
        (string firstHalf, string secondHalf) halveString(string toHalve)
        {
            return (toHalve.Substring(0, toHalve.Length / 2),
                    toHalve.Substring(toHalve.Length / 2));
        }

        string compareOneRucksack(string str1, string str2)
        {
            string comp1 = new String(str1.Distinct().ToArray());
            string comp2 = new String(str2.Distinct().ToArray());
            string ans = "";

            foreach (char c in comp1)
            {
                foreach (char cc in comp2)
                {
                    if (c.Equals(cc))
                    {
                        ans += c;
                    }
                }
            }
            return ans;
        }

        Dictionary<char, int> createPrioTable()
        {
            char[] alphaUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            char[] alphaLower = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            int counter = 1;

            Dictionary<char, int> prios = new Dictionary<char, int>();

            foreach (char lower in alphaLower)
            {
                prios.Add(lower, counter);
                counter++;
            }
            foreach (char upper in alphaUpper)
            {
                prios.Add(upper, counter);
                counter++;
            }
            return prios;
        }

        //char compareThreeRucksack(List<string> rucksacks)
        //{
        //    List<string> commonItems = new List<string>();
        //    var result = rucksacks[0].Intersect(rucksacks[1]);
        //}

        public static void Main()
        {
            Solution s = new Solution();

            List<string> rucksacks = System.IO.File.ReadAllLines("input.txt").ToList();
            List<string> temp = new List<string>();

            List<string> test = new List<string>() {"abcd", "abd", "hjk", "aion"};

            var testIt = test[0].Intersect(test[1]).Intersect(test[2]);
            System.Console.WriteLine(testIt);


            //for(int i = 0; i<rucksacks.Count; ++i)
            //{
            //    if(i != 0 && i%3 == 0)
            //    {
            //        System.Console.WriteLine(rucksacks[i].Intersect(rucksacks[i-1].Intersect(rucksacks[i-2])).ToString());
            //    }
            //}
            // Dictionary<char, int> prios = s.createPrioTable();
            // int prioVal = 0;

            // foreach (string rucksack in rucksacks)
            // {
            //     string firstHalf = s.halveString(rucksack).firstHalf;
            //     string secondHalf = s.halveString(rucksack).secondHalf;
            //     char[] common = s.compareOneRucksack(firstHalf, secondHalf).ToCharArray();

            //     prioVal += prios[common[0]];
            // }

            // System.Console.WriteLine("Solution 1: " + prioVal);



        }
    }
}
