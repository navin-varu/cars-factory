using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using CarsFactory.Engine.Abstractions;
using CarsFactory.Engine.Implementations;
using CarsFactory.FuelTank.Abstractions;
using CarsFactory.FuelTank.Implementations;
using CarsFactory.Car.Loader.Abstractions;
using CarsFactory.Car.Loader.Implementations;
using CarsFactory.Car.Factories.Abstractions;
using CarsFactory.Common;
using System.Collections.Generic;
using System.Timers;
using System.Threading.Tasks;
using CarsFactoryConsole.Operations.Abstractions;
using CarsFactoryConsole.Operations.Implementations;
using CarsFactoryConsole.Operations;

namespace CarsFactoryConsole
{
    class Program
    {
        private static string _message = "Please choose operation to use car...";
        private static MessageType _messageType = MessageType.Information;
        private static decimal _refuelAmount = 0;
        private static int _speed = 0;

        private static Operation _operation = Operation.Idle;
        static void Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            var engine = (IEngine)host.Services.GetService(typeof(IEngine));
            var fuelTank = (IFuelTank)host.Services.GetService(typeof(IFuelTank));

            Timer timer = new Timer(1000);

            ITaskSelector taskSelector = new TaskSelector();

            ICarFactoryLoader carFactoryLoader = new CarFactoryLoader(engine, fuelTank);

            ConsoleKeyInfo key;
            CarBrand carBrandObj = CarBrand.Unknown;

            DisplayManager.PrintBrandSelection();
            while ((key = Console.ReadKey()) != null)
            {
                DisplayManager.PrintBrandSelection();
                int brand = -1;
                char brandChar = key.KeyChar;
                if (int.TryParse(brandChar.ToString(), out brand))
                {
                    try
                    {
                        brand -= 1;
                        if (Enum.IsDefined(typeof(CarBrand), brand))
                        {
                            carBrandObj = (CarBrand)Enum.ToObject(typeof(CarBrand), brand);
                        }
                        else
                        {
                            carBrandObj = CarBrand.Unknown;
                        }
                    }
                    catch
                    {
                        carBrandObj = CarBrand.Unknown;
                    }
                }                

                if (carBrandObj != CarBrand.Unknown)
                {
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Please select a valid car brand to create a car");
                }
            }

            ICarFactory carFactory = carFactoryLoader.Select(carBrandObj);

            BaseCar car = carFactory.Create();

            timer.Elapsed += (sender, e) => HandleOperation(taskSelector, car, e.SignalTime.ToString("HH:mm:ss"));

            timer.Start();

            while ((key = Console.ReadKey()) != null)
            {
                _message = "";
                timer.Stop();
                char operation = key.KeyChar;
                switch (operation)
                {
                    case '1':
                        _operation = Operation.Start;
                        _message = "Car is started";
                        _messageType = MessageType.Success;
                        break;
                    case '2':
                        _operation = Operation.Stop;
                        _message = "Car is stopped";
                        _messageType = MessageType.Information;
                        break;
                    case '3':
                        _operation = Operation.Brake;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine();
                        Console.Write("Brake car by speed (km/h) per second [Put Value and press Enter Key]:");
                        _speed = Convert.ToInt32(GetValue());
                        _message = "Car is braked";
                        _messageType = MessageType.Error;
                        break;
                    case '4':
                        _operation = Operation.Accelerate;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine();
                        Console.Write("Accelerate car by speed (km/h) per second [Put Value and press Enter Key]:");
                        _speed = Convert.ToInt32(GetValue());
                        _message = "Car is accelerated";
                        _messageType = MessageType.Warning;
                        break;
                    case '5':
                        _operation = Operation.Refuel;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine();
                        Console.Write("Please enter fuel amount (Liters) [Put Value and press Enter Key]:");
                        _refuelAmount = GetValue();
                        _message = "Car is refueled and stopped";
                        _messageType = MessageType.Information;
                        break;
                    default:
                        _message = "Please choose proper operation";
                        _messageType = MessageType.Error;
                        break;
                }
                timer.Start();
            }
            Console.ReadLine();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .ConfigureServices((_, services) =>
                   services.AddScoped<IEngineTemperature, EngineTemperature>()
                           .AddScoped<IEngine, Engine>()
                           .AddScoped<IFuelTank, FuelTank>()
                           .AddScoped<IEngineFuelRequirement, EngineFuelRequirement>());

        private static void RefreshDisplay(BaseCar car, string timerDetails)
        {
            DisplayMetaData displayMetaData = new DisplayMetaData
            {
                Message = _message,
                TimerDetails = timerDetails,
                MessageType = _messageType
            };

            Dictionary<string, string> ms = car.GetManufacturingStatus();

            Dictionary<string, string> dd = car.GetDashboardDetails();

            DisplayManager.Display(ms, dd, displayMetaData);
        }

        private static void HandleOperation(ITaskSelector taskSelector, BaseCar car, string timerDetails)
        {
            try
            {
                var task = taskSelector.Select(_operation);
                task.Complete(car, new CarTaskDetail
                {
                    Speed = _speed,
                    FuelAmount = _refuelAmount
                });
                _refuelAmount = 0;

            }
            catch (Exception ex)
            {
                _message = ex.Message;
                _messageType = MessageType.Failed;
            }

            RefreshDisplay(car, timerDetails);
        }

        private static decimal GetValue()
        {
            decimal result = 0;
            string value = Console.ReadLine();
            try
            {
                result = Convert.ToDecimal(value);
            }
            catch
            {

            }
            return result;
        }
    }
}
