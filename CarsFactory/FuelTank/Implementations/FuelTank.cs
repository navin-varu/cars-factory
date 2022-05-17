using CarsFactory.Common;
using CarsFactory.FuelTank.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarsFactory.FuelTank.Implementations
{
    public class FuelTank : IFuelTank
    {
        private readonly int _size = Constants.CarFuelTank.FUEL_TANK_SIZE;

        public FuelTankStatus Status { get; private set; } = FuelTankStatus.UnKnown;

        public int Size => _size;

        public decimal Level { get; private set; } = Constants.CarFuelTank.DEFAULT_FUEL_LEVEL;

        public decimal ReserveLevel { get; private set; } = Constants.CarFuelTank.RESERVE_LEVEL;

        public FuelTank()
        {
            GetStatus();
        }

        public void Refuel(decimal liter)
        {
            if (liter < 0)
            {
                throw new ArgumentException("Negative fuel amount can not be refueled");
            }
            else if (liter > Constants.CarFuelTank.FUEL_TANK_SIZE || (liter + Level) > Constants.CarFuelTank.FUEL_TANK_SIZE)
            {
                throw new InvalidOperationException("Fuel amount can not be refueled more than maximum fuel tank capacity");
            }
            else
            {
                Level += liter;
                Status = GetStatus();
            }
        }

        public void UseFuel(decimal liter)
        {
            if (liter < 0)
            {
                throw new ArgumentException("Negative fuel amount can not be used");
            }
            else if (liter >= Level)
            {
                throw new InvalidOperationException("Insufficient full being used, please refuel before use");
            }
            else
            {
                Level -= liter;
                Status = GetStatus();
            }
        }

        private FuelTankStatus GetStatus()
        {
            if (Level == 0)
            {
                return FuelTankStatus.Empty;
            }
            else if (Level < ReserveLevel)
            {
                return FuelTankStatus.Reserve;
            }
            else if (Level >= ReserveLevel && Level < _size)
            {
                return FuelTankStatus.Suffiecient;
            }
            else if (Level == _size)
            {
                return FuelTankStatus.Full;
            }
            return FuelTankStatus.UnKnown;
        }
    }
}
