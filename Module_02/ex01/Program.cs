/*
 * Module 02 - Exercise 01: Interface Segregation
 * Implement: IMovable, IAttackable, IHealable, Warrior, Turret
 */

// TODO: Create interfaces IMovable, IAttackable, IHealable
// TODO: Create class Warrior (implements all three)
// TODO: Create class Turret (implements only IAttackable)

using System.Runtime.CompilerServices;

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

class Warrior(string name) : IMovable, IAttackable, IHealable
{
    public string Name { get; set; } = name;
    public int Health { get; set; } = 100;
    public int Damage { get; set; } = 25;
    public string Position { get; set; } = "Home";

    public void Move()
    {
        Console.WriteLine($"{Name} moves to the battlefield.");
        Position = "Battlefield";
    }

    public void Attack(string target)
    {
        if (Damage > 0)
            Console.WriteLine($"{Name} attacks {target} for {Damage} damage!");
        else
            Console.WriteLine($"{target} is dead!!");
    }

    public void Heal(int amount)
    {
        Health = Math.Min(100, Health + amount);
        Console.WriteLine($"{Name} heals for {amount}. Health: {Health}");
    }
}

class Turret(string name) : IAttackable
{
    public string Name { get; set; } = name;
    public int Damage { get; set; } = 50;

    public void Attack(string target)
    {
        Console.WriteLine($"Turret {Name} fires at {target} for {Damage} damage!");
    }
}


class Program
{
    static void Main(string[] args)
    {
        Warrior w = new("Aragorn");
        Turret t = new("Sentinel");

        w.Move();
        w.Attack("Goblin");
        w.Heal(20);

        t.Attack("Orc");

        // Demonstrate interface polymorphism:
        List<IAttackable> attackers = [w, t];
        foreach (IAttackable a in attackers)
            a.Attack("Dragon");
    }
}
