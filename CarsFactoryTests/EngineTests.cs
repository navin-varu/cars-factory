using CarsFactory.Common;
using CarsFactory.Engine.Abstractions;
using CarsFactory.Engine.Implementations;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CarsFactoryTests
{
    public class EngineTests
    {
        [Fact]
        public void EngineRunningIdleFuelConsumptionTests()
        {
            // Arrange
            IEngine engine = GetCarEngine();

            // Act
            engine.Start();

            // Assert
            Assert.Equal(0.0003M, engine.RunningIdleFuelConsumption);
        }
        [Fact]
        public void EngineStartingFuelConsumptionTests()
        {
            // Arrange
            IEngine engine = GetCarEngine();

            // Act
            engine.Start();

            // Assert
            Assert.Equal(0, engine.StartingFuelConsumption);
        }
        [Fact]
        public void EngineStartedStatusTests()
        {
            // Arrange
            IEngine engine = GetCarEngine();

            // Act
            engine.Start();

            // Assert
            Assert.Equal(EngineStatus.Started, engine.Status);
        }

        [Fact]
        public void EngineStoppedStatusTests()
        {
            // Arrange
            IEngine engine = GetCarEngine();

            // Act
            engine.Stop();

            // Assert
            Assert.Equal(EngineStatus.Stopped, engine.Status);
        }

        [Fact]
        public void EngineAcceleratedStatusTests()
        {
            // Arrange
            IEngine engine = GetCarEngine();

            // Act
            engine.Accelerate(10, 0.003M);

            // Assert
            Assert.Equal(EngineStatus.Accelerated, engine.Status);
        }

        [Fact]
        public void EngineBrackedStatusTests()
        {
            // Arrange
            IEngine engine = GetCarEngine();

            // Act
            engine.Deaccelerate(10, 0.003M);

            // Assert
            Assert.Equal(EngineStatus.Deaccelerated, engine.Status);
        }

        [Fact]
        public void EngineRunningIdleStatusTests()
        {
            // Arrange
            IEngine engine = GetCarEngine();

            // Act
            engine.RunningIdle();

            // Assert
            Assert.Equal(EngineStatus.RunningIdle, engine.Status);
        }

        [Fact]
        public void EngineZeroSpeedFuelRequirementTests()
        {
            // Arrange
            IEngine engine = GetCarEngine();

            // Act
            decimal req = engine.GetRequiredFuel(0);

            // Assert
            Assert.Equal(0.0003M, req);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(50)]
        [InlineData(60)]
        public void Engine1to60SpeedFuelRequirementTests(int speed)
        {
            // Arrange
            IEngine engine = GetCarEngine();

            // Act
            decimal req = engine.GetRequiredFuel(speed);

            // Assert
            Assert.Equal(0.0020M, req);
        }

        [Theory]
        [InlineData(61)]
        [InlineData(80)]
        [InlineData(100)]
        public void Engine61to100SpeedFuelRequirementTests(int speed)
        {
            // Arrange
            IEngine engine = GetCarEngine();

            // Act
            decimal req = engine.GetRequiredFuel(speed);

            // Assert
            Assert.Equal(0.0014M, req);
        }

        [Theory]
        [InlineData(101)]
        [InlineData(124)]
        [InlineData(140)]
        public void Engine101to140SpeedFuelRequirementTests(int speed)
        {
            // Arrange
            IEngine engine = GetCarEngine();

            // Act
            decimal req = engine.GetRequiredFuel(speed);

            // Assert
            Assert.Equal(0.0020M, req);
        }

        [Theory]
        [InlineData(141)]
        [InlineData(185)]
        [InlineData(200)]
        public void Engine141to200SpeedFuelRequirementTests(int speed)
        {
            // Arrange
            IEngine engine = GetCarEngine();

            // Act
            decimal req = engine.GetRequiredFuel(speed);

            // Assert
            Assert.Equal(0.0025M, req);
        }

        [Theory]
        [InlineData(201)]
        [InlineData(235)]
        [InlineData(250)]
        public void Engine201to250SpeedFuelRequirementTests(int speed)
        {
            // Arrange
            IEngine engine = GetCarEngine();

            // Act
            decimal req = engine.GetRequiredFuel(speed);

            // Assert
            Assert.Equal(0.0030M, req);
        }

        private IEngine GetCarEngine()
        {
            IEngineFuelRequirement engineFuelRequirement = new EngineFuelRequirement();
            IEngineTemperature engineTemperature = new EngineTemperature();
            return new Engine(engineFuelRequirement, engineTemperature);
        }
    }
}
