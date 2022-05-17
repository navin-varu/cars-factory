using CarsFactory.Engine.FuelRequirementRules.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarsFactory.Engine.FuelRequirementRules.Implementations
{
    public class MediumSpeedFuelRequirementRule : IFuelRequirementRule
    {
        public decimal GetFuelRequirement(int speed)
        {
            return (speed >= 61 && speed <= 100) ? 0.0014M : 0;
        }
    }
}
