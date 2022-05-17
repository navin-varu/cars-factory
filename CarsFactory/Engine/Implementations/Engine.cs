using CarsFactory.Common;
using CarsFactory.Engine.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarsFactory.Engine.Implementations
{
    public class Engine : IEngine
    {
        private readonly IEngineFuelRequirement _engineFuelRequirement;
        private readonly IEngineTemperature _engineTemperature;

        public EngineStatus Status { get; private set; } = EngineStatus.Idle;

        public decimal TotalFuelConsumed { get; private set; }

        public decimal RunningIdleFuelConsumption { get; private set; } = 0.0003M;

        public decimal StartingFuelConsumption { get; private set; } = 0;

        public decimal Temperature { get; private set; }

        public Engine(IEngineFuelRequirement engineFuelRequirement, IEngineTemperature engineTemperature)
        {
            _engineFuelRequirement = engineFuelRequirement;
            _engineTemperature = engineTemperature;
        }

        public void Accelerate(int speed, decimal fuel)
        {
            TotalFuelConsumed += fuel;
            Temperature = _engineTemperature.Measure(speed);
            Status = EngineStatus.Accelerated;
        }

        public void Deaccelerate(int speed, decimal fuel)
        {
            TotalFuelConsumed += fuel;
            Temperature = _engineTemperature.Measure(speed);
            Status = EngineStatus.Deaccelerated;
        }

        public decimal Start()
        {
            TotalFuelConsumed = StartingFuelConsumption;
            Status = EngineStatus.Started;
            Temperature = _engineTemperature.Measure(0);
            return TotalFuelConsumed;
        }

        public void Stop()
        {
            Status = EngineStatus.Stopped;
            Temperature = _engineTemperature.Measure(0);
            TotalFuelConsumed = 0;
        }

        public decimal GetRequiredFuel(int speed)
        {
            return _engineFuelRequirement.CalculateFuelRequirement(speed);
        }

        public decimal RunningIdle()
        {
            TotalFuelConsumed += RunningIdleFuelConsumption;
            Temperature = _engineTemperature.Measure(0);
            Status = EngineStatus.RunningIdle;
            return TotalFuelConsumed;
        }
    }
}
