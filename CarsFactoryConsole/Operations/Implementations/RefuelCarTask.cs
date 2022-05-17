using CarsFactory.Car.Factories.Abstractions;
using CarsFactoryConsole.Operations.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarsFactoryConsole.Operations.Implementations
{
    public class RefuelCarTask : ICarTask
    {
        public Operation Operation { get; } = Operation.Refuel;

        public void Complete(BaseCar car, CarTaskDetail carTaskDetail)
        {
            car.Refuel(carTaskDetail.FuelAmount);
        }
    }
}
