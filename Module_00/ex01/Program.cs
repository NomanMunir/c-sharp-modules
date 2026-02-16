using System;
using System.Collections.Generic;

/*
 * Exercise 01: My Awesome Phonebook
 * Expected behavior:
 * - ADD: Add a contact
 * - SEARCH: Search for a contact
 * - EXIT: Quit
 */

public class Contact
{
    // TODO: Add properties (FirstName, LastName, etc.)
}

public class PhoneBook
{
    // TODO: Add list of contacts and methods to Add/Display
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to My Awesome Phonebook!");
        
        while (true)
        {
            Console.Write("Enter Command (ADD, SEARCH, EXIT): ");
            // TODO: Read input and handle logic
            string? command = Console.ReadLine();
            
            if (command == "EXIT")
                break;
            else if (command == "SEARCH")
            {
                
            }
            else if (command == "ADD")
            {
                
            }
        }
    }
}
