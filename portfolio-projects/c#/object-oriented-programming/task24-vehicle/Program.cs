using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task24_vehicle
{
    public class Tire
    {   
        // properties
        public string Manufacturer { get; private set;}
        public string Model { get; private set;}
        public int TireSize { get; private set;}

        public Tire(string manufacturer, string model, int tiresize) { 
            Manufacturer = manufacturer;
            Model = model;
            TireSize = tiresize;
        }
    }

    public class Vehicle
    {
        public string Name { get; private set;}
        public string Model { get; private set;}

        public List<Tire> Tires { get; private set;}

        public Vehicle(string name, string model)
        {
            Name = name; 
            Model = model;
            Tires = new List<Tire>();
        }
   
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Create some tire objects
            Tire carTire1 = new Tire("Michelin", "Pilot Sport 4S", 19);
            Tire carTire2 = new Tire("Michelin", "Pilot Sport 4S", 19);
            Tire carTire3 = new Tire("Michelin", "Pilot Sport 4S", 19);
            Tire carTire4 = new Tire("Michelin", "Pilot Sport 4S", 19);

            Tire bikeTire1 = new Tire("Bridgestone", "Battlax Hypersport S22", 17);
            Tire bikeTire2 = new Tire("Bridgestone", "Battlax Hypersport S22", 17);

            // Create a car and assemble its tires
            Vehicle car = new Vehicle("Toyota", "Camry");
            car.Tires.Add(carTire1);
            car.Tires.Add(carTire2);
            car.Tires.Add(carTire3);
            car.Tires.Add(carTire4);

            // Create a motorcycle and assemble its tires
            Vehicle motorcycle = new Vehicle("Honda", "CBR1000RR");
            motorcycle.Tires.Add(bikeTire1);
            motorcycle.Tires.Add(bikeTire2);

            // Display the details of the vehicles
            Console.WriteLine("Car Details:");
            Console.WriteLine($"Name: {car.Name}, Model: {car.Model}");
            Console.WriteLine("Tires:");
            foreach (var tire in car.Tires)
            {
                Console.WriteLine($"- Manufacturer: {tire.Manufacturer}, Model: {tire.Model}, Size: {tire.TireSize}");
            }

            Console.WriteLine();

            Console.WriteLine("Motorcycle Details:");
            Console.WriteLine($"Name: {motorcycle.Name}, Model: {motorcycle.Model}");
            Console.WriteLine("Tires:");
            foreach (var tire in motorcycle.Tires)
            {
                Console.WriteLine($"- Manufacturer: {tire.Manufacturer}, Model: {tire.Model}, Size: {tire.TireSize}");
            }
        }
    }
}
