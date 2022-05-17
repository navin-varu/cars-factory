using System;
using System.Collections.Generic;
using System.Text;

namespace CarsFactory.Common
{
    /// <summary>
    /// Global library constants.
    /// </summary>
    public abstract class Constants
    {
        /// <summary>
        /// Constants for a car.
        /// </summary>
        public abstract class Car
        {
            public const int MAX_SPEED = 250;
            public const int DEFAULT_ACCELERATION = 10;
            public const int DEFAULT_MIN_ACCELERATION = 5;
            public const int DEFAULT_MAX_ACCELERATION = 20;
            public const int DEFAULT_DEACCELERATION = 5;
            public const int DEFAULT_MAX_DEACCELERATION = 10;
            /// <summary>
            /// Car color constant values.
            /// </summary>
            public abstract class Color
            {
                public const string BLACK = "Black";
                public const string BLUE = "Blue";
                public const string RED = "Red";
                public const string WHITE = "White";
            }

            /// <summary>
            /// Car brand constant values.
            /// </summary>
            public abstract class Brand
            {
                public const string BMW = "BMW";
                public const string AUDI = "Audi";
                public const string TATA = "Tata";
            }

            /// <summary>
            /// Car manfacturing status constant values.
            /// </summary>
            public abstract class ManufacturingStatus
            {
                public const string ID = "Car Id";
                public const string BRAND = "Brand";
                public const string COLOR = "Color";
                public const string MAX_SPEED = "Max Speed";
                public const string CREATED_DATE = "Created Date";
            }

            /// <summary>
            /// Car dashboard details constant values.
            /// </summary>
            public abstract class DashboardDetails
            {
                public const string FUEL_LEVEL = "Fuel Level";
                public const string FUEL_MAX_LEVEL = "Max Fuel Level";
                public const string SPEED = "Speed";
                public const string CAR_STATUS = "Car Status";
                public const string TEMPERATURE = "Temperature";
                public const string CURRENT_FUEL_REQUIREMENT = "Current Fuel Requirement";
            }

            /// <summary>
            /// Car constant messages.
            /// </summary>
            public abstract class Message
            {
                public const string START_CAR_FIRST = "Please start a car first";
                public const string MAX_CAR_LIMIT_REACHED = "Car can run at most 250 km/h";
                public const string INVALID_CAR_BRAKING = "Car can't be braked by negative speed";
                public const string INVALID_CAR_BRAKING_RUNNING_IDLE = "Car can be braked only if it is running";
            }
        }

        /// <summary>
        /// Constants for a car fuel tank.
        /// </summary>
        public abstract class CarFuelTank
        {
            public const decimal DEFAULT_FUEL_LEVEL = 20;
            public const int FUEL_TANK_SIZE = 60;
            public const decimal RESERVE_LEVEL = 5;
            /// <summary>
            /// Car fuel tank constant messages.
            /// </summary>
            public abstract class Message
            {
                public const string NEGATIVE_FUEL_REFUELING = "Negative fuel amount can not be refueled";
                public const string MAX_FUEL_TANK_REFUEL = "Fuel amount can not be refueled more than maximum fuel tank capacity";
                public const string NEGATIVE_FUEL_AMOUNT = "Negative fuel amount can not be used";
                public const string INSUFICIENT_FUEL_LEVEL = "Insufficient full being used, please refuel before use";
            }
        }
    }
}
