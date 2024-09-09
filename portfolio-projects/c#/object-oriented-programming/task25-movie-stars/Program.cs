using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task25_movie_stars
{
    public class Human
    {
        // properties
        public string Name { get; set; }
        public int BirthYear { get; set; }

        //constructor
        public Human(string name, int birthYear)
        {
            Name = name;
            BirthYear = birthYear;
        }
    }

    public class Director : Human
    {
        // constructor
        public Director(string name, int birthYear) : base(name, birthYear)
        {
        }
    }

    public class Actor : Human
    {
        // constructor
        public Actor(string name, int birthYear) : base(name, birthYear)
        {
        }
    }

    public class Movie
    {
        // properties
        public string Name { get; set; }
        public int Year { get; set; }
        public Director Director { get; }
        public List<Actor> Actors { get; }

        // constructor
        public Movie(string name, int year, Director director, List<Actor> actors)
        {
            Name = name;
            Year = year;
            Director = director;
            Actors = actors;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            // create a director
            Director director = new Director("Christopher Nolan", 1970);

            // create some actors
            Actor actor1 = new Actor("Leonardo DiCaprio", 1974);
            Actor actor2 = new Actor("Joseph Gordon-Levitt", 1981);

            // create a movie and add actors
            List<Actor> actors = new List<Actor> { actor1, actor2 };
            Movie inception = new Movie("Inception", 2010, director, actors);

            // create another movie with different actors
            Actor actor3 = new Actor("Tom Hardy", 1977);
            Actor actor4 = new Actor("Ellen Page", 1987);
            List<Actor> actors2 = new List<Actor> { actor3, actor4 };
            Movie darkKnightRises = new Movie("The Dark Knight Rises", 2012, director, actors2);

            // display movie details
            Console.WriteLine("Movie 1 Details:");
            Console.WriteLine($"Name: {inception.Name}");
            Console.WriteLine($"Year: {inception.Year}");
            Console.WriteLine($"Director: {inception.Director.Name}");
            Console.WriteLine("Actors:");
            foreach (var actor in inception.Actors)
            {
                Console.WriteLine($"- {actor.Name}");
            }

            Console.WriteLine();

            Console.WriteLine("Movie 2 Details:");
            Console.WriteLine($"Name: {darkKnightRises.Name}");
            Console.WriteLine($"Year: {darkKnightRises.Year}");
            Console.WriteLine($"Director: {darkKnightRises.Director.Name}");
            Console.WriteLine("Actors:");
            foreach (var actor in darkKnightRises.Actors)
            {
                Console.WriteLine($"- {actor.Name}");
            }
        }
    }
}
