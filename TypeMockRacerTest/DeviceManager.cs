using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using ThreadLockSimulator.Model;

namespace ThreadLockSimulator
{
    /// <summary>
    /// Responsible for hooking up the devices and reading the data
    /// </summary>
    public class DeviceManager
    {
        #region Events

        public event EventHandler DataReceived;
        public event EventHandler CurrentTemperatureChanged;

        #endregion

        #region fields

        private float currentTemperature;
        private List<IExternalDevice> externalDevices = new List<IExternalDevice>();
        private List<float> temperatures = new List<float>();
        private ITemperatureController temperatureController;

        /// <summary>
        /// Syncronisation object.
        /// </summary>
        private object syncObject = new object();

        #endregion

        #region Constructors

        public DeviceManager(IEnumerable<IExternalDevice> devices)
            : this(new SimpleTemperatureController(), devices)
        {
        }

        public DeviceManager(ITemperatureController temperatureController, IEnumerable<IExternalDevice> devices)
        {
            this.temperatureController = temperatureController;
            AddExternalDevices(devices);
        }

        #endregion

        #region Event Raisers

        protected void RaiseDataReceivedEvent(object sender, EventArgs empty)
        {
            System.Diagnostics.Debug.WriteLine("RaiseDataReceived, Thread:" + Thread.CurrentThread.GetHashCode(), "DeviceManager");

            EventHandler handler = DataReceived;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        #endregion

        #region Public Properties

        public List<float> Temperatures
        {
            get
            {
                // Lock whilst getting the temperatures to prevent alteration.
                lock (syncObject)
                {
                    return temperatures;
                }
            }
        }

        public float CurrentTemperature
        {
            get
            {
                lock (syncObject)
                {
                    return currentTemperature;
                }
            }
            private set
            {
                lock (syncObject)
                {
                    currentTemperature = value;
                }
            }
        }

        #endregion

        #region Public Methods

        public void Start()
        {
            // Lock to prevent the colleciton being altered whilst itterating.
            lock (syncObject)
            {
                foreach (IExternalDevice externalDevice in externalDevices)
                {
                    externalDevice.Open();
                }
            }
        }

        #endregion

        #region Private implementation

        void device_DataReceived(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Data Received", "DeviceManager");

            // Lock whilst reading the data to prevent 
            // other communications with the hardware
            // and internal data being read whilst it's being updated.
            lock (syncObject)
            {
                IExternalDevice device = (IExternalDevice)sender;

                GetTemperature(device);

                //CheckTemperature(device, CurrentTemperature);
            }

            RaiseDataReceivedEvent(this, EventArgs.Empty);
        }

        private void GetTemperature(IExternalDevice device)
        {
            float temperature = device.ReadTemperature();
            CurrentTemperature = temperature;
            temperatures.Add(temperature);
        }

        private void CheckTemperature(IExternalDevice device, float temperature)
        {
            if (temperatureController.ShouldEnableCooling(temperature))
            {
                EnableCooling();
            }
            else
            {
                DisableCooling();
            }
        }

        private void AddExternalDevices(IEnumerable<IExternalDevice> enumerable)
        {
            // Wire up the data received event and add to the collection of known devices.
            foreach (IExternalDevice externalDevice in enumerable)
            {
                AddExternalDevice(externalDevice);
            }
        } 

        #endregion

        public void AddExternalDevice(IExternalDevice externalDevice)
        {
            lock (syncObject)
            {
                externalDevice.DataReceived += new EventHandler(device_DataReceived);
                externalDevices.Add(externalDevice);
            }
        }

        public void EnableCooling()
        {
            lock (syncObject)
            {
                foreach (IExternalDevice externalDevice in externalDevices)
                {
                    externalDevice.EnableCooling();
                }
            }
        }

        public void DisableCooling()
        {
            Debug.WriteLine("Disable Cooling", "Manager");
            lock (syncObject)
            {
                foreach (IExternalDevice externalDevice in externalDevices)
                {
                    externalDevice.DisableCooling();
                }
            }
        }

        public bool CheckDeviceStatus()
        {
            // Lock whilst accessing hardware, check all the external decivices
            // are ok.
            Debug.WriteLine("Check Status", "Manager");
            lock(syncObject)
            {
                foreach (IExternalDevice externalDevice in externalDevices)
                {
                    if (!externalDevice.CheckStatus())
                    {
                        return false;
                    }                   
                }

                return true;
            }
        }
    }
}
