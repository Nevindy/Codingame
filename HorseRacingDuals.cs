using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int closestDifference = int.MaxValue;
        List<int> horses = new List<int>();
        for (int i = 0; i < N; i++)
        {
            int pi = int.Parse(Console.ReadLine());
            horses.Add(pi);
        }

        horses.Sort();
        for(int i = 1; i < N; i++){
            if ((horses[i] - horses[i-1]) < closestDifference)
                closestDifference = (horses[i] - horses[i-1]);
        }

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(closestDifference);
    }
}
