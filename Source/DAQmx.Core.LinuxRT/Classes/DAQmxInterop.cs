using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace DAQmx.Core.LinuxRT
{
    internal class Interop
    {
        [DllImport("/usr/local/natinst/lib/libnidaqmx.so", CallingConvention = CallingConvention.StdCall)]
        internal static extern int DAQmxCreateTask(string taskName, out IntPtr taskHandle);

        [DllImport("/usr/local/natinst/lib/libnidaqmx.so", CallingConvention = CallingConvention.StdCall)]
        internal static extern int DAQmxCreateAIVoltageChan(IntPtr taskHandle, string physicalChannel, string nameToAssignToChannel, int terminalConfig, double minVal, double maxVal, int units, string customScaleName);

        [DllImport("/usr/local/natinst/lib/libnidaqmx.so", CallingConvention = CallingConvention.StdCall)]
        internal static extern int DAQmxCfgSampClkTiming(IntPtr taskHandle, string source, double rate, int activeEdge, int sampleMode, ulong sampsPerChan);

        [DllImport("/usr/local/natinst/lib/libnidaqmx.so", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 DAQmxReadAnalogF64(IntPtr taskHandle, Int32 numSampsPerChan, double timeout, Int32 fillMode, double[] readArray, UInt32 arraySizeInSamps, out IntPtr sampsPerChanRead, IntPtr reserved);

        [DllImport("/usr/local/natinst/lib/libnidaqmx.so", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 DAQmxStopTask(IntPtr taskHandle);

        [DllImport("/usr/local/natinst/lib/libnidaqmx.so", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 DAQmxClearTask(IntPtr taskHandle);
    }
}
