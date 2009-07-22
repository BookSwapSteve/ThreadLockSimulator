using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThreadLockSimulator.Model
{
    /// <summary>
    /// Interface definition for a controller that is responsible
    /// for overseeing the temperature control of the system
    /// </summary>
    public interface ITemperatureController
    {
        bool ShouldEnableCooling(float currentTemperature);
    }
}
