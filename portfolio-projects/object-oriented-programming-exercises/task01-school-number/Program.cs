using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task1_school_number
{
    //  the grading logic class
    class GradingSystem
    {
        // property to store the points
        public int Points { get; set; }

        // constructor to initialize the object with points
        public GradingSystem(int points)
        {
            Points = points;
        }

        // method to calculate and print the grade based on points
        public void CalculateGrade()
        {
            if (Points >= 0 && Points <= 19)
            {
                Console.WriteLine("Grade is: 0");
            }
            else if (Points >= 20 && Points <= 29)
            {
                Console.WriteLine("Grade is: 1");
            }
            else if (Points >= 30 && Points <= 39)
            {
                Console.WriteLine("Grade is: 2");
            }
            else if (Points >= 40 && Points <= 49)
            {
                Console.WriteLine("Grade is: 3");
            }
            else if (Points >= 50 && Points <= 59)
            {
                Console.WriteLine("Grade is: 4");
            }
            else if (Points >= 60 && Points <= 70)
            {
                Console.WriteLine("Grade is: 5");
            }
            else
            {
                Console.WriteLine("Something went wrong.");
            }
        }
    }

    // main program
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter points: ");

            // try and parse user input as an integer
            if (int.TryParse(Console.ReadLine(), out int points))
            {   
                // create an instance for GradingSystem class
                GradingSystem gradingSystem = new GradingSystem(points);

                // call CalculateGrade method to determine and print the grade
                gradingSystem.CalculateGrade();
            }
            else
            {
                // if input is not integer print -> invalid input
                Console.WriteLine("Invalid input. Please enter a valid integer for the points.");
            }
        }
    }
}
