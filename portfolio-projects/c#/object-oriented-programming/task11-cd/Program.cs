using System;
using System.Collections.Generic;

public class CD
{
    public string Title { get; set; }
    public string Artist { get; set; }
    public string Genre { get; set; }
    public int ReleaseYear { get; set; }
    public int Duration { get; set; }
    public double Price { get; set; }
    public List<string> Songs { get; set; }


    public CD(string title, string artist, string genre, int releaseYear, int duration, double price, List<string> songs)
    {
        Title = title;
        Artist = artist;
        Genre = genre;
        ReleaseYear = releaseYear;
        Duration = duration;
        Price = price;
        Songs = songs;
    }


    public string GetAllInfo()
    {
        string info = $"Title: {Title}\n";
        info += $"Artist: {Artist}\n";
        info += $"Genre: {Genre}\n";
        info += $"Release Date: {ReleaseYear}\n";
        info += $"Price: {Price}e\n";
        info += $"Duration: {Duration} minutes\n";
        info += "Songs:\n";
        foreach (string song in Songs)
        {
            info += $"- {song}\n";
        }
        return info;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var songs1 = new List<string> {
            "Shudder Before the Beautiful - 06:29",
            "Weak Fantasy - 05:23",
            "Elan - 04:45",
            "Yours Is an Empty Hope - 05:34",
            "Our Decades in the Sun - 06:37",
            "My Walden - 04:38",
            "Endless Forms Most Beautiful - 05:07",
            "Edema Ruh - 05:15",
            "Alpenglow - 04:45",
            "The Eyes of Sharbat Gula - 06:03",
            "The Greatest Show on Earth - 24:00"
        };
        CD cd1 = new CD("Endless Forms Most Beautiful", "Nightwish", "Symphonic metal", 2015, 60, 19.90, songs1);

        Console.WriteLine(cd1.GetAllInfo());
    


        var songs2 = new List<string> {
        "Blowin' in the Wind - 02:48",
        "The Times They Are a-Changin' - 03:15",
        "Like a Rolling Stone - 06:13",
        "Tangled Up in Blue - 05:42",
        "Knockin' on Heaven's Door - 02:30"
    };

        CD cd2 = new CD("Bob Dylan", "Greatest Hits", "Folk", 1971, 40, 19.90, songs2);

        Console.WriteLine(cd2.GetAllInfo());
    }
}
