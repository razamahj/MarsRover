using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers
{
    public class MarsRover
    {
        public int x;
        public int y;
        public string direction;

        public MarsRover()
        {
            x = 0;
            y = 0;
            direction = "South";
        }

        public void Move(int distance)
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

            ReportPosition();
        }

        public void TurnLeft()
        {
            switch (direction)
            {
                case "South":
                    direction = "East";
                    break;
                case "North":
                    direction = "West";
                    break;
                case "East":
                    direction = "North";
                    break;
                case "West":
                    direction = "South";
                    break;
            }
            ReportPosition();
        }

        public void TurnRight()
        {
            switch (direction)
            {
                case "South":
                    direction = "West";
                    break;
                case "North":
                    direction = "East";
                    break;
                case "East":
                    direction = "South";
                    break;
                case "West":
                    direction = "North";
                    break;
            }
            ReportPosition();
        }

        public void ReportPosition()
        {
            Console.WriteLine($"Current Position: {y * 100 + x + 1} {direction}");
        }
    }
}
