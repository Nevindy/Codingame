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
    static void Main(string[] args) {
        int n = int.Parse(Console.ReadLine());
        List<string> answers = new List<string>();
        
        for (int i = 0; i < n; i++) {
            List<string> pointNames = new List<string>();
            List<int []> points = new List<int []>();
            int [] tempPoint;
            
            string[] inputs = Console.ReadLine().Split(' ');
            pointNames.Add(inputs[0]);

            tempPoint = new int[] {Convert.ToInt32(inputs[1]), Convert.ToInt32(inputs[2])};
            points.Add(tempPoint);
            pointNames.Add(inputs[3]);

            tempPoint = new int[] {Convert.ToInt32(inputs[4]), Convert.ToInt32(inputs[5])};
            points.Add(tempPoint);
            pointNames.Add(inputs[6]);

            tempPoint = new int[] {Convert.ToInt32(inputs[7]), Convert.ToInt32(inputs[8])};
            points.Add(tempPoint);
            pointNames.Add(inputs[9]);

            tempPoint = new int[] {Convert.ToInt32(inputs[10]), Convert.ToInt32(inputs[11])};
            points.Add(tempPoint);

            
            answers.Add(calcQuadType(pointNames, points));
        }
        for (int i = 0; i < n; i++) {

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            Console.WriteLine(answers[i]);
        }
    }
    
    static string calcQuadType(List<string> pointNames, List<int []> points) {
        string output = "";
        bool allCorners90 = true; //initialized to true as it's easier to prove false
        bool oppositesCongruent = false;
        bool allCongruent = false;
        double [] distances = new double [] {0.0, 0.0, 0.0, 0.0};
        double [] angles = new double [] {0.0, 0.0, 0.0, 0.0};
        
        //get quad name
        for(int i = 0; i < pointNames.Count; i++) {
            output += pointNames[i];
        }
        
        //calculate the lengths of all sides
        distances[0] = distance(points[0], points[1]);
        distances[1] = distance(points[1], points[2]);
        distances[2] = distance(points[2], points[3]);
        distances[3] = distance(points[3], points[0]);
        
        
        //calculate if opposite sides are congruent
        if (distances[0] == distances[2] && distances[1] == distances[3]) {
            oppositesCongruent = true;
        }
        if (oppositesCongruent && (distances[1] == distances[2] && distances[0] == distances[3])) {
            allCongruent = true;
        }
        
        //calculate all angles
        angles[0] = angle(points[3], points[0], points[1]);
        angles[1] = angle(points[0], points[1], points[2]);
        angles[2] = angle(points[1], points[2], points[3]);
        angles[3] = angle(points[2], points[3], points[0]);
        for (int i = 0; i < angles.Length; i++) {
            //Console.Error.WriteLine(Convert.ToInt32(angles[i]) + " " + angles[i]);
            if (Convert.ToInt32(angles[i]) != 90) {
                allCorners90 = false;
            }
        }
        
        if (oppositesCongruent) {
            if (allCorners90) {
                if (allCongruent) {
                    output += " is a square.";
                }
                if (output.Length == 4) {
                    output += " is a rectangle.";
                }
            }
            if (allCongruent) {
                if (output.Length == 4) {
                    output += " is a rhombus.";
                }
            }
            if (output.Length == 4) {
                output += " is a parallelogram.";
            }
        }
        else {
            output += " is a quadrilateral.";
        }
        
        return output;
    }
    
    static double distance(int[] p1, int[] p2) {
        double dist = 0.0;
        
        double dX = p2[0] - p1[0];
        double dY = p2[1] - p1[1];
        
        dist = Math.Pow(dX, 2) + Math.Pow(dY, 2);
        dist = Math.Sqrt(dist);
        
        return dist;
    }
    
    //find angle of p1p2p3
    //
    // equation theta = cos-1((a^2 + c^2 - b^2)/(2ac))
    static double angle(int[] p1, int[] p2, int[] p3) {
        double retAngle = 0.0;
        
        double a = distance(p2,p3);
        double b = distance(p1,p3);
        double c = distance(p1,p2);
        
        double temp = Math.Pow(a, 2) + Math.Pow(c, 2) - Math.Pow(b, 2);
        temp = temp / (2 * a * c);
        retAngle = Math.Acos(temp);
        
        //convert from radians to degrees
        retAngle = retAngle * (180/Math.PI);
        
        return retAngle;
    }
}
