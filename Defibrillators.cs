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
        int defLat = 5;
        int defLon = 4;
        int R = 6371; //Radius of the earth in KM
        double LON = Convert.ToDouble(Console.ReadLine().Replace(",","."));// Console.Error.WriteLine(LON);
        double LAT = Convert.ToDouble(Console.ReadLine().Replace(",","."));// Console.Error.WriteLine(LAT);
        int N = int.Parse(Console.ReadLine());
        double closestDistance = int.MaxValue;
        string closestName = "";

        for (int i = 0; i < N; i++)
        {
            string DEFIB = Console.ReadLine();
            string[] defibInfo = DEFIB.Split(';');
            double defLongitude = Convert.ToDouble(defibInfo[defLon].Replace(",","."));
            double defLatitude = Convert.ToDouble(defibInfo[defLat].Replace(",","."));
            
            double x1 = defLongitude - LON;
            double x2 = (LAT+defLatitude)/2;
            x2 = Math.Cos(x2);
            double x = x1 * x2;
            
            double y = defLatitude - LAT;
            double distance = Math.Sqrt((x*x) + (y * y)) * R;
            
            if (distance < closestDistance) {
                closestDistance = distance;
                closestName = defibInfo[1];
            }
        }

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(closestName);
    }
}
