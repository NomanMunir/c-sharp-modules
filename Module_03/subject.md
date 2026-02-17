# Module 03: Generics & Collections

**Summary:** This module dives into Generics, the Collections framework, and C#'s standard interfaces like `IComparable` and `IEnumerable`. You'll build your own generic data structures.

## General Rules
- Use `dotnet` CLI.
- No global variables.
- Follow C# naming conventions.

---

## Exercise 00: My Generic List

**Build a type-safe container.**

Implement a generic class `MyList<T>` that mimics a simplified `List<T>`.

### Requirements
- Private `T[]` internal array (start with capacity 4).
- `int Count` property (read-only) — number of elements currently stored.
- `void Add(T item)` — appends item. If array is full, double the capacity (reallocate).
- `T Get(int index)` — returns element at index. Throw `IndexOutOfRangeException` if invalid.
- `bool Remove(T item)` — removes the first occurrence. Returns `true` if found. Use `Equals()` for comparison.
- `void Print()` — prints all elements separated by `, `.
- Indexer: `this[int index]` — allows `list[0]` syntax (get and set).

### Main
```csharp
MyList<int> numbers = new MyList<int>();
numbers.Add(42);
numbers.Add(21);
numbers.Add(7);
numbers.Print();            // 42, 21, 7

Console.WriteLine(numbers[1]);  // 21
numbers[1] = 99;
numbers.Print();            // 42, 99, 7

numbers.Remove(99);
numbers.Print();            // 42, 7

MyList<string> words = new MyList<string>();
words.Add("Hello");
words.Add("World");
words.Print();              // Hello, World
```

### Thinking
- Generics in C# are similar to C++ templates, but they are **reified** (type info preserved at runtime), not erased at compile time.
- The `where T :` constraint allows you to restrict what types can be used. You don't need it here, but explore it.
- Indexers (`this[int index]`) are C#'s way of overloading `operator[]`.

---

## Exercise 01: Sort That Out

**Implement `IComparable<T>` and use standard sorting.**

Create a `Student` class:
- Properties: `string Name`, `float Gpa`, `int Age`.
- Implement `IComparable<Student>` — sort by GPA descending. If equal GPA, sort by Name ascending.
- Override `ToString()` → `"<Name> (GPA: <Gpa>, Age: <Age>)"`.

Create a `Classroom` class:
- Contains a `List<Student>`.
- `void Enroll(Student s)` — adds a student.
- `void DisplayRoster()` — prints all students.
- `void SortByGpa()` — sorts using `List.Sort()` (which uses `IComparable`).
- `Student? FindByName(string name)` — returns student or null if not found. Use `List.Find()`.
- `List<Student> GetHonorRoll(float minGpa)` — returns students with GPA >= `minGpa`. Use `List.FindAll()`.

### Main
```csharp
Classroom cs101 = new Classroom();
cs101.Enroll(new Student("Alice", 3.8f, 21));
cs101.Enroll(new Student("Bob", 3.2f, 22));
cs101.Enroll(new Student("Charlie", 3.9f, 20));
cs101.Enroll(new Student("Diana", 3.8f, 23));

Console.WriteLine("=== Roster ===");
cs101.DisplayRoster();

cs101.SortByGpa();
Console.WriteLine("\n=== Sorted by GPA ===");
cs101.DisplayRoster();

Console.WriteLine("\n=== Honor Roll (GPA >= 3.8) ===");
foreach (Student s in cs101.GetHonorRoll(3.8f))
    Console.WriteLine(s);

Student? found = cs101.FindByName("Bob");
Console.WriteLine($"\nFound: {found}");
```

### Expected Output
```
=== Roster ===
Alice (GPA: 3.8, Age: 21)
Bob (GPA: 3.2, Age: 22)
Charlie (GPA: 3.9, Age: 20)
Diana (GPA: 3.8, Age: 23)

=== Sorted by GPA ===
Charlie (GPA: 3.9, Age: 20)
Alice (GPA: 3.8, Age: 21)
Diana (GPA: 3.8, Age: 23)
Bob (GPA: 3.2, Age: 22)

=== Honor Roll (GPA >= 3.8) ===
Charlie (GPA: 3.9, Age: 20)
Alice (GPA: 3.8, Age: 21)
Diana (GPA: 3.8, Age: 23)

Found: Bob (GPA: 3.2, Age: 22)
```

### Thinking
- `IComparable<T>` is C#'s standard sorting interface — like implementing `operator<` in C++.
- `List<T>.Sort()` uses this interface automatically.
- `List<T>.Find()` and `FindAll()` take a `Predicate<T>` (a delegate) — you'll get deeper into these in Module 04.
