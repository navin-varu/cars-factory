using System;
using System.Collections.Generic;
using System.Text;

namespace CarsFactory.Engine.FuelRequirementRules.Abstractions
{
    /// <summary>
    /// Defines a class which represents engine's fuel requirement at specified car speed.
    /// </summary>
    public interface IFuelRequirementRule
    {
        /// <summary>
        /// Gets fuel requirement for a given speed.
        /// </summary>
        /// <param name="speed"></param>
        /// <returns></returns>
        decimal GetFuelRequirement(int speed);
    }
}
