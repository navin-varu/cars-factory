using CarsFactory.Engine.Abstractions;
using CarsFactory.Engine.FuelRequirementRules.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CarsFactory.Engine.Implementations
{
    public class EngineFuelRequirement : IEngineFuelRequirement
    {
        private List<IFuelRequirementRule> _fuelRequirementRules = new List<IFuelRequirementRule>();

        public EngineFuelRequirement()
        {
            LoadRules();
        }

        public decimal CalculateFuelRequirement(int speed)
        {
            decimal fuelRequirement = 0;
            foreach (var fuelRequirementRule in _fuelRequirementRules)
            {
                fuelRequirement += fuelRequirementRule.GetFuelRequirement(speed);
                if(fuelRequirement > 0)
                {
                    break;
                }
            }
            return fuelRequirement;
        }

        private void LoadRules()
        {
            IEnumerable<Type> rules = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetInterface(typeof(IFuelRequirementRule).ToString()) != null);
            foreach (Type rule in rules)
            {
                if (rule.GetInterface(typeof(IFuelRequirementRule).ToString()) != null)
                {
                    IFuelRequirementRule fuelRequirementRule = Activator.CreateInstance(rule) as IFuelRequirementRule;
                    if (fuelRequirementRule != null)
                    {
                        if (!_fuelRequirementRules.Contains(fuelRequirementRule))
                        {
                            _fuelRequirementRules.Add(fuelRequirementRule);
                        }
                    }
                }
            }
        }
    }
}
