using System;

namespace task19_collection
{
    internal class Program
    {
        // Base class representing a library item
        public class LibraryItem
        {
            // Properties
            public string Title { get; set; }
            public bool IsAvailable { get; set; }

            // Constructor
            public LibraryItem(string title)
            {
                Title = title;
                IsAvailable = true; // By default, the item is available
            }

            // Method to check out the item
            public virtual void CheckOut()
            {
                if (IsAvailable)
                {
                    IsAvailable = false; // Set the item as not available
                    Console.WriteLine($"Checked out: {Title}");
                }
                else
                {
                    Console.WriteLine($"Sorry, {Title} is already checked out.");
                }
            }

            // Method to return the item
            public virtual void Return()
            {
                if (!IsAvailable)
                {
                    IsAvailable = true; // Set the item as available
                    Console.WriteLine($"Returned: {Title}");
                }
                else
                {
                    Console.WriteLine($"Error: {Title} is already in the library.");
                }
            }
        }

        // Subclass for representing a book
        public class Book : LibraryItem
        {
            // Additional property specific to books
            public string Author { get; private set; }

            // Constructor
            public Book(string title, string author) : base(title)
            {
                Author = author;
            }

            // Override method to provide a string representation of the book
            public override string ToString()
            {
                return $"Book: {Title} by {Author}";
            }
        }

        // Subclass for representing a magazine
        public class Magazine : LibraryItem
        {
            // Additional property specific to magazines
            public int IssueNumber { get; private set; }

            // Constructor
            public Magazine(string title, int issueNumber) : base(title)
            {
                IssueNumber = issueNumber;
            }

            // Override method to provide a string representation of the magazine
            public override string ToString()
            {
                return $"Magazine: {Title}, Issue {IssueNumber}";
            }
        }

        // Subclass for representing a DVD
        public class DVD : LibraryItem
        {
            // Additional property specific to DVDs
            public string Director { get; private set; }

            // Constructor
            public DVD(string title, string director) : base(title)
            {
                Director = director;
            }

            // Override method to provide a string representation of the DVD
            public override string ToString()
            {
                return $"DVD: {Title}, Directed by {Director}";
            }
        }

        // Main method
        static void Main(string[] args)
        {
            // Create library items
            Book book = new Book("The Great Gatsby", "F. Scott Fitzgerald");
            Magazine magazine = new Magazine("National Geographic", 123);
            DVD dvd = new DVD("Inception", "Christopher Nolan");

            // Display items
            Console.WriteLine(book);
            Console.WriteLine(magazine);
            Console.WriteLine(dvd);

            // Check out and return items
            book.CheckOut();
            magazine.CheckOut();
            dvd.CheckOut();

            book.Return();
            magazine.Return();

            // Try to checkout item that is hasn't yet been returned
            Console.WriteLine("Trying to checkout item that is hasn't yet been returned.");
            dvd.CheckOut();

            // Try to return already returned item
            Console.WriteLine("Trying to return already returned item.");
            book.Return();
        }
    }
}

