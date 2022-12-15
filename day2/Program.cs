using System.Collections;

/*  A: Rock     X   ==> 1 point
    B: Paper    Y   ==> 2 points
    C: Scissors Z   ==> 3 points

    0 point for loss
    3 points for draw
    6 points for win
*/

string[] rounds = System.IO.File.ReadAllLines("input.txt");

(int score, string message) rps(char elfPlay, char myPlay)
{
    // Win rounds
    if (elfPlay == 'A' && myPlay == 'Y')
        return (8, "Round won");

    if (elfPlay == 'B' && myPlay == 'Z')
        return (9, "Round won");

    if (elfPlay == 'C' && myPlay == 'X')
        return (7, "Round won");

    // Draw rounds
    if (elfPlay == 'A' && myPlay == 'X')
        return (4, "Round draw");

    if (elfPlay == 'B' && myPlay == 'Y')
        return (5, "Round draw");

    if (elfPlay == 'C' && myPlay == 'Z')
        return (6, "Round draw");

    // Lost rounds
    if (elfPlay == 'A' && myPlay == 'Z')
        return (3, "Round lost");

    if (elfPlay == 'B' && myPlay == 'X')
        return (1, "Round lost");

    if (elfPlay == 'C' && myPlay == 'Y')
        return (2, "Round lost");
    else
        return (0, "Something went wrong");
}

// A || B || C && X
int loose(string round)
{
    if (round == "A X")
        return 3;

    if (round == "B X")
        return 1;

    if (round == "C X")
        return 2;
    else 
        return 0;
}

// A || B || C && Y
int draw(string round)
{
    if (round == "A Y")
        return 4;

    if (round == "B Y")
        return 5;

    if (round == "C Y")
        return 6;
    else
        return 0;
}

// A || B || C && Z
int win(string round)
{
    if (round =="A Z")
        return 8;

    if (round =="B Z")
        return 9;

    if (round =="C Z")
        return 7;
    else
        return 0;
}
System.Console.WriteLine(rounds[0]);
//char ldw(char elfPlay, char cond)
//{
//    // X need to loose
//
//    // Y need to draw
//    // Z need to win 
//}
//
int finalScore = 0;

for (int i = 0; i < rounds.Length; ++i)
{
    if(rounds[i][2] == 'X')
        finalScore += loose(rounds[i]);

    if(rounds[i][2] == 'Y')
        finalScore += draw(rounds[i]);

    if(rounds[i][2] == 'Z')
        finalScore += win(rounds[i]);
}

System.Console.WriteLine(finalScore);