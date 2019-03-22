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
class Player
{
    static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int W = int.Parse(inputs[0]); // width of the building.
        int H = int.Parse(inputs[1]); // height of the building.
        int N = int.Parse(Console.ReadLine()); // maximum number of turns before game over.
        
        inputs = Console.ReadLine().Split(' ');
        int X0 = int.Parse(inputs[0]);
        int Y0 = int.Parse(inputs[1]);
        
        //dimensions of the field
        int furthestLeft = 0;
        int furthestRight = W-1;
        int furthestBottom = H-1;
        int furthestTop = 0;

        // game loop
        while (true)
        {
            string bombDir = Console.ReadLine(); // the direction of the bombs from batman's current location (U, UR, R, DR, D, DL, L or UL)
            
            //implement a simple binary search for finding the target
            if (bombDir.IndexOf('R') != -1) {
                furthestLeft = X0;
                X0 += Convert.ToInt32(Math.Ceiling((furthestRight-(X0))/2.0));
            }
            if (bombDir.IndexOf('L') != -1) {
                furthestRight = X0;
                X0 += Convert.ToInt32(Math.Floor((furthestLeft - (X0))/2.0));
            }
            if (bombDir.IndexOf('D') != -1) {
                furthestTop = Y0;
                Y0 += Convert.ToInt32(Math.Ceiling((furthestBottom-(Y0))/2.0));
            }
            if (bombDir.IndexOf('U') != -1) {
                furthestBottom = Y0;
                Y0 += Convert.ToInt32(Math.Floor((furthestTop - (Y0))/2.0));
            }
            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");


            // the location of the next window Batman should jump to.
            Console.WriteLine(X0 + " " + Y0);
        }
    }
}
