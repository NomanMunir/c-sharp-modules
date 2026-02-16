# Module 00: Basics of C# and .NET

**Summary:** This module is designed to help you get started with C# and understand the basic differences between C++ and C#. You will learn about Namespaces, Classes, Console I/O, and Strings.

## General Rules
- Use the `dotnet` CLI to create and run your projects.
- Recommended IDE: Visual Studio Code or Visual Studio.
- No global variables.
- Follow standard C# naming conventions (PascalCase for methods and classes, camelCase for local variables).

---

## Exercise 00: Megaphone

**Turn off that noise!**

Write a program that takes a string as an argument and prints it in uppercase.
- If there are multiple arguments, join them with a space.
- If there are no arguments, print `* LOUD AND UNBEARABLE NOISE *`.
- You must strip leading and trailing whitespace from the final output if needed (though `String.Join` usually handles spacing well).

### Expected Output
```sh
$> dotnet run "shhhhh... I think the students are asleep..."
SHHHHH... I THINK THE STUDENTS ARE ASLEEP...

$> dotnet run Damnit " ! " "Sorry students, I thought this thing was off."
DAMNIT ! SORRY STUDENTS, I THOUGHT THIS THING WAS OFF.

$> dotnet run
* LOUD AND UNBEARABLE NOISE *
```

### Hints
- Look up `args` in `Main`.
- `String.ToUpper()`.
- `Console.WriteLine()`.
- `foreach` loops in C#.

---

## Exercise 01: My Awesome Phonebook

**The 80s are back!**

Create a shitty phonebook program. It should behave like a piece of software from the 80s.
You must have a `Contact` class and a `PhoneBook` class.

### The Program
The program handles a Read-Eval-Print Loop (REPL) that accepts the following commands:
- `EXIT`: The program quits and the contacts are lost forever!
- `ADD`: Save a new contact.
    - If the phonebook is full (you decide the limit, e.g., 8 contacts), replace the oldest one.
    - Fields: `FirstName`, `LastName`, `Nickname`, `PhoneNumber`.
    - You must validate that fields are not empty.
- `SEARCH`: Display a specific contact.
    - Display a list of the available contacts (index, first name, last name, nickname).
    - Each column must be 10 characters wide.
    - Separated by a pipe character `|`.
    - Right-aligned text.
    - If text is longer than 10 characters, usually truncate it and replace the last displayable character with a dot `.` (e.g., `"Christopher"` becomes `"Christophe."`).
    - The program then asks later for the `index` of the entry to display. If the index is invalid or out of range, handle it gracefully.

### Hints
- `Console.ReadLine()`
- `String.Format` or Interpolated Strings `$"{var,10}"`.
- Properties structure: `public string Name { get; set; }`.
- `List<Contact>` vs `Contact[]`.
- `DateTime`? (Not needed but cool).

### Example
```text
$> dotnet run
Enter Command: ADD
First Name: John
Last Name: Doe
Nickname: Johnny
Phone Number: 1234567890

Enter Command: SEARCH
|     Index|First Name| Last Name|  Nickname|
|         0|      John|       Doe|    Johnny|
Index to view: 0
First Name: John
Last Name: Doe
Nickname: Johnny
Phone Number: 1234567890

Enter Command: EXIT
$>
```
