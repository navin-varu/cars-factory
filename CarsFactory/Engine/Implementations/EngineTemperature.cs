using CarsFactory.Engine.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarsFactory.Engine.Implementations
{
    public class EngineTemperature : IEngineTemperature
    {
        public decimal Measure(decimal speed)
        {
            return speed * 0.1M * 3.5M;
        }
    }
}
