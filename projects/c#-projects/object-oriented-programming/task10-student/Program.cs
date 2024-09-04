using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task10_student
{
    internal class Program
    {    
        public class Student
        {   

            // properties
            public string Name { get; private set; }
            public int Id { get; private set; }
            public int Age { get; private set; }
            public float Grade { get; private set; }

            // constructor
            public Student(string name, int id, int age, float grade)
            {
                Name = name;
                Id = id;
                Age = age;
                Grade = grade;
            }

            // methods
            public string ShowInfo()
            {
                return $"Name: {Name}, ID: {Id}, Age: {Age}, Grade: {Grade}";
            }

            public string ShowName()
            {
                return $"Name: {Name}";
            }

            public int ShowId()
            {
                return (int)Id;

            }

            public int ShowAge()
            {
                return (int)Age;
            }

            public int ShowGrade()
            {
                return (int)Grade;
            }


            public override string ToString()
            {
                return base.ToString();
            }
        }

        static void Main(string[] args)
        {

            // Creating a list to store students
            List<Student> students = new List<Student>();

            // Adding five students to the list
            students.Add(new Student("John Doe", 001, 20, 4.5f));
            students.Add(new Student("Jane Smith", 002, 22, 5.0f));
            students.Add(new Student("Alice Johnson", 003, 21, 3.2f));
            students.Add(new Student("Bob Brown", 004, 19, 1.7f));
            students.Add(new Student("Emily Davis", 005, 23, 2.9f));

            // Printing names for each student using a loop
            Console.WriteLine("Students Names:");
            foreach (var student in students)
            {
                Console.WriteLine(student.ShowName());
            }

            // Printing ages for each student using a loop
            Console.WriteLine("Students Ages:");
            foreach (var student in students)
            {
                Console.WriteLine(student.ShowAge());
            }

            // Printing grades for each student using a loop
            Console.WriteLine("Students Grades:");
            foreach (var student in students)
            {
                Console.WriteLine(student.ShowGrade());
            }

            // Printing information for each student using a loop
            Console.WriteLine("Students Information:");
            foreach (var student in students)
            {
                Console.WriteLine(student.ShowInfo());
            }

        }


    }
}

