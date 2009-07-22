using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThreadLockSimulator.Model;

namespace ThreadLockSimulator
{
    public partial class Form1 : Form
    {
        private DeviceManager manager;
        private FakeExternalDevice device1 = new FakeExternalDevice();
        private FakeExternalDevice device2 = new FakeExternalDevice();

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            List<IExternalDevice> devices = new List<IExternalDevice>();

            devices.Add(device1);
            devices.Add(device2);

            manager = new DeviceManager(devices);
            manager.DataReceived += new EventHandler(manager_DataReceived);

            manager.Start();
        }

        void manager_DataReceived(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(manager_DataReceived), new object[] {sender, e});
            }
            else
            {
                this.listBox1.Items.Clear();

                foreach (float temperature in manager.Temperatures)
                {
                    this.listBox1.Items.Add(temperature);
                }
            }
        }

        private void buttonDevice1Send_Click(object sender, EventArgs e)
        {
            device1.TriggerDataReceived();
        }

        private void buttonDevice2Send_Click(object sender, EventArgs e)
        {
            device2.TriggerDataReceived();
        }

        private void buttonDisableCooling_Click(object sender, EventArgs e)
        {
            manager.DisableCooling();
        }

        private void buttonEnableCooling_Click(object sender, EventArgs e)
        {
            manager.EnableCooling();
        }
    }
}
