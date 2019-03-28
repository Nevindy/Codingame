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
        int n = int.Parse(Console.ReadLine()); // the number of temperatures to analyse
        int val = -6000;
        string[] inputs = Console.ReadLine().Split(' ');

        for (int i = 0; i < n; i++)
        {
            int t = int.Parse(inputs[i]); // a temperature expressed as an integer ranging from -273 to 5526
            Console.Error.WriteLine(val + " " + t + " " + Math.Abs(t));
            if (Math.Abs(t) <= Math.Abs(val)){
                if ((Math.Abs(val) == Math.Abs(t)) && (val < 0)){
                    val = t;
                } else if (Math.Abs(val) != Math.Abs(t)) {
                    val = t;
                }
            }
        }

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");
        if (val == -6000) {
            val = 0;
        }

        Console.WriteLine(val);
    }
}
