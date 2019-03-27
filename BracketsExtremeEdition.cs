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
        string expression = Console.ReadLine();
        Stack<char> charStack = new Stack<char>();
        string output = "true";
        foreach (char c in expression) {
            try {
            switch (c) {
                case '[':
                case '{':
                case '(':
                    charStack.Push(c);
                    break;
                case ']':
                    if (charStack.Pop() != '[')
                        output = "false";
                    break;
                case '}':
                    if (charStack.Pop() != '{')
                        output = "false";
                    break;
                case ')':
                    if (charStack.Pop() != '(')
                        output = "false";
                    break;
            }
            }
            catch (System.InvalidOperationException e) {
                output = "false";
            }
        }
        if (charStack.Count != 0) {
            output = "false";
        }
        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(output);
    }
}
