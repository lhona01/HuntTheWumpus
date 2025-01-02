using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuntTheWumpus1
{
    public class Map
    {
        public Object[,] Room { get; private set; }
        public Map(int row, int column)
        {
            Room = new Room[row, column];
            int countRoomsAssigned = 0;
            // add rooms to the game map
            for (int x = 0; x < row; x++)
            {
                for (int y = 0; y < column; y++)
                {
                    if (x == 0 && y == 0)
                        Room[x, y] = new EntranceRoom();
                    else if (x == 0 && y == 2)
                        Room[x, y] = new FountainRoom();
                    else
                        Room[x, y] = new Room();
                    
                    countRoomsAssigned++;
                }
            }
        }
    }
}