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
        long r1 = long.Parse(Console.ReadLine());
        long r2 = long.Parse(Console.ReadLine());

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");
        while(r1 != r2) {
            if (r1 < r2)
                r1 = nextRiverNum(r1);
            else
                r2 = nextRiverNum(r2);
        }

        Console.WriteLine(r1);
    }
    static long nextRiverNum(long inNum) {
        long retVal = inNum;
        long temp = inNum;
        while (temp > 0) {
            retVal += temp%10;
            temp /= 10;
        }
        return retVal;
    }
}
