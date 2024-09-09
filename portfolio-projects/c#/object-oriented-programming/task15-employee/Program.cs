using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task15_employee
{
    internal class Program
    {
        public class Employee
        {
            // Properties
            public string Name { get; private set; }
            public string Profession { get; private set; }
            public double Salary { get; private set; }

            // Constructors
            public Employee(string name, string profession, double salary)
            {
                Name = name;
                Profession = profession;
                Salary = salary;
            }

            // Methods
            public string showName()
            {
                return Name;
            }

            public string showProfession()
            {
                return Profession;
            }

            public double showSalary()
            {
                return Salary;
            }

            public string setName(string name)
            {
                Name = name;
                return $"New name: {name}";
            }

            public string setSalary(double salary)
            {
                Salary = salary;
                return $"New salary: {salary}";
            }

            public string setProfession(string profession)
            {
                Profession = profession;
                return $"New profession: {profession}";
            }

            public virtual string toString()
            {
                return $"Employee:\n {Name}, {Profession}, {Salary}";
            }
        }

        public class Boss : Employee
        {
            // Additional Properties
            public double Bonus { get; private set; }
            public string Car { get; private set; }

            // Constructors
            public Boss(string name, string profession, double salary, string car, double bonus)
                : base(name, profession, salary)
            {
                Car = car;
                Bonus = bonus;
            }

            // Methods
            public string setCar(string car)
            {
                Car = car;
                return $"New car: {car}";
            }

            public double setBonus(double bonus)
            {
                Bonus = bonus;
                return bonus;
            }


            // Override ToString method
            public override string ToString()
            {
                double totalSalary = Salary + Bonus;
                return $"Boss:\n Name: {Name}, Bonus: {Bonus}, Car: {Car}, Total Salary: {totalSalary}";
            }
        }

        static void Main(string[] args)
        {
            Employee employee1 = new Employee("Kirsi Kernel", "Teacher", 1200);
            Console.WriteLine(employee1.toString());

            Boss boss1 = new Boss("Hanna Husso", "Head of institute", 9000, "Audi", 5000);
            Console.WriteLine(boss1.toString());

            employee1.setProfession("Principal");
            employee1.setSalary(2200);
            Console.WriteLine(employee1.toString());
        }
    }
}
