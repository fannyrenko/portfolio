using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task14_amplifier
{
    public class Amplifier
    {
        // Private field to hold the volume level
        private double volume;

        // Property to control the volume level
        public double Volume
        {
            get { return volume; }
            set
            {
                // Ensure the volume is within the allowed range (0 to 100)
                if (value < 0)
                {
                    volume = 0;
                    Console.WriteLine("-> Too low volume - Amplifier volume is set to minimum : 0");
                }
                else if (value > 100)
                {
                    volume = 100;
                    Console.WriteLine("-> Too much volume - Amplifier volume is set to maximum : 100");
                }
                else
                {
                    volume = value;
                    Console.WriteLine($"-> Amplifier volume is set to : {volume}");
                }
            }
        }

        // Constructor to initialize the volume
        public Amplifier(double volume)
        {
            // Use the property to set the volume, ensuring it's within the valid range
            Volume = volume;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the Amplifier class
            Amplifier amplifier = new Amplifier(50);

            // Continuous loop to adjust the volume
            while (true)
            {
                // Ask the user for a new volume value
                Console.WriteLine("Give a new volume value (0-100) > ");
                // Read the volume value from the user input
                var volume = Convert.ToDouble(Console.ReadLine());
                // Set the volume of the amplifier using the Volume property
                amplifier.Volume = volume;
            }
        }
    }
}
