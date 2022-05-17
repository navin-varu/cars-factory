using CarsFactory.Car.Factories.Abstractions;
using CarsFactoryConsole.Operations.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarsFactoryConsole.Operations.Implementations
{
    public class IdleCarTask : ICarTask
    {
        public Operation Operation { get; } = Operation.Idle;

        public void Complete(BaseCar car, CarTaskDetail carTaskDetail)
        {
            
        }
    }
}
