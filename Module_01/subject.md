# Module 01: Memory, References, and Classes

**Summary:** This module covers memory management (the C# way), references vs values, and more advanced class features.

## General Rules
- Use `dotnet` CLI.
- No global variables.
- Strict typing.

---

## Exercise 00: BraiiiiiiinnnzzzZ

**Memory is managed, but you still need to understand it.**

Create a `Zombie` class.
- It has a private `Name`.
- It has a method `Announce()` which prints `<name>: BraiiiiiiinnnzzzZ...`.
- Implement a method `static Zombie NewZombie(string name)`:
    - It creates a zombie, names it, and returns it.
    - This zombie should be usable outside the function scope.
- Implement a method `static void RandomChump(string name)`:
    - It creates a zombie, names it, and the zombie announces itself.
    - This zombie is created locally and not returned. (In C#, the GC eventually collects it).

### Hints
- In C++, you had to worry about stack vs heap ( `new` ).
- In C#, `class` is *always* a Reference Type (Heap).
- `struct` is a Value Type (Stack).
- Observe how `NewZombie` returns a reference to the object on the heap.
- Observe how `RandomChump`'s zombie is also on the heap, but the reference is lost after the method ends.

---

## Exercise 01: Unnecessary Violence

**References and Properties.**

Create a `Weapon` class:
- Has a `Type` property (string).
- Has a `GetType()` and `SetType()` method (or just use the Property! It's C#).
    - Actually, use a Property `Type` but demonstrate how passing the Weapon to a Human allows the Human to use logically the *same* object.

Create two classes: `HumanA` and `HumanB`.
- Both have a `Name` and a `Weapon`.
- `Attack()` method prints: `<name> attacks with their <weapon type>`.
- `HumanA` takes the `Weapon` in its constructor.
- `HumanB` does NOT take the `Weapon` in its constructor. It has `SetWeapon()`.

### Main
```csharp
Weapon club = new Weapon("crude spiked club");

HumanA bob = new HumanA("Bob", club);
bob.Attack();
club.SetType("some other type of club");
bob.Attack();

Weapon club2 = new Weapon("crude spiked club");
HumanB jim = new HumanB("Jim");
jim.SetWeapon(club2);
jim.Attack();
club2.SetType("some other type of club");
jim.Attack();
```
### Expected Output
```text
Bob attacks with their crude spiked club
Bob attacks with their some other type of club
Jim attacks with their crude spiked club
Jim attacks with their some other type of club
```

### Thinking
- In C++, you used pointers or references.
- In C#, `class` variables are *references* by default.
- So `HumanA` holds a reference to `club`. Changes to `club` are reflected in `HumanA`.
- This exercise demonstrates that assignment copying of a class variable copies the *reference*, not the object.
