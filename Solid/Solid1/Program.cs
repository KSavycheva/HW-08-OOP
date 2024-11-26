using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid1
{
    //Який принцип S.O.L.I.D. порушено? Виправте!

    /*
     * Тут порушується принцип єдиного обов'язку (The Single Responsibility Principle), 
     * що звучить як: "Клас має мати лише одну причину на зміну", тобто кожен клас має 
     * вирішувати тільки одну задачу. Тут же ж клас "Order" робить забагато різних речей. 
     * Маємо розділити клас на декілька поменше і розподілити між ними ці методи(або ж доповнити існуючі)
    */

        class Item
        {
            
        }

        class Order
        {
            private List<Item> itemList = new List<Item>();

            public List<Item> ItemList
            {
                get { return itemList; }
            }

            public void AddItem(Item item) => itemList.Add(item);
            public void DeleteItem(Item item) => itemList.Remove(item);
            public int GetItemCount() => itemList.Count;
            public decimal CalculateTotalSum()
            {
                
                return 0;
            }
        }

        class OrderPrinter
        {
            public void PrintOrder(Order order)
            {
                
            }

            public void ShowOrder(Order order)
            {
            Console.WriteLine("Here I am! (Order)");
            }
        }

        class OrderRepository
        {
            public void Load()
            {
                
            }

            public void Save(Order order)
            {
                
            }

            public void Update(Order order)
            {
                
            }

            public void Delete(Order order)
            {
                
            }
        }

        class Program
        {
            static void Main()
            { 
                Order order = new Order();
                OrderPrinter printer = new OrderPrinter();
                OrderRepository repository = new OrderRepository();

                order.AddItem(new Item());
                printer.ShowOrder(order);
                repository.Save(order);
            }
        }
    }