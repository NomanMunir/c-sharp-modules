// See https://aka.ms/new-console-template for more information
// TODO: Implement Megaphone behavior here!

/*
 * Goal: Read args, convert to uppercase, print result.
 * If no args, print loud noise.
 */

using System;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
            Console.WriteLine("* LOUD AND UNBEARABLE NOISE *");
        else
        {
            String result = String.Join(" ", args);
            Console.WriteLine(result.ToUpper());
        }
    }
}
