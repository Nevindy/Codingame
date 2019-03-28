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
        string MESSAGE = Console.ReadLine();
        string binaryMessage = "";
        string output = "";
        bool zeroState = false;

        foreach (char c in MESSAGE){ //convert string to binary
            binaryMessage += Convert.ToString(c,2).PadLeft(7,'0');
        }
        Console.Error.WriteLine(binaryMessage);
        
        //set initial state to opposite of first character
        if (binaryMessage[0] == '1') {
            zeroState = true;
        }
        
        //build output message, bit change handled by state flag
        foreach (char c in binaryMessage) {
            if ((c == '1') && zeroState) {
                output += " 0 ";
                zeroState = false;
            }
            else if ((c=='0') && !zeroState) {
                output += " 00 ";
                zeroState = true;
            }
            output += "0";
        }
        //trim leading space
        output = output.Trim();
        
        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(output);
    }
}
