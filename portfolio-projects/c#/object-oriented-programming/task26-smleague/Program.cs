using System;
using System.Collections.Generic;


class Program
{
    public class Player
    {
        // player properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GameLocation { get; set; }
        public int Number { get; set; }

        // constructor
        public Player(string firstName, string lastName, string gameLocation, int number)
        {
            FirstName = firstName;
            LastName = lastName;
            GameLocation = gameLocation;
            Number = number;
        }
    }

    public class Team
    {
        // team properties
        public string Name { get; }
        public string Hometown { get; }
        public List<Player> Players { get; }

        // constructor
        public Team(string team)
        {
            Name = team;
            Players = new List<Player>();

            // add players based on the team name
            if (team == "JYP")
            {
                Hometown = "Jyväskylä";
            }
            else if (team == "Ilves")
            {
                Hometown = "Tampere";
            }
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            Players.Remove(player);
        }

        public void ListPlayers()
        {
            Console.WriteLine($"Players for {Name}, {Hometown}:");
            foreach (var player in Players)
            {
                Console.WriteLine($"Name: {player.FirstName} {player.LastName}, Game Location: {player.GameLocation}, Number: {player.Number}");
            }
        }
    }


    static void Main(string[] args)
    {
        // Create teams
        Team jyp = new Team("JYP");
        Team ilves = new Team("Ilves");

        // create players for jyp
        Player jypPlayer1 = new Player("Niko", "Minkkinen", "Puolustaja", 2);
        Player jypPlayer2 = new Player("Miks", "Tumanovs", "Puolustaja", 16);

        // create players for ilves
        Player ilvesPlayer1 = new Player("Sebastian", "Soini", "Puolustaja", 6);
        Player ilvesPlayer2 = new Player("Eemeli", "Suomi", "Hyökkääjä", 10);

        // add players to team jyp
        jyp.AddPlayer(jypPlayer1);
        jyp.AddPlayer(jypPlayer2);

        // add players to team ilves
        ilves.AddPlayer(ilvesPlayer1);
        ilves.AddPlayer(ilvesPlayer2);

        // List players for each team
        jyp.ListPlayers();
        ilves.ListPlayers();
    }



}
