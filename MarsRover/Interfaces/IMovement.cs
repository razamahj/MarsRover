using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers.Interfaces
{
    public interface IMovement
    {
        void Move(ref int x, ref int y, string direction, int distance);
    }
}
