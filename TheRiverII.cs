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
        int r1 = int.Parse(Console.ReadLine());
        string output = "NO";
        int x = 1, testRiver = 0, digits = 0;
        //initialize testRiver so we can begin testing
        
        do {
            testRiver = nextRiverNum(r1-x);
            x++;
            if (testRiver == r1) {
                output = "YES";
            }
            digits = Convert.ToInt32(Math.Floor(Math.Log10(r1-x) + 1));
        } while((r1-x)+(9*digits) > r1);

        Console.WriteLine(output);
    }
    //taken from previous solution
    static int nextRiverNum(int inNum) {
        int retVal = inNum;
        int temp = inNum;
        while (temp > 0) {
            retVal += temp%10;
            temp /= 10;
        }
        return retVal;
    }
}
