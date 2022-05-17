using CarsFactory.Car.Factories.Abstractions;
using CarsFactory.Common;
using CarsFactory.Engine.Abstractions;
using CarsFactory.FuelTank.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarsFactory.Car.Factories.Implementations.TATA
{
    public class TataCar : BaseCar
    {
        public TataCar(string id, IEngine engine, IFuelTank fuelTank)
        {
            Id = id;
            Engine = engine;
            FuelTank = fuelTank;
            Color = Constants.Car.Color.WHITE;
            Brand = Constants.Car.Brand.TATA;
        }
    }
}
