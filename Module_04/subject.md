# Module 04: LINQ & Functional Programming

**Summary:** This module covers Lambdas, Delegates, Extension Methods, and LINQ — the features that make C# uniquely powerful compared to C++.

## General Rules
- Use `dotnet` CLI.
- No global variables.
- Follow C# naming conventions.

---

## Exercise 00: Delegates & Lambdas

**Functions as first-class citizens.**

### Part 1: Delegates
Create a delegate type and use it:

```csharp
public delegate int MathOperation(int a, int b);
```

Implement at least three functions matching this signature: `Add`, `Subtract`, `Multiply`.

Write a method `void ApplyAndPrint(int a, int b, MathOperation op)` that calls the delegate and prints the result.

### Part 2: Lambdas
Refactor the above to use **lambda expressions** instead of named methods:

```csharp
MathOperation add = (a, b) => a + b;
```

### Part 3: Func<> and Action<>
Rewrite `ApplyAndPrint` to use the built-in `Func<int, int, int>` instead of a custom delegate. Also create an `Action<string>` that prints a decorated message.

### Main
```csharp
// Part 1: Named delegates
ApplyAndPrint(10, 5, Add);        // Result: 15
ApplyAndPrint(10, 5, Subtract);   // Result: 5

// Part 2: Lambda
MathOperation multiply = (a, b) => a * b;
ApplyAndPrint(10, 5, multiply);   // Result: 50

// Part 3: Func<>
Func<int, int, int> power = (baseNum, exp) =>
{
    int result = 1;
    for (int i = 0; i < exp; i++) result *= baseNum;
    return result;
};
Console.WriteLine(power(2, 10));  // 1024

Action<string> shout = msg => Console.WriteLine($"📢 {msg.ToUpper()}!");
shout("hello world");             // 📢 HELLO WORLD!
```

### Thinking
- C++ has `std::function` and lambdas — C# `Func<>` and `Action<>` serve the same purpose but are more integrated.
- `Func<T1, T2, TResult>` = function with return. `Action<T>` = function without return (`void`).
- Delegates are the *foundation* that LINQ is built on.

---

## Exercise 01: LINQ Master

**Query data like a boss.**

You are given a `List<Employee>`:

```csharp
public class Employee
{
    public string Name { get; set; } = "";
    public string Department { get; set; } = "";
    public decimal Salary { get; set; }
    public int YearsOfExperience { get; set; }
}
```

Populate a list with at least 10 employees across different departments.

### Tasks (implement each using LINQ)

1. **Filter**: Get all employees with salary > 60000.
2. **Sort**: Sort employees by name alphabetically.
3. **Select/Map**: Get a list of just employee names (as `List<string>`).
4. **GroupBy**: Group employees by department. Print each group with its members.
5. **Aggregate**: Calculate the average salary across all employees.
6. **Any/All**: Check if any employee has > 10 years experience. Check if all employees have salary > 30000.
7. **First/FirstOrDefault**: Find the first employee in "Engineering". Find the first in "Nonexistent" (handle gracefully).
8. **Chain**: In one LINQ chain — get employees from "Engineering" with > 5 years experience, sorted by salary descending, and select just their names.

### Expected
Print the result of each task clearly labeled.

### Two Syntaxes
Implement at least **two tasks** using both LINQ syntaxes:

**Method syntax** (fluent):
```csharp
var result = employees.Where(e => e.Salary > 60000).OrderBy(e => e.Name);
```

**Query syntax** (SQL-like):
```csharp
var result = from e in employees
             where e.Salary > 60000
             orderby e.Name
             select e;
```

### Thinking
- LINQ is C#'s killer feature — nothing like it exists in standard C++.
- It works on anything implementing `IEnumerable<T>`.
- `var` is useful here — let the compiler infer complex return types.
- Lazy evaluation: LINQ queries are **deferred** until you enumerate them (`.ToList()`, `foreach`, etc.).
