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
class Player    {
    static List<int[]> links = new List<int []>();
    static List<int> gateways = new List<int>();
    
    static void Main(string[] args) {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int N = int.Parse(inputs[0]); // the total number of nodes in the level, including the gateways
        int L = int.Parse(inputs[1]); // the number of links
        int E = int.Parse(inputs[2]); // the number of exit gateways
        
        
        
        for (int i = 0; i < L; i++) {
            inputs = Console.ReadLine().Split(' ');
            int N1 = int.Parse(inputs[0]); // N1 and N2 defines a link between these nodes
            int N2 = int.Parse(inputs[1]);
            links.Add(new int[] {N1, N2});
        }
        for (int i = 0; i < E; i++) {
            int EI = int.Parse(Console.ReadLine()); // the index of a gateway node
            gateways.Add(EI);
        }

        // game loop
        while (true)    {
            int SI = int.Parse(Console.ReadLine()); // The index of the node on which the Skynet agent is positioned this turn

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            string output = findBestLink(SI);

            // Example: 0 1 are the indices of the nodes you wish to sever the link between
            Console.WriteLine(output);
        }
    }
    
    static string findBestLink(int enemyIndex) {
        string output = null;
        
        Queue<int []> q = new Queue<int []>();
        //parallel array of visited indexes and the last node to get to them
        //Visited node == enemyIndex means root node reached
        List<int> L = new List<int>(); //last node before visited node
        List<int> V = new List<int>(); //visited node
        
        //build initial queue
        List<int []> linksToSearch = links.Where(x => Array.IndexOf(x, enemyIndex) != -1).ToList();
        foreach (int [] link in linksToSearch) {
            q.Enqueue(link);
        }
        L.Add(enemyIndex);
        V.Add(enemyIndex);
        
        while ((q.Count != 0) && (output == null)) {
            int [] link = q.Dequeue();
            
            //Find which node is the new and old
            int newNode, oldNode;
            if (V.IndexOf(link[0]) == -1) {
                newNode = link[0];
                oldNode = link[1];
            }
            else {
                newNode = link[1];
                oldNode = link[0];
            }
            
            //Find if new node is a gateway, if so, return the first link in the path
            if (gateways.IndexOf(newNode) != -1) {
                //TODO: return path
                List<int> finalPath = new List<int>();
                finalPath.Add(newNode);
                finalPath.Add(oldNode);

                while (finalPath.IndexOf(enemyIndex) == -1) {
                    int lastVisitedIndex = V.IndexOf(finalPath[finalPath.Count-1]);
                    int lastVisitedNode = L[lastVisitedIndex];
                    finalPath.Add(lastVisitedNode);
                    //finalPath.Add(L[V.IndexOf(finalPath[finalPath.Count -1])]);
                }
                
                output = finalPath[finalPath.Count-1] + " " + finalPath[finalPath.Count-2];
            }
            else { //Grab new links and mark new node as visited and the node that got us to that one
                   //New links must also link only to previously unvisited nodes.
                List<int []> allPossibleNewLinks = links.Where(x => (Array.IndexOf(x, newNode) != -1)).ToList();
                //List<int []> refinedNewLinks = allPossibleNewLinks.Where(x => ((V.IndexOf(x[0]) = -1) && (V.IndexOf(x[1]) = -1)) && ((L.IndexOf(x[0]) = -1) && (L.IndexOf(x[0]) = -1)));
                List<int []> refinedNewLinks = allPossibleNewLinks.Where(x => ((V.IndexOf(x[0]) == -1) && (V.IndexOf(x[1]) == -1))).ToList();
                
                foreach (int [] newLink in refinedNewLinks) {
                    q.Enqueue(newLink);
                }
            
                L.Add(oldNode);
                V.Add(newNode);
            }
            
        }
        
        return output;
    }
}
