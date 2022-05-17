using CarsFactory.Car.Factories.Abstractions;
using CarsFactoryConsole.Operations.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarsFactoryConsole.Operations.Implementations
{
    public class BrakeCarTask : ICarTask
    {
        public Operation Operation { get; } = Operation.Brake;

        public void Complete(BaseCar car, CarTaskDetail carTaskDetail)
        {
            car.DefaultDeacceleration = carTaskDetail.Speed;
            car.Deaccelerate();
        }
    }
}
