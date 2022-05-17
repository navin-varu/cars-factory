using CarsFactory.Car.Factories.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarsFactoryConsole.Operations.Abstractions
{
    /// <summary>
    /// Defines a class that represents a task regarding car handling.
    /// </summary>
    public interface ICarTask
    {
        /// <summary>
        /// Represents a car handling operation.
        /// </summary>
        Operation Operation { get; }

        /// <summary>
        /// Completes the requested car task.
        /// </summary>
        /// <param name="car"></param>
        /// <param name="carTaskDetail"></param>
        void Complete(BaseCar car, CarTaskDetail carTaskDetail);
    }
}
