using System;
using System.Collections.Generic;
using System.Text;

namespace DAQmx.Core.LinuxRT
{
    public enum DAQmxInputTerminalConfiguration
    {
        Default = -1,
        RSE = 10083,
        NRSE = 10078,
        Differential = 10106,
        Pseudodifferential = 12529,
    }
}
