using MarsRovers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers
{
    public class ConsolePositionReporter : IPositionReporter
    {
        public void ReportPosition(int x, int y, string direction)
        {
            Console.WriteLine($"Current position: {y * 100 + x + 1} {direction}");  
        }
    }
}
