using System;

namespace task20_mammal
{
    // Abstract class Mammal
    public abstract class Mammal
    {
        // Property for age
        public int Age { get; set; }

        // Abstract method for movement
        public abstract void Move();
    }

    // Human class inheriting from Mammal
    public class Human : Mammal
    {
        // Properties specific to humans
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }

        // Method to move
        public override void Move()
        {
            Console.WriteLine("Moving");
        }

        // Method to increase age by one year
        public void Grow()
        {
            Age++;
        }
    }

    // Baby class inheriting from Human
    public class Baby : Human
    {
        // Property specific to babies
        public string Diaper { get; set; }

        // Override move method to print crawling
        public override void Move()
        {
            Console.WriteLine("Crawling");
        }
    }

    // Adult class inheriting from Human
    public class Adult : Human
    {
        // Property specific to adults
        public string Auto { get; set; }

        // Override move method to print walking
        public override void Move()
        {
            Console.WriteLine("Walking");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Creating instances of Baby and Adult
            Baby baby = new Baby
            {
                Name = "Alice",
                Age = 1,
                Weight = 8.5,
                Height = 0.6,
                Diaper = "Pampers"
            };

            Adult adult = new Adult
            {
                Name = "Bob",
                Age = 30,
                Weight = 75,
                Height = 1.75,
                Auto = "Toyota Corolla"
            };

            // Printing information about the baby and adult
            Console.WriteLine("Baby:");
            Console.WriteLine($"Name: {baby.Name}, Age: {baby.Age}, Weight: {baby.Weight}, Height: {baby.Height}, Diaper: {baby.Diaper}");

            Console.WriteLine("Adult:");
            Console.WriteLine($"Name: {adult.Name}, Age: {adult.Age}, Weight: {adult.Weight}, Height: {adult.Height}, Auto: {adult.Auto}");

            // Testing movement
            Console.WriteLine("\nTesting movement:");
            Console.WriteLine("Baby movement:");
            baby.Move();
            Console.WriteLine("Adult movement:");
            adult.Move();

            // Growing the baby
            Console.WriteLine("\nGrowing the baby:");
            Console.WriteLine($"Before growing: Baby's age is {baby.Age}");
            baby.Grow();
            Console.WriteLine($"After growing: Baby's age is {baby.Age}");
        }
    }
}
