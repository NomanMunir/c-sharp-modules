# Module 02: OOP — Polymorphism & Interfaces

**Summary:** This module explores inheritance, polymorphism, operator overloading, and the difference between `abstract class` and `interface`. You'll build a class hierarchy and see how C# handles virtual dispatch.

## General Rules
- Use `dotnet` CLI.
- No global variables.
- Follow C# naming conventions.

---

## Exercise 00: The Animal Farm

**Inheritance and virtual methods.**

Create the following class hierarchy:

```
        Animal (abstract)
       /      \
     Dog      Cat
```

### `Animal` (abstract class)
- Protected field `string _name`.
- Constructor that takes `string name`.
- Abstract method `string MakeSound()`.
- Concrete method `void Announce()` — prints `<name> says <MakeSound()>!`.

### `Dog : Animal`
- Constructor that takes `string name` and passes it to `base(name)`.
- Override `MakeSound()` → returns `"Woof"`.

### `Cat : Animal`
- Constructor that takes `string name` and passes it to `base(name)`.
- Override `MakeSound()` → returns `"Meow"`.

### Main
```csharp
Animal[] animals = new Animal[]
{
    new Dog("Rex"),
    new Cat("Whiskers"),
    new Dog("Buddy"),
    new Cat("Luna")
};

foreach (Animal a in animals)
    a.Announce();
```

### Expected Output
```
Rex says Woof!
Whiskers says Meow!
Buddy says Woof!
Luna says Meow!
```

### Thinking
- `Animal` cannot be instantiated directly (`abstract`).
- `virtual` / `override` in C# is **explicit** — unlike C++ where all virtual overrides are implicit.
- The `override` keyword is **required** in C#. Forgetting it creates a *new* method instead of overriding.

---

## Exercise 01: Interface Segregation

**Interfaces and multiple implementation.**

Create the following interfaces and classes:

### Interfaces
```csharp
public interface IMovable
{
    void Move();
    string Position { get; }
}

public interface IAttackable
{
    void Attack(string target);
    int Damage { get; }
}

public interface IHealable
{
    void Heal(int amount);
    int Health { get; }
}
```

### Classes

**`Warrior`** — implements `IMovable`, `IAttackable`, `IHealable`
- Has `Name`, `Health` (starts at 100), `Damage` (starts at 25), and `Position` (starts at `"Home"`).
- `Move()` prints `<Name> moves to the battlefield.` and updates Position to `"Battlefield"`.
- `Attack(target)` prints `<Name> attacks <target> for <Damage> damage!`.
- `Heal(amount)` increases Health (max 100) and prints `<Name> heals for <amount>. Health: <Health>`.

**`Turret`** — implements only `IAttackable`
- Has `Name`, `Damage` (starts at 50).
- `Attack(target)` prints `Turret <Name> fires at <target> for <Damage> damage!`.
- Cannot move, cannot heal. The interface system enforces this.

### Main
```csharp
Warrior w = new Warrior("Aragorn");
Turret t = new Turret("Sentinel");

w.Move();
w.Attack("Goblin");
w.Heal(20);

t.Attack("Orc");

// Demonstrate interface polymorphism:
List<IAttackable> attackers = new List<IAttackable> { w, t };
foreach (IAttackable a in attackers)
    a.Attack("Dragon");
```

### Thinking
- In C++, you'd use multiple inheritance or pure virtual classes. C# uses **interfaces** for this.
- A class can implement **multiple interfaces** but inherit only **one class**.
- Interfaces define a *contract* — "what can this object do?" vs abstract classes which say "what kind of thing is this?".

---

## Exercise 02: Operator Overloading

**Make your objects first-class citizens.**

Create a `Vector2` struct (yes, struct! Value type):

```csharp
public struct Vector2
{
    public float X { get; }
    public float Y { get; }
}
```

Implement the following:
- Constructor `Vector2(float x, float y)`.
- Override `ToString()` → returns `"(X, Y)"` (e.g., `"(3.5, 2.1)"`).
- Override `Equals(object? obj)` and `GetHashCode()`.
- Operator `+` → adds two vectors.
- Operator `-` → subtracts two vectors.
- Operator `*` → scalar multiplication (`Vector2 * float`).
- Operator `==` and `!=`.

### Main
```csharp
Vector2 a = new Vector2(1.0f, 2.0f);
Vector2 b = new Vector2(3.0f, 4.0f);

Console.WriteLine(a + b);       // (4, 6)
Console.WriteLine(a - b);       // (-2, -2)
Console.WriteLine(a * 3.0f);    // (3, 6)
Console.WriteLine(a == b);      // False
Console.WriteLine(a != b);      // True

Vector2 c = new Vector2(1.0f, 2.0f);
Console.WriteLine(a == c);      // True
```

### Thinking
- `struct` in C# is a **value type** (lives on the stack, copied on assignment). Perfect for small data like vectors.
- Operator overloading in C# uses `public static` methods — slightly different syntax than C++.
- When overloading `==`, you **must** also override `Equals()` and `GetHashCode()`, or the compiler warns you.
