using CarsFactory.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarsFactoryConsole
{
    /// <summary>
    /// It is responsible to manage the display while handling a created car and/or car creation process.
    /// </summary>
    public static class DisplayManager
    {
        /// <summary>
        /// Prints overall car status on screen.
        /// </summary>
        /// <param name="manufacturingStatus"></param>
        /// <param name="dashBoardDetails"></param>
        /// <param name="displayMetaData"></param>
        public static void Display(Dictionary<string, string> manufacturingStatus, Dictionary<string, string> dashBoardDetails, DisplayMetaData displayMetaData)
        {
            Console.Clear();
            Console.Title = $"Cars Factory   [Time Elapsed : {displayMetaData.TimerDetails} ]";
            PrintManufacturingStatus(manufacturingStatus);
            Console.WriteLine();
            PrintDashboardDetails(dashBoardDetails);
            Console.WriteLine();
            Console.WriteLine();
            PrintOprations();
            Console.WriteLine();
            Console.WriteLine();
            PrintMessage(displayMetaData);
            Console.WriteLine();
        }

        /// <summary>
        /// Prints car's manufacturing details on screen.
        /// </summary>
        /// <param name="manufacturingStatus"></param>
        private static void PrintManufacturingStatus(Dictionary<string, string> manufacturingStatus)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("\t\t\t   CAR DETAILS");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine();

            foreach (var kvp in manufacturingStatus)
            {
                //Console.WriteLine($"     {kvp.Key} ::  {kvp.Value}");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"     {kvp.Key} ::");
                Console.ForegroundColor = ConsoleColor.DarkCyan;

                Console.Write($"  {kvp.Value}");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("-----------------------------------------------------------------");
        }

        /// <summary>
        /// Prints car's internal dashboard on screen.
        /// </summary>
        /// <param name="dashBoardDetails"></param>
        private static void PrintDashboardDetails(Dictionary<string, string> dashBoardDetails)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("\t\t\t   CAR DASHBOARD");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine();

            foreach (var kvp in dashBoardDetails)
            {
                //Console.WriteLine($"     {kvp.Key} ::  {kvp.Value}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"     {kvp.Key} ::");
                if (kvp.Key == Constants.Car.DashboardDetails.FUEL_LEVEL)
                {
                    if (kvp.Value.Contains("Reserve"))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                }
                else if (kvp.Key == Constants.Car.DashboardDetails.FUEL_MAX_LEVEL)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }

                Console.Write($"  {kvp.Value}");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("-----------------------------------------------------------------");
        }

        /// <summary>
        /// Prints car handling operations on screen.
        /// </summary>
        public static void PrintOprations()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Start Car (Press [1]) ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Stop Car (Press [2]) ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Brake Car (Press [3]) ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Accelerate Car (Press [4]) ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Refuel Car (Press [5])");
        }

        /// <summary>
        /// Prints instruction / error message on screen.
        /// </summary>
        /// <param name="displayMetaData"></param>
        private static void PrintMessage(DisplayMetaData displayMetaData)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(".................................................................");
            Console.Write("Helper Message :: ");
            if (displayMetaData.MessageType == MessageType.Information)
                Console.ForegroundColor = ConsoleColor.White;
            else if (displayMetaData.MessageType == MessageType.Error)
                Console.ForegroundColor = ConsoleColor.DarkRed;
            else if (displayMetaData.MessageType == MessageType.Warning)
                Console.ForegroundColor = ConsoleColor.Yellow;
            else if (displayMetaData.MessageType == MessageType.Failed)
                Console.ForegroundColor = ConsoleColor.Red;
            else if (displayMetaData.MessageType == MessageType.Success)
                Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(displayMetaData.Message);
        }

        /// <summary>
        /// Prints brand selection choices on screen.
        /// </summary>
        public static void PrintBrandSelection()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.Write("BMW [Press 1] ");
            Console.Write("AUDI [Press 2] ");
            Console.Write("TATA [Press 3] ");
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Please select a car brand to create a car:");
        }
    }
}
