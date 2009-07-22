using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ThreadLockSimulator.Model
{
    /// <summary>
    /// Represents an external device that reads temperature
    /// and reports this back, leaving the manager to 
    /// decide if heater should be enabled or disabled.
    /// </summary>
    public class FakeExternalDevice : IExternalDevice
    {
        public event EventHandler DataReceived;
        
        private object hardwareLockObject = new object();

        protected void RaiseDataReceived()
        {
            // Raise an event to pretend data has been received.
            if (DataReceived != null)
            {
                DataReceived(this, EventArgs.Empty);
            }
        }

        public void Open()
        {
            ////// Create a new thread to poll the hardware on.
            ////ThreadStart threadStart = new ThreadStart(PollHardware);
            ////Thread thread = new Thread(threadStart);
            ////thread.Start();
        }

        public void Close()
        {
            // TODO: Disable ticker.    
        }

        public void TriggerDataReceived()
        {
            // Simulate hardware event where data has been received.
            // in an ideal world the event needs to be outside of the lock
            // as this is what will cause our thread lock.
            lock (hardwareLockObject)
            {
                RaiseDataReceived();
            }
        }

        public float ReadTemperature()
        {
            Debug.WriteLine("Read Temperature");

            lock (hardwareLockObject)
            {
                return 100F;
            }
        }

        /// <summary>
        /// Turns the fan on.
        /// </summary>
        public void EnableCooling()
        {
            lock (hardwareLockObject)
            {
                // Write to hardware
                Debug.WriteLine("Enable cooling cooling", "Fake Device");
            }
        }

        /// <summary>
        /// Turns the fan off.
        /// </summary>
        public void DisableCooling()
        {
            lock (hardwareLockObject)
            {
                Debug.WriteLine("Disable cooling", "Fake Device");
            }
        }

        /// <summary>
        /// Checks the status of the hardware connection
        /// </summary>
        /// <returns>Returns true if the device is connected</returns>
        public bool CheckStatus()
        {
            lock (hardwareLockObject)
            {
                Debug.WriteLine("Check Status", "Fake Device");
                return true;
            }
        }
    }
}
