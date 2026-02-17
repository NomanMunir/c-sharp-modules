/*
 * Module 02 - Exercise 02: Operator Overloading
 * Implement: Vector2 struct with operator +, -, *, ==, !=
 */

// TODO: Create struct Vector2

using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

public struct Vector2(float x, float y)
{
    public float X { get; } = x;
    public float Y { get; } = y;

    public override string ToString()
    {
        return $"({X}, {Y})";
    }
    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is Vector2 v && this == v;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    public static Vector2 operator +(Vector2 a, Vector2 b)
    {
        return new Vector2(a.X + b.X, a.Y + b.Y);
    }

    public static Vector2 operator -(Vector2 a, Vector2 b)
    {
        return new Vector2(a.X - b.X, a.Y - b.Y);
    }
    public static Vector2 operator *(Vector2 a, float scalar)
    {
        return new Vector2(a.X * scalar, a.Y * scalar);
    }
    public static bool operator ==(Vector2 a, Vector2 b)
    {
        return a.X == b.X && a.Y == b.Y;
    }
    public static bool operator !=(Vector2 a, Vector2 b)
    {
        return !(a == b);
    }

}
class Program
{
    static void Main(string[] args)
    {
        Vector2 a = new(1.0f, 2.0f);
        Vector2 b = new(3.0f, 4.0f);

        Console.WriteLine(a + b);       // (4, 6)
        Console.WriteLine(a - b);       // (-2, -2)
        Console.WriteLine(a * 3.0f);    // (3, 6)
        Console.WriteLine(a == b);      // False
        Console.WriteLine(a != b);      // True

        Vector2 c = new(1.0f, 2.0f);
        Console.WriteLine(a == c);      // True
    }
}
