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
        int n = int.Parse(Console.ReadLine()); // the number of cards for player 1
        List<string> deck1 = new List<string>();
        List<string> deck2 = new List<string>();
        int rounds = 0;
        string winner = "PAT"; //default to draw, redo once a winner is declared
        char[] suits = new char[]{'C', 'D', 'H', 'S'};
        string[] cardStrengths = new string[] {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
        for (int i = 0; i < n; i++) {
            string cardp1 = Console.ReadLine(); // the n cards of player 1
            deck1.Add(cardp1);
        }
        int m = int.Parse(Console.ReadLine()); // the number of cards for player 2
        for (int i = 0; i < m; i++) {
            string cardp2 = Console.ReadLine(); // the m cards of player 2
            deck2.Add(cardp2);
        }

        while((deck1.Count != 0) && (deck2.Count != 0)) {
            rounds += 1;
            //only grab value of the card, suits don't impact results
            string[] temp = deck1[0].Split(suits, StringSplitOptions.RemoveEmptyEntries);
            string cardVal1 = temp[0];
            temp = deck2[0].Split(suits, StringSplitOptions.RemoveEmptyEntries);
            string cardVal2 = temp[0];
            
            //compare card values
            if (String.Compare(cardVal1, cardVal2) != 0) {
                //simple value battle
                if (Array.IndexOf(cardStrengths, cardVal1) > Array.IndexOf(cardStrengths, cardVal2)) {
                    deck1.Add(deck1[0]);
                    deck1.Add(deck2[0]);
                    deck1.RemoveAt(0);
                    deck2.RemoveAt(0);
                }
                else {
                    deck2.Add(deck1[0]);
                    deck2.Add(deck2[0]);
                    deck1.RemoveAt(0);
                    deck2.RemoveAt(0);
                }
            }
            else { //war were declared
                bool winnerDeclared = false;
                int warCardCounter = 4; //5th index of the war card: 0: card currently down, 1-3: cards face down, 4: war card
                while (!winnerDeclared) {
                    if (deck1.Count < warCardCounter || deck2.Count < warCardCounter) {
                        //draw, exit loop and end game
                        break;
                    }
                    
                    string warCard1 = deck1[warCardCounter].Split(suits, StringSplitOptions.RemoveEmptyEntries)[0];
                    string warCard2 = deck2[warCardCounter].Split(suits, StringSplitOptions.RemoveEmptyEntries)[0];

                    if (Array.IndexOf(cardStrengths, warCard1) > Array.IndexOf(cardStrengths, warCard2)) { //Deck1 wins
                        //deck1 cards always moved first
                        for (int i = 0; i <= warCardCounter; i++) {
                            string tempS = deck1[0];
                            deck1.RemoveAt(0);
                            deck1.Add(tempS);
                        }
                        for (int i = 0; i <= warCardCounter; i++) {
                            deck1.Add(deck2[0]);
                            deck2.RemoveAt(0);
                        }
                        winnerDeclared = true;
                    }
                    else if (Array.IndexOf(cardStrengths, warCard1) < Array.IndexOf(cardStrengths, warCard2)) { //Deck2 wins
                        //deck1 cards always moved first
                        for (int i = 0; i <= warCardCounter; i++) {
                            deck2.Add(deck1[0]);
                            deck1.RemoveAt(0);
                        }
                        for (int i = 0; i <= warCardCounter; i++) {
                            string tempS = deck2[0];
                            deck2.RemoveAt(0);
                            deck2.Add(tempS);
                        }
                        winnerDeclared = true;
                    }
                    else {} //Tie, the war continues
                    
                    warCardCounter += 4; //3 face down cards, 1 new war card
                }
                if (!winnerDeclared) {
                    //exit game with a tie
                    break;
                }
            }
        }

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        if (deck1.Count == 0) {
            winner = "2 " + rounds.ToString();
        }
        else if (deck2.Count == 0) {
            winner = "1 " + rounds.ToString();
        }

        Console.WriteLine(winner);
    }
}
