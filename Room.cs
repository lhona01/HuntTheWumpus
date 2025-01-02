using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HuntTheWumpus1
{

    // Class Map contains rooms
    public class Room
    {

    }

    public class EntranceRoom : Room
    {
        public EntranceRoom() { }

    }

    public class FountainRoom: Room
    {
        public bool IsEnabled { get; private set; } = false;
        public FountainRoom()
        {
        }
        public void EnableFountain() => IsEnabled = true;

        public void DisableFountain() => IsEnabled = false;
    }

    public class PitRoom : Room
    {
        public PitRoom(int row, int col) { }
    }
}
