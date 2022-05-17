using CarsFactoryConsole.Operations.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CarsFactoryConsole.Operations.Implementations
{
    public class TaskSelector : ITaskSelector
    {
        private readonly Dictionary<Operation, ICarTask> _carTasks = new Dictionary<Operation, ICarTask>();

        public TaskSelector()
        {
            InitializeTasks();
        }

        public ICarTask Select(Operation operation)
        {
            return _carTasks[operation];
        }

        private void InitializeTasks()
        {
            IEnumerable<Type> carFactories = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetInterface(typeof(ICarTask).ToString()) != null);
            foreach (Type carFactory in carFactories)
            {
                if (carFactory.GetInterface(typeof(ICarTask).ToString()) != null)
                {
                    ICarTask carTaskObj = Activator.CreateInstance(carFactory) as ICarTask;
                    if (carTaskObj != null)
                    {
                        if (!_carTasks.ContainsKey(carTaskObj.Operation))
                        {
                            _carTasks.Add(carTaskObj.Operation, carTaskObj);
                        }
                    }
                }
            }
        }
    }
}
