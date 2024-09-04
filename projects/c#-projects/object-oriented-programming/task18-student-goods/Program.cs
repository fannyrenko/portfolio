using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace task18_student_goods
{
    internal class Program
    {
        public class Item
        {
            public string Title { get; private set; }
            public decimal Price { get; private set; }

            public Item(string title, decimal price)
            {
                Title = title;
                Price = price;
            }

            public override string ToString()
            {
                return $"Title: {Title}, Price: {Price} e";
            }
        }

        public class CD : Item
        {
            public string Artist { get; private set; }
            public int Year { get; private set; }
            public string Genre { get; private set; }

            public CD(string title, decimal price, string artist, int year, string genre) : base(title, price)
            {
                Artist = artist;
                Year = year;
                Genre = genre;
            }

            public override string ToString()
            {
                return $"Title: {Title}, Artist: {Artist}, Year: {Year}, Genre: {Genre}, Price: {Price}e";
            }
        }

        public class DVD : Item
        {
            public string Director { get; private set; }

            public DVD(string title, decimal price, string director) : base(title, price)
            {
                Director = director;
            }

            public override string ToString()
            {
                return $"Title: {Title}, Director: {Director}, Price: {Price}e";
            }
        }

        public class Book : Item
        {
            public string Author { get; private set; }
            public string Genre { get; private set; }

            public Book(string title, decimal price, string author, string genre) : base(title, price)
            {
                Author = author;
                Genre = genre;
            }

            public override string ToString()
            {
                return $"Title: {Title}, Author: {Author}, Genre: {Genre}, Price: {Price}e";
            }
        }

        public class Electronic : Item
        {
            public string Brand { get; private set; }
            public string Model { get; private set; }

            public Electronic(string title, decimal price, string brand, string model) : base(title, price)
            {
                Brand = brand;
                Model = model;
            }

            public override string ToString()
            {
                return $"Title: {Title}, Brand: {Brand}, Model: {Model}, Price: {Price}e";
            }
        }

        static void Main(string[] args)
        {
            // Example usage:
            CD cd = new CD("Greatest Hits", 14.99m, "Various Artists", 2022, "Pop");
            DVD dvd = new DVD("Inception", 9.99m, "Christopher Nolan");
            Book book = new Book("The Great Gatsby", 7.99m, "F. Scott Fitzgerald", "Fiction");
            Electronic electronic = new Electronic("Smartwatch", 199.99m, "Apple", "Apple Watch Series 6");

            Console.WriteLine(cd.ToString());
            Console.WriteLine(dvd.ToString());
            Console.WriteLine(book.ToString());
            Console.WriteLine(electronic.ToString());
        }
    }
}