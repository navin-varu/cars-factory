using CarsFactory.Car.Factories.Abstractions;
using CarsFactory.Car.Loader.Abstractions;
using CarsFactory.Car.Loader.Implementations;
using CarsFactory.Common;
using CarsFactory.Engine.Abstractions;
using CarsFactory.Engine.Implementations;
using CarsFactory.FuelTank.Abstractions;
using CarsFactory.FuelTank.Implementations;
using System;
using Xunit;

namespace CarsFactoryTests
{
    public class CarTests
    {


        [Fact]
        public void CarDefaultAccelerationTests()
        {
            // Arrange
            ICarFactory carFactory = GetCarFactory(CarBrand.BMW);

            BaseCar car = carFactory.Create();

            // Act
            int da = car.DefaultAcceleration;

            // Assert
            Assert.Equal(10, da);
        }

        [Theory]
        [InlineData(50)]
        [InlineData(30)]
        [InlineData(20)]
        public void CarMaxAccelerationTests(int acceleration)
        {
            // Arrange
            ICarFactory carFactory = GetCarFactory(CarBrand.BMW);

            BaseCar car = carFactory.Create();

            // Act
            car.DefaultAcceleration = acceleration;

            // Assert
            Assert.Equal(20, car.DefaultAcceleration);
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(0)]
        [InlineData(4)]
        public void CarMinAccelerationTests(int acceleration)
        {
            // Arrange
            ICarFactory carFactory = GetCarFactory(CarBrand.BMW);

            BaseCar car = carFactory.Create();

            // Act
            car.DefaultAcceleration = acceleration;

            // Assert
            Assert.Equal(5, car.DefaultAcceleration);
        }

        [Theory]
        [InlineData(50)]
        [InlineData(30)]
        [InlineData(20)]
        public void CarMaxDeaccelerationTests(int deacceleration)
        {
            // Arrange
            ICarFactory carFactory = GetCarFactory(CarBrand.BMW);

            BaseCar car = carFactory.Create();

            // Act
            car.DefaultDeacceleration = deacceleration;

            // Assert
            Assert.Equal(10, car.DefaultDeacceleration);
        }

        [Fact]
        public void CarMaxSpeedTests()
        {
            // Arrange
            ICarFactory carFactory = GetCarFactory(CarBrand.BMW);

            BaseCar car = carFactory.Create();

            // Act
            int ms = car.MaxSpeed;

            // Assert
            Assert.Equal(250, ms);
        }

        [Fact]
        public void CreatedCarStatusIdleTests()
        {
            // Arrange
            ICarFactory carFactory = GetCarFactory(CarBrand.BMW);

            BaseCar car = carFactory.Create();

            // Act

            // Assert
            Assert.Equal(CarStatus.Idle, car.Status);
        }

        [Fact]
        public void CarHavingEngineTests()
        {
            // Arrange
            ICarFactory carFactory = GetCarFactory(CarBrand.BMW);

            BaseCar car = carFactory.Create();

            // Act

            // Assert
            Assert.NotNull(car.Engine);
            Assert.IsType<Engine>(car.Engine);
        }

        [Fact]
        public void CarHavingFueltankTests()
        {
            // Arrange
            ICarFactory carFactory = GetCarFactory(CarBrand.BMW);

            BaseCar car = carFactory.Create();

            // Act

            // Assert
            Assert.NotNull(car.FuelTank);
            Assert.IsType<FuelTank>(car.FuelTank);
        }

        [Fact]
        public void CarStartedStatusTests()
        {
            // Arrange
            ICarFactory carFactory = GetCarFactory(CarBrand.BMW);

            BaseCar car = carFactory.Create();

            // Act
            car.Start();

            // Assert
            Assert.Equal(CarStatus.Started, car.Status);
        }

        [Fact]
        public void CarStoppedStatusTests()
        {
            // Arrange
            ICarFactory carFactory = GetCarFactory(CarBrand.BMW);

            BaseCar car = carFactory.Create();

            // Act
            car.Stop();

            // Assert
            Assert.Equal(CarStatus.Stopped, car.Status);
        }

        [Fact]
        public void CarAcceleratedStatusTests()
        {
            // Arrange
            ICarFactory carFactory = GetCarFactory(CarBrand.BMW);

            BaseCar car = carFactory.Create();

            // Act
            car.Start();
            car.Accelerate();

            // Assert
            Assert.Equal(CarStatus.Accelerated, car.Status);
        }

