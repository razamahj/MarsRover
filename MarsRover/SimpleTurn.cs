using MarsRovers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers
{
    public class SimpleTurn : ITurn
    {
        public string Turn(string direction, string turnDirection)
        {
            return (direction, turnDirection) switch
            {
                ("South", "Left") => "East",
                ("North", "Left") => "West",
                ("East", "Left") => "North",
                ("West", "Left") => "South",

                ("South", "Right") => "West",
                ("North", "Right") => "East",
                ("East", "Right") => "South",
                ("West", "Right") => "North",
                (_, _) => throw new InvalidOperationException("Invalid turn direction")
            };
        }
    }
}
