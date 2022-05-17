using System;
using System.Collections.Generic;
using System.Text;

namespace CarsFactory.Common
{
    /// <summary>
    /// Engine status enumerations.
    /// </summary>
    public enum EngineStatus
    {
        Started,
        Accelerated,
        Deaccelerated,
        Stopped,
        Idle,
        RunningIdle
    }

    /// <summary>
    /// Fuel tank status enumerations.
    /// </summary>
    public enum FuelTankStatus
    {
        Full,
        Empty,
        Reserve,
        Suffiecient,
        UnKnown
    }

    /// <summary>
    /// Car status enumerations.
    /// </summary>
    public enum CarStatus
    {
        Started,
        Accelerated,
        Deaccelerated,
        Stopped,
        Idle,
        RunningIdle,
        Refueled
    }

    /// <summary>
    /// Fuel requirement speed enumerations.
    /// </summary>
    public enum FuelRequirementSpeed
    {
        Idle,
        Slow,
        Medium,
        Fast,
        Faster,
        Fastest
    }

    /// <summary>
    /// Car brand enumerations.
    /// </summary>
    public enum CarBrand
    {
        BMW,
        Audi,
        Tata,
        Unknown
    }
}
