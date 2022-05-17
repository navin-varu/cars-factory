using CarsFactory.Common;
using CarsFactory.Engine.Abstractions;
using CarsFactory.FuelTank.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarsFactory.Car.Factories.Abstractions
{
    /// <summary>
    /// Defines class abstraction to provide generalization to a car.
    /// </summary>
    public abstract class BaseCar : ICar
    {
        private int _defaultAcceleration = Constants.Car.DEFAULT_ACCELERATION;
        private int _defaultDeacceleration = Constants.Car.DEFAULT_DEACCELERATION;
        private decimal _currentFuelRequirement = 0;
        public string Id { get; protected set; }
        public int MaxSpeed { get; protected set; } = Constants.Car.MAX_SPEED;
        public int Speed { get; protected set; }
        public string Color { get; protected set; }
        public string Brand { get; protected set; }
        public DateTime CreatedDate { get; } = DateTime.Now;
        public CarStatus Status { get; protected set; } = CarStatus.Idle;

        public IEngine Engine { get; protected set; }

        public IFuelTank FuelTank { get; protected set; }
        public int DefaultAcceleration
        {
            get => _defaultAcceleration;
            set
            {
                if (value < Constants.Car.DEFAULT_MIN_ACCELERATION)
                {
                    _defaultAcceleration = Constants.Car.DEFAULT_MIN_ACCELERATION;
                }
                else if (value > Constants.Car.DEFAULT_MAX_ACCELERATION)
                {
                    _defaultAcceleration = Constants.Car.DEFAULT_MAX_ACCELERATION;
                }
                else
                {
                    _defaultAcceleration = value;
                }
            }
        }

        public int DefaultDeacceleration
        {
            get => _defaultDeacceleration;
            set
            {
                if (value > Constants.Car.DEFAULT_MAX_DEACCELERATION)
                {
                    _defaultDeacceleration = Constants.Car.DEFAULT_MAX_DEACCELERATION;
                }
                else
                {
                    _defaultDeacceleration = value;
                }
            }
        }

        public virtual void Accelerate()
        {
            if (Status == CarStatus.Idle || Status == CarStatus.Stopped)
            {
                throw new InvalidOperationException(Constants.Car.Message.START_CAR_FIRST);
            }
            else if ((DefaultAcceleration + Speed) > MaxSpeed)
            {
                Speed = 250;
                decimal fuel = Engine.GetRequiredFuel(Speed);
                _currentFuelRequirement = fuel;
                FuelTank.UseFuel(fuel);
                Engine.Accelerate(Speed, fuel);
                throw new ArgumentException(Constants.Car.Message.MAX_CAR_LIMIT_REACHED);
            }
            else
            {
                Speed += DefaultAcceleration;
                decimal fuel = Engine.GetRequiredFuel(Speed);
                _currentFuelRequirement = fuel;
                FuelTank.UseFuel(fuel);
                Engine.Accelerate(Speed, fuel);
                Status = CarStatus.Accelerated;
            }
        }

        public virtual void Deaccelerate()
        {
            if (Status == CarStatus.Idle || Status == CarStatus.Stopped)
            {
                throw new InvalidOperationException(Constants.Car.Message.START_CAR_FIRST);
            }
            else if (DefaultDeacceleration <= 0)
            {
                throw new ArgumentException(Constants.Car.Message.INVALID_CAR_BRAKING);
            }
            else if (Status == CarStatus.RunningIdle)
            {
                Speed = 0;
                decimal fuel = Engine.GetRequiredFuel(Speed);
                _currentFuelRequirement = fuel;
                FuelTank.UseFuel(fuel);
                Engine.Deaccelerate(Speed, fuel);
                Status = CarStatus.RunningIdle;
                throw new InvalidOperationException(Constants.Car.Message.INVALID_CAR_BRAKING_RUNNING_IDLE);
            }
            else
            {
                if (Speed - DefaultDeacceleration > 0)
                {
                    Speed -= DefaultDeacceleration;
                    decimal fuel = Engine.GetRequiredFuel(Speed);
                    _currentFuelRequirement = fuel;
                    FuelTank.UseFuel(fuel);
                    Engine.Deaccelerate(Speed, fuel);
                    Status = CarStatus.Deaccelerated;
                }
                else
                {
                    Speed = 0;
                    decimal fuel = Engine.GetRequiredFuel(Speed);
                    _currentFuelRequirement = fuel;
                    FuelTank.UseFuel(fuel);
                    Engine.Deaccelerate(Speed, fuel);
                    Status = CarStatus.RunningIdle;
                }
            }
        }

        public Dictionary<string, string> GetDashboardDetails()
        {
            Dictionary<string, string> details = new Dictionary<string, string>();
            details.Add(Constants.Car.DashboardDetails.FUEL_LEVEL, $"{FuelTank.Level} L {(FuelTank.Level < FuelTank.ReserveLevel ? "[Reserve]" : "")} {(_currentFuelRequirement > 0 ? "(\u2193 " + _currentFuelRequirement.ToString() + " L)" : "")}");
            details.Add(Constants.Car.DashboardDetails.FUEL_MAX_LEVEL, $"{FuelTank.Size} L");
            details.Add(Constants.Car.DashboardDetails.SPEED, $"{Speed} km/h {((Status == CarStatus.Accelerated) ? $"(\u2191 {DefaultAcceleration} km/h per socond)" : ((Status == CarStatus.Deaccelerated) ? $"(\u2193 {DefaultDeacceleration} km/h per socond)" : ""))}");
            details.Add(Constants.Car.DashboardDetails.TEMPERATURE, $"{Engine.Temperature} Celcius");
            details.Add(Constants.Car.DashboardDetails.CAR_STATUS, $"{Status}");
            return details;
        }

        public Dictionary<string, string> GetManufacturingStatus()
        {
            Dictionary<string, string> status = new Dictionary<string, string>();
            status.Add(Constants.Car.ManufacturingStatus.ID, Id);
            status.Add(Constants.Car.ManufacturingStatus.BRAND, Brand);
            status.Add(Constants.Car.ManufacturingStatus.COLOR, Color);
            status.Add(Constants.Car.ManufacturingStatus.MAX_SPEED, $"{MaxSpeed} km/h");
            status.Add(Constants.Car.ManufacturingStatus.CREATED_DATE, CreatedDate.ToLongDateString());
            return status;
        }

        public virtual void Refuel(decimal liter)
        {
            if (Status != CarStatus.Refueled)
            {
                Stop();
                FuelTank.Refuel(liter);
                Status = CarStatus.Refueled;
            }
        }

        public virtual void Start()
        {
            if (Status != CarStatus.Started)
            {
                decimal fuel = Engine.GetRequiredFuel(0);
                _currentFuelRequirement = fuel;
                Engine.Start();
                Status = CarStatus.Started;
            }
        }

        public virtual void Stop()
        {
            if (Status != CarStatus.Stopped)
            {
                Speed = 0;
                _currentFuelRequirement = 0;
                Engine.Stop();
                Status = CarStatus.Stopped;
            }
        }

        public virtual void RunningIdle()
        {
            decimal fuel = Engine.RunningIdleFuelConsumption;
            FuelTank.UseFuel(fuel);
            Engine.RunningIdle();
            Status = CarStatus.RunningIdle;
        }
    }
}
