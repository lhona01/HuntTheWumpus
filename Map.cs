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
        public Room[,] @Room { get; set; }
        public Map(int row, int column)
        {
            Room = new Room[row, column];
            int countRoomsAssigned = 0;
            // add rooms to the game map
            for (int x = 0; x < row; x++)
            {
                for (int y = 0; y < column; y++)
                {
                    @Room[x, y] = new Room(countRoomsAssigned);
                    countRoomsAssigned++;
                }
            }
        }
    }

    // Class Map contains rooms
    public class Room
    {
        public int RoomNumber { get; private set; }

        public Room(int roomNumber)
        {
            RoomNumber = roomNumber;
        }
    }
}