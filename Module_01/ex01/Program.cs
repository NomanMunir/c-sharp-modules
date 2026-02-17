/*
 * Exercise 01: Unnecessary Violence
 * Implement Weapon, HumanA and HumanB
 */

using System.Diagnostics.Contracts;

public class Weapon
{
    // TODO: Type property
    public string Type { get; set; } = String.Empty;
    public Weapon(string type)
    {
        Type = type;
    }
    public void SetType(string type)
    {
        Type = type;
    }
}

public class HumanA
{
    // TODO: Constructor taking Name and Weapon
    // TODO: Attack()
    private string _name;
    private Weapon _weapon;
    public HumanA(string name, Weapon weapon)
    {
        _name = name;
        _weapon = weapon;
    }
    public void Attack()
    {
        Console.WriteLine($"{_name} attacks with their {_weapon.Type}");
    }
}

public class HumanB
{
    private string _name;
    private Weapon _weapon;

    public HumanB(string name)
    {
        _name = name;
        _weapon = new Weapon("");
    }
    public void Attack()
    {
        Console.WriteLine($"{_name} attacks with their {_weapon.Type}");
    }
    public void SetWeapon(Weapon weapon)
    {
        _weapon = weapon;
    }

    // TODO: Constructor taking Name
    // TODO: SetWeapon()
    // TODO: Attack()
}

class Program
{
    static void Main(string[] args)
    {
        // Uncomment when classes are ready
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

    }
}
