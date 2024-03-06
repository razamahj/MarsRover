using MarsRovers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers
{
    internal class SimpleMovement : IMovement
    {
        public void Move(ref int x, ref int y, string direction, int distance)
        {
            switch (direction)
            {
                case "North":
                    y = Math.Max(1, Math.Min(100, y - distance));
                    break;
                case "East":
                    x = Math.Max(1, Math.Min(100, x + distance));
                    break;
                case "South":
                    y = Math.Max(1, Math.Min(100, y + distance));
                    break;
                case "West":
                    x = Math.Max(1, Math.Min(100, x - distance));
                    break;
            }
        }
    }
}
