using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThreadLockSimulator.Model
{
    /// <summary>
    /// Simple controller that will enable the specific device fan
    /// if the temperature goes above a set point.
    /// </summary>
    class SimpleTemperatureController : ITemperatureController
    {
        public bool ShouldEnableCooling(float currentTemperature)
        {
            if (currentTemperature > 37.0F)
            {
                return true;
            }
            return false;
        }
    }
}
