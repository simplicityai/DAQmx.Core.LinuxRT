using System;
using System.Collections.Generic;
using System.Text;

namespace DAQmx.Core.LinuxRT
{
    public static class DAQmx
    {
        public static string GetErrorString(int errorCode)
        {
            StringBuilder errorString = new StringBuilder(256);
            Interop.DAQmxGetErrorString(errorCode, errorString, (uint)(errorString.Capacity + 1));
            return errorString.ToString();
        }
    }
}
