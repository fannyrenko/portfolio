using System;
using System.Collections.Generic;


namespace task28_refridgerator
{   
    public class Refridgerator
    {   
        public List<Food> Foods { get; private set; }
        public List<Drink> Drinks { get; private set; }

        public Refridgerator() {
            Foods = new List<Food>();
            Drinks = new List<Drink>();
        }

        public void AddFood(Food food)
        {
            Foods.Add(food);
        }

        public void RemoveFood(Food food)
        {
            Foods.Remove(food);
        }

        public void ClearFood() 
        {   
            Foods.Clear();
        }

        public void AddDrink(Drink drink)
        {
            Drinks.Add(drink);
        }

        public void RemoveDrink(Drink drink)
        {
            Drinks.Remove(drink);
        }

        public void ListContents()
        {
            if (Foods.Count == 0 && Drinks.Count == 0)
            {
                Console.WriteLine("The refrigerator is empty.");
            }
            else
            {
                Console.WriteLine("Refrigerator contents:");
                Console.WriteLine("\nFood items:\n");
                foreach (var food in Foods)
                {
                    Console.WriteLine($"{food.Name} - Expires on: {food.ExpirationDate.ToShortDateString()}");
                }
                Console.WriteLine("\nDrink items:\n");
                foreach (var drink in Drinks)
                {
                    Console.WriteLine($"{drink.Name} - Expires on: {drink.ExpirationDate.ToShortDateString()}");
                }
            }
        }

    }

    public class Food
    {
        public string Name { get; private set; }
        public DateTime ExpirationDate { get; private set; }

        public Food(string name, DateTime expirationDate)
        {
            Name = name;
            ExpirationDate = expirationDate;
        }
    }

    public class Drink
    {
        public string Name { get; private set; }
        public DateTime ExpirationDate { get; private set; }

        public Drink(string name, DateTime expirationDate)
        {
            Name = name;
            ExpirationDate = expirationDate;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Refridgerator refrigerator = new Refridgerator();

            // Adding food to the refrigerator
            refrigerator.AddFood(new Food("Eggs", DateTime.Today.AddDays(10)));
            refrigerator.AddFood(new Food("Cheese", DateTime.Today.AddDays(30)));
            refrigerator.AddFood(new Food("Bread", DateTime.Today.AddDays(7)));
            refrigerator.AddFood(new Food("Apples", DateTime.Today.AddDays(14)));
            refrigerator.AddFood(new Food("Yogurt", DateTime.Today.AddDays(14)));

            // Adding drinks to the refrigerator
            refrigerator.AddDrink(new Drink("Beer", DateTime.Today.AddDays(360)));
            refrigerator.AddDrink(new Drink("Milk", DateTime.Today.AddDays(5)));
            refrigerator.AddDrink(new Drink("Orange Juice", DateTime.Today.AddDays(7)));
            refrigerator.AddDrink(new Drink("Soda", DateTime.Today.AddDays(30)));
            refrigerator.AddDrink(new Drink("Iced Tea", DateTime.Today.AddDays(14)));

            // Listing the contents of the refrigerator
            refrigerator.ListContents();
        }

    }
}
