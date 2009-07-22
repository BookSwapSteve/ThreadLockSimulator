using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThreadLockSimulator.Model
{
    public interface IExternalDevice
    {
        event EventHandler DataReceived;
        void Open();
        void Close();
        float ReadTemperature();
        void EnableCooling();
        void DisableCooling();
        bool CheckStatus();
    }
}
