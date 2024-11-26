using System;
using System.Collections.Generic;
/*Даний інтерфейс поганий тим, що він включає занадто багато методів.
 А що, якщо наш клас товарів не може мати знижок або промокодом, або для нього немає сенсу встановлювати матеріал з 
 якого зроблений (наприклад, для книг). Таким чином, щоб не реалізовувати в кожному класі невикористовувані в ньому методи, краще 
розбити інтерфейс на кілька дрібних і кожним конкретним класом реалізовувати потрібні інтерфейси.
Перепишіть, розбивши інтерфейс на декілька інтерфейсів, керуючись принципом розділення інтерфейсу. 
Опишіть класи книжки (розмір та колір не потрібні, але потрібна ціна та знижки) та верхній одяг (колір, розмір, ціна знижка),
які реалізують притаманні їм інтерфейси.

(P.s. тут було порушено принцип розділення інтерфейсу (The Interface Segregation Principle), що каже: клієнт не повинен залежати від
методів, які він не використовує.)
 */

namespace Solid4
{

interface IPriceable
{
    void SetPrice(double price);
    double Price { get; }
}

interface IDiscountPossible
{
    void ApplyDiscount(double discount);
    double GetDiscountedPrice();
}

interface IColorable
{
    void SetColor(byte color);
}

interface ISizeable
{
    void SetSize(byte size);
}

class Item : IPriceable
{
    private string _name;
    private double _price;

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public double Price => _price;

    public void SetPrice(double price)
    {
        _price = price;
    }
}

    class Order
    {
        private List<Item> _itemList = new List<Item>();

        public List<Item> ItemList
        {
            get => _itemList;
            set => _itemList = value;
        }

        public void AddItem(Item item)
        {
            _itemList.Add(item);
        }

        public void DeleteItem(Item item)
        {
            _itemList.Remove(item);
        }

        public double CalculateTotalSum()
        {
            double total = 0;
            foreach (Item item in _itemList)
            {
                if (item is IDiscountPossible discountableItem)
                    total += discountableItem.GetDiscountedPrice();
                else
                    total += item.Price;
            }
            return total;
        }
    }

    class OrderViewer
{
    public void PrintOrder(Order order)
    {
        Console.WriteLine("Order Details:");
        foreach (var item in order.ItemList)
        {
            Console.WriteLine($"Item Name: {item.Name}, Price: {item.Price}");
        }
        Console.WriteLine($"Total: {order.CalculateTotalSum()}");
    }
}

class Book : Item, IDiscountPossible
{
    public string Author { get; private set; }
    private double _discount;

    public Book(string name, string author, double price)
    {
        Name = name;
        Author = author;
        SetPrice(price);
    }

    public void ApplyDiscount(double discount)
    {
        _discount = discount;
    }

    public double GetDiscountedPrice()
    {
        return Price - _discount;
    }
}

class Clothes : Item, ISizeable, IColorable, IDiscountPossible
{
    public byte Color { get; private set; }
    public byte Size { get; private set; }
    private double _discount;

    public void SetColor(byte color)
    {
        Color = color;
    }

    public void SetSize(byte size)
    {
        Size = size;
    }

    public void ApplyDiscount(double discount)
    {
        _discount = discount;
    }

    public double GetDiscountedPrice()
    {
        return Price - _discount;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Book book1 = new Book("Dead Souls", "Gogol", 233.5);
        Clothes coat = new Clothes();
        coat.Name = "Winter Coat";
        coat.SetPrice(50.0);
        coat.SetColor(1);
        coat.SetSize(34);

        Order order = new Order();
        order.AddItem(book1);
        order.AddItem(coat);

        book1.ApplyDiscount(33.5);
        coat.ApplyDiscount(10);

        OrderViewer viewer = new OrderViewer();
        viewer.PrintOrder(order);

        Console.ReadKey();
    }
}
}