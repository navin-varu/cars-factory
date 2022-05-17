using CarsFactory.Car.Factories.Abstractions;
using CarsFactory.Common;
using CarsFactory.Engine.Abstractions;
using CarsFactory.FuelTank.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarsFactory.Car.Factories.Implementations.TATA
{
    public class TataCarFactory : ICarFactory
    {
        public IEngine Engine { get; private set; }

        public IFuelTank FuelTank { get; private set; }

        public CarBrand CarBrand { get; } = CarBrand.Tata;

        public TataCarFactory(IEngine engine, IFuelTank fuelTank)
        {
            Engine = engine;
            FuelTank = fuelTank;
        }

        public BaseCar Create()
        {
            string id = Guid.NewGuid().ToString();
            return new TataCar(id, Engine, FuelTank);
        }
    }
}
