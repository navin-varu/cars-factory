using CarsFactory.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarsFactory.FuelTank.Abstractions
{
    /// <summary>
    /// Defines a class which represents a car fuel tank.
    /// </summary>
    public interface IFuelTank
    {
        FuelTankStatus Status { get; }

        /// <summary>
        /// Fuel tank's maximun capacity.
        /// </summary>
        int Size { get; }

        /// <summary>
        /// Level at which fuel tank gets reserved.
        /// </summary>
        decimal ReserveLevel { get; }

        /// <summary>
        /// Current fuel tank level.
        /// </summary>
        decimal Level { get; }

        /// <summary>
        /// Fuel tank can be reflued.
        /// </summary>
        /// <param name="liter"></param>
        void Refuel(decimal liter);

        /// <summary>
        /// Car use's fuel to do a task.
        /// </summary>
        /// <param name="liter"></param>
        void UseFuel(decimal liter);

    }
}
