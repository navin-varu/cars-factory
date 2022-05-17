using CarsFactory.Engine.Abstractions;
using CarsFactory.Engine.Implementations;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CarsFactoryTests
{
    public class EngineTemperatureTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(20)]
        [InlineData(50)]
        [InlineData(250)]
        public void CarDefaultAccelerationTests(decimal speed)
        {
            // Arrange
            IEngineTemperature engineTemperature = new EngineTemperature();

            // Act
            decimal temperature = engineTemperature.Measure(speed);

            // Assert
            Assert.Equal(speed * 0.1M * 3.5M, temperature);
        }
    }
}
