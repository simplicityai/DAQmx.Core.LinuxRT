using System;
using System.Collections.Generic;
using System.Text;

namespace DAQmx.Core.LinuxRT
{
    public class DAQmxException : Exception
    {
        public DAQmxException(string message) : base(message) { }
    }
}
