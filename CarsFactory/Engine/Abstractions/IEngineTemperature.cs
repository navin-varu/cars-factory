using System;
using System.Collections.Generic;
using System.Text;

namespace CarsFactory.Engine.Abstractions
{
    /// <summary>
    /// Defines a class which is responsible to provide engine's temperature.
    /// </summary>
    public interface IEngineTemperature
    {
        /// <summary>
        /// Measures engine's temperature for a given car speed.
        /// </summary>
        /// <param name="speed"></param>
        /// <returns></returns>
        decimal Measure(decimal speed);
    }
}
