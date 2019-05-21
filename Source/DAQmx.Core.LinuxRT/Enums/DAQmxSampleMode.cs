using System;
using System.Collections.Generic;
using System.Text;

namespace DAQmx.Core.LinuxRT
{
    public enum DAQmxSampleMode
    {
        FiniteSamples = 10178,
        ContinuousSamples = 10123,
        HardwareTimedSinglePoint = 12522
    }
}
