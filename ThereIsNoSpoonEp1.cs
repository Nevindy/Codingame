using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Don't let the machines win. You are humanity's last hope...
 **/
class Player
{
    static void Main(string[] args)
    {
        int width = int.Parse(Console.ReadLine()); // the number of cells on the X axis
        int height = int.Parse(Console.ReadLine()); // the number of cells on the Y axis
        List<string> map = new List<string>();
        for (int i = 0; i < height; i++)
        {
            string line = Console.ReadLine(); // width characters, each either 0 or .
            map.Add(line);
        }

        for (int i = 0; i < height; i++){
            for(int j = 0; j < width; j++){
                if (map[i][j] == '0') {
                    string output = j + " " + i + " ";
                    
                    int xIndex = map[i].IndexOf('0', j+1);
                    if (xIndex > 0) 
                        output += xIndex + " " + i + " ";
                    else
                        output += "-1 -1 ";
                    
                    int yIndex = map.FindIndex(i+1, x => x[j] == '0');
                    if (yIndex > 0)
                        output += j + " " + yIndex;
                    else
                        output += "-1 -1";
                    
                    Console.WriteLine(output);
                }
            }
        }

        // Three coordinates: a node, its right neighbor, its bottom neighbor
        //Console.WriteLine("0 0 1 0 0 1");
    }
}
