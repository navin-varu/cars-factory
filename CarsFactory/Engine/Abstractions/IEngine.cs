using CarsFactory.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarsFactory.Engine.Abstractions
{
    /// <summary>
    /// Defines a class which represents a car engine.
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// Engine's current status.
        /// </summary>
        EngineStatus Status { get; }

        /// <summary>
        /// Total fuel consumed by engine till now.
        /// </summary>
        decimal TotalFuelConsumed { get; }

        /// <summary>
        /// Engine's fuel consumption rate when a car is idle
        /// </summary>
        decimal RunningIdleFuelConsumption { get; }

        /// <summary>
        /// Engine's fuel consumption rate when a car is started
        /// </summary>
        decimal StartingFuelConsumption { get; }

        /// <summary>
        /// Represents engine's current temperature.
        /// </summary>
        decimal Temperature { get; }

        /// <summary>
        /// Starts the engine.
        /// </summary>
        /// <returns></returns>
        decimal Start();

        /// <summary>
        /// Engine's running when car is idle.
        /// </summary>
        /// <returns></returns>
        decimal RunningIdle();

        /// <summary>
        /// Accelerates the car engine.
        /// </summary>
        /// <param name="speed"></param>
        /// <param name="fuel"></param>
        void Accelerate(int speed, decimal fuel);

        /// <summary>
        /// Deaccelerates the car engine.
        /// </summary>
        /// <param name="speed"></param>
        /// <param name="fuel"></param>
        void Deaccelerate(int speed, decimal fuel);

        /// <summary>
        /// Stops the engine.
        /// </summary>
        void Stop();

        /// <summary>
        /// Gets engine's fuel requirement for current car speed.
        /// </summary>
        /// <param name="speed"></param>
        /// <returns></returns>
        decimal GetRequiredFuel(int speed);

    }
}
