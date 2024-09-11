using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace task3_consumption
{
    internal class Program
    {
        class Distance
        {
            private int _distanceDriven;

            public Distance(int distanceDriven)
            {
                _distanceDriven = distanceDriven;
            }

            // Method to calculate trip cost
            public void CalculateTripCost()
            {
                // Generate random consumption between 6 - 9 liters/100km
                Random rnd = new Random();
                double consumption = rnd.NextDouble() * (9 - 6) + 6;

                // Generate random fuel price between 1.75€ - 2.50€ per litre
                double fuelPrice = rnd.NextDouble() * (2.50 - 1.75) + 1.75;

                // Calculate amount of gasoline consumed
                double gasolineConsumed = (_distanceDriven / 100.0) * consumption;

                // Calculate amount of money spent on gasoline
                double moneySpent = gasolineConsumed * fuelPrice;

                // Display results
                string formattedGasolineConsumed = gasolineConsumed.ToString("0.0");
                string formattedMoneySpent = moneySpent.ToString("0.0");

                Console.WriteLine($"Amount of gasoline consumed: {formattedGasolineConsumed} liters");
                Console.WriteLine($"Amount of money spent on gasoline: {formattedMoneySpent} euros");
            }
        }

        static void Main(string[] args)
        {   
            // Ask user input
            Console.WriteLine("Enter distance driven in kilometers: ");

            // Check if the user input is integers
            if (int.TryParse(Console.ReadLine(), out int distanceDriven))
            {
                Distance distance = new Distance(distanceDriven);
                distance.CalculateTripCost(); // Calculate and display trip cost
            }
            else
            {
                Console.WriteLine("Distance given is not a number.");
            }
        }
    }
}
