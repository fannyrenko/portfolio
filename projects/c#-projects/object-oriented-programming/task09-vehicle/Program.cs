using System;
using System.Reflection;

namespace task9_vehicle
{
    public class Vehicle
    {
        // Properties
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Speed { get; set; }
        public int Tires { get; set; }

        // Constructor
        public Vehicle(string manufacturer, string model, int speed, int tires)
        {
            Manufacturer = manufacturer;
            Model = model;
            Speed = speed;
            Tires = tires;
        }

        // Methods
        public string ShowInfo()
        {
            return $"Manufacturer: {Manufacturer}, Model: {Model}";
        }

        public override string ToString()
        {
            return $"Manufacturer: {Manufacturer}, Model: {Model}, Speed: {Speed}, Tires: {Tires}";
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {

            // Creating instances of different types of vehicles
            Vehicle bicycle = new Vehicle("Giant", "Escape", 20, 2);
            Vehicle motorcycle = new Vehicle("Harley-Davidson", "Street Glide", 120, 2);
            Vehicle car = new Vehicle("Toyota", "Camry", 100, 4);
            Vehicle truck = new Vehicle("Ford", "F-150", 90, 6);

            // Printing vehicle information
            Console.WriteLine("Bicycle:");
            Console.WriteLine(bicycle.ShowInfo()); // Manufacturer and model information
            Console.WriteLine(bicycle.ToString()); // All properties

            Console.WriteLine("\nMotorcycle:");
            Console.WriteLine(motorcycle.ShowInfo()); // Manufacturer and model information
            Console.WriteLine(motorcycle.ToString()); // All properties

            Console.WriteLine("\nCar:");
            Console.WriteLine(car.ShowInfo()); // Manufacturer and model information
            Console.WriteLine(car.ToString()); // All properties

            Console.WriteLine("\nTruck:");
            Console.WriteLine(truck.ShowInfo()); // Manufacturer and model information
            Console.WriteLine(truck.ToString()); // All properties

        }
    }
}
