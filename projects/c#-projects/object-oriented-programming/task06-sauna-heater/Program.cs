using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;

namespace task6_sauna_heater
{
    public class Heater
    {
        // Private fields to store temperature, humidity, and the state of the heater
        private int temperature;
        private int humidity;
        private bool isOn;

        // Public properties to provide access to the temperature, humidity, and state of the heater
        public int Temperature
        {
            get { return temperature; } // Getter returns the current temperature
            set { temperature = value; } // Setter sets the temperature to the provided value
        }

        public int Humidity
        {
            get { return humidity; } // Getter returns the current humidity
            set { humidity = value; } // Setter sets the humidity to the provided value
        }

        public bool IsOn
        {
            get { return isOn; } // Getter returns true if the heater is on, false otherwise
        }

        // Method to turn on the heater
        public void TurnOn()
        {
            isOn = true; // Set the isOn field to true to indicate that the heater is on
        }

        // Method to turn off the heater
        public void TurnOff()
        {
            isOn = false; // Set the isOn field to false to indicate that the heater is off
        }

        // Method to adjust the temperature
        public void AdjustTemperature(int newTemperature)
        {
            temperature = newTemperature; // Set the temperature to the provided value
        }

        // Method to adjust the humidity
        public void AdjustHumidity(int newHumidity)
        {
            humidity = newHumidity; // Set the humidity to the provided value
        }

        // Override the ToString method to provide a string representation of the Heater object
        public override string ToString()
        {
            // Return a string containing the current state of the heater (on/off), temperature, and humidity
            return $"Heater: {(isOn ? "On" : "Off")}, Temperature: {temperature}, Humidity: {humidity}";
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Heater saunaHeater = new Heater();

            // Turn on the heater
            saunaHeater.TurnOn();

            // Adjust temperature and humidity
            saunaHeater.AdjustTemperature(115);
            saunaHeater.AdjustHumidity(5);

            // Check if the heater is on
            if (saunaHeater.IsOn)
            {
                // Turn off the heater
                saunaHeater.TurnOff();
            }

            // Print the status of the heater
            Console.WriteLine(saunaHeater.ToString());
        }
    }
}
