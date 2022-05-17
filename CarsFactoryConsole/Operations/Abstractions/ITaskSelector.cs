using System;
using System.Collections.Generic;
using System.Text;

namespace CarsFactoryConsole.Operations.Abstractions
{
    /// <summary>
    /// Defines a class which selects a car task based on requested operation.
    /// </summary>
    public interface ITaskSelector
    {
        /// <summary>
        /// Selects a car task based on requested operation.
        /// </summary>
        /// <param name="operation"></param>
        /// <returns></returns>
        ICarTask Select(Operation operation);
    }
}
