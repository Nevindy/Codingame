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
        int N = int.Parse(Console.ReadLine());
        int L = int.Parse(Console.ReadLine());
        List<StringBuilder> map = new List<StringBuilder>();
        List<int[]> candles = new List<int[]>();
        int candleSide = (L-1) * 2;
        int spaces = 0;


        for (int i = 0; i < N; i++) {
            string LINE = Console.ReadLine();
            map.Add(new StringBuilder(LINE));
            if (LINE.IndexOf('C') != -1) {
                int candleIndex = 0;
                while(LINE.IndexOf('C', candleIndex) != -1) {
                    candles.Add(new int[] {LINE.IndexOf('C', candleIndex), i});
                    candleIndex = LINE.IndexOf('C', candleIndex) + 1;
                }
            }
        }

        //Change map around candles based around light intensity
        for (int i = 0; i < candles.Count; i++) {
            for (int x = (candles[i][0] - candleSide); x <= (candles[i][0] + candleSide); x+=2) {
                if (x >= 0 && x <= map[candles[i][1]].Length) { //X value has to be on the map
                    for (int y = (candles[i][1] - (candleSide/2)); y <= (candles[i][1] + (candleSide/2)); y++) {
                        if (y >= 0 && y < map.Count) { //Y value has to be on the map
                            if (map[y][x] == 'X') {
                                map[y][x] = '1'; //intensity handled by candleSide
                            }
                        }
                    }
                }
            }
        }
        
        //calculate hiding spots
        for (int i = 0; i < map.Count; i++) {
            for (int j = 0; j < map[i].Length; j++) {
                if (map[i][j] == 'X') {
                    spaces += 1;
                }
            }
        }

        Console.WriteLine(spaces);
    }
}
