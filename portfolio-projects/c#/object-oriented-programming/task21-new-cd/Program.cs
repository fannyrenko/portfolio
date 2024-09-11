using System;
using System.Collections.Generic;
using System.Linq;


namespace task21_new_cd
{
    class Song
    {   
        // properties
        public string Name { get; set; }
        public int LengthInSeconds { get; set; }

        // constructor
        public Song(string name, int lengthInSeconds)
        {
            Name = name;
            LengthInSeconds = lengthInSeconds;
        }

        // methods
        public override string ToString()
        {
            return $"- {Name}, {LengthInSeconds / 60}:{LengthInSeconds % 60:D2}";
        }
    }

    class CD
    {   
        // properties
        public string Name { get; set; }
        public string Artist { get; set; }
        public readonly List<Song> Songs = new List<Song>();
        
        // constructor
        public CD(string name, string artist)
        {
            Name = name;
            Artist = artist;

        }

        // methods
        public void AddSong(Song song)
        {
            Songs.Add(song);
        }

        public string ShowSongs()
        {
            string msg = "";
            foreach (Song song in Songs)
            {
                msg += song.ToString() + "\n";
            }
            return msg;
        }

        // readonly property to get the number of songs on the CD
        public int NumberOfSongs
        {
            get { return Songs.Count; }
        }


        // readonly property to get the total length of all songs on the CD
        public string TotalLength
        {
            get
            {
                int totalSeconds = Songs.Sum(song => song.LengthInSeconds);
                int minutes = totalSeconds / 60;
                int seconds = totalSeconds % 60;
                return $"{minutes} min {seconds} sec";
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a CD object with a name and artist
            CD cd = new CD("Endless Forms Most Beautiful", "Nightwish");
            // Add songs to the CD
            cd.AddSong(new Song("Shudder Before the Beautiful", 389));
            cd.AddSong(new Song("Weak Fantasy", 323));
            cd.AddSong(new Song("Elan", 285));
            cd.AddSong(new Song("Yours Is an Empty Hope", 334));
            cd.AddSong(new Song("Our Decades in the Sun", 397));
            cd.AddSong(new Song("My Walden", 278));
            cd.AddSong(new Song("Endless Forms Most Beautiful", 307));
            cd.AddSong(new Song("Edema Ruh", 315));
            cd.AddSong(new Song("Alpenglow", 285));
            cd.AddSong(new Song("The Eyes of Sharbat Gula", 363));
            cd.AddSong(new Song("The Greatest Show on Earth", 1440));

            // Print the details of the CD
            Console.WriteLine("You have a CD:");
            Console.WriteLine("- Name: " + cd.Name);
            Console.WriteLine("- Artist: " + cd.Artist);
            Console.WriteLine("- Total Length: " + cd.TotalLength);
            Console.WriteLine("- Number of Songs: " + cd.NumberOfSongs);
            Console.WriteLine("- Songs:");
            Console.WriteLine(cd.ShowSongs());
        }
    }
}
