using CarsFactory.FuelTank.Abstractions;
using CarsFactory.FuelTank.Implementations;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CarsFactoryTests
{
    public class FueltankTests
    {
        [Fact]
        public void FuelTankReserveLevelTests()
        {
            // Arrange
            IFuelTank fuelTank = new FuelTank();

            // Act

            // Assert
            Assert.Equal(5, fuelTank.ReserveLevel);
        }

        [Fact]
        public void FuelTankSizeTests()
        {
            // Arrange
            IFuelTank fuelTank = new FuelTank();

            // Act

            // Assert
            Assert.Equal(60, fuelTank.Size);
        }

        [Fact]
        public void FuelTankDefaultLevelTests()
        {
            // Arrange
            IFuelTank fuelTank = new FuelTank();

            // Act

            // Assert
            Assert.Equal(20, fuelTank.Level);
        }

        [Theory]
        [InlineData(-20)]
        [InlineData(-30)]
        [InlineData(-40)]
        public void FuelTankNegativeRefuelTests(decimal amount)
        {
            // Arrange
            IFuelTank fuelTank = new FuelTank();

            // Act

            // Assert
            Assert.Throws<ArgumentException>(() => fuelTank.Refuel(amount));
        }

        [Theory]
        [InlineData(60)]
        [InlineData(80)]
        [InlineData(100)]
        public void FuelTankRefuelBeyondMaxSizeTests(decimal amount)
        {
            // Arrange
            IFuelTank fuelTank = new FuelTank();

            // Act

            // Assert
            Assert.Throws<InvalidOperationException>(() => fuelTank.Refuel(amount));
        }

        [Theory]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(30)]
        public void FuelTankRefuelTests(decimal amount)
        {
            // Arrange
            IFuelTank fuelTank = new FuelTank();

            // Act
            decimal level = fuelTank.Level;
            fuelTank.Refuel(amount);

            // Assert
            Assert.Equal(level + amount, fuelTank.Level);
        }

        [Theory]
        [InlineData(-20)]
        [InlineData(-30)]
        [InlineData(-40)]
        public void FuelTankNegativeUsefuelTests(decimal amount)
        {
            // Arrange
            IFuelTank fuelTank = new FuelTank();

            // Act

            // Assert
            Assert.Throws<ArgumentException>(() => fuelTank.UseFuel(amount));
        }

        [Theory]
        [InlineData(60)]
        [InlineData(80)]
        [InlineData(100)]
        public void FuelTankUsefuelBeyondMaxSizeTests(decimal amount)
        {
            // Arrange
            IFuelTank fuelTank = new FuelTank();

            // Act

            // Assert
            Assert.Throws<InvalidOperationException>(() => fuelTank.UseFuel(amount));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void FuelTankUsefuelTests(decimal amount)
        {
            // Arrange
            IFuelTank fuelTank = new FuelTank();

            // Act
            decimal level = fuelTank.Level;
            fuelTank.UseFuel(amount);

            // Assert
            Assert.Equal(level - amount, fuelTank.Level);
        }
    }
}
