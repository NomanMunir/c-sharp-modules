/*
 * Module 02 - Exercise 00: The Animal Farm
 * Implement: Animal (abstract), Dog, Cat
 */

// TODO: Create abstract class Animal
// TODO: Create class Dog : Animal
// TODO: Create class Cat : Animal


using System.ComponentModel;

abstract class Animal
{
    protected string _name;

    public Animal(string name)
    {
        _name = name;
    }

    public abstract string MakeSound();
    public void Announce()
    {
        Console.WriteLine($"{_name} says {MakeSound()}!");
    }
}

class Dog : Animal
{
    public Dog(string name) : base(name)
    {
    }

    public override string MakeSound() => "Woof";
}

class Cat : Animal
{
    public Cat(string name) : base(name)
    {
    }

    public override string MakeSound() => "Meow";
}


class Program
{
    static void Main(string[] args)
    {
        Animal[] animals = new Animal[]
        {
            new Dog("Rex"),
            new Cat("Whiskers"),
            new Dog("Buddy"),
            new Cat("Luna")
        };

        foreach (Animal a in animals)
            a.Announce();

    }
}
