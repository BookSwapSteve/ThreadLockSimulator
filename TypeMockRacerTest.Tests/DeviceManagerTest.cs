using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using NUnit.Framework;
using Typemock.Racer;
using ThreadLockSimulator.Model;

namespace ThreadLockSimulator.Tests
{
    [TestFixture]
    public class DeviceManagerTest
    {
        [Test]
        [ParallelInspection]
        public void TestSwitchOnCoolingWhilstReceivingData()
        {
            // Create an instance of a faked external hardware device
            FakeExternalDevice device = new FakeExternalDevice();
            device.Open();

            DeviceManager manager = new DeviceManager(new[] { device });

            // Force a data received from the device.
            // Locks external device lock then try to lock on syncObject in manager.
            device.TriggerDataReceived();

            // This should lock on Manager syncObject, try to lock on the external device lock.
            manager.EnableCooling();

            // Either the TriggerDataReceived call should fail to lock on the managers syncObject
            // or EnableCooling should fail to lock on the external Device's hardware lock as the other thread should 
            // already have acquired the lock.
        }

        /// <summary>
        /// This test should fail with thread timeouts due to locking but it's 
        /// not reliable. 
        /// </summary>
        [Test]
        public void TestManualThreadLockTest()
        {
            FakeExternalDevice device = new FakeExternalDevice();
            device.Open();

            DeviceManager manager = new DeviceManager(new[] { device });

            ThreadStart start1 = device.TriggerDataReceived;
            ThreadStart start2 = manager.EnableCooling;

            Thread thread1 = new Thread(start1);
            thread1.Name = "Thread 1";

            Thread thread2 = new Thread(start2);
            thread2.Name = "Thread 2";

            // Start both the threads.
            // Expect thread blocking as external device locks internally then calls manager which locks internally
            // call to manager locks internally then calles external device which tries to lock internally.
            thread2.Start();
            thread1.Start();

            if (!thread1.Join(5000))
            {
                Debug.WriteLine("t1 join");
                Assert.Fail("Thread 1 timeout");
            }

            if (!thread2.Join(5000))
            {
                Debug.WriteLine("t2 join");
                Assert.Fail("Thread 2 timeout");
            }
        }
    }
}
