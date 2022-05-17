using CarsFactory.Engine.FuelRequirementRules.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarsFactory.Engine.FuelRequirementRules.Implementations
{
    public class IdleSpeedFuelRequirementRule : IFuelRequirementRule
    {
        public decimal GetFuelRequirement(int speed)
        {
            return (speed == 0) ? 0.0003M : 0;
        }
    }
}
