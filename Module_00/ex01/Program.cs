using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

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
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

}

public class PhoneBook
{
    private List<Contact> contactsList = new List<Contact>();
    public void PromptAddContact()
    {
        Console.Write("Enter FirstName: ");
        string? firstName = Console.ReadLine();
        if (!VerifyInput(firstName))
        {
            Console.WriteLine("Invalid first name!");
            return;
        }

        Console.Write("Enter LastName: ");
        string? lastName = Console.ReadLine();
        if (!VerifyInput(lastName))
        {
            Console.WriteLine("Invalid first name!");
            return;
        }
        Contact contact = new Contact
        {
            FirstName = firstName!,
            LastName = lastName!
        };
        contactsList.Add(contact);
    }

    public void PromptSearchContact()
    {
        Console.WriteLine("Index | First Name   |   Last Name");

        for (int i = 0; i < contactsList.Count; i++)
        {
            Contact contact = contactsList[i];
            Console.WriteLine($"{i + 1}     | {contact.FirstName}   |   {contact.LastName}");
        }
        
        string? command = Console.ReadLine();
        if (command == "Exit")
            return;
    }

    public static bool VerifyInput(string? input)
    {
        return !string.IsNullOrWhiteSpace(input);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to My Awesome Phonebook!");
        PhoneBook phoneBook = new PhoneBook();
        while (true)
        {
            Console.Write("Enter Command (ADD, SEARCH, EXIT): ");
            // TODO: Read input and handle logic
            string? command = Console.ReadLine();

            if (command == "EXIT")
                break;
            else if (command == "SEARCH")
            {
                phoneBook.PromptSearchContact();
            }
            else if (command == "ADD")
            {
                phoneBook.PromptAddContact();
            }
        }
    }
}
