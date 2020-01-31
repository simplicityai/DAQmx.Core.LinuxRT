using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace DAQmx.Core.LinuxRT
{
    internal class Interop
    {
        #region Task Configuration/Control
        /*
        int32 __CFUNC     DAQmxLoadTask                  (const char taskName[], TaskHandle *taskHandle);
        int32 __CFUNC     DAQmxCreateTask                (const char taskName[], TaskHandle *taskHandle);
        // Channel Names must be valid channels already available in MAX. They are not created.
        int32 __CFUNC     DAQmxAddGlobalChansToTask      (TaskHandle taskHandle, const char channelNames[]);

        int32 __CFUNC     DAQmxStartTask                 (TaskHandle taskHandle);
        int32 __CFUNC     DAQmxStopTask                  (TaskHandle taskHandle);

        int32 __CFUNC     DAQmxClearTask                 (TaskHandle taskHandle);

        int32 __CFUNC     DAQmxWaitUntilTaskDone         (TaskHandle taskHandle, float64 timeToWait);
        int32 __CFUNC     DAQmxWaitForValidTimestamp     (TaskHandle taskHandle, int32 timestampEvent, float64 timeout, CVIAbsoluteTime* timestamp);
        int32 __CFUNC     DAQmxIsTaskDone                (TaskHandle taskHandle, bool32 *isTaskDone);

        int32 __CFUNC     DAQmxTaskControl               (TaskHandle taskHandle, int32 action);

        int32 __CFUNC     DAQmxGetNthTaskChannel         (TaskHandle taskHandle, uInt32 index, char buffer[], int32 bufferSize);

        int32 __CFUNC     DAQmxGetNthTaskDevice          (TaskHandle taskHandle, uInt32 index, char buffer[], int32 bufferSize);

        int32 __CFUNC_C   DAQmxGetTaskAttribute          (TaskHandle taskHandle, int32 attribute, void *value, ...);

        typedef int32 (CVICALLBACK *DAQmxEveryNSamplesEventCallbackPtr)(TaskHandle taskHandle, int32 everyNsamplesEventType, uInt32 nSamples, void *callbackData);
        typedef int32 (CVICALLBACK *DAQmxDoneEventCallbackPtr)(TaskHandle taskHandle, int32 status, void *callbackData);
        typedef int32 (CVICALLBACK *DAQmxSignalEventCallbackPtr)(TaskHandle taskHandle, int32 signalID, void *callbackData);

        int32 __CFUNC     DAQmxRegisterEveryNSamplesEvent(TaskHandle task, int32 everyNsamplesEventType, uInt32 nSamples, uInt32 options, DAQmxEveryNSamplesEventCallbackPtr callbackFunction, void *callbackData);
        int32 __CFUNC     DAQmxRegisterDoneEvent         (TaskHandle task, uInt32 options, DAQmxDoneEventCallbackPtr callbackFunction, void *callbackData);
        int32 __CFUNC     DAQmxRegisterSignalEvent       (TaskHandle task, int32 signalID, uInt32 options, DAQmxSignalEventCallbackPtr callbackFunction, void *callbackData);
         */
        [DllImport("/usr/local/natinst/lib/libnidaqmx.so", CallingConvention = CallingConvention.StdCall)]
        internal static extern int DAQmxLoadTask(string taskName, out IntPtr taskHandle);

        [DllImport("/usr/local/natinst/lib/libnidaqmx.so", CallingConvention = CallingConvention.StdCall)]
        internal static extern int DAQmxCreateTask(string taskName, out IntPtr taskHandle);

        //[DllImport("/usr/local/natinst/lib/libnidaqmx.so", CallingConvention = CallingConvention.StdCall)]
        //internal static extern int DAQmxAddGlobalChansToTask(string taskName, out IntPtr taskHandle);

        [DllImport("/usr/local/natinst/lib/libnidaqmx.so", CallingConvention = CallingConvention.StdCall)]
        internal static extern int DAQmxStartTask(IntPtr taskHandle);

        [DllImport("/usr/local/natinst/lib/libnidaqmx.so", CallingConvention = CallingConvention.StdCall)]
        internal static extern int DAQmxStopTask(IntPtr taskHandle);

        [DllImport("/usr/local/natinst/lib/libnidaqmx.so", CallingConvention = CallingConvention.StdCall)]
        internal static extern int DAQmxClearTask(IntPtr taskHandle);
        #endregion
        #region Channel Configuration/Creation
        [DllImport("/usr/local/natinst/lib/libnidaqmx.so", CallingConvention = CallingConvention.StdCall)]
        internal static extern int DAQmxCreateAIVoltageChan(IntPtr taskHandle, string physicalChannel, string nameToAssignToChannel, int terminalConfig, double minVal, double maxVal, int units, string customScaleName);
        /*
        int32 __CFUNC     DAQmxCreateAICurrentChan       (TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], int32 terminalConfig, float64 minVal, float64 maxVal, int32 units, int32 shuntResistorLoc, float64 extShuntResistorVal, const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateAIVoltageRMSChan    (TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], int32 terminalConfig, float64 minVal, float64 maxVal, int32 units, const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateAICurrentRMSChan    (TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], int32 terminalConfig, float64 minVal, float64 maxVal, int32 units, int32 shuntResistorLoc, float64 extShuntResistorVal, const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateAIThrmcplChan       (TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], float64 minVal, float64 maxVal, int32 units, int32 thermocoupleType, int32 cjcSource, float64 cjcVal, const char cjcChannel[]);
        int32 __CFUNC     DAQmxCreateAIRTDChan           (TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], float64 minVal, float64 maxVal, int32 units, int32 rtdType, int32 resistanceConfig, int32 currentExcitSource, float64 currentExcitVal, float64 r0);
        int32 __CFUNC     DAQmxCreateAIThrmstrChanIex    (TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], float64 minVal, float64 maxVal, int32 units, int32 resistanceConfig, int32 currentExcitSource, float64 currentExcitVal, float64 a, float64 b, float64 c);
        int32 __CFUNC     DAQmxCreateAIThrmstrChanVex    (TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], float64 minVal, float64 maxVal, int32 units, int32 resistanceConfig, int32 voltageExcitSource, float64 voltageExcitVal, float64 a, float64 b, float64 c, float64 r1);
        int32 __CFUNC     DAQmxCreateAIFreqVoltageChan   (TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], float64 minVal, float64 maxVal, int32 units, float64 thresholdLevel, float64 hysteresis, const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateAIResistanceChan    (TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], float64 minVal, float64 maxVal, int32 units, int32 resistanceConfig, int32 currentExcitSource, float64 currentExcitVal, const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateAIStrainGageChan    (TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], float64 minVal, float64 maxVal, int32 units, int32 strainConfig, int32 voltageExcitSource, float64 voltageExcitVal, float64 gageFactor, float64 initialBridgeVoltage, float64 nominalGageResistance, float64 poissonRatio, float64 leadWireResistance, const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateAIRosetteStrainGageChan    (TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], float64 minVal, float64 maxVal, int32 rosetteType, float64 gageOrientation, const int32 rosetteMeasTypes[], uInt32 numRosetteMeasTypes, int32 strainConfig, int32 voltageExcitSource, float64 voltageExcitVal,float64 gageFactor, float64 nominalGageResistance,float64 poissonRatio,float64 leadWireResistance);
        int32 __CFUNC     DAQmxCreateAIForceBridgeTwoPointLinChan(TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[],float64 minVal,float64 maxVal,int32 units,int32 bridgeConfig,int32 voltageExcitSource,float64 voltageExcitVal,float64 nominalBridgeResistance,float64 firstElectricalVal,float64 secondElectricalVal,int32	electricalUnits,float64 firstPhysicalVal,float64 secondPhysicalVal,int32 physicalUnits,const char customScaleName[]);

        int32 __CFUNC     DAQmxCreateAIForceBridgeTableChan(TaskHandle taskHandle,const char physicalChannel[],const char nameToAssignToChannel[],float64 minVal,float64 maxVal,int32 units,int32 bridgeConfig,int32 voltageExcitSource,float64 voltageExcitVal,float64 nominalBridgeResistance,const float64 electricalVals[],uInt32 numElectricalVals,int32	electricalUnits,const float64 physicalVals[],uInt32 numPhysicalVals,int32 physicalUnits,const char customScaleName[]);

        int32 __CFUNC     DAQmxCreateAIForceBridgePolynomialChan(TaskHandle taskHandle,const char physicalChannel[],const char nameToAssignToChannel[],float64 minVal,float64 maxVal,int32 units,int32 bridgeConfig,int32 voltageExcitSource,float64 voltageExcitVal,float64 nominalBridgeResistance,const float64 forwardCoeffs[],uInt32 numForwardCoeffs,const float64 reverseCoeffs[],uInt32 numReverseCoeffs,int32	electricalUnits,int32 physicalUnits,const char customScaleName[]);

        int32 __CFUNC     DAQmxCreateAIPressureBridgeTwoPointLinChan(TaskHandle taskHandle,const char physicalChannel[],const char nameToAssignToChannel[],float64 minVal,float64 maxVal,int32 units,int32 bridgeConfig,int32 voltageExcitSource,float64 voltageExcitVal,float64 nominalBridgeResistance,float64 firstElectricalVal,float64 secondElectricalVal,int32	electricalUnits,float64 firstPhysicalVal,float64 secondPhysicalVal,int32 physicalUnits,const char customScaleName[]);

        int32 __CFUNC     DAQmxCreateAIPressureBridgeTableChan(TaskHandle taskHandle,const char physicalChannel[],const char nameToAssignToChannel[],float64 minVal,float64 maxVal,int32 units,int32 bridgeConfig,int32 voltageExcitSource,float64 voltageExcitVal,float64 nominalBridgeResistance,const float64 electricalVals[],uInt32 numElectricalVals,int32	electricalUnits,const float64 physicalVals[],uInt32 numPhysicalVals,int32 physicalUnits,const char customScaleName[]);

        int32 __CFUNC     DAQmxCreateAIPressureBridgePolynomialChan(TaskHandle taskHandle,const char physicalChannel[],const char nameToAssignToChannel[],float64 minVal,float64 maxVal,int32 units,int32 bridgeConfig,int32 voltageExcitSource,float64 voltageExcitVal,float64 nominalBridgeResistance,const float64 forwardCoeffs[],uInt32 numForwardCoeffs,const float64 reverseCoeffs[],uInt32 numReverseCoeffs,int32	electricalUnits,int32 physicalUnits,const char customScaleName[]);

        int32 __CFUNC     DAQmxCreateAITorqueBridgeTwoPointLinChan(TaskHandle taskHandle,const char physicalChannel[],const char nameToAssignToChannel[],float64 minVal,float64 maxVal,int32 units,int32 bridgeConfig,int32 voltageExcitSource,float64 voltageExcitVal,float64 nominalBridgeResistance,float64 firstElectricalVal,float64 secondElectricalVal,int32	electricalUnits,float64 firstPhysicalVal,float64 secondPhysicalVal,int32 physicalUnits,const char customScaleName[]);

        int32 __CFUNC     DAQmxCreateAITorqueBridgeTableChan(TaskHandle taskHandle,const char physicalChannel[],const char nameToAssignToChannel[],float64 minVal,float64 maxVal,int32 units,int32 bridgeConfig,int32 voltageExcitSource,float64 voltageExcitVal,float64 nominalBridgeResistance,const float64 electricalVals[],uInt32 numElectricalVals,int32	electricalUnits,const float64 physicalVals[],uInt32 numPhysicalVals,int32 physicalUnits,const char customScaleName[]);

        int32 __CFUNC     DAQmxCreateAITorqueBridgePolynomialChan(TaskHandle taskHandle,const char physicalChannel[],const char nameToAssignToChannel[],float64 minVal,float64 maxVal,int32 units,int32 bridgeConfig,int32 voltageExcitSource,float64 voltageExcitVal,float64 nominalBridgeResistance,const float64 forwardCoeffs[],uInt32 numForwardCoeffs,const float64 reverseCoeffs[],uInt32 numReverseCoeffs,int32	electricalUnits,int32 physicalUnits,const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateAIBridgeChan    (TaskHandle taskHandle,const char physicalChannel[],const char nameToAssignToChannel[],float64 minVal,float64 maxVal,int32 units,int32 bridgeConfig,int32 voltageExcitSource,float64 voltageExcitVal,float64 nominalBridgeResistance,const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateAIVoltageChanWithExcit(TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], int32 terminalConfig, float64 minVal, float64 maxVal, int32 units, int32 bridgeConfig, int32 voltageExcitSource, float64 voltageExcitVal, bool32 useExcitForScaling, const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateAITempBuiltInSensorChan(TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], int32 units);
        int32 __CFUNC     DAQmxCreateAIAccelChan         (TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], int32 terminalConfig, float64 minVal, float64 maxVal, int32 units, float64 sensitivity, int32 sensitivityUnits, int32 currentExcitSource, float64 currentExcitVal, const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateAIVelocityIEPEChan  (TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], int32 terminalConfig, float64 minVal, float64 maxVal, int32 units, float64 sensitivity, int32 sensitivityUnits, int32 currentExcitSource, float64 currentExcitVal, const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateAIForceIEPEChan         (TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], int32 terminalConfig, float64 minVal, float64 maxVal, int32 units, float64 sensitivity, int32 sensitivityUnits, int32 currentExcitSource, float64 currentExcitVal, const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateAIMicrophoneChan    (TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], int32 terminalConfig, int32 units, float64 micSensitivity, float64 maxSndPressLevel, int32 currentExcitSource, float64 currentExcitVal, const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateAIChargeChan       (TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], int32 terminalConfig, float64 minVal, float64 maxVal, int32 units, const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateAIAccelChargeChan  (TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], int32 terminalConfig, float64 minVal, float64 maxVal, int32 units, float64 sensitivity, int32 sensitivityUnits, const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateAIAccel4WireDCVoltageChan  (TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], int32 terminalConfig, float64 minVal, float64 maxVal, int32 units, float64 sensitivity, int32 sensitivityUnits, int32 voltageExcitSource, float64 voltageExcitVal, bool32 useExcitForScaling, const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateAIPosLVDTChan       (TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], float64 minVal, float64 maxVal, int32 units, float64 sensitivity, int32 sensitivityUnits, int32 voltageExcitSource, float64 voltageExcitVal, float64 voltageExcitFreq, int32 ACExcitWireMode, const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateAIPosRVDTChan       (TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], float64 minVal, float64 maxVal, int32 units, float64 sensitivity, int32 sensitivityUnits, int32 voltageExcitSource, float64 voltageExcitVal, float64 voltageExcitFreq, int32 ACExcitWireMode, const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateAIPosEddyCurrProxProbeChan(TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], float64 minVal, float64 maxVal, int32 units, float64 sensitivity, int32 sensitivityUnits, const char customScaleName[]);
        // Function DAQmxCreateAIDeviceTempChan is obsolete and has been replaced by DAQmxCreateAITempBuiltInSensorChan
        int32 __CFUNC     DAQmxCreateAIDeviceTempChan    (TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], int32 units);

        int32 __CFUNC     DAQmxCreateTEDSAIVoltageChan   (TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], int32 terminalConfig, float64 minVal, float64 maxVal, int32 units, const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateTEDSAICurrentChan   (TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], int32 terminalConfig, float64 minVal, float64 maxVal, int32 units, int32 shuntResistorLoc, float64 extShuntResistorVal, const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateTEDSAIThrmcplChan   (TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], float64 minVal, float64 maxVal, int32 units, int32 cjcSource, float64 cjcVal, const char cjcChannel[]);
        int32 __CFUNC     DAQmxCreateTEDSAIRTDChan       (TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], float64 minVal, float64 maxVal, int32 units, int32 resistanceConfig, int32 currentExcitSource, float64 currentExcitVal);
        int32 __CFUNC     DAQmxCreateTEDSAIThrmstrChanIex(TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], float64 minVal, float64 maxVal, int32 units, int32 resistanceConfig, int32 currentExcitSource, float64 currentExcitVal);
        int32 __CFUNC     DAQmxCreateTEDSAIThrmstrChanVex(TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], float64 minVal, float64 maxVal, int32 units, int32 resistanceConfig, int32 voltageExcitSource, float64 voltageExcitVal, float64 r1);
        int32 __CFUNC     DAQmxCreateTEDSAIResistanceChan(TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], float64 minVal, float64 maxVal, int32 units, int32 resistanceConfig, int32 currentExcitSource, float64 currentExcitVal, const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateTEDSAIStrainGageChan(TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], float64 minVal, float64 maxVal, int32 units, int32 voltageExcitSource, float64 voltageExcitVal, float64 initialBridgeVoltage, float64 leadWireResistance, const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateTEDSAIForceBridgeChan(TaskHandle taskHandle,const char physicalChannel[],const char nameToAssignToChannel[],float64 minVal,float64 maxVal,int32 units,int32 voltageExcitSource,float64 voltageExcitVal,const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateTEDSAIPressureBridgeChan(TaskHandle taskHandle,const char physicalChannel[],const char nameToAssignToChannel[],float64 minVal,float64 maxVal,int32 units,int32 voltageExcitSource,float64 voltageExcitVal,	const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateTEDSAITorqueBridgeChan(TaskHandle taskHandle,const char physicalChannel[],const char nameToAssignToChannel[],float64 minVal,float64 maxVal,int32 units,int32 voltageExcitSource,float64 voltageExcitVal,const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateTEDSAIBridgeChan    (TaskHandle taskHandle,const char physicalChannel[],const char nameToAssignToChannel[],float64 minVal,float64 maxVal,int32 units,int32 voltageExcitSource,float64 voltageExcitVal,const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateTEDSAIVoltageChanWithExcit(TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], int32 terminalConfig, float64 minVal, float64 maxVal, int32 units, int32 voltageExcitSource, float64 voltageExcitVal, const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateTEDSAIAccelChan     (TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], int32 terminalConfig, float64 minVal, float64 maxVal, int32 units, int32 currentExcitSource, float64 currentExcitVal, const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateTEDSAIForceIEPEChan     (TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], int32 terminalConfig, float64 minVal, float64 maxVal, int32 units, int32 currentExcitSource, float64 currentExcitVal, const char customScaleName[]);

        int32 __CFUNC     DAQmxCreateTEDSAIMicrophoneChan(TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], int32 terminalConfig, int32 units, float64 maxSndPressLevel, int32 currentExcitSource, float64 currentExcitVal, const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateTEDSAIPosLVDTChan   (TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], float64 minVal, float64 maxVal, int32 units, int32 voltageExcitSource, float64 voltageExcitVal, float64 voltageExcitFreq, int32 ACExcitWireMode, const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateTEDSAIPosRVDTChan   (TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], float64 minVal, float64 maxVal, int32 units, int32 voltageExcitSource, float64 voltageExcitVal, float64 voltageExcitFreq, int32 ACExcitWireMode, const char customScaleName[]);

        int32 __CFUNC     DAQmxCreateAOVoltageChan       (TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], float64 minVal, float64 maxVal, int32 units, const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateAOCurrentChan       (TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], float64 minVal, float64 maxVal, int32 units, const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateAOFuncGenChan       (TaskHandle taskHandle, const char physicalChannel[], const char nameToAssignToChannel[], int32 type, float64 freq, float64 amplitude, float64 offset);

        int32 __CFUNC     DAQmxCreateDIChan              (TaskHandle taskHandle, const char lines[], const char nameToAssignToLines[], int32 lineGrouping);

        int32 __CFUNC     DAQmxCreateDOChan              (TaskHandle taskHandle, const char lines[], const char nameToAssignToLines[], int32 lineGrouping);

        int32 __CFUNC     DAQmxCreateCIFreqChan          (TaskHandle taskHandle, const char counter[], const char nameToAssignToChannel[], float64 minVal, float64 maxVal, int32 units, int32 edge, int32 measMethod, float64 measTime, uInt32 divisor, const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateCIPeriodChan        (TaskHandle taskHandle, const char counter[], const char nameToAssignToChannel[], float64 minVal, float64 maxVal, int32 units, int32 edge, int32 measMethod, float64 measTime, uInt32 divisor, const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateCICountEdgesChan    (TaskHandle taskHandle, const char counter[], const char nameToAssignToChannel[], int32 edge, uInt32 initialCount, int32 countDirection);
        int32 __CFUNC     DAQmxCreateCIDutyCycleChan     (TaskHandle taskHandle, const char counter[], const char nameToAssignToChannel[], float64 minFreq, float64 maxFreq, int32 edge, const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateCIPulseWidthChan    (TaskHandle taskHandle, const char counter[], const char nameToAssignToChannel[], float64 minVal, float64 maxVal, int32 units, int32 startingEdge, const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateCISemiPeriodChan    (TaskHandle taskHandle, const char counter[], const char nameToAssignToChannel[], float64 minVal, float64 maxVal, int32 units, const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateCITwoEdgeSepChan       (TaskHandle taskHandle, const char counter[], const char nameToAssignToChannel[], float64 minVal, float64 maxVal, int32 units, int32 firstEdge, int32 secondEdge, const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateCIPulseChanFreq        (TaskHandle taskHandle, const char counter[], const char nameToAssignToChannel[], float64 minVal, float64 maxVal, int32 units);
        int32 __CFUNC     DAQmxCreateCIPulseChanTime        (TaskHandle taskHandle, const char counter[], const char nameToAssignToChannel[], float64 minVal, float64 maxVal, int32 units);
        int32 __CFUNC     DAQmxCreateCIPulseChanTicks       (TaskHandle taskHandle, const char counter[], const char nameToAssignToChannel[], const char sourceTerminal[], float64 minVal, float64 maxVal);
        int32 __CFUNC     DAQmxCreateCILinEncoderChan    (TaskHandle taskHandle, const char counter[], const char nameToAssignToChannel[], int32 decodingType, bool32 ZidxEnable, float64 ZidxVal, int32 ZidxPhase, int32 units, float64 distPerPulse, float64 initialPos, const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateCIAngEncoderChan    (TaskHandle taskHandle, const char counter[], const char nameToAssignToChannel[], int32 decodingType, bool32 ZidxEnable, float64 ZidxVal, int32 ZidxPhase, int32 units, uInt32 pulsesPerRev, float64 initialAngle, const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateCILinVelocityChan  (TaskHandle taskHandle, const char counter[], const char nameToAssignToChannel[], float64 minVal, float64 maxVal, int32 decodingType, int32 units, float64 distPerPulse, const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateCIAngVelocityChan  (TaskHandle taskHandle, const char counter[], const char nameToAssignToChannel[], float64 minVal, float64 maxVal, int32 decodingType, int32 units, uInt32 pulsesPerRev, const char customScaleName[]);
        int32 __CFUNC     DAQmxCreateCIGPSTimestampChan  (TaskHandle taskHandle, const char counter[], const char nameToAssignToChannel[], int32 units, int32 syncMethod, const char customScaleName[]);

        int32 __CFUNC     DAQmxCreateCOPulseChanFreq     (TaskHandle taskHandle, const char counter[], const char nameToAssignToChannel[], int32 units, int32 idleState, float64 initialDelay, float64 freq, float64 dutyCycle);
        int32 __CFUNC     DAQmxCreateCOPulseChanTime     (TaskHandle taskHandle, const char counter[], const char nameToAssignToChannel[], int32 units, int32 idleState, float64 initialDelay, float64 lowTime, float64 highTime);
        int32 __CFUNC     DAQmxCreateCOPulseChanTicks    (TaskHandle taskHandle, const char counter[], const char nameToAssignToChannel[], const char sourceTerminal[], int32 idleState, int32 initialDelay, int32 lowTicks, int32 highTicks);

        int32 __CFUNC     DAQmxGetAIChanCalCalDate       (TaskHandle taskHandle, const char channelName[], uInt32 *year, uInt32 *month, uInt32 *day, uInt32 *hour, uInt32 *minute);
        int32 __CFUNC     DAQmxSetAIChanCalCalDate       (TaskHandle taskHandle, const char channelName[], uInt32 year, uInt32 month, uInt32 day, uInt32 hour, uInt32 minute);
        int32 __CFUNC     DAQmxGetAIChanCalExpDate       (TaskHandle taskHandle, const char channelName[], uInt32 *year, uInt32 *month, uInt32 *day, uInt32 *hour, uInt32 *minute);
        int32 __CFUNC     DAQmxSetAIChanCalExpDate       (TaskHandle taskHandle, const char channelName[], uInt32 year, uInt32 month, uInt32 day, uInt32 hour, uInt32 minute);

        int32 __CFUNC_C   DAQmxGetChanAttribute          (TaskHandle taskHandle, const char channel[], int32 attribute, void *value, ...);
        int32 __CFUNC_C   DAQmxSetChanAttribute          (TaskHandle taskHandle, const char channel[], int32 attribute, ...);
        int32 __CFUNC     DAQmxResetChanAttribute        (TaskHandle taskHandle, const char channel[], int32 attribute);
         */
        #endregion
        #region Timing
        [DllImport("/usr/local/natinst/lib/libnidaqmx.so", CallingConvention = CallingConvention.StdCall)]                                                      // (Analog/Counter Timing)
        internal static extern int DAQmxCfgSampClkTiming(IntPtr taskHandle, string source, double rate, int activeEdge, int sampleMode, ulong sampsPerChan);
        /*
        // (Digital Timing)
        int32 __CFUNC     DAQmxCfgHandshakingTiming      (TaskHandle taskHandle, int32 sampleMode, uInt64 sampsPerChan);
        // (Burst Import Clock Timing)
        int32 __CFUNC     DAQmxCfgBurstHandshakingTimingImportClock(TaskHandle taskHandle, int32 sampleMode, uInt64 sampsPerChan, float64 sampleClkRate, const char sampleClkSrc[], int32 sampleClkActiveEdge, int32 pauseWhen, int32 readyEventActiveLevel);
        // (Burst Export Clock Timing)
        int32 __CFUNC     DAQmxCfgBurstHandshakingTimingExportClock(TaskHandle taskHandle, int32 sampleMode, uInt64 sampsPerChan, float64 sampleClkRate, const char sampleClkOutpTerm[], int32 sampleClkPulsePolarity, int32 pauseWhen, int32 readyEventActiveLevel);
        int32 __CFUNC     DAQmxCfgChangeDetectionTiming  (TaskHandle taskHandle, const char risingEdgeChan[], const char fallingEdgeChan[], int32 sampleMode, uInt64 sampsPerChan);
        // (Counter Timing)
        int32 __CFUNC     DAQmxCfgImplicitTiming         (TaskHandle taskHandle, int32 sampleMode, uInt64 sampsPerChan);
        // (Pipelined Sample Clock Timing)
        int32 __CFUNC     DAQmxCfgPipelinedSampClkTiming (TaskHandle taskHandle, const char source[], float64 rate, int32 activeEdge, int32 sampleMode, uInt64 sampsPerChan);

        int32 __CFUNC_C   DAQmxGetTimingAttribute        (TaskHandle taskHandle, int32 attribute, void *value, ...);
        int32 __CFUNC_C   DAQmxSetTimingAttribute        (TaskHandle taskHandle, int32 attribute, ...);
        int32 __CFUNC     DAQmxResetTimingAttribute      (TaskHandle taskHandle, int32 attribute);

        int32 __CFUNC_C   DAQmxGetTimingAttributeEx      (TaskHandle taskHandle, const char deviceNames[], int32 attribute, void *value, ...);
        int32 __CFUNC_C   DAQmxSetTimingAttributeEx      (TaskHandle taskHandle, const char deviceNames[], int32 attribute, ...);
        int32 __CFUNC     DAQmxResetTimingAttributeEx    (TaskHandle taskHandle, const char deviceNames[], int32 attribute);
        */
        #endregion
        #region Triggering
        #endregion
        #region Read Data
        /*
        int32 __CFUNC     DAQmxReadAnalogF64             (TaskHandle taskHandle, int32 numSampsPerChan, float64 timeout, bool32 fillMode, float64 readArray[], uInt32 arraySizeInSamps, int32 *sampsPerChanRead, bool32 *reserved);
        int32 __CFUNC     DAQmxReadAnalogScalarF64       (TaskHandle taskHandle, float64 timeout, float64 *value, bool32 *reserved);

        int32 __CFUNC     DAQmxReadBinaryI16             (TaskHandle taskHandle, int32 numSampsPerChan, float64 timeout, bool32 fillMode, int16 readArray[], uInt32 arraySizeInSamps, int32 *sampsPerChanRead, bool32 *reserved);

        int32 __CFUNC     DAQmxReadBinaryU16             (TaskHandle taskHandle, int32 numSampsPerChan, float64 timeout, bool32 fillMode, uInt16 readArray[], uInt32 arraySizeInSamps, int32 *sampsPerChanRead, bool32 *reserved);

        int32 __CFUNC     DAQmxReadBinaryI32             (TaskHandle taskHandle, int32 numSampsPerChan, float64 timeout, bool32 fillMode, int32 readArray[], uInt32 arraySizeInSamps, int32 *sampsPerChanRead, bool32 *reserved);

        int32 __CFUNC     DAQmxReadBinaryU32             (TaskHandle taskHandle, int32 numSampsPerChan, float64 timeout, bool32 fillMode, uInt32 readArray[], uInt32 arraySizeInSamps, int32 *sampsPerChanRead, bool32 *reserved);

        int32 __CFUNC     DAQmxReadDigitalU8             (TaskHandle taskHandle, int32 numSampsPerChan, float64 timeout, bool32 fillMode, uInt8 readArray[], uInt32 arraySizeInSamps, int32 *sampsPerChanRead, bool32 *reserved);
        int32 __CFUNC     DAQmxReadDigitalU16            (TaskHandle taskHandle, int32 numSampsPerChan, float64 timeout, bool32 fillMode, uInt16 readArray[], uInt32 arraySizeInSamps, int32 *sampsPerChanRead, bool32 *reserved);
        int32 __CFUNC     DAQmxReadDigitalU32            (TaskHandle taskHandle, int32 numSampsPerChan, float64 timeout, bool32 fillMode, uInt32 readArray[], uInt32 arraySizeInSamps, int32 *sampsPerChanRead, bool32 *reserved);
        int32 __CFUNC     DAQmxReadDigitalScalarU32      (TaskHandle taskHandle, float64 timeout, uInt32 *value, bool32 *reserved);
        int32 __CFUNC     DAQmxReadDigitalLines          (TaskHandle taskHandle, int32 numSampsPerChan, float64 timeout, bool32 fillMode, uInt8 readArray[], uInt32 arraySizeInBytes, int32 *sampsPerChanRead, int32 *numBytesPerSamp, bool32 *reserved);

        int32 __CFUNC     DAQmxReadCounterF64            (TaskHandle taskHandle, int32 numSampsPerChan, float64 timeout, float64 readArray[], uInt32 arraySizeInSamps, int32 *sampsPerChanRead, bool32 *reserved);
        int32 __CFUNC     DAQmxReadCounterU32            (TaskHandle taskHandle, int32 numSampsPerChan, float64 timeout, uInt32 readArray[], uInt32 arraySizeInSamps, int32 *sampsPerChanRead, bool32 *reserved);
        int32 __CFUNC     DAQmxReadCounterF64Ex          (TaskHandle taskHandle, int32 numSampsPerChan, float64 timeout, bool32 fillMode, float64 readArray[], uInt32 arraySizeInSamps, int32 *sampsPerChanRead, bool32 *reserved);
        int32 __CFUNC     DAQmxReadCounterU32Ex          (TaskHandle taskHandle, int32 numSampsPerChan, float64 timeout, bool32 fillMode, uInt32 readArray[], uInt32 arraySizeInSamps, int32 *sampsPerChanRead, bool32 *reserved);
        int32 __CFUNC     DAQmxReadCounterScalarF64      (TaskHandle taskHandle, float64 timeout, float64 *value, bool32 *reserved);
        int32 __CFUNC     DAQmxReadCounterScalarU32      (TaskHandle taskHandle, float64 timeout, uInt32 *value, bool32 *reserved);



        int32 __CFUNC     DAQmxReadCtrFreq               (TaskHandle taskHandle, int32 numSampsPerChan, float64 timeout, bool32 interleaved, float64 readArrayFrequency[], float64 readArrayDutyCycle[], uInt32 arraySizeInSamps, int32 *sampsPerChanRead, bool32 *reserved);
        int32 __CFUNC     DAQmxReadCtrTime               (TaskHandle taskHandle, int32 numSampsPerChan, float64 timeout, bool32 interleaved, float64 readArrayHighTime[], float64 readArrayLowTime[], uInt32 arraySizeInSamps, int32 *sampsPerChanRead, bool32 *reserved);
        int32 __CFUNC     DAQmxReadCtrTicks              (TaskHandle taskHandle, int32 numSampsPerChan, float64 timeout, bool32 interleaved, uInt32 readArrayHighTicks[], uInt32 readArrayLowTicks[], uInt32 arraySizeInSamps, int32 *sampsPerChanRead, bool32 *reserved);

        int32 __CFUNC     DAQmxReadCtrFreqScalar         (TaskHandle taskHandle, float64 timeout, float64 *frequency, float64 *dutyCycle, bool32 *reserved);
        int32 __CFUNC     DAQmxReadCtrTimeScalar         (TaskHandle taskHandle, float64 timeout, float64 *highTime, float64 *lowTime, bool32 *reserved);
        int32 __CFUNC     DAQmxReadCtrTicksScalar        (TaskHandle taskHandle, float64 timeout, uInt32 *highTicks, uInt32 *lowTicks, bool32 *reserved);



        int32 __CFUNC     DAQmxReadRaw                   (TaskHandle taskHandle, int32 numSampsPerChan, float64 timeout, void *readArray, uInt32 arraySizeInBytes, int32 *sampsRead, int32 *numBytesPerSamp, bool32 *reserved);

        int32 __CFUNC     DAQmxGetNthTaskReadChannel     (TaskHandle taskHandle, uInt32 index, char buffer[], int32 bufferSize);

        int32 __CFUNC_C   DAQmxGetReadAttribute          (TaskHandle taskHandle, int32 attribute, void *value, ...);
        int32 __CFUNC_C   DAQmxSetReadAttribute          (TaskHandle taskHandle, int32 attribute, ...);
        int32 __CFUNC     DAQmxResetReadAttribute        (TaskHandle taskHandle, int32 attribute);

        int32 __CFUNC     DAQmxConfigureLogging          (TaskHandle taskHandle, const char filePath[], int32 loggingMode, const char groupName[], int32 operation);
        int32 __CFUNC     DAQmxStartNewFile              (TaskHandle taskHandle, const char filePath[]);
        */
        [DllImport("/usr/local/natinst/lib/libnidaqmx.so", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 DAQmxReadAnalogF64(IntPtr taskHandle, Int32 numSampsPerChan, double timeout, Int32 fillMode, double[] readArray, UInt32 arraySizeInSamps, out IntPtr sampsPerChanRead, IntPtr reserved);

        [DllImport("/usr/local/natinst/lib/libnidaqmx.so", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 DAQmxConfigureLogging(IntPtr taskHandle, string filePath, Int32 loggingMode, string groupName, Int32 operation);
        #endregion
        #region Write Data
        #endregion
        #region Events & Signals
        #endregion
        #region Scale Configurations
        #endregion
        #region Buffer Configurations
        #endregion
        #region Signal Routing
        #endregion
        #region Device Control
        #endregion
        #region Watchdog Timer
        #endregion
        #region Calibration
        #endregion
        #region TEDS
        #endregion
        #region Real-time
        #endregion
        #region Storage
        #endregion
        #region System Configuration
        #endregion
        #region cDAQ Sync Connections
        #endregion
        #region Error Handling
        [DllImport("/usr/local/natinst/lib/libnidaqmx.so", CallingConvention = CallingConvention.StdCall)]
        internal static extern int DAQmxGetErrorString(Int32 errorCode, StringBuilder errorString, UInt32 buffersize);
        #endregion
        #region NI-DAQmx Specific Attribute Get/Set/Reset Function Declarations
        ////*** Set/Get functions for DAQmx_Logging_FilePath ***
        //int32 __CFUNC DAQmxGetLoggingFilePath(TaskHandle taskHandle, char* data, uInt32 bufferSize);
        //int32 __CFUNC DAQmxSetLoggingFilePath(TaskHandle taskHandle, const char* data);
        //int32 __CFUNC DAQmxResetLoggingFilePath(TaskHandle taskHandle);
        //[DllImport("/usr/local/natinst/lib/libnidaqmx.so", CallingConvention = CallingConvention.StdCall)]
        //internal static extern int DAQmxGetLoggingFilePath(IntPtr taskHandle, StringBuilder data, uint bufferSize);     //Use StringBuilder(256), and pass 256 into bufferSize
        //[DllImport("/usr/local/natinst/lib/libnidaqmx.so", CallingConvention = CallingConvention.StdCall)]
        //internal static extern int DAQmxSetLoggingFilePath(IntPtr taskHandle, string data);
        //[DllImport("/usr/local/natinst/lib/libnidaqmx.so", CallingConvention = CallingConvention.StdCall)]
        //internal static extern int DAQmxResetLoggingFilePath(IntPtr taskHandle);
        //int32 __CFUNC DAQmxGetSampClkRate(TaskHandle taskHandle, float64* data);
        [DllImport("/usr/local/natinst/lib/libnidaqmx.so", CallingConvention = CallingConvention.StdCall)]
        internal static extern int DAQmxGetSampClkRate(IntPtr taskHandle, ref double data);
        ////int32 __CFUNC DAQmxGetSampClkTimebaseDiv(TaskHandle taskHandle, uInt32 *data);
        //[DllImport("/usr/local/natinst/lib/libnidaqmx.so", CallingConvention = CallingConvention.StdCall)]
        //internal static extern int DAQmxGetSampClkTimebaseDiv(IntPtr taskHandle, ref UInt32 data);
        ////int32 __CFUNC DAQmxGetSampClkTimebaseRate(TaskHandle taskHandle, float64 *data);
        //[DllImport("/usr/local/natinst/lib/libnidaqmx.so", CallingConvention = CallingConvention.StdCall)]
        //internal static extern int DAQmxGetSampClkTimebaseRate(IntPtr taskHandle, ref double data);
        #endregion
    }
}
