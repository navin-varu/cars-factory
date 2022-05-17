using CarsFactory.Engine.FuelRequirementRules.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarsFactory.Engine.FuelRequirementRules.Implementations
{
    public class FasterSpeedFuelRequirementRule : IFuelRequirementRule
    {
        public decimal GetFuelRequirement(int speed)
        {
            return (speed >= 141 && speed <= 200) ? 0.0025M : 0;
        }
    }
}
