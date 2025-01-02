// all object interaction happens here. ex moving player on map and updating player values
using HuntTheWumpus1;
using System.Reflection.Metadata.Ecma335;

Game @Game = new Game(new Player());

do
{
    Console.WriteLine("Enter one of the following commands ('move north', 'move south', 'move east', 'move west', 'enable fountain', disable fountain').", Console.ForegroundColor = ConsoleColor.Cyan);
    printPlayerLocation(Game.PlayerAt);

    if (Game.PlayerAt == (0, 0))
    {
        Console.WriteLine("You see light in this room coming from outside the cavern. This is the entrance.", Console.ForegroundColor = ConsoleColor.Green);
    }

    if (Game.Map.Room[Game.PlayerAt.row, Game.PlayerAt.column] is FountainRoom)
    {
        var fountain = (FountainRoom)Game.Map.Room[Game.PlayerAt.row, Game.PlayerAt.column] ;
        if (fountain.IsEnabled == true)
        {
            Game.Player.Hear = Sound.rushing;
            Console.WriteLine($"You hear {Game.Player.Hear} water from fountain of object. It has been reactivated. (enabled)", Console.ForegroundColor = ConsoleColor.Gray);
        }
        else
        {
            Game.Player.Hear = Sound.dripping;
            Console.WriteLine($"You hear {Game.Player.Hear} water in this room. The Fountain of Object is here (disabled).", Console.ForegroundColor = ConsoleColor.Gray);
        }
    }

    if (Game.Map.Room[Game.PlayerAt.row, Game.PlayerAt.column] is EntranceRoom)
        if (CheckWin((EntranceRoom)Game.Map.Room[Game.PlayerAt.row, Game.PlayerAt.column], (FountainRoom)Game.Map.Room[0, 2]))
        {
            Console.WriteLine("The fountain of youth have been reactivated, and you have escaped with your life!\n Yow Win!", Console.ForegroundColor = ConsoleColor.Red);
            Console.ForegroundColor = ConsoleColor.White;
            break;
        }

    Console.Write("What do you want to do? ", Console.ForegroundColor = ConsoleColor.Blue);
    MovePlayer(Console.ReadLine().ToLower());
} while (true);

void printPlayerLocation((int row, int column) playerAt)
{
    Console.WriteLine($"You are in the room at (Row: {playerAt.row}, Column: {playerAt.column} )", Console.ForegroundColor = ConsoleColor.White);
}

void MovePlayer(string direction)
{
    Console.Clear();
    switch (direction)
    {
        case "move north":
            if (!IsPlayerOverBoundary(Game.PlayerAt.row + 1))
                Game.PlayerAt.row++;
            break;
        case "move east":
            if (!IsPlayerOverBoundary(Game.PlayerAt.column + 1))
                Game.PlayerAt.column++;
            break;
        case "move south":
            if (!IsPlayerOverBoundary(Game.PlayerAt.row - 1))
                Game.PlayerAt.row--;
            break;
        case "move west":
            if (!IsPlayerOverBoundary(Game.PlayerAt.column - 1))
                Game.PlayerAt.column--;
            break;
        case "enable fountain":
            var enableFountain = (FountainRoom)Game.Map.Room[Game.PlayerAt.row, Game.PlayerAt.column];
            if (enableFountain != null)
                enableFountain.EnableFountain();
            else
                Console.WriteLine("No fountain of object found", Console.ForegroundColor = ConsoleColor.Red);
            break;
        case "disable fountain":
            var disableFountain = (FountainRoom)Game.Map.Room[Game.PlayerAt.row, Game.PlayerAt.column];
            if (disableFountain != null)
                disableFountain.DisableFountain();
            else
                Console.WriteLine("No fountain of object found", Console.ForegroundColor = ConsoleColor.Red);
            break;
        default:
            Console.Clear();
            Console.WriteLine($"Error! couldn't understant '{direction}'. try again.", Console.ForegroundColor = ConsoleColor.Red);
            break;
    }
}

bool IsPlayerOverBoundary(int nextMove)
{
    Console.Clear();
    if (nextMove < Game.Map?.Room.GetLength(0) && nextMove >= 0)
        return false;
    else if (nextMove < Game.Map?.Room.GetLength(1) && nextMove >= 0)
        return false;
    else
    {
        Console.WriteLine($"Can't go over boundary! Try again.", Console.ForegroundColor = ConsoleColor.Red);
        return true; //yes
    }
}

bool CheckWin(EntranceRoom playerAt, FountainRoom fountainRoom)
{
    if (playerAt is EntranceRoom && fountainRoom.IsEnabled == true)
        return true;
    else
        return false;
}