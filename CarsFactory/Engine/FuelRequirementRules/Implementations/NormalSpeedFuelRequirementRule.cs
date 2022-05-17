using CarsFactory.Engine.FuelRequirementRules.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarsFactory.Engine.FuelRequirementRules.Implementations
{
    public class NormalSpeedFuelRequirementRule : IFuelRequirementRule
    {
        public decimal GetFuelRequirement(int speed)
        {
            return (speed >= 1 && speed <= 60) ? 0.0020M : 0;
        }
    }
}
