using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task5_names
{   
    // Person struct 
    struct Person
    {   
        // fields
        public string Name;
        public int YearOfBirth;

        // Method to calculate age based on the current year
        public int CalculateAge()
        {
            int currentYear = DateTime.Now.Year;
            return currentYear - YearOfBirth;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {   
            // Creating empty list to store persons
            List<Person> people = new List<Person>();

            // Ask the user to enter people's names and their year of birth
            Console.WriteLine("Enter people's names and their year of birth separated by a comma (e.g., John, 1990):");
            Console.Write("Give a name: ");
            string input;

            // do-while loop to repeatedly prompt the user to enter name and year of birth
            do
            {   
                input = Console.ReadLine();

                // Split the input into name and year of birth
                string[] parts = input.Split(',');
                if (parts.Length == 2)
                {
                    string name = parts[0].Trim();
                    if (int.TryParse(parts[1].Trim(), out int yearOfBirth))
                    {
                        // Create a new Person struct and add it to the list
                        Person person = new Person { Name = name, YearOfBirth = yearOfBirth };
                        people.Add(person);
                    }
                    else
                    {
                        Console.WriteLine("Invalid year of birth format. Please enter a valid number.");
                    }
                }
                else if (!string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Invalid input format. Please enter name and year of birth separated by a comma.");
                }

                Console.Write("Give a name: ");

            } while (!string.IsNullOrEmpty(input)); // if user gives empty input, loop stops

            // Display the total number of names given
            Console.WriteLine($"Total number of names given: {people.Count}");

            // Sort the list of people by their age (ascending)
            List<Person> sortedPeople = people.OrderBy(p => p.CalculateAge()).ToList();


            // Display the names in order of age from youngest to oldest
            Console.WriteLine("\nNames in order of age from youngest to oldest:");
            foreach (Person person in sortedPeople)
            {
                int age = person.CalculateAge();
                Console.WriteLine($"{person.Name} (Age: {age})");
            }

        }
    }
}
