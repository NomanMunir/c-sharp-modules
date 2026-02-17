/*
 * Exercise 00: BraiiiiiiinnnzzzZ
 * Implement the Zombie class and the following functions:
 * - NewZombie
 * - RandomChump
 */

using System;
public class Zombie
{
    // TODO: Add Name private field
    // TODO: Add Announce() method
    private string _name;
    
    Zombie (string name)
    {
        this._name = name;
    }
    public void Announce()
    {
        Console.WriteLine($"{this._name}: BraiiiiiiiinnnzzzzZ...");
    }
    public static Zombie NewZombie(string name)
    {
        return new Zombie(name);
    }

    public static void RandomChump(string name)
    {
        var z = new Zombie(name);
        z.Announce();
    }
}

class Program
{
    // TODO: Implement NewZombie(string name)
    
    // TODO: Implement RandomChump(string name)

    static void Main(string[] args)
    {
        Console.WriteLine("Creating a zombie on the Heap...");
        Zombie z = Zombie.NewZombie("HeapZ");
        z.Announce();
        Zombie.RandomChump("Localz");

        Console.WriteLine("Creating a zombie on the Stack (sort likely local variable)...");
        // RandomChump("StackZ");
    }
}
