using System;
using System.Linq;

namespace DAQmx.Core.LinuxRT.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DAQmxTask task = DAQmxTask.Create("AI Task");
            bool runLoop = true;

            Console.CancelKeyPress += (s, ev) =>
            {
                runLoop = false;
                ev.Cancel = true;
            };

            task.CreateAIVoltageChan("cDAQ2Mod1/ai0", "Voltage0", DAQmxInputTerminalConfiguration.Default, -10, 10, DAQmxUnits.Volts, "");
            task.CreateAIVoltageChan("cDAQ2Mod1/ai1", "Voltage1", DAQmxInputTerminalConfiguration.Default, -10, 10, DAQmxUnits.Volts, "");
            task.CreateAIVoltageChan("cDAQ2Mod1/ai2", "Voltage2", DAQmxInputTerminalConfiguration.Default, -10, 10, DAQmxUnits.Volts, "");
            task.CreateAIVoltageChan("cDAQ2Mod1/ai3", "Voltage3", DAQmxInputTerminalConfiguration.Default, -10, 10, DAQmxUnits.Volts, "");
            task.CreateAIVoltageChan("cDAQ2Mod2/ai0", "Voltage4", DAQmxInputTerminalConfiguration.Default, -10, 10, DAQmxUnits.Volts, "");
            task.CreateAIVoltageChan("cDAQ2Mod2/ai1", "Voltage5", DAQmxInputTerminalConfiguration.Default, -10, 10, DAQmxUnits.Volts, "");
            task.CreateAIVoltageChan("cDAQ2Mod2/ai2", "Voltage6", DAQmxInputTerminalConfiguration.Default, -10, 10, DAQmxUnits.Volts, "");
            task.CreateAIVoltageChan("cDAQ2Mod2/ai3", "Voltage7", DAQmxInputTerminalConfiguration.Default, -10, 10, DAQmxUnits.Volts, "");
            task.CreateAIVoltageChan("cDAQ2Mod3/ai0", "Voltage8", DAQmxInputTerminalConfiguration.Default, -10, 10, DAQmxUnits.Volts, "");
            task.CreateAIVoltageChan("cDAQ2Mod3/ai1", "Voltage9", DAQmxInputTerminalConfiguration.Default, -10, 10, DAQmxUnits.Volts, "");
            task.CreateAIVoltageChan("cDAQ2Mod3/ai2", "Voltage10", DAQmxInputTerminalConfiguration.Default, -10, 10, DAQmxUnits.Volts, "");
            task.CreateAIVoltageChan("cDAQ2Mod3/ai3", "Voltage11", DAQmxInputTerminalConfiguration.Default, -10, 10, DAQmxUnits.Volts, "");
            task.CreateAIVoltageChan("cDAQ2Mod4/ai0", "Voltage12", DAQmxInputTerminalConfiguration.Default, -10, 10, DAQmxUnits.Volts, "");
            task.CreateAIVoltageChan("cDAQ2Mod4/ai1", "Voltage13", DAQmxInputTerminalConfiguration.Default, -10, 10, DAQmxUnits.Volts, "");
            task.CreateAIVoltageChan("cDAQ2Mod4/ai2", "Voltage14", DAQmxInputTerminalConfiguration.Default, -10, 10, DAQmxUnits.Volts, "");
            task.CreateAIVoltageChan("cDAQ2Mod4/ai3", "Voltage15", DAQmxInputTerminalConfiguration.Default, -10, 10, DAQmxUnits.Volts, "");
            task.CreateAIVoltageChan("cDAQ2Mod5/ai0", "Voltage16", DAQmxInputTerminalConfiguration.Default, -10, 10, DAQmxUnits.Volts, "");
            task.CreateAIVoltageChan("cDAQ2Mod5/ai1", "Voltage17", DAQmxInputTerminalConfiguration.Default, -10, 10, DAQmxUnits.Volts, "");
            task.CreateAIVoltageChan("cDAQ2Mod5/ai2", "Voltage18", DAQmxInputTerminalConfiguration.Default, -10, 10, DAQmxUnits.Volts, "");
            task.CreateAIVoltageChan("cDAQ2Mod5/ai3", "Voltage19", DAQmxInputTerminalConfiguration.Default, -10, 10, DAQmxUnits.Volts, "");
            task.CreateAIVoltageChan("cDAQ2Mod6/ai0", "Voltage20", DAQmxInputTerminalConfiguration.Default, -10, 10, DAQmxUnits.Volts, "");
            task.CreateAIVoltageChan("cDAQ2Mod6/ai1", "Voltage21", DAQmxInputTerminalConfiguration.Default, -10, 10, DAQmxUnits.Volts, "");
            task.CreateAIVoltageChan("cDAQ2Mod6/ai2", "Voltage22", DAQmxInputTerminalConfiguration.Default, -10, 10, DAQmxUnits.Volts, "");
            task.CreateAIVoltageChan("cDAQ2Mod6/ai3", "Voltage23", DAQmxInputTerminalConfiguration.Default, -10, 10, DAQmxUnits.Volts, "");
            task.CreateAIVoltageChan("cDAQ2Mod7/ai0", "Voltage24", DAQmxInputTerminalConfiguration.Default, -10, 10, DAQmxUnits.Volts, "");
            task.CreateAIVoltageChan("cDAQ2Mod7/ai1", "Voltage25", DAQmxInputTerminalConfiguration.Default, -10, 10, DAQmxUnits.Volts, "");
            task.CreateAIVoltageChan("cDAQ2Mod7/ai2", "Voltage26", DAQmxInputTerminalConfiguration.Default, -10, 10, DAQmxUnits.Volts, "");
            task.CreateAIVoltageChan("cDAQ2Mod7/ai3", "Voltage27", DAQmxInputTerminalConfiguration.Default, -10, 10, DAQmxUnits.Volts, "");
            task.CfgSampClkTiming("", 100000, DAQmxActiveEdge.Rising, DAQmxSampleMode.ContinuousSamples, 10000);
            Console.WriteLine("DAQmx Task started.");
            for (int i = 0; runLoop; i++)
            {
                Span<double> data = task.ReadAnalogF64(10000, 10, DAQmxFillMode.GroupByScanNumber);
                if (i % 10 == 0)
                    Console.WriteLine("Samples: " + string.Join(", ", data.Slice(0, 8).ToArray()));
            }
            task.Stop();
            task.Clear();
            Console.WriteLine("DAQmx Task stopped.");
        }
    }
}
