using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace DAQmx.Core.LinuxRT
{
    internal class Interop
    {
        #region Task Configuration/Control
        [DllImport("/usr/local/natinst/lib/libnidaqmx.so", CallingConvention = CallingConvention.StdCall)]
        internal static extern int DAQmxLoadTask(string taskName, out IntPtr taskHandle);

        [DllImport("/usr/local/natinst/lib/libnidaqmx.so", CallingConvention = CallingConvention.StdCall)]
        internal static extern int DAQmxCreateTask(string taskName, out IntPtr taskHandle);

        //[DllImport("/usr/local/natinst/lib/libnidaqmx.so", CallingConvention = CallingConvention.StdCall)]
        //internal static extern int DAQmxAddGlobalChansToTask(string taskName, out IntPtr taskHandle);

        [DllImport("/usr/local/natinst/lib/libnidaqmx.so", CallingConvention = CallingConvention.StdCall)]
        public static extern int DAQmxStartTask(IntPtr taskHandle);

        [DllImport("/usr/local/natinst/lib/libnidaqmx.so", CallingConvention = CallingConvention.StdCall)]
        public static extern int DAQmxStopTask(IntPtr taskHandle);

        [DllImport("/usr/local/natinst/lib/libnidaqmx.so", CallingConvention = CallingConvention.StdCall)]
        public static extern int DAQmxClearTask(IntPtr taskHandle);
        /*
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
        [DllImport("/usr/local/natinst/lib/libnidaqmx.so", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 DAQmxReadAnalogF64(IntPtr taskHandle, Int32 numSampsPerChan, double timeout, Int32 fillMode, double[] readArray, UInt32 arraySizeInSamps, out IntPtr sampsPerChanRead, IntPtr reserved);
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
        public static extern int DAQmxGetErrorString(int errorCode, StringBuilder errorString, uint buffersize);
        #endregion
    }
}
