using OpenTK;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Werewolf.Engine
{
    public class EngineDiagnostics
    {
        static PerformanceCounter? cpuPerformanceCounter;
        static double CpuUsage = 0;
        static bool isCallingCpuUsageRefresh = false;

        static System.Threading.Timer? refreshTImer;

        public static void Init()
        {
            Debug.Log("Initializing Engine Diagnostics...");

            Task initialize = new Task(() =>
            {
                cpuPerformanceCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            });
            initialize.Start();
            initialize.Wait();

            Debug.Log("Engine Diagnostics Ready!");

            // Use System.Threading.Timer instead of System.Windows.Forms.Timer
            refreshTImer = new System.Threading.Timer(RefreshCallback, null, 0, 500);
        }
        private static void RefreshCallback(object? state)
        {
            try
            {
                if (cpuPerformanceCounter != null && isCallingCpuUsageRefresh)
                {
                    CpuUsage = cpuPerformanceCounter.NextValue();
                    isCallingCpuUsageRefresh = false;
                }
            }
            catch (Exception ex)
            {
                Debug.Warning($"Failed to Update Usage: {ex.Message}");
            }
        }
        public static double ReportRamUsage()
        {
            Process currentProcess = Process.GetCurrentProcess();
            long workingSet = currentProcess.PrivateMemorySize64;
            return workingSet / (1024.0 * 1024.0);
        }
        public static double ReportPeakRamUsage()
        {
            Process currentProcess = Process.GetCurrentProcess();
            long peakMem = currentProcess.PeakWorkingSet64;
            return peakMem / (1024.0 * 1024.0);
        }
        public static double ReportTotalRam()
        {
            return (new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory) / (1024 * 1024);
        }
        public static double ReportCpuUsage()
        {
            isCallingCpuUsageRefresh = true;
            return CpuUsage;
        }
    }
}
