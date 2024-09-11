using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task7_washing_machine
{   
    public class WashingMachine
    {

        // fields
        private bool powerOn;
        private int temperature;
        private int spinSpeed;

        // constructors
        public WashingMachine()
        {
            // Initializing default values
            powerOn = false; // Initially powered off
            temperature = 0; // No temperature initially
            spinSpeed = 0; // No spin speed initially

        }

        public WashingMachine(bool powerOn, int temperature, int spinSpeed)
        {
            this.powerOn = powerOn;
            this.temperature = temperature;
            this.spinSpeed = spinSpeed;
        }

        public WashingMachine(bool powerOn) : this()
        {
            this.powerOn = powerOn;
        }

        public WashingMachine(int temperature) : this()
        {
            this.temperature = temperature;
        }

        public WashingMachine(int temperature, int spinSpeed) : this()
        {
            this.temperature = temperature;
            this.spinSpeed = spinSpeed;
        }


        // methods

        public void TurnOn()
        {
            powerOn = true;
        }

        public void TurnOff()
        {
            powerOn = false;
        }

        public void SetTemperature(int temperature)
        {
            this.temperature = temperature;
        }

        public void SetSpinSpeed(int spinSpeed)
        {
            this.spinSpeed = spinSpeed;
        }


        public override string ToString()
        {
            return $"Power: {(powerOn ? "On" : "Off")}, Temperature: {temperature}, Spin Speed: {spinSpeed}\n";
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the WashingMachine class using various constructors
            WashingMachine washingMachine1 = new WashingMachine(); // Default constructor
            WashingMachine washingMachine2 = new WashingMachine(true); // Constructor with powerOn parameter
            WashingMachine washingMachine3 = new WashingMachine(60); // Constructor with temperature parameter
            WashingMachine washingMachine4 = new WashingMachine(60, 800); // Constructor with temperature and spinSpeed parameters
            WashingMachine washingMachine5 = new WashingMachine(false, 40, 600); // Constructor with all parameters


            // Output the state of each washing machine
            // Washing machine 1
            Console.WriteLine("Washing Machine 1:");
            Console.WriteLine(washingMachine1.ToString());

            // Washing Machine 2
            Console.WriteLine("Washing Machine 2:");
            Console.WriteLine(washingMachine2.ToString());

            // Washing Machine 3
            Console.WriteLine("Washing Machine 3:");
            Console.WriteLine(washingMachine3.ToString());

            // Washing Machine 4
            Console.WriteLine("Washing Machine 4:");
            Console.WriteLine(washingMachine4.ToString());

            // Washing Machine 5
            Console.WriteLine("Washing Machine 5:");
            Console.WriteLine(washingMachine5.ToString());
        }
    }
}
