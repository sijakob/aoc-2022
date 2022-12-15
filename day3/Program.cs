using System.Collections.Generic;

(string firstHalf, string secondHalf) halveString(string toHalve)
{
    return (toHalve.Substring(0, toHalve.Length / 2),
            toHalve.Substring(toHalve.Length / 2));
}

string findCommonItem(string str1, string str2)
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

string[] rucksacks = System.IO.File.ReadAllLines("input.txt");
Dictionary<char, int> prios = createPrioTable();
int prioVal = 0;

foreach (string rucksack in rucksacks)
{
    string firstHalf = halveString(rucksack).firstHalf;
    string secondHalf = halveString(rucksack).secondHalf;
    char[] common = findCommonItem(firstHalf, secondHalf).ToCharArray();

    prioVal += prios[common[0]];
}

System.Console.WriteLine(prioVal);
