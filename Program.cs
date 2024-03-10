// all object interaction happens here. ex moving player on map and updating player values
using HuntTheWumpus1;
using System.Reflection.Metadata.Ecma335;

int numOfRow = 4;
int numOfCol = 4;
HuntTheWumpus @HuntTheWumpus = new HuntTheWumpus(new Map(numOfRow, numOfCol), new Player());

do
{
    Console.WriteLine("Enter one of the following commands ('move north', 'move south', 'move east', 'move west').");
    printPlayerLocation(HuntTheWumpus.PlayerAt);
    Console.Write("What do you want to do? ");
    HuntTheWumpus.MovePlayer(Console.ReadLine().ToLower());
} while (true);

void printPlayerLocation((int row, int column) playerAt)
{
    Console.WriteLine($"You are in the room at (Row: {playerAt.row}, Column: {playerAt.column} )");
}