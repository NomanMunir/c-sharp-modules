/*
 * Module 03 - Exercise 00: My Generic List
 * Implement: MyList<T> with Add, Get, Remove, Print, and Indexer
 */

// TODO: Create class MyList<T>

using System.Data;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.FileIO;

class MyList<T>
{

    private T[] _items = new T[4];
    private int _count = 0;
    private T[] Items => _items;
    private int Count => _count;

    public void Add(T item)
    {
        if (_items.Length == _count)
        {
            T[] newArry = new T[_items.Length * 2];
            Array.Copy(_items, newArry, _count);
            _items = newArry;
        }
        _items[_count] = item;
        _count++;
    }
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException($"Index {index} is out of range");
            return _items[index];

        }
        set
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException($"Index {index} is out of range");
            _items[index] = value;

        }
    }

    public T Get(int index)
    {
        if (index < 0 || index >= _count)
            throw new IndexOutOfRangeException($"Index {index} is out of range");
        return Items[index];
    }
    public bool Remove(T item)
    {
        for (int i = 0; i < _count; i++)
        {
            if (_items[i]!.Equals(item))
            {
                for (int j = i; j < _count - 1; j++)
                    _items[j] = _items[j + 1];
                _count--;
                return true;
            }
        }
        return false;
    }
    public void Print()
    {
        for (int i = 0; i < _count; i++)
        {
            Console.Write(_items[i]);
            if (i < _count - 1)
                Console.Write(", ");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
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

    }
}
