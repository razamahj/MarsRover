﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers.Interfaces
{
    public interface IPositionReporter
    {
        void ReportPosition(int x, int y, string direction);
    }
}
