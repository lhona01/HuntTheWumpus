using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuntTheWumpus1
{
    public class HuntTheWumpus
    {
        // initialize objects
        public Map @Map { get; private set; }
        public Player @Player { get; private set; }
        public (int row, int column) PlayerAt = (0, 0); // keep track of players location 
        public HuntTheWumpus(Map map, Player player)
        {
            @Map = map;
            @Player = player;
        }

        public void MovePlayer(string direction)
        {
            switch (direction)
            {
                case "move north":
                    if (!IsPlayerOverBoundary(PlayerAt.row + 1))
                        PlayerAt.row++;
                    break;
                case "move east":
                    if (!IsPlayerOverBoundary(PlayerAt.column + 1))
                        PlayerAt.column++;
                    break;
                case "move south":
                    if (!IsPlayerOverBoundary(PlayerAt.row - 1))
                        PlayerAt.row--;
                    break;
                case "move west":
                    if (!IsPlayerOverBoundary(PlayerAt.column - 1))
                        PlayerAt.column--;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine($"Error! couldn't understant '{direction}'. try again.");
                    break;
            }
        }

        bool IsPlayerOverBoundary(int nextMove)
        {
            Console.Clear();
            if (nextMove < Map?.Room.GetLength(0) && nextMove >= 0)
                return false;
            else if (nextMove < Map?.Room.GetLength(1) && nextMove >= 0)
                return false;
            else
            {
                Console.WriteLine($"Can't go over boundary! Try again.");
                return true; //yes
            }
        }
    }
}
