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
            MarsRover rover = new MarsRover();
            rover.Move(50);
            rover.TurnLeft();
            rover.Move(23);
            rover.TurnLeft();
            rover.Move(4);

            Console.ReadLine();
        }
    }
}