        [Fact]
        public void CarBrackedStatusTests()
        {
            // Arrange
            ICarFactory carFactory = GetCarFactory(CarBrand.BMW);

            BaseCar car = carFactory.Create();

            // Act
            car.Start();
            car.Deaccelerate();

            // Assert
            if (car.Speed - car.DefaultDeacceleration > 0)
                Assert.Equal(CarStatus.Deaccelerated, car.Status);
            else
                Assert.Equal(CarStatus.RunningIdle, car.Status);
        }

        [Fact]
        public void CarRefueledStatusTests()
        {
            // Arrange
            ICarFactory carFactory = GetCarFactory(CarBrand.BMW);

            BaseCar car = carFactory.Create();

            // Act
            car.Refuel(20);

            // Assert
            Assert.Equal(CarStatus.Refueled, car.Status);
        }

        [Fact]
        public void CarStaredBeforeAcceleratedTests()
        {
            // Arrange
            ICarFactory carFactory = GetCarFactory(CarBrand.BMW);

            BaseCar car = carFactory.Create();

            // Act

            // Assert
            Assert.Throws<InvalidOperationException>(() => car.Accelerate());
        }

        [Fact]
        public void CarStaredBeforeDeacceleratedTests()
        {
            // Arrange
            ICarFactory carFactory = GetCarFactory(CarBrand.BMW);

            BaseCar car = carFactory.Create();

            // Act

            // Assert
            Assert.Throws<InvalidOperationException>(() => car.Deaccelerate());
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(0)]
        [InlineData(-4)]
        public void CarNegativeDeacceleratedTests(int deacceleration)
        {
            // Arrange
            ICarFactory carFactory = GetCarFactory(CarBrand.BMW);

            BaseCar car = carFactory.Create();

            // Act
            car.Start();
            car.DefaultDeacceleration = deacceleration;

            // Assert
            Assert.Throws<ArgumentException>(() => car.Deaccelerate());
        }

        [Fact]
        public void CarRunningIdleStatusTests()
        {
            // Arrange
            ICarFactory carFactory = GetCarFactory(CarBrand.BMW);

            BaseCar car = carFactory.Create();

            // Act
            car.RunningIdle();

            // Assert
            Assert.Equal(CarStatus.RunningIdle, car.Status);
        }

        [Fact]
        public void CarRunningIdleFuelConsumptionTests()
        {
            // Arrange
            ICarFactory carFactory = GetCarFactory(CarBrand.BMW);

            BaseCar car = carFactory.Create();

            // Act
            car.RunningIdle();

            // Assert
            Assert.Equal(0.0003M, car.Engine.TotalFuelConsumed);
        }

        [Fact]
        public void CarDefaultFuelLevelTests()
        {
            // Arrange
            ICarFactory carFactory = GetCarFactory(CarBrand.BMW);

            BaseCar car = carFactory.Create();

            // Act

            // Assert
            Assert.Equal(20, car.FuelTank.Level);
        }

        [Fact]
        public void CarMaxFuelLevelTests()
        {
            // Arrange
            ICarFactory carFactory = GetCarFactory(CarBrand.BMW);

            BaseCar car = carFactory.Create();

            // Act

            // Assert
            Assert.Equal(60, car.FuelTank.Size);
        }

        [Fact]
        public void CarStoppedThenEngineStoppedTests()
        {
            // Arrange
            ICarFactory carFactory = GetCarFactory(CarBrand.BMW);

            BaseCar car = carFactory.Create();

            // Act
            car.Stop();

            // Assert
            Assert.Equal(EngineStatus.Stopped, car.Engine.Status);
        }

        [Fact]
        public void CarStartedThenEngineStartedTests()
        {
            // Arrange
            ICarFactory carFactory = GetCarFactory(CarBrand.BMW);

            BaseCar car = carFactory.Create();

            // Act
            car.Start();

            // Assert
            Assert.Equal(EngineStatus.Started, car.Engine.Status);
        }

        private ICarFactory GetCarFactory(CarBrand carBrand)
        {
            IEngineFuelRequirement engineFuelRequirement = new EngineFuelRequirement();
            IEngineTemperature engineTemperature = new EngineTemperature();
            IEngine engine = new Engine(engineFuelRequirement, engineTemperature);
            IFuelTank fuelTank = new FuelTank();
            ICarFactoryLoader carFactoryLoader = new CarFactoryLoader(engine, fuelTank);
            return carFactoryLoader.Select(carBrand);
        }
    }
}
