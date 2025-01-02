using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuntTheWumpus1
{
    public class Game
    {
        // initialize objects
        public Map @Map { get; private set; }
        public Player @Player { get; private set; }

        public (int row, int column) PlayerAt = (0, 0); // keep track of players location 
        public Game(Player player)
        {
            SetDifficulty();
            @Player = player;
        }

        public void SetDifficulty()
        {
            string difficulty;
            Console.WriteLine("Would you like to play Small = (4x4), Medium = (6x6), or Large = (8x8) game?", Console.ForegroundColor = ConsoleColor.Green);
            difficulty = Console.ReadLine().ToLower();
            
            switch (difficulty)
            {
                case "small":
                    Map = new Map(4, 4);
                    break;
                case "medium":
                    Map = new Map(6, 6);
                    break;
                case "large":
                    Map = new Map(8, 8);
                    break;
                default:
                    Console.WriteLine("Wrong input, try again!");
                    break;
            }

            Console.Clear();
        }
    }
}
