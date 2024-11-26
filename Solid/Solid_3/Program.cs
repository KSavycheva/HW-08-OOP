using System;

interface IShape
{
    int GetArea();
}

/*
 * тут було порушено Принцип підстановки Лісков (The Liskov Substitution Principle),
 * який каже що підтипи повинні бути замінювані базовими типами. У нашому випадку
 * Квадрат не може бути замінений базовим типом, адже площа для нього та зввичайного прямокутника
 * рахується по різному та зміст ключових даних про фігуру теж відрізняється.
 * Правильним рішенням буде використовувати свій власний інтерфейс під квадрат, що імплементує
 * інтерфейс фігури IShape.
 */

class Rectangle : IShape
{
    public int Width { get; set; }
    public int Height { get; set; }

    public int GetArea()
    {
        return Width * Height;
    }
}

class Square : IShape
{
    public int Side { get; set; }

    public int GetArea()
    {
        return Side * Side;
    }
}

class Program
{
    static void Main(string[] args)
    {
        IShape rect = new Rectangle { Width = 5, Height = 10 };
        IShape square = new Square { Side = 5 };
        Console.WriteLine(" * * * Rectangle * * * ");
        Console.WriteLine($"Area: {rect.GetArea()}");
        Console.WriteLine(" * * * Square * * * ");
        Console.WriteLine($"Area: {square.GetArea()}"); 

        Console.ReadKey();
    }
}