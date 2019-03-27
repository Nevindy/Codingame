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
        int N = int.Parse(Console.ReadLine());
        double totalDistance = 0.0;
        List<int []> cityList = new List<int []>();
        for (int i = 0; i < N; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int X = int.Parse(inputs[0]);
            int Y = int.Parse(inputs[1]);
            cityList.Add(new int[] {X, Y});
        }

        //initialize loop
        int [] location = new int[] {cityList[0][0], cityList[0][1]};
        int [] initLoc = location;
        cityList.RemoveAt(0);
        
        while (cityList.Count > 0) {
            //find index of closest city;
            double closestDist = double.MaxValue;
            int closestIndex = 0;
            for (int i = 0; i < cityList.Count; i++) {
                double x = Math.Pow(location[0] - cityList[i][0],2);
                double y = Math.Pow(location[1] - cityList[i][1],2);
                double tempDistance = Math.Sqrt(x + y);
                
                if (tempDistance < closestDist) {
                    closestDist = tempDistance;
                    closestIndex = i;
                }
            }
            totalDistance += closestDist;
            location = new int[] {cityList[closestIndex][0], cityList[closestIndex][1]};
            cityList.RemoveAt(closestIndex);
        }

        //connect final location with initial city
        double xx = Math.Pow(location[0] - initLoc[0],2);
        double yy = Math.Pow(location[1] - initLoc[1],2);
        double tempDist = Math.Sqrt(xx + yy);
        totalDistance += tempDist;

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(Math.Round(totalDistance));
    }
}
