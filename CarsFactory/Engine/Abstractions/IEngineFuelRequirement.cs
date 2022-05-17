using System;
using System.Collections.Generic;
using System.Text;

namespace CarsFactory.Engine.Abstractions
{
    /// <summary>
    /// Defines a class which is responsible to provide engine's fuel requirement.
    /// </summary>
    public interface IEngineFuelRequirement
    {
        /// <summary>
        /// Calculates engine's total fuel requirement for a given car speed.
        /// </summary>
        /// <param name="speed"></param>
        /// <returns></returns>
        decimal CalculateFuelRequirement(int speed);
    }
}
