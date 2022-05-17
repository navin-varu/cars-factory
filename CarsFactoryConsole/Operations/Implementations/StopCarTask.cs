using CarsFactory.Car.Factories.Abstractions;
using CarsFactoryConsole.Operations.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarsFactoryConsole.Operations.Implementations
{
    public class StopCarTask : ICarTask
    {
        public Operation Operation { get; } = Operation.Stop;

        public void Complete(BaseCar car, CarTaskDetail carTaskDetail)
        {
            car.Stop();
        }
    }
}
