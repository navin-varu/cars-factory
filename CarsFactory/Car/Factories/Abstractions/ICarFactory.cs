using CarsFactory.Common;
using CarsFactory.Engine.Abstractions;
using CarsFactory.FuelTank.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarsFactory.Car.Factories.Abstractions
{
    /// <summary>
    /// Defines a car factory which is responsible to create car.
    /// </summary>
    public interface ICarFactory
    {
        /// <summary>
        /// Car's brand.
        /// </summary>
        CarBrand CarBrand { get; }

        /// <summary>
        /// The engine which is going to be assembled in a created car.
        /// </summary>
        IEngine Engine { get; }

        /// <summary>
        /// The fuel tank which is going to be mounted in a created car.
        /// </summary>
        IFuelTank FuelTank { get; }

        /// <summary>
        /// Creates a car for a given car brand.
        /// </summary>
        /// <returns></returns>
        BaseCar Create();
    }
}
