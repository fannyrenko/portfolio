using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;

namespace task16_vehicle
{
    using System;

    internal class Program
    {
        // Define the base class Vehicle
        public class Vehicle
        {
            // Properties common to all vehicles
            public string Name { get; private set; }
            public string Model { get; private set; }
            public int ModelYear { get; private set; }
            public string Color { get; private set; }

            // Constructor for initializing the vehicle properties
            public Vehicle(string name, string model, int modelYear, string color)
            {
                Name = name;
                Model = model;
                ModelYear = modelYear;
                Color = color;
            }

            // Override ToString method to provide a formatted string representation of the vehicle
            public override string ToString()
            {
                return $"- Name: {Name} Model: {Model} ModelYear: {ModelYear} Color: {Color}";
            }
        }

        // Define a subclass Bicycle inheriting from Vehicle
        public class Bicycle : Vehicle
        {
            // Additional properties specific to bicycles
            public bool GearWheels { get; private set; }
            public string GearName { get; private set; }

            // Constructor for initializing bicycle properties
            public Bicycle(string name, string model, int modelYear, string color, bool gearWheels, string gearName = "")
                : base(name, model, modelYear, color)
            {
                GearWheels = gearWheels;
                GearName = gearName;
            }

            // Override ToString method to provide a formatted string representation of the bicycle
            public override string ToString()
            {
                string bikeInfo = base.ToString(); // Call the base class ToString method
                bikeInfo += $" GearWheels: {GearWheels} Gear Name: {GearName}"; // Append bicycle-specific properties
                return bikeInfo;
            }
        }

        // Define a subclass Boat inheriting from Vehicle
        public class Boat : Vehicle
        {
            // Additional properties specific to boats
            public int SeatCount { get; private set; }
            public string BoatType { get; private set; }

            // Constructor for initializing boat properties
            public Boat(string name, string model, int modelYear, string color, int seatCount, string boatType)
                : base(name, model, modelYear, color)
            {
                SeatCount = seatCount;
                BoatType = boatType;
            }

            // Override ToString method to provide a formatted string representation of the boat
            public override string ToString()
            {
                string boatInfo = base.ToString(); // Call the base class ToString method
                boatInfo += $" SeatCount: {SeatCount} BoatType: {BoatType}"; // Append boat-specific properties
                return boatInfo;
            }
        }

        static void Main(string[] args)
        {
            // Create instances of Bicycle and Boat classes and print out their information
            Bicycle bike1 = new Bicycle("Jopo", "Street", 2016, "Blue", false);
            Console.WriteLine("Bike1 info");
            Console.WriteLine(bike1.ToString());

            Bicycle bike2 = new Bicycle("Tunturi", "StreetPower", 2010, "Black", true, "Shimano Nexus");
            Console.WriteLine("\nBike2 info");
            Console.WriteLine(bike2.ToString());

            Boat boat1 = new Boat("SummerFun", "S900", 1990, "White", 3, "Rowboat");
            Console.WriteLine("\nBoat1 info");
            Console.WriteLine(boat1.ToString());

            Boat boat2 = new Boat("Yamaha", "Model 1000", 2010, "Yellow", 5, "Motorboat");
            Console.WriteLine("\nBoat2 info");
            Console.WriteLine(boat2.ToString());
        }
    }

}
