using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers
{
    class Program
    {
        static void Main()
        {
            var movement = new SimpleMovement();
            var turn = new SimpleTurn();
            var positionReporter = new ConsolePositionReporter();

            var rover = new MarsRover(movement, turn, positionReporter);

            rover.Move(50);
            rover.TurnLeft();
            rover.Move(23);
            rover.TurnLeft();
            rover.Move(4);

            Console.ReadLine();
        }
    }
}
