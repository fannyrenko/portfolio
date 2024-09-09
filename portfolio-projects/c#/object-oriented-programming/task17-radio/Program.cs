using System;

namespace task17_radio
{
    internal class Program
    {
        // Class representing an electrical device
        public class ElectricalDevice
        {
            // Properties for the state of the device
            public bool IsOn { get; set; }
            public float Power { get; set; }

            // Constructor to initialize the device with given state and power
            public ElectricalDevice(bool isOn, float power)
            {
                IsOn = isOn;
                Power = power;
            }
        }

        // Class representing a portable radio, inheriting from ElectricalDevice
        public class PortableRadio : ElectricalDevice
        {
            // Private fields for volume and frequency
            private int volume;
            private float frequency;

            // Property for volume with validation
            public int Volume
            {
                get { return volume; }
                set
                {
                    if (IsOn)
                    {
                        if (value >= 0 && value <= 9)
                            volume = value;
                        else
                            Console.WriteLine("Volume value should be between 0 and 9.");
                    }
                    else
                    {
                        Console.WriteLine("Please turn on the radio to adjust the volume.");
                    }
                }
            }

            // Property for frequency with validation
            public float Frequency
            {
                get { return frequency; }
                set
                {
                    if (IsOn)
                    {
                        if (value >= 2000.0f && value <= 26000.0f)
                            frequency = value;
                        else
                            Console.WriteLine("Frequency value should be between 2000.0 and 26000.0.");
                    }
                    else
                    {
                        Console.WriteLine("Please turn on the radio to select a frequency.");
                    }
                }
            }

            // Constructor to initialize the radio with given state and power
            public PortableRadio(bool isOn, float power) : base(isOn, power)
            {
                volume = 0;
                frequency = 0.0f;
            }

            // Override of ToString method to return a string representation of the radio settings
            public override string ToString()
            {
                return $"Power: {IsOn}, Volume: {Volume}, Frequency: {Frequency}";
            }
        }

        // Main method to test the functionality of the radio
        static void Main(string[] args)
        {
            // Creating a portable radio object with initial state and power
            PortableRadio radio = new PortableRadio(false, 10.0f);

            // Printing initial radio settings
            Console.WriteLine("Initial Radio Settings:");
            Console.WriteLine(radio.ToString());

            // Turning on the radio and adjusting volume and frequency
            radio.IsOn = true;
            radio.Volume = 5;
            radio.Frequency = 15000.0f;

            // Printing radio settings after adjustments
            Console.WriteLine("\nRadio Settings After Adjustments:");
            Console.WriteLine(radio.ToString());

            // Attempting to adjust settings when the radio is turned off
            Console.WriteLine("\nTrying to change volume and frequency when turned off:");
            radio.IsOn = false;
            radio.Volume = 6;
            radio.Frequency = 2500f;
        }
    }
}
