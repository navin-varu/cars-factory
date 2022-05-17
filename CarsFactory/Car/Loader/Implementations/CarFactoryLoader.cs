using CarsFactory.Car.Factories.Abstractions;
using CarsFactory.Car.Loader.Abstractions;
using CarsFactory.Common;
using CarsFactory.Engine.Abstractions;
using CarsFactory.FuelTank.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CarsFactory.Car.Loader.Implementations
{
    public class CarFactoryLoader : ICarFactoryLoader
    {
        private readonly Dictionary<CarBrand, ICarFactory> _carFactories = new Dictionary<CarBrand, ICarFactory>();
        private readonly IEngine _engine;
        private readonly IFuelTank _fuelTank;

        public CarFactoryLoader(IEngine engine, IFuelTank fuelTank)
        {
            _engine = engine;
            _fuelTank = fuelTank;
            InitializeFactories();
        }

        public ICarFactory Select(CarBrand carBrand)
        {
            return _carFactories[carBrand];
        }

        private void InitializeFactories()
        {
            IEnumerable<Type> carFactories = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetInterface(typeof(ICarFactory).ToString()) != null);
            foreach (Type carFactory in carFactories)
            {
                if (carFactory.GetInterface(typeof(ICarFactory).ToString()) != null)
                {
                    object[] arguments = new object[2];
                    arguments[0] = _engine;
                    arguments[1] = _fuelTank;
                    ICarFactory carFactoryObj = Activator.CreateInstance(carFactory, arguments) as ICarFactory;
                    if (carFactoryObj != null)
                    {
                        if (!_carFactories.ContainsKey(carFactoryObj.CarBrand))
                        {
                            _carFactories.Add(carFactoryObj.CarBrand, carFactoryObj);
                        }
                    }
                }
            }
        }
    }
}
