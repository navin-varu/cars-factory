using CarsFactory.Car.Factories.Abstractions;
using CarsFactory.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarsFactory.Car.Loader.Abstractions
{
    /// <summary>
    /// Defines a class which is responsible to select a specific car factory to create a desired car.
    /// </summary>
    public interface ICarFactoryLoader
    {
        /// <summary>
        /// Selects an intended car factory by a given car brand.
        /// </summary>
        /// <param name="carBrand"></param>
        /// <returns></returns>
        ICarFactory Select(CarBrand carBrand);
    }
}
