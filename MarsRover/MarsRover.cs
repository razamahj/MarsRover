using MarsRovers.Interfaces;
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

        private readonly IMovement movement;
        private readonly ITurn turn;
        private readonly IPositionReporter positionReporter;

        public MarsRover(IMovement movement,ITurn turn, IPositionReporter positionReporter)
        {
            this.turn = turn ?? throw new ArgumentNullException(nameof(turn));
            this.movement = movement ?? throw new ArgumentNullException(nameof(movement));
            this.positionReporter = positionReporter ?? throw new ArgumentNullException(nameof(positionReporter));

            x = 1;
            y = 1;
            direction = "South";
        }

        public void Move(int distance)
        {
            movement.Move(ref x, ref y, direction, distance);
            ReportPosition();
        }

        public void TurnLeft()
        {
            direction = turn.Turn(direction, "Left");
            ReportPosition();
        }

        public void TurnRight()
        {
            direction = turn.Turn(direction, "Right");
            ReportPosition();
        }

        public void ReportPosition()
        {
            positionReporter.ReportPosition(x, y, direction);
        }
    }
}
