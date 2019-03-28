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
        int L = int.Parse(Console.ReadLine());
        int H = int.Parse(Console.ReadLine());
        string T = Console.ReadLine();
        string[,] letters = new string[27, H];
        string alphabet = "abcdefghijklmnopqrstuvwxyz";
        for (int i = 0; i < H; i++)
        {
            string ROW = Console.ReadLine();
            for (int j = 0; j < 27; j++) {
                try {
                    letters[j, i] = ROW.Substring(L*j, L);
                }
                catch (System.IndexOutOfRangeException e) {
                    Console.Error.WriteLine(i + " " + j);
                    Console.Error.WriteLine(letters.Length);
                }
            }
        }
        for (int h = 0; h < H; h++){
            string output = "";
            for (int i = 0; i < T.Length; i++){
                int index = alphabet.IndexOf(Char.ToLower(T[i]));
                if (index > -1) {
                    output += letters[index, h];
                }
                else {
                    output += letters[26, h];
                }
            }
            Console.WriteLine(output);
        }

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        
    }
}
