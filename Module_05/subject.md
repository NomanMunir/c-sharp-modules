# Module 05: Exceptions, IDisposable & File I/O

**Summary:** This module covers error handling the C# way, resource management with `using`, and file operations including JSON serialization.

## General Rules
- Use `dotnet` CLI.
- No global variables.
- Follow C# naming conventions.
- **Zero crashes** — handle all edge cases gracefully.

---

## Exercise 00: Custom Exceptions & Error Handling

**No more segfaults — welcome to managed exceptions.**

### Part 1: Custom Exception
Create a custom exception class `GradeTooHighException` and `GradeTooLowException`, both inheriting from `Exception`.

Create a `Bureaucrat` class:
- `string Name` (read-only, set in constructor).
- `int Grade` (1 = highest, 150 = lowest).
- Constructor throws `GradeTooHighException` if grade < 1, `GradeTooLowException` if grade > 150.
- `void IncrementGrade()` — decreases grade number (moves up). Throws if goes above 1.
- `void DecrementGrade()` — increases grade number (moves down). Throws if goes below 150.
- Override `ToString()` → `"<Name>, bureaucrat grade <Grade>"`.

### Part 2: Safe Execution
In `Main`, wrap **every** creation and grade change in `try-catch` blocks. Print the exception message. The program must **never crash**.

### Main
```csharp
try
{
    Bureaucrat b1 = new Bureaucrat("Alice", 1);
    Console.WriteLine(b1);
    b1.IncrementGrade();  // Should throw
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

try
{
    Bureaucrat b2 = new Bureaucrat("Bob", 151);  // Should throw
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

Bureaucrat b3 = new Bureaucrat("Charlie", 75);
Console.WriteLine(b3);
b3.IncrementGrade();
Console.WriteLine(b3);
```

### Expected Output
```
Alice, bureaucrat grade 1
Error: Grade too high
Error: Grade too low
Charlie, bureaucrat grade 75
Charlie, bureaucrat grade 74
```

### Thinking
- In C++, exceptions are often avoided. In C#, they're the standard error handling mechanism.
- Custom exceptions inherit from `Exception` or `ApplicationException`.
- Always provide meaningful messages.
- If you come from 42, think of this like checking `malloc` returns — but with structure.

---

## Exercise 01: File Manager

**IDisposable, using, and JSON.**

Build a simple file-based contact manager that saves/loads contacts as JSON.

### `ContactManager` class
- Implements `IDisposable`.
- Maintains a `List<Contact>` in memory.
- `string FilePath` — path to the JSON file.
- Constructor takes `string filePath`. If the file exists, load contacts from it.
- `void AddContact(string name, string email)` — adds a contact.
- `void ListContacts()` — prints all contacts.
- `void Save()` — writes all contacts to the file as JSON.
- `void Dispose()` — calls `Save()` and prints `"ContactManager disposed. Data saved."`.

### `Contact` class
```csharp
public class Contact
{
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
}
```

### Main — use `using` statement
```csharp
using (ContactManager cm = new ContactManager("contacts.json"))
{
    cm.AddContact("Alice", "alice@example.com");
    cm.AddContact("Bob", "bob@42.fr");
    cm.ListContacts();
}
// Dispose is called automatically here

// Verify persistence:
using (ContactManager cm2 = new ContactManager("contacts.json"))
{
    Console.WriteLine("\n=== Loaded from file ===");
    cm2.ListContacts();
}
```

### Hints
- Use `System.Text.Json` (built-in, no NuGet needed).
- `JsonSerializer.Serialize()` and `JsonSerializer.Deserialize<T>()`.
- `File.ReadAllText()`, `File.WriteAllText()`.
- Wrap file I/O in `try-catch` — files might not exist, be locked, etc.

### Expected Output
```
Alice - alice@example.com
Bob - bob@42.fr
ContactManager disposed. Data saved.

=== Loaded from file ===
Alice - alice@example.com
Bob - bob@42.fr
ContactManager disposed. Data saved.
```

### Thinking
- `IDisposable` is C#'s answer to RAII (Resource Acquisition Is Initialization) from C++.
- The `using` statement guarantees `Dispose()` is called, even if an exception is thrown — like a destructor, but explicit.
- `System.Text.Json` is the modern, built-in JSON library (no need for Newtonsoft for simple cases).
