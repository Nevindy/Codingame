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
        string[] inputs = Console.ReadLine().Split(' ');
        int W = int.Parse(inputs[0]);
        int H = int.Parse(inputs[1]);
        List<string> map = new List<string>();
        for (int i = 0; i < H; i++) {
            string line = Console.ReadLine();
            map.Add(line);
        }
        
        //Grab headers
        string[] heads = map[0].Split(new [] {"  "}, StringSplitOptions.None);
        List<string> headers = new List<string>(heads);
        
        //initialize column tracking, 0 indexed will be fixed upon output
        List<int> destCol = new List<int>();
        for(int i = 0; i < headers.Count; i++) {
            destCol.Add(i);
        }
        
        //get destination names
        string[] names = map[map.Count-1].Split(new [] {"  "}, StringSplitOptions.None);
        List<string> colNames = new List<string>(names);
        
        //go through columns and change the destinations
        //we can start from 0 as headers won't have the character '-'
        for(int i = 0; i < map.Count; i++) {
            int startIndex = 0;
            while(map[i].IndexOf("--", startIndex) != -1) {
                int foundIdx = map[i].IndexOf("--", startIndex);
                startIndex = foundIdx+1;
                
                //find which gap is filled, subtract the width of the column and divide by number of characters for each col
                int gapNum = (foundIdx - 1)/3;
                
                for(int j=0; j < destCol.Count; j++) {
                    if (destCol[j] == gapNum) {
                        destCol[j] = gapNum+1;
                    }
                    else if (destCol[j] == gapNum+1) {
                        destCol[j] = gapNum;
                    }
                }
            }
        }
        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        for (int i = 0; i < headers.Count; i++) {
            Console.WriteLine(headers[i] + colNames[destCol[i]]);
        }
    }
}
