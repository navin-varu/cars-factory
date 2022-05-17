using CarsFactory.Engine.FuelRequirementRules.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarsFactory.Engine.FuelRequirementRules.Implementations
{
    public class FastSpeedFuelRequirementRule : IFuelRequirementRule
    {
        public decimal GetFuelRequirement(int speed)
        {
            return (speed >= 101 && speed <= 140) ? 0.0020M : 0;
        }
    }
}
