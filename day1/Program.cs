/*  Loop through array sum each index until nullorempty string is hit
    Save sum in temp variable
    loop through next set of values until nullorempty is hit compare against temp*/

(int parsed, string message) strParse(string toParse)
{

    bool parsable = Int32.TryParse(toParse, out int parsed);
    if (parsable)
        return (parsed, "");
    else
        return (0, toParse + ": Is not parsable");
}

string[] lines = System.IO.File.ReadAllLines("input.txt");

int max = 0;
int curr = 0;
List<int> elfBaggage = new List<int>();

for (int i = 0; i < lines.Length; ++i)
{
    if (String.IsNullOrWhiteSpace(lines[i]))
    {
        elfBaggage.Add(curr);
        curr = 0;
    }

    curr += strParse(lines[i]).parsed;
}

elfBaggage.Sort();
elfBaggage.Reverse();
int sum = 0;
for(int j = 0; j<3; ++j)
{
    sum += elfBaggage[j];
}
System.Console.WriteLine(sum);


