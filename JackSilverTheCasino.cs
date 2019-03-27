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
class Solution {
    static void Main(string[] args) {
        int ROUNDS = int.Parse(Console.ReadLine());
        int CASH = int.Parse(Console.ReadLine());
        for (int i = 0; i < ROUNDS; i++) {
            string PLAY = Console.ReadLine();
            string[] playParts = PLAY.Split(' ');
            bool wonPlay = false;
            int bet = (int)Math.Ceiling(CASH/4.0);
            
            switch (playParts[1]) {
                case "PLAIN":
                    if (playParts[0] == playParts[2]) {
                        bet *= 35;
                        wonPlay = true;
                    } 
                    break;
                case "EVEN":
                    if (Int32.Parse(playParts[0])%2 == 0 && Int32.Parse(playParts[0]) > 0) {
                        wonPlay = true;
                    } 
                    break;
                default:
                    if (Int32.Parse(playParts[0])%2 == 1) {
                        wonPlay = true;
                    }
                    break;
            }
            
            if (wonPlay) {
                CASH += bet;
            }
            else {
                CASH -= bet;
            }
        }

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(CASH);
    }
}
