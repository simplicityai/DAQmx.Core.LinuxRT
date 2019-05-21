using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace DAQmx.Core.LinuxRT
{
    public class DAQmxTask
    {
        private IntPtr taskHandle;
        private int channels;
        private DAQmxTask() { }

        public static DAQmxTask Create(string taskName)
        {
            int error = Interop.DAQmxCreateTask(taskName, out IntPtr taskHandleIntPtr);
            if (error < 0)
                throw new DAQmxException(error, "Could not create Task");
            return new DAQmxTask()
            {
                taskHandle = taskHandleIntPtr,
                channels = 0
            };
        }

        public void CreateAIVoltageChan(string physicalChannel, string nameToAssignToChannel, DAQmxInputTerminalConfiguration terminalConfig, double minVal, double maxVal, DAQmxUnits units, string customScaleName)
        {
            int error = Interop.DAQmxCreateAIVoltageChan(taskHandle, physicalChannel, nameToAssignToChannel, (int)terminalConfig, minVal, maxVal, (int)units, customScaleName);
            if (error < 0)
                throw new DAQmxException(error, "Could not create AI Voltage channel");
            channels++;
        }

        public void CfgSampClkTiming(string source, double rate, DAQmxActiveEdge activeEdge, DAQmxSampleMode sampleMode, ulong sampsPerChan)
        {
            int error = Interop.DAQmxCfgSampClkTiming(taskHandle, source, rate, (int)activeEdge, (int)sampleMode, sampsPerChan);
            if (error < 0)
                throw new DAQmxException(error, "Could not configure Sample Clock Timing");
        }

        public Span<double> ReadAnalogF64(int numSampsPerChan, double timeout, DAQmxFillMode fillMode)
        {
            var arraySize = numSampsPerChan * channels;
            var data = new double[arraySize];
            int error = Interop.DAQmxReadAnalogF64(taskHandle, numSampsPerChan, timeout, (int)fillMode, data, (uint)arraySize, out IntPtr sampsPerChanReadIntPtr, new IntPtr());
            if (error < 0)
                throw new DAQmxException(error, "Could not read samples");
            var sampsPerChanRead = sampsPerChanReadIntPtr.ToInt32();
            if (sampsPerChanRead != numSampsPerChan)
                throw new DAQmxException("Could not read requested number of samples");
            return new Span<double>(data);
        }

        public void Stop()
        {
            int error = Interop.DAQmxStopTask(taskHandle);
            if (error < 0)
                throw new DAQmxException(error, "Could not stop Task");
        }

        public void Clear()
        {
            int error = Interop.DAQmxClearTask(taskHandle);
            if (error < 0)
                throw new DAQmxException(error, "Could not clear Task");
        }
    }
}
