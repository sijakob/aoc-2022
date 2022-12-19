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

        int getPrios(char c)
        {
            if(Char.IsUpper(c))
                return c-96;
            else
                return c-38;
        }

        int getIntersect(string[] lines)
        {
            var chonk = lines.Chunk(3);
            var res = chonk.Select(chonk => 
            { 
                var first = chonk[0];
                var second = chonk[1];
                var third = chonk[2];
                return first.Intersect(second).Intersect(third).Select(c => getPrios(c)).Sum();
            }).Sum();

            return res;
        }
        public static void Main()
        {
            Solution s = new Solution();

            //List<string> rucksacks = System.IO.File.ReadAllLines("input.txt").ToList();
            var lines = System.IO.File.ReadAllLines("input.txt");
            int res = s.getIntersect(lines);
            System.Console.WriteLine(res);
        }
    }
}
