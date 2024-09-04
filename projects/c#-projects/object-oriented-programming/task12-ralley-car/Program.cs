using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static task12_ralley_car.Program;

namespace task12_ralley_car
{
    internal class Program
    {
        public class RalleyCar
        {
            // properties
            public string Name { get; set; }
            public string Type { get; set; }
            public float Speed { get; private set; }

            private const float SpeedMax = 200;

            // constructors
            public RalleyCar() { }


            // methods

            public void AccelerateTo(float targetSpeed)
            {
                if (targetSpeed >= 0 && targetSpeed <= SpeedMax)
                {
                    Speed = Math.Min(targetSpeed, SpeedMax);
                }
            }

            public void SlowTo(float targetSpeed)
            {
                if (targetSpeed >= 0 && targetSpeed <= SpeedMax)
                {
                    Speed = Math.Max(targetSpeed, 0);
                }
            }
        }

        static void Main(string[] args)
        {
            RalleyCar car = new RalleyCar();
            car.Name = "Subaru";
            car.Type = "WRX";
            Console.WriteLine($"Car Name: {car.Name}, Type: {car.Type}");

            // Test AccelerateTo method
            car.AccelerateTo(100);
            Console.WriteLine($"Current Speed: {car.Speed}");

            // Test SlowTo method
            car.SlowTo(50);
            Console.WriteLine($"Current Speed: {car.Speed}");

            // Test setting speed beyond max
            car.AccelerateTo(250);
            Console.WriteLine($"Current Speed: {car.Speed}");

            // Test setting negative speed
            car.SlowTo(-10);
            Console.WriteLine($"Current Speed: {car.Speed}");
        }
    }
}
