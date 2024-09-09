using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task2_hill_jumping
{
    // Score class
    public class Score
    {
        // properties
        private int Points { get; set; }

        // constructor
        public Score(int points)
        {
            Points = points;
        }

        // method to calculate lowest point
        private int LowestScore(List<Score> scores)
        {
            return scores.Min(s => s.Points);
        }

        // method to calculate highest point
        private int HighestScore(List<Score> scores)
        {
            return scores.Max(s => s.Points);
        }

        // method to calculate final score
        public int CalculateFinalScore(List<Score> scores)
        {
            int sum = scores.Sum(s => s.Points);
            int lowest = LowestScore(scores);
            int highest = HighestScore(scores);
            int finalscore = sum - lowest - highest;
            return finalscore;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // a list of points
            List<Score> scores = new List<Score>();

            // ask user five times to give points (5 judges)
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Give points: ");
                // convert given string to int
                if (int.TryParse(Console.ReadLine(), out int points))
                {
                    // add number to scores list
                    scores.Add(new Score(points));
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter an integer for the points.");
                    break;
                }
            }

            // create a new instance of Score
            Score score = new Score(0);

            // calculate final score
            int finalScore = score.CalculateFinalScore(scores);

            // print final score
            Console.WriteLine($"Final Score: {finalScore}");
        }
    }
}
    