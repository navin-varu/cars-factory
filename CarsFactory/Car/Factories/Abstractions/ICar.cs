using CarsFactory.Common;
using CarsFactory.Engine.Abstractions;
using CarsFactory.FuelTank.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarsFactory.Car.Factories.Abstractions
{
    /// <summary>
    /// Defines a class that represents the eligibility to become a car.
    /// </summary>
    public interface ICar
    {
        /// <summary>
        /// Created car unique id.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Defines maximum car speed.
        /// </summary>
        int MaxSpeed { get; }

        /// <summary>
        /// Current car speed.
        /// </summary>
        int Speed { get; }

        /// <summary>
        /// Cars's color.
        /// </summary>
        string Color { get; }

        /// <summary>
        /// Car's brand.
        /// </summary>
        string Brand { get; }

        /// <summary>
        /// Car creation date.
        /// </summary>
        DateTime CreatedDate { get; }

        /// <summary>
        /// Car's current status.
        /// </summary>
        CarStatus Status { get; }

        /// <summary>
        /// Represents car's engine.
        /// </summary>
        IEngine Engine { get; }

        /// <summary>
        /// Represents car's fuel tank.
        /// </summary>
        IFuelTank FuelTank { get;}

        /// <summary>
        /// Starts a car.
        /// </summary>
        void Start();

        /// <summary>
        /// Represents a started car but not running.
        /// </summary>
        void RunningIdle();

        /// <summary>
        /// Accelerates a car to provided acceleration.
        /// </summary>
        void Accelerate();

        /// <summary>
        /// Deaccelerates a car to provided deacceleration.
        /// </summary>
        void Deaccelerate();

        /// <summary>
        /// Stops a car.
        /// </summary>
        void Stop();

        /// <summary>
        /// Refuels a car by given liters.
        /// </summary>
        /// <param name="liter"></param>
        void Refuel(decimal liter);

        /// <summary>
        /// Gives manufacturing status of a car.
        /// </summary>
        /// <returns></returns>
        Dictionary<string, string> GetManufacturingStatus();

        /// <summary>
        /// Gives details regarding internal dashboard of a car.
        /// </summary>
        /// <returns></returns>
        Dictionary<string, string> GetDashboardDetails();
    }
}
