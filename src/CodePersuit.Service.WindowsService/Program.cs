using DasMulli.Win32.ServiceUtils;
using System;
using System.Diagnostics;

namespace CodePersuit.Service.WindowsService
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost();

            if (Debugger.IsAttached)
            {
                host.Start(null, null);
                Console.WriteLine("Press any key to stop the service");
                Console.ReadLine();
                host.Stop();
            }
            else
            {
                var win32Host = new Win32ServiceHost(host);
                win32Host.Run();
            }
        }
    }
}
