using CarsFactory.Car.Factories.Abstractions;
using CarsFactoryConsole.Operations.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarsFactoryConsole.Operations.Implementations
{
    public class AccelerateCarTask : ICarTask
    {
        public Operation Operation { get; } = Operation.Accelerate;

        public void Complete(BaseCar car, CarTaskDetail carTaskDetail)
        {
            car.DefaultAcceleration = carTaskDetail.Speed;
            car.Accelerate();
        }
    }
}
