using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Werewolf.Engine.EngineManagement;

namespace Werewolf.Engine
{
    public class CriticalErrorHandler
    {
        public static void HandleOutOfRam(bool efficient)
        {
            Thread thread = new Thread(delegate ()
            {
                while (true)
                {
                    if (EngineDiagnostics.ReportRamUsage() >= EngineDiagnostics.ReportTotalRam())
                    {
                        EngineInstance.CRIT();
                        GC.Collect();

                        // Out of memory
                        Debug.ErrorBox(
                            "CRITICAL ERROR:\n" +
                            "Out of memory!"
                        );

                        Environment.Exit(1);
                    }

                    if (efficient)
                        Thread.Sleep(5000);
                }
            });
            thread.Start();
        }
    }
}
