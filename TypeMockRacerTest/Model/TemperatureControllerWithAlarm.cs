using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThreadLockSimulator.Model
{
    /// <summary>
    /// Simple temperature monitor that raises an alarm when the set point is reached.
    /// </summary>
    public class TemperatureControllerWithAlarm : ITemperatureController
    {
        public event EventHandler TemperatureAlarm;


        public bool ShouldEnableCooling(float currentTemperature)
        {
            if (currentTemperature > 50.0F)
            {
                if (TemperatureAlarm!=null)
                {
                    TemperatureAlarm(this, EventArgs.Empty);
                }

                return true;
            }

            return false;
        }
    }
}
