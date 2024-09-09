using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task13_elevator
{
    internal class Program
    {   
        public class Elevator
        {
            public int currentFloor;

            public int CurrentFloor
            {
                get { return currentFloor; }
            }

            public Elevator() {
                currentFloor = 1;
            }
           
            public bool GoTo(int floor, out string message)
            {   
                if (floor < 1) {
                    message = "Floor min 1";
                    return false;
                }
                else if (floor > 5) {
                    message = "Floor max 5";
                    return false;
                }
                else
                {
                    currentFloor = floor;
                    message = $"Elevator is now in floor: {currentFloor}";
                    return true;
                }
            }
        }

        static void Main(string[] args)
        {
            Elevator elevator = new Elevator();
            Console.WriteLine($"Elevator is now in floor: {elevator.CurrentFloor}");

            while (true)
            {
                Console.Write("Give a new floor number (1-5) > ");
                if (int.TryParse(Console.ReadLine(), out int floor))
                {
                    string message;
                    if (elevator.GoTo(floor, out message))
                    {
                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine(message);
                        Console.WriteLine($"Elevator is now in floor: {elevator.CurrentFloor}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                }
            }
        }
    }
}
